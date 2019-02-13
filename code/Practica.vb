Imports System
Public Class Practica
    Public prestador As Prestador
    Public paciente As Paciente
    'Public prestacion As Prestacion
    Public modulo As Integer
    Public subModulo As Integer
    Public hsSemana As Decimal
    Public hsFeriado As Decimal
    Public hsDif As Decimal
    Public fecha As Date
    Public fecha_registrado As Date
    Public observaciones As String
    Public creoUser As Integer
    Public modifUser As Integer
    Public fechaCarga As Date
    Public fechaMod As Date
    Public fila As Integer
    Dim util As New utils

    Public Sub New()
        'CONTRSUCTOR VACIO PARA USAR GETPRACTICAS
    End Sub


    Public Sub New(_prestador As Prestador, _paciente As Paciente, _modulo As Integer, _subModulo As Integer, _fecha As Date, _horas As Decimal, _horasDif As Decimal, _observaciones As String, _fila As Integer)

        prestador = _prestador
        paciente = _paciente
        modulo = _modulo
        subModulo = _subModulo
        fecha = _fecha
        fecha_registrado = Date.Today.Date
        observaciones = _observaciones
        calcularHoras(_horas)
        creoUser = My.Settings.dni
        modifUser = My.Settings.dni
        fechaCarga = Today.ToShortDateString
        fechaMod = Today.ToShortDateString
        hsDif = _horasDif
        fila = _fila
    End Sub


    Private Sub calcularHoras(_horas As Decimal)
        If util.esFindeOFeriado(fecha) Then
            hsFeriado = _horas
            hsSemana = 0
        Else
            hsFeriado = 0
            hsSemana = _horas
        End If
    End Sub

    Public Sub insertar()
        Try
            observaciones = observaciones.Replace("'", " ")
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
