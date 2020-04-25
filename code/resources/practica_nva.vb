Public Class practica_nva
    Inherits Resource
    Private _cuit As String
    Private _afiliado As Integer
    Private _modulo As Integer
    Private _subModulo As Integer
    Private _hsSemana As Decimal
    Private _hsFeriado As Decimal
    Private _hsDif As Decimal
    Private _fecha As Date
    Private _observaciones As String
    Private _observacionPre As String
    Private _observacionPac As String
    Private _id_prestador As Integer

    Public Sub New(_prestador As Prestador, _paciente As Paciente, _modulo As Integer, _subModulo As Integer, _fecha As Date, _horasLaV As Decimal, _horasFer As Decimal, _horasDif As Decimal, _observacionPre As String, _observacionPac As String, _observaciones As String)
        MyBase.New()
        Me._id_prestador = _prestador.id
        Me._afiliado = _paciente.id
        Me._modulo = _modulo
        Me._subModulo = _subModulo
        Me._fecha = _fecha
        Me._observaciones = _observaciones
        Me._observacionPac = _observacionPac
        Me._observacionPre = _observacionPre
        Me._hsSemana = _horasLaV
        Me._hsFeriado = _horasFer
        Me._hsDif = _horasDif
    End Sub

    Public Property cuit As String
        Get
            Return _cuit
        End Get
        Set(value As String)
            _cuit = value
        End Set
    End Property

    Public Property afiliado
        Set(value)
            _afiliado = value
        End Set
        Get
            Return _afiliado
        End Get
    End Property

    Public Property modulo As Integer
        Set(value As Integer)
            _modulo = value
        End Set
        Get
            Return _modulo
        End Get
    End Property

    Public Property sub_modulo As Integer
        Set(value As Integer)
            _subModulo = value
        End Set
        Get
            Return _subModulo
        End Get
    End Property

    Public Property id_prest As Integer
        Set(value As Integer)
            _id_prestador = value
        End Set
        Get
            Return _id_prestador
        End Get
    End Property

    Public Property hs_normales As Decimal
        Set(value As Decimal)
            _hsSemana = value
        End Set
        Get
            Return _hsSemana
        End Get
    End Property

    Public Property hs_feriado As Decimal
        Set(value As Decimal)
            _hsFeriado = value
        End Set
        Get
            Return _hsFeriado
        End Get
    End Property

    Public Property hs_diferencial As Decimal
        Set(value As Decimal)
            _hsDif = value
        End Set
        Get
            Return _hsDif
        End Get
    End Property

    Public Property fecha As Date
        Set(value As Date)
            _fecha = value
        End Set
        Get
            Return _fecha
        End Get
    End Property

    Public Property observaciones As String
        Set(value As String)
            _observaciones = value
        End Set
        Get
            Return _observaciones
        End Get
    End Property

    Public Property observaciones_paciente As String
        Set(value As String)
            _observacionPac = value
        End Set
        Get
            Return _observacionPac
        End Get
    End Property

    Public Property observaciones_prestacion As String
        Set(value As String)
            _observacionPre = value
        End Set
        Get
            Return _observacionPre
        End Get
    End Property
End Class

