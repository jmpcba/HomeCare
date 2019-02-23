﻿Imports System.Net.Mail
Imports System.Net
Public Class Mail

    Dim liqui As Liquidacion
    Dim client As SmtpClient = New SmtpClient()
    Dim NetworkCred As NetworkCredential = New System.Net.NetworkCredential()

    Public Sub New()
        Dim db As New DB

        With client
            .EnableSsl = True
            .Port = 587
            .UseDefaultCredentials = True
            .Credentials = NetworkCred
        End With
    End Sub

    Public Sub send(_liq As Liquidacion)

        Try
            Dim zona As New Zona
            Dim mail As String = My.Resources.mailTemplate
            Dim mm As MailMessage = New MailMessage()
            Dim totalFinal As Decimal

            mail = mail.Replace("[MES]", MonthName(_liq.mes.Month))
            mail = mail.Replace("[YEAR]", _liq.mes.Year)
            totalFinal = _liq.montoFijo + _liq.importeFeriado + _liq.importeNormal + _liq.importeDiferencial
            mail = mail.Replace("[MONTO_TOTAL]", totalFinal.ToString("F"))
            mail = mail.Replace("[OBS]", _liq.observaciones)
            mail = mail.Replace("[APELLIDO]", _liq.prestador.apellido.ToUpper)
            mail = mail.Replace("[NOMBRE]", _liq.prestador.nombre.ToUpper)
            mail = mail.Replace("[SERVICIO]", _liq.prestador.obraSocial)

            zona.idzona = _liq.prestador.zona
            Dim mailFrom = zona.email.ToLower

            If mailFrom.EndsWith("gmail.com") Then
                client.Host = "smtp.gmail.com"
            ElseIf mailFrom.EndsWith("hotmail.com") Or mailFrom.EndsWith("outlook.com") Then
                client.Host = "smtp.live.com"
            End If

            NetworkCred.UserName = zona.email
            NetworkCred.Password = zona.pass

            mm.From = New MailAddress(mailFrom)
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
