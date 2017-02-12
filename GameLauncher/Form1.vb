Imports System.IO
Imports System.Net
Imports System.Xml

Public Class Form1
    Dim newest As Boolean
    Dim verzia As String = 0.9
    Dim newestver As String
    Public currentindex = 0
    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            MkDir("games")
        Catch ex As Exception
        End Try
        If My.Settings.nonanimode = True Then

            settings.CheckBox1.Checked = True
        Else
            settings.CheckBox1.Checked = False
        End If
        settings.settingsreload()
        Dim address As String = "https://raw.githubusercontent.com/TheMorc/Gamelauncher/master/GameLauncher/version.txt"
        Dim client As WebClient = New WebClient()
        Dim reader As StreamReader = New StreamReader(client.OpenRead(address))
        newestver = reader.ReadToEnd
        If newestver = verzia Then
            newest = True
        Else
            newest = False
            dialog.ukaz("There's a new version available: " + newestver + vbNewLine + "You can download it now! Click ▼", My.Resources.info, "New Version!!", True)
        End If
        games
        moveright(currentindex)
    End Sub

    Public Sub games()
        Dim counter = My.Computer.FileSystem.GetFiles("games")
        Dim doc As New XmlDocument
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        For Each game In counter
            doc.Load(game)
            For Each atribut As XmlElement In doc.DocumentElement.GetElementsByTagName("game")
                'MsgBox(citajxml(atribut, "filename") + citajxml(atribut, "name"))

                ListBox1.Items.Add(citajxml(atribut, "filename"))
                ListBox3.Items.Add(citajxml(atribut, "iconfromexe"))
                ListBox4.Items.Add(citajxml(atribut, "iconfilename"))
                ListBox2.Items.Add(citajxml(atribut, "name"))
            Next atribut
        Next
    End Sub

    Public Sub moveright(center As Integer)
        Try
            If currentindex = ListBox2.Items.Count Then
                currentindex = 0
            End If
            If currentindex - 1 = -1 Then
                ListBox2.SelectedIndex = ListBox2.Items.Count - 1
                ListBox1.SelectedIndex = ListBox2.Items.Count - 1
                ListBox3.SelectedIndex = ListBox2.Items.Count - 1
                ListBox4.SelectedIndex = ListBox2.Items.Count - 1
            Else
                ListBox2.SelectedIndex = currentindex - 1
                ListBox1.SelectedIndex = currentindex - 1
                ListBox3.SelectedIndex = currentindex - 1
                ListBox4.SelectedIndex = currentindex - 1
            End If
            Label2.Text = ListBox2.SelectedItem
            If ListBox3.SelectedItem = "True" Then
                PictureBox3.Image = Drawing.Icon.ExtractAssociatedIcon(ListBox1.SelectedItem).ToBitmap
            Else
                PictureBox3.Image = Image.FromFile(ListBox4.SelectedItem)
            End If
            If currentindex + 1 = ListBox1.Items.Count Then
                ListBox2.SelectedIndex = 0
                ListBox4.SelectedIndex = 0
                ListBox3.SelectedIndex = 0
                ListBox1.SelectedIndex = 0
            Else
                ListBox2.SelectedIndex = currentindex + 1
                ListBox1.SelectedIndex = currentindex + 1
                ListBox3.SelectedIndex = currentindex + 1
                ListBox4.SelectedIndex = currentindex + 1
            End If
            Label4.Text = ListBox2.SelectedItem
            If ListBox3.SelectedItem = "True" Then
                PictureBox2.Image = Drawing.Icon.ExtractAssociatedIcon(ListBox1.SelectedItem).ToBitmap
            Else
                PictureBox2.Image = Image.FromFile(ListBox4.SelectedItem)
            End If
            If currentindex = ListBox1.Items.Count Then
                ListBox2.SelectedIndex = 0
                ListBox1.SelectedIndex = 0
                ListBox3.SelectedIndex = 0
                ListBox4.SelectedIndex = 0
            Else
                ListBox2.SelectedIndex = currentindex
                ListBox1.SelectedIndex = currentindex
                ListBox3.SelectedIndex = currentindex
                ListBox4.SelectedIndex = currentindex
            End If
            Label3.Text = ListBox2.SelectedItem
            currentindex = currentindex + 1
            If ListBox3.SelectedItem = "True" Then
                PictureBox1.Image = Drawing.Icon.ExtractAssociatedIcon(ListBox1.SelectedItem).ToBitmap
            Else
                PictureBox1.Image = Image.FromFile(ListBox4.SelectedItem)
            End If


        Catch ex As Exception
            If ex.Message = "The path is not of a legal form." Then
                dialog.ukaz("You need to upgrade gamelist!" + vbNewLine + "If you don't want, it will show this error every time", My.Resources.err, "Fatal error!", False)
            Else

                dialog.ukaz("You need to add atleast one game.", My.Resources.err, "Fatal error!", False)
            End If
            settings.Show()
        End Try

    End Sub


    Private Function citajxml(ByVal node As XmlNode, ByVal attibutename As String) As String
        Dim ret As String = String.Empty
        If node IsNot Nothing AndAlso node.Attributes IsNot Nothing Then
            Dim attrib As XmlNode = node.Attributes.GetNamedItem(attibutename)
            If attrib IsNot Nothing Then
                ret = attrib.Value
            End If
        End If
        Return ret
    End Function 'GetAttibuteValue

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        settings.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = My.Settings.nonanimode.ToString + vbNewLine + Width.ToString + "x" + Height.ToString + vbNewLine + verzia + vbNewLine + newest.ToString + " " + newestver
    End Sub

    Private Sub Form1_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        If e.Delta = 120 Then
            moveright(currentindex)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Process.Start(ListBox1.SelectedItem)
        Catch ex As Exception
            dialog.ukaz("Uh Oh! Something happened!", My.Resources.err, "Fatal error!!", False)
        End Try

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If My.Settings.color = "green" Then
            Button2.BackColor = Color.LimeGreen
            Button2.FlatAppearance.MouseDownBackColor = Color.Green
            Button2.FlatAppearance.MouseOverBackColor = Color.GreenYellow
        ElseIf My.Settings.color = "red" Then
            Button2.BackColor = Color.Red
            Button2.FlatAppearance.MouseDownBackColor = Color.Maroon
            Button2.FlatAppearance.MouseOverBackColor = Color.IndianRed
        ElseIf My.Settings.color = "blue" Then
            Button2.BackColor = Color.DeepSkyBlue
            Button2.FlatAppearance.MouseDownBackColor = Color.SteelBlue
            Button2.FlatAppearance.MouseOverBackColor = Color.SkyBlue
        ElseIf My.Settings.color = "gray" Then
            Button2.BackColor = Color.Gray
            Button2.FlatAppearance.MouseDownBackColor = Color.DimGray
            Button2.FlatAppearance.MouseOverBackColor = Color.LightGray
        ElseIf My.Settings.color = "yellow" Then
            Button2.BackColor = Color.Gold
            Button2.FlatAppearance.MouseDownBackColor = Color.DarkGoldenrod
            Button2.FlatAppearance.MouseOverBackColor = Color.Khaki
        End If
    End Sub
End Class
