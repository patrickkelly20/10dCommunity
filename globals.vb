Imports System
Imports System.Net
Imports System.Net.Mail
Module globals
    Public Structure strctOptions
        Dim strOutput As String
        Dim blnLog As Boolean
        Dim strEmailAddress As String
        Dim strSMTPserver As String
        Dim strSMTPuser As String
        Dim strSMTPpassword As String
        Dim intPort As Integer
        Dim blnSSL As Boolean
        Dim strAddressList As String
        Dim strToList As String
        Dim strCCList As String
        Dim strBCCList As String
        Dim intMaxLogFile As Integer
        Dim strPrikeyName As String
        Dim strPubKeyName As String
        Dim strPriKeyPath As String
        Dim strPubKeyPath As String
        Dim strPriKey As String
        Dim strPubKey As String
        Dim blnEncAsym As Boolean
    End Structure
    Public Structure structMailMessage
        Public strFrom As String
        Public strTo As List(Of String)
        Public strCc As List(Of String)
        Public strBcc As List(Of String)
        Public strSubject As String
        Public strMessage As String
        Public strAttachment As List(Of String)
        Public strStatus As String
    End Structure
    Public objTheMessage As structMailMessage = New structMailMessage
    Public lstMailMessages As List(Of MailMessage) = New List(Of MailMessage)

    Public objOptions As strctOptions = New strctOptions
    Public ourFile As New hhcsxFile
    Public AppData As String = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
    Public XML_CONFIG_FILE As String
    Public Zen_xsd_File As String = AppData + "\Tenac10us\10d\zen\zen.xsd"
    Public Zen_DTD_File As String = AppData + "\Tenac10us\10d\zen\zen.dtd"
    Public Xroot As String
End Module
