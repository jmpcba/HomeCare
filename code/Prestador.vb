Public Class Prestador

    Private _user As Usuario
    Private _prestadores As DataTable

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
    Private _fechaCese As Date
    Private _modifUser As Integer
    Private _creoUser As Integer
    Private _fechaCarga As Date
    Private _fechaMod As Date
    Private _modificado = False

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
            '    _fechaCese = r(0)("fecha_cese")
            _modifUser = r(0)("modifico_usuario")
            _creoUser = r(0)("cargo_usuario")
            _fechaCarga = r(0)("fecha_carga")
            _fechaMod = r(0)("fecha_modificacion")
        End Set
        Get
            Return _cuit
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

    Public Sub New(_cuit As String, _nombre As String, _apellido As String, _mail As String, _especialidad As String, _localidad As String, _montoLV As Integer, _montoFer As Integer, _montoFijo As Integer, _porcentaje As Integer, _fechaCese As Date)
        Try
            _user = New Usuario
            Me._cuit = _cuit
            Me._nombre = _nombre
            Me._apellido = _apellido
            Me._mail = _mail
            Me._especialidad = _especialidad
            Me._localidad = _localidad
            Me._montoLV = _montoLV
            Me._montoFer = _montoFer
            Me._montoFijo = _montoFijo
            Me._porcentaje = _porcentaje
            Me._fechaCese = _fechaCese
            Me._modifUser = _user.dni
            Me._creoUser = _user.dni
            Me._fechaCarga = Date.Today
            Me._fechaMod = Date.Today
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Property nombre As String
        Set(value As String)
            _nombre = value
            _modificado = True
        End Set
        Get
            Return _nombre
        End Get
    End Property

    Public Property apellido As String
        Set(value As String)
            _apellido = value
            _modificado = True
        End Set
        Get
            Return _apellido
        End Get
    End Property

    Public Property especialidad As String
        Set(value As String)
            _especialidad = value
            _modificado = True
        End Set
        Get
            Return _especialidad
        End Get
    End Property

    Public Property localidad As String
        Set(value As String)
            _localidad = value
            _modificado = True
        End Set
        Get
            Return _localidad
        End Get
    End Property

    Public Property mail As String
        Set(value As String)
            _mail = value
            _modificado = True
        End Set
        Get
            Return _mail
        End Get
    End Property

    Public Property montoNormal As Integer
        Set(value As Integer)
            _montoLV = value
            _modificado = True
        End Set
        Get
            Return _montoLV
        End Get
    End Property

    Public Property montoFeriado As Integer
        Set(value As Integer)
            _montoFer = value
            _modificado = True
        End Set
        Get
            Return _montoFer
        End Get
    End Property

    Public Property montoFijo As Integer
        Set(value As Integer)
            _montoFijo = value
            _modificado = True
        End Set
        Get
            Return _montoFijo
        End Get
    End Property

    Public Property porcentaje As Integer
        Set(value As Integer)
            _porcentaje = value
            _modificado = True
        End Set
        Get
            Return _porcentaje
        End Get
    End Property

    Public Property fechaCese As Date
        Set(value As Date)
            _fechaCese = value
            _modificado = True
        End Set
        Get
            Return _fechaCese
        End Get
    End Property

    Public Sub insertar()
        Try
            Dim db = New DB
            db.insertar(Me)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub actualizar()
        Dim db = New DB
        Try
            If _modificado Then
                _fechaMod = Date.Today
                _modifUser = _user.dni
                db.actualizar(Me)
            Else
                Throw New Exception("No se realizaron modificaciones")
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class
