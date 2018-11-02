Public Class subModulo

    Private _codigo As Integer
    Private _descripcion As String
    Private _numTope As Integer
    Private _modifUser As Integer
    Private _creoUser As Integer
    Private _fechaCarga As Date
    Private _fechaMod As Date
    Private _subModulos As DataTable

    Public Sub New(_cod As Integer, _desc As String, _Tope As Integer)
        Dim user As New Usuario

        _codigo = _cod
        _descripcion = _desc
        _numTope = _Tope
        _modifUser = user.dni
        _creoUser = user.dni
        _fechaCarga = Date.Today
        _fechaMod = Date.Today
    End Sub

    Public Sub New()
        Dim db = New DB()
        Try
            _subModulos = db.getTable(DB.tablas.subModulo)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Property codigo As Integer
        Set(value As Integer)
            Dim r As DataRow()
            r = _subModulos.Select("codigo = " & value)
            _codigo = value
            _descripcion = r(0)("descripcion")
            _modifUser = r(0)("modifico_usuario")
            _creoUser = r(0)("cargo_usuario")
            _fechaCarga = r(0)("fecha_carga")
            _fechaMod = r(0)("fecha_modificacion")
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

    Public Sub actualizar()
        Dim db As New DB
        Try
            db.actualizar(Me)
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
