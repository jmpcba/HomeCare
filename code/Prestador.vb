﻿Imports Newtonsoft
Public Class Prestador

    Private _prestadores As DataTable
    Private _id As String
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
    Private _creoUser As String
    Private _modifUser As String
    Private _fechaCarga As Date
    Private _fechaMod As Date
    Private _modificado = False
    Private _obraSocial As String
    Private _estado As Integer
    Private _observaciones As String
    Private _zona As Integer

    Public Sub New()
        Dim api As New API(API.resources.PRESTADOR)
        Try
            _prestadores = api.get_table()
            _prestadores.Columns.Add("COMBO").SetOrdinal(0)
            For Each r As DataRow In _prestadores.Rows
                Dim nombre = r("nombre")
                Dim apellido = r("apellido")
                Dim especialidad = r("especialidad")
                Dim localidad = r("localidad")
                Dim servicio = r("servicio")
                r("COMBO") = String.Format("{0} {1} - {2} - {3} - {4}", apellido, nombre, localidad, especialidad, servicio)
            Next
            _prestadores.DefaultView.Sort = "COMBO"
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub New(_cuit As String, _nombre As String, _apellido As String, _email As String, _especialidad As String, _localidad As String, _montoLV As Decimal, _montoFer As Decimal, _montoFijo As Decimal, _diferencial As Decimal, _fechaCese As Date, _obraSocial As String, _comentario As String, _zona As Integer)

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
        Me._modifUser = My.Settings.dni
        Me._creoUser = My.Settings.dni
        Me._fechaCarga = Date.Today
        Me._fechaMod = Date.Today
        Me._zona = _zona
    End Sub

    Public Property id As String
        Set(value As String)
            Dim r As DataRow()
            r = _prestadores.Select("ID = '" & value.ToString & "'")

            If r.Length = 1 Then
                _id = value
                _cuit = r(0)("cuit")
                _nombre = r(0)("nombre")
                _apellido = r(0)("apellido")

                If IsDBNull(r(0)("mail")) Then
                    _email = ""
                Else
                    _email = r(0)("mail")
                End If

                _especialidad = r(0)("especialidad")
                _localidad = r(0)("localidad")

                If IsDBNull(r(0)("servicio")) Then
                    _obraSocial = ""
                Else
                    _obraSocial = r(0)("servicio")
                End If

                _montoLV = r(0)("monto_semana")

                If IsDBNull(r(0)("monto_feriado")) Then
                    _montoFer = 0
                Else
                    _montoFer = r(0)("monto_feriado")
                End If

                If IsDBNull(r(0)("monto_fijo")) Then
                    _montoFijo = 0
                Else
                    _montoFijo = r(0)("monto_fijo")
                End If

                If IsDBNull(r(0)("monto_diferencial")) Then
                    _montoDiferencial = 0
                Else
                    _montoDiferencial = r(0)("monto_diferencial")
                End If

                If IsDBNull(r(0)("comentario")) Then
                    _observaciones = ""
                Else
                    _observaciones = r(0)("comentario")
                End If

                If IsDBNull(r(0)("zona")) Then
                    _zona = 1
                Else
                    _zona = r(0)("zona")
                End If
            Else
                Throw New Exception("No se encontro el prestador")
            End If

        End Set
        Get
            Return _id
        End Get
    End Property

    Friend Sub reactivar()
        Try
            Dim db As New DB
            db.reactivarPrestador(id)
        Catch ex As Exception
            Throw
        End Try
    End Sub

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
            _email = value
            _modificado = True
        End Set
        Get
            Return _email
        End Get
    End Property

    Public Property servicio As String
        Set(value As String)
            _obraSocial = value
            _modificado = True
        End Set
        Get
            Return _obraSocial
        End Get
    End Property

    Public Property monto_semana As Decimal
        Set(value As Decimal)
            _montoLV = value
            _modificado = True
        End Set
        Get
            Return _montoLV
        End Get
    End Property

    Public Property monto_feriado As Decimal
        Set(value As Decimal)
            _montoFer = value
            _modificado = True
        End Set
        Get
            Return _montoFer
        End Get
    End Property

    Public Property monto_fijo As Decimal
        Set(value As Decimal)
            _montoFijo = value
            _modificado = True
        End Set
        Get
            Return _montoFijo
        End Get
    End Property

    Public Property monto_diferencial As Decimal
        Set(value As Decimal)
            _montoDiferencial = value
            _modificado = True
        End Set
        Get
            Return _montoDiferencial
        End Get
    End Property

    Public Property baja As Boolean
        Set(value As Boolean)
            _baja = value
            _modificado = True
        End Set
        Get
            Return _baja
        End Get
    End Property

    Public Property comentario As String
        Set(value As String)
            _observaciones = value
            _modificado = True
        End Set
        Get
            Return _observaciones
        End Get
    End Property

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

    Public Function getPrestadores() As DataTable
        Return _prestadores
    End Function

    Public Property zona As Integer
        Set(value As Integer)
            _zona = value
            _modificado = True
        End Set
        Get
            Return _zona
        End Get
    End Property

    Public Sub insertar()
        'Try
        '    _observaciones = _observaciones.Replace("'", " ")
        '    Dim db = New DB
        '    Dim ut As New utils
        '    Dim r As DataRow()
        '    _prestadores = db.getTable(DB.tablas.prestadores)
        '    r = _prestadores.Select("CUIT = '" & Me.CUIT.ToString & "'")
        '    _prestadores = Nothing

        '    ' SI SE ELIGE LA OPCION NO, LA RUTINA SE TERMINA
        '    If r.Length > 0 Then
        '        If ut.mensaje("Ya existe un prestador con este CUIT" & vbCrLf & "Desea continuar?", utils.mensajes.preg) = MsgBoxResult.No Then
        '            Exit Sub
        '        End If
        '    End If

        '    Dim api As New Backend(Backend.services.prestador)
        '    Me.baja = False
        '    Dim serialObject = Json.JsonConvert.SerializeObject(Me)
        '    api.send_post_put(serialObject, Backend.methods.httpPOST)

        'Catch ex As Exception
        '    Throw
        'End Try
        Try
            Dim api As New API(API.resources.PRESTADOR)
            Me.baja = False
            Dim serialObject = Json.JsonConvert.SerializeObject(Me)
            api.send_post_put(serialObject, API.httpMethods.httpPOST)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub actualizar()
        Try
            If _modificado Then
                Dim api As New API(API.resources.PRESTADOR)
                _prestadores = Nothing
                Dim serialObject = Json.JsonConvert.SerializeObject(Me)
                api.send_post_put(serialObject, API.httpMethods.httpPUT)
            Else
                Throw New Exception("No se realizaron modificaciones")
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub llenarcombo(_combo As ComboBox)
        Dim DV = New DataView(_prestadores)
        DV.RowFilter = "BAJA = FALSE"
        DV.Sort = "APELLIDO ASC"
        _combo.DataSource = DV
        _combo.DisplayMember = "combo"
        _combo.ValueMember = "id"
        _combo.SelectedIndex = -1
    End Sub

    Public Sub refrescar()
        Try
            getPrestadores()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function getModificado() As Boolean
        Return _modificado
    End Function
End Class
