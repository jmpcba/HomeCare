Public Class Prestacion
    Private _codigo As Integer
    Private descripcion As String
    Private _creoUser As Integer
    Private _modifUser As Integer
    Private _fechaCarga As Date
    Private _fechaMod As Date
    Private _prestaciones As DataTable

    Public Property codigo As Integer
        Set(value As Integer)
            Dim r As DataRow()
            r = _prestaciones.Select("codigo=" & value)
            _codigo = r(0)("codigo")
            descripcion = r(0)("descripcion")
            _modifUser = r(0)("modifico_usuario")
            _creoUser = r(0)("cargo_usuario")
            _fechaCarga = r(0)("fecha_carga")
            _fechaMod = r(0)("fecha_modificacion")
        End Set
        Get
            Return _codigo
        End Get
    End Property

    Public ReadOnly Property modificoUser
        Get
            Return _modifUser
        End Get
    End Property

    Public ReadOnly Property creoUser
        Get
            Return _creoUser
        End Get
    End Property

    Public ReadOnly Property fechaCarga
        Get
            Return _fechaCarga
        End Get
    End Property

    Public ReadOnly Property fechaModificacion
        Get
            Return _fechaMod
        End Get
    End Property

    Public Sub New()
        Dim db = New DB()
        Try
            _prestaciones = db.getTable(DB.tablas.prestaciones)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Friend Sub insertar()
        Try
            Dim db = New DB()
            db.insertar(Me)
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
