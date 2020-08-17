Imports System.Data
Imports System.Data.OleDb

Public Class FrmInformeDiario
    Dim conexion As OleDbConnection
    Dim adaptador As OleDbDataAdapter
    Dim construct As OleDbCommandBuilder
    Dim datos As DataSet
    Dim bmb As BindingManagerBase

    Private Sub FrmInformeDiario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboAño.Text = DateTime.Now.Year
        cboMes.Text = DateTime.Now.Month

        Call cargarCombox(cboAño, cboMes)
        Call cargarDatos()
        Call registro()
    End Sub

    Private Sub cargarCombox(cboAño As ComboBox, cboMes As ComboBox)
        For i As Integer = 2010 To DateTime.Now.Year Step 1
            cboAño.Items.Add(i)
        Next

        For i As Integer = 1 To 12 Step 1
            cboMes.Items.Add(i)
        Next
    End Sub

    Private Sub cargarDatos()
        Dim sql As String = "TRANSFORM SUM(mt3Dig) Select cliente, contrato, descripcion as material From CLIENTE As CL, REMISION As RE, MATERIAL As MA, CONTRATO AS CO Where CL.id = RE.idCliente And MA.id = RE.idMaterial AND CO.id = RE.idContrato And Year(re.fecha) = '" + cboAño.Text + "' AND MONTH(RE.fecha)='" + cboMes.Text + "' AND RE.activo = true Group By CLIENTE, contrato, descripcion ORDER BY cliente, contrato, descripcion PIVOT  Day(RE.FECHA)"
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter(sql, conexion)
        datos = New DataSet()

        conexion.Open()
        adaptador.Fill(datos, "DIARIO")
        conexion.Close()

        dgvDiario.DataSource = datos.Tables("DIARIO")

        bmb = BindingContext(datos.Tables("DIARIO"))
        Call registro()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        cargarDatos()
    End Sub

    Private Sub registro()
        Try
            txtRegistro.Text = "Registro " & (bmb.Position + 1) & " de " & datos.Tables(0).Rows.Count
        Catch ex As NullReferenceException
            MessageBox.Show("NO hay remisiones digitadas en el año '" + cboAño.Text + "' del mes '" + cboMes.Text + "' ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub btnPri_Click(sender As Object, e As EventArgs) Handles btnPri.Click
        bmb.Position = 0
        Call registro()
    End Sub

    Private Sub btnAnt_Click(sender As Object, e As EventArgs) Handles btnAnt.Click
        bmb.Position -= 1
        Call registro()
    End Sub

    Private Sub btnSig_Click(sender As Object, e As EventArgs) Handles btnSig.Click
        bmb.Position += 1
        Call registro()
    End Sub

    Private Sub btnUlt_Click(sender As Object, e As EventArgs) Handles btnUlt.Click
        bmb.Position = datos.Tables("DIARIO").Rows.Count
        Call registro()
    End Sub

    Private Sub btnExportarExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportarExcel.Click
        Dim exportarExcel As New ExportarExcel()
        exportarExcel.ExportarExcel(dgvDiario)
    End Sub
End Class