Public Class Liquidacion
    Private _prestador As Prestador
    Private _mes As Date
    Private _hsNormales As Decimal
    Private _hsFeriado As Decimal
    Private _hsDiferencial As Decimal
    Private _importeFeriado As Decimal
    Private _importeNormal As Decimal
    Private _montoFijo As Decimal
    Private _importeDiferencial As Decimal
    Private _modifUser As Integer
    Private _creoUser As Integer
    Private _fechaCarga As Date
    Private _fechaMod As Date
    Private _modificado = False
    Private _observaciones As String


    Public Sub New(_prestador As Prestador, _mes As Date, _hsNormales As Decimal, _hsFeriado As Decimal, _hsDiferencial As Decimal, _importeNormal As Decimal, _importeFeriado As Decimal, _importeDiferencial As Decimal, _montoFijo As Decimal, _observaciones As String)

        Me._prestador = _prestador
        Me._mes = _mes
        Me._hsNormales = _hsNormales
        Me._hsFeriado = _hsFeriado
        Me._hsDiferencial = _hsDiferencial
        Me._importeFeriado = _importeFeriado
        Me._importeNormal = _importeNormal
        Me._importeDiferencial = _importeDiferencial
        Me._montoFijo = _montoFijo
        Me._observaciones = _observaciones
        _modifUser = My.Settings.dni
        _creoUser = My.Settings.dni
        _fechaCarga = Date.Today
        _fechaMod = Date.Today
    End Sub

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

    Public Property importeDiferencial As Decimal
        Set(value As Decimal)
            _importeDiferencial = value
        End Set
        Get
            Return _importeDiferencial
        End Get
    End Property

    Public Property hsDiferencial As Decimal
        Set(value As Decimal)
            _hsDiferencial = value
        End Set
        Get
            Return _hsDiferencial
        End Get
    End Property

    Public Sub insertar()
        Try
            _observaciones = _observaciones.Replace("'", " ")
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

    Public Sub notificar()
        Try
            Dim mail As New Mail
            mail.send(Me)
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
