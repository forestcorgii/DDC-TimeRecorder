Public Class UserTimeStatus
    Inherits UserRecords

    '  Public UserState As String
    Public PreviousFlag As String
    Public _previousTime As Date
    Public _presentTime As Date


    Public ReadOnly Property PreviousTime(Optional f As String = "") As String
        Get
            If Not _previousTime = Nothing Then
                If f.ToLower = "d" Then
                    Return _previousTime.ToString("yyyy-MM-dd")
                Else : Return _previousTime.ToString("yyyy-MM-dd HH:mm:ss")
                End If
            Else : Return ""
            End If
        End Get
    End Property

    Public ReadOnly Property PresentTime(Optional f As String = "") As String
        Get
            If Not _presentTime = Nothing Then
                If f.ToLower = "d" Then
                    Return _presentTime.ToString("yyyy-MM-dd")
                ElseIf f.ToLower = "t" Then
                    Return _presentTime.ToString("hh:mm tt")
                Else : Return _presentTime.ToString("yyyy-MM-dd HH:mm:ss")
                End If
            Else : Return ""
            End If
        End Get
    End Property

    Sub New(_userDB As UserRecords) ', _userState As String)
        ' UserState = _userState
        With _userDB
            ID = .ID
            EmployeeNumber = .EmployeeNumber
            FirstName = .FirstName
            LastName = .LastName
            MiddleName = .MiddleName
            Company = .Company
            Schedule = .Schedule
            Department = .Department
            Available = .Available
            Admin = .Admin
        End With
        getTimeTableInfo()
    End Sub

    Private Sub getTimeTableInfo()
        Dim dt As New DataTable
        dt = TMconn.ToDT(String.Format("SELECT * FROM `{0}` ORDER BY `_TIME` DESC", ID))
        Dim time As String
        If Not dt.Rows.Count = 0 Then
            time = dt.Rows(0).Item("_TIME").ToString
            PreviousFlag = dt.Rows(0).Item("FLAG").ToString
        Else : time = "" : PreviousFlag = ""
        End If
        If Not time = "" Then
            _previousTime = Date.Parse(time)
        End If
    End Sub

End Class
