Imports System.Data
Imports System.Data.OleDb

Public Class ConexionDatos

    Private Shared cnn As String

    Shared Function conectar() As String
        cnn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=base.accdb; Jet OLEDB:Database Password=chmod-rwx"
        Return cnn
    End Function

End Class
