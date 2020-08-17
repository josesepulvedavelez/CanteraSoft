Imports System.Data
Imports System.Data.OleDb

Public Class FrmValeraDescargaClienteResumenInforme
    Private conexion As OleDbConnection
    Private adaptador As OleDbDataAdapter
    Private datos As DataSet
    Private bmb As BindingManagerBase

    Private Sub FrmValeraDescargaClienteResumenInforme_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter("SELECT Cliente, COUNT(Placa) as NoViajes, SUM(ValorVale) as TotalVales, SUM(Efectivo) as TotalEfectivo FROM (CLIENTE INNER JOIN VALERA ON CLIENTE.Id = VALERA.Idcliente ) INNER JOIN VALERA_DESCARGA ON VALERA.Id = VALERA_DESCARGA.IdValera GROUP BY Cliente ", conexion)
        datos = New DataSet()

        conexion.Open()
        adaptador.Fill(datos, "VALERADESCARGARESUMENINFORME")
        conexion.Close()

        dgvValeraDescargaInforme.DataSource = datos.Tables("VALERADESCARGARESUMENINFORME")

        Busqueda.busqueda(txtCliente, "SELECT Cliente FROM CLIENTE")
        bmb = BindingContext(datos.Tables("VALERADESCARGARESUMENINFORME"))
    End Sub

    Private Sub txtCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCliente.TextChanged
        If dtpFechaInicio.Text > dtpFechaFinal.Text Then
            MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            adaptador = New OleDbDataAdapter("SELECT Cliente, COUNT(Placa) as NoViajes, SUM(ValorVale) as TotalVales, SUM(Efectivo) as TotalEfectivo FROM (CLIENTE INNER JOIN VALERA ON CLIENTE.Id = VALERA.Idcliente ) INNER JOIN VALERA_DESCARGA ON VALERA.Id = VALERA_DESCARGA.IdValera WHERE VALERA_DESCARGA.Fecha BETWEEN @FechaInicio AND @FechaFinal AND Cliente.Cliente LIKE '%" + txtCliente.Text + "%' GROUP BY Cliente", conexion)
            adaptador.SelectCommand.Parameters.AddWithValue("@FechaInicio", dtpFechaInicio.Text)
            adaptador.SelectCommand.Parameters.AddWithValue("@FechaFinal", dtpFechaFinal.Text)
            datos = New DataSet()

            conexion.Open()
            adaptador.Fill(datos, "VALERADESCARGACLIENTERESUMENINFORMEFECHABUSCAR")
            conexion.Close()

            dgvValeraDescargaInforme.DataSource = datos.Tables("VALERADESCARGACLIENTERESUMENINFORMEFECHABUSCAR")
        End If
    End Sub

    Private Sub btnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarExcel.Click
        Dim exportarExcel As New ExportarExcel()
        exportarExcel.ExportarExcel(dgvValeraDescargaInforme)
    End Sub
End Class