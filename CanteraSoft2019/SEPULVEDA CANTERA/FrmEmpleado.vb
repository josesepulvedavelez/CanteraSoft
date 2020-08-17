Imports System.Data
Imports System.Data.OleDb
Imports System.Windows

Public Class FrmEmpleado
    Dim conexion As OleDbConnection
    Dim adaptador As OleDbDataAdapter
    Dim construct As OleDbCommandBuilder
    Dim datos As DataSet
    Dim bmb As BindingManagerBase

    Dim sql As String = "SELECT nombres, cedula, cargo, usuario, contraseña, activo, id FROM EMPLEADO"

    Private Sub FrmEmpleado_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter(sql, conexion)
        construct = New OleDbCommandBuilder(adaptador)
        datos = New DataSet()

        Dim insertar As New OleDbCommand("INSERT INTO EMPLEADO(nombres, cedula, cargo, usuario, contraseña, activo) VALUES(@nombres, @cedula, @cargo, @usuario, @contraseña, @activo)", conexion)
        adaptador.InsertCommand = insertar
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@nombres", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@cedula", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@cargo", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@usuario", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@contraseña", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@activo", OleDbType.Boolean))

        Dim actualizar As New OleDbCommand("UPDATE EMPLEADO SET nombres=@nombres, cedula=@cedula, cargo=@cargo, usuario=@usuario, contraseña=@contraseña, activo=@activo WHERE id=@id", conexion)
        adaptador.UpdateCommand = actualizar
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@nombres", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@cedula", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@cargo", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@usuario", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@contraseña", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@activo", OleDbType.Boolean))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@id", OleDbType.VarChar))

        Dim eliminar As New OleDbCommand("DELETE * FROM EMPLEADO WHERE id=@id", conexion)
        adaptador.DeleteCommand = eliminar
        adaptador.DeleteCommand.Parameters.Add(New OleDbParameter("@id", OleDbType.VarChar))

        conexion.Open()
        adaptador.Fill(datos, "EMPLEADO")
        conexion.Close()

        txtNombre.DataBindings.Add(New Binding("Text", datos.Tables("EMPLEADO"), "nombres"))
        txtCedula.DataBindings.Add(New Binding("Text", datos.Tables("EMPLEADO"), "cedula"))
        cboCargo.DataBindings.Add(New Binding("Text", datos.Tables("EMPLEADO"), "cargo"))
        txtUsuario.DataBindings.Add(New Binding("Text", datos.Tables("EMPLEADO"), "usuario"))
        txtContraseña.DataBindings.Add(New Binding("Text", datos.Tables("EMPLEADO"), "contraseña"))
        chkActivo.DataBindings.Add(New Binding("Checked", datos.Tables("EMPLEADO"), "activo"))

        dgvEmpleado.DataSource = datos.Tables("EMPLEADO")
        dgvEmpleado.Columns("contraseña").Visible = False
        dgvEmpleado.Columns("id").Visible = False

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

    Private Sub btnSigg_Click(sender As System.Object, e As System.EventArgs) Handles btnSigg.Click
        bmb.Position += 1
        Call registro()
    End Sub

    Private Sub btnUlt_Click(sender As System.Object, e As System.EventArgs) Handles btnUlt.Click
        bmb.Position = datos.Tables("EMPLEADO").Rows.Count
        Call registro()
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        txtNombre.Clear()
        txtCedula.Clear()
        txtUsuario.Clear()
        txtContraseña.Clear()
        chkActivo.Checked = True

        btnInsertar.Enabled = True
        btnNuevo.Enabled = False
        txtNombre.Focus()
    End Sub

    Private Sub btnInsertar_Click(sender As System.Object, e As System.EventArgs) Handles btnInsertar.Click
        If txtNombre.Text = "" Or txtCedula.Text = "" Or cboCargo.Text = "" Or txtUsuario.Text = "" Then
            MessageBox.Show("Llene todos los campos ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                adaptador.InsertCommand.Parameters("@nombres").Value = txtNombre.Text
                adaptador.InsertCommand.Parameters("@cedula").Value = txtCedula.Text
                adaptador.InsertCommand.Parameters("@cargo").Value = cboCargo.Text
                adaptador.InsertCommand.Parameters("@usuario").Value = txtUsuario.Text
                adaptador.InsertCommand.Parameters("@contraseña").Value = txtContraseña.Text
                adaptador.InsertCommand.Parameters("@activo").Value = chkActivo.CheckState

                conexion.Open()
                Dim i As Integer = adaptador.InsertCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registros añadidos", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "EMPLEADO")
                dgvEmpleado.Refresh()

                chkActivo.Checked = False
                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        If txtNombre.Text = "" Or txtCedula.Text = "" Or cboCargo.Text = "" Or txtUsuario.Text = "" Then
            MessageBox.Show("Llene todos los campos ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                adaptador.UpdateCommand.Parameters("@nombres").Value = txtNombre.Text
                adaptador.UpdateCommand.Parameters("@cedula").Value = txtCedula.Text
                adaptador.UpdateCommand.Parameters("@cargo").Value = cboCargo.Text
                adaptador.UpdateCommand.Parameters("@usuario").Value = txtUsuario.Text
                adaptador.UpdateCommand.Parameters("@contraseña").Value = txtContraseña.Text
                adaptador.UpdateCommand.Parameters("@activo").Value = chkActivo.CheckState
                adaptador.UpdateCommand.Parameters("@id").Value = dgvEmpleado.CurrentRow.Cells("id").Value

                conexion.Open()
                Dim i As Integer = adaptador.UpdateCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registro actualizado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "EMPLEADO")
                dgvEmpleado.Refresh()

                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If dgvEmpleado.Rows.Count = 0 Then
            MessageBox.Show("No exiten registros en este momento para eliminar", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If MessageBox.Show("Esta seguro de eliminar este registro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Try
                    adaptador.DeleteCommand.Parameters("@id").Value = dgvEmpleado.CurrentRow.Cells("id").Value

                    conexion.Open()
                    Dim i As Integer = adaptador.DeleteCommand.ExecuteNonQuery()
                    conexion.Close()

                    MessageBox.Show(i & " Registro eliminado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    btnInsertar.Enabled = False
                    btnNuevo.Enabled = True

                    datos.Clear()
                    adaptador.Fill(datos, "EMPLEADO")
                    dgvEmpleado.Refresh()

                    Call registro()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            End If
        End If
    End Sub

    Private Sub btnExportarExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportarExcel.Click
        Dim exportarExcel As New ExportarExcel()
        exportarExcel.ExportarExcel(dgvEmpleado)
    End Sub
End Class