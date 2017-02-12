Public Class dialog
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Public Sub ukaz(v As String, bitmapa As Bitmap, title As String, secondbtn As Boolean)
        PictureBox1.Image = bitmapa
        Button2.Visible = secondbtn
        Label1.Text = v
        Me.Text = title
        Me.ShowDialog()
    End Sub
End Class