Imports Newtonsoft
Public Class Zona
    Inherits BaseEntity

    Private _nombre As String
    Private _email As String
    Private _pass As String
    Private _propietario As String
    Private _modificado = False

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(_nombre As String, _email As String, _pass As String, _propietario As String)
        MyBase.New()
        Me._nombre = _nombre
        Me._email = _email
        Me._pass = _pass
        Me._propietario = _propietario
    End Sub

    Public Property mail As String
        Set(value As String)
            _email = value
            _modificado = True
        End Set
        Get
            Return _email
        End Get
    End Property
    Public Property pwd As String
        Set(value As String)
            _pass = value
            _modificado = True
        End Set

        Get
            Return _pass
        End Get
    End Property

    Public Property nombre As String
        Set(value As String)
            _nombre = value
            _modificado = True
        End Set
        Get
            Return _nombre
        End Get
    End Property

    Public Property propietario As String
        Set(value As String)
            _propietario = value
            _modificado = True
        End Set
        Get
            Return _propietario
        End Get
    End Property
End Class

