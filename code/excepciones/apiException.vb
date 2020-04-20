Imports System.Net

Public Class apiException
    Inherits WebException

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub
End Class
