Option Explicit On
Option Strict On
Imports System
Imports System.IO
Imports System.IO.Compression
Imports System.Security.Cryptography
Imports System.Text
Imports System.Configuration
Imports System.Net.Mail
Imports System.Xml.Serialization
Imports System.Xml
Imports System.Xml.XPath


Public Class frmtEncrypt
    Private strFileToCompress As String = ""
    Private strUserPathRoot As String = ""
    Private Structure KeyFile
        Dim strAkeyName As String
        Dim strAkeyPath As String
        Dim strAkeyPri As String
        Dim strAkeyPub As String
    End Structure
    Private lstKeys As List(Of KeyFile) = New List(Of KeyFile)
    Dim lstKeyNames As List(Of String) = New List(Of String)

    Private Sub btnBrowseToFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseToFile.Click
        'Get user input for file to compress
        Try
            Dim dr As DialogResult
            dr = ofdFileToCompress.ShowDialog
            If dr = Windows.Forms.DialogResult.OK Then
                txtFileToCompress.Text = ofdFileToCompress.FileName
                lblStatus.Text = ofdFileToCompress.FileName
                lblStatus.Visible = True
                strFileToCompress = ofdFileToCompress.FileName
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Opening File", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnCompress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Process the compression
        Try
            Dim strFile As String = txtFileToCompress.Text.Trim
            'Validate that we have input
            If strFile = "" Then
                MessageBox.Show("Please select a file", "File Input Needed", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf Not File.Exists(strFile) Then
                MessageBox.Show("Please select an existing file", "File does not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Else
                'Process the input using our compression sub
                'CompressFile(strFileToCompress, strFileToCompress & ".gz")
                lblStatus.Text = "Created " & AddToNewZip(strFile)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Starting Compression", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Shared Sub CompressFile(ByVal inFilename As String, ByVal outFilename As String)
        Try
            'Compress the file
            Dim sourceFile As FileStream = File.OpenRead(inFilename)
            Dim destFile As FileStream = File.Create(outFilename)
            Dim compStream As New GZipStream(destFile, CompressionMode.Compress)
            Dim theByte As Integer = sourceFile.ReadByte()
            While theByte <> -1
                compStream.WriteByte(CType(theByte, Byte))
                theByte = sourceFile.ReadByte
            End While
            compStream.Close()
            destFile.Close()
            sourceFile.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Compressing File", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Shared Sub DecompressFile(ByVal inFilename As String, ByVal outFilename As String)
        Try
            'Decompress the file
            Dim sourceFile As FileStream = File.OpenRead(inFilename)
            Dim destFile As FileStream = File.Create(outFilename)
            Dim compStream As New GZipStream(sourceFile, CompressionMode.Decompress)
            Dim theByte As Integer = compStream.ReadByte()
            While theByte <> -1
                destFile.WriteByte(CType(theByte, Byte))
                theByte = compStream.ReadByte
            End While
            compStream.Close()
            destFile.Close()
            sourceFile.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Decompressing File", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnDecompress_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            'call the decompress sub
            If Microsoft.VisualBasic.Right(strFileToCompress, 3) <> ".gz" Then
                MessageBox.Show("Please select a file with a .gz extension", "Incorrect File type", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Else
                'Decompress the file
                DecompressFile(strFileToCompress, Microsoft.VisualBasic.Left(strFileToCompress, strFileToCompress.Length - 3))
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Starting File Decompression", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnEncrypt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEncrypt.Click
        Try
            'Validate the password and process the encryption
            Dim strPassword1 As String = "Gr@titud3" 'txtPassword1.Text
            'Dim strPassWord2 As String = txtPassword2.Text
            Dim strFile As String = txtFileToCompress.Text
            Dim fiOurFile As FileInfo = New FileInfo(strFile)
            Dim lngSizeLimit As Long = 500000000
            'If Not AtLeastSix(strPassword1) Then
            '    MessageBox.Show("Your Password is not valid.  It must contain at least six characters.", "Password is Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            'ElseIf Not strPassword1 = strPassWord2 Then
            '    MessageBox.Show("Your Passwords do not match, please re-enter your Passwords", "Passwords Must Match", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            'ElseIf Not ContainsAlpha(strPassword1) Then
            '    MessageBox.Show("Your Password is not valid.  It must contain at least one Alphabetic character.", "Password is Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            '    'Check for numbers
            'ElseIf Not ContainsNumber(strPassword1) Then
            '    MessageBox.Show("Your Password is not valid.  It must contain at least one numeric character.", "Password is Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            '    'check for at least six characters
            'ElseIf Not ContainsSymbol(strPassword1) Then
            '    MessageBox.Show("Your Password is not valid.  It must contain at least one Symbol or non-alpha and non-numeric character", "Password is Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            'Else
            If Not File.Exists(strFile) Then
                MessageBox.Show("Please enter a valid file name.  It must exist already", "File input invalid", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf fiOurFile.Length > lngSizeLimit Then
                MessageBox.Show("The file is larger than the 500mb limit.  In order to encrypt a file with this application, it must be less than 2,000,000,000 bytes.", "File Size is above the limit", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Else
                'It must be valid if it passed our number and alpha tests
                'MessageBox.Show("Your Password is valid.  It contains at least one numeric, one symbol, and alphabetic character and is at least six characters in length. Nice job!", "Password is Valid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                'Process the request
                ofdFileToCompress = Nothing
                ofdFileToCompress = New System.Windows.Forms.OpenFileDialog
                Dim strZippedFile As String = AddToNewZip(strFile)
                'strFile = Path.GetFileName(strFile)
                Dim blnEncryptSuccess As Boolean = EncryptFile(strFile, strZippedFile, strPassword1, "the sEcr3t!", 4)
                If blnEncryptSuccess Then
                    ourFile.EncName = Path.GetFullPath(strOutputFile).ToString
                    ourFile.password = strPassword1
                    ourFile.Name = Path.GetFullPath(strOutputFile).ToString
                    Dim dialogResult As DialogResult = MessageBox.Show("Your file has been encrypted as the file:" & vbCrLf & ourFile.Name & vbCrLf & "Would you like to send this file?", "Encryption Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    If objOptions.blnLog Then
                        logEnc()
                    End If
                    If dialogResult = Windows.Forms.DialogResult.Yes Then
                        Try
                            If Not ourFile.EncName = String.Empty Then
                                Dim frmSendM As New frmtEncryptSendMail(ourFile.EncName)
                                frmSendM.ShowDialog()
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Error Displaying Send Mail form. Message: " & vbCrLf & ex.Message, "Mail Display Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        End Try
                    End If
                Else
                    MessageBox.Show("File Encryption Failed: Error: 20", "Encryption Failed", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Encryption Error: 30", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub


    Private Sub btnDeCrypt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeCrypt.Click
        Try
            'Validate the password and process the decryption
            Dim strPassword1 As String = "R3@ly!" 'txtPassword1.Text
            'Dim strPassWord2 As String = txtPassword2.Text
            Dim strFile As String = txtFileToCompress.Text.Trim
            'If Not AtLeastSix(strPassword1) Then
            '    MessageBox.Show("Your Password is not valid.  It must contain at least six characters.", "Password is Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            'ElseIf Not strPassword1 = strPassWord2 Then
            '    MessageBox.Show("Your Passwords do not match, please re-enter your Passwords", "Passwords Must Match", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            'ElseIf Not ContainsAlpha(strPassword1) Then
            '    MessageBox.Show("Your Password is not valid.  It must contain at least one Alphabetic character.", "Password is Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            '    'Check for numbers
            'ElseIf Not ContainsNumber(strPassword1) Then
            '    MessageBox.Show("Your Password is not valid.  It must contain at least one numeric character.", "Password is Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            '    'check for at least six characters
            'ElseIf Not ContainsSymbol(strPassword1) Then
            '    MessageBox.Show("Your Password is not valid.  It must contain at least one Symbol or non-alpha and non-numeric character", "Password is Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            'Else
            If String.Empty = strFile Then
                MessageBox.Show("Please choose a file to decrypt.", "File Input Needed", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf Not File.Exists(strFile) Then
                MessageBox.Show("Please enter an existing file to decrypt.", "File doesn't exist", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Else
                'It must be valid if it passed our number and alpha tests
                'MessageBox.Show("Your Password is valid.  It contains at least one numeric, one symbol, and alphabetic character and is at least six characters in length. Nice job!", "Password is Valid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                'Process the request
                '
                If (Not File.Exists(Path.GetFullPath(strFile).Replace(Path.GetFileName(strFile), "hhcsx.xsd"))) Or (Not File.Exists(Path.GetFullPath(strFile).Replace(Path.GetFileName(strFile), "hhcsx.dtd"))) Then
                    SetupDirectory(Path.GetFullPath(strFile).Replace(Path.GetFileName(strFile), ""))
                End If
                Dim xEncFile As New hhcsxFile
                xEncFile = GetEncryptedFile(strFile)
                Dim blnEncryptSuccess As Boolean = DecryptFile(xEncFile, strPassword1, "the sEcr3t!", 4)
                If blnEncryptSuccess Then
                    Dim result As DialogResult = MessageBox.Show("Your file:" & vbCrLf & strOutputFile & vbCrLf & "has been decrypted" & vbCrLf & "Would you like to open it?", "File Decryption Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    If result = Windows.Forms.DialogResult.Yes Then
                        Process.Start(strOutputFile)
                    End If
                Else
                    MessageBox.Show("File Decryption Failed: Error - 20", "File Decryption Failed", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "File Decryption Error - 30", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub chkShowPassword_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowPassword.CheckedChanged
        Try
            'if it is checked show the password if not show stars
            If chkShowPassword.Checked Then
                txtPassword1.PasswordChar = CChar(String.Empty)
                txtPassword2.PasswordChar = CChar(String.Empty)
            Else
                txtPassword1.PasswordChar = CChar("*")
                txtPassword2.PasswordChar = CChar("*")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Password View Error - 8", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Try
            'clear the form
            txtFileToCompress.Text = String.Empty
            txtPassword1.Text = String.Empty
            txtPassword2.Text = String.Empty
            chkShowPassword.Checked = False
            btnBrowseToFile.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Form Reset Error - 10", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Try
            'close the form
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Form Close Error - 11", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub


    Private Sub chkShowSalt_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowSalt.CheckedChanged
        Try
            'if it is checked show the salt if not show stars
            If chkShowSalt.Checked Then
                txtSalt1.PasswordChar = CChar(String.Empty)
                txtSalt2.PasswordChar = CChar(String.Empty)
            Else
                txtSalt1.PasswordChar = CChar("*")
                txtSalt2.PasswordChar = CChar("*")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Salt View Error - 16", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub frmEncryptionDemo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Dim intCounter As Integer = 1
        'For Each objMessage As MailMessage In lstMailMessages
        '    Dim fs As FileStream = New FileStream(objOptions.strOutput & "\" & CStr(intCounter) & ".pkencm", FileMode.Create)
        '    Dim xs As XmlSerializer = New XmlSerializer(GetType(MailMessage))
        '    xs.Serialize(fs, objMessage)
        '    intCounter += 1
        'Next
    End Sub

    Private Sub frmEncryptionDemo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            objOptions.strOutput = ConfigurationManager.AppSettings("OutputDirectory")
            objOptions.blnLog = CBool(ConfigurationManager.AppSettings("LogPasswords"))
            objOptions.intPort = CInt(ConfigurationManager.AppSettings("SMTPport"))
            objOptions.strEmailAddress = ConfigurationManager.AppSettings("systemFromMail")
            If Not ConfigurationManager.AppSettings("SMTPpassword") = String.Empty Then
                Dim strB64 As String = CStr(ConfigurationManager.AppSettings("SMTPpassword"))
                Dim strPassword As String = GetStringFromB64(strB64, "gr@tItud3")
                objOptions.strSMTPpassword = strPassword
            End If
            objOptions.strSMTPserver = ConfigurationManager.AppSettings("SMTPserver")
            objOptions.strSMTPuser = ConfigurationManager.AppSettings("SMTPuser")
            objOptions.blnSSL = CBool(ConfigurationManager.AppSettings("SMTPssl"))
            objOptions.strAddressList = ConfigurationManager.AppSettings("emailAddresses")
            objOptions.intMaxLogFile = CInt(ConfigurationManager.AppSettings("MaxLogFiles"))
            objOptions.strPrikeyName = ConfigurationManager.AppSettings("AsymPriKey")

            'Dim lstStrMessages() As String
            'lstStrMessages = Directory.GetFiles(objOptions.strOutput, "*.pkencm")
            'If lstStrMessages.Length > 0 Then
            '    For intCounter As Integer = 0 To lstStrMessages.Length - 1
            '        Dim fs As FileStream = New FileStream(lstStrMessages(intCounter), FileMode.Open)
            '        Dim xs As XmlSerializer = New XmlSerializer(GetType(MailMessage))
            '        Dim objMessage As MailMessage = CType(xs.Deserialize(fs), MailMessage)
            '        lstMailMessages.Add(objMessage)
            '        'intCounter += 1
            '    Next
            'End If
            XML_CONFIG_FILE = System.Environment.GetEnvironmentVariable("APPDATA").ToString & "\Tenac10us\10d\zen\zen.xml"
            Xroot = System.Environment.GetEnvironmentVariable("APPDATA").ToString & "\Tenac10us\10d\"
            Dim strKeys() As String = Directory.GetFiles(Xroot & "kys", "*_pri.xml")

            For Each strTemp As String In strKeys
                Dim strName As String = Path.GetFileNameWithoutExtension(strTemp)
                Dim strPath As String = strTemp
                Dim strPri As String = File.ReadAllText(strTemp)
                Dim strPub As String = File.ReadAllText(strTemp.Replace("_pri.xml", "_pub.xml"))
                Dim kyFile As KeyFile = New KeyFile
                kyFile.strAkeyName = strName
                lstKeyNames.Add(strName)
                kyFile.strAkeyPath = strPath
                kyFile.strAkeyPri = strPri
                kyFile.strAkeyPub = strPub
                lstKeys.Add(kyFile)
            Next
            For Each strT As String In lstKeyNames
                cboxKeys.Items.Add(strT.Replace("_pri", ""))
            Next
            Dim intCount As Integer = 0
            For Each objItem As Object In cboxKeys.Items
                If objItem.ToString & "_pri" = objOptions.strPrikeyName Then
                    cboxKeys.SelectedIndex = intCount
                    Exit For
                End If
                intCount += 1
            Next
            GetKeys(objOptions.strPrikeyName)
            If Not Directory.Exists(Xroot & "input") Then
                Directory.CreateDirectory(Xroot & "input")
            End If
            If Not Directory.Exists(Xroot & "output") Then
                Directory.CreateDirectory(Xroot & "output")
            End If
            If Not Directory.Exists(Xroot & "process") Then
                Directory.CreateDirectory(Xroot & "process")
            End If
        Catch ex As Exception
            MessageBox.Show("Invalid Configuration Information error." & vbCrLf & vbTab & "Some or all of your saved settings may not be available." & vbCrLf & "Message: " & ex.Message, "Configation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
        'If log passwords is set to true, then retrieve the password logging information here
        If objOptions.blnLog Then
            'do processing to retrieve the passwords and display them in the log window
        End If
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        Try
            Dim frmOpt As New frmtEncryptOptions
            frmOpt.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Error Displaying options form. Message: " & vbCrLf & ex.Message, "Options Display Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub


    Private Sub SendToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendToolStripMenuItem.Click
        Try
            If Not ourFile.EncName = String.Empty Then
                Dim frmSendM As New frmtEncryptSendMail(ourFile.EncName)
                frmSendM.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show("Error Displaying Send Mail form. Message: " & vbCrLf & ex.Message, "Mail Display Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Private Sub logEnc()
        Try


            Dim strSetting As String

            Dim xPath As XPathNavigator
            Dim xDocument As XmlDocument = New XmlDocument

            Dim strNode As String = ""
            'load XML config Document
            CheckZen()
            xDocument.Load(XML_CONFIG_FILE)
            'Application.ExecutablePath.Replace("hhcsEnc.exe", "zen.xml"))
            'load XML config Document
            xPath = xDocument.CreateNavigator() 'create the XML Navigator
            Dim xIterator As XPathNodeIterator 'enables node iteration
            xPath.MoveToFirstChild()
            xPath.MoveToFirstChild()
            strSetting = "<file id=""f" & Date.Now.ToString("yyyyMMddhhmmssfff") & """>" & vbCrLf _
            & "<fileName>" & ourFile.Name & "</fileName>" & vbCrLf _
            & "<host>" & Environment.MachineName & "</host>" & vbCrLf _
            & "<password>" & GetB64FileName(ourFile.password, "the sEcr3t!", "gr@tItud3") & "</password>" & vbCrLf & "<d1>" & vbCrLf & "</d1>" _
            & vbCrLf & "<ts>" & ourFile.ts.ToString & "</ts>" & vbCrLf & "</file>"

            xPath.AppendChild(strSetting)


            xIterator = Nothing
            xPath = Nothing
            xDocument.Save(XML_CONFIG_FILE)
            'Application.ExecutablePath.Replace("hhcsEnc.exe", "zen.xml"))
            xDocument = Nothing
        Catch ex As Exception
            MessageBox.Show("Error writing to log. Details: " & ex.Message, "Log Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Public Sub CheckZen()
        Try
            Dim strPath As String = XML_CONFIG_FILE
            Dim strRoot As String = XML_CONFIG_FILE.Replace("zen.xml", "")
            Dim strName As String = "zen"
            Dim strEXT As String = ".xml"
            Dim intCounter As Integer = 0
            If Not File.Exists(strPath) Then
                Dim sw As StreamWriter = File.CreateText(strPath)
                sw.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
                sw.WriteLine("<!DOCTYPE zen SYSTEM ""zen.dtd""[]>")
                sw.WriteLine("<zen xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:noNamespaceSchemaLocation=""zen.xsd"">")
                sw.WriteLine("<history>")
                sw.WriteLine("</history>")
                sw.WriteLine("<mail>")
                sw.WriteLine("</mail>")
                sw.Write("</zen>")
                sw.Close()
                sw = Nothing
            End If
            Dim fi As FileInfo = New FileInfo(strPath)
            Dim lngLimit As Long = 5000000
            If fi.Length > lngLimit Then
                Dim strNewFileName As String = strRoot & strName & intCounter.ToString & strEXT
                While File.Exists(strNewFileName)
                    intCounter += 1
                    strNewFileName = strRoot & strName & intCounter & strEXT
                End While
                File.Copy(strPath, strNewFileName)
                objOptions.intMaxLogFile = intCounter
                File.Delete(strPath)
                'create new log file
                Dim sw As StreamWriter = File.CreateText(strPath)
                sw.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
                sw.WriteLine("<!DOCTYPE zen SYSTEM ""zen.dtd""[]>")
                sw.WriteLine("<zen xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:noNamespaceSchemaLocation=""zen.xsd"">")
                sw.WriteLine("<history>")
                sw.WriteLine("</history>")
                sw.WriteLine("<mail>")
                sw.WriteLine("</mail>")
                sw.Write("</zen>")
                sw.Close()
                sw = Nothing
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GenerateKeyFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerateKeyFileToolStripMenuItem.Click
        Try
            Dim frmGK As New frmGenKeys
            Dim result As DialogResult = frmGK.ShowDialog()
            If result = Windows.Forms.DialogResult.OK Then
                Dim strKeys() As String = Directory.GetFiles(Xroot & "kys", "*_pri.xml")

                For Each strTemp As String In strKeys
                    Dim strName As String = Path.GetFileNameWithoutExtension(strTemp)
                    Dim strPath As String = strTemp
                    Dim strPri As String = File.ReadAllText(strTemp)
                    Dim strPub As String = File.ReadAllText(strTemp.Replace("_pri.xml", "_pub.xml"))
                    Dim kyFile As KeyFile = New KeyFile
                    kyFile.strAkeyName = strName
                    lstKeyNames.Add(strName)
                    kyFile.strAkeyPath = strPath
                    kyFile.strAkeyPri = strPri
                    kyFile.strAkeyPub = strPub
                    lstKeys.Add(kyFile)
                Next
                ' cboxKeys.Items.Clear()
                For Each strT As String In lstKeyNames
                    If Not IsstrInList(strT, cboxKeys) Then
                        cboxKeys.Items.Add(strT.Replace("_pri", ""))
                    End If
                Next
                Dim intCount As Integer = 0
                For Each objItem As Object In cboxKeys.Items
                    If objItem.ToString & "_pri" = objOptions.strPrikeyName Then
                        cboxKeys.SelectedIndex = intCount
                        Exit For
                    End If
                    intCount += 1
                Next
                GetKeys(objOptions.strPrikeyName)
            End If
        Catch ex As Exception
            MessageBox.Show("Error Displaying Key Generation form. Message: " & vbCrLf & ex.Message, "Options Display Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
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
            objOptions.strPriKey = strTemp
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cboxKeys_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxKeys.SelectedIndexChanged
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
    Public Function IsstrInList(ByVal strT As String, ByRef cmbox As ComboBox) As Boolean
        Dim boolInList As Boolean = False
        For Each item As Object In cmbox.Items
            If strT = item.ToString & "_pri" Then
                boolInList = True
                Exit For
            End If
        Next
        Return boolInList
    End Function

    Private Sub AboutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem1.Click
        Try
            Dim frmAbt As New AboutBox
            frmAbt.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Error Displaying About form. Message: " & vbCrLf & ex.Message, "Options Display Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

End Class
