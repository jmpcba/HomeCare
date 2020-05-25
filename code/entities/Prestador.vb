Imports Newtonsoft
Public Class Prestador
    Inherits BaseEntity

    Private _cuit As String
    Private _nombre As String
    Private _apellido As String
    Private _email As String
    Private _especialidad As String
    Private _localidad As String
    Private _montoLV As Decimal
    Private _montoFer As Decimal
    Private _montoFijo As Decimal
    Private _montoDiferencial As Decimal
    Private _baja As Boolean
    Private _obraSocial As String
    Private _estado As Integer
    Private _observaciones As String
    Private _zona As Integer
    Private _id As String

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(_cuit As String, _nombre As String, _apellido As String, _email As String, _especialidad As String, _localidad As String, _montoLV As Decimal, _montoFer As Decimal, _montoFijo As Decimal, _diferencial As Decimal, _fechaCese As Date, _obraSocial As String, _comentario As String, _zona As Integer)
        MyBase.New()
        Me._cuit = _cuit
        Me._nombre = _nombre
        Me._apellido = _apellido
        Me._email = _email
        Me._especialidad = _especialidad
        Me._localidad = _localidad
        Me._obraSocial = _obraSocial
        Me._montoLV = _montoLV
        Me._montoFer = _montoFer
        Me._montoFijo = _montoFijo
        Me._montoDiferencial = _diferencial
        Me._observaciones = _comentario
        Me._zona = _zona
    End Sub

    Public Property id As String
        Set(value As String)
            _id = value
        End Set
        Get
            Return _id
        End Get
    End Property

    Public Property CUIT As String
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
        End Set
        Get
            Return _nombre
        End Get
    End Property

    Public Property apellido As String
        Set(value As String)
            _apellido = value
        End Set
        Get
            Return _apellido
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

    Public Property localidad As String
        Set(value As String)
            _localidad = value
        End Set
        Get
            Return _localidad
        End Get
    End Property

    Public Property mail As String
        Set(value As String)
            _email = value
        End Set
        Get
            Return _email
        End Get
    End Property

    Public Property servicio As String
        Set(value As String)
            _obraSocial = value
        End Set
        Get
            Return _obraSocial
        End Get
    End Property

    Public Property monto_semana As Decimal
        Set(value As Decimal)
            _montoLV = value
        End Set
        Get
            Return _montoLV
        End Get
    End Property

    Public Property monto_feriado As Decimal
        Set(value As Decimal)
            _montoFer = value
        End Set
        Get
            Return _montoFer
        End Get
    End Property

    Public Property monto_fijo As Decimal
        Set(value As Decimal)
            _montoFijo = value
        End Set
        Get
            Return _montoFijo
        End Get
    End Property

    Public Property monto_diferencial As Decimal
        Set(value As Decimal)
            _montoDiferencial = value
        End Set
        Get
            Return _montoDiferencial
        End Get
    End Property

    Public Property baja As Boolean
        Set(value As Boolean)
            _baja = value
        End Set
        Get
            Return _baja
        End Get
    End Property

    Public Property comentario As String
        Set(value As String)
            _observaciones = value
        End Set
        Get
            Return _observaciones
        End Get
    End Property


    Public Property zona As Integer
        Set(value As Integer)
            _zona = value
        End Set
        Get
            Return _zona
        End Get
    End Property
End Class
