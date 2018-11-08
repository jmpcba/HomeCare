Imports System.Data
Imports System.Data.OleDb
Imports HomeCare

Public Class DB
    Private cnn As OleDbConnection
    Private cmd As OleDbCommand
    Private da As OleDbDataAdapter
    Private ds As DataSet
    Private conStr As String = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}'", My.Settings.DBPath)

    Public Enum tablas
        prestadores
        pacientes
        prestaciones
        visitas
        modulo
        subModulo
        feriados
    End Enum

    Public Enum liquidaciones
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

    Friend Function liquidacion(_fecha As Date, _liq As liquidaciones) As DataTable
        Dim desde As String
        Dim hasta As String

        desde = String.Format("1/{0}/{1}", _fecha.Month, _fecha.Year)
        hasta = String.Format("{0}/{1}/{2}", Date.DaysInMonth(_fecha.Year, _fecha.Month), _fecha.Month, _fecha.Year)

        cmd.CommandType = CommandType.StoredProcedure
        If _liq = liquidaciones.detalle Then
            cmd.CommandText = "QUERY_DETALLES"
        ElseIf _liq = liquidaciones.medico Then
            cmd.CommandText = "QUERY_MEDICOS"
        ElseIf _liq = liquidaciones.paciente Then
            cmd.CommandText = "QUERY_PACIENTES"
            cmd.Parameters.AddWithValue("P_CUIT", desde)
        End If

        cmd.Parameters.AddWithValue("DESDE", desde)
        cmd.Parameters.AddWithValue("HASTA", hasta)

        Try
            da.Fill(ds, "LIQUIDACION")
            Return ds.Tables("LIQUIDACION")
        Catch ex As Exception
            Throw New Exception("Error DE BASE DE DATOS: " & ex.Message)
        End Try

    End Function

    Friend Sub eliminar(_visita As Practica)
        Try
            'Dim query = "DELETE FROM VISITAS WHERE ID=" & _visita.id

            cmd.CommandType = CommandType.Text
            'cmd.CommandText = query

            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw
        Finally
            cnn.Close()
        End Try
    End Sub

    Friend Sub eliminar(_visita As Practica, _id As Integer)
        'REVISAR MAS ADELANTE POR AHORA EL OBJETO VISITA SE USA SOLO PARA QUE SE SEPA QUE ESTOY ELIMINANDO UNA VISITA
        'SE ELIMINA LA VISITA _id
        Try
            Dim query = "DELETE FROM VISITAS WHERE ID=" & _id

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

    Public Function getPaciente(_dni As Object) As DataTable
        Dim query = "SELECT * FROM PACIENTES where dni = " & _dni

        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            da.Fill(ds, "PACIENTES")
            Return ds.Tables("PACIENTES")
        Catch ex As Exception
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try

    End Function

    Friend Sub insertar(_visita As Practica)
        Try
            Dim query = String.Format("INSERT INTO PRACTICAS (CUIT, AFILIADO, MODULO, SUB_MODULO, COD_PRESTACION, HS_NORMALES, HS_FERIADO, FECHA_PRACTICA, FECHA_INICIO, OBSERVACIONES, CARGO_USUARIO, FECHA_CARGA, MODIFICO_USUARIO, FECHA_MODIFICACION) VALUES ('{0}', {1}, {2}, {3}, {4}, {5}, {6}, '{7}', '{8}', '{9}', {10}, '{11}', {12}, '{13}' )",
                                      _visita.prestador.cuit, _visita.paciente.afiliado, _visita.modulo, _visita.subModulo,
                                      _visita.prestacion.codigo, _visita.hsSemana, _visita.hsFeriado, _visita.fecha.ToShortDateString,
                                      DateTime.Today.ToShortDateString, _visita.observaciones, _visita.creoUser,
                                      _visita.fechaCarga.ToShortDateString, _visita.modifUser, _visita.fechaMod.ToShortDateString)

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

    Friend Sub insertar(_prestacion As Prestacion)

    End Sub

    Friend Sub insertar(_paciente As Paciente)

    End Sub

    Friend Sub insertar(_prestador As Prestador)

    End Sub

    Friend Sub insertar(_subMod As subModulo)
        Dim query = String.Format("INSERT INTO SUBMODULO (CODIGO, DESCRIPCION, CARGO_USUARIO, FECHA, MODIFICO_USUARIO, FECHA_MODIFICACION) VALUES ({0}, '{1}', {2}, #{3}#, {4}, #{5}#)", _subMod.codigo, _subMod.descripcion, _subMod.creoUser, _subMod.fechaCarga.ToShortDateString, _subMod.modifUser, _subMod.fechaMod.ToShortDateString)

        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw
        Finally
            cnn.Close()
        End Try
    End Sub

    Friend Sub insertar(_mod As Modulo)
        Dim query = String.Format("INSERT INTO MODULO VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, #{7}#, {8}, #{9}#)", _mod.codigo, _mod.topeMedico, _mod.topeEnfermeria, _mod.topeKinesio, _mod.topeFono, _mod.topeCuidador, _mod.creoUser, _mod.fechaCarga.ToShortDateString, _mod.modifUser, _mod.fechaMod.ToShortDateString)

        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw
        Finally
            cnn.Close()
        End Try
    End Sub

    Friend Sub actualizar(_paciente As Paciente)

    End Sub

    Friend Sub actualizar(_prestador As Prestador)

    End Sub
    Friend Sub actualizar(_prestacion As Prestacion)

    End Sub
    Friend Sub actualizar(_subMod As subModulo)
        Dim query = String.Format("UPDATE SUBMODULO SET DESCRIPCION='{0}', MODIFICO_USUARIO={1}, FECHA_MODIFICACION=#{2}# WHERE CODIGO = {3}", _subMod.descripcion, _subMod.modifUser, _subMod.fechaMod.ToShortDateString, _subMod.codigo)

        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw
        Finally
            cnn.Close()
        End Try
    End Sub

    Friend Sub actualizar(_mod As Modulo)
        Dim query = String.Format("UPDATE MODULO SET MEDICO={0}, ENFERMERIA={1}, KINESIO={2}, FONO={3}, CUIDADOR={4}, MODIFICO_USUARIO={5}, FECHA_MODIFICACION=#{6}# WHERE CODIGO={7}", _mod.topeMedico, _mod.topeEnfermeria, _mod.topeKinesio, _mod.topeFono, _mod.topeCuidador, _mod.modifUser, _mod.fechaMod.ToShortDateString, _mod.codigo)

        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw
        Finally
            cnn.Close()
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

        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            da.Fill(ds, "FERIADOS")
            Return ds.Tables("FERIADOS")
        Catch ex As Exception
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try

    End Function

End Class
