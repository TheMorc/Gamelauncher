Imports System.ComponentModel

Public Class colordialog
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        My.Settings.color = "green"
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        My.Settings.color = "yellow"
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        My.Settings.color = "blue"
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        My.Settings.color = "gray"
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        My.Settings.color = "red"
    End Sub

    Private Sub colordialog_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.Save()

    End Sub
End Class