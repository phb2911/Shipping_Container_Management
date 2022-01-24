
Class ListViewSorter

#Region "Global Fields"

    Dim _myLsv As ListView
    Dim _numCols() As Integer = {}
    Dim _dateCols() As Integer = {}
    Dim _oldColumn As Integer = -1
    Dim _sortOrder As SortOrder = SortOrder.Ascending

#End Region ' Global Fields

#Region "Constructor"

    ' unaccessible
    Private Sub New()

    End Sub

    Public Sub New(ByRef myListView As ListView)
        Me._myLsv = myListView
    End Sub

#End Region ' Constructor

#Region "Properties"

    Public WriteOnly Property NumericColumns() As Integer()
        Set(ByVal value As Integer())
            Me._numCols = value
        End Set
    End Property

    Public WriteOnly Property DateColumns() As Integer()
        Set(ByVal value As Integer())
            Me._dateCols = value
        End Set
    End Property

#End Region ' Properties

#Region "Methods"

    Public Sub Sort()
        Me.Sort(-1, SortOrder.None)
    End Sub

    Public Sub Sort(ByVal ColumnIndex As Integer)
        Me.Sort(ColumnIndex, SortOrder.None)
    End Sub

    Public Sub Sort(ByVal ColumnIndex As Integer, ByVal SrtOrder As SortOrder)

        Dim SortType As ListViewComparer.SortingDataType = Nothing

        If ColumnIndex < 0 Then
            ' same column, same sort order
            ColumnIndex = Me._oldColumn
        ElseIf ColumnIndex = Me._oldColumn Then
            'same column, invert sort order
            If Me._sortOrder = SortOrder.Ascending Then
                Me._sortOrder = SortOrder.Descending
            Else
                Me._sortOrder = SortOrder.Ascending
            End If
        Else
            ' different column
            Me._sortOrder = SortOrder.Ascending
        End If

        ' if parameter has a value, use it
        If SrtOrder <> SortOrder.None Then
            Me._sortOrder = SrtOrder
        End If

        If ColumnIndex < 0 Then ColumnIndex = 0

        Me._oldColumn = ColumnIndex

        ' select sort data type
        If Array.IndexOf(Me._numCols, ColumnIndex) <> -1 Then
            SortType = ListViewComparer.SortingDataType.Number
        ElseIf Array.IndexOf(Me._dateCols, ColumnIndex) <> -1 Then
            SortType = ListViewComparer.SortingDataType.Date
        Else
            SortType = ListViewComparer.SortingDataType.String
        End If

        ' select sorting arrow
        If Not IsNothing(Me._myLsv.SmallImageList) Then
            For i As Integer = 0 To Me._myLsv.Columns.Count - 1
                If i = ColumnIndex Then
                    Me._myLsv.Columns(i).ImageIndex = CInt(Me._sortOrder)
                Else
                    Me._myLsv.Columns(i).ImageIndex = 0
                End If
            Next
        End If

        ' sort
        Me._myLsv.ListViewItemSorter = New ListViewComparer(ColumnIndex, Me._sortOrder, SortType)
        Me._myLsv.Sort()

        Me._myLsv.ListViewItemSorter = Nothing

    End Sub

#End Region ' Methods

End Class

' Implements a comparer for ListView columns.
Class ListViewComparer
    Implements IComparer

    Public Enum SortingDataType As Byte
        [String]
        [Number]
        [Date]
    End Enum

    Private m_ColumnNumber As Integer
    Private m_SortOrder As SortOrder
    Private myDataType As SortingDataType


    Public Sub New(ByVal column_number As Integer, ByVal sort_order As SortOrder, ByVal DataType As SortingDataType)
        m_ColumnNumber = column_number
        m_SortOrder = sort_order
        myDataType = DataType
    End Sub

    ' Compare the items in the appropriate column
    ' for objects x and y.
    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
        Implements System.Collections.IComparer.Compare

        Dim item_x As ListViewItem = DirectCast(x, ListViewItem)
        Dim item_y As ListViewItem = DirectCast(y, ListViewItem)

        If myDataType = SortingDataType.String Then
            ' Get the sub-item values.
            Dim string_x As String
            If item_x.SubItems.Count <= m_ColumnNumber Then
                string_x = ""
            Else
                string_x = item_x.SubItems(m_ColumnNumber).Text
            End If

            Dim string_y As String
            If item_y.SubItems.Count <= m_ColumnNumber Then
                string_y = ""
            Else
                string_y = item_y.SubItems(m_ColumnNumber).Text
            End If

            ' Compare them.
            If m_SortOrder = SortOrder.Ascending Then
                Return string_x.CompareTo(string_y)
            Else
                Return string_y.CompareTo(string_x)
            End If
        ElseIf myDataType = SortingDataType.Number Then
            ' Get the sub-item values.
            Dim num_x As Double
            If item_x.SubItems.Count <= m_ColumnNumber Then
                num_x = 0
            Else
                Dim dblItem As String = item_x.SubItems(m_ColumnNumber).Text
                If dblItem = String.Empty Then
                    dblItem = "0"
                End If
                num_x = CDbl(dblItem)
            End If

            Dim num_y As Double
            If item_y.SubItems.Count <= m_ColumnNumber Then
                num_y = 0
            Else
                Dim dblItem As String = item_y.SubItems(m_ColumnNumber).Text
                If dblItem = String.Empty Then
                    dblItem = "0"
                End If
                num_y = CDbl(dblItem)
            End If

            ' Compare them.
            If m_SortOrder = SortOrder.Ascending Then
                Return num_x.CompareTo(num_y)
            Else
                Return num_y.CompareTo(num_x)
            End If
        ElseIf myDataType = SortingDataType.Date Then
            ' Get the sub-item values.
            Dim date_x As Date
            If item_x.SubItems.Count <= m_ColumnNumber Then
                date_x = #12:00:00 AM#
            Else
                Dim dtItem As String = item_x.SubItems(m_ColumnNumber).Text
                If dtItem = String.Empty Then
                    dtItem = "12:00:00 AM"
                End If
                date_x = CDate(dtItem)
            End If

            Dim date_y As Date
            If item_y.SubItems.Count <= m_ColumnNumber Then
                date_y = #12:00:00 AM#
            Else
                Dim dtItem As String = item_y.SubItems(m_ColumnNumber).Text
                If dtItem = String.Empty Then
                    dtItem = "12:00:00 AM"
                End If
                date_y = CDate(dtItem)
            End If

            ' Compare them.
            If m_SortOrder = SortOrder.Ascending Then
                Return date_x.CompareTo(date_y)
            Else
                Return date_y.CompareTo(date_x)
            End If
        End If

    End Function
End Class
