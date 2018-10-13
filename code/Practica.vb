Public Class Practica
    Public prestador As Prestador
    Public paciente As Paciente
    Public prestacion As Prestacion
    Public modulo As Modulo
    Public fecha As Date
    Public fecha_registrado As Date
    Public observaciones As String

    Public Sub New()
        'CONSTRUCTOR VACIO PARA PODER USAR EL METODO ELIMINAR(_ID)
    End Sub


    Public Sub New(_prestador As Prestador, _paciente As Paciente, _modulo As Modulo, _prestacion As Prestacion, _fecha As Date, _hsNormales As Decimal, _hsFeriado As Decimal, _observaciones As String)
        prestador = _prestador
        paciente = _paciente
        prestacion = _prestacion
        modulo = _modulo
        fecha = _fecha
        fecha_registrado = Date.Today.Date
        observaciones = _observaciones
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
