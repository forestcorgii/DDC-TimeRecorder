Imports SEAN.DatabaseManagement
Imports MySql.Data
Imports NPOI.SS.UserModel
Imports System.IO
Imports NPOI.XSSF.UserModel
Imports System.Xml.Serialization
Public Class clsSenderTimelog
    Implements ICloneable

    Public ID As String
    Public EmployeeID As String

    Public TimeInSendStatus As Byte
    Public TimeOutSendStatus As Byte

    Public _type As String

    Private ReadOnly Property _timeBound As Integer
        Get
            Select Case Now.Day
                Case 5, 6, 7, 20, 21, 22
                    Return 16
                Case Else
                    Return 16
            End Select
        End Get
    End Property

    Public ReadOnly Property Valid As Boolean
        Get
            If Timeout = "null" And Timein = "null" Then Return False
            If (TimeInSendStatus = 1 AndAlso TimeOutSendStatus = 1) Then Return False
            If TimeInSendStatus = 1 AndAlso Timeout = "null" Then Return False
            If TimeOutSendStatus = 1 AndAlso Timein = "null" Then Return False
            If ((Not Timein = "null") AndAlso (Now - Date.Parse(Timein)).TotalHours <= _timeBound) Then Return False
            If ((Not Timeout = "null") AndAlso (Now - Date.Parse(Timeout)).TotalHours <= _timeBound) Then Return False
            Return True
        End Get
    End Property

    Public Property encrypted_data As String
        Get
            Return encrypt(LogDate)
        End Get
        Set(value As String)

        End Set
    End Property
    Public Property LogDate As String
        Get
            If Timein <> "null" Then
                Return Date.Parse(Timein).ToString("yyyy-MM-dd")
            ElseIf Timeout <> "null" Then
                Return Date.Parse(Timeout).ToString("yyyy-MM-dd")
            End If
            Return ""
        End Get
        Set(value As String)

        End Set
    End Property
    Private _timein As String
    Public Property Timein As String
        Get
            If _timein <> Nothing And _timein <> "" Then
                Return _timein
            Else : Return "null"
            End If
        End Get
        Set(value As String)
            _timein = value
        End Set
    End Property

    Private _timeout As String
    Public Property Timeout As String
        Get
            If _timeout <> Nothing And _timeout <> "" Then
                Return _timeout
            Else : Return "null"
            End If
        End Get
        Set(value As String)
            _timeout = value
        End Set
    End Property

    Private Function encrypt(val As String) As String
        Dim newVal As String = ""
        For i As Integer = 0 To val.Length - 1
            Dim v As String = val(i)
            If Char.IsNumber(v) Then
                newVal &= Chr(Asc(val(i)) + CInt(v))
            Else
                newVal &= Chr(Asc(val(i)) + 3)
            End If
        Next
        Return newVal
    End Function

    Public Sub ClearTime()
        _timein = ""
        _timeout = ""
        TimeInSendStatus = 0
        TimeOutSendStatus = 0
    End Sub

    Public Function Clone() As Object Implements ICloneable.Clone
        Return Me.MemberwiseClone
    End Function

    Public Overrides Function ToString() As String
        Return String.Format("{0}   {1} - {2}", EmployeeID, Timein, Timeout)
    End Function
End Class

Public Class clsRequest
    Public LogDate As String
    Public _type As String
    Public Property encrypted_data As String
        Get
            Return encrypt(LogDate)
        End Get
        Set(value As String)

        End Set
    End Property
    Private Function encrypt(val As String) As String
        Dim newVal As String = ""
        For i As Integer = 0 To val.Length - 1
            Dim v As String = val(i)
            If Char.IsNumber(v) Then
                newVal &= Chr(Asc(val(i)) + CInt(v))
            Else
                newVal &= Chr(Asc(val(i)) + 3)
            End If
        Next
        Return newVal
    End Function
End Class

Public Class clsUpdateLog
    Public id_number As String
    Public log_date As String
    Public original_time_in As String
    Public original_time_out As String
    Public edited_time_in As String
    Public edited_time_out As String
End Class

Public Class GeneralConfiguration
    Public Address As String
    Public WorkersCount As Integer
End Class


