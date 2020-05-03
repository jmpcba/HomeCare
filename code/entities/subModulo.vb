Imports Newtonsoft

Public Class subModulo
    Inherits BaseEntity
    Private _codigo As String
    Private _descripcion As String
    Private _numTope As Integer


    Public Sub New(_cod As String, _desc As String)
        MyBase.New()
        _codigo = _cod
        _descripcion = _desc
    End Sub

    Public Sub New()
        MyBase.New
    End Sub

    Public Property codigo
        Set(value)
            _codigo = value
        End Set
        Get
            Return _codigo
        End Get
    End Property

    Public Property descripcion As String
        Set(value As String)
            _descripcion = value
        End Set
        Get
            Return _descripcion
        End Get
    End Property
End Class