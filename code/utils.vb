Imports System.IO
Imports Microsoft.Office.Interop

Public Class utils

    Dim db As DB
    Dim feriados As DataTable
    Event progresoExportExcel()
    Private liquidaciones As DataTable
    Private cargoLiq As Boolean = False
    Event cambioBarraDeProgreso()

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
        frmArchivo.Filter = "Base de datos access (*.accdb)|*accdb|Todos los archivos (*.*)|*.*"

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

    Public Sub setBackupPath()
        Dim frmFolder = New FolderBrowserDialog

        frmFolder.ShowNewFolderButton = True

        If frmFolder.ShowDialog = DialogResult.OK Then
            Try
                Dim path = frmFolder.SelectedPath
                My.Settings.DBBackupPath = path
                My.Settings.Save()
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

    Public Sub validarNumerico(_txtBox As TextBox())
        For Each t As TextBox In _txtBox
            If t.Text <> "" Then
                If t.Text.Contains(".") Or Not IsNumeric(t.Text) Then
                    t.Focus()
                    Throw New Exception("Debe ingresar un valor numerico" & vbCrLf & "Utilice comas para separar decimales")
                End If
            End If
        Next
    End Sub

    Public Sub validarCombos(_combos As ComboBox())
        For Each c As ComboBox In _combos
            If c.SelectedIndex = -1 Then
                c.Focus()
                Throw New Exception("Seleccione un valor de la grilla")
            End If
        Next
    End Sub
    Public Sub iniciarTxtBoxes(_txtboxes As TextBox())
        activarTxtBoxes(_txtboxes)
        For Each t As TextBox In _txtboxes
            t.Text = ""
        Next
    End Sub

    Public Sub activarTxtBoxes(_txtboxes As TextBox())
        For Each t As TextBox In _txtboxes
            t.Enabled = True
        Next
    End Sub

    Public Sub desactivarTxtBoxes(_txtboxes As TextBox())
        For Each t As TextBox In _txtboxes
            t.Enabled = False
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
        Dim bckpDir As String

        If My.Settings.DBPath = "" Then
            Throw New Exception("La ruta a la base de datos no ha sido configurada aun")
        Else
            Try
                If My.Settings.DBBackupPath = "" Then
                    Dim dir = Path.GetDirectoryName(My.Settings.DBPath)
                    bckpDir = Path.Combine(dir, "BCKP")
                Else
                    bckpDir = Path.Combine(My.Settings.DBBackupPath, "BCKP")
                End If

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
        Dim bckpDir As String
        Dim tempBckFile As String

        If My.Settings.DBBackupPath = "" Then
            Dim dir = Path.GetDirectoryName(My.Settings.DBPath)
            bckpDir = Path.Combine(dir, "BCKP")
        Else
            bckpDir = Path.Combine(My.Settings.DBBackupPath, "BCKP")
        End If

        tempBckFile = Path.Combine(bckpDir, "homeCare_temp.accdb")

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

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim sheetIndex As Integer
        Dim exc As New Excel.Application
        Dim Wb As Excel.Workbook
        Dim Ws As Excel.Worksheet
        Dim saveFile As New SaveFileDialog
        Dim path As String

        saveFile.Filter = "Documento Excel (*.xlsx)|*.xlsx"

        Wb = exc.Workbooks.Add

        If saveFile.ShowDialog = DialogResult.OK Then
            path = saveFile.FileName

            Try
                ' Copy each DataTable as a new Sheet
                'On Error Resume Next
                Dim col, row As Integer
                ' Copy the DataTable to an object array
                Dim rawData(_dt.Rows.Count, _dt.Columns.Count - 1) As Object

                ' Copy the column names to the first row of the object array

                For col = 0 To _dt.Columns.Count - 1
                    rawData(0, col) = _dt.Columns(col).ColumnName.ToUpper
                Next

                ' Copy the values to the object array

                For col = 0 To _dt.Columns.Count - 1
                    For row = 0 To _dt.Rows.Count - 1
                        rawData(row + 1, col) = _dt.Rows(row).ItemArray(col)
                    Next
                Next
                ' Calculate the final column letter
                Dim finalColLetter As String = String.Empty
                finalColLetter = columnaExcel(_dt.Columns.Count)
                'Generate Excel Column Name (Column ID)

                sheetIndex += 1
                Ws = Wb.Worksheets(sheetIndex)
                Ws.Name = _dt.TableName
                Dim excelRange As String = String.Format("A1:{0}{1}",
                                           finalColLetter, _dt.Rows.Count + 1)

                Ws.Range(excelRange, Type.Missing).Value2 = rawData
                Ws.Columns.AutoFit()

                Dim contador = 0
                For Each c As DataColumn In _dt.Columns
                    contador += 1

                    If c.ColumnName.ToUpper.Contains("FECHA") Then
                        Dim letraCol = columnaExcel(contador)
                        Dim rango As String
                        rango = letraCol & ":" & letraCol
                        Ws.Columns(rango).numberformat = "dd-mmm-yy"
                    End If

                    If c.ColumnName.ToUpper.Contains("AFILIADO") Then
                        Dim letraCol = columnaExcel(contador)
                        Dim rango As String
                        rango = letraCol & ":" & letraCol
                        Ws.Columns(rango).numberformat = "0"
                    End If
                Next

                Ws = Nothing


                For Each w As Excel.Worksheet In Wb.Sheets
                    If w.Name.StartsWith("Sheet") Then
                        w.Delete()
                    End If
                Next

                Wb.SaveAs(path)

                Wb.Close(True, Type.Missing, Type.Missing)
                Wb = Nothing
                ' Release the Application object
                exc.Quit()
                exc = Nothing
                ' Collect the unreferenced objects
                GC.Collect()

                mensaje("Archivo exportado!", mensajes.info)

            Catch ex As Exception
                Throw
            Finally
                System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
            End Try
        End If
    End Sub

    Public Sub habilitarBoton(_txtboxes As TextBox(), _btn As Button)
        _btn.Enabled = False
        For Each t In _txtboxes
            If t.Text <> "" Then
                _btn.Enabled = True
            End If
        Next
    End Sub

    Public Sub copiarDB()
        Dim frmFolder = New FolderBrowserDialog
        Dim fileName = Path.GetFileName(My.Settings.DBPath)

        frmFolder.ShowNewFolderButton = True

        If frmFolder.ShowDialog = DialogResult.OK Then
            Try
                Dim p = frmFolder.SelectedPath
                Dim copyPath = Path.Combine(p, fileName)

                If Path.GetFullPath(Path.GetDirectoryName(My.Settings.DBPath)) = p Then
                    Throw New ExcepcionDeSistema("No se puede guardar una copia aqui" & vbCrLf & vbCrLf & "Seleccione otra carpeta")
                End If

                File.Copy(My.Settings.DBPath, copyPath)
                mensaje("Archivo copiado", mensajes.info)

            Catch ex As Exception
                Throw
            End Try
        End If
    End Sub
    Public Sub restaurarDB()
        Dim frmArchivo = New OpenFileDialog

        frmArchivo.InitialDirectory = "C:\"
        frmArchivo.RestoreDirectory = True
        frmArchivo.Filter = "Base de datos access (*.accdb)|*accdb|Todos los archivos (*.*)|*.*"

        If frmArchivo.ShowDialog = DialogResult.OK Then
            Try
                Dim p = Path.GetFullPath(frmArchivo.FileName)
                Dim bckFileName = Path.GetFileName(My.Settings.DBPath)
                bckFileName = bckFileName.Insert(bckFileName.IndexOf(".accdb"), "_copia_usuario_" & Now.ToString("yyyy-MM-dd_HHmm"))
                'copia del archivo actual
                File.Copy(My.Settings.DBPath, Path.Combine(My.Settings.DBBackupPath, bckFileName), True)
                File.Copy(frmArchivo.FileName, My.Settings.DBPath, True)
                mensaje("Archivo restaurado", mensajes.info)
            Catch ex As Exception
                Throw
            End Try
        End If
    End Sub

    Public Sub exportarExcel(ds As DataSet)

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim sheetIndex As Integer
        Dim exc As New Excel.Application
        Dim Wb As Excel.Workbook
        Dim Ws As Excel.Worksheet
        Dim saveFile As New SaveFileDialog
        Dim path As String

        saveFile.Filter = "Documento Excel (*.xlsx)|*.xlsx"

        Wb = exc.Workbooks.Add

        If saveFile.ShowDialog = DialogResult.OK Then
            path = saveFile.FileName

            Try
                ' Copy each DataTable as a new Sheet
                For Each dt As System.Data.DataTable In ds.Tables
                    'On Error Resume Next
                    Dim col, row As Integer
                    ' Copy the DataTable to an object array
                    Dim rawData(dt.Rows.Count, dt.Columns.Count - 1) As Object

                    ' Copy the column names to the first row of the object array

                    For col = 0 To dt.Columns.Count - 1
                        rawData(0, col) = dt.Columns(col).ColumnName.ToUpper
                    Next

                    ' Copy the values to the object array

                    For col = 0 To dt.Columns.Count - 1
                        For row = 0 To dt.Rows.Count - 1
                            rawData(row + 1, col) = dt.Rows(row).ItemArray(col)
                        Next
                        RaiseEvent progresoExportExcel()
                    Next
                    ' Calculate the final column letter
                    Dim finalColLetter As String = String.Empty
                    finalColLetter = columnaExcel(dt.Columns.Count)
                    'Generate Excel Column Name (Column ID)

                    Try
                        sheetIndex += 1
                        Ws = Wb.Worksheets(sheetIndex)

                    Catch ex As Exception
                        Wb.Worksheets.Add()
                        Ws = Wb.Worksheets(sheetIndex - 1)
                    End Try

                    Ws.Name = dt.TableName
                    Dim excelRange As String = String.Format("A1:{0}{1}",
                                           finalColLetter, dt.Rows.Count + 1)

                    Ws.Range(excelRange, Type.Missing).Value2 = rawData
                    Ws.Columns.AutoFit()

                    Dim contador = 0
                    For Each c As DataColumn In dt.Columns
                        contador += 1

                        If c.ColumnName.ToUpper.Contains("FECHA") Then
                            Dim letraCol = columnaExcel(contador)
                            Dim rango As String
                            rango = letraCol & ":" & letraCol
                            Ws.Columns(rango).numberformat = "dd-mmm-yy"
                        End If

                        If c.ColumnName.ToUpper.Contains("AFILIADO") Then
                            Dim letraCol = columnaExcel(contador)
                            Dim rango As String
                            rango = letraCol & ":" & letraCol
                            Ws.Columns(rango).numberformat = "0"
                        End If
                    Next
                    Ws = Nothing
                Next

                Try
                    For Each w As Excel.Worksheet In Wb.Sheets
                        If w.Name.StartsWith("Sheet") Or w.Name.StartsWith("Hoja") Then
                            w.Delete()
                        End If
                    Next
                Catch ex As Exception

                End Try


                Wb.SaveAs(path)

                Wb.Close(True, Type.Missing, Type.Missing)
                Wb = Nothing
                ' Release the Application object
                exc.Quit()
                exc = Nothing
                ' Collect the unreferenced objects
                GC.Collect()

                mensaje("Archivo exportado!", mensajes.info)

            Catch ex As Exception
                Throw
            Finally
                System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
            End Try
        End If
    End Sub

    Private Function columnaExcel(ByVal Col As Integer) As String
        If Col < 0 And Col > 256 Then
            mensaje("Argumento Invalido", mensajes.err)
            Return Nothing
            Exit Function
        End If

        Dim i As Int16
        Dim r As Int16
        Dim S As String

        If Col <= 26 Then
            S = Chr(Col + 64)
        Else
            r = Col Mod 26
            i = System.Math.Floor(Col / 26)
            If r = 0 Then
                r = 26
                i = i - 1
            End If
            S = Chr(i + 64) & Chr(r + 64)
        End If
        columnaExcel = S
    End Function
End Class
