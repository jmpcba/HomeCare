Public Class Prestador

    Private _user As Usuario
    Private _prestadores As DataTable
    Private _clave As String
    Private _cuit As String
    Private _nombre As String
    Private _apellido As String
    Private _email As String
    Private _especialidad As String
    Private _localidad As String
    Private _montoLV As Decimal
    Private _montoFer As Decimal
    Private _montoFijo As Decimal
    Private _porcentaje As Decimal
    Private _fechaCese As Date
    Private _creoUser As String
    Private _modifUser As String
    Private _fechaCarga As Date
    Private _fechaMod As Date
    Private _modificado = False

    Public Sub New()
        Dim db = New DB()
        Try
            _prestadores = db.getTable(DB.tablas.prestadores)
            _prestadores.Columns.Add("COMBO")
            For Each r As DataRow In _prestadores.Rows
                Dim nombre = r("nombre")
                Dim apellido = r("apellido")
                Dim especialidad = r("especialidad")
                Dim localidad = r("localidad")
                r("COMBO") = String.Format("{0} {1} - {2} - {3}", apellido, nombre, localidad, especialidad)
            Next
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub New(_cuit As String, _nombre As String, _apellido As String, _mail As String, _especialidad As String, _localidad As String, _montoLV As Decimal, _montoFer As Decimal, _montoFijo As Decimal, _porcentaje As Decimal, _fechaCese As Date)
        Try
            _user = New Usuario
            Me._cuit = _cuit
            Me._nombre = _nombre
            Me._apellido = _apellido
            Me._email = _email
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

    Public Property clave As String
        Set(value As String)
            Dim r As DataRow()
            r = _prestadores.Select("CLAVE = '" & value.ToString & "'")
            _clave = value
            _cuit = r(0)("cuit")
            _nombre = r(0)("nombre")
            _apellido = r(0)("apellido")
            _email = r(0)("email")
            _especialidad = r(0)("especialidad")
            _localidad = r(0)("localidad")
            _montoLV = r(0)("monto_semana")
            _montoFer = r(0)("monto_feriado")
            _montoFijo = r(0)("monto_fijo")
            _porcentaje = r(0)("porcentaje")
            If Not IsDBNull(r(0)("fecha_cese")) Then
                _fechaCese = r(0)("fecha_cese")
            End If

            _modifUser = r(0)("modifico_usuario")
            _creoUser = r(0)("cargo_usuario")
            _fechaCarga = r(0)("fecha_carga")
            _fechaMod = r(0)("fecha_modificacion")
        End Set
        Get
            Return _clave
        End Get
    End Property

    Public Property cuit As String
        Set(value As String)
            _cuit = value
        End Set
        Get
            Return _cuit
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

    Public Property email As String
        Set(value As String)
            _email = value
            _modificado = True
        End Set
        Get
            Return _email
        End Get
    End Property

    Public Property montoNormal As Decimal
        Set(value As Decimal)
            _montoLV = value
            _modificado = True
        End Set
        Get
            Return _montoLV
        End Get
    End Property

    Public Property montoFeriado As Decimal
        Set(value As Decimal)
            _montoFer = value
            _modificado = True
        End Set
        Get
            Return _montoFer
        End Get
    End Property

    Public Property montoFijo As Decimal
        Set(value As Decimal)
            _montoFijo = value
            _modificado = True
        End Set
        Get
            Return _montoFijo
        End Get
    End Property

    Public Property porcentaje As Decimal
        Set(value As Decimal)
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

    Public Sub llenarcombo(_combo As ComboBox)

        _combo.DataSource = _prestadores
        _combo.DisplayMember = "combo"
        _combo.ValueMember = "clave"
        _combo.SelectedIndex = -1

    End Sub
End Class
