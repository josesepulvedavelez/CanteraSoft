Imports System.Data
Imports System.Data.OleDb

Public Class FrmMaquina
    Dim conexion As OleDbConnection
    Dim adaptador As OleDbDataAdapter
    Dim construct As OleDbCommandBuilder
    Dim datos As DataSet
    Dim bmb As BindingManagerBase

    Dim sql As String = "SELECT marca, modelo, serie, combustible, placa, notas, activo, id FROM MAQUINA"

    Private Sub FrmMaquina_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter(sql, conexion)
        construct = New OleDbCommandBuilder(adaptador)
        datos = New DataSet()

        Dim insertar As New OleDbCommand("INSERT INTO MAQUINA(marca, modelo, serie, combustible, placa, notas, activo) VALUES(@marca, @modelo, @serie, @combustible, @placa, @notas, @activo)", conexion)
        adaptador.InsertCommand = insertar
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@marca", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@modelo", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@serie", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@combustible", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@placa", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@notas", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@activo", OleDbType.Boolean))

        Dim actualizar As New OleDbCommand("UPDATE MAQUINA SET marca=@marca, modelo=@modelo, serie=@serie, combustible=@combustible, placa=@placa, notas=@notas, activo=@activo WHERE id=@id", conexion)
        adaptador.UpdateCommand = actualizar
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@marca", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@modelo", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@serie", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@combustible", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@placa", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@notas", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@activo", OleDbType.Boolean))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@id", OleDbType.VarChar))

        Dim eliminar As New OleDbCommand("DELETE * FROM MAQUINA WHERE id=@id", conexion)
        adaptador.DeleteCommand = eliminar
        adaptador.DeleteCommand.Parameters.Add(New OleDbParameter("@id", OleDbType.VarChar))

        conexion.Open()
        adaptador.Fill(datos, "MAQUINA")
        conexion.Close()

        txtMarca.DataBindings.Add(New Binding("Text", datos.Tables("MAQUINA"), "marca"))
        txtModelo.DataBindings.Add(New Binding("Text", datos.Tables("MAQUINA"), "modelo"))
        txtSerie.DataBindings.Add(New Binding("Text", datos.Tables("MAQUINA"), "serie"))
        txtCombustible.DataBindings.Add(New Binding("Text", datos.Tables("MAQUINA"), "combustible"))
        txtPlaca.DataBindings.Add(New Binding("Text", datos.Tables("MAQUINA"), "placa"))
        txtNotas.DataBindings.Add(New Binding("Text", datos.Tables("MAQUINA"), "notas"))
        chkActivo.DataBindings.Add(New Binding("Checked", datos.Tables("MAQUINA"), "activo"))

        dgvMaquina.DataSource = datos.Tables("MAQUINA")
        dgvMaquina.Columns("id").Visible = False
        bmb = BindingContext(datos.Tables(0))

        Call registro()
    End Sub

    Private Sub registro()
        txtRegistro.Text = "Registro " & (bmb.Position + 1) & " de " & datos.Tables(0).Rows.Count
    End Sub

    Private Sub btnPri_Click_1(sender As System.Object, e As System.EventArgs) Handles btnPri.Click
        bmb.Position = 0
        Call registro()
    End Sub
    
    Private Sub btnAnt_Click(sender As System.Object, e As System.EventArgs) Handles btnAnt.Click
        bmb.Position -= 1
        Call registro()
    End Sub

    Private Sub btnSigg_Click(sender As System.Object, e As System.EventArgs) Handles btnSigg.Click
        bmb.Position += 1
        Call registro()
    End Sub

    Private Sub btnUlt_Click(sender As System.Object, e As System.EventArgs) Handles btnUlt.Click
        bmb.Position = datos.Tables("MAQUINA").Rows.Count
        Call registro()
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        txtMarca.Clear()
        txtModelo.Clear()
        txtSerie.Clear()
        txtCombustible.Clear()
        txtPlaca.Clear()
        txtNotas.Clear()
        chkActivo.Checked = True

        btnInsertar.Enabled = True
        btnNuevo.Enabled = False

        txtMarca.Focus()
    End Sub

    Private Sub btnInsertar_Click(sender As System.Object, e As System.EventArgs) Handles btnInsertar.Click
        If txtMarca.Text = "" Or txtModelo.Text = "" Or txtSerie.Text = "" Or txtCombustible.Text = "" Or txtPlaca.Text = "" Or txtNotas.Text = "" Then
            MessageBox.Show("Llene todos los campos ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                adaptador.InsertCommand.Parameters("@marca").Value = txtMarca.Text
                adaptador.InsertCommand.Parameters("@modelo").Value = txtModelo.Text
                adaptador.InsertCommand.Parameters("@serie").Value = txtSerie.Text
                adaptador.InsertCommand.Parameters("@combustible").Value = txtCombustible.Text
                adaptador.InsertCommand.Parameters("@placa").Value = txtPlaca.Text
                adaptador.InsertCommand.Parameters("@notas").Value = txtNotas.Text
                adaptador.InsertCommand.Parameters("@activo").Value = chkActivo.CheckState

                conexion.Open()
                Dim i As Integer = adaptador.InsertCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registros añadidos", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "MAQUINA")
                dgvMaquina.Refresh()

                bmb.Position = datos.Tables("MAQUINA").Rows.Count
                chkActivo.Checked = False
                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        If txtMarca.Text = "" Or txtModelo.Text = "" Or txtSerie.Text = "" Or txtCombustible.Text = "" Or txtPlaca.Text = "" Or txtNotas.Text = "" Then
            MessageBox.Show("Llene todos los campos ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                adaptador.UpdateCommand.Parameters("@marca").Value = txtMarca.Text
                adaptador.UpdateCommand.Parameters("@modelo").Value = txtModelo.Text
                adaptador.UpdateCommand.Parameters("@serie").Value = txtSerie.Text
                adaptador.UpdateCommand.Parameters("@combustible").Value = txtCombustible.Text
                adaptador.UpdateCommand.Parameters("@placa").Value = txtPlaca.Text
                adaptador.UpdateCommand.Parameters("@notas").Value = txtNotas.Text
                adaptador.UpdateCommand.Parameters("@activo").Value = chkActivo.CheckState
                adaptador.UpdateCommand.Parameters("@id").Value = dgvMaquina.CurrentRow.Cells("id").Value

                conexion.Open()
                Dim i As Integer = adaptador.UpdateCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registro actualizado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "MAQUINA")
                dgvMaquina.Refresh()

                bmb.Position = datos.Tables("MAQUINA").Rows.Count
                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If MessageBox.Show("Esta seguro de eliminar este registro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                adaptador.DeleteCommand.Parameters("@id").Value = dgvMaquina.CurrentRow.Cells("id").Value

                conexion.Open()
                Dim i As Integer = adaptador.DeleteCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registro eliminado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "MAQUINA")
                dgvMaquina.Refresh()

                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub btnHorometroTanqueo_Click(sender As Object, e As EventArgs) Handles btnHorometroTanqueo.Click
        FrmHorometro_Tanqueo.Show()
        FrmHorometro_Tanqueo.MdiParent = FrmMenu
    End Sub

    Private Sub btnExportarExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportarExcel.Click
        Dim exportarExcel As New ExportarExcel()
        exportarExcel.ExportarExcel(dgvMaquina)
    End Sub
End Class