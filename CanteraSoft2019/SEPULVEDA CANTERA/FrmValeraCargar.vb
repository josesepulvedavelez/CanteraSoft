Imports System.Data
Imports System.Data.OleDb

Public Class FrmValeraCargar

    Dim conexion As OleDbConnection
    Dim adaptador As OleDbDataAdapter
    Dim datos As DataSet

    Private Sub FrmValeraCargar_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter("SELECT id, cliente FROM CLIENTE", conexion)
        datos = New DataSet()

        conexion.Open()
        adaptador.Fill(datos, "CLIENTE")
        conexion.Close()

        cboCliente.DataSource = datos.Tables("CLIENTE")
        cboCliente.DisplayMember = "cliente"
        cboCliente.ValueMember = "id"
    End Sub

   
    Private Sub btnExaminar_Click(sender As System.Object, e As System.EventArgs) Handles btnExaminar.Click
        Dim open As New OpenFileDialog()
        open.Filter = "Archivo Excel | *.XLSX"

        If open.ShowDialog() = DialogResult.OK Then
            txtExaminar.Text = open.FileName

            Try
                Dim cadena As String = "Provider=Microsoft.ACE.OLEDB.12.0; data source= " & txtExaminar.Text & "; Extended properties=""Excel 12.0 Xml;hdr=yes;"""
                Dim conexion As New OleDb.OleDbConnection(cadena)
                Dim adaptador As New OleDb.OleDbDataAdapter("SELECT * FROM [Hoja1$]", conexion)

                Dim datos As New DataTable()

                conexion.Open()
                adaptador.Fill(datos)
                conexion.Close()

                dgvValera.DataSource = datos
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnInsertar_Click(sender As System.Object, e As System.EventArgs) Handles btnInsertar.Click
        If dgvValera.Rows.Count <= 0 Then
            MessageBox.Show("Llene todos los campos ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                conexion = New OleDbConnection(ConexionDatos.conectar())
                conexion.Open()

                '

                Dim insertar = New OleDbCommand("INSERT INTO VALERA(CodigoBarras, Fecha, Orden, IdCliente, ValorVale) VALUES(@CodigoBarras, @Fecha, @Orden, @IdCliente, @ValorVale)", conexion)

                For Each row As DataGridViewRow In dgvValera.Rows
                    insertar.Parameters.Clear()
                    insertar.Parameters.AddWithValue("@CodigoBarras", Convert.ToString(row.Cells("CodigoBarras").Value))
                    insertar.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(row.Cells("Fecha").Value))
                    insertar.Parameters.AddWithValue("@Orden", Convert.ToString(row.Cells("Orden").Value))
                    insertar.Parameters.AddWithValue("@idCliente", Convert.ToInt64(cboCliente.SelectedValue))
                    insertar.Parameters.AddWithValue("@ValorVale", Convert.ToInt64(row.Cells("ValorVale").Value))
                    insertar.ExecuteNonQuery()
                Next

                MessageBox.Show(" Registros añadidos", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

                conexion.Close()
                Me.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub
End Class