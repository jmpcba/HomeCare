Public Class Modulo
    Private _codigo As Integer
    Private _numero As Integer
    Private _tope As Integer
    Private _descripcion As String
    Private _modifUser As Integer
    Private _creoUser As Integer
    Private _fechaCarga As Date
    Private _fechaMod As Date
    Private _modulos As DataTable

    Public Sub New()
        Dim db = New DB()
        Try
            _modulos = db.getTable(DB.tablas.modulos)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Property codigo As Integer
        Set(value As Integer)
            Dim r As DataRow()
            r = _modulos.Select("codigo=" & value)
            _codigo = r(0)("codigo")
            _numero = r(0)("numero")
            _tope = r(0)("tope")
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

End Class
