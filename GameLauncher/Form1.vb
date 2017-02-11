Imports System.IO
Imports System.Net

Public Class Form1
    Dim newest As Boolean
    Dim verzia As String = 0.5
    Dim newestver As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.nonanimode = True Then

            settings.CheckBox1.Checked = True
        Else
            settings.CheckBox1.Checked = False
        End If
        Dim address As String = "https://raw.githubusercontent.com/TheMorc/Gamelauncher/master/GameLauncher/version.txt"
        Dim client As WebClient = New WebClient()
        Dim reader As StreamReader = New StreamReader(client.OpenRead(address))
        newestver = reader.ReadToEnd
        If newestver = verzia Then
            newest = True
        Else
            newest = False
            dialog.Label1.Text = "Uh oh! There's a new version available " + newestver
            dialog.ShowDialog()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        settings.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = My.Settings.nonanimode.ToString + vbNewLine + Width.ToString + "x" + Height.ToString + vbNewLine + verzia + vbNewLine + newest.ToString + " " + newestver
    End Sub
End Class
