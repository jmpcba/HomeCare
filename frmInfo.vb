Imports System.IO
Public Class frmInfo
    Private Sub frmInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDB.Text = My.Settings.DBPath.ToString
        lblUsuario.Text = My.Settings.nivel
        lblMod.Text = File.GetLastWriteTime(My.Settings.DBPath).ToString
    End Sub
End Class