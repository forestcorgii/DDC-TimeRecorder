Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Xml.Serialization
Imports System.Collections
Imports System.IO
Imports System.ComponentModel
Imports Neurotec.Biometrics

Public Class UserRecord
    <XmlAttribute("id")> _
    Public _id As Integer
    <XmlAttribute("name")> _
    Public _name As String

    Public Sub New()
        _id = 0
        _name = String.Empty
    End Sub

    Public Sub New(ByVal id As Integer, ByVal name As String)
        _id = id
        _name = name
    End Sub

    Public ReadOnly Property ID() As Integer
        Get
            Return _id
        End Get
    End Property

    Public ReadOnly Property Name() As String
        Get
            Return _name
        End Get
    End Property
End Class

<XmlRoot("UserDatabase")> _
Public Class UserRecords


    '   Inherits List(Of UserRecord)
    <XmlIgnore> Private _id As String = ""
    <XmlIgnore> Private _fname As String = ""
    <XmlIgnore> Private _lname As String = ""
    <XmlIgnore> Private _mname As String = ""
    <XmlIgnore> Private _empno As String = ""
    <XmlIgnore> Private _dept As String = ""
    <XmlIgnore> Private _co As String = ""
    <XmlIgnore> Private _sched As String
    <XmlIgnore> Private _admin As Boolean = False
    <XmlIgnore> Private _available As Boolean = False

    Public UserRecs As New List(Of UserRecord)
#Region "Public Properties"
    Public Property Available As Boolean
        Get
            If Not File.Exists(Application.StartupPath & "\" & ID & ext.datEx) Then
                Return False
            Else : Return True
            End If
            Return _available
        End Get
        Set(value As Boolean)
            _available = value
        End Set
    End Property
    Public Property Schedule As String
        Get
            Return _sched
        End Get
        Set(value As String)
            _sched = value
        End Set
    End Property

    Public Property ID As String
        Get
            Return _id
        End Get
        Set(value As String)
            _id = value
        End Set
    End Property

    Public Property LastName As String
        Get
            Return _lname
        End Get
        Set(value As String)
            _lname = value
        End Set
    End Property

    Public Property MiddleName As String
        Get
            Return _mname
        End Get
        Set(value As String)
            _mname = value
        End Set
    End Property

    Public Property EmployeeNumber As String
        Get
            Return _empno
        End Get
        Set(value As String)
            _empno = value
        End Set
    End Property

    Public Property Admin As Boolean
        Get
            Return _admin
        End Get
        Set(value As Boolean)
            _admin = value
        End Set
    End Property

    Public Property Company As String
        Get
            Return _co
        End Get
        Set(value As String)
            _co = value
        End Set
    End Property

    Public Property Department As String
        Get
            Return _dept
        End Get
        Set(value As String)
            _dept = value
        End Set
    End Property

    Public Property FirstName As String
        Get
            Return _fname
        End Get
        Set(value As String)
            _fname = value
        End Set
    End Property

    Public ReadOnly Property FullName As String
        Get
            Return String.Format("{0}, {1} {2}.", LastName, FirstName, MI)
        End Get
    End Property

    Public ReadOnly Property MI As String
        Get
            If MiddleName = "" Then Return ""
            Return MiddleName.Substring(0, 1)
        End Get
    End Property

    Public ReadOnly Property Empty As Boolean
        Get
            Return ID = ""
        End Get
    End Property

#End Region

    Public Sub WriteToFile(ByVal filename As String)
        Dim w As TextWriter = Nothing
        Try
            Dim s As New XmlSerializer(GetType(UserRecords))
            w = New StreamWriter(String.Format(Application.StartupPath & "\Employee Records(don't delete)\{0}", filename))
            s.Serialize(w, Me)
            w.Close()
        Catch ex As Exception
            Throw ex
        Finally
            If w IsNot Nothing Then
                w.Close()
                w = Nothing
            End If
        End Try
    End Sub

    Public Shared Function ReadFromFile(ByVal filename As String) As UserRecords
        Dim newUserDb As UserRecords = Nothing
        Dim r As TextReader = Nothing
        Try
            Dim s As New XmlSerializer(GetType(UserRecords))
            r = New StreamReader(String.Format(Application.StartupPath & "\Employee Records(don't delete)\{0}", filename))
            newUserDb = DirectCast(s.Deserialize(r), UserRecords)
        Catch ex As Exception
            Throw ex
        Finally
            r.Close()
        End Try
        Return newUserDb
    End Function

    Public Function Lookup(ByVal id As Integer) As UserRecord
        For Each userRec As UserRecord In Me.UserRecs
            If userRec.ID = id Then
                Return userRec
            End If
        Next
        Return Nothing
    End Function

    Public Overrides Function ToString() As String
        Return _id
    End Function
End Class

Public Class UserDatabase
    Inherits List(Of UserRecords)
    Sub New(find As Boolean)
        Directory.CreateDirectory(String.Format(Application.StartupPath & "\Employee Records(don't delete)\", ""))

        If find Then
            For Each xmlFile As String In Directory.GetFiles(Application.StartupPath & "\Employee Records(don't delete)\", "????.xml")
                Add(UserRecords.ReadFromFile(Path.GetFileNameWithoutExtension(xmlFile) & ext.xmlEx))
            Next
            Sort()
        End If
    End Sub

    Public Function Lookup(id As String) As UserRecords
        Dim userFound As UserRecords = (From res In Me Where res.ID.Equals(id) Take 1 Select res).FirstOrDefault
        Return userFound
    End Function

    Public Overloads Sub Sort()
        Dim tmp As New UserDatabase(False)
        tmp.AddRange(Me)
        Me.Clear()
        Me.AddRange((From res As UserRecords In tmp Select res Order By res.FullName Ascending).ToList)
    End Sub
End Class


Public Class CData
    Implements IDisposable
    Private _engineUser As NffvUser
    Private _image As Bitmap
    Private _name As String

    Public Sub New(ByVal engineUser As NffvUser, ByVal name As String)
        _engineUser = engineUser
        _image = engineUser.GetBitmap()
        _name = name
    End Sub

    Public ReadOnly Property EngineUser() As NffvUser
        Get
            Return _engineUser
        End Get
    End Property

    Public ReadOnly Property Image() As Bitmap
        Get
            Return _image
        End Get
    End Property

    Public ReadOnly Property ID() As Integer
        Get
            Return _engineUser.Id
        End Get
    End Property

    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Public Overrides Function ToString() As String
        Return Name
    End Function
#Region "IDisposable Members"

    Public Sub Dispose() Implements IDisposable.Dispose
        If _image IsNot Nothing Then
            _image.Dispose()
            _image = Nothing
        End If
    End Sub

#End Region
End Class