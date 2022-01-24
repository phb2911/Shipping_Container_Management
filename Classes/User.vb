Public Class User

    Dim _name As String
    Dim _id As Integer = -1
    Dim _authentic As Boolean = False

    Private Enum CredentialType As Byte
        CreateUsers
        AccessSensitiveInfo
    End Enum

#Region "Constructor/Destructor"

    Public Sub New(ByVal UserName As String, ByVal Password As String)
        Me.New(UserName, Password, Nothing)
    End Sub

    Public Sub New(ByVal UserName As String, ByVal Password As String, ByRef Connection As SqlClient.SqlConnection)

        Me._name = UserName
        Me._authentic = Me.Authenticate(Password, Connection)

    End Sub

    Private Sub New(ByVal UserName As String)
        Me._name = UserName
    End Sub

    Friend Sub Destroy()
        Me._name = ""
        Me._id = -1
        Me._authentic = False
        MyBase.Finalize()
    End Sub

#End Region ' Constructor/Destructor

#Region "Methods"

    Friend Shared Function DeleteUser(ByVal UserName As String) As Boolean
        Return DeleteUser(UserName, Nothing)
    End Function

    Friend Shared Function DeleteUser(ByVal UserName As String, ByRef Connection As SqlClient.SqlConnection) As Boolean
        Dim myConn As SqlClient.SqlConnection = Nothing
        Dim myCmd As New SqlClient.SqlCommand
        Dim OutConnFlag As Boolean = (Connection IsNot Nothing AndAlso Connection.State = ConnectionState.Open)
        Dim flag As Boolean = True

        If UserName = "" Then Throw New Exception("UserName can't be empty.")

        Try
            If OutConnFlag Then
                myConn = Connection
            Else
                myConn = New SqlClient.SqlConnection(GS.ConnectionString)
                myConn.Open()
            End If

            myCmd.Connection = myConn
            myCmd.CommandText = "DELETE FROM [Users] WHERE [User Name]='" & UserName & "'"

            flag = CBool(myCmd.ExecuteNonQuery())

        Catch ex As Exception
            MessageBox.Show("An error occurred while accessing the database." & vbCrLf & vbCrLf & _
                 "Details: " & ex.Message & vbCrLf & vbCrLf & "Please check your connection and try again.", "Error", _
                 MessageBoxButtons.OK, MessageBoxIcon.Error)
            flag = False
        Finally
            If Not OutConnFlag And myConn IsNot Nothing Then
                If myConn.State = ConnectionState.Open Then myConn.Close()
                myConn.Dispose()
            End If
            If myCmd IsNot Nothing Then myCmd.Dispose()
        End Try

        Return flag

    End Function

    Friend Shared Function ChangeCredentials(ByVal UserName As String, ByVal Level As Integer) As Boolean
        Return ChangeCredentials(UserName, Level, Nothing)
    End Function

    Friend Shared Function ChangeCredentials(ByVal UserName As String, ByVal Level As Integer, ByRef Connection As SqlClient.SqlConnection) As Boolean
        Dim myConn As SqlClient.SqlConnection = Nothing
        Dim myCmd As New SqlClient.SqlCommand
        Dim OutConnFlag As Boolean = (Connection IsNot Nothing AndAlso Connection.State = ConnectionState.Open)
        Dim flag As Boolean = True
        Dim CrU As String = "0"
        Dim ASI As String = "0"

        If Level < 0 Then Throw New Exception("Level cannot be negative.")
        If UserName = "" Then Throw New Exception("UserName can't be empty.")

        If Level >= 2 Then
            ASI = "1"
            Level -= 2
        End If

        If Level >= 1 Then
            CrU = "1"
        End If

        Try
            If OutConnFlag Then
                myConn = Connection
            Else
                myConn = New SqlClient.SqlConnection(GS.ConnectionString)
                myConn.Open()
            End If

            myCmd.Connection = myConn
            myCmd.CommandText = "UPDATE [Users] SET [CreateUsers]=" & CrU & ",[AccessSensitiveInfo]=" & ASI & " WHERE [User Name]='" & UserName & "'"

            flag = CBool(myCmd.ExecuteNonQuery())

        Catch ex As Exception
            MessageBox.Show("An error occurred while accessing the database." & vbCrLf & vbCrLf & _
                 "Details: " & ex.Message & vbCrLf & vbCrLf & "Please check your connection and try again.", "Error", _
                 MessageBoxButtons.OK, MessageBoxIcon.Error)
            flag = False
        Finally
            If Not OutConnFlag And myConn IsNot Nothing Then
                If myConn.State = ConnectionState.Open Then myConn.Close()
                myConn.Dispose()
            End If
            If myCmd IsNot Nothing Then myCmd.Dispose()
        End Try

        Return flag

    End Function

    Friend Shared Function ChangePassword(ByVal UserName As String, ByVal NewPassword As String) As Boolean
        Return ChangePassword(UserName, NewPassword, Nothing)
    End Function

    Friend Shared Function ChangePassword(ByVal UserName As String, ByVal NewPassword As String, ByRef Connection As SqlClient.SqlConnection) As Boolean
        Dim oUser As New User(UserName)
        Return oUser.ChangePassword(NewPassword, Connection)
    End Function

    Friend Function ChangePassword(ByVal NewPassword As String) As Boolean
        Dim EmptyConn As SqlClient.SqlConnection = Nothing
        Return Me.ChangePassword(NewPassword, EmptyConn)
    End Function

    Friend Function ChangePassword(ByVal NewPassword As String, ByRef Connection As SqlClient.SqlConnection) As Boolean

        Dim myConn As SqlClient.SqlConnection = Nothing
        Dim myCmd As New SqlClient.SqlCommand
        Dim OutConnFlag As Boolean = (Connection IsNot Nothing AndAlso Connection.State = ConnectionState.Open)
        Dim flag As Boolean = True
        Dim RowsAffected As Integer = 0

        If NewPassword = "" Then Throw New Exception("NewPassword cannot be empty.")

        Try
            If OutConnFlag Then
                myConn = Connection
            Else
                myConn = New SqlClient.SqlConnection(GS.ConnectionString)
                myConn.Open()
            End If

            myCmd.Connection = myConn
            myCmd.CommandText = "UPDATE [Users] SET [Password]='" & Cryptography.MD5.HashString(NewPassword) & _
                    "' WHERE [User Name]='" & Me._name & "'"

            RowsAffected = myCmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("An error occurred while accessing the database." & vbCrLf & vbCrLf & _
                 "Details: " & ex.Message & vbCrLf & vbCrLf & "Please check your connection and try again.", "Error", _
                 MessageBoxButtons.OK, MessageBoxIcon.Error)
            flag = False
        Finally
            If Not OutConnFlag And myConn IsNot Nothing Then
                If myConn.State = ConnectionState.Open Then myConn.Close()
                myConn.Dispose()
            End If
            If myCmd IsNot Nothing Then myCmd.Dispose()
        End Try

        If RowsAffected = 0 Then flag = False

        Return flag

    End Function

    Private Function Authenticate(ByVal Password As String, ByRef Connection As SqlClient.SqlConnection) As Boolean

        Dim myConn As SqlClient.SqlConnection = Nothing
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDa As New SqlClient.SqlDataAdapter
        Dim myDs As New DataSet
        Dim OutConnFlag As Boolean = (Connection IsNot Nothing AndAlso Connection.State = ConnectionState.Open)
        Dim flag As Boolean = True

        Try
            If OutConnFlag Then
                myConn = Connection
            Else
                myConn = New SqlClient.SqlConnection(GS.ConnectionString)
                myConn.Open()
            End If

            myCmd.Connection = myConn
            myCmd.CommandText = "SELECT [User ID],[Password] FROM [Users] WHERE [User Name]='" & Me._name & "'"
            ' AND [Password]='" & _
            'Cryptography.MD5.HashString(Password) & "'"

            myDa.SelectCommand = myCmd
            myDa.Fill(myDs, "Users")

            If myDs.Tables("Users").Rows.Count = 0 OrElse _
                Cryptography.MD5.HashString(Password) <> myDs.Tables("Users").Rows(0).Item("Password").ToString Then
                flag = False
            Else
                Me._id = CInt(myDs.Tables("Users").Rows(0).Item("User ID"))
            End If

        Catch ex As Exception
            MessageBox.Show("An error occurred while accessing the database." & vbCrLf & vbCrLf & _
                "Details: " & ex.Message & vbCrLf & vbCrLf & "Please check your connection and try again.", "Error", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            flag = False
        Finally
            If Not OutConnFlag And myConn IsNot Nothing Then
                If myConn.State = ConnectionState.Open Then myConn.Close()
                myConn.Dispose()
            End If
            If myCmd IsNot Nothing Then myCmd.Dispose()
        End Try

        Me._authentic = flag
        Return flag

    End Function

    Friend Shared Function CreateNewUser(ByVal UserName As String, ByVal Password As String) As Boolean
        Return CreateNewUser(UserName, Password, 0, Nothing)
    End Function

    Friend Shared Function CreateNewUser(ByVal UserName As String, ByVal Password As String, ByVal Level As Integer) As Boolean
        Return CreateNewUser(UserName, Password, Level, Nothing)
    End Function

    Friend Shared Function CreateNewUser(ByVal UserName As String, ByVal Password As String, ByVal Level As Integer, ByRef Connection As SqlClient.SqlConnection) As Boolean

        ' level 1 - create users
        ' level 2 - read sensitive info

        Dim myConn As SqlClient.SqlConnection = Nothing
        Dim myCmd As New SqlClient.SqlCommand
        Dim OutConnFlag As Boolean = (Connection IsNot Nothing AndAlso Connection.State = ConnectionState.Open)
        Dim flag As Boolean = True
        Dim ErrMsg As String = String.Empty

        If UserName = "" Or Password = "" Then Throw New Exception("UserName and Password cannot be empty.")

        Try
            If OutConnFlag Then
                myConn = Connection
            Else
                myConn = New SqlClient.SqlConnection(GS.ConnectionString)
                myConn.Open()
            End If

            myCmd.Connection = myConn
            myCmd.CommandText = "IF EXISTS(SELECT [User ID] FROM [Users] WHERE [User Name]='" & UserName & "') SELECT 1 ELSE SELECT 0"

            If CBool(myCmd.ExecuteScalar()) Then
                ErrMsg = "User Name already in use. Pleas choose a different one and try again."
                flag = False
            Else

                Dim CrU As String = "0"
                Dim RSI As String = "0"

                If Level >= 2 Then
                    RSI = "1"
                    Level -= 2
                End If

                If Level >= 1 Then
                    CrU = "1"
                End If

                myCmd.CommandText = "INSERT INTO [Users]([User Name],[Password],[CreateUsers],[AccessSensitiveInfo]) VALUES ('" & _
                    UserName & "','" & Cryptography.MD5.HashString(Password) & "'," & CrU & "," & RSI & ")"

                myCmd.ExecuteNonQuery()

            End If

        Catch ex As Exception
            ErrMsg = "An error occurred while accessing the database." & vbCrLf & vbCrLf & _
                     "Details: " & ex.Message & "Please check your connection and try again."
            flag = False
        Finally
            If Not OutConnFlag And myConn IsNot Nothing Then
                If myConn.State = ConnectionState.Open Then myConn.Close()
                myConn.Dispose()
            End If
            If myCmd IsNot Nothing Then myCmd.Dispose()
        End Try

        If Not flag Then _
            MessageBox.Show(ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Return flag

    End Function

    Private Sub Validate()
        If Me._id < 0 Then _
            Throw New Exception("User not authentic.")
    End Sub

    Private Function GetCredential(ByVal Type As CredentialType, ByRef Connection As SqlClient.SqlConnection) As Boolean
        Dim myConn As SqlClient.SqlConnection = Nothing
        Dim myCmd As New SqlClient.SqlCommand
        Dim OutConnFlag As Boolean = (Connection IsNot Nothing AndAlso Connection.State = ConnectionState.Open)
        Dim flag As Boolean = True

        Try

            If OutConnFlag Then
                myConn = Connection
            Else
                myConn = New SqlClient.SqlConnection(GS.ConnectionString)
                myConn.Open()
            End If

            myCmd.Connection = myConn
            myCmd.CommandText = "SELECT [" & Type.ToString & "] FROM [Users] WHERE [User Name]='" & Me._name & "'"

            flag = CBool(myCmd.ExecuteScalar())

        Catch ex As Exception
            flag = False
        Finally
            If Not OutConnFlag And myConn IsNot Nothing Then
                If myConn.State = ConnectionState.Open Then myConn.Close()
                myConn.Dispose()
            End If
            If myCmd IsNot Nothing Then myCmd.Dispose()
        End Try

        Return flag

    End Function

#End Region ' methods

#Region "Properties"

    Friend ReadOnly Property IsAuthentic() As Boolean
        Get
            Return Me._authentic
        End Get
    End Property

    Friend ReadOnly Property ID() As Integer
        Get
            Me.Validate()
            Return Me._id
        End Get
    End Property

    Friend ReadOnly Property Name() As String
        Get
            Return Me._name
        End Get
    End Property

    Friend ReadOnly Property CreateUsers() As Boolean
        Get
            Return Me.CreateUsers(Nothing)
        End Get
    End Property

    Friend ReadOnly Property CreateUsers(ByVal Connection As SqlClient.SqlConnection) As Boolean
        Get
            Return Me.GetCredential(CredentialType.CreateUsers, Connection)
        End Get
    End Property

    Friend ReadOnly Property AccessSensitiveInfo() As Boolean
        Get
            Return Me.AccessSensitiveInfo(Nothing)
        End Get
    End Property

    Friend ReadOnly Property AccessSensitiveInfo(ByVal Connection As SqlClient.SqlConnection) As Boolean
        Get
            Return Me.GetCredential(CredentialType.AccessSensitiveInfo, Connection)
        End Get
    End Property

#End Region ' Properties

End Class
