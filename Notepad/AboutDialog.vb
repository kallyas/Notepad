Public Class AboutDialog
    Public Sub New()
        InitializeComponent()

        ' Set the size of the AboutDialog form
        Me.Size = New Size(460, 423)
        Me.Text = "About Notepad Clone"
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.ResizeRedraw = False
        Me.FormBorderStyle = FormBorderStyle.FixedDialog

    End Sub
End Class
