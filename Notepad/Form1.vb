Imports System.IO

Public Class Notepad

    Const zoomfactor = 0.1F
    Public Function WrapText(ByVal Text As String, ByVal LineLength As Integer) As List(Of String)

        Dim ReturnValue As New List(Of String)
        ' Remove leading and trailing spaces
        Text = Trim(Text)


        Dim Words As String() = Text.Split(" ")

        If Words.Length = 1 And Words(0).Length > LineLength Then

            ' Text is just one big word that is longer than one line
            ' Split it mercilessly
            Dim lines As Integer = (Int(Text.Length / LineLength) + 1)
            Text = Text.PadRight(lines * LineLength)
            For i = 0 To lines - 1
                Dim SliceStart As Integer = i * LineLength
                ReturnValue.Add(Text.Substring(SliceStart,
                LineLength))
            Next
        Else
            Dim CurrentLine As New System.Text.StringBuilder
            For Each Word As String In Words
                ' will this word fit on the current line?
                If CurrentLine.Length + Word.Length <
                LineLength Then
                    CurrentLine.Append(Word & " ")
                Else
                    ' is the word too long for one line
                    If Word.Length > LineLength Then
                        ' hack off the first piece, fill out the current line and start a new line
                        Dim Slice As String =
                        Word.Substring(0, LineLength - CurrentLine.Length)
                        CurrentLine.Append(Slice)
                        ReturnValue.Add(CurrentLine.ToString)

                        CurrentLine = New System.Text.StringBuilder()

                        ' Remove the first slice from the word
                        Word = Word.Substring(Slice.Length,
                        Word.Length - Slice.Length)

                        ' How many more lines do we need for this word?
                        Dim RemainingSlices As Integer =
                        Int(Word.Length / LineLength) + 1
                        For LineNumber = 1 To RemainingSlices

                            If LineNumber = RemainingSlices Then

                                'this is the last slice
                                CurrentLine.Append(Word & " ")
                            Else
                                ' this is not the last slice
                                ' hack off a slice that is one line long, add that slice
                                ' to the output as a line and start a new line
                                Slice = Word.Substring(0,
                                LineLength)
                                CurrentLine.Append(Slice)

                                ReturnValue.Add(CurrentLine.ToString)
                                CurrentLine = New System.Text.StringBuilder()

                                ' Remove the slice from the 

                                Word = Word.Substring(Slice.Length, Word.Length - Slice.Length)
                            End If
                        Next
                    Else
                        ' finish the current line and start a new one with the wrapped word
                        ReturnValue.Add(CurrentLine.ToString)
                        CurrentLine = New System.Text.StringBuilder(Word & " ")
                    End If
                End If
            Next

            ' Write the last line to the output
            If CurrentLine.Length > 0 Then
                ReturnValue.Add(CurrentLine.ToString)
            End If
        End If
        Return ReturnValue
    End Function
    'Save function
    Sub saveData()
        Using sfd As New SaveFileDialog
            sfd.Filter = "Rich Text|*.rtf|Plain Text|*.txt"
            sfd.AddExtension = True
            If sfd.ShowDialog = DialogResult.OK Then
                If sfd.FilterIndex = 1 Then
                    RichTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.RichText)
                Else
                    RichTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText)
                End If
                Dim strArr() As String
                strArr = sfd.FileName.Split("\")
                Me.Text = strArr(5) + " - Notepad"
            End If
        End Using
    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        'Exit with save confirmation
        If RichTextBox1.Text <> Nothing Then
            Dim result As DialogResult = MessageBox.Show("Do you want to save changes to Untitled?", "Notepad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Me.saveData()
                End
            ElseIf result = DialogResult.No Then
                End
            ElseIf result = DialogResult.Cancel Then
                Return
            End If
        Else
            End
        End If
    End Sub

    Private Sub mnuFont_Click(sender As Object, e As EventArgs) Handles mnuFont.Click
        dlgFont.ShowDialog()
        If dlgFont.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            RichTextBox1.ForeColor = dlgFont.Color
            RichTextBox1.Font = dlgFont.Font

        End If
    End Sub


    'disable some menus on start and apply modern styling
    Private Sub Notepad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox1.Font = New Drawing.Font("Consolas", 11)
        RichTextBox1.BackColor = Color.FromArgb(30, 30, 30)
        RichTextBox1.ForeColor = Color.FromArgb(220, 220, 220)
        
        mainMenu.BackColor = Color.FromArgb(45, 45, 48)
        mainMenu.ForeColor = Color.White
        
        mainStatusStrip.BackColor = Color.FromArgb(0, 122, 204)
        mainStatusStrip.ForeColor = Color.White
        
        Me.BackColor = Color.FromArgb(37, 37, 38)
        
        mnuCopy.Enabled = False
        mnuCut.Enabled = False
        mnuDel.Enabled = False
        mnuUndo.Enabled = False
        mnuRedo.Enabled = False
        StatusBarToolStripMenuItem.Checked = True
        Me.Text = "Untitled - Notepad"
    End Sub

    Private Sub mnuWordWrap_Click(sender As Object, e As EventArgs) Handles mnuWordWrap.Click
        RichTextBox1.WordWrap = Not RichTextBox1.WordWrap
        mnuWordWrap.Checked = RichTextBox1.WordWrap
    End Sub

    Private Sub mnuZoomIn_Click(sender As Object, e As EventArgs) Handles mnuZoomIn.Click
        RichTextBox1.ZoomFactor += zoomfactor
    End Sub

    Private Sub mnuZoomOut_Click(sender As Object, e As EventArgs) Handles mnuZoomOut.Click
        RichTextBox1.ZoomFactor -= zoomfactor
    End Sub

    Private Sub mnuDefaultZoom_Click(sender As Object, e As EventArgs) Handles mnuDefaultZoom.Click
        RichTextBox1.ZoomFactor = 1.0F
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        tlsChars.Text = RichTextBox1.Text.Length & " Characters"
        mnuUndo.Enabled = True
        mnuRedo.Enabled = True

        If RichTextBox1.SelectedText.Length > 0 Then
            mnuCopy.Enabled = True
            mnuCut.Enabled = True
            mnuDel.Enabled = True

        End If
    End Sub

    Private Sub mnuCut_Click(sender As Object, e As EventArgs) Handles mnuCut.Click
        If RichTextBox1.SelectionLength > 0 Then
            RichTextBox1.Cut()
        End If
    End Sub

    Private Sub mnuUndo_Click(sender As Object, e As EventArgs) Handles mnuUndo.Click
        If RichTextBox1.CanUndo Then
            RichTextBox1.Undo()
        End If
    End Sub

    Private Sub mnuRedo_Click(sender As Object, e As EventArgs) Handles mnuRedo.Click
        If RichTextBox1.CanRedo Then
            RichTextBox1.Redo()
        End If
    End Sub

    Private Sub mnuPaste_Click(sender As Object, e As EventArgs) Handles mnuPaste.Click
        If RichTextBox1.CanPaste(DataFormats.GetFormat(DataFormats.Text)) Then
            RichTextBox1.Paste()
        End If
    End Sub

    Private Sub mnuCopy_Click(sender As Object, e As EventArgs) Handles mnuCopy.Click
        If RichTextBox1.SelectionLength > 0 Then
            RichTextBox1.Copy()
        End If
    End Sub

    Private Sub mnuSave_Click(sender As Object, e As EventArgs) Handles mnuSave.Click
        Using sfd As New SaveFileDialog
            sfd.Filter = "All Files (*.*)|*.*"
            sfd.AddExtension = True
            If sfd.ShowDialog() = DialogResult.OK Then
                If RichTextBox1.Text <> "" Then
                    Dim fileStream As New FileStream(sfd.FileName, FileMode.Create, FileAccess.Write)
                    Dim writer As New StreamWriter(fileStream)
                    writer.Write(RichTextBox1.Text)
                    writer.Close()
                    fileStream.Close()
                End If
                Me.Text = sfd.FileName.Split("\")(sfd.FileName.Split("\").Length - 1).Split(".")(0) + " - Notepad"
            End If
        End Using
    End Sub

    'open existing file. supported formats. rtf, txt
    Private Sub mnuOpen_Click(sender As Object, e As EventArgs) Handles mnuOpen.Click
        Using openFile As New OpenFileDialog
            openFile.Filter = "All Files (*.*)|*.*"
            openFile.AddExtension = True
            If openFile.ShowDialog() = DialogResult.OK Then
                Dim _path As String = openFile.FileName
                Try
                    Dim text As String = File.ReadAllText(_path)
                    RichTextBox1.Text = text
                    Me.Text = Path.GetFileNameWithoutExtension(_path) & " - Notepad"
                Catch ex As Exception
                    MsgBox(ex.Message.ToString(), MsgBoxStyle.Critical)
                End Try
            End If
        End Using
    End Sub

    Private Sub mnuNew_Click(sender As Object, e As EventArgs) Handles mnuNew.Click
        Dim ntpd = New Notepad()
        ntpd.Show()
    End Sub


    Private Sub StatusBarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        If mainStatusStrip.Visible Then
            mainStatusStrip.Visible = False
            StatusBarToolStripMenuItem.Checked = False
        Else
            mainStatusStrip.Visible = True
            StatusBarToolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub mnuAbout_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click
        Dim aboutDialog As New AboutDialog()
        aboutDialog.ShowDialog()
    End Sub

    Private Sub mnuDel_Click(sender As Object, e As EventArgs) Handles mnuDel.Click
        If RichTextBox1.SelectionLength > 0 Then
            RichTextBox1.SelectedText = ""
        End If
    End Sub

End Class
