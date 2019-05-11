Imports System.Data.OleDb
Imports System.Data

Public Class dbHelper

    Private cnn As OleDbConnection
    Private cmd As OleDbCommand
    Private da As OleDbDataAdapter
    Private ds As DataSet
    Private conStr As String
    Private CI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture

    Public Sub New()
        Me.conStr = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}'", My.Settings.DBPath)
        cnn = New OleDbConnection(conStr)
        cmd = New OleDbCommand()
        da = New OleDbDataAdapter(cmd)
        ds = New DataSet()
        cmd.Connection = cnn
    End Sub

    Public Function ejecutarSelect(SQL As String) As DataTable
        cmd.CommandText = SQL
        cmd.CommandType = CommandType.Text

        Try
            da.Fill(ds, "RESULTADO")
            Return ds.Tables("RESULTADO")
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub ejecutarNonQuery(SQL As String)
        cmd.CommandType = CommandType.Text
        cmd.CommandText = SQL
        Try
            cnn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw
        Finally
            cnn.Close()
        End Try
    End Sub

    Public Function ejecutarEscalar(SQL As String) As Object
        cmd.CommandType = CommandType.Text
        cmd.CommandText = SQL
        Try
            cnn.Open()
            Return cmd.ExecuteScalar()
        Catch ex As Exception
            Throw
        Finally
            cnn.Close()
        End Try
    End Function

    Public Sub ejecutarNonQueryMultiple(SQL As List(Of String))
        cmd.CommandType = CommandType.Text
        Try
            cnn.Open()
            For Each S In SQL
                cmd.CommandText = S
                cmd.ExecuteNonQuery()
            Next
        Catch ex As Exception
            Throw
        Finally
            cnn.Close()
        End Try
    End Sub

End Class