Imports System.Data
Imports System.Data.OleDb

Public Class FrmValeraDescarga
    Dim conexion As OleDbConnection
    Dim adaptador As OleDbDataAdapter
    Dim adaptadorCli As OleDbDataAdapter
    Dim adaptadorMat As OleDbDataAdapter
    Dim construct As OleDbCommandBuilder
    Dim datos As DataSet
    Dim bmb As BindingManagerBase

    Dim sql As String = "SELECT CodigoBarras, VALERA_DESCARGA.Fecha, Cliente, Placa, Mt3, Orden, ValorVale, Material, Lugar, Efectivo, Observaciones, IdValera, VALERA_DESCARGA.Id FROM CLIENTE, VALERA, VALERA_DESCARGA WHERE CLIENTE.Id = VALERA.IdCliente AND VALERA.Id = VALERA_DESCARGA.idValera"
    Dim sqlCliente As String = "SELECT Cliente, Cliente.Id AS IdCliente, CodigoBarras, Orden, ValorVale, VALERA.Id as IdValera FROM CLIENTE, VALERA WHERE CLIENTE.Id = VALERA.IdCliente AND CodigoBarras = @CodigoBarras AND Descargada=False"
    Dim sqlMaterial As String = "SELECT Descripcion, Id FROM MATERIAL"

    Private Sub FrmValeraDescarga_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter(sql, conexion)
        datos = New DataSet()

        Dim insertar As New OleDbCommand("INSERT INTO VALERA_DESCARGA(Fecha, Lugar, Material, Efectivo, Placa, Mt3, Observaciones, IdValera) VALUES(@Fecha, @Lugar, @Material, @Efectivo, @Placa, @Mt3, @Observaciones, @IdValera)", conexion)
        adaptador.InsertCommand = insertar
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@Fecha", OleDbType.Date))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@Lugar", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@Material", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@Efectivo", OleDbType.Integer))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@Placa", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@Mt3", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@Observaciones", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@IdValera", OleDbType.VarChar))

        'Dim actualizar As New OleDbCommand("UPDATE VALERA_DESCARGA SET Fecha=@Fecha, Lugar=@Lugar, Material=@Material, Efectivo=@Efectivo, Placa=@Placa, Mt3=@Mt3, Observaciones=@Observaciones, IdValera=@IdValera WHERE Id=@Id", conexion)
        'adaptador.UpdateCommand = actualizar
        'adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@Fecha", OleDbType.Date))
        'adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@Lugar", OleDbType.VarChar))
        'adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@Material", OleDbType.VarChar))
        'adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@Efectivo", OleDbType.Integer))
        'adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@Placa", OleDbType.VarChar))
        'adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@Mt3", OleDbType.VarChar))
        'adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@Observaciones", OleDbType.VarChar))
        'adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@IdValera", OleDbType.VarChar))
        'adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@Id", OleDbType.Integer))

        Dim eliminar As New OleDbCommand("DELETE * FROM VALERA_DESCARGA WHERE id=@id", conexion)
        adaptador.DeleteCommand = eliminar
        adaptador.DeleteCommand.Parameters.Add(New OleDbParameter("@id", OleDbType.VarChar))

        conexion.Open()
        adaptador.Fill(datos, "VALERA_DESCARGA")
        conexion.Close()

        dgvValeraDescarga.DataSource = datos.Tables("VALERA_DESCARGA")
        dgvValeraDescarga.Columns("IdValera").Visible = False
        dgvValeraDescarga.Columns("Id").Visible = False

        dtpFecha.DataBindings.Add(New Binding("Text", datos.Tables("VALERA_DESCARGA"), "Fecha"))
        txtCodigoBarras.DataBindings.Add(New Binding("Text", datos.Tables("VALERA_DESCARGA"), "CodigoBarras"))
        txtCliente.DataBindings.Add(New Binding("Text", datos.Tables("VALERA_DESCARGA"), "Cliente"))
        txtPlaca.DataBindings.Add(New Binding("Text", datos.Tables("VALERA_DESCARGA"), "Placa"))
        txtMt3.DataBindings.Add(New Binding("Text", datos.Tables("VALERA_DESCARGA"), "Mt3"))
        txtMaterial.DataBindings.Add(New Binding("Text", datos.Tables("VALERA_DESCARGA"), "Material"))
        cboLugar.DataBindings.Add(New Binding("Text", datos.Tables("VALERA_DESCARGA"), "Lugar"))
        txtEfectivo.DataBindings.Add(New Binding("Text", datos.Tables("VALERA_DESCARGA"), "Efectivo"))
        txtOrden.DataBindings.Add(New Binding("Text", datos.Tables("VALERA_DESCARGA"), "Orden"))
        txtValorVale.DataBindings.Add(New Binding("Text", datos.Tables("VALERA_DESCARGA"), "ValorVale"))
        txtObservaciones.DataBindings.Add(New Binding("Text", datos.Tables("VALERA_DESCARGA"), "Observaciones"))
        txtIdValera.DataBindings.Add(New Binding("Text", datos.Tables("VALERA_DESCARGA"), "IdValera"))

        bmb = BindingContext(datos.Tables("VALERA_DESCARGA"))
        Call registro()

        Busqueda.busqueda(txtPlaca, "SELECT Placa FROM VEHICULO WHERE Activo = True")
        Busqueda.busqueda(txtMaterial, "SELECT Descripcion FROM MATERIAL WHERE Activo = True")
    End Sub

    Private Sub registro()
        txtRegistro.Text = "Registro " & (bmb.Position + 1) & " de " & datos.Tables(0).Rows.Count
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
        bmb.Position = datos.Tables("VALERA_DESCARGA").Rows.Count
        Call registro()
    End Sub

    Private Sub txtCodigoBarras_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodigoBarras.Validating
        If txtCodigoBarras.Text = "" Then
            MessageBox.Show("Llene el campo CODIGO DE BARRAS", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCodigoBarras.Focus()
        Else
            adaptadorCli = New OleDbDataAdapter(sqlCliente, conexion)
            adaptadorCli.SelectCommand.Parameters.AddWithValue("@CodigoBarras", txtCodigoBarras.Text)
            adaptadorCli.Fill(datos, "CLIENTE")

            If datos.Tables("CLIENTE").Rows.Count <= 0 Then
                MessageBox.Show("No existe el codigo de barras o ya fue descargada la valera", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCodigoBarras.Focus()
            Else
                txtCliente.Text = datos.Tables("CLIENTE").Rows(0)("Cliente").ToString()
                txtValorVale.Text = datos.Tables("CLIENTE").Rows(0)("ValorVale").ToString()
                txtOrden.Text = datos.Tables("CLIENTE").Rows(0)("Orden").ToString()
                txtIdValera.Text = datos.Tables("CLIENTE").Rows(0)("IdValera").ToString()
                'Me.Text = datos.Tables("CLIENTE").Rows(0)("IdCliente").ToString()
            End If

            datos.Tables("CLIENTE").Clear()
        End If
    End Sub

    Private Sub txtPlaca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPlaca.TextChanged
        Try
            Using conexion As New OleDbConnection(ConexionDatos.conectar())
                Dim sql As String = "SELECT MT3, id FROM VEHICULO WHERE placa LIKE '%" + txtPlaca.Text + "%' "
                Dim adaptador As New OleDbDataAdapter(sql, conexion)

                Dim tbl As New DataTable()

                conexion.Open()
                adaptador.Fill(tbl)
                conexion.Close()

                txtMt3.Text = tbl.Rows(0)("Mt3").ToString()
            End Using
        Catch ex As Exception
            txtMt3.Text = "0"
        End Try
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        dtpFecha.Value = DateTime.Now.Date
        txtCodigoBarras.Clear()
        txtCliente.Clear()
        txtPlaca.Clear()
        txtMt3.Clear()
        txtMaterial.Clear()

        txtEfectivo.Text = 0
        txtOrden.Clear()
        txtValorVale.Text = ""
        txtObservaciones.Text = "NINGUNA"
        txtIdValera.Clear()

        btnNuevo.Enabled = False
        btnInsertar.Enabled = True
        txtCodigoBarras.Focus()
    End Sub

    Private Sub btnInsertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertar.Click
        If txtCodigoBarras.Text = "" Or txtCliente.Text = "" Or txtPlaca.Text = "" Or txtMt3.Text = "" Or txtMaterial.Text = "" Or cboLugar.Text = "" Or txtEfectivo.Text = "" Or txtValorVale.Text = "" Or txtOrden.Text = "" Or txtIdValera.Text = "" Then
            MessageBox.Show("Llene todos los campos correctamente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                adaptador.InsertCommand.Parameters("@Fecha").Value = dtpFecha.Text
                adaptador.InsertCommand.Parameters("@Lugar").Value = cboLugar.Text
                adaptador.InsertCommand.Parameters("@Material").Value = txtMaterial.Text
                adaptador.InsertCommand.Parameters("@Efectivo").Value = txtEfectivo.Text
                adaptador.InsertCommand.Parameters("@Mt3").Value = txtMt3.Text
                adaptador.InsertCommand.Parameters("@Placa").Value = txtPlaca.Text
                adaptador.InsertCommand.Parameters("@Observaciones").Value = txtObservaciones.Text
                adaptador.InsertCommand.Parameters("@IdValera").Value = txtIdValera.Text

                Dim sqlValera As String = "UPDATE VALERA SET Descargada=True WHERE Id=@IdValera"
                Dim cmdValera As New OleDbCommand(sqlValera, conexion)

                cmdValera.Parameters.AddWithValue("@IdValera", txtIdValera.Text)

                conexion.Open()
                Dim i As Integer = adaptador.InsertCommand.ExecuteNonQuery()
                Dim res As Integer = cmdValera.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registros añadidos", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "VALERA_DESCARGA")
                dgvValeraDescarga.Refresh()

                bmb.Position = datos.Tables("VALERA_DESCARGA").Rows.Count
                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        'If txtCodigoBarras.Text = "" Or txtCliente.Text = "" Or txtPlaca.Text = "" Or txtMt3.Text = "" Or txtMaterial.Text = "" Or cboLugar.Text = "" Or txtEfectivo.Text = "" Or txtValorVale.Text = "" Or txtOrden.Text = "" Or txtIdValera.Text = "" Then
        '    MessageBox.Show("Llene todos los campos correctamente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'Else
        '    Try
        '        adaptador.UpdateCommand.Parameters("@Fecha").Value = dtpFecha.Text
        '        adaptador.UpdateCommand.Parameters("@Lugar").Value = cboLugar.Text
        '        adaptador.UpdateCommand.Parameters("@Material").Value = txtMaterial.Text
        '        adaptador.UpdateCommand.Parameters("@Efectivo").Value = txtEfectivo.Text
        '        adaptador.UpdateCommand.Parameters("@Mt3").Value = txtMt3.Text
        '        adaptador.UpdateCommand.Parameters("@Placa").Value = txtPlaca.Text
        '        adaptador.UpdateCommand.Parameters("@Observaciones").Value = txtObservaciones.Text
        '        adaptador.UpdateCommand.Parameters("@IdValera").Value = txtIdValera.Text
        '        adaptador.UpdateCommand.Parameters("@Id").Value = dgvValeraDescarga.CurrentRow.Cells("Id").Value

        '        conexion.Open()
        '        Dim i As Integer = adaptador.DeleteCommand.ExecuteNonQuery()
        '        conexion.Close()

        '        MessageBox.Show(i & " Registro eliminado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        btnInsertar.Enabled = False
        '        btnNuevo.Enabled = True

        '        datos.Clear()
        '        adaptador.Fill(datos, "VALERA_DESCARGA")
        '        dgvValeraDescarga.Refresh()

        '        Call registro()
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    End Try
        'End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If MessageBox.Show("Esta seguro de eliminar este registro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                adaptador.DeleteCommand.Parameters("@id").Value = dgvValeraDescarga.CurrentRow.Cells("id").Value

                Dim sqlValera As String = "UPDATE VALERA SET Descargada=False WHERE Id=@IdValera"
                Dim cmdValera As New OleDbCommand(sqlValera, conexion)

                cmdValera.Parameters.AddWithValue("@IdValera", txtIdValera.Text)

                conexion.Open()
                Dim i As Integer = adaptador.DeleteCommand.ExecuteNonQuery()
                cmdValera.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registro eliminado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "VALERA_DESCARGA")
                dgvValeraDescarga.Refresh()

                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        Dim dv As New DataView(datos.Tables("VALERA_DESCARGA"))

        If cboBuscar.Text = "CodigoBarras" Then
            dv.RowFilter = "CodigoBarras LIKE '%" + txtBuscar.Text + "%' "

        ElseIf cboBuscar.Text = "Cliente" Then
            dv.RowFilter = "Cliente LIKE '%" + txtBuscar.Text + "%' "

        ElseIf cboBuscar.Text = "Placa" Then
            dv.RowFilter = "Placa LIKE '%" + txtBuscar.Text + "%' "

        ElseIf cboBuscar.Text = "Material" Then
            dv.RowFilter = "Material LIKE '%" + txtBuscar.Text + "%' "

        ElseIf cboBuscar.Text = "Orden" Then
            dv.RowFilter = "Orden LIKE '%" + txtBuscar.Text + "%' "

        ElseIf cboBuscar.Text = "Lugar" Then
            dv.RowFilter = "Lugar LIKE '%" + txtBuscar.Text + "%' "

        ElseIf cboBuscar.Text = "Observaciones" Then
            dv.RowFilter = "Observaciones LIKE '%" + txtBuscar.Text + "%' "
        End If

        dgvValeraDescargaBuscar.DataSource = dv
        dgvValeraDescargaBuscar.Columns("IdValera").Visible = False
        dgvValeraDescargaBuscar.Columns("Id").Visible = False

        If dv.Count < 1 Then
            ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
            ErrorProvider1.SetError(txtBuscar, "No hay registros")
        Else
            ErrorProvider1.SetError(txtBuscar, "")
        End If
    End Sub

    Private Sub btnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarExcel.Click
        Dim exportarExcel As New ExportarExcel()

        If TabControl1.SelectedIndex = 0 Then
            exportarExcel.ExportarExcel(dgvValeraDescarga)
        ElseIf TabControl1.SelectedIndex = 1 Then
            exportarExcel.ExportarExcel(dgvValeraDescargaBuscar)
        End If
    End Sub

End Class