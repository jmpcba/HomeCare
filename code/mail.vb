﻿Imports System.Net.Mail
Imports System.Net
Public Class Mail

    Dim client As SmtpClient = New SmtpClient()
    Dim NetworkCred As NetworkCredential = New System.Net.NetworkCredential()

    Public Sub New()
        Dim db As New DB
        client.EnableSsl = True
        client.Host = "smtp.gmail.com"
        client.Port = 587

        NetworkCred.UserName = db.getEmail
        NetworkCred.Password = db.getEmailPass

        client.UseDefaultCredentials = True
        client.Credentials = NetworkCred
    End Sub

    Public Sub send(_liq As Liquidacion)

        Try
            Dim mail As String = My.Resources.mailTemplate
            Dim mm As MailMessage = New MailMessage()

            mail = mail.Replace("[MES]", MonthName(_liq.mes.Month))
            mail = mail.Replace("[YEAR]", _liq.mes.Year)
            mail = mail.Replace("[HS_LAV]", _liq.hsNormales)
            mail = mail.Replace("[HS_FER]", _liq.hsFeriado)
            mail = mail.Replace("[MONTO_LAV]", _liq.importeNormal)
            mail = mail.Replace("[MONTO_FER]", _liq.importeFeriado)
            mail = mail.Replace("[MONTO_FIJO]", _liq.montoFijo)
            mail = mail.Replace("[OBS]", _liq.observaciones)
            mail = mail.Replace("[APELLIDO]", _liq.prestador.apellido.ToUpper)
            mail = mail.Replace("[NOMBRE]", _liq.prestador.nombre.ToUpper)

            mm.From = New MailAddress("homecarePrueba@gmail.com")
            mm.Subject = "Liquidacion HomeCare " & MonthName(_liq.mes.Month)
            mm.IsBodyHtml = True
            mm.Body = mail
            mm.To.Add(New MailAddress(_liq.prestador.email))
            client.Send(mm)
        Catch ex As Exception
            Throw New Exception("Error enviando mail: " & ex.Message)
        End Try
    End Sub


End Class
