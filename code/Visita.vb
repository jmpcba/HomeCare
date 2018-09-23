Public Class Visita
    Public id As Integer
    Public medico As Medico
    Public paciente As Paciente
    Public prestacion As Prestacion
    Public fecha As Date
    Public fecha_registrado As Date

    Public Sub New()
        'CONSTRUCTOR VACIO PARA PODER USAR EL METODO ELIMINAR(_ID)
    End Sub

    Public Sub New(_nro As Integer)
        Dim db = New DB()
        Dim dt As DataTable

        Try
            dt = db.getRow(_nro, DB.tablas.visitas)
            id = dt(0)(0)
            paciente = New Paciente(dt(0)(1))
            medico = New Medico(dt(0)(2))
            fecha = dt(0)(3)
            fecha_registrado = dt(0)(4)
            prestacion = New Prestacion(dt(0)(5))
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub New(_medico As Medico, _paciente As Paciente, _prestacion As Prestacion, _fecha As Date)
        medico = _medico
        paciente = _paciente
        prestacion = _prestacion
        fecha = _fecha
        fecha_registrado = Date.Today.Date
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
