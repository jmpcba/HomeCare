Imports System.Data
Imports System.Data.OleDb
Imports HomeCare

Public Class DB
    Private cnn As OleDbConnection
    Private cmd As OleDbCommand
    Private da As OleDbDataAdapter
    Private ds As DataSet
    Private conStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\Users\Manuel\Google Drive\HomeCare.accdb'"

    Sub New()
        cnn = New OleDbConnection(conStr)
        cmd = New OleDbCommand()
        da = New OleDbDataAdapter(cmd)
        ds = New DataSet()
        cmd.Connection = cnn
    End Sub

    Public Enum tablas
        medicos
        pacientes
        prestaciones
        visitas
    End Enum

    Public Function getRow(_priKey As Object, _tabla As tablas) As DataTable
        Dim query As String

        If _tabla = tablas.medicos Then
            query = "SELECT * FROM MEDICOS WHERE MATRICULA = " & _priKey
        ElseIf _tabla = tablas.pacientes Then
            query = "SELECT * FROM PACIENTES WHERE dni = " & _priKey
        ElseIf _tabla = tablas.prestaciones Then
            query = "SELECT * FROM PRESTACIONES WHERE ID = " & _priKey
        End If


        cmd.CommandType = CommandType.Text
        cmd.CommandText = query

        Try
            da.Fill(ds, "RESULTADO")
            Return ds.Tables("RESULTADO")
        Catch ex As Exception
            Throw New Exception("ERROR DE BASE DE DATOS: " & ex.Message)
        End Try

    End Function

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

    Friend Sub insertar(visita As Visita)
        Dim query = "INSERT INTO VISITAS VALUES ()"
    End Sub

End Class
