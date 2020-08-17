Imports System.Data
Imports System.Data.OleDb

Public Class FrmCliente
    Dim conexion As OleDbConnection
    Dim adaptador As OleDbDataAdapter
    Dim construct As OleDbCommandBuilder
    Dim datos As DataSet
    Dim bmb As BindingManagerBase

    Dim sql As String = "SELECT cliente, nit, contacto, telefono, celular, activo, id FROM CLIENTE"

    Private Sub FrmCliente_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter(sql, conexion)
        construct = New OleDbCommandBuilder(adaptador)
        datos = New DataSet()

        Dim insertar As New OleDbCommand("INSERT INTO CLIENTE(cliente, nit, contacto, telefono, celular, activo) VALUES(@cliente, @nit, @contacto, @telefono, @celular, @activo)", conexion)
        adaptador.InsertCommand = insertar
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@cliente", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@nit", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@contacto", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@telefono", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@celular", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@activo", OleDbType.Boolean))

        Dim actualizar As New OleDbCommand("UPDATE CLIENTE SET cliente=@cliente, nit=@nit, contacto=@contacto, telefono=@telefono, celular=@celular, activo=@activo WHERE id=@id", conexion)
        adaptador.UpdateCommand = actualizar
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@cliente", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@nit", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@contacto", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@telefono", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@celular", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@activo", OleDbType.Boolean))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@id", OleDbType.VarChar))

        Dim eliminar As New OleDbCommand("DELETE * FROM CLIENTE WHERE id=@id", conexion)
        adaptador.DeleteCommand = eliminar
        adaptador.DeleteCommand.Parameters.Add(New OleDbParameter("@id", OleDbType.VarChar))

        conexion.Open()
        adaptador.Fill(datos, "CLIENTE")
        conexion.Close()

        txtCliente.DataBindings.Add(New Binding("Text", datos.Tables("CLIENTE"), "cliente"))
        txtNit.DataBindings.Add(New Binding("Text", datos.Tables("CLIENTE"), "nit"))
        txtContacto.DataBindings.Add(New Binding("Text", datos.Tables("CLIENTE"), "contacto"))
        txtTelefono.DataBindings.Add(New Binding("Text", datos.Tables("CLIENTE"), "telefono"))
        txtCelular.DataBindings.Add(New Binding("Text", datos.Tables("CLIENTE"), "celular"))
        chkActivo.DataBindings.Add(New Binding("Checked", datos.Tables("CLIENTE"), "activo"))

        dgvCliente.DataSource = datos.Tables("CLIENTE")
        dgvCliente.Columns("id").Visible = False

        bmb = BindingContext(datos.Tables(0))
        Call registro()
    End Sub

    Private Sub registro()
        txtRegistro.Text = "Registro " & (bmb.Position + 1) & " de " & datos.Tables(0).Rows.Count
    End Sub

    Private Sub btnPri_Click(sender As System.Object, e As System.EventArgs) Handles btnPri.Click
        bmb.Position = 0
        Call registro()
    End Sub

    Private Sub btnAnt_Click(sender As System.Object, e As System.EventArgs) Handles btnAnt.Click
        bmb.Position -= 1
        Call registro()
    End Sub

    Private Sub btnUlt_Click(sender As System.Object, e As System.EventArgs) Handles btnUlt.Click
        bmb.Position += 1
        Call registro()
    End Sub

    Private Sub btnSigg_Click(sender As System.Object, e As System.EventArgs) Handles btnSigg.Click
        bmb.Position = datos.Tables("CLIENTE").Rows.Count
        Call registro()
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        txtCliente.Clear()
        txtNit.Clear()
        txtContacto.Clear()
        txtTelefono.Clear()
        txtCelular.Clear()
        chkActivo.Checked = True

        btnInsertar.Enabled = True
        btnNuevo.Enabled = False

        txtCliente.Focus()
    End Sub

    Private Sub btnInsertar_Click(sender As System.Object, e As System.EventArgs) Handles btnInsertar.Click
        If txtCliente.Text = "" Or txtNit.Text = "" Or txtContacto.Text = "" Or txtTelefono.Text = "" Or txtCelular.Text = "" Then
            MessageBox.Show("Llene todos los campos ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                adaptador.InsertCommand.Parameters("@cliente").Value = txtCliente.Text
                adaptador.InsertCommand.Parameters("@nit").Value = txtNit.Text
                adaptador.InsertCommand.Parameters("@contacto").Value = txtContacto.Text
                adaptador.InsertCommand.Parameters("@telefono").Value = txtTelefono.Text
                adaptador.InsertCommand.Parameters("@celular").Value = txtCelular.Text
                adaptador.InsertCommand.Parameters("@activo").Value = chkActivo.CheckState

                conexion.Open()
                Dim i As Integer = adaptador.InsertCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registros añadidos", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "CLIENTE")
                dgvCliente.Refresh()

                bmb.Position = datos.Tables("CLIENTE").Rows.Count
                chkActivo.Checked = False
                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        If txtCliente.Text = "" Or txtNit.Text = "" Or txtContacto.Text = "" Or txtTelefono.Text = "" Or txtCelular.Text = "" Then
            MessageBox.Show("Llene todos los campos ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                adaptador.UpdateCommand.Parameters("@cliente").Value = txtCliente.Text
                adaptador.UpdateCommand.Parameters("@nit").Value = txtNit.Text
                adaptador.UpdateCommand.Parameters("@contacto").Value = txtContacto.Text
                adaptador.UpdateCommand.Parameters("@telefono").Value = txtTelefono.Text
                adaptador.UpdateCommand.Parameters("@celular").Value = txtCelular.Text
                adaptador.UpdateCommand.Parameters("@activo").Value = chkActivo.CheckState
                adaptador.UpdateCommand.Parameters("@id").Value = dgvCliente.CurrentRow.Cells("id").Value

                conexion.Open()
                Dim i As Integer = adaptador.UpdateCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registro actualizado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "CLIENTE")
                dgvCliente.Refresh()

                bmb.Position = datos.Tables("CLIENTE").Rows.Count
                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If MessageBox.Show("Esta seguro de eliminar este registro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                adaptador.DeleteCommand.Parameters("@id").Value = dgvCliente.CurrentRow.Cells("id").Value

                conexion.Open()
                Dim i As Integer = adaptador.DeleteCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registro eliminado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "CLIENTE")
                dgvCliente.Refresh()

                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscar.TextChanged
        Dim sql As String
        Dim tabla As DataTable

        If cboBuscar.Text = "Cliente" Then
            sql = "SELECT * FROM CLIENTE WHERE cliente LIKE '%" + txtBuscar.Text + "%' ORDER BY cliente"
            adaptador = New OleDbDataAdapter(sql, conexion)

            tabla = New DataTable()

            conexion.Open()
            adaptador.Fill(tabla)
            conexion.Close()

            dgvClienteBuscar.DataSource = tabla
            dgvClienteBuscar.Columns("id").Visible = False

        ElseIf cboBuscar.Text = "Nit" Then
            sql = "SELECT * FROM CLIENTE WHERE nit LIKE '%" + txtBuscar.Text + "%' ORDER BY cliente"
            adaptador = New OleDbDataAdapter(sql, conexion)

            tabla = New DataTable()

            conexion.Open()
            adaptador.Fill(tabla)
            conexion.Close()

            dgvClienteBuscar.DataSource = tabla
            dgvClienteBuscar.Columns("id").Visible = False

        ElseIf cboBuscar.Text = "Contacto" Then
            sql = "SELECT * FROM CLIENTE WHERE contacto LIKE '%" + txtBuscar.Text + "%' ORDER BY cliente"
            adaptador = New OleDbDataAdapter(sql, conexion)

            tabla = New DataTable()

            conexion.Open()
            adaptador.Fill(tabla)
            conexion.Close()

            dgvClienteBuscar.DataSource = tabla
            dgvClienteBuscar.Columns("id").Visible = False

        ElseIf cboBuscar.Text = "Telefono" Then
            sql = "SELECT * FROM CLIENTE WHERE telefono LIKE '%" + txtBuscar.Text + "%' ORDER BY cliente"
            adaptador = New OleDbDataAdapter(sql, conexion)

            tabla = New DataTable()

            conexion.Open()
            adaptador.Fill(tabla)
            conexion.Close()

            dgvClienteBuscar.DataSource = tabla
            dgvClienteBuscar.Columns("id").Visible = False

        ElseIf cboBuscar.Text = "Celular" Then
            sql = "SELECT * FROM CLIENTE WHERE celular LIKE '%" + txtBuscar.Text + "%' ORDER BY cliente"
            adaptador = New OleDbDataAdapter(sql, conexion)

            tabla = New DataTable()

            conexion.Open()
            adaptador.Fill(tabla)
            conexion.Close()

            dgvClienteBuscar.DataSource = tabla
            dgvClienteBuscar.Columns("id").Visible = False
        End If

        If dgvClienteBuscar.Rows.Count < 1 Then
            ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
            ErrorProvider1.SetError(txtBuscar, "No hay registros")
        Else
            ErrorProvider1.SetError(txtBuscar, "")
        End If
    End Sub

    Private Sub btnExportarExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportarExcel.Click
        Dim exportarExcel As New ExportarExcel()
        exportarExcel.ExportarExcel(dgvCliente)
    End Sub

    Private Sub dgvCliente_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCliente.CellContentClick

    End Sub
End Class