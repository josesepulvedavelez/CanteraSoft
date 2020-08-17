Imports System.Data
Imports System.Data.OleDb
Imports System.Windows

Public Class FrmMaterial
    Dim conexion As OleDbConnection
    Dim adaptador As OleDbDataAdapter
    Dim construct As OleDbCommandBuilder
    Dim datos As DataSet
    Dim bmb As BindingManagerBase

    Dim sql As String = "SELECT codigo, descripcion, medida, activo, id FROM MATERIAL"

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter(sql, conexion)
        construct = New OleDbCommandBuilder(adaptador)
        datos = New DataSet()

        Dim insertar As New OleDbCommand("INSERT INTO MATERIAL(codigo, descripcion, medida, activo) VALUES(@codigo, @descripcion, @medida, @activo)", conexion)
        adaptador.InsertCommand = insertar
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@codigo", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@descripcion", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@medida", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@activo", OleDbType.Boolean))

        Dim actualizar As New OleDbCommand("UPDATE MATERIAL SET codigo=@codigo, descripcion=@descripcion, medida=@medida, activo=@activo WHERE id=@id", conexion)
        adaptador.UpdateCommand = actualizar
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@codigo", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@descripcion", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@medida", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@activo", OleDbType.Boolean))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@id", OleDbType.VarChar))

        Dim eliminar As New OleDbCommand("DELETE * FROM MATERIAL WHERE id=@id", conexion)
        adaptador.DeleteCommand = eliminar
        adaptador.DeleteCommand.Parameters.Add(New OleDbParameter("@id", OleDbType.VarChar))

        conexion.Open()
        adaptador.Fill(datos, "MATERIAL")
        conexion.Close()

        txtCodigo.DataBindings.Add(New Binding("Text", datos.Tables("MATERIAL"), "codigo"))
        txtDescripcion.DataBindings.Add(New Binding("Text", datos.Tables("MATERIAL"), "descripcion"))
        txtMedida.DataBindings.Add(New Binding("Text", datos.Tables("MATERIAL"), "medida"))
        chkActivo.DataBindings.Add(New Binding("Checked", datos.Tables("MATERIAL"), "activo"))

        dgvMaterial.DataSource = datos.Tables("MATERIAL")
        dgvMaterial.Columns("id").Visible = False
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

    Private Sub btnSig_Click(sender As System.Object, e As System.EventArgs) Handles btnUlt.Click
        bmb.Position += 1
        Call registro()
    End Sub

    Private Sub btnUlt_Click(sender As System.Object, e As System.EventArgs) Handles btnSigg.Click
        bmb.Position = datos.Tables("MATERIAL").Rows.Count
        Call registro()
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        txtCodigo.Clear()
        txtDescripcion.Clear()
        chkActivo.Checked = True

        btnInsertar.Enabled = True
        btnNuevo.Enabled = False

        txtCodigo.Focus()
    End Sub

    Private Sub btnInsertar_Click(sender As System.Object, e As System.EventArgs) Handles btnInsertar.Click
        If txtCodigo.Text = "" Or txtDescripcion.Text = "" Or txtMedida.Text = "" Then
            MessageBox.Show("Llene todos los campos ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                adaptador.InsertCommand.Parameters("@codigo").Value = txtCodigo.Text
                adaptador.InsertCommand.Parameters("@descripcion").Value = txtDescripcion.Text
                adaptador.InsertCommand.Parameters("@medida").Value = txtMedida.Text
                adaptador.InsertCommand.Parameters("@activo").Value = chkActivo.CheckState

                conexion.Open()
                Dim i As Integer = adaptador.InsertCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registros añadidos", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "MATERIAL")
                dgvMaterial.Refresh()

                bmb.Position = datos.Tables("MATERIAL").Rows.Count
                chkActivo.Checked = False
                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        If txtCodigo.Text = "" Or txtDescripcion.Text = "" Or txtMedida.Text = "" Then
            MessageBox.Show("Llene todos los campos ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                adaptador.UpdateCommand.Parameters("@codigo").Value = txtCodigo.Text
                adaptador.UpdateCommand.Parameters("@descripcion").Value = txtDescripcion.Text
                adaptador.UpdateCommand.Parameters("@medida").Value = txtMedida.Text
                adaptador.UpdateCommand.Parameters("@activo").Value = chkActivo.CheckState
                adaptador.UpdateCommand.Parameters("@id").Value = dgvMaterial.CurrentRow.Cells("id").Value

                conexion.Open()
                Dim i As Integer = adaptador.UpdateCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registro actualizado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "MATERIAL")
                dgvMaterial.Refresh()

                bmb.Position = datos.Tables("MATERIAL").Rows.Count
                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If MessageBox.Show("Esta seguro de eliminar este registro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                adaptador.DeleteCommand.Parameters("@id").Value = dgvMaterial.CurrentRow.Cells("id").Value

                conexion.Open()
                Dim i As Integer = adaptador.DeleteCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registro eliminado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "MATERIAL")
                dgvMaterial.Refresh()

                bmb.Position = datos.Tables("MATERIAL").Rows.Count
                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub btnExportarExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportarExcel.Click
        Dim exportarExcel As New ExportarExcel()
        exportarExcel.ExportarExcel(dgvMaterial)
    End Sub
End Class
