Option Explicit On
Option Strict On

Public Class BackupWriter

    Dim _fileName As String
    Dim _fs As IO.FileStream
    Dim _sw As IO.StreamWriter
    Dim _started As Boolean = False
    Dim _tableStarted As Boolean = False
    Dim _rowStarted As Boolean = False

    Public Sub New(ByVal fileName As String)
        Me._fileName = fileName
    End Sub

    Public ReadOnly Property FileName() As String
        Get
            Return Me._fileName
        End Get
    End Property

    Public Sub StartBackup()

        If Me._started Then _
            Throw New Exception("Backup already started.")

        Me._fs = New IO.FileStream(Me._fileName, IO.FileMode.Create, IO.FileAccess.Write)
        Me._sw = New IO.StreamWriter(Me._fs)

        Me._sw.WriteLine("START_BACKUP||" & Now.ToString & "||" & My.Application.Info.Version.ToString())

        Me._started = True

    End Sub

    Public Sub EndBackup()

        If Not Me._started Then _
            Throw New Exception("Backup not started.")

        If Not Me._rowStarted Or Not Me._tableStarted Then _
            Throw New Exception("Any table or row must be closed before backup is finalized.")

        Me._sw.WriteLine("END_BACKUP")

        Me._sw.Close()

        Me._fs.Dispose()
        Me._sw.Dispose()

        Me._started = False

    End Sub

    Public Sub StartTable(ByVal TableName As String)

        If Not Me._started Then _
            Throw New Exception("Backup not started.")

        If Me._tableStarted Or Me._rowStarted Then _
            Throw New Exception("Any table or row must be closed before a table is open.")

        Me._sw.WriteLine("START_TABLE||" & TableName)

        Me._tableStarted = True

    End Sub

    Public Sub EndTable()

        If Not Me._started Then _
            Throw New Exception("Backup not started.")

        If Not Me._tableStarted Then _
            Throw New Exception("A table was not started.")

        If Me._rowStarted Then _
            Throw New Exception("A row was not ended.")

        Me._sw.WriteLine("END_TABLE")

        Me._tableStarted = False

    End Sub

    Public Sub StartRow()

        If Not Me._started Then _
            Throw New Exception("Backup not started.")

        If Not Me._tableStarted Then _
            Throw New Exception("A table was not started.")

        If Me._rowStarted Then _
            Throw New Exception("A row was not ended.")

        Me._sw.WriteLine("START_ROW")

        Me._rowStarted = True

    End Sub

    Public Sub EndRow()

        If Not Me._started Then _
            Throw New Exception("Backup not started.")

        If Not Me._tableStarted Then _
            Throw New Exception("A table was not started.")

        If Not Me._rowStarted Then _
            Throw New Exception("A row was not started.")

        Me._sw.WriteLine("END_ROW")

        Me._rowStarted = False

    End Sub

    Public Sub AddCell(ByVal Name As String, ByVal Value As String)

        If Not Me._started Then _
            Throw New Exception("Backup not started.")

        If Not Me._tableStarted Then _
            Throw New Exception("A table was not started.")

        If Not Me._rowStarted Then _
            Throw New Exception("A row was not started.")

        Me._sw.WriteLine("CELL||" & Name & "||" & Value)

    End Sub

End Class
