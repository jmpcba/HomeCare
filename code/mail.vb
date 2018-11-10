﻿Imports System.Net.Mail
Imports System.Net
Public Class Mail

    Dim client As SmtpClient = New SmtpClient()
    Dim NetworkCred As NetworkCredential = New System.Net.NetworkCredential()

    Public Sub New()
        client.EnableSsl = True
        client.Host = "smtp.gmail.com"
        client.Port = 587
        NetworkCred.UserName = "jmpcba@gmail.com"
        NetworkCred.Password = "Newuser1!"
        client.UseDefaultCredentials = True
        client.Credentials = NetworkCred
    End Sub

    Public Sub send(_liq As Liquidacion)
        'Dim filePath As String = My.Application.Info.DirectoryPath & "\mailTemplate.html"
        Dim filePath As String = "C:\Users\jmpcb\Documents\GitHub\HomeCare\code\mailTemplate.html"
        Try
            Dim sr As New System.IO.StreamReader(filePath)
            Dim mail As String = sr.ReadToEnd
            Dim mm As MailMessage = New MailMessage()

            mail = mail.Replace("[MES]", MonthName(_liq.mes.Month))
            mail = mail.Replace("[YEAR]", _liq.mes.Year)
            mail = mail.Replace("[HS_LAV]", _liq.hsNormales)
            mail = mail.Replace("[HS_FER]", _liq.hsFeriado)
            mail = mail.Replace("[MONTO_LAV]", _liq.importeNormal)
            mail = mail.Replace("[MONTO_FER]", _liq.importeFeriado)
            mail = mail.Replace("[MONTO_FIJO]", _liq.montoFijo)

            mm.From = New MailAddress("homecarePrueba@gmail.com")
            mm.Subject = "Liquidacion HomaCare " & MonthName(_liq.mes.Month)
            mm.IsBodyHtml = True
            mm.Body = mail
            mm.To.Add(New MailAddress("jmpcba@gmail.com"))
            client.Send(mm)
        Catch ex As Exception
            Throw
        End Try

    End Sub


End Class
