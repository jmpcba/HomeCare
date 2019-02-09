Imports System.Data
Imports System.Data.OleDb
Imports HomeCare
Imports System.Globalization

Public Class DB
    Private cnn As OleDbConnection
    Private cmd As OleDbCommand
    Private da As OleDbDataAdapter
    Private ds As DataSet
    Private conStr As String = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}'", My.Settings.DBPath)
    Private ut As New utils
    Private hacerBackup As Boolean = True

    Public Enum tablas
        prestadores
        pacientes
        prestaciones
        visitas
        modulo
        subModulo
        feriados
        especialidades
        usuarios
        zonas
    End Enum

    Public Enum tiposLiquidacion
        detalle
        medico
        paciente
    End Enum

    Sub New()
        If My.Settings.DBPath = "" Then
            Throw New Exception("No se configuro una DB todavia!!!" & vbCrLf & "en la pantalla principal seleccione Configuracion - DB")
        End If
        cnn = New OleDbConnection(conStr)
        cmd = New OleDbCommand()
        da = New OleDbDataAdapter(cmd)
        ds = New DataSet()
        cmd.Connection = cnn
    End Sub

    Friend Function getVisitas(fec As Date) As DataTable
        Dim query = "SELECT * FROM VISITAS WHERE  FECHA > " & fec.ToShortDateString

        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            da.Fill(ds, "RESULTADO")
            Return ds.Tables("RESULTADO")
        Catch ex As Exception
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try
    End Function

    Friend Sub InsertarFeriado(_fecha As Date, _desc As String)
        Try
            Dim query = String.Format("INSERT INTO FERIADOS (FECHA, DESCRIPCION, CARGO_USUARIO, FECHA_CARGA, MODIFICO_USUARIO, FECHA_MODIFICACION) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                                      _fecha.Date.ToShortDateString, _desc, My.Settings.dni, Today.ToShortDateString, My.Settings.dni, Today.ToShortDateString)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            ut.backupDBTemp()

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            hacerBackup = False
            Throw
        Finally
            cnn.Close()
            ut.backUpDBFinal(hacerBackup)
        End Try
    End Sub

    Friend Function getPracticas(_fecha As Date) As DataTable
        Dim desde As Date
        Dim hasta As Date

        desde = New Date(_fecha.Year, _fecha.Month, 1)
        hasta = New Date(_fecha.Year, _fecha.Month, Date.DaysInMonth(_fecha.Year, _fecha.Month))

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "QUERY_DETALLE_PRACTICAS"

        cmd.Parameters.AddWithValue("DESDE", desde.ToShortDateString)
        cmd.Parameters.AddWithValue("HASTA", hasta.ToShortDateString)

        Try
            da.Fill(ds, "PRACTICAS")
            Return ds.Tables("PRACTICAS")
        Catch ex As Exception
            Throw New Exception("Error DE BASE DE DATOS: " & ex.Message)
        End Try
    End Function

    Friend Sub eliminarFeriado(_fecha As Date)
        Try

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "DELETE_FERIADO"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("FECHA_IN", _fecha.Date)

            ut.backupDBTemp()

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            hacerBackup = False
            Throw
        Finally
            cnn.Close()
            ut.backUpDBFinal(hacerBackup)
        End Try
    End Sub

    Friend Function getLiquidacion(_fecha As Date, _liq As tiposLiquidacion) As DataTable
        Dim desde As Date
        Dim hasta As Date
        Dim dt As New DataTable
        Dim ut As New utils

        desde = New Date(_fecha.Year, _fecha.Month, 1)
        hasta = New Date(_fecha.Year, _fecha.Month, Date.DaysInMonth(_fecha.Year, _fecha.Month))

        cmd.CommandType = CommandType.StoredProcedure
        If _liq = tiposLiquidacion.detalle Then
            cmd.CommandText = "QUERY_DETALLES"

        ElseIf _liq = tiposLiquidacion.medico Then
            cmd.CommandText = "QUERY_SUMATORIA_MEDICOS"

        ElseIf _liq = tiposLiquidacion.paciente Then
            cmd.CommandText = "QUERY_SUMATORIA_PACIENTE"
        End If

        cmd.Parameters.AddWithValue("DESDE", desde.ToShortDateString)
        cmd.Parameters.AddWithValue("HASTA", hasta.ToShortDateString)

        Try
            'LLENAR EL DETALLE
            da.Fill(ds, "QUERY")
            ds.Tables("QUERY").Columns.Add("ESTADO")
            If _liq = tiposLiquidacion.medico Then
                If ds.Tables("QUERY").Rows.Count > 0 Then
                    'CONTROLAR SI EXISTEN LIQUIDACIONES PARA ESE MEDICO
                    Dim liquidacionesCerradas As New DataTable
                    liquidacionesCerradas = getLiquidacionesCerradas(_fecha)

                    For Each r As DataRow In ds.Tables("QUERY").Rows
                        Dim id = r("ID_PREST")

                        If ut.validarLiquidacion(id, _fecha) Then
                            r("ESTADO") = "CERRADA"
                        Else
                            r("ESTADO") = "PENDIENTE"
                        End If
                    Next
                End If
            End If


            Return ds.Tables("QUERY")

        Catch ex As Exception
            Throw New Exception("Error DE BASE DE DATOS: " & ex.Message)
        End Try

    End Function

    Friend Sub reactivarPrestador(_id As String)
        Try
            Dim query = "UPDATE PRESTADORES SET FECHA_CESE=NULL WHERE ID=" & _id

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw
        Finally
            cnn.Close()
        End Try
    End Sub

    Friend Sub reactivarPaciente(_afiliado As String)
        Try
            Dim query = "UPDATE PACIENTES SET FECHA_BAJA=NULL WHERE AFILIADO='" & _afiliado & "'"

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw
        Finally
            cnn.Close()
        End Try
    End Sub

    Friend Sub eliminarPractica(_id As Integer)
        Try
            Dim query = "DELETE FROM PRACTICAS WHERE ID=" & _id

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw
        Finally
            cnn.Close()
        End Try
    End Sub

    Friend Sub eliminarPractica(_ids As List(Of Integer))
        Try
            Dim query = "DELETE FROM PRACTICAS WHERE ID IN ("
            For Each id In _ids
                query += id.ToString & ","
            Next
            'remueve la ultima coma
            query = query.Substring(0, query.Length - 1)
            query += ")"

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw
        Finally
            cnn.Close()
        End Try
    End Sub
    Friend Function getLiquidacion(_id As Integer, _fecha As Date) As DataTable
        Dim desde As Date
        Dim hasta As Date

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        desde = New Date(_fecha.Year, _fecha.Month, 1)
        hasta = New Date(_fecha.Year, _fecha.Month, Date.DaysInMonth(_fecha.Year, _fecha.Month))

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "QUERY_DETALLE_MEDICO"

        cmd.Parameters.Clear()

        cmd.Parameters.AddWithValue("DESDE", desde)
        cmd.Parameters.AddWithValue("HASTA", hasta)
        cmd.Parameters.AddWithValue("P_ID", _id)

        Try
            da.Fill(ds, "LIQUIDACION")
            Return ds.Tables("LIQUIDACION")
        Catch ex As Exception
            Throw New Exception("Error DE BASE DE DATOS: " & ex.Message)
        Finally
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
        End Try

    End Function

    Friend Function getPracticasPaciente(_id As String, _fecha As Date) As DataTable
        Dim desde As Date
        Dim hasta As Date

        desde = New Date(_fecha.Year, _fecha.Month, 1)
        hasta = New Date(_fecha.Year, _fecha.Month, Date.DaysInMonth(_fecha.Year, _fecha.Month))

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "QUERY_DETALLE_PACIENTE"

        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("P_ID", _id)
        cmd.Parameters.AddWithValue("DESDE", desde.ToShortDateString)
        cmd.Parameters.AddWithValue("HASTA", hasta.ToShortDateString)

        Try
            da.Fill(ds, "PRACTICAS")
            Return ds.Tables("PRACTICAS")
        Catch ex As Exception
            Throw New Exception("Error DE BASE DE DATOS: " & ex.Message)
        End Try
    End Function

    Public Function getUsuario(_dni As String) As DataTable
        cmd.CommandText = String.Format("SELECT * FROM USUARIOS WHERE DNI = '{0}'", _dni)
        cmd.CommandType = CommandType.Text

        Try
            da.Fill(ds, "PACIENTES")
            Return ds.Tables("PACIENTES")
        Catch ex As Exception
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try

    End Function

    Friend Sub insertar(_practica As Practica)

        Try
            Dim query = String.Format("INSERT INTO PRACTICAS (CUIT, AFILIADO, MODULO, SUB_MODULO, HS_NORMALES, HS_FERIADO, FECHA_PRACTICA, FECHA_INICIO, OBSERVACIONES, CARGO_USUARIO, FECHA_CARGA, MODIFICO_USUARIO, FECHA_MODIFICACION, ID_PREST, HS_DIFERENCIAL) VALUES ('{0}', '{1}', '{2}', '{3}', {4}, {5}, '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', {14})",
                                      _practica.prestador.cuit, _practica.paciente.afiliado, _practica.modulo, _practica.subModulo,
                                      _practica.hsSemana, _practica.hsFeriado, _practica.fecha.ToShortDateString,
                                      DateTime.Today.ToShortDateString, _practica.observaciones, _practica.creoUser,
                                      _practica.fechaCarga.ToShortDateString, _practica.modifUser, _practica.fechaMod.ToShortDateString, _practica.prestador.id, _practica.hsDif)

            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            ut.backupDBTemp()

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            hacerBackup = False
            Throw
        Finally
            cnn.Close()
            ut.backUpDBFinal(hacerBackup)
        End Try
    End Sub

    Friend Sub insertar(_prestacion As Prestacion)

        Dim query = String.Format("INSERT INTO PRESTACIONES (CODIGO, DESCRIPCION, CARGO_USUARIO, MODIFICO_USUARIO, FECHA_CARGA, FECHA_MODIFICACION)
                        VALUES ({0}, '{1}', '{2}', '{3}', #{4}#, #{5}#)",
                                  _prestacion.codigo, _prestacion.descripcion, _prestacion.creoUser, _prestacion.modifUser, _prestacion.fechaCarga.ToShortDateString, _prestacion.fechaMod.ToShortDateString)

        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            ut.backupDBTemp()

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            hacerBackup = False
            Throw
        Finally
            cnn.Close()
            ut.backUpDBFinal(hacerBackup)
        End Try
    End Sub

    Friend Sub insertar(_paciente As Paciente)

        Dim query = String.Format("INSERT INTO PACIENTES (AFILIADO, DNI, NOMBRE, APELLIDO, LOCALIDAD, OBRA_SOCIAL, CARGO_USUARIO, MODIFICO_USUARIO, FECHA_CARGA, FECHA_MODIFICACION)
                        VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', #{8}#, #{9}#)",
                                  _paciente.afiliado, _paciente.dni, _paciente.nombre, _paciente.apellido, _paciente.localidad, _paciente.obrasocial, _paciente.creoUser, _paciente.modifUser, _paciente.fechaCarga.ToShortDateString, _paciente.fechaMod.ToShortDateString)


        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            ut.backupDBTemp()

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            hacerBackup = False
            Throw
        Finally
            cnn.Close()
            ut.backUpDBFinal(hacerBackup)
        End Try
    End Sub

    Friend Sub insertar(_prestador As Prestador)
        'Dim cult = New CultureInfo("en-US")

        Dim query = String.Format("INSERT INTO PRESTADORES (CUIT, APELLIDO, NOMBRE, EMAIL, ESPECIALIDAD, LOCALIDAD, MONTO_SEMANA, MONTO_FERIADO, MONTO_FIJO, PORCENTAJE, CARGO_USUARIO, MODIFICO_USUARIO, FECHA_CARGA, FECHA_MODIFICACION, SERVICIO, COMENTARIO, ZONA) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6}, {7}, {8}, {9}, '{10}', '{11}', #{12}#, #{13}#, '{14}', '{15}', {16})", _prestador.cuit, _prestador.apellido, _prestador.nombre, _prestador.email, _prestador.especialidad, _prestador.localidad, _prestador.montoNormal, _prestador.montoFeriado, _prestador.montoFijo, _prestador.montoDiferencial, _prestador.creoUser, _prestador.modifUser, _prestador.fechaCarga.ToShortDateString, _prestador.fechaMod.ToShortDateString, _prestador.obraSocial, _prestador.observaciones, _prestador.zona)

        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            ut.backupDBTemp()

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            hacerBackup = False
            Throw
        Finally
            cnn.Close()
            ut.backUpDBFinal(hacerBackup)
        End Try

    End Sub

    Friend Sub insertar(_liq As Liquidacion)
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim query = String.Format("INSERT INTO LIQUIDACION (CUIT, LOCALIDAD, ESPECIALIDAD, MES, HS_NORMALES, HS_FERIADOS, IMPORTE_NORMAL, IMPORTE_FERIADO, MONTO_FIJO, CARGO_USUARIO, MODIFICO_USUARIO, FECHA_CARGA, FECHA_MODIFICACION, ID_PREST, HS_DIFERENCIAL, IMPORTE_DIFERENCIAL) VALUES ('{0}', '{1}', '{2}', #{3}#, {4}, {5}, {6}, {7}, {8}, {9}, {10}, #{11}#, #{12}#, {13}, {14}, {15})",
                                  _liq.prestador.cuit,
                                  _liq.prestador.localidad,
                                  _liq.prestador.especialidad,
                                  _liq.mes.ToShortDateString,
                                  _liq.hsNormales,
                                  _liq.hsFeriado,
                                  _liq.importeNormal,
                                  _liq.importeFeriado,
                                  _liq.montoFijo,
                                  _liq.creoUser,
                                  _liq.modifUser,
                                  _liq.fechaCarga.ToShortDateString,
                                  _liq.fechaMod.ToShortDateString,
                                  _liq.idPrestador,
                                  _liq.hsDiferencial,
                                  _liq.importeDiferencial)

        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            ut.backupDBTemp()

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            hacerBackup = False
            Throw
        Finally
            cnn.Close()
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
            ut.backUpDBFinal(hacerBackup)
        End Try
    End Sub


    Friend Sub insertar(_subMod As subModulo)

        Dim query = String.Format("INSERT INTO SUBMODULO (CODIGO, DESCRIPCION, CARGO_USUARIO, FECHA, MODIFICO_USUARIO, FECHA_MODIFICACION) VALUES ({0}, '{1}', {2}, #{3}#, {4}, #{5}#)", _subMod.codigo, _subMod.descripcion, _subMod.creoUser, _subMod.fechaCarga.ToShortDateString, _subMod.modifUser, _subMod.fechaMod.ToShortDateString)

        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            ut.backupDBTemp()

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            hacerBackup = False
            Throw
        Finally
            cnn.Close()
            ut.backUpDBFinal(hacerBackup)
        End Try
    End Sub

    Friend Sub insertar(_mod As Modulo)

        Dim query = String.Format("INSERT INTO MODULO (CODIGO, MEDICO, ENFERMERIA, KINESIOLOGIA, FONOAUDIOLOGIA, CUIDADOR, NUTRICION, CARGO_USUARIO, FECHA_CARGA, MODIFICO_USUARIO, FECHA_MODIFICACION) VALUES ('{0}', {1}, {2}, {3}, {4}, {5}, {6}, {7}, #{8}#, {9}, #{10}#)", _mod.codigo, _mod.topeMedico, _mod.topeEnfermeria, _mod.topeKinesio, _mod.topeFono, _mod.topeCuidador, _mod.topeNutricionista, _mod.creoUser, _mod.fechaCarga.ToShortDateString, _mod.modifUser, _mod.fechaMod.ToShortDateString)

        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            ut.backupDBTemp()

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            hacerBackup = False
            Throw
        Finally
            cnn.Close()
            ut.backUpDBFinal(hacerBackup)
        End Try
    End Sub
    Friend Sub insertar(_feriado As Feriado)

        Dim query = String.Format("INSERT INTO FERIADOS (FECHA, DESCRIPCION, CARGO_USUARIO, FECHA_CARGA, MODIFICO_USUARIO, FECHA_MODIFICACION) VALUES (#{0}#, '{1}', {2}, #{3}#, {4}, #{5}#)", _feriado.fecha.ToShortDateString, _feriado.descripcion, _feriado.creoUser, _feriado.fechaCarga.ToShortDateString, _feriado.modifUser, _feriado.fechaMod.ToShortDateString)

        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            ut.backupDBTemp()

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            hacerBackup = False
            Throw
        Finally
            cnn.Close()
            ut.backUpDBFinal(hacerBackup)
        End Try
    End Sub
    Friend Sub insertar(_usuario As Usuario)
        Dim enc As New Encriptador()
        Try
            Dim query = String.Format("INSERT INTO USUARIOS (DNI, APELLIDO, NOMBRE, NIVEL, PASS, CARGO_USUARIO, FECHA_CARGA, MODIFICO_USUARIO, FECHA_MODIFICACION) VALUES ('{0}', '{1}', '{2}', {3}, '{4}', '{5}', '{6}', '{7}', '{8}')",
                                      _usuario.dni, _usuario.apellido, _usuario.nombre, _usuario.nivel, enc.encriptar(_usuario.pass), _usuario.creoUser, _usuario.fechaCarga.ToShortDateString, _usuario.modifUser, _usuario.fechaMod.ToShortDateString)


            cmd.CommandType = CommandType.Text
            cmd.CommandText = query

            ut.backupDBTemp()

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            hacerBackup = False
            Throw
        Finally
            cnn.Close()
            ut.backUpDBFinal(hacerBackup)
        End Try
    End Sub

    Friend Sub insertar(_zona As Zona)

        Dim enc As New Encriptador()
        Dim query = String.Format("INSERT INTO ZONAS (NOMBRE, EMAIL, PASS, PROPIETARIO, CARGO_USUARIO, FECHA_CARGA, MODIFICO_USUARIO, FECHA_MODIFICACION) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}',#{5}#, '{6}', #{7}#)",
                                  _zona.nombre, _zona.email, enc.encriptar(_zona.pass), _zona.propietario, _zona.creoUser, _zona.fechaCarga.ToShortDateString, _zona.modifUser, _zona.fechaMod.ToShortDateString)
        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            ut.backupDBTemp()

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            hacerBackup = False

            If ex.Message.Contains("duplicate values in the index") Or ex.Message.Contains("valores duplicados en el índice") Then
                Throw New ExcepcionDeSistema("Ya existe una zona con este nombre")
            Else
                Throw
            End If
        Finally
            cnn.Close()
            ut.backUpDBFinal(hacerBackup)
        End Try
    End Sub
    Friend Sub actualizar(_paciente As Paciente)

        Dim query As String
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        If _paciente.fechaBaja = Date.MinValue Then
            query = String.Format("UPDATE PACIENTES SET DNI={0}, APELLIDO='{1}', NOMBRE='{2}', LOCALIDAD='{3}', OBRA_SOCIAL='{4}', MODIFICO_USUARIO='{5}', FECHA_MODIFICACION='{6}' WHERE AFILIADO='{7}'",
                                    _paciente.dni, _paciente.apellido, _paciente.nombre, _paciente.localidad, _paciente.obrasocial, _paciente.modifUser, _paciente.fechaMod, _paciente.afiliado)
        Else
            query = String.Format("UPDATE PACIENTES SET DNI={0}, APELLIDO='{1}', NOMBRE='{2}', LOCALIDAD='{3}', OBRA_SOCIAL='{4}', MODIFICO_USUARIO='{5}', FECHA_MODIFICACION='{6}', FECHA_BAJA=#{7}# WHERE AFILIADO='{8}'",
                                    _paciente.dni, _paciente.apellido, _paciente.nombre, _paciente.localidad, _paciente.obrasocial, _paciente.modifUser, _paciente.fechaMod, _paciente.fechaBaja.ToShortDateString, _paciente.afiliado)
        End If

        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            ut.backupDBTemp()

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            hacerBackup = False
            Throw
        Finally
            cnn.Close()
            ut.backUpDBFinal(hacerBackup)
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
        End Try
    End Sub

    Friend Sub actualizar(_prestador As Prestador)

        Dim query As String

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        If _prestador.fechaCese = Date.MinValue Then
            query = String.Format("UPDATE PRESTADORES SET APELLIDO='{0}', NOMBRE='{1}', EMAIL='{2}', ESPECIALIDAD='{3}', LOCALIDAD='{4}', MONTO_SEMANA={5}, MONTO_FERIADO={6}, MONTO_FIJO={7}, PORCENTAJE={8}, MODIFICO_USUARIO='{9}', FECHA_MODIFICACION='{10}', SERVICIO='{11}', COMENTARIO='{12}', ZONA={13} WHERE ID={14}", _prestador.apellido, _prestador.nombre, _prestador.email, _prestador.especialidad, _prestador.localidad, _prestador.montoNormal, _prestador.montoFeriado, _prestador.montoFijo, _prestador.montoDiferencial, _prestador.modifUser, _prestador.fechaMod.ToShortDateString, _prestador.obraSocial, _prestador.observaciones, _prestador.zona, _prestador.id)
        Else
            query = String.Format("UPDATE PRESTADORES SET APELLIDO='{0}', NOMBRE='{1}', EMAIL='{2}', ESPECIALIDAD='{3}', LOCALIDAD='{4}', MONTO_SEMANA={5}, MONTO_FERIADO={6}, MONTO_FIJO={7}, PORCENTAJE={8}, MODIFICO_USUARIO='{9}', FECHA_MODIFICACION='{10}', SERVICIO='{11}', FECHA_CESE=#{12}#, COMENTARIO='{13}', ZONA={14} WHERE ID={15}", _prestador.apellido, _prestador.nombre, _prestador.email, _prestador.especialidad, _prestador.localidad, _prestador.montoNormal, _prestador.montoFeriado, _prestador.montoFijo, _prestador.montoDiferencial, _prestador.modifUser, _prestador.fechaMod.ToShortDateString, _prestador.obraSocial, _prestador.fechaCese.ToShortDateString, _prestador.observaciones, _prestador.zona, _prestador.id)
        End If


        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            ut.backupDBTemp()

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            hacerBackup = False
            Throw
        Finally
            cnn.Close()
            ut.backUpDBFinal(hacerBackup)
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
        End Try

    End Sub
    Friend Sub actualizar(_feriado As Feriado)

    End Sub
    Friend Sub actualizar(_subMod As subModulo)

        Dim query = String.Format("UPDATE SUBMODULO SET DESCRIPCION='{0}', MODIFICO_USUARIO='{1}', FECHA_MODIFICACION=#{2}# WHERE CODIGO= '{3}'", _subMod.descripcion, _subMod.modifUser, _subMod.fechaMod.ToShortDateString, _subMod.codigo)

        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            ut.backupDBTemp()

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            hacerBackup = False
            Throw
        Finally
            cnn.Close()
            ut.backUpDBFinal(hacerBackup)
        End Try
    End Sub

    Friend Sub actualizar(_mod As Modulo)

        Dim query = String.Format("UPDATE MODULO SET MEDICO='{0}', ENFERMERIA='{1}', KINESIOLOGIA='{2}', FONOAUDIOLOGIA='{3}', CUIDADOR='{4}', NUTRICION='{5}', MODIFICO_USUARIO='{6}', FECHA_MODIFICACION=#{7}# WHERE CODIGO='{8}'", _mod.topeMedico, _mod.topeEnfermeria, _mod.topeKinesio, _mod.topeFono, _mod.topeCuidador, _mod.topeNutricionista, _mod.modifUser, _mod.fechaMod.ToShortDateString, _mod.codigo)

        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            ut.backupDBTemp()

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            hacerBackup = False
            Throw
        Finally
            cnn.Close()
            ut.backUpDBFinal(hacerBackup)
        End Try
    End Sub

    Friend Sub ACTUALIZAR(_prestacion As Prestacion)

    End Sub

    Friend Sub actualizar(_usuario As Usuario)
        Dim enc As New Encriptador()
        Dim query = String.Format("UPDATE USUARIOS SET APELLIDO='{0}', NOMBRE='{1}', NIVEL={2}, PASS='{3}', MODIFICO_USUARIO='{4}', FECHA_MODIFICACION=#{5}# WHERE DNI='{6}'", _usuario.apellido, _usuario.nombre, _usuario.nivel, enc.encriptar(_usuario.pass), _usuario.modifUser, _usuario.fechaMod.ToShortDateString, _usuario.dni)

        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            ut.backupDBTemp()

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            hacerBackup = False
            Throw
        Finally
            cnn.Close()
            ut.backUpDBFinal(hacerBackup)
        End Try
    End Sub
    Friend Sub actualizar(_zona As Zona)
        Dim enc As New Encriptador()
        Dim query = String.Format("UPDATE ZONAS SET NOMBRE='{0}', EMAIL='{1}', PASS='{2}', PROPIETARIO='{3}', MODIFICO_USUARIO='{4}', FECHA_MODIFICACION=#{5}# WHERE ID={6}",
                                  _zona.nombre, _zona.email, enc.encriptar(_zona.pass), _zona.propietario, _zona.modifUser, _zona.fechaMod.ToShortDateString, _zona.idzona)

        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            ut.backupDBTemp()

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            hacerBackup = False
            Throw
        Finally
            cnn.Close()
            ut.backUpDBFinal(hacerBackup)
        End Try
    End Sub

    Public Function getTable(_tabla As tablas)

        Dim query = "SELECT * FROM " & _tabla.ToString()

        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            da.Fill(ds, _tabla.ToString)
            Return ds.Tables(_tabla.ToString)
        Catch ex As Exception
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try

    End Function

    Public Function feriado(_fecha As Date) As DataTable
        Dim query = String.Format("SELECT * FROM feriados where fecha > 1/1/{0}", _fecha.Year.ToString)
        Dim ds As New DataSet
        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            da.Fill(ds, "FERIADOS")
            Return ds.Tables("FERIADOS")
        Catch ex As Exception
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try

    End Function

    Public Function getLiquidacionesCerradas(_fecha As Date) As DataTable
        Dim hasta As Date
        hasta = New Date(_fecha.Year, _fecha.Month, Date.DaysInMonth(_fecha.Year, _fecha.Month))

        cmd.CommandType = CommandType.Text
        cmd.CommandText = String.Format("SELECT * FROM LIQUIDACION WHERE MES=#{0}#", hasta.ToShortDateString)

        Try
            da.Fill(ds, "LIQ_CERRADAS")
            Return ds.Tables("LIQ_CERRADAS")
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function getEmail() As String
        Dim resultado As String
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT MAIL FROM CONFIG"

        Try
            cnn.Open()
            cmd.ExecuteScalar()
            resultado = cmd.ExecuteScalar()
            Return resultado
        Catch ex As Exception
            Throw
        Finally
            cnn.Close()
        End Try
    End Function

    Public Function getEmailPass() As String
        Dim resultado As String
        Dim encPass As String
        Dim encriptador As New Encriptador()

        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT MAIL_PASS FROM CONFIG"

        Try
            cnn.Open()
            cmd.ExecuteScalar()
            encPass = cmd.ExecuteScalar()
            resultado = encriptador.desencriptar(encPass)
            Return resultado
        Catch ex As Exception
            Throw
        Finally
            cnn.Close()
        End Try
    End Function

    Public Function getEmailObs() As String
        Dim resultado As String

        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT MAIL_TEXTO FROM CONFIG"

        Try
            cnn.Open()
            cmd.ExecuteScalar()
            resultado = cmd.ExecuteScalar()

            Return resultado
        Catch ex As Exception
            Throw
        Finally
            cnn.Close()
        End Try
    End Function


    Public Sub actualizarMail(_mail As String)
        cmd.CommandType = CommandType.Text
        cmd.CommandText = String.Format("UPDATE CONFIG SET MAIL='{0}'", _mail)

        Try
            cnn.Open()
            cmd.ExecuteScalar()
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw
        Finally
            cnn.Close()
        End Try
    End Sub

    Public Sub actualizarMailPass(_pass As String)
        Dim encriptador As New Encriptador()
        Dim encPass = encriptador.encriptar(_pass)
        cmd.CommandType = CommandType.Text
        cmd.CommandText = String.Format("UPDATE CONFIG SET MAIL_PASS='{0}'", encPass)

        Try
            cnn.Open()
            cmd.ExecuteScalar()
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw
        Finally
            cnn.Close()
        End Try
    End Sub

    Public Sub actuaizarMailObs(_obs As String)
        cmd.CommandType = CommandType.Text
        cmd.CommandText = String.Format("UPDATE CONFIG SET MAIL_TEXTO='{0}'", _obs)

        Try
            cnn.Open()
            cmd.ExecuteScalar()
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw
        Finally
            cnn.Close()
        End Try
    End Sub
End Class
