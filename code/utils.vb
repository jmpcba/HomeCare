Public Class utils

    Dim db As DB

    Public Sub New()
        db = New DB
    End Sub

    Public Function calcDiaSemana(_fecha As Date)
        'devuelve true si _fecha no esta en la tabla de feriados ni es sababo/domingo
        'TODO: agregar tabla feriados
        Dim ret = True

        If _fecha.DayOfWeek = DayOfWeek.Saturday Or _fecha.DayOfWeek = DayOfWeek.Sunday Then
            ret = False
        End If
        Return ret
    End Function

    Public Function esFeriado(_fecha As Date) As Boolean
        Dim dt = New DataTable
        If db.feriado(_fecha) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
