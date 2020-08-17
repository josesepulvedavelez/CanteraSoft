Public Class FfrmInicio
    Private Sub FfrmInicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True

        Dim nombre As String
        nombre = "CATERA SOFTWARE"

        Label1.Text = nombre.ToUpper() & " " & DateTime.Now.Year
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Value += 5
        Label4.Text = "Cargando... " & ProgressBar1.Value & "%"

        If ProgressBar1.Value = 100 Then
            Timer1.Enabled = False
            Dim frmLogin As New FrmLogin()
            frmLogin.Show()
        End If
    End Sub
End Class