Imports System.Data
Imports System.Data.OleDb

Public Class FrmRemisionFiltro
    Dim conexion As OleDbConnection
    Dim adaptador As OleDbDataAdapter
    Dim datos As DataSet
    Dim bmb As BindingManagerBase

    Dim sql As String = "SELECT numero, RE.fecha, cliente, contrato, marca, RE.serie, descripcion AS material, formaPago, nombres AS operador, conductor, RE.placa, horaDespacho, mt3Dig, mt3Cap, morro, RE.activo, RE.id FROM CLIENTE AS CL, REMISION AS RE, CONTRATO AS CR, MAQUINA AS MA, MATERIAL AS MT, EMPLEADO AS EM WHERE CL.id=RE.idCliente AND CR.id=RE.idContrato AND MA.id=RE.idMaquina AND MT.id=RE.idMaterial AND EM.id=RE.idEMpleado ORDER BY RE.id;"

    Private Sub FrmRemisionFiltro_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter(sql, conexion)
        datos = New DataSet()

        conexion.Open()
        adaptador.Fill(datos, "REMISION")
        conexion.Close()

        dgvRemision.DataSource = datos.Tables("REMISION")
        dgvRemision.Columns("id").Visible = False

        bmb = BindingContext(datos.Tables("REMISION"))

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

    Private Sub btnSig_Click(sender As System.Object, e As System.EventArgs) Handles btnSig.Click
        bmb.Position += 1
        Call registro()
    End Sub

    Private Sub btnUlt_Click(sender As System.Object, e As System.EventArgs) Handles btnUlt.Click
        bmb.Position = datos.Tables("REMISION").Rows.Count
        Call registro()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Dim sql2 As String = "SELECT numero, RE.fecha, cliente, contrato, marca, RE.serie, descripcion as material, formaPago, nombres as operador, conductor, RE.placa, horaDespacho, mt3Dig, mt3Cap, morro, RE.activo, RE.id FROM CLIENTE AS CL, REMISION AS RE, CONTRATO AS CR, MAQUINA AS MA, MATERIAL AS MT, EMPLEADO AS EM WHERE CL.id=RE.idCliente AND CR.id=RE.idContrato AND MA.id=RE.idMaquina AND MT.id=RE.idMaterial AND EM.id=RE.idEMpleado AND RE.fecha BETWEEN @fechaDesde AND @hasta ORDER BY RE.fecha"
        Dim comando = New OleDbCommand(sql2, conexion)
        comando.Parameters.AddWithValue("@desde", CDate(dtpDesde.Text))
        comando.Parameters.AddWithValue("@hasta", CDate(dtpHasta.Text))

        adaptador = New OleDbDataAdapter(comando)
        datos = New DataSet()

        conexion.Open()
        adaptador.Fill(datos, "REMISIONFILTRO")
        conexion.Close()

        dgvRemision.DataSource = datos.Tables("REMISIONFILTRO")
        dgvRemision.Columns("id").Visible = False

        'bmb = BindingContext(datos.Tables("REMISIONFILTO"))

        btnPri.Enabled = False
        btnAnt.Enabled = False
        btnSig.Enabled = False
        btnUlt.Enabled = False
        Call registro()
    End Sub

    Private Sub btnExportarExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportarExcel.Click
        Dim exportarExcel As New ExportarExcel()
        exportarExcel.ExportarExcel(dgvRemision)
    End Sub
End Class