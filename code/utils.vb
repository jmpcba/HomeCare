Imports System.IO
Imports Microsoft.Office.Interop

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

    Public Sub backupDBTemp()
        If My.Settings.DBPath = "" Then
            Throw New Exception("La ruta a la base de datos no ha sido configurada aun")
        Else
            Try
                Dim dir = Path.GetDirectoryName(My.Settings.DBPath)
                Dim bckpDir = Path.Combine(dir, "BCKP")

                'CREAR DIR BCKP SI NO EXISTE
                If Not Directory.Exists(bckpDir) Then
                    Directory.CreateDirectory(bckpDir)
                End If

                'COPIAR ARCHIVO
                Dim bckpfile = Path.Combine(bckpDir, "homeCare_temp.accdb")
                FileCopy(My.Settings.DBPath, bckpfile)


            Catch ex As Exception
                Throw New Exception("No se pudo guardar una copia de la DB, sin embargo la operacion continuara:" & vbCrLf & vbCrLf & "Descripcion:" & vbCrLf & ex.Message)
            End Try
        End If
    End Sub

    Public Sub backUpDBFinal(_copiar As Boolean)

        Dim dir = Path.GetDirectoryName(My.Settings.DBPath)
        Dim bckpDir = Path.Combine(dir, "BCKP")
        Dim tempBckFile = Path.Combine(bckpDir, "homeCare_temp.accdb")

        If My.Settings.DBPath = "" Then
            Throw New Exception("La ruta a la base de datos no ha sido configurada aun")
        ElseIf _copiar Then

            Try

                'CREAR DIR BCKP SI NO EXISTE
                If Not Directory.Exists(bckpDir) Then
                    Directory.CreateDirectory(bckpDir)
                End If

                'COPIAR ARCHIVO
                Dim bckpfile = Path.Combine(bckpDir, String.Format("homeCare_{0}_{1}.accdb", Today.ToString("ddMMMyy"), Now.Hour.ToString))
                FileCopy(tempBckFile, bckpfile)
                'ELIMINAR TEMPORAL
                File.Delete(tempBckFile)

                Dim dirInfo As New DirectoryInfo(bckpDir)
                Dim archivos() = dirInfo.GetFileSystemInfos

                'SI HAY MAS DE 8 BACKUPS ELIMINA EL MAS VIEJO
                If archivos.Length > 8 Then

                    'INICIO LA VARIABLE CON LA FECHA MAXIMA DEL SISTEMA PARA QUE EL PRIMER IF SIEMPRE LE ASIGNE UNA FECHA
                    Dim menorEscitura As Date = Date.MaxValue
                    Dim archivoMasViejo As FileSystemInfo

                    For Each a In archivos
                        Dim ultEscritura = a.LastWriteTimeUtc
                        If ultEscritura < menorEscitura Then
                            menorEscitura = ultEscritura
                            archivoMasViejo = a
                        End If
                    Next

                    archivoMasViejo.Delete()

                End If

            Catch ex As Exception
                Throw New Exception("No se pudo guardar una copia de la DB, sin embargo la operacion continuara:" & vbCrLf & vbCrLf & "Descripcion:" & vbCrLf & ex.Message)
            End Try
        Else
            Try
                File.Delete(tempBckFile)
            Catch ex As Exception
                'SI NO PUEDE BORRAR EL ARCHIVO TEMPORAL NO HACE NADA
            End Try

        End If
    End Sub

    Public Sub validarMail(_mail As String)
        If _mail.Contains("@") And (_mail.Contains(".COM") Or _mail.Contains(".com")) Then
            Else
            Throw New Exception("El mail debe seguir el formato alguien@algo.com")
        End If
    End Sub

    Public Sub exportarExcel(ByVal _dt As DataTable)

        Dim _excel As New Excel.Application
        Dim saveFile As New SaveFileDialog
        Dim path As String

        saveFile.Filter = "Documento Excel (*.xlsx)|*.xlsx"
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        Try
            If saveFile.ShowDialog = DialogResult.OK Then
                path = saveFile.FileName

                wBook = _excel.Workbooks.Add()
                wSheet = wBook.ActiveSheet()

                Dim dc As System.Data.DataColumn
                Dim dr As System.Data.DataRow
                Dim colIndex As Integer = 0
                Dim rowIndex As Integer = 0

                For Each dc In _dt.Columns
                    colIndex = colIndex + 1
                    wSheet.Cells(1, colIndex) = dc.ColumnName
                Next

                For Each dr In _dt.Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In _dt.Columns
                        colIndex = colIndex + 1
                        wSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next
                wSheet.Columns.AutoFit()
                wBook.SaveAs(path)

                ReleaseObject(wSheet)
                wBook.Close(False)
                ReleaseObject(wBook)
                _excel.Quit()
                ReleaseObject(_excel)
                GC.Collect()

                mensaje("Archivo exportado!", mensajes.info)
            End If
        Catch ex As Exception
            Throw
        Finally
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
        End Try
    End Sub
    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub
End Class
