Imports System.Data
Imports System.Data.OleDb

Public Class FrmContratoVenta
    Dim conexion As OleDbConnection
    Friend adaptador, adaptador2 As OleDbDataAdapter
    Dim construct As OleDbCommandBuilder
    Dim comando As OleDbCommand
    Friend datos As DataSet
    Friend datos2 As DataSet
    Dim bmb As BindingManagerBase

    Private Sub FrmContratoVenta_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter("SELECT CO.id, cliente, contacto, telefono, celular, fecha, fechaLim, contrato, notas, subtotal, IVA, totalPagar, totalAbono, saldo, CO.activo FROM CLIENTE AS CL, CONTRATO AS CO WHERE CL.id=CO.idCliente", conexion)
        adaptador2 = New OleDbDataAdapter("SELECT contrato, descripcion, precio, cantidad, V.subtotal, idMaterial, idContrato, V.id FROM MATERIAL AS M, VENTA AS V, CONTRATO AS C WHERE C.id = V.idContrato AND M.id = V.idMaterial", conexion)
        construct = New OleDbCommandBuilder(adaptador)
        datos = New DataSet()

        Dim actualizar As New OleDbCommand("UPDATE CONTRATO SET fecha=@fecha, fechaLim=@fechaLim, contrato=@contrato, notas=@notas, activo=@activo WHERE id=@id", conexion)
        adaptador.UpdateCommand = actualizar
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@fecha", OleDbType.Date))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@fechaLim", OleDbType.Date))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@contrato", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@notas", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@activo", OleDbType.Boolean))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@id", OleDbType.VarChar))

        Dim eliminar As New OleDbCommand("DELETE * FROM CONTRATO WHERE id=@id", conexion)
        adaptador.DeleteCommand = eliminar
        adaptador.DeleteCommand.Parameters.Add(New OleDbParameter("@id", OleDbType.VarChar))

        conexion.Open()
        adaptador.Fill(datos, "CONTRATO")
        adaptador2.Fill(datos, "VENTA")
        conexion.Close()

        datos.Relations.Add("PK", datos.Tables("CONTRATO").Columns("id"), datos.Tables("VENTA").Columns("idContrato"))
        dgvContrato.DataSource = datos
        dgvContrato.DataMember = "CONTRATO"
        dgvContrato.Columns("id").Visible = False

        dgvVenta.DataSource = datos
        dgvVenta.DataMember = "CONTRATO.PK"
        dgvVenta.Columns("idMaterial").Visible = False
        dgvVenta.Columns("idContrato").Visible = False
        dgvVenta.Columns("id").Visible = False

        bmb = BindingContext(datos.Tables("CONTRATO"))
    End Sub

    Private Sub btnAbonar_Click(sender As Object, e As EventArgs) Handles btnAbonar.Click
        If dgvContrato.Rows.Count = 0 Then
            MessageBox.Show("No existe ningun contrato registrado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            FrmAbono.Show()
            FrmAbono.cboContrato.Text = dgvContrato.CurrentRow.Cells("id").Value.ToString()
            FrmAbono.txtNotas.Text = "NINGUNA"
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If dgvContrato.Rows.Count < 1 Then
            MessageBox.Show("NO hay registro para actualizar", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            adaptador.UpdateCommand.Parameters("@fecha").Value = dgvContrato.CurrentRow.Cells("fecha").Value
            adaptador.UpdateCommand.Parameters("@fechaLim").Value = dgvContrato.CurrentRow.Cells("fechaLim").Value
            adaptador.UpdateCommand.Parameters("@contrato").Value = dgvContrato.CurrentRow.Cells("contrato").Value

            adaptador.UpdateCommand.Parameters("@notas").Value = dgvContrato.CurrentRow.Cells("notas").Value
            adaptador.UpdateCommand.Parameters("@activo").Value = dgvContrato.CurrentRow.Cells("activo").Value
            adaptador.UpdateCommand.Parameters("@id").Value = dgvContrato.CurrentRow.Cells("id").Value

            conexion.Open()
            Dim i As Integer = adaptador.UpdateCommand.ExecuteNonQuery()
            conexion.Close()

            MessageBox.Show(i & " Registro actualizado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

            datos.Clear()
            adaptador.Fill(datos, "CONTRATO")
            adaptador2.Fill(datos, "VENTA")
            dgvContrato.Refresh()
            dgvVenta.Refresh()

        End If
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If dgvContrato.Rows.Count < 1 Then
            MessageBox.Show("NO hay registro para eliminar", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If MessageBox.Show("Esta seguro de eliminar este registro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Try
                    adaptador.DeleteCommand.Parameters("@id").Value = dgvContrato.CurrentRow.Cells("id").Value

                    conexion.Open()
                    Dim i As Integer = adaptador.DeleteCommand.ExecuteNonQuery()
                    conexion.Close()

                    MessageBox.Show(i & " Registro eliminado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    datos.Clear()
                    adaptador.Fill(datos, "CONTRATO")
                    adaptador2.Fill(datos, "VENTA")
                    dgvContrato.Refresh()
                    dgvVenta.Refresh()

                Catch ex As OleDbException
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            End If
        End If

    End Sub

    Private Sub btnExportarExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportarExcel.Click
        Dim exportarExcel As New ExportarExcel()
        exportarExcel.ExportarExcel(dgvContrato)
    End Sub
End Class