Imports Newtonsoft

Public Class Modulo
    Inherits BaseEntity

    Private _codigo As String
    Private _topeMedico As Integer
    Private _topeEnfermeria As Integer
    Private _topeKinesio As Integer
    Private _topeFono As Integer
    Private _topeCuidador As Integer
    Private _topeNutricionista As Integer


    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(_cod As String, _topeMedico As Integer, _topeEnfer As Integer, _topeKine As Integer, _topeFon As Integer, _topeCuid As Integer, _topeNutri As Integer)
        MyBase.New()
        Me._codigo = _cod
        Me._topeMedico = _topeMedico
        Me._topeEnfermeria = _topeEnfer
        Me._topeKinesio = _topeKine
        Me._topeFono = _topeFon
        Me._topeCuidador = _topeCuid
        Me._topeNutricionista = _topeNutri
    End Sub

    Public Property codigo As String
        Get
            Return _codigo
        End Get
        Set(value As String)
            _codigo = value
        End Set
    End Property

    Public ReadOnly Property tope(_tipo As String) As Integer
        Get
            If _tipo.ToUpper.Contains("MEDICO") Then
                Return _topeMedico
            ElseIf _tipo.ToUpper.Contains("ENF") Then
                Return _topeEnfermeria
            ElseIf _tipo.ToUpper.Contains("KINES") Then
                Return _topeKinesio
            ElseIf _tipo.ToUpper.Contains("FONOAUDIOLOGIA") Then
                Return _topeFono
            ElseIf _tipo.ToUpper.Contains("CD") Then
                Return _topeCuidador
            ElseIf _tipo.ToUpper.Contains("NUTRICION") Then
                Return _topeNutricionista
            Else
                Return 0
            End If
        End Get
    End Property

    Public Property medico As Integer
        Set(value As Integer)
            _topeMedico = value
        End Set
        Get
            Return _topeMedico
        End Get
    End Property
    Public Property enfermeria As Integer
        Set(value As Integer)
            _topeEnfermeria = value
        End Set
        Get
            Return _topeEnfermeria
        End Get
    End Property
    Public Property kinesiologia As Integer
        Set(value As Integer)
            _topeKinesio = value
        End Set
        Get
            Return _topeKinesio
        End Get
    End Property
    Public Property fonoaudiologia As Integer
        Set(value As Integer)
            _topeFono = value
        End Set
        Get
            Return _topeFono
        End Get
    End Property
    Public Property cuidador As Integer
        Set(value As Integer)
            _topeCuidador = value
        End Set
        Get
            Return _topeCuidador
        End Get
    End Property

    Public Property nutricion As Integer
        Set(value As Integer)
            _topeNutricionista = value
        End Set
        Get
            Return _topeNutricionista
        End Get
    End Property
End Class
