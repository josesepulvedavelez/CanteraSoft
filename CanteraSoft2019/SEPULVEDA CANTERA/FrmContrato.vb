Imports System.Data
Imports System.Data.OleDb

Public Class FrmContrato
    Dim conexion As OleDbConnection
    Dim adaptador As OleDbDataAdapter
    Dim tabla As DataTable

    Dim sql As String = "SELECT cliente, id FROM CLIENTE WHERE activo = true"

    Private Sub FrmContrato_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter(Sql, conexion)
        tabla = New DataTable()

        conexion.Open()
        adaptador.Fill(tabla)
        conexion.Close()

        cboCliente.DataSource = tabla
        cboCliente.DisplayMember = "cliente"
        cboCliente.ValueMember = "id"
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        Dim frmContratoBuscar As New FrmContratoBuscar()
        frmContratoBuscar.Show()
    End Sub

    Private Sub chkPrecio_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkPrecio.CheckedChanged
        If chkPrecio.Checked = True Then
            Dim subTotal As Double = 0
            Dim totalPagar As Double
            Dim IVA As Double = Convert.ToDouble(cboIVA.Text)

            For Each row As DataGridViewRow In dgvContrato.Rows
                subTotal = subTotal + row.Cells("subtotal").Value
            Next

            txtSubtotal.Text = subTotal.ToString()
            totalPagar = subTotal + (subTotal * (IVA / 100))

            txtTotalPagar.Text = totalPagar.ToString()
        Else
            txtSubtotal.Clear()
            txtTotalPagar.Clear()
        End If
    End Sub

    Private Sub cboCliente_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCliente.SelectedIndexChanged
        txtContrato.Text = cboCliente.Text
    End Sub

    Private Sub btnInsertar_Click(sender As System.Object, e As System.EventArgs) Handles btnInsertar.Click
        If txtSubtotal.Text = "" Or txtTotalPagar.Text = "" Or txtSubtotal.Text = "0" Or txtTotalPagar.Text = "0" Then
            MessageBox.Show("Datos imcompletos", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Try
                conexion = New OleDbConnection(ConexionDatos.conectar)
                conexion.Open()

                Dim transaccion As OleDbTransaction
                Dim comando As OleDbCommand

                transaccion = conexion.BeginTransaction()

                comando = New OleDbCommand("INSERT INTO CONTRATO(idCliente, fecha, fechaLim, contrato, notas, subtotal, IVA, totalPagar, activo) VALUES(@idCliente, @fecha, @fechaLim, @contrato, @notas, @subtotal, @IVA, @totalPagar, @activo)", conexion)
                comando.Parameters.AddWithValue("@idCliente", cboCliente.SelectedValue)
                comando.Parameters.AddWithValue("@fecha", dtpFecha.Text)
                comando.Parameters.AddWithValue("@fechaLim", dtpFechaLim.Text)
                comando.Parameters.AddWithValue("@contrato", txtContrato.Text)
                comando.Parameters.AddWithValue("@notas", txtNotas.Text)
                comando.Parameters.AddWithValue("@subtotal", txtSubtotal.Text)
                comando.Parameters.AddWithValue("@IVA", cboIVA.Text)
                comando.Parameters.AddWithValue("@totalPagar", txtTotalPagar.Text)
                comando.Parameters.AddWithValue("@activo", chkActivo.CheckState)

                comando.Transaction = transaccion
                comando.ExecuteNonQuery()

                comando = New OleDbCommand("SELECT MAX(id) FROM CONTRATO", conexion)
                comando.Transaction = transaccion
                Dim idContrato As Integer = comando.ExecuteScalar()

                comando = New OleDbCommand("INSERT INTO VENTA(precio, cantidad, subtotal, idMaterial, idContrato) VALUES(@precio, @cantidad, @subtotal, @idMaterial, @idContrato)", conexion)
                comando.Transaction = transaccion

                For Each row As DataGridViewRow In dgvContrato.Rows
                    comando.Parameters.Clear()

                    comando.Parameters.AddWithValue("@precio", row.Cells("precio").Value)
                    comando.Parameters.AddWithValue("@cantidad", row.Cells("cantidad").Value)
                    comando.Parameters.AddWithValue("@subtotal", row.Cells("subtotal").Value)
                    comando.Parameters.AddWithValue("@idMaterial", row.Cells("idMaterial").Value)
                    comando.Parameters.AddWithValue("@idContrato", idContrato.ToString())
                    comando.ExecuteNonQuery()
                Next

                transaccion.Commit()
                MessageBox.Show("Datos insertados", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtSubtotal.Text = "0"
                txtTotalPagar.Text = "0"
                txtNotas.Clear()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try

            conexion.Close()

            For i As Integer = dgvContrato.Rows.Count - 1 To 0 Step -1
                dgvContrato.Rows.RemoveAt(i)
            Next

        End If
    End Sub
End Class