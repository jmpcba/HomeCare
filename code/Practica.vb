Imports System
Public Class Practica
    Public prestador As Prestador
    Public paciente As Paciente
    Public modulo As Integer
    Public subModulo As Integer
    Public hsSemana As Decimal
    Public hsFeriado As Decimal
    Public hsDif As Decimal
    Public fecha As Date
    Public fecha_registrado As Date
    Public observaciones As String
    Public observacionPre As String
    Public observacionPac As String
    Public creoUser As Integer
    Public modifUser As Integer
    Public fechaCarga As Date
    Public fechaMod As Date
    Public fila As Integer
    Dim util As New utils

    Public Sub New()
        'CONTRSUCTOR VACIO PARA USAR GETPRACTICAS
    End Sub


    Public Sub New(_prestador As Prestador, _paciente As Paciente, _modulo As Integer, _subModulo As Integer, _fecha As Date, _horasLaV As Decimal, _horasFer As Decimal, _horasDif As Decimal, _observacionPre As String, _observacionPac As String, _observaciones As String, _fila As Integer)

        prestador = _prestador
        paciente = _paciente
        modulo = _modulo
        subModulo = _subModulo
        fecha = _fecha
        fecha_registrado = Date.Today.Date
        observaciones = _observaciones
        observacionPac = _observacionPac
        observacionPre = _observacionPre
        hsSemana = _horasLaV
        hsFeriado = _horasFer
        hsDif = _horasDif
        creoUser = My.Settings.dni
        modifUser = My.Settings.dni
        fechaCarga = Today.ToShortDateString
        fechaMod = Today.ToShortDateString
        fila = _fila
    End Sub

    Public Sub insertar()
        Try
            observaciones = observaciones.Replace("'", " ")
            observacionPac = observacionPac.Replace("'", " ")
            observacionPre = observacionPre.Replace("'", " ")
            Dim db = New DB()
            db.insertar(Me)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function getPracticas(_mes As Date) As DataTable
        Dim db As New DB
        Try
            Return db.getPracticas(_mes)
        Catch ex As Exception
            Throw
        End Try
    End Function
End Class
