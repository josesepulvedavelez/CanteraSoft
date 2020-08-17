Imports System.Data
Imports System.Data.OleDb

Public Class FrmVehiculoCargarPlaca

    Dim conexion As OleDbConnection
    Dim adaptador As OleDbDataAdapter
    Dim datos As DataSet

    Private Sub FrmVehiculoCargarPlaca_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
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

                dgvVehiculo.DataSource = datos
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        If dgvVehiculo.Rows.Count <= 0 Then
            MessageBox.Show("Llene todos los campos ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                conexion = New OleDbConnection(ConexionDatos.conectar())
                conexion.Open()

                Dim insertar = New OleDbCommand("INSERT INTO VEHICULO(placa, mt3, activo, idCliente) VALUES(@placa, @mt3, @activo, @idCliente)", conexion)

                For Each row As DataGridViewRow In dgvVehiculo.Rows
                    insertar.Parameters.Clear()
                    insertar.Parameters.AddWithValue("@placa", Convert.ToString(row.Cells("placa").Value))
                    insertar.Parameters.AddWithValue("@mt3", Convert.ToDouble(row.Cells("mt3").Value))
                    insertar.Parameters.AddWithValue("@activo", Convert.ToDouble(row.Cells("activo").Value))
                    insertar.Parameters.AddWithValue("@idCliente", Convert.ToInt64(cboCliente.SelectedValue))
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