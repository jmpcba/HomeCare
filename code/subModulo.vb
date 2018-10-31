Public Class subModulo

    Private _codigo As Integer
    Private _descripcion As String
    Private _modifUser As Integer
    Private _creoUser As Integer
    Private _fechaCarga As Date
    Private _fechaMod As Date

    Public Sub New(_cod As Integer, _desc As String)
        Dim user As New Usuario

        _codigo = _cod
        _descripcion = _desc
        _modifUser = user.dni
        _creoUser = user.dni
        _fechaCarga = Date.Today
        _fechaMod = Date.Today
    End Sub

    Public Property codigo As Integer
        Set(value As Integer)

        End Set
        Get
            Return _codigo
        End Get
    End Property
    Public ReadOnly Property descripcion As String
        Get
            Return _descripcion
        End Get
    End Property
    Public ReadOnly Property modifUser As Integer
        Get
            Return _modifUser
        End Get
    End Property
    Public ReadOnly Property creoUser As Integer
        Get
            Return _creoUser
        End Get
    End Property
    Public ReadOnly Property fechaCarga As Date
        Get
            Return _fechaCarga
        End Get
    End Property
    Public ReadOnly Property fechaMod As Date
        Get
            Return _fechaMod
        End Get
    End Property

    Public Sub insertar()
        Dim db As New DB
        Try
            db.insertar(Me)
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
