Imports System.Data
Imports System.Data.OleDb
Imports HomeCare

Public Class DB
    Private cnn As OleDbConnection
    Private cmd As OleDbCommand
    Private da As OleDbDataAdapter
    Private ds As DataSet
    Private conStr As String = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}\Google Drive\HomeCare.accdb'", Environ("USERPROFILE"))


    Sub New()
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

    Public Enum tablas
        prestadores
        pacientes
        prestaciones
        visitas
        modulos
    End Enum

    'Public Function getRow(_priKey As Object, _tabla As tablas) As DataTable
    '    Dim query As String

    '    If _tabla = tablas.medicos Then
    '        query = "SELECT * FROM MEDICOS WHERE MATRICULA = " & _priKey
    '    ElseIf _tabla = tablas.pacientes Then
    '        query = "SELECT * FROM PACIENTES WHERE dni = " & _priKey
    '    ElseIf _tabla = tablas.prestaciones Then
    '        query = "SELECT * FROM PRESTACIONES WHERE ID = " & _priKey
    '    ElseIf _tabla = tablas.visitas Then
    '        query = "SELECT * FROM VISITAS WHERE ID = " & _priKey
    '    End If

    '    cmd.CommandType = CommandType.Text
    '    cmd.CommandText = query

    '    Try
    '        da.Fill(ds, "RESULTADO")
    '        Return ds.Tables("RESULTADO")
    '    Catch ex As Exception
    '        Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
    '    End Try

    'End Function

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

End Class
