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
    Function saveData()
        MsgBox("Yay it works")
    End Function

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        'End
        'We can use a self reference object Me
        If RichTextBox1.Text <> Nothing Then
            MsgBox("Do you want to save changes to Untitled?", MessageBoxButtons.YesNoCancel)
            If DialogResult.No Then
                End
            ElseIf DialogResult.Yes Then
                saveData()
            ElseIf DialogResult.Cancel Then
                Return
            Else
                'Something went wrong!
            End If
        End If
    End Sub

    Private Sub mnuFont_Click(sender As Object, e As EventArgs) Handles mnuFont.Click
        dlgFont.ShowDialog()
        If dlgFont.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            RichTextBox1.ForeColor = dlgFont.Color
            RichTextBox1.Font = dlgFont.Font

        End If
    End Sub


    Private Sub Notepad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox1.Font = New Drawing.Font("consolas", 16)
    End Sub

    Private Sub mnuWordWrap_Click(sender As Object, e As EventArgs) Handles mnuWordWrap.Click
        WrapText(RichTextBox1.Text, 30)
    End Sub

    Private Sub mnuZoomIn_Click(sender As Object, e As EventArgs) Handles mnuZoomIn.Click
        RichTextBox1.ZoomFactor += zoomfactor
    End Sub

    Private Sub mnuZoomOut_Click(sender As Object, e As EventArgs) Handles mnuZoomOut.Click
        RichTextBox1.ZoomFactor -= zoomfactor
    End Sub

    Private Sub mnuDefaultZoom_Click(sender As Object, e As EventArgs) Handles mnuDefaultZoom.Click
        RichTextBox1.ZoomFactor = 0F
    End Sub
End Class
