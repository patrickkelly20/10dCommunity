Imports System.Configuration
Imports System.IO
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Security
Imports System.Security.Cryptography


Public Class frmtEncryptOptions
    Private Structure KeyFile
        Dim strAkeyName As String
        Dim strAkeyPath As String
        Dim strAkeyPri As String
        Dim strAkeyPub As String
    End Structure
    
    Private lstPriKeys As List(Of KeyFile) = New List(Of KeyFile)
    Private lstPubKeys As List(Of KeyFile) = New List(Of KeyFile)
    Dim lstPriKeyNames As List(Of String) = New List(Of String)
    Dim lstPubKeyNames As List(Of String) = New List(Of String)

    Private lstKeys As List(Of KeyFile) = New List(Of KeyFile)
    Dim lstKeyNames As List(Of String) = New List(Of String)

    Private Sub frmOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'txtOutputFolder.Text = objOptions.strOutput
            txtEmailAddress.Text = objOptions.strEmailAddress
            'If objOptions.blnLog Then
            '    radLogPasswords.Checked = True
            'Else
            '    radNotLogPasswords.Checked = True
            'End If
            txtSMTPserver.Text = objOptions.strSMTPserver
            txtSMTPuser.Text = objOptions.strSMTPuser
            txtSMTPport.Text = CStr(objOptions.intPort)
            txtSMTPpassword.Text = objOptions.strSMTPpassword
            chkSSL.Checked = objOptions.blnSSL
            Dim strPriKeys() As String = Directory.GetFiles(Xroot & "kys", "*_pri.xml")
            Dim strPubKeys() As String = Directory.GetFiles(Xroot & "kys", "*_pub.xml")
            For Each strTemp As String In strPriKeys
                Dim strName As String = Path.GetFileNameWithoutExtension(strTemp)
                Dim strPath As String = strTemp
                Dim strPri As String = File.ReadAllText(strTemp)
                'Dim strPub As String = File.ReadAllText(strTemp.Replace("_pri.xml", "_pub.xml"))
                Dim kyFile As KeyFile = New KeyFile
                kyFile.strAkeyName = strName
                lstPriKeyNames.Add(strName)
                kyFile.strAkeyPath = strPath
                kyFile.strAkeyPri = strPri
                'kyFile.strAkeyPub = strPub
                lstPriKeys.Add(kyFile)
            Next
            For Each strTemp As String In strPubKeys
                Dim strName As String = Path.GetFileNameWithoutExtension(strTemp)
                Dim strPath As String = strTemp
                'Dim strPri As String = File.ReadAllText(strTemp)
                Dim strPub As String = File.ReadAllText(strTemp)
                Dim kyFile As KeyFile = New KeyFile
                kyFile.strAkeyName = strName
                lstPubKeyNames.Add(strName)
                kyFile.strAkeyPath = strPath
                'kyFile.strAkeyPri = strPri
                kyFile.strAkeyPub = strPub
                lstPubKeys.Add(kyFile)
            Next
            For Each strT As String In lstPubKeyNames
                cboxKeys.Items.Add(strT.Replace("_pub", ""))
                'cBoxKeys2.Items.Add(strT.Replace("_pri", ""))
            Next
            For Each strT As String In lstPriKeyNames
                cboxKeys2.Items.Add(strT.Replace("_pri", ""))
                'cBoxKeys2.Items.Add(strT.Replace("_pri", ""))
            Next
            Dim intCount As Integer = 0
            For Each objItem As Object In cboxKeys.Items
                If objItem.ToString & "_pub" = objOptions.strPubKeyName Then
                    cboxKeys.SelectedIndex = intCount
                    'cBoxKeys2.SelectedIndex = intCount
                    Exit For
                End If
                intCount += 1
            Next
            Dim intCount2 As Integer = 0
            For Each objItem As Object In cboxKeys2.Items
                If objItem.ToString & "_pri" = objOptions.strPrikeyName Then
                    'cboxKeys.SelectedIndex = intCount2
                    cboxKeys2.SelectedIndex = intCount2
                    Exit For
                End If
                intCount2 += 1
            Next



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            'objOptions.strOutput = txtOutputFolder.Text
            objOptions.strEmailAddress = txtEmailAddress.Text
            ' objOptions.blnLog = radLogPasswords.Checked
            objOptions.strSMTPserver = txtSMTPserver.Text
            objOptions.strSMTPuser = txtSMTPuser.Text
            If Not IsNumeric(txtSMTPport.Text) Then
                MessageBox.Show("SMTP Port value must be a number.", "Invalid SMTP Port Entry", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Else
                objOptions.intPort = CInt(txtSMTPport.Text)
            End If
            objOptions.strSMTPpassword = txtSMTPpassword.Text
            objOptions.blnSSL = chkSSL.Checked
            objOptions.strPrikeyName = cboxKeys2.Items(cboxKeys2.SelectedIndex).ToString & "_pri"
            objOptions.strPubKeyName = cboxKeys.Items(cboxKeys.SelectedIndex).ToString & "_pub"
            GetKeys(objOptions.strPrikeyName)
            SaveConfigInfo()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error processing options input:" & vbCrLf & ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    'Private Sub btnBrowseOutputFolder_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim objResult As System.Windows.Forms.DialogResult
    '        objResult = fbdOptions.ShowDialog
    '        If objResult = Windows.Forms.DialogResult.OK Then
    '            txtOutputFolder.Text = fbdOptions.SelectedPath
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SaveConfigInfo()
        Try
            Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath)
            config.AppSettings.Settings("OutputDirectory").Value = objOptions.strOutput
            config.AppSettings.Settings("LogPasswords").Value = CStr(objOptions.blnLog)
            config.AppSettings.Settings("SMTPport").Value = CStr(objOptions.intPort)
            config.AppSettings.Settings("systemFromMail").Value = objOptions.strEmailAddress
            config.AppSettings.Settings("SMTPpassword").Value = GetB64FileName(objOptions.strSMTPpassword, "the sEcr3t!", "gr@tItud3")
            config.AppSettings.Settings("SMTPserver").Value = objOptions.strSMTPserver
            config.AppSettings.Settings("SMTPuser").Value = objOptions.strSMTPuser
            config.AppSettings.Settings("SMTPssl").Value = CStr(objOptions.blnSSL)
            config.AppSettings.Settings("emailAddresses").Value = objOptions.strAddressList
            config.AppSettings.Settings("AsymPriKey").Value = objOptions.strPrikeyName
            config.AppSettings.Settings("AsymPubKey").Value = objOptions.strPubKeyName
            config.Save()
        Catch ex As Exception
            MessageBox.Show("Error saving configuration options. Message: " & vbCrLf & ex.Message, "Error Saving Config", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Private Sub GetKeys(ByVal strKeyName As String)
        Try
            Dim strPath As String = Xroot & "kys\" & objOptions.strPrikeyName & ".xml"
            objOptions.strPriKeyPath = strPath
            Dim strTemp As String = File.ReadAllText(strPath)
            objOptions.strPriKey = strTemp
            strTemp = ""
            Dim strPath2 As String = Xroot & "kys\" & objOptions.strPubKeyName & ".xml"
            objOptions.strPubKeyPath = strPath2
            strTemp = File.ReadAllText(strPath2)
            objOptions.strPubKey = strTemp

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub chkShowPassword_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked = True Then
            txtSMTPpassword.PasswordChar = ""
        Else
            txtSMTPpassword.PasswordChar = "*"
        End If
    End Sub

    
    
    
    Private Sub cboxKeys_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxKeys.SelectedIndexChanged
        Try

            objOptions.strPubKeyName = cboxKeys.Items(cboxKeys.SelectedIndex).ToString & "_pub"
            GetKeys(objOptions.strPrikeyName)
            Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath)
            config.AppSettings.Settings("AsymPubKey").Value = objOptions.strPubKeyName
            config.Save()
            
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cboxKeys2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxKeys2.SelectedIndexChanged
        Try
           

            objOptions.strPrikeyName = cboxKeys.Items(cboxKeys.SelectedIndex).ToString & "_pri"
            GetKeys(objOptions.strPrikeyName)
            Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath)
            config.AppSettings.Settings("AsymPriKey").Value = objOptions.strPrikeyName
            config.Save()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class