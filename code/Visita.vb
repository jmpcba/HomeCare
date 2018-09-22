Public Class Visita
    Public medico As Medico
    Public paciente As Paciente
    Public prestacion As Prestacion

    Public Sub New(_medico As Medico, _paciente As Paciente, _prestacion As Prestacion)
        medico = _medico
        paciente = _paciente
        prestacion = _prestacion
    End Sub
End Class
