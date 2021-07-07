Imports System.Net.Mail
Imports System.Net
Imports System.IO
Imports System.ComponentModel
Imports System.Xml
Imports System.Xml.XPath
Imports System.Xml.Serialization


Public Class frmtEncryptSendMail
    Dim objServer As New SmtpClient
    Dim m As MailMessage = New MailMessage()
    Private Sub frmSendMail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New(ByVal strPath As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lblAttachment.Text = strPath
    End Sub
    Private Sub SendMail()
        Try
            Dim blnSend As Boolean = True

            If txtTo.Text = "" Then
                MessageBox.Show("Please enter an address in the To: section", "Missing To: Address", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
            If txtMessage.Text = "" Then
                Dim result As System.Windows.Forms.DialogResult
                result = MessageBox.Show("The message body is empty.  Do you still want to send the message?", "Message Body empty", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                If result = Windows.Forms.DialogResult.OK Then
                    blnSend = True
                Else
                    blnSend = False
                End If
            End If
            If blnSend Then
                If txtSubject.Text = "" Then
                    Dim result2 As System.Windows.Forms.DialogResult
                    result2 = MessageBox.Show("The Subject of the message is blank.  Do you want to send the message anyway?", "Message Subject Blank", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    If result2 = Windows.Forms.DialogResult.OK Then
                        blnSend = True
                    Else
                        blnSend = False
                    End If
                End If
            End If
            If blnSend Then
                If objOptions.strSMTPserver.ToUpper.Contains("GMAIL.COM") Then 'Or objOptions.strSMTPserver.ToUpper.Contains("HOTMAIL.COM") Then


                    'Dim [to] As New List(Of String)()
                    'Dim strSubject As String = txtSubject.Text
                    'If txtTo.Text.Split(";").Length > 1 Then
                    '    Dim arr As String() = txtTo.Text.Split(";")
                    '    For Each str As String In arr
                    '        [to].Add(str.Trim)
                    '        If Not objOptions.strAddressList.Contains(str) Then
                    '            objOptions.strAddressList &= str & "; "
                    '        End If
                    '    Next

                    'Else
                    '    [to].Add(txtTo.Text.Trim)

                    'End If
                    'For Each strTemp As String In [to]
                    '    m.To.Add(strTemp)
                    '    If Not objOptions.strAddressList.Contains(strTemp) Then
                    '        objOptions.strAddressList &= strTemp & "; "
                    '    End If
                    'Next
                    Dim boolSuccess As Boolean = False
                    boolSuccess = MailSender.SendEmail(objOptions.strSMTPserver, objOptions.intPort.ToString, objOptions.strEmailAddress, objOptions.strSMTPpassword, txtTo.Text.Trim, txtSubject.Text.Trim, txtMessage.Text.Trim, Web.Mail.MailFormat.Text, lblAttachment.Text, txtCC.Text, txtBcc.Text)
                    If boolSuccess Then
                        MessageBox.Show("Message sent Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.Close()
                    Else
                        MessageBox.Show("Error sending message", "Message Not Sent", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        'Me.Close()
                    End If
                Else
                    Dim boolSuccess As Boolean = False
                    boolSuccess = MailSender.SendEmail(objOptions.strSMTPserver, objOptions.intPort.ToString, objOptions.strEmailAddress, objOptions.strSMTPpassword, txtTo.Text.Trim, txtSubject.Text.Trim, txtMessage.Text.Trim, Web.Mail.MailFormat.Text, lblAttachment.Text, txtCC.Text, txtBcc.Text)
                    If boolSuccess Then
                        MessageBox.Show("Message sent Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.Close()
                    Else
                        MessageBox.Show("Error sending message", "Message Not Sent", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        'Me.Close()
                    End If
                End If
            Else
                objServer.Timeout = 300000000
                'objServer.Host = objOptions.strSMTPserver
                objServer.Port = objOptions.intPort
                objServer.EnableSsl = objOptions.blnSSL
                objServer.UseDefaultCredentials = False
                objServer.DeliveryMethod = SmtpDeliveryMethod.Network
                objServer.Credentials = New NetworkCredential(objOptions.strSMTPuser, objOptions.strSMTPpassword)
                'Send message here or build message object here
                'Continue sending message here
                ' AddHandler objServer.SendCompleted, AddressOf sc_SendCompleted

                m.From = New MailAddress(objOptions.strEmailAddress)
                Dim [to] As New List(Of String)()
                Dim strSubject As String = txtSubject.Text
                If txtTo.Text.Split(";").Length > 1 Then
                    Dim arr As String() = txtTo.Text.Split(";")
                    For Each str As String In arr
                        [to].Add(str.Trim)
                        If Not objOptions.strAddressList.Contains(str) Then
                            objOptions.strAddressList &= str & "; "
                        End If
                    Next

                Else
                    [to].Add(txtTo.Text.Trim)

                End If
                For Each strTemp As String In [to]
                    m.To.Add(strTemp)
                    If Not objOptions.strAddressList.Contains(strTemp) Then
                        objOptions.strAddressList &= strTemp & "; "
                    End If
                Next
                If Not txtCC.Text = String.Empty Then
                    Dim [cc] As New List(Of String)()
                    If txtCC.Text.Split(";").Length > 1 Then
                        Dim arr As String() = txtCC.Text.Split(";")
                        For Each str As String In arr
                            [cc].Add(str.Trim)
                        Next
                    Else
                        [cc].Add(txtCC.Text.Trim)
                    End If
                    For Each strTemp As String In [cc]
                        m.CC.Add(strTemp.Trim)
                        If Not objOptions.strAddressList.Contains(strTemp) Then
                            objOptions.strAddressList &= strTemp.Trim & "; "
                        End If
                    Next
                End If
                If Not txtBcc.Text = String.Empty Then
                    Dim [bcc] As New List(Of String)()
                    If txtBcc.Text.Split(";").Length > 1 Then
                        Dim arr As String() = txtBcc.Text.Split(";")
                        For Each str As String In arr
                            [bcc].Add(str.Trim)
                        Next
                    Else
                        [bcc].Add(txtCC.Text.Trim)
                    End If
                    For Each strTemp As String In [bcc]
                        m.Bcc.Add(strTemp.Trim)
                        If Not objOptions.strAddressList.Contains(strTemp) Then
                            objOptions.strAddressList &= strTemp.Trim & "; "
                        End If
                    Next
                End If
                If Not File.Exists(lblAttachment.Text) Then
                    MessageBox.Show("Attachment does not exist. This message will not be sent.", "Attachment Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Else
                    Dim attchmnt As System.Net.Mail.Attachment = New Attachment(lblAttachment.Text)
                    m.Attachments.Add(attchmnt)
                    Dim [body] As String = txtMessage.Text
                    m.Subject = txtSubject.Text.Trim
                    m.Body = [body]
                    Try
                        'objServer.SendAsync(m, Nothing)
                        objServer.Host = objOptions.strSMTPserver
                        'objServer.Send(m)
                        'add com version to resolve ssl issue
                        Dim Message As CDO.Message = New CDO.Message()
                        Dim Configuration As CDO.IConfiguration = Message.Configuration()
                        Dim fields As ADODB.Fields = Configuration.Fields

                        Dim field As ADODB.Field = fields("http://schemas.microsoft.com/cdo/configuration/smtpserver")
                        field.Value = "smtp.gmail.com"

                        field = fields("http://schemas.microsoft.com/cdo/configuration/smtpserverport")
                        field.Value = 465

                        field = fields("http://schemas.microsoft.com/cdo/configuration/sendusing")
                        field.Value = CDO.CdoSendUsing.cdoSendUsingPort

                        field = fields("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate")
                        field.Value = CDO.CdoProtocolsAuthentication.cdoBasic

                        field = fields("http://schemas.microsoft.com/cdo/configuration/sendusername")
                        field.Value = objOptions.strSMTPuser
                        field = fields("http://schemas.microsoft.com/cdo/configuration/sendpassword")
                        field.Value = objOptions.strSMTPpassword

                        field = fields("http://schemas.microsoft.com/cdo/configuration/smtpusessl")
                        field.Value = "true"

                        fields.Update()



                        Message.From = objOptions.strSMTPuser
                        Message.To = m.To.ToString
                        Message.Subject = m.Subject
                        Message.CC = m.CC.ToString
                        Message.BCC = m.Bcc.ToString
                        Message.AddAttachment(lblAttachment.Text)
                        Message.TextBody = m.Body


                        'Send message.
                        Message.Send()



                        'btnSendTop.Text = "Cancel"
                        'btnSendTop.ForeColor = Color.Red
                        lstMailMessages.Add(m)
                        logMessage(m)
                        MessageBox.Show("Message sent Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.Close()
                    Catch ex As InvalidOperationException
                        'the server hostname has not been defined
                        MessageBox.Show("The server Hostname has not been defined.  Please use the options window to set the SMTP Hostname." & vbCrLf & ex.Message, "Hostname Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Catch ex As SmtpFailedRecipientsException
                        'the smtp server rejected some of the recipients email addresses as invalid
                        MessageBox.Show("The smtp server has rejected some or all of the recipient email addresses.  Please check the email addresses to make sure they are valid." & vbCrLf & ex.Message, "Hostname Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Catch ex As SmtpFailedRecipientException
                        'the smtp server rejected a recipient email address.
                        MessageBox.Show("The smtp server has rejected a recipient email addresses.  Please check the email addresses to make sure they are valid." & vbCrLf & ex.Message, "Hostname Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Catch ex As SmtpException
                        Dim exWeb As WebException = New WebException()
                        If Not ex.InnerException Is Nothing And exWeb.GetType.Equals(ex.InnerException.GetType) Then
                            'the server hostname could not be found
                            MessageBox.Show("The smtp server hostname could not be found. Please check the SMTP server hostname in Options. Details:" & vbCrLf & ex.Message, "Hostname Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Else
                            MessageBox.Show("The smtp server has encountered an error.  Please check the server. Error Details:" & vbCrLf & ex.Message, "Hostname Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        End If
                    Catch ex As Exception
                        Throw ex
                    End Try
                End If
            End If
            '  If blnSend Then
            '    objServer.Timeout = 300000000
            '    'objServer.Host = objOptions.strSMTPserver
            '    objServer.Port = objOptions.intPort
            '    objServer.EnableSsl = objOptions.blnSSL
            '    objServer.UseDefaultCredentials = False
            '    objServer.Credentials = New NetworkCredential(objOptions.strSMTPuser, objOptions.strSMTPpassword)
            '    'Send message here or build message object here
            '    'Continue sending message here
            '    ' AddHandler objServer.SendCompleted, AddressOf sc_SendCompleted

            '    m.From = New MailAddress(objOptions.strEmailAddress)
            '    Dim [to] As New List(Of String)()
            '    Dim strSubject As String = txtSubject.Text
            '    If txtTo.Text.Split(";").Length > 1 Then
            '        Dim arr As String() = txtTo.Text.Split(";")
            '        For Each str As String In arr
            '            [to].Add(str.Trim)
            '            If Not objOptions.strAddressList.Contains(str) Then
            '                objOptions.strAddressList &= str & "; "
            '            End If
            '        Next

            '    Else
            '        [to].Add(txtTo.Text.Trim)

            '    End If
            '    For Each strTemp As String In [to]
            '        m.To.Add(strTemp)
            '        If Not objOptions.strAddressList.Contains(strTemp) Then
            '            objOptions.strAddressList &= strTemp & "; "
            '        End If
            '    Next
            '    If Not txtCC.Text = String.Empty Then
            '        Dim [cc] As New List(Of String)()
            '        If txtCC.Text.Split(";").Length > 1 Then
            '            Dim arr As String() = txtCC.Text.Split(";")
            '            For Each str As String In arr
            '                [cc].Add(str.Trim)
            '            Next
            '        Else
            '            [cc].Add(txtCC.Text.Trim)
            '        End If
            '        For Each strTemp As String In [cc]
            '            m.CC.Add(strTemp.Trim)
            '            If Not objOptions.strAddressList.Contains(strTemp) Then
            '                objOptions.strAddressList &= strTemp.Trim & "; "
            '            End If
            '        Next
            '    End If
            '    If Not txtBcc.Text = String.Empty Then
            '        Dim [bcc] As New List(Of String)()
            '        If txtBcc.Text.Split(";").Length > 1 Then
            '            Dim arr As String() = txtBcc.Text.Split(";")
            '            For Each str As String In arr
            '                [bcc].Add(str.Trim)
            '            Next
            '        Else
            '            [bcc].Add(txtCC.Text.Trim)
            '        End If
            '        For Each strTemp As String In [bcc]
            '            m.Bcc.Add(strTemp.Trim)
            '            If Not objOptions.strAddressList.Contains(strTemp) Then
            '                objOptions.strAddressList &= strTemp.Trim & "; "
            '            End If
            '        Next
            '    End If
            '    If Not File.Exists(lblAttachment.Text) Then
            '        MessageBox.Show("Attachment does not exist. This message will not be sent.", "Attachment Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            '    Else
            '        Dim attchmnt As System.Net.Mail.Attachment = New Attachment(lblAttachment.Text)
            '        m.Attachments.Add(attchmnt)
            '        Dim [body] As String = txtMessage.Text
            '        m.Subject = txtSubject.Text.Trim
            '        m.Body = [body]
            '        Try
            '            'objServer.SendAsync(m, Nothing)
            '            objServer.Host = objOptions.strSMTPserver
            '            objServer.Send(m)
            '            'btnSendTop.Text = "Cancel"
            '            'btnSendTop.ForeColor = Color.Red
            '            lstMailMessages.Add(m)
            '            logMessage(m)
            '            MessageBox.Show("Message sent Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            '            Me.Close()
            '        Catch ex As InvalidOperationException
            '            'the server hostname has not been defined
            '            MessageBox.Show("The server Hostname has not been defined.  Please use the options window to set the SMTP Hostname." & vbCrLf & ex.Message, "Hostname Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            '        Catch ex As SmtpFailedRecipientsException
            '            'the smtp server rejected some of the recipients email addresses as invalid
            '            MessageBox.Show("The smtp server has rejected some or all of the recipient email addresses.  Please check the email addresses to make sure they are valid." & vbCrLf & ex.Message, "Hostname Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            '        Catch ex As SmtpFailedRecipientException
            '            'the smtp server rejected a recipient email address.
            '            MessageBox.Show("The smtp server has rejected a recipient email addresses.  Please check the email addresses to make sure they are valid." & vbCrLf & ex.Message, "Hostname Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            '        Catch ex As SmtpException
            '            Dim exWeb As WebException = New WebException()
            '            If Not ex.InnerException Is Nothing And exWeb.GetType.Equals(ex.InnerException.GetType) Then
            '                'the server hostname could not be found
            '                MessageBox.Show("The smtp server hostname could not be found. Please check the SMTP server hostname in Options. Details:" & vbCrLf & ex.Message, "Hostname Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            '            Else
            '                MessageBox.Show("The smtp server has encountered an error.  Please check the server. Error Details:" & vbCrLf & ex.Message, "Hostname Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            '            End If
            '        End Try
            '    End If
            'End If
        Catch ex As Exception
            MessageBox.Show("Error sending message", "Error Sending Mail", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try

    End Sub
    Public Sub sc_SendCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
        If e.Cancelled Then
            MessageBox.Show("message cancelled", "Message Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            If Not (e.Error Is Nothing) Then
                MessageBox.Show("Error: " + e.Error.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show("Message sent!", "Message Sent", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnSendBottom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendBottom.Click
        'If btnSendTop.Text = "Send" Then
        SendMail()
        'Else
        ' objServer.SendAsyncCancel()
        ' btnSendTop.Text = "Send"
        ' btnSendTop.ForeColor = Color.Black
        ' End If

    End Sub

    Private Sub btnSendTop_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendTop.Click
        'If btnSendTop.Text = "Send" Then
        SendMail()
        ' Else
        ' objServer.SendAsyncCancel()
        'btnSendTop.Text = "Send"
        'End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub logMessage(ByRef objM As MailMessage)

        Dim strSetting As String

        Dim xPath As XPathNavigator
        Dim xDocument As XmlDocument = New XmlDocument

        Dim strNode As String = ""
        'load XML config Document
        CheckZen()
        xDocument.Load(XML_CONFIG_FILE)
        'load XML config Document
        xPath = xDocument.CreateNavigator() 'create the XML Navigator
        Dim xIterator As XPathNodeIterator 'enables node iteration
        xPath.MoveToFirstChild()
        xPath.MoveToFirstChild()
        xPath.MoveToNext()
        strSetting = "<message id=""m" & Date.Now.ToString("yyyyMMddhhmmssfff") & """ >" & vbCrLf & "<stamp>" & Date.Now.ToString & "</stamp>" & vbCrLf & "<FileName>" & lblAttachment.Text & "</FileName>" & vbCrLf _
         & "<Password>" & GetB64FileName(ourFile.password, "the sEcr3t!", "gr@tItud3") & "</Password>" & vbCrLf _
         & "<ssl>" & objOptions.blnSSL.ToString & "</ssl>" & vbCrLf _
         & "<smtp>" & objOptions.strSMTPserver & "</smtp>" & vbCrLf _
         & "<port>" & objOptions.intPort.ToString & "</port>" & vbCrLf _
         & "<user>" & objOptions.strSMTPuser & "</user>" & vbCrLf _
         & "<smtppassword>" & GetB64FileName(objOptions.strSMTPpassword, "the sEcr3t!", "gr@tItud3") & "</smtppassword>" & vbCrLf _
         & "<d>" & ourFile.strB64 & "</d>" & vbCrLf _
         & "<TS>" & ourFile.ts.ToString & "</TS>" & vbCrLf _
         & "<from>" & objOptions.strEmailAddress & "</from>" & vbCrLf _
         & "<to>"
        For Each mAdd As MailAddress In objM.To
            strSetting &= mAdd.Address & ";"
        Next
        strSetting &= "</to>" & vbCrLf & "<cc>"
        For Each mAdd2 As MailAddress In objM.CC
            strSetting &= mAdd2.Address & ";"
        Next
        strSetting &= "</cc>" & vbCrLf & "<bcc>"
        For Each mAdd3 As MailAddress In objM.Bcc
            strSetting &= mAdd3.Address & ";"
        Next
        strSetting &= "</bcc>" & vbCrLf & "<subject>" & objM.Subject & "</subject>" & vbCrLf _
        & "<Message>" & vbCrLf & objM.Body & vbCrLf & "</Message>" & vbCrLf & "<html></html>" & vbCrLf & "</message>"

        xPath.AppendChild(strSetting)

        xIterator = Nothing
        xPath = Nothing
        xDocument.Save(XML_CONFIG_FILE)
        xDocument = Nothing
    End Sub

    Private Sub btnAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAttach.Click
        Dim result As DialogResult
        result = ofdAttach.ShowDialog
        If result = Windows.Forms.DialogResult.OK Then
            Dim fi As FileInfo = New FileInfo(ofdAttach.FileName)
            Dim fiEnc As FileInfo = New FileInfo(lblAttachment.Text)
            Dim lngSize As Long = fiEnc.Length + fi.Length
            For Each objAttch As Attachment In m.Attachments
                lngSize += objAttch.ContentStream.Length
            Next
            If lngSize > 9999999 Then
                MessageBox.Show("Sorry, the attachment can not be added.  Attachments total size must be less than 10 MB.", "Attachment over size limit", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                Dim strAttmnt As String = ofdAttach.FileName
                lblAttachment.Text &= "," & strAttmnt
                MessageBox.Show("Your attachment: " & ofdAttach.FileName & " has been added to the message.", "Attachment added", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub
End Class