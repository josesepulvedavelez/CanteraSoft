Imports System.Data
Imports System.Data.OleDb

Public Class FrmValeraDescargaClienteInforme
    Private conexion As OleDbConnection
    Private adaptador As OleDbDataAdapter
    Private datos As DataSet
    Private bmb As BindingManagerBase

    Private Sub FrmValeraDescargaClienteInforme_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter("SELECT Cliente.Cliente, VALERA.Fecha AS FechaCarga, CodigoBarras, VALERA_DESCARGA.Fecha AS FechaDescarga, Placa, Mt3, Orden, ValorVale, Material, Lugar, Efectivo, Observaciones FROM (CLIENTE INNER JOIN VALERA ON Cliente.id = VALERA.IdCliente) INNER JOIN VALERA_DESCARGA ON VALERA.Id = VALERA_DESCARGA.IdValera", conexion)
        datos = New DataSet()

        conexion.Open()
        adaptador.Fill(datos, "VALERADESCARGACLIENTEINFORME")
        conexion.Close()

        Busqueda.busqueda(txtBuscar, "SELECT Cliente FROM CLIENTE")

        dgvValeraDescargaInforme.DataSource = datos.Tables("VALERADESCARGACLIENTEINFORME")

        bmb = BindingContext(datos.Tables("VALERADESCARGACLIENTEINFORME"))
    End Sub

    Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        If dtpFechaInicio.Text > dtpFechaFinal.Text Then
            MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            adaptador = New OleDbDataAdapter("SELECT Cliente.Cliente, VALERA.Fecha AS FechaCarga, CodigoBarras, VALERA_DESCARGA.Fecha AS FechaDescarga, Placa, Mt3, Orden, ValorVale, Material, Lugar, Efectivo, Observaciones FROM (CLIENTE INNER JOIN VALERA ON Cliente.id = VALERA.IdCliente) INNER JOIN VALERA_DESCARGA ON VALERA.Id = VALERA_DESCARGA.IdValera WHERE VALERA_DESCARGA.Fecha BETWEEN @FechaInicio AND @FechaFinal AND CLIENTE.Cliente LIKE '%" + txtBuscar.Text + "%' ", conexion)
            adaptador.SelectCommand.Parameters.AddWithValue("@FechaInicio", dtpFechaInicio.Text)
            adaptador.SelectCommand.Parameters.AddWithValue("@FechaFinal", dtpFechaFinal.Text)

            datos = New DataSet()

            conexion.Open()
            adaptador.Fill(datos, "VALERADESCARGACLIENTEINFORMEFECHA")
            conexion.Close()

            dgvValeraDescargaInforme.DataSource = datos.Tables("VALERADESCARGACLIENTEINFORMEFECHA")
        End If
    End Sub

    Private Sub btnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarExcel.Click
        Dim exportarExcel As New ExportarExcel()
        exportarExcel.ExportarExcel(dgvValeraDescargaInforme)
    End Sub
End Class