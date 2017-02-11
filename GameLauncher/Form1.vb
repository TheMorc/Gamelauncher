Imports System.IO
Imports System.Net

Public Class Form1
    Dim verzia As String = 0.5
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.nonanimode = True Then

            settings.CheckBox1.Checked = True
        Else
            settings.CheckBox1.Checked = False
        End If
        Dim address As String = "https://github.com/TheMorc/Gamelauncher/blob/master/GameLauncher/version.txt"
        Dim client As WebClient = New WebClient()
        Dim reader As StreamReader = New StreamReader(client.OpenRead(address))
        If reader.ReadToEnd IsNot verzia Then
            dialog.Label1.Text = "Uh oh! There's a new version availible"
            dialog.ShowDialog()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        settings.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = My.Settings.nonanimode.ToString + vbNewLine + Width.ToString + "x" + Height.ToString + vbNewLine + verzia
    End Sub
End Class
