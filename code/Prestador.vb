Public Class Prestador
    Private _cuit As String
    Private _nombre As String
    Private _apellido As String
    Private _mail As String
    Private _especialidad As String
    Private _localidad As String
    Private _montoLV As Decimal
    Private _montoFer As Decimal
    Private _montoFijo As Decimal
    Private _porcentaje As Decimal
    Private _modifUser As Integer
    Private _creoUser As Integer
    Private _fechaCarga As Date
    Private _fechaMod As Date
    Private _prestadores As DataTable

    Public Property cuit As String
        Set(value As String)
            Dim r As DataRow()
            r = _prestadores.Select("CUIT = '" & value.ToString & "'")

            _cuit = r(0)("cuit")
            _nombre = r(0)("nombre")
            _apellido = r(0)("apellido")
            _mail = r(0)("email")
            _especialidad = r(0)("especialidad")
            _localidad = r(0)("localidad")
            _montoLV = r(0)("monto_semana")
            _montoFer = r(0)("monto_feriado")
            _montoFijo = r(0)("monto_fijo")
            _porcentaje = r(0)("porcentaje")
            _modifUser = r(0)("modifico_usuario")
            _creoUser = r(0)("cargo_usuario")
            _fechaCarga = r(0)("fecha_carga")
            _fechaMod = r(0)("fecha_modificacion")
        End Set
        Get
            Return _cuit
        End Get
    End Property

    Public ReadOnly Property especialidad
        Get
            Return _especialidad
        End Get
    End Property
    Public ReadOnly Property nombre
        Get
            Return _nombre
        End Get
    End Property

    Public ReadOnly Property apellido
        Get
            Return _apellido
        End Get
    End Property

    Public Sub New()
        Dim db = New DB()
        Try
            _prestadores = db.getTable(DB.tablas.prestadores)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public ReadOnly Property montoNormal
        Get
            Return _montoLV
        End Get
    End Property

    Public ReadOnly Property montoFeriado
        Get
            Return _montoFer
        End Get
    End Property

    Public Sub New(_matricula As Integer, _nombre As String, _prestador As String)
        Try
            _matricula = _matricula
            _nombre = _nombre
            _prestador = _prestador
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
