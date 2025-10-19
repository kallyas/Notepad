Public Class AboutDialog
    Public Sub New()
        InitializeComponent()

        ' Set the size and properties of the AboutDialog form
        Me.Size = New Size(460, 320)
        Me.Text = "About Notepad"
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.StartPosition = FormStartPosition.CenterParent
        Me.BackColor = Color.FromArgb(37, 37, 38)

        ' Create and configure labels
        Dim lblTitle As New Label()
        lblTitle.Text = "Notepad"
        lblTitle.Font = New Font("Segoe UI", 24, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(0, 122, 204)
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(20, 20)
        Me.Controls.Add(lblTitle)

        Dim lblVersion As New Label()
        lblVersion.Text = "Version 2.0"
        lblVersion.Font = New Font("Segoe UI", 11)
        lblVersion.ForeColor = Color.FromArgb(220, 220, 220)
        lblVersion.AutoSize = True
        lblVersion.Location = New Point(20, 65)
        Me.Controls.Add(lblVersion)

        Dim lblDescription As New Label()
        lblDescription.Text = "A modern, sleek notepad application" & vbCrLf & "with enhanced functionality and clean UI."
        lblDescription.Font = New Font("Segoe UI", 10)
        lblDescription.ForeColor = Color.FromArgb(200, 200, 200)
        lblDescription.AutoSize = True
        lblDescription.Location = New Point(20, 100)
        Me.Controls.Add(lblDescription)

        Dim lblCopyright As New Label()
        lblCopyright.Text = "© 2024 Notepad Application" & vbCrLf & "All rights reserved."
        lblCopyright.Font = New Font("Segoe UI", 9)
        lblCopyright.ForeColor = Color.FromArgb(180, 180, 180)
        lblCopyright.AutoSize = True
        lblCopyright.Location = New Point(20, 160)
        Me.Controls.Add(lblCopyright)

        ' Create OK button
        Dim btnOK As New Button()
        btnOK.Text = "OK"
        btnOK.Size = New Size(100, 35)
        btnOK.Location = New Point(330, 230)
        btnOK.FlatStyle = FlatStyle.Flat
        btnOK.BackColor = Color.FromArgb(0, 122, 204)
        btnOK.ForeColor = Color.White
        btnOK.Font = New Font("Segoe UI", 10)
        btnOK.Cursor = Cursors.Hand
        AddHandler btnOK.Click, AddressOf Me.btnOK_Click
        Me.Controls.Add(btnOK)

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class
