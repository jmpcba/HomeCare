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

    Friend Function liquidacion(_fecha As Date) As DataTable
        Dim desde As String
        Dim hasta As String

        desde = String.Format("{0}/1/{1}", _fecha.Month, _fecha.Year)
        hasta = String.Format("{1}/{0}/{2}", Date.DaysInMonth(_fecha.Year, _fecha.Month), _fecha.Month, _fecha.Year)

        Dim query = String.Format("SELECT PACIENTES.AFILIADO, PACIENTES.APELLIDO AS PACIENTE, PRESTADORES.CUIT AS CUIT_PRESTADOR, PRESTADORES.APELLIDO AS APELLIDO_PRESTADOR, PRESTACIONES.DESCRIPCION AS PRESTACION, MODULO.CODIGO AS MODULO, SUBMODULO.DESCRIPCION AS SUBMODULO, PRACTICAS.FECHA_PRACTICA, PRACTICAS.HS_NORMALES AS HORAS_Lav, PRACTICAS.HS_FERIADO AS HORAS_FERIADOS
        From PRESTACIONES, SUBMODULO INNER Join (PRESTADORES INNER Join (PACIENTES INNER Join (MODULO INNER Join PRACTICAS On Modulo.codigo = PRACTICAS.MODULO) ON PACIENTES.AFILIADO = PRACTICAS.AFILIADO) ON PRESTADORES.CUIT = PRACTICAS.CUIT) ON SUBMODULO.CODIGO = PRACTICAS.SUB_MODULO Where PRACTICAS.FECHA_PRACTICA > #{0}# And PRACTICAS.FECHA_PRACTICA < #{1}#", desde, hasta)

        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            da.Fill(ds, "PRACTICAS")
            Return ds.Tables("PRACTICAS")
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
