Imports System.Data
Imports System.Data.OleDb

Public Class FrmAbonos
    Dim conexion As OleDbConnection
    Friend adaptador As OleDbDataAdapter
    Dim comando As OleDbCommand
    Friend datos As DataSet
    Dim bmb As BindingManagerBase

    Private Sub FrmAbonos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter("SELECT cliente, contrato, valor, ABONO.notas, ABONO.fecha FROM (CLIENTE INNER JOIN CONTRATO ON CLIENTE.id = CONTRATO.idCliente) LEFT JOIN ABONO ON CONTRATO.id = ABONO.idContrato ORDER BY cliente, contrato, CONTRATO.fecha", conexion)
        datos = New DataSet()

        conexion.Open()
        adaptador.Fill(datos, "ABONOS")
        conexion.Close()

        dgvAbonos.DataSource = datos.Tables("ABONOS")

        bmb = BindingContext(datos.Tables("ABONOS"))
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
        bmb.Position = datos.Tables("ABONOS").Rows.Count
        Call registro()
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim exportarExcel As New ExportarExcel()
        exportarExcel.ExportarExcel(dgvAbonos)
    End Sub
End Class