Public Class Liquidacion
    Private _cuit As String
    Private _localidad As String
    Private _especialidad As String
    Private _mes As Date
    Private _hsNormales As Decimal
    Private _hsFeriado As Decimal
    Private _importeFeriado As Decimal
    Private _importeNormal As Decimal

    Public Sub New(_cuit As String, _localidad As String, _especialidad As String, _mes As Date, _hsNormales As Decimal, _hsFeriado As Decimal, _importeNormal As Decimal, _importeFeriado As Decimal)
        Me._cuit = _cuit
        Me._localidad = _localidad
        Me._especialidad = _especialidad
        Me._mes = _mes
        Me._hsNormales = _hsNormales
        Me._hsFeriado = _hsFeriado
        Me._importeFeriado = _importeFeriado
        Me._importeNormal = _importeNormal
    End Sub

    Public Property cuit As String
        Set(value As String)
            Me._cuit = value
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
            Return _importeFeriado
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

    Public Sub insertar()
        Dim db As New DB
        db.insertar(Me)
    End Sub
End Class
