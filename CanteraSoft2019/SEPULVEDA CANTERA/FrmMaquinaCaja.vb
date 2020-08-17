Imports System.Data
Imports System.Data.OleDb

Public Class FrmCaja
    Dim conexion As OleDbConnection
    Dim adaptador As OleDbDataAdapter
    Dim construct As OleDbCommandBuilder
    Dim datos As DataSet
    Dim bmb As BindingManagerBase

    Dim sql As String = "SELECT concepto, valor, idHorometro, id FROM CAJA"

    Private Sub FrmCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter(sql, conexion)
        construct = New OleDbCommandBuilder(adaptador)

        datos = New DataSet()

        Dim insertar As New OleDbCommand("INSERT INTO CAJA(concepto, valor, idHorometro) VALUES(@concepto, @valor, @idHorometro)", conexion)
        adaptador.InsertCommand = insertar
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@concepto", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@valor", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@idHorometro", OleDbType.VarChar))

        Dim actualizar As New OleDbCommand("UPDATE CAJA SET concepto=@concepto, valor=@valor, idHorometro=@idHorometro WHERE id=@id", conexion)
        adaptador.UpdateCommand = actualizar
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@concepto", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@valor", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@idHorometro", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@id", OleDbType.VarChar))

        Dim eliminar As New OleDbCommand("DELETE * FROM CAJA WHERE id=@id", conexion)
        adaptador.DeleteCommand = eliminar
        adaptador.DeleteCommand.Parameters.Add(New OleDbParameter("@id", OleDbType.VarChar))

        conexion.Open()
        adaptador.Fill(datos, "CAJA")
        conexion.Close()

        txtConcepto.DataBindings.Add(New Binding("Text", datos.Tables("CAJA"), "concepto"))
        txtValor.DataBindings.Add(New Binding("Text", datos.Tables("CAJA"), "valor"))

        dgvCaja.DataSource = datos.Tables("CAJA")
        dgvCaja.Columns("idHorometro").Visible = False
        dgvCaja.Columns("id").Visible = False

        bmb = BindingContext(datos.Tables("CAJA"))
        Call registro()
    End Sub

    Private Sub registro()
        txtRegistro.Text = "Registro " & (bmb.Position + 1) & " de " & datos.Tables(0).Rows.Count
    End Sub

    Private Sub btnPri_Click(sender As Object, e As EventArgs) Handles btnPri.Click
        bmb.Position = 0
        Call registro()
    End Sub

    Private Sub btnAnt_Click(sender As Object, e As EventArgs) Handles btnAnt.Click
        bmb.Position -= 1
        Call registro()
    End Sub

    Private Sub btnSigg_Click(sender As Object, e As EventArgs) Handles btnSigg.Click
        bmb.Position += 1
        Call registro()
    End Sub

    Private Sub btnUlt_Click(sender As Object, e As EventArgs) Handles btnUlt.Click
        bmb.Position = datos.Tables("CAJA").Rows.Count
        Call registro()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtConcepto.Clear()
        txtValor.Text = "0"

        btnInsertar.Enabled = True
        btnNuevo.Enabled = False

        txtConcepto.Focus()
    End Sub

    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        If txtConcepto.Text = "" Or txtValor.Text = "" Then
            MessageBox.Show("Llene todos los campos ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                adaptador.InsertCommand.Parameters("@concepto").Value = txtConcepto.Text
                adaptador.InsertCommand.Parameters("@valor").Value = txtValor.Text
                adaptador.InsertCommand.Parameters("@idHorometro").Value = txtIdHorometro.Text

                conexion.Open()
                Dim i As Integer = adaptador.InsertCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registros añadidos", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "CAJA")
                dgvCaja.Refresh()

                bmb.Position = datos.Tables("CAJA").Rows.Count
                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If txtConcepto.Text = "" Or txtValor.Text = "" Then
            MessageBox.Show("Llene todos los campos ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                adaptador.UpdateCommand.Parameters("@concepto").Value = txtConcepto.Text
                adaptador.UpdateCommand.Parameters("@valor").Value = txtValor.Text
                adaptador.UpdateCommand.Parameters("@idHorometro").Value = txtIdHorometro.Text
                adaptador.UpdateCommand.Parameters("@id").Value = dgvCaja.CurrentRow.Cells("id").Value

                conexion.Open()
                Dim i As Integer = adaptador.UpdateCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registro actualizado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "CAJA")
                dgvCaja.Refresh()

                bmb.Position = datos.Tables("CAJA").Rows.Count
                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If MessageBox.Show("Esta seguro de eliminar este registro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                adaptador.DeleteCommand.Parameters("@id").Value = dgvCaja.CurrentRow.Cells("id").Value

                conexion.Open()
                Dim i As Integer = adaptador.DeleteCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registro eliminado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "CAJA")
                dgvCaja.Refresh()

                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub
End Class