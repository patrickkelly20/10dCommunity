Imports System.Web
Imports System.Web.Mail
Imports System
Public Class MailSender
    Public Shared Function SendEmail(ByVal strServer As String, ByVal strPort As String, ByVal pGmailEmail As String, ByVal pGmailPassword As String, ByVal pTo As String, ByVal pSubject As String, ByVal pBody As String, ByVal pFormat As System.Web.Mail.MailFormat,
     ByVal pAttachmentPath As String, ByVal pCC As String, ByVal pBCC As String) As Boolean
        Try
            Dim myMail As New System.Web.Mail.MailMessage()
            Dim my2Mail As New System.Net.Mail.MailMessage()
            myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", strServer)
            myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", strPort)
            myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2")
            'sendusing: cdoSendUsingPort, value 2, for sending the message using  
            'the network. 

            'smtpauthenticate: Specifies the mechanism used when authenticating  
            'to an SMTP  
            'service over the network. Possible values are: 
            '- cdoAnonymous, value 0. Do not authenticate. 
            '- cdoBasic, value 1. Use basic clear-text authentication.  
            'When using this option you have to provide the user name and password  
            'through the sendusername and sendpassword fields. 
            '- cdoNTLM, value 2. The current process security context is used to  
            ' authenticate with the service. 
            myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1")
            'Use 0 for anonymous 
            myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", pGmailEmail)
            myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", pGmailPassword)
            myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true")
            myMail.From = pGmailEmail
            myMail.[To] = pTo
            myMail.Subject = pSubject
            myMail.BodyFormat = pFormat
            myMail.Body = pBody
            If pAttachmentPath.Trim() <> "" Then
                Dim attmnts() As String = pAttachmentPath.Split(",")
                For Each strTemp As String In attmnts
                    If strTemp.Trim = "" Then
                    Else
                        Dim MyAttachment As New MailAttachment(strTemp.Trim)
                        Dim my2Attachment As New System.Net.Mail.Attachment(strTemp.Trim)
                        my2Mail.Attachments.Add(my2Attachment)
                        myMail.Attachments.Add(MyAttachment)
                    End If
                    '
                Next
            End If
            'Dim my2Mail As New System.Net.Mail.MailMessage()
            Dim fromAddress As New System.Net.Mail.MailAddress(pGmailEmail)
            Dim toAddress As New System.Net.Mail.MailAddress(pTo)
            my2Mail.From = fromAddress
            my2Mail.To.Add(toAddress)
            If Not (pCC = "") Then
                Dim strCC As String() = pCC.Split(";")
                For Each strTemp As String In strCC
                    Dim ccAddress As New System.Net.Mail.MailAddress(strTemp)
                    my2Mail.CC.Add(ccAddress)
                Next
            End If
            If Not (pBCC = "") Then
                Dim strBCC As String() = pBCC.Split(";")
                For Each strTemp As String In strBCC
                    Dim bccAddress As New System.Net.Mail.MailAddress(strTemp)
                    my2Mail.Bcc.Add(bccAddress)
                Next
            End If
            my2Mail.Subject = pSubject
            'Dim my2Attachment As New System.Net.Mail.Attachment()

            Dim newServer As System.Net.Mail.SmtpClient = New Net.Mail.SmtpClient(strServer, strPort)
            Dim newNetCredential As New System.Net.NetworkCredential(pGmailEmail, pGmailPassword)
            newServer.Credentials = newNetCredential

            newServer.EnableSsl = True
            newServer.Send(my2Mail)
            'System.Web.Mail.SmtpMail.SmtpServer = strServer & ":" & strPort
            'System.Web.Mail.SmtpMail.Send(myMail)
            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function
End Class

