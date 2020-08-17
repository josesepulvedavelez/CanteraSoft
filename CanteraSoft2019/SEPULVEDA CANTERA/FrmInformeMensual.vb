Imports System.Data
Imports System.Data.OleDb

Public Class FrmInformeMensual
    Dim conexion As OleDbConnection
    Dim adaptador As OleDbDataAdapter
    Dim construct As OleDbCommandBuilder
    Dim datos As DataSet
    Dim bmb As BindingManagerBase

    Private Sub FrmInformeMensual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboAño.Text = DateTime.Now.Year
        Call cargarCombox(cboAño)
        cargarDatos()
        Call registro()
    End Sub

    Private Sub cargarCombox(cboAño As ComboBox)
        For i As Integer = 2010 To DateTime.Now.Year Step 1
            cboAño.Items.Add(i)
        Next
    End Sub

    Private Sub cargarDatos()
        Dim sql As String = "TRANSFORM SUM(mt3Dig) Select cliente, descripcion as material  From CLIENTE As CL, REMISION As RE, MATERIAL As MA  Where CL.id = RE.idCliente And MA.id = RE.idMaterial And Year(re.fecha) ='" + cboAño.Text + "' AND RE.activo = true Group By CLIENTE, descripcion ORDER BY cliente, descripcion PIVOT  MONTH(RE.fecha)"
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter(sql, conexion)
        datos = New DataSet()

        conexion.Open()
        adaptador.Fill(datos, "MENSUAL")
        conexion.Close()

        dgvDiario.DataSource = datos.Tables("MENSUAL")

        bmb = BindingContext(datos.Tables("MENSUAL"))
        'Call registro()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        cargarDatos()
    End Sub

    Private Sub registro()
        Try
            txtRegistro.Text = "Registro " & (bmb.Position + 1) & " de " & datos.Tables(0).Rows.Count
        Catch ex As NullReferenceException
            MessageBox.Show("NO hay remisiones digitadas en el año '" + cboAño.Text + "' ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
        bmb.Position = datos.Tables("MENSUAL").Rows.Count
        Call registro()
    End Sub

    Private Sub btnExportarExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportarExcel.Click
        Dim exportarExcel As New ExportarExcel()
        exportarExcel.ExportarExcel(dgvDiario)
    End Sub
End Class