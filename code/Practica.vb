Imports System
Public Class Practica
    Public prestador As Prestador
    Public paciente As Paciente
    'Public prestacion As Prestacion
    Public modulo As Integer
    Public subModulo As Integer
    Public hsSemana As Decimal
    Public hsFeriado As Decimal
    Public fecha As Date
    Public fecha_registrado As Date
    Public observaciones As String
    Public creoUser As Integer
    Public modifUser As Integer
    Public fechaCarga As Date
    Public fechaMod As Date
    Dim util As New utils


    Public Sub New()
        'CONSTRUCTOR VACIO PARA PODER USAR EL METODO ELIMINAR(_ID)
    End Sub


    Public Sub New(_prestador As Prestador, _paciente As Paciente, _modulo As Integer, _subModulo As Integer, _fecha As Date, _horas As Decimal, _observaciones As String)

        prestador = _prestador
        paciente = _paciente
        modulo = _modulo
        subModulo = _subModulo
        fecha = _fecha
        fecha_registrado = Date.Today.Date
        observaciones = _observaciones
        calcularHoras(_horas)
        creoUser = 29188989
        modifUser = 29188989
        fechaCarga = Today.ToShortDateString
        fechaMod = Today.ToShortDateString

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
            Dim db = New DB()
            db.insertar(Me)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub eliminar()
        Try
            Dim db = New DB()
            db.eliminar(Me)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub eliminar(_id As Integer)
        Try
            Dim db = New DB()
            db.eliminar(Me, _id)
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
