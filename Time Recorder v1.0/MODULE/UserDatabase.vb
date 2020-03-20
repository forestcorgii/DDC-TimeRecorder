Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Xml.Serialization
Imports System.Collections
Imports System.IO

Namespace VBNETSample
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
	Public Class UserDatabase
		Inherits List(Of UserRecord)
		Public Sub WriteToFile(ByVal filename As String)
			Dim w As TextWriter = Nothing
			Try
				Dim s As New XmlSerializer(GetType(UserDatabase))
				w = New StreamWriter(filename)
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

		Public Shared Function ReadFromFile(ByVal filename As String) As UserDatabase
			Dim newUserDb As UserDatabase = Nothing
			Dim r As TextReader = Nothing
			Try
				Dim s As New XmlSerializer(GetType(UserDatabase))
				r = New StreamReader(filename)
				newUserDb = DirectCast(s.Deserialize(r), UserDatabase)
			Catch ex As Exception
				Throw ex
			Finally
				r.Close()
			End Try

			Return newUserDb
		End Function

		Public Function Lookup(ByVal id As Integer) As UserRecord
			For Each userRec As UserRecord In Me
				If userRec.ID = id Then
					Return userRec
				End If
			Next

			Return Nothing
		End Function
	End Class
End Namespace
