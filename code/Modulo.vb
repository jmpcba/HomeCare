Imports Newtonsoft

Public Class Modulo
    Private _id As Integer
    Private _codigo As String
    Private _topeMedico As Integer
    Private _topeEnfermeria As Integer
    Private _topeKinesio As Integer
    Private _topeFono As Integer
    Private _topeCuidador As Integer
    Private _topeNutricionista As Integer
    Private _modifUser As Integer
    Private _creoUser As Integer
    Private _fechaCarga As Date
    Private _fechaMod As Date
    Private _modificado = False
    Private _modulos As DataTable

    Public Sub New()
        Try
            Dim api As New API(API.resources.MODULO)
            _modulos = api.get_table()
            Dim c = _modulos.Columns.Count
            _modulos.Columns("ultima_modificacion").SetOrdinal(c - 1)
            _modulos.Columns("usuario_ultima_modificacion").SetOrdinal(c - 2)
            _modulos.Columns("codigo").SetOrdinal(1)
            _modulos.Columns("id").SetOrdinal(0)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub New(_cod As String, _topeMedico As Integer, _topeEnfer As Integer, _topeKine As Integer, _topeFon As Integer, _topeCuid As Integer, _topeNutri As Integer)

        Me._codigo = _cod
        Me._topeMedico = _topeMedico
        Me._topeEnfermeria = _topeEnfer
        Me._topeKinesio = _topeKine
        Me._topeFono = _topeFon
        Me._topeCuidador = _topeCuid
        Me._topeNutricionista = _topeNutri
        Me._modifUser = My.Settings.userName
        Me._creoUser = My.Settings.dni
        Me._fechaCarga = Date.Today
        Me._fechaMod = Date.Today
    End Sub

    Public Property id As String
        Set(value As String)
            Dim r As DataRow()
            r = _modulos.Select("id=" & value)
            If r.Length = 1 Then
                _id = value
                _codigo = r(0)("codigo")
                _topeMedico = r(0)("medico")
                _topeEnfermeria = r(0)("enfermeria")
                _topeKinesio = r(0)("kinesiologia")
                _topeFono = r(0)("fonoaudiologia")
                _topeCuidador = r(0)("cuidador")
                _topeNutricionista = r(0)("nutricion")
                _modifUser = r(0)("usuario_ultima_modificacion")
                _fechaMod = r(0)("ultima_modificacion")
            Else
                Throw New Exception("Codigo Inexistente")
            End If
        End Set
        Get
            Return _id
        End Get
    End Property

    Public Property codigo As String
        Get
            Return _codigo
        End Get
        Set(value As String)
            _codigo = value
        End Set
    End Property

    Friend Sub llenarcombo(_combo As ComboBox)
        _combo.DataSource = _modulos
        _combo.DisplayMember = "codigo"
        _combo.ValueMember = "id"
        _combo.SelectedIndex = -1
    End Sub

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
            _modificado = True
        End Set
        Get
            Return _topeMedico
        End Get
    End Property
    Public Property enfermeria As Integer
        Set(value As Integer)
            _topeEnfermeria = value
            _modificado = True
        End Set
        Get
            Return _topeEnfermeria
        End Get
    End Property
    Public Property kinesiologia As Integer
        Set(value As Integer)
            _topeKinesio = value
            _modificado = True
        End Set
        Get
            Return _topeKinesio
        End Get
    End Property
    Public Property fonoaudiologia As Integer
        Set(value As Integer)
            _topeFono = value
            _modificado = True
        End Set
        Get
            Return _topeFono
        End Get
    End Property
    Public Property cuidador As Integer
        Set(value As Integer)
            _topeCuidador = value
            _modificado = True
        End Set
        Get
            Return _topeCuidador
        End Get
    End Property

    Public Property nutricion As Integer
        Set(value As Integer)
            _topeNutricionista = value
            _modificado = True
        End Set
        Get
            Return _topeNutricionista
        End Get
    End Property

    Public Sub actualizar()
        Try
            If _modificado Then
                Dim api As New API(API.resources.MODULO)
                _modulos = Nothing
                Dim serialObject = Json.JsonConvert.SerializeObject(Me)
                api.send_post_put(serialObject, API.httpMethods.httpPUT)
            Else
                Throw New Exception("No se realizaron modificaciones")
            End If

        Catch ex As apiException
            Throw
        End Try
    End Sub

    Public Sub insertar()
        Try
            Dim api As New API(API.resources.MODULO)
            _modulos = Nothing
            Dim serialObject = Json.JsonConvert.SerializeObject(Me)
            api.send_post_put(serialObject, API.httpMethods.httpPOST)
        Catch ex As apiException
            Throw
        End Try
    End Sub

    Public ReadOnly Property usuario_ultima_modificacion As Integer
        Get
            Return _modifUser
        End Get
    End Property

    Public ReadOnly Property ultima_modificacion As Date
        Get
            Return _fechaMod
        End Get
    End Property

    Public Function getModulos() As DataTable
        Return _modulos
    End Function
End Class
