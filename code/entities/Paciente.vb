Imports Newtonsoft

Public Class Paciente
    Inherits BaseEntity

    Private _afiliado As String
    Private _dni As String
    Private _nombre As String
    Private _apellido As String
    Private _localidad As String
    Private _obraSocial As String
    Private _observaciones As String
    Private _modulo As String
    Private _subModulo As String
    Private _baja As Boolean

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(_afiliado As String, _dni As String, _nombre As String, _apellido As String, _obrasocial As String, _localidad As String, _observaciones As String, _modulo As String, _subModulo As String, _fechaBaja As Date)
        Dim um = New UserManager()
        Me._dni = _dni
        Me._afiliado = _afiliado
        Me._nombre = _nombre
        Me._apellido = _apellido
        Me._obraSocial = _obrasocial
        Me._localidad = _localidad
        Me._observaciones = _observaciones
        Me._subModulo = _subModulo
        Me._modulo = _modulo
    End Sub

    Public Property DNI As String
        Set(value As String)
            _dni = value
        End Set
        Get
            Return _dni
        End Get
    End Property

    Public Property afiliado As String
        Set(value As String)
            _afiliado = value
        End Set
        Get
            Return _afiliado
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

    Public Property obra_social As String
        Set(value As String)
            _obraSocial = value
        End Set
        Get
            Return _obraSocial
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

    Public Property observacion As String
        Set(value As String)
            _observaciones = value
        End Set
        Get
            Return _observaciones
        End Get
    End Property

    Public Property modulo As String
        Set(value As String)
            _modulo = value
        End Set
        Get
            Return _modulo
        End Get
    End Property

    Public Property sub_modulo As String
        Set(value As String)
            _subModulo = value
        End Set
        Get
            Return _subModulo
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
End Class