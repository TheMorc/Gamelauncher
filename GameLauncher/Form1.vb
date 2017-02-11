Public Class Form1
    Dim verzia As String = 0.5
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.nonanimode = True Then

            settings.CheckBox1.Checked = True
        Else
            settings.CheckBox1.Checked = False
        End If

        dialog.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        settings.show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = My.Settings.nonanimode.ToString + vbNewLine + Width.ToString + "x" + Height.ToString + vbNewLine + verzia
    End Sub
End Class
