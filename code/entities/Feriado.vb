
Public Class Feriado
    Inherits BaseEntity

    Private _fecha As Date
    Private _descripcion As String
    Private _ultima_modificacion As Date
    Private _usuario_ultima_modificacion As String
    Public Sub New(_fecha As Date, _descr As String)
        MyBase.New()
        Me._fecha = _fecha
        Me._descripcion = _descr
    End Sub

    Public Property fecha As Date
        Set(value As Date)
            _fecha = value
        End Set
        Get
            Return _fecha
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
