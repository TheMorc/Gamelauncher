Public Class settings
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            My.Settings.nonanimode = True
            My.Settings.Save()
        Else
            My.Settings.nonanimode = False
            My.Settings.Save()
        End If
    End Sub
End Class