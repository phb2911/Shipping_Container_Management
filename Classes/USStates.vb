' By Pablo Borges
' 2006-Dec-20

Option Explicit On
Option Strict On

Public Class USStates

    Dim _full() As String
    Dim _abrv() As String

    Private Sub New()
        Me._full = New String() {"Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", _
                "District of Columbia", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", _
                "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", _
                "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", _
                "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", _
                "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming"}
        Me._abrv = New String() {"AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FL", "GA", "HI", "ID", "IL", "IN", "IA", _
            "KS", "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", _
            "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY"}
    End Sub

    Private Function returnFullName(ByVal Abreviation As String) As String

        Abreviation = Abreviation.Trim

        Dim index As Integer = Array.IndexOf(Me._abrv, Abreviation.ToUpper)

        If index < 0 Then Throw New Exception(Abreviation & " is not a valid state abreviation.")

        Return Me._full(index)

    End Function

    Private Function returnAbreviation(ByVal StateName As String) As String

        StateName = StateName.Trim

        Dim index As Integer = -1

        For i As Integer = 0 To Me._abrv.GetUpperBound(0)
            If Me._full(i).ToUpper = StateName.ToUpper Then
                index = i
                Exit For
            End If
        Next

        If index < 0 Then Throw New Exception(StateName & " is not a US State.")

        Return Me._abrv(index)

    End Function

    Private Function FullNames() As String()
        Return Me._full
    End Function

    Private Function Abrvs() As String()
        Return Me._abrv
    End Function

    Public Shared Function GetStateName(ByVal Abreviation As String) As String
        Dim obj As New USStates
        Return obj.returnFullName(Abreviation)
    End Function

    Public Shared Function GetAbreviation(ByVal StateName As String) As String
        Dim obj As New USStates
        Return obj.returnAbreviation(StateName)
    End Function

    Public Shared ReadOnly Property States() As String()
        Get
            Dim obj As New USStates
            Return obj.FullNames
        End Get
    End Property

    Public Shared ReadOnly Property Abreviations() As String()
        Get
            Dim obj As New USStates
            Return obj.Abrvs
        End Get
    End Property

End Class
