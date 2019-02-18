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
        liquidacionCerrada
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

        cmd.CommandType = CommandType.Text
        cmd.CommandText = String.Format("SELECT PRACTICAS.ID, PRACTICAS.CUIT, PRESTADORES.APELLIDO AS [APELLIDO PRESTADOR], PRESTADORES.NOMBRE AS [NOMBRE PRESTADOR], PRESTADORES.LOCALIDAD, PRESTADORES.ESPECIALIDAD, PRESTADORES.SERVICIO, PRACTICAS.AFILIADO, PACIENTES.APELLIDO AS [APELLIDO PACIENTE], PACIENTES.NOMBRE AS [NOMBRE PACIENTE], PRACTICAS.FECHA_PRACTICA AS [FECHA PRACTICA], MODULO.CODIGO AS MODULO, SUBMODULO.CODIGO AS [CODIGO SUBMODULO], SUBMODULO.DESCRIPCION AS [DESCRIPCION SUBMODULO], PRACTICAS.HS_NORMALES AS [HS LUN a VIE], PRACTICAS.HS_FERIADO AS [HS SAB DOM y FER], PRACTICAS.HS_DIFERENCIAL AS DIFERENCIAL, [HS_NORMALES]*[MONTO_SEMANA] AS [$ LUN a VIE], [HS_FERIADO]*[MONTO_FERIADO] AS [$ SAB DOM y FER], [HS_DIFERENCIAL]*[PORCENTAJE] AS [$ DIF], PRESTADORES.MONTO_FIJO AS [MONTO FIJO]
                            FROM SUBMODULO INNER JOIN (PACIENTES INNER JOIN (MODULO INNER JOIN (PRESTADORES INNER JOIN PRACTICAS ON PRESTADORES.ID = PRACTICAS.ID_PREST) ON MODULO.CODIGO = PRACTICAS.MODULO) ON PACIENTES.AFILIADO = PRACTICAS.AFILIADO) ON SUBMODULO.CODIGO = PRACTICAS.SUB_MODULO
                            WHERE (((PRACTICAS.FECHA_PRACTICA) Between #{0}# And #{1}#))", desde, hasta)

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

        cmd.CommandType = CommandType.Text

        If _liq = tiposLiquidacion.medico Then

            'USAR QUERY_SUMATORIA_MEDICOS EN ACCESS PARA GENERAR SQL
            cmd.CommandText = String.Format("SELECT PRACTICAS.ID_PREST, PRESTADORES.CUIT, PRESTADORES.APELLIDO AS [APELLIDO PRESTADOR], PRESTADORES.NOMBRE AS [NOMBRE PRESTADOR], PRESTADORES.SERVICIO, PRESTADORES.ESPECIALIDAD AS ESPECIALIDAD, PRESTADORES.LOCALIDAD AS LOCALIDAD, Sum(PRACTICAS.HS_NORMALES) AS [HS LUN a VIE], Sum(PRACTICAS.HS_FERIADO) AS [HS SAB DOM y FER], Sum(PRACTICAS.HS_DIFERENCIAL) AS DIFERENCIAL, Sum([HS_NORMALES]+[HS_FERIADO]+[HS_DIFERENCIAL]) AS [TOTAL HORAS], PRESTADORES.MONTO_FIJO AS [MONTO FIJO], Sum([HS_NORMALES]*[MONTO_SEMANA]) AS [$ LUN a VIE], IIF([MONTO_FERIADO]<>0, Sum([HS_FERIADO]*[MONTO_FERIADO]), Sum([HS_FERIADO]*[MONTO_SEMANA])) AS [$ SAB DOM y FER], Sum([HS_DIFERENCIAL]*[PORCENTAJE]) AS [$ DIF], [$ DIF] + [$ LUN a VIE] + [$ SAB DOM y FER] + [MONTO FIJO] AS [$ TOTAL]
                                            FROM PRESTADORES INNER JOIN PRACTICAS ON PRESTADORES.ID = PRACTICAS.ID_PREST
                                            WHERE (((PRACTICAS.FECHA_PRACTICA) Between #{0}# And #{1}#))
                                            GROUP BY PRACTICAS.ID_PREST, PRESTADORES.CUIT, PRESTADORES.APELLIDO, PRESTADORES.NOMBRE, PRESTADORES.SERVICIO, PRESTADORES.ESPECIALIDAD, PRESTADORES.LOCALIDAD, PRESTADORES.MONTO_FIJO, PRESTADORES.MONTO_SEMANA, PRESTADORES.MONTO_FERIADO", desde, hasta)

        ElseIf _liq = tiposLiquidacion.paciente Then

            'USAR QUERY_SUMATORIA_PACIENTE EN ACCESS PARA GENERAR SQL
            cmd.CommandText = String.Format("Select PACIENTES.AFILIADO, PACIENTES.APELLIDO As [APELLIDO PACIENTE], PACIENTES.NOMBRE As [NOMBRE PACIENTE], Sum(PRACTICAS.HS_NORMALES) As [HS LUN a VIE], Sum(PRACTICAS.HS_FERIADO) As [HS SAB DOM y FER], Sum(PRACTICAS.HS_DIFERENCIAL) AS DIFERENCIAL
                                From PACIENTES INNER JOIN (PRESTADORES INNER JOIN PRACTICAS ON PRESTADORES.ID = PRACTICAS.ID_PREST) ON PACIENTES.AFILIADO = PRACTICAS.AFILIADO
                                WHERE (((PRACTICAS.FECHA_PRACTICA) Between #{0}# And #{1}#))
                                GROUP BY PACIENTES.AFILIADO, PACIENTES.APELLIDO, PACIENTES.NOMBRE", desde, hasta)

        ElseIf _liq = tiposLiquidacion.liquidacionCerrada Then

            cmd.CommandText = String.Format("SELECT LIQUIDACION.ID_PREST, LIQUIDACION.CUIT, PRESTADORES.APELLIDO, PRESTADORES.NOMBRE, LIQUIDACION.LOCALIDAD, LIQUIDACION.ESPECIALIDAD, LIQUIDACION.HS_NORMALES AS [HS LUN a VIE], LIQUIDACION.HS_FERIADOS AS [HS SAB DOM Y FER], LIQUIDACION.HS_DIFERENCIAL AS DIFERENCIAL, [HS_NORMALES]+[HS_FERIADOS]+[HS_DIFERENCIAL] AS [TOTAL HORAS], LIQUIDACION.MONTO_FIJO AS [MONTO FIJO], LIQUIDACION.IMPORTE_NORMAL AS [$ LUN a VIE], LIQUIDACION.IMPORTE_FERIADO AS [$ SAB DOM y FER], LIQUIDACION.IMPORTE_DIFERENCIAL AS [$ DIF], [$ DIF]+[$ LUN a VIE]+[$ SAB DOM y FER]+[MONTO FIJO] AS [$ TOTAL]
                                FROM LIQUIDACION INNER JOIN PRESTADORES ON LIQUIDACION.ID_PREST = PRESTADORES.ID
                                WHERE (((LIQUIDACION.MES)=#{0}#))", hasta)
        End If

        Try
            'LLENAR EL DETALLE
            da.Fill(ds, "QUERY")
            ds.Tables("QUERY").Columns.Add("ESTADO")
            If _liq = tiposLiquidacion.medico Then
                Dim liquidacionesCerradas As New List(Of DataRow)
                If ds.Tables("QUERY").Rows.Count > 0 Then
                    'CONTROLAR SI EXISTEN LIQUIDACIONES PARA ESE MEDICO

                    For Each r As DataRow In ds.Tables("QUERY").Rows
                        Dim id = r("ID_PREST")

                        If ut.validarLiquidacion(id, _fecha) Then
                            liquidacionesCerradas.Add(r)
                        Else
                            r("ESTADO") = "PENDIENTE"
                        End If
                    Next

                    For Each r As DataRow In liquidacionesCerradas
                        ds.Tables("QUERY").Rows.Remove(r)
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

        cmd.CommandType = CommandType.Text
        cmd.CommandText = String.Format("SELECT PRACTICAS.ID, PRACTICAS.CUIT, PRACTICAS.AFILIADO, PACIENTES.APELLIDO AS [APELLIDO PACIENTE], PACIENTES.NOMBRE AS [NOMBRE PACIENTE], PRACTICAS.FECHA_PRACTICA AS [FECHA PRACTICA], MODULO.CODIGO AS MODULO, SUBMODULO.CODIGO AS [CODIGO SUBMODULO], SUBMODULO.DESCRIPCION AS [DESCRIPCION SUBMODULO], PRACTICAS.HS_NORMALES AS [HS LUN a VIE], PRACTICAS.HS_FERIADO AS [HS SAB DOM y FER], PRACTICAS.HS_DIFERENCIAL AS DIFERENCIAL, [HS_NORMALES]*[MONTO_SEMANA] AS [$ LUN a VIE], [HS_FERIADO]*[MONTO_FERIADO] AS [$ SAB DOM Y  FER], [HS_DIFERENCIAL]*[PORCENTAJE] AS [$ DIFERENCIAL]
                                        FROM SUBMODULO INNER JOIN (PACIENTES INNER JOIN (MODULO INNER JOIN (PRESTADORES INNER JOIN PRACTICAS ON PRESTADORES.ID = PRACTICAS.ID_PREST) ON MODULO.CODIGO = PRACTICAS.MODULO) ON PACIENTES.AFILIADO = PRACTICAS.AFILIADO) ON SUBMODULO.CODIGO = PRACTICAS.SUB_MODULO
                                        WHERE (((PRACTICAS.FECHA_PRACTICA) Between #{0}# And #{1}#) AND ((PRACTICAS.ID_PREST)={2}))", desde, hasta, _id)

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

        cmd.CommandType = CommandType.Text
        cmd.CommandText = String.Format("SELECT PRACTICAS.ID, PRACTICAS.AFILIADO, PRACTICAS.CUIT, PRESTADORES.APELLIDO AS [APELLIDO PRESTADOR], PRESTADORES.NOMBRE AS [NOMBRE PRESTADOR], PRACTICAS.FECHA_PRACTICA AS [FECHA PRACTICA], MODULO.CODIGO AS MODULO, SUBMODULO.CODIGO AS [CODIGO SUBMODULO], SUBMODULO.DESCRIPCION AS [DESCRIPCION SUBMODULO], PRACTICAS.HS_NORMALES AS [HS LUN a VIE], PRACTICAS.HS_FERIADO AS [HS SAB DOM y FER], PRACTICAS.HS_DIFERENCIAL AS DIFERENCIAL, [HS_NORMALES]*[MONTO_SEMANA] AS [$ LUN a VIE], [HS_FERIADO]*[MONTO_FERIADO] AS [$ SAB DOM y FER], [HS_DIFERENCIAL]*[PORCENTAJE] AS [$ DIFERENCIAL], PRESTADORES.ID AS ID_PRESTADOR
                            FROM SUBMODULO INNER JOIN (PACIENTES INNER JOIN (MODULO INNER JOIN (PRESTADORES INNER JOIN PRACTICAS ON PRESTADORES.ID = PRACTICAS.ID_PREST) ON MODULO.CODIGO = PRACTICAS.MODULO) ON PACIENTES.AFILIADO = PRACTICAS.AFILIADO) ON SUBMODULO.CODIGO = PRACTICAS.SUB_MODULO
                            WHERE (((PRACTICAS.AFILIADO)='{0}') AND ((PRACTICAS.FECHA_PRACTICA) Between #{1}# And #{2}#))", _id, desde, hasta)

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

    Friend Function insertar(_practicas As List(Of Practica)) As List(Of ResultadoCargaPracticas)
        Dim errores As New List(Of ResultadoCargaPracticas)

        ut.backupDBTemp()
        cmd.CommandType = CommandType.Text
        cnn.Open()

        For Each p As Practica In _practicas
            Try
                Dim query = String.Format("INSERT INTO PRACTICAS (CUIT, AFILIADO, MODULO, SUB_MODULO, HS_NORMALES, HS_FERIADO, FECHA_PRACTICA, FECHA_INICIO, OBSERVACIONES, CARGO_USUARIO, FECHA_CARGA, MODIFICO_USUARIO, FECHA_MODIFICACION, ID_PREST, HS_DIFERENCIAL) VALUES ('{0}', '{1}', '{2}', '{3}', {4}, {5}, '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', {14})",
                                      p.prestador.cuit, p.paciente.afiliado, p.modulo, p.subModulo,
                                      p.hsSemana, p.hsFeriado, p.fecha.ToShortDateString,
                                      DateTime.Today.ToShortDateString, p.observaciones, p.creoUser,
                                      p.fechaCarga.ToShortDateString, p.modifUser, p.fechaMod.ToShortDateString, p.prestador.id, p.hsDif)

                cmd.CommandText = query
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim msg As String

                If ex.Message.Contains("duplicate values in the index") Or ex.Message.Contains("valores duplicados en el índice") Then
                    msg = "Ya existe una practica igual para este dia"
                Else
                    msg = ex.Message
                End If

                errores.Add(New ResultadoCargaPracticas(p.fila, msg))
            End Try
        Next

        cnn.Close()

        Return errores
    End Function


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

            If ex.Message.Contains("duplicate values in the index") Or ex.Message.Contains("valores duplicados en el índice") Then
                Throw New ExcepcionDeSistema("Esta liquidacion ya esta cerrada")
            Else
                Throw
            End If

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
