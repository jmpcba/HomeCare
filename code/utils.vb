Imports System.IO
Public Class utils

    Dim db As DB
    Dim feriados As DataTable

    Public Sub New()
        feriados = New DataTable()
    End Sub

    Public Function esFindeOFeriado(_fecha As Date)
        'devuelve true si _fecha es fin de semana

        If _fecha.DayOfWeek = DayOfWeek.Saturday Or _fecha.DayOfWeek = DayOfWeek.Sunday Or esFeriado(_fecha) Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Function esFeriado(_fecha As Date) As Boolean
        'llenar la tabla si no esta llena todavia. Reduce las interacciones con la DB
        db = New DB
        Dim r As DataRow()
        If feriados.Rows.Count = 0 Then
            feriados = db.feriado(_fecha)
        End If

        r = feriados.Select(String.Format("FECHA='{0}'", _fecha.ToShortDateString))

        If r.Count = 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub setDB()
        Dim frmArchivo = New OpenFileDialog

        frmArchivo.InitialDirectory = "C:\"
        frmArchivo.RestoreDirectory = True

        If frmArchivo.ShowDialog = DialogResult.OK Then
            Try
                Dim path = IO.Path.GetFullPath(frmArchivo.FileName)
                My.Settings.DBPath = path
                My.Settings.Save()
                My.Settings.Item("HomeCareConnectionString") = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}'", My.Settings.DBPath)
            Catch ex As Exception
                Throw
            End Try
        End If
    End Sub
End Class
