Imports System.Data
Imports System.Data.OleDb

Public Class FrmValera
    Dim conexion As OleDbConnection
    Dim adaptador As OleDbDataAdapter
    Dim adaptadorCli As OleDbDataAdapter
    Dim construct As OleDbCommandBuilder
    Dim datos As DataSet
    Dim bmb As BindingManagerBase

    Dim sql As String = "SELECT CodigoBarras, fecha, Orden, Cliente, ValorVale, Descargada, VALERA.Id FROM CLIENTE, VALERA WHERE CLIENTE.id = VALERA.IdCliente"
    Dim sqlCliente As String = "SELECT Cliente, Id FROM CLIENTE WHERE Activo = True ORDER BY Cliente"

    Private Sub FrmValera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter(sql, conexion)
        construct = New OleDbCommandBuilder(adaptador)
        datos = New DataSet()

        Dim insertar As New OleDbCommand("INSERT INTO VALERA(CodigoBarras, Fecha, Orden, IdCliente, ValorVale) VALUES(@CodigoBarras, @Fecha, @Orden, @IdCliente, @ValorVale)", conexion)
        adaptador.InsertCommand = insertar
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@CodigoBarras", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@Fecha", OleDbType.Date))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@Orden", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@IdCliente", OleDbType.Integer))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@ValorVale", OleDbType.Integer))

        Dim actualizar As New OleDbCommand("UPDATE VALERA SET CodigoBarras=@CodigoBarras, Fecha=@Fecha, Orden=@Orden, IdCliente=@IdCliente, ValorVale=@ValorVale WHERE id=@id", conexion)
        adaptador.UpdateCommand = actualizar
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@CodigoBarras", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@Fecha", OleDbType.Date))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@Orden", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@IdCliente", OleDbType.Integer))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@ValorVale", OleDbType.Integer))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@Id", OleDbType.Integer))

        Dim eliminar As New OleDbCommand("DELETE * FROM VALERA WHERE id=@id", conexion)
        adaptador.DeleteCommand = eliminar
        adaptador.DeleteCommand.Parameters.Add(New OleDbParameter("@id", OleDbType.VarChar))

        conexion.Open()
        adaptador.Fill(datos, "VALERA")
        conexion.Close()

        'cboCliente.DataBindings.Add(New Binding("Text", datos.Tables("CLIENTE"), "cliente"))
        txtCodigoBarras.DataBindings.Add(New Binding("Text", datos.Tables("VALERA"), "CodigoBarras"))
        dtpFecha.DataBindings.Add(New Binding("Text", datos.Tables("VALERA"), "Fecha"))
        txtOrden.DataBindings.Add(New Binding("Text", datos.Tables("VALERA"), "Orden"))
        cboCliente.DataBindings.Add(New Binding("Text", datos.Tables("VALERA"), "Cliente"))
        txtValorVale.DataBindings.Add(New Binding("Text", datos.Tables("VALERA"), "ValorVale"))

        REM carga del datagridview
        dgvValera.DataSource = datos.Tables("VALERA")
        dgvValera.Columns("id").Visible = False

        REM carga del combo cliente
        cargarCombo()

        bmb = BindingContext(datos.Tables(0))

        Call registro()
    End Sub

    Private Sub cargarCombo()
        adaptadorCli = New OleDbDataAdapter(sqlCliente, conexion)
        adaptadorCli.Fill(datos, "CLIENTE")

        cboCliente.DataSource = datos.Tables("CLIENTE")
        cboCliente.DisplayMember = "Cliente"
        cboCliente.ValueMember = "Id"
    End Sub

    Private Sub registro()
        txtRegistro.Text = "Registro " & (bmb.Position + 1) & " de " & datos.Tables(0).Rows.Count
        'cargarCombo()
    End Sub

    Private Sub btnPri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPri.Click
        bmb.Position = 0
        Call registro()
    End Sub

    Private Sub btnAnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnt.Click
        bmb.Position -= 1
        Call registro()
    End Sub

    Private Sub btnSig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSig.Click
        bmb.Position += 1
        Call registro()
    End Sub

    Private Sub btnUlt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUlt.Click
        bmb.Position = datos.Tables("VALERA").Rows.Count
        Call registro()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        txtCodigoBarras.Clear()
        dtpFecha.Value = DateTime.Now.Date
        txtOrden.Clear()
        txtValorVale.Clear()

        btnInsertar.Enabled = True
        btnNuevo.Enabled = False

        txtCodigoBarras.Focus()
    End Sub

    Private Sub btnInsertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertar.Click
        If txtCodigoBarras.Text = "" Or txtOrden.Text = "" Or txtValorVale.Text = "" Then
            MessageBox.Show("Llene todos los campos correctamente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                adaptador.InsertCommand.Parameters("@CodigoBarras").Value = txtCodigoBarras.Text
                adaptador.InsertCommand.Parameters("@Fecha").Value = dtpFecha.Value
                adaptador.InsertCommand.Parameters("@Orden").Value = txtOrden.Text
                adaptador.InsertCommand.Parameters("@IdCLiente").Value = cboCliente.SelectedValue
                adaptador.InsertCommand.Parameters("@ValorVale").Value = txtValorVale.Text

                conexion.Open()
                Dim i As Integer = adaptador.InsertCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registros añadidos", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "VALERA")
                adaptadorCli.Fill(datos, "CLIENTE")
                dgvValera.Refresh()

                bmb.Position = datos.Tables("VALERA").Rows.Count
                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        If txtCodigoBarras.Text = "" Or txtOrden.Text = "" Or txtValorVale.Text = "" Then
            MessageBox.Show("Llene todos los campos ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                adaptador.UpdateCommand.Parameters("@CodigoBarras").Value = txtCodigoBarras.Text
                adaptador.UpdateCommand.Parameters("@Fecha").Value = dtpFecha.Value
                adaptador.UpdateCommand.Parameters("@Orden").Value = txtOrden.Text
                adaptador.UpdateCommand.Parameters("@IdCLiente").Value = cboCliente.SelectedValue
                adaptador.UpdateCommand.Parameters("@ValorVale").Value = txtValorVale.Text
                adaptador.UpdateCommand.Parameters("@id").Value = dgvValera.CurrentRow.Cells("id").Value

                conexion.Open()
                Dim i As Integer = adaptador.UpdateCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registro actualizado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "VALERA")
                adaptadorCli.Fill(datos, "CLIENTE")
                dgvValera.Refresh()

                bmb.Position = datos.Tables("VALERA").Rows.Count
                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If MessageBox.Show("Esta seguro de eliminar este registro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                adaptador.DeleteCommand.Parameters("@id").Value = dgvValera.CurrentRow.Cells("id").Value

                conexion.Open()
                Dim i As Integer = adaptador.DeleteCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registro eliminado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "VALERA")
                adaptadorCli.Fill(datos, "CLIENTE")
                dgvValera.Refresh()

                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        Dim dv As New DataView(datos.Tables("VALERA"))

        If cboBuscar.Text = "CodigoBarras" Then
            dv.RowFilter = "CodigoBarras LIKE '%" + txtBuscar.Text + "%' "

        ElseIf cboBuscar.Text = "Cliente" Then
            dv.RowFilter = "Cliente LIKE '%" + txtBuscar.Text + "%' "

        ElseIf cboBuscar.Text = "Orden" Then
            dv.RowFilter = "Orden LIKE '%" + txtBuscar.Text + "%' "
        End If

        dgvValeraBuscar.DataSource = dv
        dgvValeraBuscar.Columns("Id").Visible = False

        If dgvValeraBuscar.Rows.Count < 1 Then
            ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
            ErrorProvider1.SetError(txtBuscar, "No hay registros")
        Else
            ErrorProvider1.SetError(txtBuscar, "")
        End If
    End Sub

    Private Sub btnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarExcel.Click
        Dim exportarExcel As New ExportarExcel()

        If TabControl1.SelectedIndex = 0 Then
            exportarExcel.ExportarExcel(dgvValera)
        ElseIf TabControl1.SelectedIndex = 1 Then
            exportarExcel.ExportarExcel(dgvValeraBuscar)
        End If
    End Sub

    Private Sub btnValeraCargaMasiva_Click(sender As System.Object, e As System.EventArgs) Handles btnValeraCargaMasiva.Click
        FrmValeraCargar.Show()
    End Sub
End Class