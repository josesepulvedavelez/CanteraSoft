Imports System.Data
Imports System.Data.OleDb

Public Class FrmValeraDescargaInformePrincipal
    Private conexion As OleDbConnection
    Private adaptador As OleDbDataAdapter
    Private datos As DataSet
    Private bmb As BindingManagerBase

    Private Sub FrmValeraDescargaInformePrincipal_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter("SELECT YEAR(VALERA.Fecha) AS Año, MONTH(VALERA.Fecha) AS Mes, Cliente.Cliente, COUNT(VALERA.Id) AS CantVales, AVG(ValorVale) AS ValorVales, SUM(ValorVale) AS TotalVales, SUM(Efectivo) AS TotalEfectivo, COUNT(IdValera) as Viajes, (Viajes * AVG(ValorVale)) AS Descargas, COUNT(VALERA.Id) - COUNT(IdValera) as ViajesPendientes, SUM(ValorVale) - (Viajes * AVG(ValorVale)) as Pendinte FROM (CLIENTE INNER JOIN VALERA ON CLIENTE.Id = VALERA.IdCliente) LEFT JOIN VALERA_DESCARGA ON VALERA.Id = VALERA_DESCARGA.IdValera GROUP BY YEAR(VALERA.Fecha), MONTH(VALERA.Fecha), Cliente", conexion)
        datos = New DataSet()

        conexion.Open()
        adaptador.Fill(datos, "ValeraDescargaInformePrincipal")
        conexion.Close()

        dgvValeraDescargaInforme.DataSource = datos.Tables("ValeraDescargaInformePrincipal")

        bmb = BindingContext(datos.Tables("ValeraDescargaInformePrincipal"))
    End Sub

    Private Sub btnExportarExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportarExcel.Click
        Dim exportarExcel As New ExportarExcel()
        exportarExcel.ExportarExcel(dgvValeraDescargaInforme)
    End Sub
End Class