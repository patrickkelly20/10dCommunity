Option Explicit On
Option Strict Off
Imports System.Collections.Generic
Imports System.Security.Permissions
Imports System.Security.Cryptography.X509Certificates
Imports System.IO
Imports System.Security.Cryptography
Imports System.Xml
Imports System.Xml.XPath
Imports Ionic.Zip
Imports System.Text
Imports System
Imports System.Configuration
Imports SH = _10dXL.CryptoSamples.StreamHelpers

Module modPassword
    Public Structure hhcsxFile
        Dim Name As String
        Dim id As String
        Dim sfhash As String
        Dim strB64 As String
        Dim ts As Date
        Dim EncName As String
        Dim password As String
    End Structure
    Public strLineNum As String = ""

    Public strOutputFile As String = ""
    Private strSymbols() As String = {"`", "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "-", "+", "=", "|", "\", ":", ";", ",", "<", ">", "?", "/"}
    Private strXsd As String = ""
    Private strDtd As String = ""
    Public Function Complexity(ByVal strPassword As String) As Integer
        'Verify the input as a password with at least one number and one alphabetic character and six characters in length
        Dim blnIsValid As Boolean = True
        Dim blnContainsNumber As Boolean = ContainsNumber(strPassword)
        Dim blnContainsAlpha As Boolean = ContainsAlpha(strPassword)
        Dim blnIsAtLeastSix As Boolean = AtLeastSix(strPassword)
        Dim intComplexity As Integer = 0
        'Check for a number in the password
        'Dim i As Integer
        'For i = 0 To (strPassword.Length - 1)
        '    If IsNumeric(strPassword.Substring(i, 1)) Then
        '        blnContainsNumber = True
        '        intComplexity += 1
        '        Exit For
        '    End If
        'Next
        ' Check for alphabetic characters
        'If IsNumeric(strPassword) Then
        '    blnContainsAlpha = False
        'Else
        '    blnContainsAlpha = True
        '    intComplexity += 1
        'End If
        'Check for at least six characters
        'If strPassword.Length >= 6 Then
        '    blnIsAtLeastSix = True
        '    intComplexity += 1
        'End If

        'Check for alphabetic characters with isnumeric
        If Not blnContainsAlpha Then
            MessageBox.Show("Your Password is not valid.  It must contain at least one Alphabetic character.", "Password is Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            'Check for numbers
        ElseIf Not blnContainsNumber Then
            MessageBox.Show("Your Password is not valid.  It must contain at least one numeric character.", "Password is Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            'check for at least six characters
        ElseIf Not blnIsAtLeastSix Then
            MessageBox.Show("Your Password is not valid.  It must contain at least six characters.", "Password is Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Else
            'It must be valid if it passed our number and alpha tests
            MessageBox.Show("Your Password is valid.  It contains at least one numeric and alphabetic character and is at least six characters in length. Nice job!", "Password is Valid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End If
    End Function

    Public Function ContainsNumber(ByVal strTemp As String) As Boolean
        Dim blnContainsNumber As Boolean = False
        Dim i As Integer
        For i = 0 To (strTemp.Length - 1)
            If IsNumeric(strTemp.Substring(i, 1)) Then
                blnContainsNumber = True
                Exit For
            End If
        Next
        Return blnContainsNumber
    End Function
    Public Function ContainsAlpha(ByVal strTemp As String) As Boolean
        Dim blnContainsAlpha As Boolean = False
        If IsNumeric(strTemp) Then
            blnContainsAlpha = False
        Else
            blnContainsAlpha = True
        End If
        Return blnContainsAlpha
    End Function
    Public Function AtLeastSix(ByVal strTemp As String) As Boolean
        Dim blnAtLeastSix As Boolean = False
        If strTemp.Length >= 6 Then
            blnAtLeastSix = True
        End If
        Return blnAtLeastSix
    End Function
    Public Function ContainsSymbol(ByVal strTemp As String) As Boolean
        Dim blnContainsSymbol As Boolean = False
        Dim i As Integer
        Dim i2 As Integer
        For i = 0 To (strTemp.Length - 1)
            For i2 = 0 To strSymbols.Length - 1
                If strTemp.Substring(i, 1) = strSymbols(i2) Then
                    blnContainsSymbol = True
                    Exit For
                End If
            Next i2
        Next i
        Return blnContainsSymbol
    End Function
    Public Function EncryptFile(ByVal strFileName As String, ByVal strZipFileName As String, ByVal strPassword As String, _
                                ByVal strSalt As String, ByVal intAlgorithm As Integer) As Boolean
        Try
            strLineNum = "1 -Path.GetTempFileName()"
            Dim strNewFileName As String = Path.GetTempFileName() '1
            'create the password key
            Dim strSaltKey As String = "Love one anoth3r + "
            Dim saltValueBytes As Byte()
            If String.Empty = strSalt Then
                saltValueBytes = System.Text.Encoding.ASCII.GetBytes(strSaltKey)
            Else
                saltValueBytes = System.Text.Encoding.ASCII.GetBytes(strSalt)
            End If
            'now perform Asymetric Encryption of Password
            Dim returnValue As Guid

            returnValue = Guid.NewGuid()
            Dim strPasssword As String = returnValue.ToString '.Substring(returnValue.ToString.Length - 11, 10)
            Dim rsaProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider
            rsaProvider.FromXmlString(objOptions.strPubKey)
            Dim bytArrayEncStr() As Byte = rsaProvider.Encrypt(System.Text.Encoding.UTF8.GetBytes(strPasssword), False)
            Dim encStrAsStr = Convert.ToBase64String(bytArrayEncStr)
            'Dim strEncFile As String = Xroot & "process\sesame.enc"
            'File.WriteAllBytes(strEncFile, bytArrayEncStr)
            'Dim strZipEncFile As String = AddToNewZip(strEncFile)
            'strPassword = strPasssword




            Dim passwordKey As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(strPasssword, saltValueBytes)
            'create the algorithm and specify the key and IV
            Select Case intAlgorithm
                Case 1
                    Dim alg3DES As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
                    alg3DES.Key = passwordKey.GetBytes(CInt(alg3DES.KeySize / 8))
                    alg3DES.IV = passwordKey.GetBytes(CInt(alg3DES.BlockSize / 8))
                    'Read unencrypted file into a byte array
                    Dim fs3DESinFile As FileStream = New FileStream(strZipFileName, FileMode.Open, FileAccess.Read)
                    Dim fs3DESinFileData(CInt(fs3DESinFile.Length)) As Byte
                    fs3DESinFile.Read(fs3DESinFileData, 0, CType(fs3DESinFile.Length, Integer))
                    'create the IcryptoTransform and CryptoStream object
                    Dim encryptor1 As ICryptoTransform = alg3DES.CreateEncryptor
                    Dim fs3DESoutFile As FileStream = New FileStream(strNewFileName, FileMode.OpenOrCreate, FileAccess.Write)
                    Dim encryptStream1 As CryptoStream = New CryptoStream(fs3DESoutFile, encryptor1, CryptoStreamMode.Write)
                    encryptStream1.Write(fs3DESinFileData, 0, fs3DESinFileData.Length)
                    encryptStream1.Close()
                    fs3DESinFile.Close()
                    fs3DESoutFile.Close()
                Case 2
                    Dim alg As RijndaelManaged = New RijndaelManaged
                    alg.KeySize = 256
                    alg.BlockSize = 128
                    alg.Key = passwordKey.GetBytes(CInt(alg.KeySize / 8))
                    alg.IV = passwordKey.GetBytes(CInt(alg.BlockSize / 8))
                    'Read unencrypted file into a byte array
                    Dim inFile As FileStream = New FileStream(strZipFileName, FileMode.Open, FileAccess.Read)
                    Dim infileData(CInt(inFile.Length)) As Byte
                    inFile.Read(infileData, 0, CType(inFile.Length, Integer))
                    ' create the IcryptoTransform and CryptoStream object
                    Dim encryptor As ICryptoTransform = alg.CreateEncryptor
                    Dim outFile As FileStream = New FileStream(strNewFileName, FileMode.OpenOrCreate, FileAccess.Write)
                    Dim encryptStream As CryptoStream = New CryptoStream(outFile, encryptor, CryptoStreamMode.Write)
                    encryptStream.Write(infileData, 0, infileData.Length)
                    'close the files
                    encryptStream.Close()
                    inFile.Close()
                    outFile.Close()
                Case 3
                    Dim algRC2 As RC2CryptoServiceProvider = New RC2CryptoServiceProvider
                    algRC2.Key = passwordKey.GetBytes(CInt(algRC2.KeySize / 8))
                    algRC2.IV = passwordKey.GetBytes(CInt(algRC2.BlockSize / 8))
                    'Read unencrypted file into a byte array
                    Dim fsAESinFile As FileStream = New FileStream(strZipFileName, FileMode.Open, FileAccess.Read)
                    Dim fsAESinFileData(CInt(fsAESinFile.Length)) As Byte
                    fsAESinFile.Read(fsAESinFileData, 0, CType(fsAESinFile.Length, Integer))
                    'create the IcryptoTransform and CryptoStream object
                    Dim encryptor3 As ICryptoTransform = algRC2.CreateEncryptor
                    Dim fsAESoutFile As FileStream = New FileStream(strNewFileName, FileMode.OpenOrCreate, FileAccess.Write)
                    Dim encryptStream3 As CryptoStream = New CryptoStream(fsAESoutFile, encryptor3, CryptoStreamMode.Write)
                    encryptStream3.Write(fsAESinFileData, 0, fsAESinFileData.Length)
                    encryptStream3.Close()
                    fsAESinFile.Close()
                    fsAESoutFile.Close()
                Case 4
                    Dim alg4AES As AesCryptoServiceProvider = New AesCryptoServiceProvider
                    alg4AES.KeySize = 256
                    alg4AES.BlockSize = 128
                    alg4AES.Key = passwordKey.GetBytes(CInt(alg4AES.KeySize / 8))
                    alg4AES.IV = passwordKey.GetBytes(CInt(alg4AES.BlockSize / 8))
                    'Read unencrypted file into a byte array
                    strLineNum = "2 - " & strZipFileName.ToString
                    Dim fsAESinFile As FileStream = New FileStream(strZipFileName, FileMode.Open, FileAccess.Read) '2
                    Dim fsAESinFileData(CInt(fsAESinFile.Length)) As Byte
                    fsAESinFile.Read(fsAESinFileData, 0, CType(fsAESinFile.Length, Integer))
                    'create the IcryptoTransform and CryptoStream object
                    Dim encryptor1 As ICryptoTransform = alg4AES.CreateEncryptor
                    strLineNum = "3 - " & strNewFileName.ToString
                    Dim fsAESoutFile As FileStream = New FileStream(strNewFileName, FileMode.OpenOrCreate, FileAccess.Write) '3
                    Dim encryptStream1 As CryptoStream = New CryptoStream(fsAESoutFile, encryptor1, CryptoStreamMode.Write)
                    encryptStream1.Write(fsAESinFileData, 0, fsAESinFileData.Length)
                    encryptStream1.Close()
                    fsAESinFile.Close()
                    fsAESoutFile.Close()
                    strLineNum = "4 - EncodeToString(strNewFileName) " & strNewFileName.ToString
                    Dim strB64 As String = EncodeToString(strNewFileName) '4
                    ourFile.strB64 = strB64
                    ourFile.password = strPasssword
                    'clean up
                    strLineNum = "5 - File.Delete(StrNewFileName) " & strNewFileName.ToString
                    File.Delete(strNewFileName) '5
                    ' 5/25/2011 to encode filename
                    strLineNum = "6 - GetB64FileName(strFileName, strSalt, strPassword) " & strFileName.ToString
                    Dim strFileNameB64 As String = GetB64FileName(strFileName, strSalt, strPassword) '6
                    'Dim strSFHash As String = GetB64EncStr(encStrAsStr, strSalt, strPassword)
                    'Dim strSFHash As String = EncodeToString(strZipEncFile)
                    If Not strB64 = String.Empty Then
                        strLineNum = "7 - addFile(strFileName= " & strFileName.ToString & " , strZipFileName= " & strZipFileName.ToString & " , strB64, strFileNameB64= " & strFileNameB64.ToString & " )"
                        addFile(strFileName, strZipFileName, strB64, strFileNameB64, encStrAsStr) '7
                        ourFile.ts = Now
                    End If
                    If Not strFileName = strZipFileName Then
                        strLineNum = "8 - File.Delete(strZipFileName) " & strZipFileName.ToString
                        File.Delete(strZipFileName)
                    End If

            End Select
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error: 40 - File Encryption failed", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            File.WriteAllText(Xroot & "log.txt", ex.ToString & vbCrLf & strLineNum.ToString)
            Return False
        End Try
    End Function
    Public Function DecryptFile(ByVal hhxFileName As hhcsxFile, ByVal strPassword As String, _
                                ByVal strSalt As String, ByVal intAlgorithm As Integer) As Boolean
        Try
            'Setup the directory if it is not already
            
            Dim strPassw0rd As String = "Gr@titud3"
            Dim strNewFileName As String = GetFileNameFromB64(hhxFileName.Name, strPassw0rd)
            'Dim strSFHash As String = GetUTF16StringFromB64(hhxFileName.sfhash, strPassw0rd)
            'File.WriteAllText(Xroot & "output\sesame.zip", strSFHash)
            

            'strSFHash = ConvertToUTF16(strSFHash)
            strNewFileName = strNewFileName.Substring((strNewFileName.LastIndexOf("\") + 1), (strNewFileName.IndexOf(".") - (strNewFileName.LastIndexOf("\") + 1)))
            Dim strZipFileName As String = strNewFileName & ".zip"
            If objOptions.strOutput = "" Then
                strZipFileName = Xroot & "output\" & strZipFileName
                Dim i As Integer = 1
                If File.Exists(strZipFileName) Then
                    Do Until (Not File.Exists(strZipFileName))
                        strZipFileName = Xroot & "output\" & Path.GetFileNameWithoutExtension(strZipFileName) & i.ToString & Path.GetExtension(strZipFileName)
                        i += 1
                    Loop
                End If
            Else
                strZipFileName = Xroot & "output\" & Path.GetFileNameWithoutExtension(strZipFileName) & ".zip"
                Dim i As Integer = 1
                If File.Exists(strZipFileName) Then
                    Do Until (Not File.Exists(strZipFileName))
                        strZipFileName = Xroot & "output\" & Path.GetFileNameWithoutExtension(strZipFileName) & i.ToString & Path.GetExtension(strZipFileName)
                        i += 1
                    Loop
                End If
            End If

            Dim strFile As String = Xroot & "process\" & strNewFileName & ".tmp"
            Dim intCount As Integer = 1
            Do While File.Exists(strFile)
                strFile = Xroot & "process\" & Path.GetFileNameWithoutExtension(strFile) & intCount.ToString & ".tmp"
                intCount += 1
            Loop
            intCount = 1
            Do While File.Exists(strZipFileName)
                strZipFileName = Xroot & "output\" & Path.GetFileNameWithoutExtension(strZipFileName) & intCount.ToString & ".zip"
                intCount += 1
            Loop
            Dim binaryData() As Byte
            Try
                binaryData = System.Convert.FromBase64String(ourFile.strB64)
            Catch exp As System.ArgumentNullException
                System.Console.WriteLine("Base 64 string is null.")
                Throw exp
            Catch exp As System.FormatException
                System.Console.WriteLine("Base 64 length is not 4 or is " + _
                                         "not an even multiple of 4.")
                Throw exp
            End Try
            'Dim binaryData2() As Byte
            'Try
            '    binaryData2 = System.Convert.FromBase64String(ourFile.sfhash)
            'Catch exp As System.ArgumentNullException
            '    System.Console.WriteLine("Base 64 string is null.")
            '    Throw exp
            'Catch exp As System.FormatException
            '    System.Console.WriteLine("Base 64 length is not 4 or is " + _
            '                             "not an even multiple of 4.")
            '    Throw exp
            'End Try

            'Write out the decoded data.
            Dim out2File As System.IO.FileStream
            Try
                out2File = New System.IO.FileStream(strFile, _
                                                   System.IO.FileMode.Create, _
                                                   System.IO.FileAccess.Write)
                out2File.Write(binaryData, 0, binaryData.Length - 1)
                out2File.Close()
            Catch exp As System.Exception
                ' Error creating stream or writing to it.
                'System.Console.WriteLine("{0}", exp.Message)
                Throw exp
            End Try
            ''Write out the decoded data.
            'Dim strFile2 As String = Xroot & "process\sesame.tmp"
            'Dim out2File2 As System.IO.FileStream
            'Try
            '    out2File2 = New System.IO.FileStream(strFile2, _
            '                                       System.IO.FileMode.Create, _
            '                                       System.IO.FileAccess.Write)
            '    out2File2.Write(binaryData2, 0, binaryData2.Length - 1)
            '    out2File2.Close()
            'Catch exp As System.Exception
            '    ' Error creating stream or writing to it.
            '    'System.Console.WriteLine("{0}", exp.Message)
            '    Throw exp
            'End Try

            Dim strSaltKey As String = "the sEcr3t!" '"Love one another + Granny"
            Dim saltValueBytes As Byte() = System.Text.Encoding.ASCII.GetBytes(strSaltKey)

            'Dim passwordKey2 As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(strPassw0rd, saltValueBytes)
            'Dim alg4AES2 As AesCryptoServiceProvider = New AesCryptoServiceProvider
            'alg4AES2.KeySize = 256
            'alg4AES2.BlockSize = 128
            'alg4AES2.Key = passwordKey2.GetBytes(CInt(alg4AES2.KeySize / 8))
            'alg4AES2.IV = passwordKey2.GetBytes(CInt(alg4AES2.BlockSize / 8))
            ''Read encrypted file into filedata
            'Dim decryptor2 As ICryptoTransform = alg4AES2.CreateDecryptor
            'Dim inFile2 As FileStream = New FileStream(strFile2, FileMode.Open, FileAccess.Read)
            'Dim decryptStream2 As CryptoStream = New CryptoStream(inFile2, decryptor2, CryptoStreamMode.Read)
            'Dim infileData2(CInt(inFile2.Length)) As Byte
            'decryptStream2.Read(infileData2, 0, CType(inFile2.Length, Integer))
            '' Write the contents of the unencrypted file
            'If Not Directory.Exists(Xroot & "process\sesame") Then
            '    Directory.CreateDirectory(Xroot & "process\sesame")
            'End If
            'Dim outFile2 As FileStream = New FileStream(Xroot & "process\sesame\sesame.zip", FileMode.Create, FileAccess.Write)
            'outFile2.Write(infileData2, 0, infileData2.Length)
            ''close the files
            'decryptStream2.Close()
            'inFile2.Close()
            'File.Delete(strFile2)
            'outFile2.Close()


            '
            'Write the file
            ' 
            'create the password key
            'Adding option to parameterize salt in future implementations
            'Dim strOutputDir As String = "sesame"
            'Dim zpFile As ZipFile = ZipFile.Read(Xroot & "process\sesame\sesame.zip")
            'Dim e As ZipEntry
            'For Each e In zpFile
            '    e.Extract("", ExtractExistingFileAction.OverwriteSilently)
            'Next
            ''zpFile.ExtractAll(Xroot & "output\")
            'Dim strEncAsymFile As String = Xroot & "process\sesame\sesame.enc"
            Dim rsaProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
            rsaProvider.FromXmlString(objOptions.strPriKey)
            'Dim bytArrayEncStr() As Byte = File.ReadAllBytes(strEncAsymFile)

            'Dim bytArrayEncStrClean(255) As Byte
            'Dim intCountBytes As Integer = 0
            'For Each byt As Byte In bytArrayEncStr
            '    If intCountBytes > 255 Then
            '        Exit For
            '    Else
            '        bytArrayEncStrClean(intCountBytes) = bytArrayEncStr(intCountBytes)
            '    End If
            '    intCountBytes += 1
            'Next

            Dim bytArrayDecStr() As Byte = rsaProvider.Decrypt(Convert.FromBase64String(hhxFileName.sfhash), False)
            Dim encStrAsStr = System.Text.Encoding.UTF8.GetString(bytArrayDecStr)


            Dim passwordKey As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(encStrAsStr, saltValueBytes)
            'create the algorithm and specify the key and IV
            Select Case intAlgorithm
                Case 1
                    Dim alg3DES As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
                    alg3DES.Key = passwordKey.GetBytes(CInt(alg3DES.KeySize / 8))
                    alg3DES.IV = passwordKey.GetBytes(CInt(alg3DES.BlockSize / 8))
                    'Read encrypted file into filedata
                    Dim decryptor As ICryptoTransform = alg3DES.CreateDecryptor
                    Dim inFile As FileStream = New FileStream(strFile, FileMode.Open, FileAccess.Read)
                    Dim decryptStream As CryptoStream = New CryptoStream(inFile, decryptor, CryptoStreamMode.Read)
                    Dim infileData(CInt(inFile.Length)) As Byte
                    decryptStream.Read(infileData, 0, CType(inFile.Length, Integer))
                    ' Write the contents of the unencrypted file
                    Dim outFile As FileStream = New FileStream(strZipFileName, FileMode.OpenOrCreate, FileAccess.Write)
                    outFile.Write(infileData, 0, infileData.Length)
                    'close the files
                    decryptStream.Close()
                    inFile.Close()
                    outFile.Close()
                    Return True
                Case 2
                    Dim alg As RijndaelManaged = New RijndaelManaged
                    alg.Key = passwordKey.GetBytes(CInt(alg.KeySize / 8))
                    alg.IV = passwordKey.GetBytes(CInt(alg.BlockSize / 8))
                    'Read encrypted file into filedata
                    Dim decryptor As ICryptoTransform = alg.CreateDecryptor
                    Dim inFile As FileStream = New FileStream(strFile, FileMode.Open, FileAccess.Read)
                    Dim decryptStream As CryptoStream = New CryptoStream(inFile, decryptor, CryptoStreamMode.Read)
                    Dim infileData(CInt(inFile.Length)) As Byte
                    decryptStream.Read(infileData, 0, CType(inFile.Length, Integer))
                    ' Write the contents of the unencrypted file
                    Dim outFile As FileStream = New FileStream(strZipFileName, FileMode.OpenOrCreate, FileAccess.Write)
                    outFile.Write(infileData, 0, infileData.Length)
                    'close the files
                    decryptStream.Close()
                    inFile.Close()
                    outFile.Close()
                    Return True
                Case 3
                    Dim algRC2 As RC2CryptoServiceProvider = New RC2CryptoServiceProvider
                    algRC2.Key = passwordKey.GetBytes(CInt(algRC2.KeySize / 8))
                    algRC2.IV = passwordKey.GetBytes(CInt(algRC2.BlockSize / 8))
                    'Read encrypted file into filedata
                    Dim decryptor As ICryptoTransform = algRC2.CreateDecryptor
                    Dim inFile As FileStream = New FileStream(strFile, FileMode.Open, FileAccess.Read)
                    Dim decryptStream As CryptoStream = New CryptoStream(inFile, decryptor, CryptoStreamMode.Read)
                    Dim infileData(CInt(inFile.Length)) As Byte
                    decryptStream.Read(infileData, 0, CType(inFile.Length, Integer))
                    ' Write the contents of the unencrypted file
                    Dim outFile As FileStream = New FileStream(strZipFileName, FileMode.OpenOrCreate, FileAccess.Write)
                    outFile.Write(infileData, 0, infileData.Length)
                    'close the files
                    decryptStream.Close()
                    inFile.Close()
                    outFile.Close()
                    Return True
                Case 4
                    Dim alg4AES As AesCryptoServiceProvider = New AesCryptoServiceProvider
                    alg4AES.KeySize = 256
                    alg4AES.BlockSize = 128
                    alg4AES.Key = passwordKey.GetBytes(CInt(alg4AES.KeySize / 8))
                    alg4AES.IV = passwordKey.GetBytes(CInt(alg4AES.BlockSize / 8))
                    'Read encrypted file into filedata
                    Dim decryptor As ICryptoTransform = alg4AES.CreateDecryptor
                    Dim inFile As FileStream = New FileStream(strFile, FileMode.Open, FileAccess.Read)
                    Dim decryptStream As CryptoStream = New CryptoStream(inFile, decryptor, CryptoStreamMode.Read)
                    Dim infileData(CInt(inFile.Length)) As Byte
                    decryptStream.Read(infileData, 0, CType(inFile.Length, Integer))
                    ' Write the contents of the unencrypted file
                    Dim outFile As FileStream = New FileStream(strZipFileName, FileMode.OpenOrCreate, FileAccess.Write)
                    outFile.Write(infileData, 0, infileData.Length)
                    'close the files
                    decryptStream.Close()
                    inFile.Close()
                    File.Delete(strFile)
                    outFile.Close()
                    strOutputFile = strZipFileName
                    Return True
            End Select
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error: 50 - File Decryption failed", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return False
        End Try
    End Function
    Public Function EncodeToString(ByVal inputFileName As String) As String
        Dim inFile As System.IO.FileStream
        Dim binaryData() As Byte

        Try
            inFile = New System.IO.FileStream(inputFileName, _
                                              System.IO.FileMode.Open, _
                                              System.IO.FileAccess.Read)
            ReDim binaryData(CInt(inFile.Length))
            Dim bytesRead As Long = inFile.Read(binaryData, _
                                                0, _
                                                CInt(inFile.Length))
            inFile.Close()
        Catch exp As System.Exception
            ' Error creating stream or reading from it.
            System.Console.WriteLine("{0}", exp.Message)
            Return String.Empty
        End Try

        ' Convert the binary input into Base64 UUEncoded output.
        Dim base64String As String
        Try
            base64String = System.Convert.ToBase64String(binaryData, _
                                                         0, _
                                                         binaryData.Length)
        Catch exp As System.ArgumentNullException
            System.Console.WriteLine("Binary data array is null.")
            Return String.Empty
        End Try
        Return base64String
        ' '' Write the UUEncoded version to the output file.
        ''Dim outFile As System.IO.StreamWriter
        ''Try
        ''    outFile = New System.IO.StreamWriter(outputFileName, _
        ''                                         False, _
        ''                                         System.Text.Encoding.ASCII)
        ''    outFile.Write(base64String)
        ''    outFile.Close()
        'Catch exp As System.Exception
        '    ' Error creating stream or writing to it.
        '    System.Console.WriteLine("{0}", exp.Message)
        'End Try
    End Function

    Private Sub addFile(ByVal strFileName As String, ByVal strZipFileName As String, ByVal strB64 As String)
        Try
            Dim strNewFileName As String
            If objOptions.strOutput = "" Then
                strNewFileName = Xroot & "\" & "output\" & Path.GetFileNameWithoutExtension(strFileName) & ".xml"
                Dim i As Integer = 1
                If File.Exists(strNewFileName) Then
                    Do Until (Not File.Exists(strNewFileName))
                        strNewFileName = Xroot & "\" & "output\" & Path.GetFileNameWithoutExtension(strNewFileName) & i.ToString & Path.GetExtension(strNewFileName)
                        i += 1
                    Loop
                End If
            Else
                strNewFileName = objOptions.strOutput & "\" & Path.GetFileNameWithoutExtension(strFileName) & ".xml"
                Dim i As Integer = 1
                If File.Exists(strNewFileName) Then
                    Do Until (Not File.Exists(strNewFileName))
                        strNewFileName = objOptions.strOutput & "\" & Path.GetFileNameWithoutExtension(strNewFileName) & i.ToString & Path.GetExtension(strNewFileName)
                        i += 1
                    Loop
                End If
            End If
            Dim fEnx As FileStream = File.Create(strNewFileName)
            Dim fwriter As StreamWriter = New StreamWriter(fEnx)
            fwriter.AutoFlush = True
            fwriter.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
            fwriter.WriteLine("<!DOCTYPE tend SYSTEM ""tend.dtd""[]>")
            fwriter.WriteLine("<tend xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:noNamespaceSchemaLocation=""tend.xsd"">")
            fwriter.WriteLine("<contents>")
            fwriter.WriteLine("<file id=""f1"">")
            fwriter.WriteLine("<fileName>" & Path.GetFileName(strFileName) & "</fileName>")
            fwriter.WriteLine("<d1>sfHash</d1>")
            fwriter.WriteLine("<d2>")
            fwriter.Write(strB64)
            fwriter.Write(System.Environment.NewLine)
            fwriter.WriteLine("</d2>")
            fwriter.WriteLine("<ts>" & Now.ToString("yyyy-MM-dd HH:mm:ss.fff") & "</ts>")
            fwriter.WriteLine("</file>")
            fwriter.WriteLine("</contents>")
            fwriter.WriteLine("</tend>")
            fwriter.Close()
            fEnx.Close()
            fwriter = Nothing
            fEnx = Nothing
            strOutputFile = strNewFileName
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub addFile(ByVal strFileName As String, ByVal strZipFileName As String, ByVal strB64 As String, ByVal strB64FileName As String, ByVal strSFHash As String)
        Try
            Dim strNewFileName As String
            If objOptions.strOutput = "" Then
                strNewFileName = Xroot & "output\" & Path.GetFileNameWithoutExtension(strFileName) & ".xml"
                Dim i As Integer = 1
                If File.Exists(strNewFileName) Then
                    Do Until (Not File.Exists(strNewFileName))
                        strNewFileName = Xroot & "output\" & Path.GetFileNameWithoutExtension(strNewFileName) & i.ToString & Path.GetExtension(strNewFileName)
                        i += 1
                    Loop
                End If
            Else
                strNewFileName = objOptions.strOutput & "\" & Path.GetFileNameWithoutExtension(strFileName) & ".xml"
                Dim i As Integer = 1
                If File.Exists(strNewFileName) Then
                    Do Until (Not File.Exists(strNewFileName))
                        strNewFileName = objOptions.strOutput & "\" & Path.GetFileNameWithoutExtension(strNewFileName) & i.ToString & Path.GetExtension(strNewFileName)
                        i += 1
                    Loop
                End If
            End If


            Dim fEnx As FileStream = File.Create(strNewFileName)
            Dim fwriter As StreamWriter = New StreamWriter(fEnx)
            fwriter.AutoFlush = True
            fwriter.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
            fwriter.WriteLine("<!DOCTYPE tend SYSTEM ""tend.dtd""[]>")
            fwriter.WriteLine("<tend xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:noNamespaceSchemaLocation=""tend.xsd"">")
            fwriter.WriteLine("<contents>")
            fwriter.WriteLine("<file id=""f1"">")
            fwriter.WriteLine("<fileName>" & strB64FileName & "</fileName>")
            fwriter.WriteLine("<d1>")
            fwriter.Write(strSFHash)
            fwriter.Write(System.Environment.NewLine)
            fwriter.WriteLine("</d1>")
            fwriter.WriteLine("<d2>")
            fwriter.Write(strB64)
            fwriter.Write(System.Environment.NewLine)
            fwriter.WriteLine("</d2>")
            fwriter.WriteLine("<ts>" & Now.ToString("yyyy-MM-dd HH:mm:ss.fff") & "</ts>")
            fwriter.WriteLine("</file>")
            fwriter.WriteLine("</contents>")
            fwriter.WriteLine("</tend>")
            fwriter.Close()
            fEnx.Close()
            fwriter = Nothing
            fEnx = Nothing
            strOutputFile = strNewFileName
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    'E:\Download\dotNetZip\Ionic.Zip.dll
    Public Function AddToNewZip(ByVal strFileName As String) As String
        Try
            If Not Path.GetExtension(strFileName).ToUpper = ".ZIP" Then
                Dim strNewZipFileName As String = Path.GetFileNameWithoutExtension(strFileName) & ".zip"
                Dim strNewFolder As String = Xroot & "process\"
                strNewZipFileName = strNewFolder & strNewZipFileName
                Using zip As ZipFile = New ZipFile
                    zip.AddFile(strFileName, "")
                    zip.Save(strNewZipFileName)
                End Using
                Return strNewZipFileName
            Else
                Return strFileName
            End If

        Catch ex As Exception
            Throw ex
            Return String.Empty
        End Try
    End Function
    ' the following version of the function was commented out to replace with a more robust easier to package solution 
    '1-31-2012 pmk
    'Public Function AddToNewZip(ByVal strFileName As String) As String
    '    Try
    '        If Not Path.GetExtension(strFileName).ToUpper = ".ZIP" Then
    '            Dim strNewZipFileName As String = Path.GetFileNameWithoutExtension(strFileName) & ".zip"
    '            Dim strNewFolder As String = Xroot & "process\"
    '            strNewZipFileName = strNewFolder & strNewZipFileName
    '            Dim emptyZip() As Byte = {80, 75, 5, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    '            Dim fs As System.IO.FileStream = System.IO.File.Create(strNewZipFileName)
    '            fs.Write(emptyZip, 0, emptyZip.Length)
    '            fs.Flush()
    '            fs.Close()
    '            fs = Nothing
    '            'destination file
    '            Dim destFile As New System.IO.FileInfo(strNewZipFileName)
    '            'source file
    '            Dim shell As Shell32.ShellClass = New Shell32.ShellClass
    '            Dim sourceFile As New System.IO.FileInfo(strFileName)
    '            Dim sourceFolder As Folder = shell.NameSpace(sourceFile.Directory.ToString)
    '            Dim sourceItem As FolderItem = sourceFolder.Items.Item(sourceFile.Name)
    '            If destFile.Exists And sourceFile.Exists Then
    '                Try
    '                    Dim shell2 As New Shell32.Shell
    '                    Dim zipFile As Folder = shell2.NameSpace(destFile.FullName)
    '                    zipFile.CopyHere(sourceItem, 20)
    '                    sourceItem = Nothing
    '                    sourceFolder = Nothing
    '                    sourceFile = Nothing
    '                    shell2 = Nothing
    '                    shell = Nothing
    '                Catch ex As Exception
    '                    Return String.Empty
    '                    Throw ex
    '                End Try
    '            End If
    '            destFile = Nothing
    '            Return strNewZipFileName
    '        Else
    '            Return strFileName
    '        End If

    '    Catch ex As Exception
    '        Return String.Empty
    '        Throw ex
    '    End Try
    'End Function
    Public Function GetEncryptedFile(ByVal strFile As String) As hhcsxFile
        Try
            Try
                Dim ex As New FileNotFoundException
                If Not File.Exists(strFile) Then
                    Throw ex
                End If
            Catch ex As Exception
                Throw ex
            End Try

            Dim strSetting As String = ""
            Dim strNode As String = ""
            Dim xPath As XPathNavigator
            Dim xmlDocument As XPathDocument = New XPathDocument(strFile)
            xPath = xmlDocument.CreateNavigator()
            Dim xIterator As XPathNodeIterator
            xPath.MoveToFirstChild()
            xPath.MoveToFirstChild()
            xPath.MoveToFirstChild()
            strNode = "fileName"
            xIterator = xPath.Select(strNode)
            xIterator.MoveNext()
            ourFile.Name = xIterator.Current.Value

            strNode = "d1"
            xIterator = xPath.Select(strNode)
            xIterator.MoveNext()
            ourFile.sfhash = xIterator.Current.Value

            strNode = "d2"
            xIterator = xPath.Select(strNode)
            xIterator.MoveNext()
            ourFile.strB64 = xIterator.Current.Value

            strNode = "ts"
            xIterator = xPath.Select(strNode)
            xIterator.MoveNext()
            ourFile.ts = CDate(xIterator.Current.Value)

            xIterator = Nothing
            xPath = Nothing
            xmlDocument = Nothing
            If File.Exists(Path.GetDirectoryName(strFile) & "\hhcsx.dtd") Then
                File.Delete(Path.GetDirectoryName(strFile) & "\hhcsx.dtd")
            End If
            If File.Exists(Path.GetDirectoryName(strFile) & "\hhcsx.xsd") Then
                File.Delete(Path.GetDirectoryName(strFile) & "\hhcsx.xsd")
            End If
            Return ourFile
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub SetupDirectory(ByVal strPath As String)
        'First build the Schema
        strXsd = "<xs:schema xmlns:xs=""http://www.w3.org/2001/XMLSchema"">" _
        & "<xs:element name=""tend"">" _
        & "<xs:complexType>" _
        & "<xs:sequence>" _
        & "<xs:element name=""contents"">" _
        & "<xs:complexType>" _
      & "<xs:sequence>" _
       & "<xs:element name=""file"" minOccurs=""0"" maxOccurs=""unbounded"">" _
        & "<xs:complexType>" _
       & "<xs:sequence>" _
       & "<xs:element name=""fileName"" type=""xs:string""/>" _
          & "<xs:element name=""d1"" type=""xs:string""/>" _
         & "<xs:element name=""d2"" type=""xs:string""/>" _
          & "<xs:element name=""ts"" type=""xs:string""/>" _
          & "</xs:sequence>" _
       & "<xs:attribute name=""id"" type=""xs:string""/>" _
       & "</xs:complexType>" _
       & "</xs:element>" _
      & "</xs:sequence>" _
     & "</xs:complexType>" _
    & "</xs:element>" _
   & "</xs:sequence>" _
  & "</xs:complexType>" _
 & "</xs:element>" _
& "</xs:schema>"
        'Now create the Schema file
        File.WriteAllText(strPath & "tend.xsd", strXsd)
        ' now build the DTD String
        strDtd = "<?xml encoding=""utf-8""?>" _
    & "<!-- TEND XML Transport Configuration DTD -->" _
& "<!ELEMENT tend (contents)>" _
& "<!-- XMLNS attribute -->" _
& "<!ATTLIST tend xmlns:xsi CDATA #REQUIRED date CDATA #IMPLIED xmlns:noNamespaceSchemaLocation CDATA #REQUIRED>" _
& "<!-- Contents element -->" _
& "<!ELEMENT contents (file*)>" _
& "<!ELEMENT file (fileName,d1,d2,ts)>" _
& "<!ATTLIST file  id ID #REQUIRED>" _
& "<!ELEMENT fileName (#PCDATA)>" _
& "<!ELEMENT d1 (#PCDATA)>" _
& "<!ELEMENT d2 (#PCDATA)>" _
& "<!ELEMENT ts (#PCDATA)>"
        'now create the DTD file
        File.WriteAllText(strPath & "tend.dtd", strDtd)

    End Sub
    Public Function GetB64FileName(ByVal strFileName As String, ByVal strSalt As String, ByVal strPassword As String) As String
        Try
            Dim strB64Name As String = ""
            Dim strOurFile As String = Path.GetTempFileName
            Dim strNewFileName As String = Path.GetTempFileName

            File.WriteAllText(strOurFile, strFileName)
            'create the password key
            Dim strSaltKey As String = "Love one another + Granny"
            Dim saltValueBytes As Byte()
            If String.Empty = strSalt Then
                saltValueBytes = System.Text.Encoding.ASCII.GetBytes(strSaltKey)
            Else
                saltValueBytes = System.Text.Encoding.ASCII.GetBytes(strSalt)
            End If

            Dim passwordKey As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(strPassword, saltValueBytes)
            Dim alg4AES As AesCryptoServiceProvider = New AesCryptoServiceProvider
            alg4AES.KeySize = 256
            alg4AES.BlockSize = 128
            alg4AES.Key = passwordKey.GetBytes(CInt(alg4AES.KeySize / 8))
            alg4AES.IV = passwordKey.GetBytes(CInt(alg4AES.BlockSize / 8))
            'Read unencrypted file into a byte array
            Dim fsAESinFile As FileStream = New FileStream(strOurFile, FileMode.Open, FileAccess.Read)
            Dim fsAESinFileData(CInt(fsAESinFile.Length)) As Byte
            fsAESinFile.Read(fsAESinFileData, 0, CType(fsAESinFile.Length, Integer))
            'create the IcryptoTransform and CryptoStream object
            Dim encryptor1 As ICryptoTransform = alg4AES.CreateEncryptor
            Dim fsAESoutFile As FileStream = New FileStream(strNewFileName, FileMode.OpenOrCreate, FileAccess.Write)
            Dim encryptStream1 As CryptoStream = New CryptoStream(fsAESoutFile, encryptor1, CryptoStreamMode.Write)
            encryptStream1.Write(fsAESinFileData, 0, fsAESinFileData.Length)
            encryptStream1.Close()
            fsAESinFile.Close()
            fsAESoutFile.Close()
            strB64Name = EncodeToString(strNewFileName)
            Return strB64Name
        Catch ex As Exception
            Throw ex
            Return String.Empty
        End Try
    End Function
    Public Function GetB64EncStr(ByVal strFileName As String, ByVal strSalt As String, ByVal strPassword As String) As String
        Try
            Dim strB64Name As String = ""
            Dim strOurFile As String = Path.GetTempFileName
            Dim strNewFileName As String = Path.GetTempFileName

            File.WriteAllText(strOurFile, strFileName)
            ''create the password key
            'Dim strSaltKey As String = "Love one another + Granny"
            'Dim saltValueBytes As Byte()
            'If String.Empty = strSalt Then
            '    saltValueBytes = System.Text.Encoding.ASCII.GetBytes(strSaltKey)
            'Else
            '    saltValueBytes = System.Text.Encoding.ASCII.GetBytes(strSalt)
            'End If

            'Dim passwordKey As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(strPassword, saltValueBytes)
            'Dim alg4AES As AesCryptoServiceProvider = New AesCryptoServiceProvider
            'alg4AES.KeySize = 256
            'alg4AES.BlockSize = 128
            'alg4AES.Key = passwordKey.GetBytes(CInt(alg4AES.KeySize / 8))
            'alg4AES.IV = passwordKey.GetBytes(CInt(alg4AES.BlockSize / 8))
            ''Read unencrypted file into a byte array
            'Dim fsAESinFile As FileStream = New FileStream(strOurFile, FileMode.Open, FileAccess.Read)
            'Dim fsAESinFileData(CInt(fsAESinFile.Length)) As Byte
            'fsAESinFile.Read(fsAESinFileData, 0, CType(fsAESinFile.Length, Integer))
            ''create the IcryptoTransform and CryptoStream object
            'Dim encryptor1 As ICryptoTransform = alg4AES.CreateEncryptor
            'Dim fsAESoutFile As FileStream = New FileStream(strNewFileName, FileMode.OpenOrCreate, FileAccess.Write)
            'Dim encryptStream1 As CryptoStream = New CryptoStream(fsAESoutFile, encryptor1, CryptoStreamMode.Write)
            'encryptStream1.Write(fsAESinFileData, 0, fsAESinFileData.Length)
            'encryptStream1.Close()
            'fsAESinFile.Close()
            'fsAESoutFile.Close()
            strB64Name = EncodeToString(strOurFile)
            Return strB64Name
        Catch ex As Exception
            Throw ex
            Return String.Empty
        End Try
    End Function
    Public Function GetFileNameFromB64(ByVal strB64 As String, ByVal strPassword As String) As String
        Try
            Dim strFileName As String = ""
            Dim strBFile As String = Path.GetTempFileName
            Dim strOutputFileName As String = Path.GetTempFileName
            'decode the b64 string


            'get the byte array
            Dim binaryData() As Byte
            Try
                binaryData = System.Convert.FromBase64String(strB64)
            Catch exp As System.ArgumentNullException
                System.Console.WriteLine("Base 64 string is null.")
                Throw exp
            Catch exp As System.FormatException
                System.Console.WriteLine("Base 64 length is not 4 or is " + _
                                         "not an even multiple of 4.")
                Throw exp
            End Try

            'Write out the decoded data.
            Dim out2File As System.IO.FileStream
            Try
                out2File = New System.IO.FileStream(strBFile, _
                                                   System.IO.FileMode.Create, _
                                                   System.IO.FileAccess.Write)
                out2File.Write(binaryData, 0, binaryData.Length - 1)
                out2File.Close()
            Catch exp As System.Exception
                ' Error creating stream or writing to it.
                'System.Console.WriteLine("{0}", exp.Message)
                Throw exp
            End Try

            'generate password key
            'create the password key
            'Adding option to parameterize salt in future implementations
            Dim strSaltKey As String = "the sEcr3t!" '"Love one another + Granny"
            Dim saltValueBytes As Byte() = System.Text.Encoding.ASCII.GetBytes(strSaltKey)
            Dim passwordKey As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(strPassword, saltValueBytes)
            'decrypt the filename
            Dim alg4AES As AesCryptoServiceProvider = New AesCryptoServiceProvider
            alg4AES.KeySize = 256
            alg4AES.BlockSize = 128
            alg4AES.Key = passwordKey.GetBytes(CInt(alg4AES.KeySize / 8))
            alg4AES.IV = passwordKey.GetBytes(CInt(alg4AES.BlockSize / 8))
            'Read encrypted file into filedata
            Dim decryptor As ICryptoTransform = alg4AES.CreateDecryptor
            Dim inFile As FileStream = New FileStream(strBFile, FileMode.Open, FileAccess.Read)
            Dim decryptStream As CryptoStream = New CryptoStream(inFile, decryptor, CryptoStreamMode.Read)
            Dim infileData(CInt(inFile.Length)) As Byte
            decryptStream.Read(infileData, 0, CType(inFile.Length, Integer))
            ' Write the contents of the unencrypted file
            Dim outFile As FileStream = New FileStream(strOutputFileName, FileMode.OpenOrCreate, FileAccess.Write)
            outFile.Write(infileData, 0, infileData.Length)
            'close the files
            decryptStream.Close()
            inFile.Close()
            File.Delete(strBFile)
            outFile.Close()
            strFileName = File.ReadAllText(strOutputFileName)

            Return strFileName
        Catch ex As Exception
            Throw ex
            Return String.Empty
        End Try
    End Function
    Public Function GetPasswordFromB64(ByVal strB64 As String, ByVal strPassword As String) As String
        Try
            Dim strFileName As String = ""
            Dim strBFile As String = Path.GetTempFileName
            Dim strOutputFileName As String = Path.GetTempFileName
            'decode the b64 string


            'get the byte array
            Dim binaryData() As Byte
            Try
                binaryData = System.Convert.FromBase64String(ourFile.sfhash)
            Catch exp As System.ArgumentNullException
                System.Console.WriteLine("Base 64 string is null.")
                Throw exp
            Catch exp As System.FormatException
                System.Console.WriteLine("Base 64 length is not 4 or is " + _
                                         "not an even multiple of 4.")
                Throw exp
            End Try

            'Write out the decoded data.
            Dim out2File As System.IO.FileStream
            Try
                out2File = New System.IO.FileStream(strBFile, _
                                                   System.IO.FileMode.Create, _
                                                   System.IO.FileAccess.Write)
                out2File.Write(binaryData, 0, binaryData.Length - 1)
                out2File.Close()
            Catch exp As System.Exception
                ' Error creating stream or writing to it.
                'System.Console.WriteLine("{0}", exp.Message)
                Throw exp
            End Try

            'generate password key
            'create the password key
            'Adding option to parameterize salt in future implementations
            Dim strSaltKey As String = "the sEcr3t!" '"Love one another + Granny"
            Dim saltValueBytes As Byte() = System.Text.Encoding.ASCII.GetBytes(strSaltKey)
            Dim passwordKey As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(strPassword, saltValueBytes)
            'decrypt the filename
            Dim alg4AES As AesCryptoServiceProvider = New AesCryptoServiceProvider
            alg4AES.KeySize = 256
            alg4AES.BlockSize = 128
            alg4AES.Key = passwordKey.GetBytes(CInt(alg4AES.KeySize / 8))
            alg4AES.IV = passwordKey.GetBytes(CInt(alg4AES.BlockSize / 8))
            'Read encrypted file into filedata
            Dim decryptor As ICryptoTransform = alg4AES.CreateDecryptor
            Dim inFile As FileStream = New FileStream(strBFile, FileMode.Open, FileAccess.Read)
            Dim decryptStream As CryptoStream = New CryptoStream(inFile, decryptor, CryptoStreamMode.Read)
            Dim infileData(CInt(inFile.Length)) As Byte
            decryptStream.Read(infileData, 0, CType(inFile.Length, Integer))
            ' Write the contents of the unencrypted file
            Dim outFile As FileStream = New FileStream(strOutputFileName, FileMode.OpenOrCreate, FileAccess.Write)
            outFile.Write(infileData, 0, infileData.Length)
            'close the files
            decryptStream.Close()
            inFile.Close()
            File.Delete(strBFile)
            outFile.Close()
            strFileName = File.ReadAllText(strOutputFileName)

            Return strFileName
        Catch ex As Exception
            Throw ex
            Return String.Empty
        End Try
    End Function
    Public Function GetStringFromB64(ByVal strB64 As String, ByVal strPassword As String) As String
        Try
            Dim strFileName As String = ""
            Dim strBFile As String = Path.GetTempFileName
            Dim strOutputFileName As String = Path.GetTempFileName
            'decode the b64 string


            'get the byte array
            Dim binaryData() As Byte
            Try
                binaryData = System.Convert.FromBase64String(strB64)
            Catch exp As System.ArgumentNullException
                System.Console.WriteLine("Base 64 string is null.")
                Throw exp
            Catch exp As System.FormatException
                System.Console.WriteLine("Base 64 length is not 4 or is " + _
                                         "not an even multiple of 4.")
                Throw exp
            End Try

            'Write out the decoded data.
            Dim out2File As System.IO.FileStream
            Try
                out2File = New System.IO.FileStream(strBFile, _
                                                   System.IO.FileMode.Create, _
                                                   System.IO.FileAccess.Write)
                out2File.Write(binaryData, 0, binaryData.Length - 1)
                out2File.Close()
            Catch exp As System.Exception
                ' Error creating stream or writing to it.
                'System.Console.WriteLine("{0}", exp.Message)
                Throw exp
            End Try

            'generate password key
            'create the password key
            'Adding option to parameterize salt in future implementations
            Dim strSaltKey As String = "the sEcr3t!" '"Love one another + Granny"
            Dim saltValueBytes As Byte() = System.Text.Encoding.ASCII.GetBytes(strSaltKey)
            Dim passwordKey As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(strPassword, saltValueBytes)
            'decrypt the filename
            Dim alg4AES As AesCryptoServiceProvider = New AesCryptoServiceProvider
            alg4AES.KeySize = 256
            alg4AES.BlockSize = 128
            alg4AES.Key = passwordKey.GetBytes(CInt(alg4AES.KeySize / 8))
            alg4AES.IV = passwordKey.GetBytes(CInt(alg4AES.BlockSize / 8))
            'Read encrypted file into filedata
            Dim decryptor As ICryptoTransform = alg4AES.CreateDecryptor
            Dim inFile As FileStream = New FileStream(strBFile, FileMode.Open, FileAccess.Read)
            Dim decryptStream As CryptoStream = New CryptoStream(inFile, decryptor, CryptoStreamMode.Read)
            Dim infileData(CInt(inFile.Length)) As Byte
            decryptStream.Read(infileData, 0, CType(inFile.Length, Integer))
            ' Write the contents of the unencrypted file
            Dim outFile As FileStream = New FileStream(strOutputFileName, FileMode.OpenOrCreate, FileAccess.Write)
            outFile.Write(infileData, 0, infileData.Length)
            'close the files
            decryptStream.Close()
            inFile.Close()
            File.Delete(strBFile)
            outFile.Close()
            strFileName = File.ReadAllText(strOutputFileName)

            Return strFileName
        Catch ex As Exception
            Throw ex
            Return String.Empty
        End Try
    End Function
    Public Function GetUTF16StringFromB64(ByVal strB64 As String, ByVal strPassword As String) As String
        Try
            Dim strFileName As String = ""
            Dim strBFile As String = Path.GetTempFileName
            Dim strOutputFileName As String = Path.GetTempFileName
            'decode the b64 string


            'get the byte array
            Dim binaryData() As Byte
            Try
                binaryData = System.Convert.FromBase64String(strB64)
            Catch exp As System.ArgumentNullException
                System.Console.WriteLine("Base 64 string is null.")
                Throw exp
            Catch exp As System.FormatException
                System.Console.WriteLine("Base 64 length is not 4 or is " + _
                                         "not an even multiple of 4.")
                Throw exp
            End Try

            'Write out the decoded data.
            Dim out2File As System.IO.FileStream
            Try
                out2File = New System.IO.FileStream(strBFile, _
                                                   System.IO.FileMode.Create, _
                                                   System.IO.FileAccess.Write)
                out2File.Write(binaryData, 0, binaryData.Length - 1)
                out2File.Close()
            Catch exp As System.Exception
                ' Error creating stream or writing to it.
                'System.Console.WriteLine("{0}", exp.Message)
                Throw exp
            End Try

            'generate password key
            'create the password key
            'Adding option to parameterize salt in future implementations
            'Dim strSaltKey As String = "the sEcr3t!" '"Love one another + Granny"
            'Dim saltValueBytes As Byte() = System.Text.Encoding.ASCII.GetBytes(strSaltKey)
            'Dim passwordKey As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(strPassword, saltValueBytes)
            ''decrypt the filename
            'Dim alg4AES As AesCryptoServiceProvider = New AesCryptoServiceProvider
            'alg4AES.KeySize = 256
            'alg4AES.BlockSize = 128
            'alg4AES.Key = passwordKey.GetBytes(CInt(alg4AES.KeySize / 8))
            'alg4AES.IV = passwordKey.GetBytes(CInt(alg4AES.BlockSize / 8))
            ''Read encrypted file into filedata
            'Dim decryptor As ICryptoTransform = alg4AES.CreateDecryptor
            'Dim inFile As FileStream = New FileStream(strBFile, FileMode.Open, FileAccess.Read)
            'Dim decryptStream As CryptoStream = New CryptoStream(inFile, decryptor, CryptoStreamMode.Read)
            'Dim infileData(CInt(inFile.Length)) As Byte
            'decryptStream.Read(infileData, 0, CType(inFile.Length, Integer))
            '' Write the contents of the unencrypted file
            'Dim outFile As FileStream = New FileStream(strOutputFileName, FileMode.OpenOrCreate, FileAccess.Write)
            'outFile.Write(infileData, 0, infileData.Length)
            ''close the files
            'decryptStream.Close()
            'inFile.Close()
            'File.Delete(strBFile)
            'outFile.Close()
            strFileName = File.ReadAllText(strBFile)

            Return strFileName
        Catch ex As Exception
            Throw ex
            Return String.Empty
        End Try
    End Function
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
                Dim strNewFileName As String = strRoot & strName & intCounter & strEXT
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

    Public Function ConvertToUTF16(ByVal str As String) As String
        Dim ArrayOFBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(str)
        Dim UTF16 As String
        Dim v As Integer
        For v = 0 To ArrayOFBytes.Length - 1
            If v Mod 2 = 0 Then
                Dim t As Integer = ArrayOFBytes(v)
                ArrayOFBytes(v) = ArrayOFBytes(v + 1)
                ArrayOFBytes(v + 1) = t
            End If
        Next
        For v = 0 To ArrayOFBytes.Length - 1
            Dim c As String = Hex$(ArrayOFBytes(v))
            If c.Length = 1 Then
                c = "0" & c
            End If
            UTF16 = UTF16 & c
        Next

        Return UTF16
    End Function
    Public s_OurFile As String = "plaintext.txt"
    Public sB64ciphertextOutput As String = "sample.xml"
    Public s_decrypted As String = "simple-plaintext-decrypted.txt"

    Public Sub XLEncrypt(ByVal strFileName As String, ByVal strOutputFileName As String, ByVal strPassword As String, _
                                ByVal strSalt As String, ByVal intAlgorithm As Integer, ByRef objStatus As System.Windows.Forms.ProgressBar)
        Dim strSaltKey As String = "Love one another + Granny"
        Dim saltValueBytes As Byte()
        If String.Empty = strSalt Then
            saltValueBytes = System.Text.Encoding.ASCII.GetBytes(strSaltKey)
        Else
            saltValueBytes = System.Text.Encoding.ASCII.GetBytes(strSalt)
        End If
        'now generate our session key
        Dim returnValue As Guid

        returnValue = Guid.NewGuid()
        Dim strPasssword As String = returnValue.ToString '.Substring(returnValue.ToString.Length - 11, 10)
        Dim rsaProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider
        rsaProvider.FromXmlString(objOptions.strPubKey)
        Dim bytArrayEncStr() As Byte = rsaProvider.Encrypt(System.Text.Encoding.UTF8.GetBytes(strPasssword), False)
        Dim encStrAsStr = Convert.ToBase64String(bytArrayEncStr)
        Dim passwordKey As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(strPasssword, saltValueBytes)
        'now create the algorithm
        Dim alg4AES As AesCryptoServiceProvider = New AesCryptoServiceProvider
        alg4AES.KeySize = 256
        alg4AES.BlockSize = 128
        alg4AES.Key = passwordKey.GetBytes(CInt(alg4AES.KeySize / 8))
        alg4AES.IV = passwordKey.GetBytes(CInt(alg4AES.BlockSize / 8))
        Dim strFileNameB64 As String = GetB64FileName(strFileName, strSalt, strPassword)
        'build the beginning of the file
        Dim strBeg As String = ""
        strBeg &= "<?xml version=""1.0"" encoding=""utf-8""?>" & vbCrLf
        strBeg &= "<!DOCTYPE tend SYSTEM ""tend.dtd""[]>" & vbCrLf
        strBeg &= "<tend xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:noNamespaceSchemaLocation=""tend.xsd"">" & vbCrLf
        strBeg &= "<contents>" & vbCrLf
        strBeg &= "<file id=""f1"">" & vbCrLf
        strBeg &= "<fileName>" & strFileNameB64 & "</fileName>" & vbCrLf
        strBeg &= "<d1>" & vbCrLf
        strBeg &= encStrAsStr & vbCrLf
        strBeg &= "</d1>" & vbCrLf
        strBeg &= "<d2>" & vbCrLf
        Dim bytBeg() As Byte = System.Text.Encoding.UTF8.GetBytes(strBeg)
        Dim fsTend As FileStream = New FileStream(strOutputFileName, FileMode.Create, FileAccess.Write)
        fsTend.Write(bytBeg, 0, bytBeg.Count)
        fsTend.Close()
        Using algo As SymmetricAlgorithm = alg4AES
            'Dim intKeySize As Integer = 256
            'Dim intBlockSize As Integer = 128
            'algo.KeySize = intKeySize
            'algo.BlockSize = intBlockSize
            algo.Padding = PaddingMode.PKCS7
            Encrypt(algo, strFileName, strOutputFileName, encStrAsStr, objStatus)
            'Decrypt(algo)
        End Using
        Dim fsTendEnd As FileStream = New FileStream(strOutputFileName, FileMode.Append, FileAccess.Write)
        Dim strEnd As String = ""
        strEnd &= vbCrLf & "</d2>" & vbCrLf
        strEnd &= "<ts>" & Now.ToString("yyyy-MM-dd HH:mm:ss.fff") & "</ts>" & vbCrLf
        strEnd &= "</file>" & vbCrLf
        strEnd &= "</contents>" & vbCrLf
        strEnd &= "</tend>"
        Dim bytEnd() As Byte = System.Text.Encoding.UTF8.GetBytes(strEnd)
        fsTendEnd.Write(bytEnd, 0, bytEnd.Count)
        fsTendEnd.Close()
    End Sub
    Public Function XLDecrypt(ByVal strFileName As String, ByVal strOutputName As String, ByVal strPassword As String, _
                                ByVal strSalt As String, ByVal intAlgorithm As Integer, ByRef objStatus As System.Windows.Forms.ProgressBar) As Boolean
        Dim boolCorrectFormat As Boolean = True
        Dim alg4AES As AesCryptoServiceProvider = New AesCryptoServiceProvider
        alg4AES.KeySize = 256
        alg4AES.BlockSize = 128
        Dim encStrAsStr As String = ""
        Dim strSSalt As String = "the sEcr3t!"
        Dim strPasssword As String = "Gr@titud3!"
        Dim fsInput As FileStream = New FileStream(strFileName, FileMode.Open, FileAccess.Read)
        Dim lngBegLength As Long = 0
        Dim lngFileLength As Long = 0
        Dim sr As StreamReader = New StreamReader(fsInput, System.Text.Encoding.UTF8)
        Dim strTempBeg As String = ""
        Dim line As String = ""
        Dim check As Boolean = True
        Dim counter As Integer = 0
        'Do
        '    Do While counter < 20
        '        counter += 1
        '        If counter = 10 Then
        '            check = False
        '            Exit Do
        '        End If
        '    Loop
        'Loop Until check = False

        Dim index As Integer = 0
        Dim count As Integer = 1
        Dim returnValue As Integer
        Dim charCurrent As Char = ""
        Dim strZipFileName As String = strOutputName
        Dim intCounterNodes As Integer = 0
        'returnValue = instance.ReadBlock(buffer, _
        ' index, count)
        'Do While Not sr.EndOfStream
        Do
            line = sr.ReadLine


            'Dim line As String = sr.ReadLine()
            If line.Contains("xml version") Then
                strTempBeg &= line & vbCrLf
                intCounterNodes += 1
                'Else
                '    'set boolean value to indicate wrong file format
                '    boolCorrectFormat = False
                '    Exit Do
            End If
            If line.Contains("DOCTYPE tend SYSTEM") Then
                strTempBeg &= line & vbCrLf
                intCounterNodes += 1
                'Else
                '    'set boolean value to indicate wrong file format
                '    boolCorrectFormat = False
                '    Exit Do
            End If
            If line.Contains("<tend xmlns") Then
                strTempBeg &= line & vbCrLf
                intCounterNodes += 1
                'Else
                '    'set boolean value to indicate wrong file format
                '    boolCorrectFormat = False
                '    Exit Do
            End If
            If line.Contains("<contents>") Then
                strTempBeg &= line & vbCrLf
                intCounterNodes += 1
                'Else
                '    'set boolean value to indicate wrong file format
                '    boolCorrectFormat = False
                '    Exit Do
            End If
            If line.Contains("<file id") Then
                strTempBeg &= line & vbCrLf
                intCounterNodes += 1
                'Else
                '    'set boolean value to indicate wrong file format
                '    boolCorrectFormat = False
                '    Exit Do
            End If
            If line.Contains("<fileName>") Then
                intCounterNodes += 1
                strTempBeg &= line & vbCrLf
                Dim strTemp1 As String = line.Replace("<fileName>", "").Replace("</fileName>", "")
                Dim strEncFileName As String = GetFileNameFromB64(strTemp1, strSSalt, strPassword)
                ''strEncFileName = strEncFileName.Substring((strEncFileName.LastIndexOf("\") + 1), (strEncFileName.IndexOf(".") - (strEncFileName.LastIndexOf("\") + 1)))
                'strZipFileName = StrZipFileName.Replace(Path.GetFileName(strZipFileName),strEncFileName & ".zip")
                Dim strZpFileName As String = Path.GetFileNameWithoutExtension(strZipFileName)
                If objOptions.strOutput = "" Then
                    'strZipFileName = Xroot & "output\" & strZipFileName
                    Dim i As Integer = 1
                    If File.Exists(strZipFileName) Then
                        Do Until (Not File.Exists(strZipFileName))
                            strZipFileName = strZipFileName.Replace(Path.GetFileName(strZipFileName), strZpFileName & i.ToString & Path.GetExtension(strZipFileName))
                            i += 1
                        Loop
                    End If
                Else
                    'strZipFileName = Xroot & "output\" & Path.GetFileNameWithoutExtension(strZipFileName) & ".zip"
                    Dim i As Integer = 1
                    If File.Exists(strZipFileName) Then
                        Do Until (Not File.Exists(strZipFileName))
                            strZipFileName = strZipFileName.Replace(Path.GetFileName(strZipFileName), strZpFileName & i.ToString & Path.GetExtension(strZipFileName))
                            i += 1
                        Loop
                    End If
                End If
                'Else
                '    'set boolean value to indicate wrong file format
                '    boolCorrectFormat = False
                '    Exit Do
            End If
            If line.Contains("<d1>") Then
                intCounterNodes += 1
                strTempBeg &= line & vbCrLf
                Dim strTemp As String = sr.ReadLine
                strTempBeg &= strTemp & vbCrLf
                Dim rsaProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
                rsaProvider.FromXmlString(objOptions.strPriKey)
                Dim bytArrayDecStr() As Byte = rsaProvider.Decrypt(Convert.FromBase64String(strTemp), False)
                encStrAsStr = System.Text.Encoding.UTF8.GetString(bytArrayDecStr)
                Dim strSaltKey As String = strSalt
                Dim saltValueBytes As Byte()
                saltValueBytes = System.Text.Encoding.ASCII.GetBytes(strSaltKey)
                Dim passwordKey As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(encStrAsStr, saltValueBytes)

                alg4AES.Key = passwordKey.GetBytes(CInt(alg4AES.KeySize / 8))
                alg4AES.IV = passwordKey.GetBytes(CInt(alg4AES.BlockSize / 8))
                '    'csCryptoStream = New CryptoStream(fsOutput, alg4AES.CreateDecryptor, CryptoStreamMode.Write)
                'Else
                '    'set boolean value to indicate wrong file format
                '    boolCorrectFormat = False
                '    Exit Do
            End If
            If line.Contains("</d1>") Then
                strTempBeg &= line & vbCrLf
                intCounterNodes += 1
                'Else
                '    'set boolean value to indicate wrong file format
                '    boolCorrectFormat = False
                '    Exit Do
            End If
            If line.Contains("<d2>") Then
                strTempBeg &= line & vbCrLf
                lngBegLength = System.Text.Encoding.UTF8.GetByteCount(strTempBeg)
                intCounterNodes += 1
                If Not intCounterNodes = 9 Then
                    boolCorrectFormat = False
                End If
                'lngPosition = sr.BaseStream.Position
                'fsInput.Position = lngPosition
                'Else
                '    'set boolean value to indicate wrong file format
                '    boolCorrectFormat = False
                '    Exit Do
            End If
        Loop Until line.Contains("<d2>")
        If boolCorrectFormat Then
            Dim strTempB64File As String = Xroot & "process\" & Path.GetFileNameWithoutExtension(strFileName) & ".bsf"
            Dim fsTempB64 As FileStream = New FileStream(strTempB64File, FileMode.Create, FileAccess.Write)
            Dim swTempB64 As StreamWriter = New StreamWriter(fsTempB64, System.Text.Encoding.UTF8)
            'Do While Not sr.EndOfStream
            'Dim bytBuff(0) As Byte
            Do While sr.Peek >= 0 'Do While Not charCurrent = "<" Or Not sr.EndOfStream 'fsInput.Position = fsInput.Length
                Dim buffer(0) As Char
                returnValue = sr.Read(buffer, index, count)
                'fsInput.Read(bytBuff, 0, 1)
                'charCurrent = System.Text.Encoding.UTF8.GetString(bytBuff)
                'swTempB64.Write(charCurrent)
                'Dim charCur As Char = buffer(0)
                charCurrent = CStr(buffer)
                If Not charCurrent = vbCr Then
                    swTempB64.Write(charCurrent)
                Else
                    'swTempB64.Close()
                    'fsTempB64.Close()
                    Exit Do
                End If
                'index += 1
            Loop
            swTempB64.Close()
            fsTempB64.Close()
            fsInput.Close()
            'Now read the end of the file and count the bytes to the calculate encrypted file size
            ' Loop
            'Dim strTempEnd As String = "<"
            'Dim bufferEnd() As Char

            'While Not sr.EndOfStream
            '    'put code here to read the end of the file into the strTempEnd and count bytes
            'End While
            ' now calculate file length 
            ' decrypt the TempB64 file passing name, length, objStatus...ect
            'If line.Contains("</d2>") Then
            '    lngFileLength = sr.BaseStream.Position - CLng(System.Text.Encoding.UTF8.GetByteCount("</d2>")) - lngPosition
            '    strTempEnd &= line & vbCrLf
            'End If
            'If line.Contains("<ts>") Then
            '    strTempEnd &= line & vbCrLf
            'End If
            'If line.Contains("</file>") Then
            '    strTempEnd &= line & vbCrLf
            'End If
            'If line.Contains("</contents>") Then
            '    strTempEnd &= line & vbCrLf
            'End If
            'If line.Contains("</tend>") Then
            '    strTempEnd &= line & vbCrLf
            '    Dim fiInput As FileInfo = New FileInfo(strInputFile)
            '    lngDataLength = fiInput.Length - lngPosition - CLng(System.Text.Encoding.UTF8.GetByteCount(strTempEnd))
            'End If
            alg4AES.Padding = PaddingMode.PKCS7
            Decrypt(alg4AES, strTempB64File, strZipFileName, objStatus)
            File.Delete(strTempB64File)
            Return boolCorrectFormat

        Else
            'return a value to indicate wrong file type
            Return boolCorrectFormat
        End If
        'Using algo As SymmetricAlgorithm = alg4AES
        '    'Dim intKeySize As Integer = 256
        '    'Dim intBlockSize As Integer = 128
        '    'algo.KeySize = intKeySize
        '    'algo.BlockSize = intBlockSize
        '    Encrypt(algo, strFileName, strOutputFileName, encStrAsStr, objStatus)
        '    'Decrypt(algo)
        'End Using
        'Dim fsTendEnd As FileStream = New FileStream(strOutputFileName, FileMode.Append, FileAccess.Write)
        'Dim strEnd As String = ""
        'strEnd &= vbCrLf & "</d2>" & vbCrLf
        'strEnd &= "<ts>" & Now.ToString("yyyy-MM-dd HH:mm:ss.fff") & "</ts>" & vbCrLf
        'strEnd &= "</file>" & vbCrLf
        'strEnd &= "</contents>" & vbCrLf
        'strEnd &= "</tend>" & vbCrLf
        'Dim bytEnd() As Byte = System.Text.Encoding.UTF8.GetBytes(strEnd)
        'fsTendEnd.Write(bytEnd, 0, bytEnd.Count)
        'fsTendEnd.Close()
    End Function

    Private Sub Encrypt(ByVal algo As SymmetricAlgorithm, ByVal strInFilePath As String, ByVal strOutputFileName As String, ByVal strB64key As String, ByRef objStatus As System.Windows.Forms.ProgressBar)
        Dim fiInput As FileInfo = New FileInfo(strInFilePath)
        Dim lngFileLength As Long = fiInput.Length
        ourFile.EncName = strOutputFileName
        Using cipherText As Stream = SH.GetAppendableFileStream(strOutputFileName)
            Using b64 As ICryptoTransform = New ToBase64Transform()
                Using enc As ICryptoTransform = algo.CreateEncryptor()
                    Using toBase64 As CryptoStream = SH.GetWriteCryptoStream(cipherText, b64)
                        Using crypt As CryptoStream = SH.GetWriteCryptoStream(toBase64, enc)
                            Using input As Stream = SH.GetReadOnlyFileStream(strInFilePath)
                                SH.Pump(input, crypt, lngFileLength, objStatus)
                                ' have to call, not called by Dispose
                                crypt.Close()
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        End Using
    End Sub
    Public Function GetFileNameFromB64(ByVal strB64 As String, ByVal strSaltT As String, ByVal strPassword As String) As String
        Try
            Dim strFileName As String = ""
            Dim strBFile As String = Path.GetTempFileName
            Dim strOutputFileName As String = Path.GetTempFileName
            'decode the b64 string


            'get the byte array
            Dim binaryData() As Byte
            Try
                binaryData = System.Convert.FromBase64String(strB64)
            Catch exp As System.ArgumentNullException
                System.Console.WriteLine("Base 64 string is null.")
                Throw exp
            Catch exp As System.FormatException
                System.Console.WriteLine("Base 64 length is not 4 or is " + _
                                         "not an even multiple of 4.")
                Throw exp
            End Try

            'Write out the decoded data.
            Dim out2File As System.IO.FileStream
            Try
                out2File = New System.IO.FileStream(strBFile, _
                                                   System.IO.FileMode.Create, _
                                                   System.IO.FileAccess.Write)
                out2File.Write(binaryData, 0, binaryData.Length - 1)
                out2File.Close()
            Catch exp As System.Exception
                ' Error creating stream or writing to it.
                'System.Console.WriteLine("{0}", exp.Message)
                Throw exp
            End Try

            'generate password key
            'create the password key
            'Adding option to parameterize salt in future implementations
            Dim strSaltKey As String = "the sEcr3t!" '"Love one another + Granny"
            Dim saltValueBytes As Byte() = System.Text.Encoding.ASCII.GetBytes(strSaltKey)
            Dim passwordKey As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(strPassword, saltValueBytes)
            'decrypt the filename
            Dim alg4AES As AesCryptoServiceProvider = New AesCryptoServiceProvider
            alg4AES.KeySize = 256
            alg4AES.BlockSize = 128
            alg4AES.Key = passwordKey.GetBytes(CInt(alg4AES.KeySize / 8))
            alg4AES.IV = passwordKey.GetBytes(CInt(alg4AES.BlockSize / 8))
            'Read encrypted file into filedata
            Dim decryptor As ICryptoTransform = alg4AES.CreateDecryptor
            Dim inFile As FileStream = New FileStream(strBFile, FileMode.Open, FileAccess.Read)
            Dim decryptStream As CryptoStream = New CryptoStream(inFile, decryptor, CryptoStreamMode.Read)
            Dim infileData(CInt(inFile.Length)) As Byte
            decryptStream.Read(infileData, 0, CType(inFile.Length, Integer))
            ' Write the contents of the unencrypted file
            Dim outFile As FileStream = New FileStream(strOutputFileName, FileMode.OpenOrCreate, FileAccess.Write)
            outFile.Write(infileData, 0, infileData.Length)
            'close the files
            decryptStream.Close()
            inFile.Close()
            File.Delete(strBFile)
            outFile.Close()
            strFileName = File.ReadAllText(strOutputFileName)

            Return strFileName
        Catch ex As Exception
            Throw ex
            Return String.Empty
        End Try
    End Function
    Private Sub Decrypt(ByVal algo As SymmetricAlgorithm, ByVal strFileName As String, ByVal strOutputFileName As String, ByRef objStatus As ProgressBar)
        Dim fiFile As FileInfo = New FileInfo(strFileName)
        Dim lngLength As Long = fiFile.Length - 3
        Using cipherText As Stream = SH.GetReadOnlyFileStream4(strFileName)
            Using b64 As ICryptoTransform = New FromBase64Transform()
                Using dec As ICryptoTransform = algo.CreateDecryptor()
                    Using frBase64 As CryptoStream = SH.GetReadCryptoStream(cipherText, b64)
                        Using decrypt As CryptoStream = SH.GetReadCryptoStream(frBase64, dec)
                            Using output As Stream = SH.GetWriteableFileStream(strOutputFileName)
                                SH.Pump(decrypt, output, lngLength, objStatus)
                                ' have to call, not called by Dispose
                                decrypt.Close()
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        End Using
    End Sub

End Module
