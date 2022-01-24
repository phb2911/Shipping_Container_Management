
Imports System.Text.RegularExpressions

Public Class Login

    Dim OkFlag As Boolean = False
    Dim _userName As String = ""
    Dim _ConfMode As Boolean = False

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal UserName As String)
        InitializeComponent()
        Me._userName = UserName
        Me._ConfMode = True
        Me.Text = "Confirmation"
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txtUserName.Focus()

        If Me._ConfMode Then Exit Sub

        My.Forms.Form1.LogInToolStripMenuItem.Enabled = False

    End Sub

    Private Sub Login_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Me._ConfMode Then Exit Sub

        If Not OkFlag Then _
            My.Forms.Form1.LogInToolStripMenuItem.Enabled = True

    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        Dim tempUser As User = Nothing
        Dim pattern As String = "^(\w+)$"
        Dim LoggedIn As Boolean = False

        Me.Cursor = Cursors.WaitCursor

        If Me._ConfMode And Me._userName.ToUpper <> Me.txtUserName.Text.ToUpper Then
            Me.Cursor = Cursors.Default
            MessageBox.Show("Please enter the same User Name you used to log in.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If Regex.IsMatch(Me.txtUserName.Text, pattern) And Regex.IsMatch(Me.txtPassword.Text, pattern) Then

            tempUser = New User(Me.txtUserName.Text, Me.txtPassword.Text)
            LoggedIn = tempUser.IsAuthentic()

        End If

        If LoggedIn Then
            If Not Me._ConfMode Then _
                My.Forms.Form1.LogIn(tempUser)
            Me.OkFlag = True
            Me.Close()
        Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("Invalid User Name or Password.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Friend ReadOnly Property Confirmed() As Boolean
        Get
            Return (Me.OkFlag And Me._ConfMode)
        End Get
    End Property

End Class