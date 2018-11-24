Public Class Liquidacion
    Private _prestador As Prestador
    Private _cuit As String
    Private _localidad As String
    Private _especialidad As String
    Private _mes As Date
    Private _hsNormales As Decimal
    Private _hsFeriado As Decimal
    Private _importeFeriado As Decimal
    Private _importeNormal As Decimal
    Private _montoFijo As Decimal
    Private _modifUser As Integer
    Private _creoUser As Integer
    Private _fechaCarga As Date
    Private _fechaMod As Date
    Private _modificado = False
    Private _observaciones As String
    Private _user As Usuario

    Public Sub New(_prestador As Prestador, _cuit As String, _localidad As String, _especialidad As String, _mes As Date, _hsNormales As Decimal, _hsFeriado As Decimal, _importeNormal As Decimal, _importeFeriado As Decimal, _montoFijo As Decimal, _observaciones As String)
        _user = New Usuario

        Me._prestador = _prestador
        Me._cuit = _cuit
        Me._localidad = _localidad
        Me._especialidad = _especialidad
        Me._mes = _mes
        Me._hsNormales = _hsNormales
        Me._hsFeriado = _hsFeriado
        Me._importeFeriado = _importeFeriado
        Me._importeNormal = _importeNormal
        Me._montoFijo = _montoFijo
        Me._observaciones = _observaciones
        _modifUser = _user.dni
        _creoUser = _user.dni
        _fechaCarga = Date.Today
        _fechaMod = Date.Today
    End Sub

    Public Property cuit As String
        Set(value As String)
            _cuit = value
        End Set
        Get
            Return _cuit
        End Get
    End Property

    Public Property localidad As String
        Set(value As String)
            _localidad = value
        End Set
        Get
            Return _localidad
        End Get
    End Property

    Public Property especialidad As String
        Set(value As String)
            _especialidad = value
        End Set
        Get
            Return _especialidad
        End Get
    End Property
    Public Property mes As Date
        Set(value As Date)
            _mes = value
        End Set
        Get
            Return _mes
        End Get
    End Property

    Public Property hsNormales As Decimal
        Set(value As Decimal)
            _hsNormales = value
        End Set
        Get
            Return _hsNormales
        End Get
    End Property

    Public Property hsFeriado As Decimal
        Set(value As Decimal)
            _hsFeriado = value
        End Set
        Get
            Return _hsFeriado
        End Get
    End Property

    Public Property importeNormal As Decimal
        Set(value As Decimal)
            _importeNormal = value
        End Set
        Get
            Return _importeNormal
        End Get
    End Property

    Public Property importeFeriado As Decimal
        Set(value As Decimal)
            _importeFeriado = value
        End Set
        Get
            Return _importeFeriado
        End Get
    End Property

    Public Property montoFijo As Decimal
        Set(value As Decimal)
            _montoFijo = value
        End Set
        Get
            Return _montoFijo
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

    Public ReadOnly Property idPrestador As Integer
        Get
            Return _prestador.id
        End Get
    End Property

    Public ReadOnly Property prestador As Prestador
        Get
            Return _prestador
        End Get
    End Property

    Public ReadOnly Property observaciones As String
        Get
            Return _observaciones
        End Get
    End Property

    Public Sub insertar()
        Try
            Dim db As New DB
            db.insertar(Me)
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Friend Sub liquidar()
        Try
            If _prestador.email = "" Or IsDBNull(_prestador.email) Then
                Throw New Exception("No hay un mail configurado para este prestador." & vbCrLf & "Ingrese un mail en la seccion ADMINISTRAR PRESTADORES")
            End If
            insertar()
            notificar()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub notificar()
        Try
            Dim mail As New Mail
            mail.send(Me)
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
