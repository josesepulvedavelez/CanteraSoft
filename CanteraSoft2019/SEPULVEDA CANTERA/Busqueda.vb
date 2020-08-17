Imports System.Data
Imports System.Data.OleDb

Public Class Busqueda
    Public Shared Function busqueda(ByVal txt As TextBox, ByVal sql As String) As AutoCompleteStringCollection
        Dim coleccion As New AutoCompleteStringCollection

        Using conexion As New OleDbConnection(ConexionDatos.conectar())
            Dim ejecutar As New OleDbCommand(sql, conexion)

            conexion.Open()
            Dim lector As OleDbDataReader = ejecutar.ExecuteReader()

            While lector.Read()
                coleccion.AddRange(New String() {lector(0)})
            End While

            lector.Close()
            conexion.Close()

            With txt
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.CustomSource
                .AutoCompleteCustomSource = coleccion
            End With

            Return coleccion
        End Using
    End Function
End Class
