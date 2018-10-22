Public Class Modulo
    Private _codigo As Integer
    Private _topeMedico As Integer
    Private _topeEnfermeria As Integer
    Private _topeKinesio As Integer
    Private _topeFono As Integer
    Private _topeCuidador As Integer
    Private _modifUser As Integer
    Private _creoUser As Integer
    Private _fechaCarga As Date
    Private _fechaMod As Date
    Private _modulos As DataTable

    Public Sub New()
        Dim db = New DB()
        Try
            _modulos = db.getTable(DB.tablas.modulo)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Property codigo As Integer
        Set(value As Integer)
            Dim r As DataRow()
            r = _modulos.Select("codigo=" & value)
            _codigo = r(0)("codigo")
            _topeMedico = r(0)("medico")
            _topeEnfermeria = r(0)("enfermeria")
            _topeKinesio = r(0)("kinesio")
            _topeFono = r(0)("fono")
            _topeCuidador = r(0)("cuidador")
            '_modifUser = r(0)("modifico_usuario")
            '_creoUser = r(0)("cargo_usuario")
            '_fechaCarga = r(0)("fecha_carga")
            '_fechaMod = r(0)("fecha_modificacion")
        End Set
        Get
            Return _codigo
        End Get
    End Property

    Public ReadOnly Property tope(_tipo As String) As Integer
        Get
            If _tipo = "MEDICO" Then
                Return _topeMedico
            ElseIf _tipo = "ENFERMERIA" Then
                Return _topeEnfermeria
            ElseIf _tipo = "KINESIO" Then
                Return _topeKinesio
            ElseIf _tipo = "FONO" Then
                Return _topeFono
            ElseIf _tipo = "CUIDADOR" Then
                Return _topeCuidador
            Else
                Return 0
            End If
        End Get
    End Property

End Class
