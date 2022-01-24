
Imports System.Xml

Public Class DbBackup

    Dim FB As New FolderBrowserDialog
    Dim _auto As Boolean

    Public Sub New()
        InitializeComponent()
        Me._auto = False
    End Sub

    Public Sub New(ByVal AutoBackup As Boolean)
        InitializeComponent()
        Me._auto = AutoBackup
    End Sub

    Private Sub DbBackup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me._auto Then
            Me.txtFileName.Text = GetSetting("Oceanne", "Auto-Backup", "FileName", "")
            Me.txtFilePath.Text = GetSetting("Oceanne", "Auto-Backup", "FilePath", "")
            Me.Label5.Text = "Auto-Backup in progress. Please wait..."
            Me.DisableControls()
        Else

            Dim BkDir As String = GetSetting("Oceanne", "Backup", "FilePath", "")

            If Not FileIO.FileSystem.DirectoryExists(BkDir) Then BkDir = ""

            Me.txtFilePath.Text = BkDir
            Me.txtFileName.Text = GetSetting("Oceanne", "Backup", "FileName", "")

            Me.Label5.Text = ""

        End If
    End Sub

    Private Sub DbBackup_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Me._auto Then Me.btnBackup_Click(Nothing, Nothing)
    End Sub

    Private Sub DisableControls()
        Me.txtFileName.ReadOnly = True
        Me.btnBackup.Enabled = False
        Me.btnBrowse.Enabled = False
        Me.btnClose.Enabled = False
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        Dim Y As Integer = 373

        Dim myPen As New System.Drawing.Pen(Color.Gray)
        Dim myPen2 As New System.Drawing.Pen(Color.White)
        Dim formGraphics As System.Drawing.Graphics = Me.CreateGraphics()
        Dim W As Integer = Me.Width

        formGraphics.DrawLine(myPen, 0, Y, W, Y)
        formGraphics.DrawLine(myPen2, 0, Y + 1, W, Y + 1)

        myPen.Dispose()
        myPen2.Dispose()
        formGraphics.Dispose()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click

        If Me.FB.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            Me.txtFilePath.Text = Me.FB.SelectedPath
        End If

    End Sub

    Private Sub txtFileName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFileName.LostFocus
        Me.txtFileName.Text = Me.txtFileName.Text.Trim()

        If Me.txtFileName.Text <> "" AndAlso (System.IO.Path.GetExtension(Me.txtFileName.Text).ToUpper <> ".OBF" And _
            Me.ValidateFileName(Me.txtFileName.Text)) Then

            Me.txtFileName.Text &= ".obf"

        End If

    End Sub

    Private Function ValidateFileName(ByVal FileName As String) As Boolean
        Return Not System.Text.RegularExpressions.Regex.IsMatch(FileName, "(\\)|(\/)|(\:)|(\?)|(\"")|(\<)|(\>)|(\|)|(\.)$")
    End Function

    Private Sub btnBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackup.Click

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim myRd As SqlClient.SqlDataReader = Nothing
        Dim Tables() As String = {}
        Dim xmlTW As XmlTextWriter = Nothing
        Dim fileName As String = ""
        Dim ErrMsg As String = "Success."
        Dim ErrFlag As Boolean = False
        Dim Icon As System.Windows.Forms.MessageBoxIcon = MessageBoxIcon.Information

        Me.Label5.Text = ""

        Me.txtFileName.Text = Me.txtFileName.Text.Trim
        Me.txtFilePath.Text = Me.txtFilePath.Text.Trim

        If Me.txtFileName.Text = "" Or Not Me.ValidateFileName(Me.txtFileName.Text) Then
            Me.Cursor = Cursors.Default
            MessageBox.Show("The file name is invalid.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        fileName = Me.txtFilePath.Text

        If fileName <> "" AndAlso fileName.Substring(fileName.Length - 1, 1) <> "\" Then
            fileName &= "\"
        End If

        fileName &= Me.txtFileName.Text

        If System.IO.Path.GetExtension(fileName).ToUpper <> ".OBF" Then
            fileName &= ".obf"
        End If

        If (Not Me._auto And System.IO.File.Exists(fileName)) AndAlso MessageBox.Show("The file '" & fileName & _
            "' already exists. Would you like to overwrite it?", "Overwrite confirmation", MessageBoxButtons.YesNo, _
            MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub

        Me.Cursor = Cursors.WaitCursor

        Try
            xmlTW = New XmlTextWriter(fileName, Nothing)

            ' start document
            xmlTW.WriteStartDocument()
            ' set formattation
            xmlTW.Formatting = Formatting.Indented

            xmlTW.WriteStartElement("database") ' start database

            xmlTW.WriteStartAttribute("date") ' start date attribute
            xmlTW.WriteString(Now.ToString)
            xmlTW.WriteEndAttribute() ' end date attribute

            xmlTW.WriteStartAttribute("version") ' start version attribute
            xmlTW.WriteString(My.Application.Info.Version.ToString())
            xmlTW.WriteEndAttribute() ' end version attribute

            myConn.Open()
            myCmd.Connection = myConn

            ' get tables
            Tables = Me.GetTableNames(myConn)

            Dim CmdStr As String = "SELECT ("
            Dim flag As Boolean = False
            Dim RecNum As Integer = 0

            For Each table As String In Tables
                If flag Then CmdStr &= "+"
                CmdStr &= "(SELECT COUNT(*) FROM [" & table & "])"
                flag = True
            Next

            CmdStr &= ")"

            myCmd.CommandText = CmdStr
            RecNum = CInt(myCmd.ExecuteScalar())

            If RecNum = 0 Then Throw New Exception("Database is empty.")

            Me.ProgressBar1.Maximum = RecNum

            For Each table As String In Tables
                myCmd.CommandText = "SELECT * FROM [" & table & "]"
                myRd = myCmd.ExecuteReader()

                xmlTW.WriteStartElement("table") ' start table

                xmlTW.WriteStartAttribute("name") ' start table name attribute
                xmlTW.WriteString(table)
                xmlTW.WriteEndAttribute() ' end table name attribute

                While myRd.Read()

                    xmlTW.WriteStartElement("row") ' start row

                    For i As Integer = 0 To myRd.FieldCount - 1

                        If Not IsDBNull(myRd(i)) Then

                            xmlTW.WriteStartElement("cell") ' statr cell

                            xmlTW.WriteStartAttribute("name") ' start cell name attribute
                            xmlTW.WriteString(myRd.GetName(i))
                            xmlTW.WriteEndAttribute() ' end cell name attribute

                            xmlTW.WriteString(Cryptography.TripleDES.Encode(myRd(i).ToString, GS.GlobalKey)) ' write value (cryptographed)
                            'xmlTW.WriteString(myRd(i).ToString) ' write value

                            xmlTW.WriteEndElement() ' end field

                        End If

                    Next

                    xmlTW.WriteEndElement() ' end row

                    Me.ProgressBar1.Value += 1

                End While

                xmlTW.WriteEndElement() ' end table

                myRd.Close()

            Next

            xmlTW.WriteEndElement() ' end database

            ' end document
            xmlTW.WriteEndDocument()

            ' write to file
            xmlTW.Flush()
            xmlTW.Close()

        Catch ex As Exception
            ErrMsg = "An error occured during backup." & vbCrLf & vbCrLf & "Description:" & vbCrLf & ex.Message & _
                vbCrLf & vbCrLf & "Your backup was not finalized. Please try again."
            Icon = MessageBoxIcon.Error
            ErrFlag = True
        Finally
            If myConn.State = ConnectionState.Open Then myConn.Close()
            myCmd.Dispose()
            myRd = Nothing
            xmlTW = Nothing
        End Try

        Me.Cursor = Cursors.Default

        If ErrFlag Then
            MessageBox.Show(ErrMsg, "Backup", MessageBoxButtons.OK, Icon)
        Else
            Me.Label5.Text = "Backup finalized successfully."
            SaveSetting("Oceanne", "Backup", "FileName", Me.txtFileName.Text)
            SaveSetting("Oceanne", "Backup", "FilePath", Me.txtFilePath.Text)
        End If

        Me.ProgressBar1.Value = 0

        If Me._auto Then Me.Close()

    End Sub

    Private Function GetTableNames(ByRef Connection As SqlClient.SqlConnection) As String()

        Dim myCmd As New SqlClient.SqlCommand
        Dim myRd As SqlClient.SqlDataReader = Nothing
        Dim TableCount As Integer = 0
        Dim Result() As String = {}

        myCmd.Connection = Connection
        myCmd.CommandText = "SELECT COUNT([name]) FROM [sysobjects] WHERE [type] = 'U'"

        TableCount = CInt(myCmd.ExecuteScalar())

        If TableCount > 0 Then

            ReDim Result(TableCount - 1)
            Dim TableIndex As Integer = 0

            myCmd.CommandText = "SELECT [name] FROM [sysobjects] WHERE [type] = 'U' ORDER BY [crdate]"
            myRd = myCmd.ExecuteReader()

            While myRd.Read()
                Result(TableIndex) = myRd(0).ToString
                TableIndex += 1
            End While

            myRd.Close()

        End If

        myCmd.Dispose()

        Return Result

    End Function

End Class