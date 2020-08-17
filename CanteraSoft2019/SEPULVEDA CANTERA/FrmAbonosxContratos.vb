Imports System.Data
Imports System.Data.OleDb

Public Class FrmAbonosxContratos
    Dim conexion As OleDbConnection
    Dim adaptadorCLiente As OleDbDataAdapter
    Dim adaptadorContrato As OleDbDataAdapter
    Dim adaptadorAbono As OleDbDataAdapter
    Dim comando As OleDbCommand
    Friend datos As DataSet
    Dim tblContrato As DataTable
    Dim tblAbono As DataTable
    Dim bmb As BindingManagerBase

    Private Sub FrmAbonosxContratos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call cargarComboCliente()
    End Sub

    Private Sub cargarComboCliente()
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptadorCLiente = New OleDbDataAdapter("SELECT id, cliente FROM CLIENTE", conexion)
        datos = New DataSet()

        conexion.Open()
        adaptadorCLiente.Fill(datos, "CLIENTE")
        conexion.Close()

        cboCliente.DataSource = datos.Tables("CLIENTE")
        cboCliente.DisplayMember = "cliente"
        cboCliente.ValueMember = "id"
    End Sub

    Private Sub cboCliente_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCliente.SelectionChangeCommitted
        Dim sql2 As String = "SELECT id, contrato FROM contrato where idCliente = " + cboCliente.SelectedValue.ToString()
        Dim comando As New OleDbCommand(sql2, conexion)
        tblContrato = New DataTable()

        Dim adaptadorCont = New OleDbDataAdapter(comando)
        adaptadorCont.Fill(tblCOntrato)

        cboContrato.DataSource = tblCOntrato
        cboContrato.DisplayMember = "contrato"
        cboContrato.ValueMember = "id"
    End Sub

    Private Sub cboContrato_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboContrato.SelectionChangeCommitted
        Dim sql3 As String = "SELECT fecha, notas, valor, id FROM ABONO WHERE idContrato = " + cboContrato.SelectedValue.ToString()
        Dim comando As New OleDbCommand(sql3, conexion)
        tblAbono = New DataTable()

        adaptadorAbono = New OleDbDataAdapter(comando)
        adaptadorAbono.Fill(tblAbono)

        dgvAbonos.DataSource = tblAbono
        dgvAbonos.Columns("id").Visible = False

        bmb = BindingContext(tblAbono)
        Call registro()
    End Sub

    Private Sub registro()
        txtRegistro.Text = "Registro " & (bmb.Position + 1) & " de " & tblAbono.Rows.Count
    End Sub


    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim exportarExcel As New ExportarExcel()
        exportarExcel.ExportarExcel(dgvAbonos)
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
        bmb.Position = tblAbono.Rows.Count
        Call registro()
    End Sub
End Class