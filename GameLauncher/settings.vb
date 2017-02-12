Imports System.Xml

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

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            My.Settings.debug = True
            Form1.Label1.Visible = True
            Form1.Timer1.Start()
            Button1.Visible = True
            Button2.Visible = True
            My.Settings.Save()
        Else
            My.Settings.debug = False
            Form1.Timer1.Stop()
            Form1.Label1.Visible = False
            Button1.Visible = False
            Button2.Visible = False
            My.Settings.Save()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        dialog.ukaz("youve requested for a warning", My.Resources.warning, "warning", False)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        dialog.ukaz("youve requested for a error", My.Resources.err, "error", False)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Then
            dialog.ukaz("You need to give game a name!", My.Resources.err, "Error", False)
        Else

            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                Try
                    MkDir("games")
                Catch ex As Exception
                End Try
                Dim counter = My.Computer.FileSystem.GetFiles("games")
                Dim game = CStr(counter.Count) + 1
                Dim writer As New Xml.XmlTextWriter("games/" + game.ToString, System.Text.Encoding.UTF8)
                writer.WriteStartDocument(True)
                writer.Formatting = Formatting.Indented
                writer.Indentation = 2
                writer.WriteStartElement("root")
                writer.WriteStartElement("game")
                writer.WriteStartAttribute("filename")
                writer.WriteString(OpenFileDialog1.FileName)
                writer.WriteEndAttribute()
                writer.WriteStartAttribute("name")
                writer.WriteString(TextBox1.Text)
                writer.WriteEndAttribute()
                writer.WriteStartAttribute("iconfromexe")
                writer.WriteString(CheckBox3.Checked)
                writer.WriteEndAttribute()
                If CheckBox3.Checked = True Then
                    If OpenFileDialog2.ShowDialog = DialogResult.OK Then
                        writer.WriteStartAttribute("iconfilename")
                        writer.WriteString(OpenFileDialog2.FileName)
                        writer.WriteEndAttribute()
                    End If
                End If
                writer.WriteEndElement()
                    writer.WriteEndDocument()
                    writer.Close()
                    dialog.ukaz("Created game. ", My.Resources.info, "Done!", False)
                End If
            End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    End Sub
End Class