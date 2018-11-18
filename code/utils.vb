Imports System.IO
Public Class utils

    Dim db As DB
    Dim feriados As DataTable
    Private liquidaciones As DataTable
    Private cargoLiq As Boolean = False

    Public Sub New()
        feriados = New DataTable()
    End Sub

    Public Enum mensajes
        err
        info
        aviso
        preg
    End Enum

    Public Function esFindeOFeriado(_fecha As Date) As Boolean
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

    Public Sub validarNumerico(_txtBox As TextBox)
        If _txtBox.Text <> "" Then
            If Not IsNumeric(_txtBox.Text) Then
                _txtBox.Text = ""
                Throw New Exception("Debe ingresar un valor numerico")
            End If
        End If
    End Sub

    Public Sub iniciarTxtBoxes(_txtboxes As TextBox())
        For Each t As TextBox In _txtboxes
            t.Text = ""
        Next
    End Sub

    Public Sub validarTxtBoxLleno(_texboxes As TextBox())
        For Each t As TextBox In _texboxes
            If t.Text = "" Then
                t.Focus()
                Throw New Exception("Complete todos los campos")
            End If
        Next
    End Sub

    Public Sub validarLargo(_txtBox As TextBox, _largo As Integer)
        If _txtBox.Text.Length <> _largo Then
            _txtBox.Focus()
            Throw New Exception(String.Format("Ingrese un numero de {0} digitos", _largo.ToString))
        End If
    End Sub

    Public Function validarLiquidacion(_id As String, _fecha As Date) As Boolean
        db = New DB
        'valida si ya existe una liquidacion cerrada para el cuit
        'DEVUELVE TRUE SI EXISTE UNA LIQUIDACION CERRADA PARA ESTE MES Y MEDICO
        If IsNothing(liquidaciones) Then
            liquidaciones = New DataTable
        End If

        Try
            If Not cargoLiq Then
                liquidaciones = db.getLiquidacionesCerradas(_fecha)
                cargoLiq = True
            End If

            If liquidaciones.Select(String.Format("ID_PREST='{0}'", _id)).Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function mensaje(_msg As String, _tipo As mensajes)
        Dim icono As New MessageBoxIcon
        Dim btn As New MessageBoxButtons
        Dim titulo As String = ""
        Dim resultado As New MsgBoxResult

        btn = MessageBoxButtons.OK

        If _tipo = mensajes.err Then
            icono = MessageBoxIcon.Exclamation
            titulo = "Error"
        ElseIf _tipo = mensajes.info Then
            titulo = "Aviso"
            icono = MessageBoxIcon.Information
        ElseIf _tipo = mensajes.preg Then
            titulo = "Confirme"
            icono = MessageBoxIcon.Question
            btn = MessageBoxButtons.YesNo
        End If

        resultado = MessageBox.Show(_msg,
            titulo,
            btn,
            icono,
            MessageBoxDefaultButton.Button1)

        Return resultado
    End Function
End Class
