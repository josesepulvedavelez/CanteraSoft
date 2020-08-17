Imports System.Data
Imports System.Data.OleDb

Public Class FrmInformeMt3Cargados
    Dim conexion As OleDbConnection
    Dim adaptador As OleDbDataAdapter
    Dim construct As OleDbCommandBuilder
    Dim datos As DataSet
    Dim bmb As BindingManagerBase

    Private Sub FrmInformeMt3Cargados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT cliente, contrato, descripcion as material, cantidad, SUM(mt3Dig) AS mt3_Dig, (cantidad - mt3_Dig) AS mt3_pendiente FROM REMISION, CLIENTE, CONTRATO, MATERIAL, VENTA WHERE CLIENTE.id = REMISION.idCliente AND CONTRATO.id = REMISION.idContrato AND MATERIAL.id = REMISION.idMaterial AND MATERIAL.id = VENTA.idMaterial AND CONTRATO.id = VENTA.idContrato GROUP BY cliente, contrato, descripcion, cantidad ORDER BY cliente, contrato;"
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter(sql, conexion)
        datos = New DataSet()

        conexion.Open()
        adaptador.Fill(datos, "INFORMEMT3CARGADOS")
        conexion.Close()

        dgvInformemt3Cargados.DataSource = datos.Tables("INFORMEMT3CARGADOS")

        bmb = BindingContext(datos.Tables("INFORMEMT3CARGADOS"))
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
        bmb.Position = datos.Tables("INFORMEMT3CARGADOS").Rows.Count
        Call registro()
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim exportarExcel As New ExportarExcel()
        exportarExcel.ExportarExcel(dgvInformemt3Cargados)
    End Sub

    Private Sub dgvInformemt3Cargados_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvInformemt3Cargados.CellValidating
        If dgvInformemt3Cargados.Columns("mt3_pendiente").Name = "mt3_pendiente" Then
            If CDbl(dgvInformemt3Cargados.CurrentRow.Cells(5).Value.ToString()) <= 50 Then
                dgvInformemt3Cargados.Rows(e.RowIndex).ErrorText = "valor!"
            End If
        End If
    End Sub

    Private Sub dgvInformemt3Cargados_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInformemt3Cargados.CellValidated

    End Sub

End Class