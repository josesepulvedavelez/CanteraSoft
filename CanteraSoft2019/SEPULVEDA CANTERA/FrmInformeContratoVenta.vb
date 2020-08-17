Imports System.Data
Imports System.Data.OleDb

Public Class FrmInformeContratoVenta
    Dim conexion As OleDbConnection
    Friend adaptador As OleDbDataAdapter
    Dim comando As OleDbCommand
    Friend datos As DataSet
    Dim bmb As BindingManagerBase

    Private Sub FrmInformeContratoVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter("SELECT CO.id, cliente, contacto, telefono, celular, fecha, fechaLim, contrato, subtotal, IVA, totalPagar, totalAbono, saldo FROM CLIENTE AS CL, CONTRATO AS CO WHERE CL.id=CO.idCliente ORDER BY cliente, contrato", conexion)
        datos = New DataSet()

        conexion.Open()
        adaptador.Fill(datos, "CONTRATO")
        conexion.Close()

        dgvContrato.DataSource = datos.Tables("CONTRATO")
        dgvContrato.Columns("id").Visible = False

        bmb = BindingContext(datos.Tables("CONTRATO"))
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

    Private Sub btnUlt_Click(sender As Object, e As EventArgs) Handles btnUlt.Click
        bmb.Position += 1
        Call registro()
    End Sub

    Private Sub btnSigg_Click(sender As Object, e As EventArgs) Handles btnSigg.Click
        bmb.Position = datos.Tables("CONTRATO").Rows.Count
        Call registro()
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim exportarExcel As New ExportarExcel()
        exportarExcel.ExportarExcel(dgvContrato)
    End Sub

End Class