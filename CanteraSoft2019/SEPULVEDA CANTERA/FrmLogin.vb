Imports System.Data
Imports System.Data.OleDb

Public Class FrmLogin

    Private Sub FrmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
    End Sub

    Private Function validar(ByVal user As String, ByVal pass As String, ByVal cargo As String) As Boolean
        Dim conexion As New OleDbConnection(ConexionDatos.conectar())
        Dim comando As OleDbCommand

        conexion.Open()
        Dim sql As String = "SELECT COUNT(*) FROM EMPLEADO WHERE usuario='" + user + "' AND contraseña='" + pass + "' AND cargo='" + cargo + "' "

        comando = conexion.CreateCommand()
        comando.CommandText = sql

        Dim i As Integer
        i = comando.ExecuteScalar()
        conexion.Close()

        If i = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim user, pass, cargo As String

        user = txtUser.Text
        pass = txtPass.Text
        cargo = cboCargo.Text

        If validar(user, pass, cargo) = True Then
            FrmMenu.Show()
            FrmMenu.lblUsuario.Text = user
            Me.Hide()
        Else
            MessageBox.Show("Datos errados", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtUser.Clear()
            txtPass.Clear()

            txtUser.Focus()
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        If MessageBox.Show("Esta seguro de salir de la aplicacion", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.ExitThread()
        End If
    End Sub
End Class