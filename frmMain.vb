' Copyright 2011 RRB - Patrick Kelly
' enhanced code to use 256 - Bit AES encryption
' This code uses recommended best practices as recommended 
' by the NSA and FIPS 140-2 guidelines for Symetric Encryption 

Imports System
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports System.Configuration
Imports Ionic.Zip

Public Class frmMain
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDestinationEncrypt As System.Windows.Forms.TextBox
    Friend WithEvents btnEncrypt As System.Windows.Forms.Button
    Friend WithEvents txtConPassEncrypt As System.Windows.Forms.TextBox
    Friend WithEvents txtPassEncrypt As System.Windows.Forms.TextBox
    Friend WithEvents txtFileToEncrypt As System.Windows.Forms.TextBox
    Friend WithEvents pbStatus As System.Windows.Forms.ProgressBar
    Friend WithEvents txtDestinationDecrypt As System.Windows.Forms.TextBox
    Friend WithEvents btnDecrypt As System.Windows.Forms.Button
    Friend WithEvents txtConPassDecrypt As System.Windows.Forms.TextBox
    Friend WithEvents txtPassDecrypt As System.Windows.Forms.TextBox
    Friend WithEvents txtFileToDecrypt As System.Windows.Forms.TextBox
    Friend WithEvents btnChangeEncrypt As System.Windows.Forms.Button
    Friend WithEvents btnBrowseEncrypt As System.Windows.Forms.Button
    Friend WithEvents btnChangeDecrypt As System.Windows.Forms.Button
    Friend WithEvents btnBrowseDecrypt As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cboxKeys As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cBoxKeys2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateKeysToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SendToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CreateKeysToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.cboxKeys = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.btnChangeEncrypt = New System.Windows.Forms.Button
        Me.txtDestinationEncrypt = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnEncrypt = New System.Windows.Forms.Button
        Me.txtConPassEncrypt = New System.Windows.Forms.TextBox
        Me.txtPassEncrypt = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnBrowseEncrypt = New System.Windows.Forms.Button
        Me.txtFileToEncrypt = New System.Windows.Forms.TextBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.cBoxKeys2 = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnChangeDecrypt = New System.Windows.Forms.Button
        Me.txtDestinationDecrypt = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnDecrypt = New System.Windows.Forms.Button
        Me.txtConPassDecrypt = New System.Windows.Forms.TextBox
        Me.txtPassDecrypt = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnBrowseDecrypt = New System.Windows.Forms.Button
        Me.txtFileToDecrypt = New System.Windows.Forms.TextBox
        Me.pbStatus = New System.Windows.Forms.ProgressBar
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
        Me.TabControl1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(387, 141)
        Me.TabControl1.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.SendToolStripMenuItem, Me.CreateKeysToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(145, 92)
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'SendToolStripMenuItem
        '
        Me.SendToolStripMenuItem.Name = "SendToolStripMenuItem"
        Me.SendToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.SendToolStripMenuItem.Text = "Send..."
        '
        'CreateKeysToolStripMenuItem
        '
        Me.CreateKeysToolStripMenuItem.Name = "CreateKeysToolStripMenuItem"
        Me.CreateKeysToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.CreateKeysToolStripMenuItem.Text = "Create Keys..."
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage1.Controls.Add(Me.cboxKeys)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.btnChangeEncrypt)
        Me.TabPage1.Controls.Add(Me.txtDestinationEncrypt)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.btnEncrypt)
        Me.TabPage1.Controls.Add(Me.txtConPassEncrypt)
        Me.TabPage1.Controls.Add(Me.txtPassEncrypt)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.btnBrowseEncrypt)
        Me.TabPage1.Controls.Add(Me.txtFileToEncrypt)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(379, 115)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "                       Encrypt                        "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cboxKeys
        '
        Me.cboxKeys.FormattingEnabled = True
        Me.cboxKeys.Location = New System.Drawing.Point(103, 70)
        Me.cboxKeys.Name = "cboxKeys"
        Me.cboxKeys.Size = New System.Drawing.Size(184, 21)
        Me.cboxKeys.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(67, 73)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Key:"
        '
        'btnChangeEncrypt
        '
        Me.btnChangeEncrypt.Enabled = False
        Me.btnChangeEncrypt.Location = New System.Drawing.Point(295, 33)
        Me.btnChangeEncrypt.Name = "btnChangeEncrypt"
        Me.btnChangeEncrypt.Size = New System.Drawing.Size(72, 21)
        Me.btnChangeEncrypt.TabIndex = 11
        Me.btnChangeEncrypt.Text = "Change"
        '
        'txtDestinationEncrypt
        '
        Me.txtDestinationEncrypt.Location = New System.Drawing.Point(103, 33)
        Me.txtDestinationEncrypt.Name = "txtDestinationEncrypt"
        Me.txtDestinationEncrypt.ReadOnly = True
        Me.txtDestinationEncrypt.Size = New System.Drawing.Size(184, 20)
        Me.txtDestinationEncrypt.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(7, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "File destination:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnEncrypt
        '
        Me.btnEncrypt.Enabled = False
        Me.btnEncrypt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEncrypt.Location = New System.Drawing.Point(295, 63)
        Me.btnEncrypt.Name = "btnEncrypt"
        Me.btnEncrypt.Size = New System.Drawing.Size(72, 32)
        Me.btnEncrypt.TabIndex = 8
        Me.btnEncrypt.Text = "Encrypt"
        '
        'txtConPassEncrypt
        '
        Me.txtConPassEncrypt.Location = New System.Drawing.Point(158, 135)
        Me.txtConPassEncrypt.Name = "txtConPassEncrypt"
        Me.txtConPassEncrypt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConPassEncrypt.Size = New System.Drawing.Size(184, 20)
        Me.txtConPassEncrypt.TabIndex = 7
        Me.txtConPassEncrypt.Visible = False
        '
        'txtPassEncrypt
        '
        Me.txtPassEncrypt.Location = New System.Drawing.Point(158, 111)
        Me.txtPassEncrypt.Name = "txtPassEncrypt"
        Me.txtPassEncrypt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassEncrypt.Size = New System.Drawing.Size(184, 20)
        Me.txtPassEncrypt.TabIndex = 6
        Me.txtPassEncrypt.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(15, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "File to encrypt:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(46, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Confirm password:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(62, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Type password:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Visible = False
        '
        'btnBrowseEncrypt
        '
        Me.btnBrowseEncrypt.Location = New System.Drawing.Point(295, 9)
        Me.btnBrowseEncrypt.Name = "btnBrowseEncrypt"
        Me.btnBrowseEncrypt.Size = New System.Drawing.Size(72, 21)
        Me.btnBrowseEncrypt.TabIndex = 2
        Me.btnBrowseEncrypt.Text = "Browse"
        '
        'txtFileToEncrypt
        '
        Me.txtFileToEncrypt.Location = New System.Drawing.Point(103, 9)
        Me.txtFileToEncrypt.Name = "txtFileToEncrypt"
        Me.txtFileToEncrypt.ReadOnly = True
        Me.txtFileToEncrypt.Size = New System.Drawing.Size(184, 20)
        Me.txtFileToEncrypt.TabIndex = 1
        Me.txtFileToEncrypt.Text = "Click Browse to load file."
        '
        'TabPage2
        '
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage2.Controls.Add(Me.cBoxKeys2)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.btnChangeDecrypt)
        Me.TabPage2.Controls.Add(Me.txtDestinationDecrypt)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.btnDecrypt)
        Me.TabPage2.Controls.Add(Me.txtConPassDecrypt)
        Me.TabPage2.Controls.Add(Me.txtPassDecrypt)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.btnBrowseDecrypt)
        Me.TabPage2.Controls.Add(Me.txtFileToDecrypt)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(379, 115)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "                       Decrypt                       "
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cBoxKeys2
        '
        Me.cBoxKeys2.FormattingEnabled = True
        Me.cBoxKeys2.Location = New System.Drawing.Point(102, 64)
        Me.cBoxKeys2.Name = "cBoxKeys2"
        Me.cBoxKeys2.Size = New System.Drawing.Size(184, 21)
        Me.cBoxKeys2.TabIndex = 24
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(66, 67)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(28, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Key:"
        '
        'btnChangeDecrypt
        '
        Me.btnChangeDecrypt.Enabled = False
        Me.btnChangeDecrypt.Location = New System.Drawing.Point(296, 32)
        Me.btnChangeDecrypt.Name = "btnChangeDecrypt"
        Me.btnChangeDecrypt.Size = New System.Drawing.Size(72, 21)
        Me.btnChangeDecrypt.TabIndex = 22
        Me.btnChangeDecrypt.Text = "Change"
        '
        'txtDestinationDecrypt
        '
        Me.txtDestinationDecrypt.Location = New System.Drawing.Point(104, 32)
        Me.txtDestinationDecrypt.Name = "txtDestinationDecrypt"
        Me.txtDestinationDecrypt.ReadOnly = True
        Me.txtDestinationDecrypt.Size = New System.Drawing.Size(184, 20)
        Me.txtDestinationDecrypt.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "File destination:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnDecrypt
        '
        Me.btnDecrypt.Enabled = False
        Me.btnDecrypt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDecrypt.Location = New System.Drawing.Point(297, 64)
        Me.btnDecrypt.Name = "btnDecrypt"
        Me.btnDecrypt.Size = New System.Drawing.Size(72, 32)
        Me.btnDecrypt.TabIndex = 19
        Me.btnDecrypt.Text = "Decrypt"
        '
        'txtConPassDecrypt
        '
        Me.txtConPassDecrypt.Location = New System.Drawing.Point(104, 88)
        Me.txtConPassDecrypt.Name = "txtConPassDecrypt"
        Me.txtConPassDecrypt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConPassDecrypt.Size = New System.Drawing.Size(184, 20)
        Me.txtConPassDecrypt.TabIndex = 18
        Me.txtConPassDecrypt.Visible = False
        '
        'txtPassDecrypt
        '
        Me.txtPassDecrypt.Location = New System.Drawing.Point(104, 64)
        Me.txtPassDecrypt.Name = "txtPassDecrypt"
        Me.txtPassDecrypt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassDecrypt.Size = New System.Drawing.Size(184, 20)
        Me.txtPassDecrypt.TabIndex = 17
        Me.txtPassDecrypt.Visible = False
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 16)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "File to decrypt:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(-8, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 16)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Confirm password:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.Visible = False
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Type password:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label8.Visible = False
        '
        'btnBrowseDecrypt
        '
        Me.btnBrowseDecrypt.Location = New System.Drawing.Point(296, 8)
        Me.btnBrowseDecrypt.Name = "btnBrowseDecrypt"
        Me.btnBrowseDecrypt.Size = New System.Drawing.Size(72, 21)
        Me.btnBrowseDecrypt.TabIndex = 13
        Me.btnBrowseDecrypt.Text = "Browse"
        '
        'txtFileToDecrypt
        '
        Me.txtFileToDecrypt.Location = New System.Drawing.Point(104, 8)
        Me.txtFileToDecrypt.Name = "txtFileToDecrypt"
        Me.txtFileToDecrypt.ReadOnly = True
        Me.txtFileToDecrypt.Size = New System.Drawing.Size(184, 20)
        Me.txtFileToDecrypt.TabIndex = 12
        Me.txtFileToDecrypt.Text = "Click Browse to load file."
        '
        'pbStatus
        '
        Me.pbStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pbStatus.ContextMenuStrip = Me.ContextMenuStrip1
        Me.pbStatus.Location = New System.Drawing.Point(0, 143)
        Me.pbStatus.Name = "pbStatus"
        Me.pbStatus.Size = New System.Drawing.Size(387, 33)
        Me.pbStatus.TabIndex = 1
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(387, 175)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.pbStatus)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "10dXL"
        Me.TabControl1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region



#Region "1. Global Variables "

    '*************************
    '** Global Variables
    '*************************

    Dim strFileToEncrypt As String
    Dim strFileToDecrypt As String
    Dim strOutputEncrypt As String
    Dim strOutputDecrypt As String
    Dim fsInput As System.IO.FileStream
    Dim fsOutput As System.IO.FileStream
    Dim fsTend As System.IO.FileStream
    Private strFileToCompress As String = ""
    Private strUserPathRoot As String = ""
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

#End Region


#Region "2. Create A Key "

    '*************************
    '** Create A Key
    '*************************

    Private Function CreateKey(ByVal strPassword As String) As Byte()
        'Convert strPassword to an array and store in chrData.
        Dim chrData() As Char = strPassword.ToCharArray
        'Use intLength to get strPassword size.
        Dim intLength As Integer = chrData.GetUpperBound(0)
        'Declare bytDataToHash and make it the same size as chrData.
        Dim bytDataToHash(intLength) As Byte

        'Use For Next to convert and store chrData into bytDataToHash.
        For i As Integer = 0 To chrData.GetUpperBound(0)
            bytDataToHash(i) = CByte(Asc(chrData(i)))
        Next

        'Declare what hash to use.
        Dim SHA512 As New System.Security.Cryptography.SHA512Managed
        'Declare bytResult, Hash bytDataToHash and store it in bytResult.
        Dim bytResult As Byte() = SHA512.ComputeHash(bytDataToHash)
        'Declare bytKey(31).  It will hold 256 bits.
        Dim bytKey(31) As Byte

        'Use For Next to put a specific size (256 bits) of 
        'bytResult into bytKey. The 0 To 31 will put the first 256 bits
        'of 512 bits into bytKey.
        For i As Integer = 0 To 31
            bytKey(i) = bytResult(i)
        Next

        Return bytKey 'Return the key.
    End Function

#End Region


#Region "3. Create An IV "

    '*************************
    '** Create An IV
    '*************************

    Private Function CreateIV(ByVal strPassword As String) As Byte()
        'Convert strPassword to an array and store in chrData.
        Dim chrData() As Char = strPassword.ToCharArray
        'Use intLength to get strPassword size.
        Dim intLength As Integer = chrData.GetUpperBound(0)
        'Declare bytDataToHash and make it the same size as chrData.
        Dim bytDataToHash(intLength) As Byte

        'Use For Next to convert and store chrData into bytDataToHash.
        For i As Integer = 0 To chrData.GetUpperBound(0)
            bytDataToHash(i) = CByte(Asc(chrData(i)))
        Next

        'Declare what hash to use.
        Dim SHA512 As New System.Security.Cryptography.SHA512Managed
        'Declare bytResult, Hash bytDataToHash and store it in bytResult.
        Dim bytResult As Byte() = SHA512.ComputeHash(bytDataToHash)
        'Declare bytIV(15).  It will hold 128 bits.
        Dim bytIV(15) As Byte

        'Use For Next to put a specific size (128 bits) of 
        'bytResult into bytIV. The 0 To 30 for bytKey used the first 256 bits.
        'of the hashed password. The 32 To 47 will put the next 128 bits into bytIV.
        For i As Integer = 32 To 47
            bytIV(i - 32) = bytResult(i)
        Next

        Return bytIV 'return the IV
    End Function

#End Region


#Region "4. Encrypt / Decrypt File "

    '****************************
    '** Encrypt/Decrypt File
    '****************************

    Private Enum CryptoAction
        'Define the enumeration for CryptoAction.
        ActionEncrypt = 1
        ActionDecrypt = 2
    End Enum

    Private Sub EncryptOrDecryptFile(ByVal strInputFile As String, _
                                     ByVal strOutputFile As String, _
                                    ByRef algAES As AesCryptoServiceProvider, ByVal Direction As CryptoAction, ByVal strEncAsymKey As String)
        'ByVal bytKey() As Byte, _
        ' ByVal bytIV() As Byte, _
        ' ByVal Direction As CryptoAction)
        Try 'In case of errors.
            Dim strSFHash As String = strEncAsymKey
            'Setup file streams to handle input and output.
            fsInput = New System.IO.FileStream(strInputFile, FileMode.Open, _
                                               FileAccess.Read)
            If Direction = CryptoAction.ActionEncrypt Then
                fsOutput = New System.IO.FileStream(strOutputFile, FileMode.OpenOrCreate, _
                                                  FileAccess.Write)
            End If
            If Direction = CryptoAction.ActionEncrypt Then
                fsTend = New System.IO.FileStream(Path.GetPathRoot(strOutputFile) & "\" & Path.GetFileNameWithoutExtension(strInputFile) & ".xml", FileMode.OpenOrCreate, FileAccess.Write)
                fsOutput.SetLength(0) 'make sure fsOutput is empty
                'Else
                'fsTend = New System.IO.FileStream(strInputFile, FileMode.Open, FileAccess.Read)
            End If


            'Declare variables for encrypt/decrypt process.
            Dim bytBuffer(4098) As Byte 'holds a block of bytes for processing
            Dim lngBytesProcessed As Long = 0 'running count of bytes processed
            Dim lngBytesProcessed2 As Long = 0 'running count of bytes processed
            Dim lngFileLength As Long = fsInput.Length 'the input file's length
            Dim intBytesInCurrentBlock As Integer 'current bytes being processed
            Dim csCryptoStream As CryptoStream
            'Declare your CryptoServiceProvider.
            'Dim cspRijndael As New System.Security.Cryptography.RijndaelManaged
            'Setup Progress Bar
            pbStatus.Value = 0
            pbStatus.Maximum = 100

            'Determine if ecryption or decryption and setup CryptoStream.
            Select Case Direction
                Case CryptoAction.ActionEncrypt
                    Dim strSSalt As String = "the sEcr3t!"
                    Dim strPasssword As String = "Gr@titud3"
                    Dim strB64FileName As String = GetB64FileName(Path.GetFileName(strFileToEncrypt), strSSalt, strPasssword) '6

                    csCryptoStream = New CryptoStream(fsOutput, algAES.CreateEncryptor, CryptoStreamMode.Write)
                    'cspRijndael.CreateEncryptor(bytKey, bytIV), _
                    'CryptoStreamMode.Write)
                    'create the beginning of the xml file
                    Dim bytTend(4098) As Byte
                    Dim bytB64() As Byte
                    Dim strBeg As String = ""
                    strBeg &= "<?xml version=""1.0"" encoding=""utf-8""?>" & vbCrLf
                    strBeg &= "<!DOCTYPE tend SYSTEM ""tend.dtd""[]>" & vbCrLf
                    strBeg &= "<tend xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:noNamespaceSchemaLocation=""tend.xsd"">" & vbCrLf
                    strBeg &= "<contents>" & vbCrLf
                    strBeg &= "<file id=""f1"">" & vbCrLf
                    strBeg &= "<fileName>" & strB64FileName & "</fileName>" & vbCrLf
                    strBeg &= "<d1>" & vbCrLf
                    strBeg &= strSFHash & vbCrLf
                    strBeg &= "</d1>" & vbCrLf
                    strBeg &= "<d2>" & vbCrLf
                    Dim bytBeg() As Byte = StringToBytes(strBeg)
                    fsTend.Write(bytBeg, 0, bytBeg.Count)
                    While lngBytesProcessed < lngFileLength
                        'Read file with the input filestream.
                        intBytesInCurrentBlock = fsInput.Read(bytBuffer, 0, 4098)
                        'Write output file with the cryptostream.
                        csCryptoStream.Write(bytBuffer, 0, intBytesInCurrentBlock)

                        'Update lngBytesProcessed
                        lngBytesProcessed = lngBytesProcessed + CLng(intBytesInCurrentBlock)
                        'Update Progress Bar
                        pbStatus.Value = CInt((lngBytesProcessed / lngFileLength) * 100)
                    End While
                    csCryptoStream.Close()
                    fsInput.Close()
                    fsOutput.Close()
                    Dim fsCrypto As FileStream = New FileStream(strOutputFile, FileMode.Open, FileAccess.Read)

                    Dim lngFileLength2 As Long = fsCrypto.Length 'the input file's length
                    Dim intBytesInCurrentBlock2 As Integer 'current bytes being processed
                    While lngBytesProcessed2 < lngFileLength2
                        'Read cryptostream
                        intBytesInCurrentBlock2 = fsCrypto.Read(bytTend, 0, 4098)
                        'Write the buffer to the output xml file
                        Dim strTemp As String = Convert.ToBase64String(bytTend)
                        bytB64 = StringToBytes(strTemp)
                        fsTend.Write(bytB64, 0, bytB64.Count)
                        lngBytesProcessed2 = lngBytesProcessed2 + CLng(intBytesInCurrentBlock2)
                        pbStatus.Value = CInt((lngBytesProcessed2 / lngFileLength2) * 100)
                    End While
                    Dim strEnd As String = ""
                    strEnd &= vbCrLf & "</d2>" & vbCrLf
                    strEnd &= "<ts>" & Now.ToString("yyyy-MM-dd HH:mm:ss.fff") & "</ts>" & vbCrLf
                    strEnd &= "</file>" & vbCrLf
                    strEnd &= "</contents>" & vbCrLf
                    strEnd &= "</tend>" & vbCrLf
                    Dim bytEnd() As Byte = StringToBytes(strEnd)
                    fsTend.Write(bytEnd, 0, bytEnd.Count)
                    fsTend.Close()
                    fsCrypto.Close()
                Case CryptoAction.ActionDecrypt
                    Dim lngPosition As Long = 0
                    Dim lngDataLength As Long = 0
                    'fsOutput = New System.IO.FileStream(strOutputFile, FileMode.OpenOrCreate, _
                    '                                FileAccess.Write)
                    'csCryptoStream = New CryptoStream(fsOutput, algAES.CreateDecryptor, CryptoStreamMode.Write)
                    ''cspRijndael.CreateDecryptor(bytKey, bytIV), _
                    'CryptoStreamMode.Write)
                    Dim encStrAsStr As String = ""
                    Dim strSSalt As String = "the sEcr3t!"
                    Dim strPasssword As String = "Gr@titud3"
                    Dim lngFileLength2 As Long = fsInput.Length 'the input file's length
                    Dim intBytesInCurrentBlock2 As Integer 'current bytes being processed
                    Dim sr As StreamReader = New StreamReader(fsInput)
                    Dim strTempBeg As String = ""
                    While Not sr.EndOfStream
                        Dim line As String = sr.ReadLine()
                        If line.Contains("xml version") Then
                            strTempBeg &= line & vbCrLf
                        End If
                        If line.Contains("DOCTYPE tend SYSTEM") Then
                            strTempBeg &= line & vbCrLf
                        End If
                        If line.Contains("<tend xmlns") Then
                            strTempBeg &= line & vbCrLf
                        End If
                        If line.Contains("<contents>") Then
                            strTempBeg &= line & vbCrLf
                        End If
                        If line.Contains("<file id") Then
                            strTempBeg &= line & vbCrLf
                        End If
                        If line.Contains("<fileName>") Then
                            strTempBeg &= line & vbCrLf
                            Dim strTemp1 As String = line.Replace("<fileName>", "").Replace("</fileName>", "")
                            Dim strEncFileName As String = GetFileNameFromB64(strTemp1, strSSalt, strPasssword)
                            strEncFileName = strEncFileName.Substring((strEncFileName.LastIndexOf("\") + 1), (strEncFileName.IndexOf(".") - (strEncFileName.LastIndexOf("\") + 1)))
                            Dim strZipFileName As String = strEncFileName & ".zip"
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
                            fsOutput = New System.IO.FileStream(strZipFileName, FileMode.OpenOrCreate, _
                                                    FileAccess.Write)
                            fsOutput.SetLength(0) 'make sure fsOutput is empty
                        End If
                        If line.Contains("<d1>") Then
                            strTempBeg &= line & vbCrLf
                            Dim strTemp As String = sr.ReadLine
                            strTempBeg &= strTemp & vbCrLf
                            Dim rsaProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider()
                            rsaProvider.FromXmlString(objOptions.strPriKey)
                            Dim bytArrayDecStr() As Byte = rsaProvider.Decrypt(Convert.FromBase64String(strTemp), False)
                            encStrAsStr = System.Text.Encoding.UTF8.GetString(bytArrayDecStr)
                            Dim strSaltKey As String = "D0n't9W0rry4@b0ut2A5th1ng"
                            Dim saltValueBytes As Byte()
                            saltValueBytes = System.Text.Encoding.ASCII.GetBytes(strSaltKey)
                            Dim passwordKey As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(encStrAsStr, saltValueBytes)
                            Dim alg4AES As AesCryptoServiceProvider = New AesCryptoServiceProvider
                            alg4AES.KeySize = 256
                            alg4AES.BlockSize = 128
                            alg4AES.Key = passwordKey.GetBytes(CInt(alg4AES.KeySize / 8))
                            alg4AES.IV = passwordKey.GetBytes(CInt(alg4AES.BlockSize / 8))
                            csCryptoStream = New CryptoStream(fsOutput, alg4AES.CreateDecryptor, CryptoStreamMode.Write)
                        End If
                        If line.Contains("</d1>") Then
                            strTempBeg &= line & vbCrLf
                        End If
                        If line.Contains("<d2>") Then
                            strTempBeg &= line & vbCrLf
                            lngPosition = System.Text.Encoding.UTF8.GetByteCount(strTempBeg)

                            'lngPosition = sr.BaseStream.Position
                            'fsInput.Position = lngPosition
                        End If
                        Dim strTempEnd As String = ""
                        If line.Contains("</d2>") Then
                            lngFileLength2 = sr.BaseStream.Position - CLng(System.Text.Encoding.UTF8.GetByteCount("</d2>")) - lngPosition
                            strTempEnd &= line & vbCrLf
                        End If
                        If line.Contains("<ts>") Then
                            strTempEnd &= line & vbCrLf
                        End If
                        If line.Contains("</file>") Then
                            strTempEnd &= line & vbCrLf
                        End If
                        If line.Contains("</contents>") Then
                            strTempEnd &= line & vbCrLf
                        End If
                        If line.Contains("</tend>") Then
                            strTempEnd &= line & vbCrLf
                            Dim fiInput As FileInfo = New FileInfo(strInputFile)
                            lngDataLength = fiInput.Length - lngPosition - CLng(System.Text.Encoding.UTF8.GetByteCount(strTempEnd))
                        End If
                    End While

                    'Use While to loop until all of the file is processed.
                    'Dim fsCrypto As FileStream = New FileStream(strOutputFile, FileMode.Open, FileAccess.Read)
                    Dim strEncFileName1 As String = Xroot & "process\" & Path.GetFileNameWithoutExtension(strInputFile) & ".enc"
                    fsTend = New System.IO.FileStream(strEncFileName1, FileMode.OpenOrCreate, FileAccess.Write)
                    Dim bytTend(4098) As Byte
                    Dim bytB64() As Byte
                    'lngPosition = 808
                    fsInput.Position = lngPosition
                    'Dim lngFileLength2 As Long = fsCrypto.Length 'the input file's length
                    'Dim intBytesInCurrentBlock2 As Integer 'current bytes being processed
                    While lngBytesProcessed2 < lngFileLength2
                        'Read cryptostream
                        intBytesInCurrentBlock2 = fsInput.Read(bytTend, 0, 4098)
                        'Write the buffer to the output xml file
                        Dim strTemp As String = BytesToString(bytTend)
                        bytB64 = System.Convert.FromBase64String(strTemp)
                        fsTend.Write(bytB64, 0, bytB64.Count)
                        lngBytesProcessed2 = lngBytesProcessed2 + CLng(intBytesInCurrentBlock2)
                        pbStatus.Value = CInt((lngBytesProcessed2 / lngFileLength2) * 100)
                    End While
                    Dim fsInOput As System.IO.FileStream = New FileStream(strEncFileName1, FileMode.Open, FileAccess.Read)
                    Dim lngBytesProcessed3 As Long = 0
                    Dim lngFileLength3 As Long = fsInOput.Length
                    Dim intBytesInCurrentBlock3 As Integer = 0
                    While lngBytesProcessed3 < lngFileLength3
                        'Read file with the input filestream.
                        intBytesInCurrentBlock3 = fsInput.Read(bytBuffer, 0, 4098)
                        'Write output file with the cryptostream.
                        csCryptoStream.Write(bytBuffer, 0, intBytesInCurrentBlock)
                        'Update lngBytesProcessed
                        lngBytesProcessed3 = lngBytesProcessed3 + CLng(intBytesInCurrentBlock3)
                        'Update Progress Bar
                        pbStatus.Value = CInt((lngBytesProcessed3 / lngFileLength3) * 100)
                    End While
                    'While lngBytesProcessed < lngFileLength
                    '    'Read file with the input filestream.
                    '    intBytesInCurrentBlock = fsInput.Read(bytBuffer, 0, 4098)
                    '    'Write output file with the cryptostream.
                    '    csCryptoStream.Write(bytBuffer, 0, intBytesInCurrentBlock)
                    '    'Update lngBytesProcessed
                    '    lngBytesProcessed = lngBytesProcessed + CLng(intBytesInCurrentBlock)
                    '    'Update Progress Bar
                    '    pbStatus.Value = CInt((lngBytesProcessed / lngFileLength) * 100)
                    'End While
                    csCryptoStream.Close()
                    fsInput.Close()
                    fsOutput.Close()
            End Select



            'Close FileStreams and CryptoStream.


            ''If encrypting then delete the original unencrypted file.
            'If Direction = CryptoAction.ActionEncrypt Then
            '    Dim fileOriginal As New FileInfo(strFileToEncrypt)
            '    fileOriginal.Delete()
            'End If

            ''If decrypting then delete the encrypted file.
            'If Direction = CryptoAction.ActionDecrypt Then
            '    Dim fileEncrypted As New FileInfo(strFileToDecrypt)
            '    fileEncrypted.Delete()
            'End If

            'Update the user when the file is done.
            Dim Wrap As String = Chr(13) + Chr(10)
            If Direction = CryptoAction.ActionEncrypt Then
                MsgBox("Encryption Complete" + Wrap + Wrap + _
                        "Total bytes processed = " + _
                        lngBytesProcessed.ToString & vbCrLf & "total new bytes = " + lngBytesProcessed2.ToString, _
                        MsgBoxStyle.Information, "Done")

                'Update the progress bar and textboxes.
                pbStatus.Value = 0
                txtFileToEncrypt.Text = "Click Browse to load file."
                txtPassEncrypt.Text = ""
                txtConPassEncrypt.Text = ""
                txtDestinationEncrypt.Text = ""
                btnChangeEncrypt.Enabled = False
                btnEncrypt.Enabled = False

            Else
                'Update the user when the file is done.
                MsgBox("Decryption Complete" + Wrap + Wrap + _
                       "Total bytes processed = " + _
                        lngBytesProcessed.ToString, _
                        MsgBoxStyle.Information, "Done")

                'Update the progress bar and textboxes.
                pbStatus.Value = 0
                txtFileToDecrypt.Text = "Click Browse to load file."
                txtPassDecrypt.Text = ""
                txtConPassDecrypt.Text = ""
                txtDestinationDecrypt.Text = ""
                btnChangeDecrypt.Enabled = False
                btnDecrypt.Enabled = False
            End If


            'Catch file not found error.
            'Catch When Err.Number = 53 'if file not found
            '    MsgBox("Please check to make sure the path and filename" + _
            '            "are correct and if the file exists.", _
            '             MsgBoxStyle.Exclamation, "Invalid Path or Filename")

            'Catch all other errors. And delete partial files.
        Catch ex As Exception
            fsInput.Close()
            If Not fsOutput Is Nothing Then
                fsOutput.Close()
            End If


            If Direction = CryptoAction.ActionDecrypt Then
                Dim fileDelete As New FileInfo(txtDestinationDecrypt.Text)
                fileDelete.Delete()
                pbStatus.Value = 0
                txtPassDecrypt.Text = ""
                txtConPassDecrypt.Text = ""

                MsgBox("Please check to make sure that you entered the correct" + _
                        "password.", MsgBoxStyle.Exclamation, "Invalid Password")
            Else
                Dim fileDelete As New FileInfo(txtDestinationEncrypt.Text)
                fileDelete.Delete()

                pbStatus.Value = 0
                txtPassEncrypt.Text = ""
                txtConPassEncrypt.Text = ""

                MsgBox("This file cannot be encrypted.", _
                        MsgBoxStyle.Exclamation, "Invalid File")

            End If

        End Try
    End Sub

#End Region


#Region "5. Browse / Change Button "

    '******************************
    '** Browse/Change Buttons
    '******************************

    Private Sub btnBrowseEncrypt_Click(ByVal sender As System.Object, _
                                       ByVal e As System.EventArgs) _
                                       Handles btnBrowseEncrypt.Click
        'Setup the open dialog.
        OpenFileDialog.FileName = ""
        OpenFileDialog.Title = "Choose a file to encrypt"
        OpenFileDialog.InitialDirectory = "C:\"
        OpenFileDialog.Filter = "All Files (*.*) | *.*"

        'Find out if the user chose a file.
        If OpenFileDialog.ShowDialog = DialogResult.OK Then
            strFileToEncrypt = OpenFileDialog.FileName
            txtFileToEncrypt.Text = strFileToEncrypt

            Dim iPosition As Integer = 0
            Dim i As Integer = 0

            'Get the position of the last "\" in the OpenFileDialog.FileName path.
            '-1 is when the character your searching for is not there.
            'IndexOf searches from left to right.
            While strFileToEncrypt.IndexOf("\"c, i) <> -1
                iPosition = strFileToEncrypt.IndexOf("\"c, i)
                i = iPosition + 1
            End While

            'Assign strOutputFile to the position after the last "\" in the path.
            'This position is the beginning of the file name.
            strOutputEncrypt = strFileToEncrypt.Substring(iPosition + 1)
            'Assign S the entire path, ending at the last "\".
            Dim S As String = strFileToEncrypt.Substring(0, iPosition + 1)
            'Replace the "." in the file extension with "_".
            strOutputEncrypt = strOutputEncrypt.Replace("."c, "_"c)
            'The final file name.  XXXXX.encrypt
            txtDestinationEncrypt.Text = S + strOutputEncrypt + ".xml"
            'Update buttons.
            btnEncrypt.Enabled = True
            btnChangeEncrypt.Enabled = True

        End If

    End Sub

    Private Sub btnBrowseDecrypt_Click(ByVal sender As System.Object, _
                                       ByVal e As System.EventArgs) _
                                       Handles btnBrowseDecrypt.Click
        'Setup the open dialog.
        OpenFileDialog.FileName = ""
        OpenFileDialog.Title = "Choose a file to decrypt"
        OpenFileDialog.InitialDirectory = "C:\"
        OpenFileDialog.Filter = "Encrypted XML Files (*.xml) | *.xml"

        'Find out if the user chose a file.
        If OpenFileDialog.ShowDialog = DialogResult.OK Then
            strFileToDecrypt = OpenFileDialog.FileName
            txtFileToDecrypt.Text = strFileToDecrypt
            Dim iPosition As Integer = 0
            Dim i As Integer = 0
            'Get the position of the last "\" in the OpenFileDialog.FileName path.
            '-1 is when the character your searching for is not there.
            'IndexOf searches from left to right.

            While strFileToDecrypt.IndexOf("\"c, i) <> -1
                iPosition = strFileToDecrypt.IndexOf("\"c, i)
                i = iPosition + 1
            End While

            'strOutputFile = the file path minus the last 8 characters (.encrypt)
            strOutputDecrypt = strFileToDecrypt.Substring(0, strFileToDecrypt.Length - 8)
            'Assign S the entire path, ending at the last "\".
            Dim S As String = strFileToDecrypt.Substring(0, iPosition + 1)
            'Assign strOutputFile to the position after the last "\" in the path.
            strOutputDecrypt = strOutputDecrypt.Substring((iPosition + 1))
            'Replace "_" with "."

            If File.Exists(S + strOutputDecrypt & ".zip") Then
                Dim intCount As Integer = 1
                Do While File.Exists(S + strOutputDecrypt & intCount.ToString & ".zip")
                    intCount += 1
                Loop
                txtDestinationDecrypt.Text = S + strOutputDecrypt & intCount.ToString & ".zip"
            Else
                txtDestinationDecrypt.Text = S + strOutputDecrypt & ".zip"
            End If

            'Update buttons
            btnDecrypt.Enabled = True
            btnChangeDecrypt.Enabled = True

        End If
    End Sub

    Private Sub btnChangeEncrypt_Click(ByVal sender As System.Object, _
                                       ByVal e As System.EventArgs) _
                                       Handles btnChangeEncrypt.Click
        'Setup up folder browser.
        FolderBrowserDialog.Description = "Select a folder to place the encrypted file in."
        'If the user selected a folder assign the path to txtDestinationEncrypt.
        If FolderBrowserDialog.ShowDialog = DialogResult.OK Then
            txtDestinationEncrypt.Text = FolderBrowserDialog.SelectedPath + _
                                         "\" + strOutputEncrypt + ".xml"
        End If
    End Sub

    Private Sub btnChangeDecrypt_Click(ByVal sender As System.Object, _
                                       ByVal e As System.EventArgs) _
                                       Handles btnChangeDecrypt.Click
        'Setup up folder browser.
        FolderBrowserDialog.Description = "Select a folder for to place the decrypted file in."
        'If the user selected a folder assign the path to txtDestinationDecrypt.
        If FolderBrowserDialog.ShowDialog = DialogResult.OK Then
            txtDestinationDecrypt.Text = FolderBrowserDialog.SelectedPath + _
                                         "\" + strOutputDecrypt & ".zip"
        End If
    End Sub

#End Region


#Region "6. Encrypt / Decrypt Buttons "

    '******************************
    '** Encrypt/Decrypt Buttons
    '******************************

    Private Sub btnEncrypt_Click(ByVal sender As System.Object, _
                                 ByVal e As System.EventArgs) _
                                 Handles btnEncrypt.Click
        'Make sure the password is correct.
        'If txtConPassEncrypt.Text = txtPassEncrypt.Text Then
        ''Declare variables for the key and iv.
        'The key needs to hold 256 bits and the iv 128 bits.
        'Dim bytKey As Byte()
        'Dim bytIV As Byte()
        ''Generate the Password key
        'commented out code below to implement hybrid AsymSym encryption
        Dim strSaltKey As String = "D0n't9W0rry4@b0ut2A5th1ng"
        Dim saltValueBytes As Byte()
        saltValueBytes = System.Text.Encoding.ASCII.GetBytes(strSaltKey)
        Dim returnValue As Guid

        returnValue = Guid.NewGuid()
        Dim strPassword As String = returnValue.ToString '.Substring(returnValue.ToString.Length - 11, 10)
        Dim rsaProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider
        rsaProvider.FromXmlString(objOptions.strPubKey)
        Dim bytArrayEncStr() As Byte = rsaProvider.Encrypt(System.Text.Encoding.UTF8.GetBytes(strPassword), False)
        Dim encStrAsStr = Convert.ToBase64String(bytArrayEncStr)
        'Dim strPassword As String = txtPassEncrypt.Text

        Dim passwordKey As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(strPassword, saltValueBytes)
        'Implementing Asymentric Key generation
        'Dim strPwd As String = "Pa$$w0rd"
        'Dim rsaProv As RSACryptoServiceProvider = New RSACryptoServiceProvider(2048)
        'rsaProv.FromXmlString(File.ReadAllText("C:\Documents and Settings\kellypm\Desktop\kys\PriKey.xml"))
        ''Dim rsaProv As RSACryptoServiceProvider = New RSACryptoServiceProvider(2048)
        ''Dim privateKey As RSAParameters = rsaProv.ExportParameters(True)
        ''yECDH.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hmac
        ''yECDH.HashAlgorithm = CngAlgorithm.ECDiffieHellmanP521
        'Dim encStrAsByt() As Byte = rsaProv.Encrypt(System.Text.Encoding.Unicode.GetBytes(strPwd), False)
        'Dim encStrAsStr As String = System.Text.Encoding.Unicode.GetString(encStrAsByt)
        'Dim passwordKey As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(encStrAsStr, saltValueBytes)
        'Dim passwordKey As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(passwordKey, saltValueBytes)
        'File.WriteAllText("C:\Documents and Settings\kellypm\Desktop\kys\PriKey2.xml", rsaProv.ToXmlString(True))
        'File.WriteAllText("C:\Documents and Settings\kellypm\Desktop\kys\PubKey2.xml", rsaProv.ToXmlString(False))


        'Dim myECDH As ECDiffieHellmanCng = New ECDiffieHellmanCng(521)
        'myECDH.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hmac
        'myECDH.HashAlgorithm = CngAlgorithm.ECDiffieHellmanP521
        'File.WriteAllText("C:\Documents and Settings\kellypm\Desktop\kys\myPrivateKey.xml", myECDH.ToXmlString(True))
        'File.WriteAllText("C:\Documents and Settings\kellypm\Desktop\kys\myPublicKey.xml", myECDH.ToXmlString(False))
        'Dim myKey As Byte() = myECDH.DeriveKeyMaterial(yECDH.PublicKey)
        Dim strZipFileName As String = AddToNewZip(strFileToEncrypt)

        Dim alg4AES As AesCryptoServiceProvider = New AesCryptoServiceProvider
        alg4AES.KeySize = 256
        alg4AES.BlockSize = 128
        alg4AES.Key = passwordKey.GetBytes(CInt(alg4AES.KeySize / 8))
        alg4AES.IV = passwordKey.GetBytes(CInt(alg4AES.BlockSize / 8))
        'Send the password to the CreateKey function.
        'bytKey = CreateKey(txtPassEncrypt.Text)
        'Send the password to the CreateIV function.
        'bytIV = CreateIV(txtPassEncrypt.Text)
        'Start the encryption.
        'EncryptOrDecryptFile(strZipFileName, txtDestinationEncrypt.Text, alg4AES, _
        '                     CryptoAction.ActionEncrypt, encStrAsStr)
        'Else
        'MsgBox("Please re-enter your password.", MsgBoxStyle.Exclamation)
        'txtPassEncrypt.Text = ""
        'txtConPassEncrypt.Text = ""
        'End If
        Dim strSSalt As String = "the sEcr3t!"
        Dim strPasssword As String = "Gr@titud3!"
        XLEncrypt(strZipFileName, txtDestinationEncrypt.Text, strPasssword, strSSalt, 4, pbStatus)
        File.Delete(strZipFileName)
        Dim fiOurFile As FileInfo = New FileInfo(ourFile.EncName)
        Dim lngMax As Long = 10000000
        If fiOurFile.Length < lngMax Then
            Dim dialogResult As DialogResult = MessageBox.Show("Your file has been encrypted as the file:" & vbCrLf & ourFile.EncName & vbCrLf & "Would you like to send this file?", "Encryption Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            'If objOptions.blnLog Then
            '    logEnc()
            'End If
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
            MsgBox("Encryption Complete", MsgBoxStyle.Information, "Done") '+ Wrap + Wrap + _
        End If
        ' "Total bytes processed = " + _
        ' lngBytesProcessed.ToString & vbCrLf & "total new bytes = " + lngBytesProcessed2.ToString, _
        ' ,MsgBoxStyle.Information, "Done")

        'Update the progress bar and textboxes.
        pbStatus.Value = 0
        txtFileToEncrypt.Text = "Click Browse to load file."
        txtPassEncrypt.Text = ""
        txtConPassEncrypt.Text = ""
        txtDestinationEncrypt.Text = ""
        btnChangeEncrypt.Enabled = False
        btnEncrypt.Enabled = False
    End Sub

    Private Sub btnDecrypt_Click(ByVal sender As System.Object, _
                                 ByVal e As System.EventArgs) _
                                 Handles btnDecrypt.Click
        'Make sure the password is correct.
        'If txtConPassDecrypt.Text = txtPassDecrypt.Text Then
        'Declare variables for the key and iv.
        'The key needs to hold 256 bits and the iv 128 bits.
        'Dim bytKey As Byte()
        'Dim bytIV As Byte()
        'Generate the Password key
        'Dim strTemp As String = ""
        'strTemp = File.ReadAllText("C:\process_printableCHARCOUNT.xml")
        'Dim lngCount As Long = System.Text.Encoding.UTF8.GetByteCount(strTemp)
        'MessageBox.Show(lngCount.ToString, "Count", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Dim strSaltKey As String = "D0n't9W0rry4@b0ut2A5th1ng"
        Dim saltValueBytes As Byte()
        saltValueBytes = System.Text.Encoding.ASCII.GetBytes(strSaltKey)
        Dim strPassword As String = txtPassDecrypt.Text

        'Dim strPwd As String = "Pa$$w0rd"
        'Dim rsaProv As RSACryptoServiceProvider = New RSACryptoServiceProvider(2048)
        'rsaProv.FromXmlString(File.ReadAllText("C:\Documents and Settings\kellypm\Desktop\kys\PriKey.xml"))
        'example decrypt asymetric
        'Dim RSA3 As RSACryptoServiceProvider = New RSACryptoServiceProvider(cspParam)
        ''---Load the Public key---
        'RSA3.FromXmlString(publicKey)
        'Dim DecryptedStrAsByt() As Byte = RSA3.Decrypt(System.Text.Encoding.Unicode.GetBytes(EncryptedStrAsString), False)
        'Dim DecryptedStrAsString = System.Text.Encoding.Unicode.GetString(DecryptedStrAsByt)
        Dim strSSalt As String = "the sEcr3t!"
        Dim strPasssword As String = "Gr@titud3!"
        Dim boolCorFormat As Boolean = False
        boolCorFormat = XLDecrypt(strFileToDecrypt, txtDestinationDecrypt.Text, strPasssword, strSSalt, 4, pbStatus)
        If boolCorFormat = True Then
            pbStatus.Value = 100
            Dim result As DialogResult = MessageBox.Show("Your file:" & vbCrLf & txtDestinationDecrypt.Text & vbCrLf & "has been decrypted" & vbCrLf & "Would you like to open it?", "File Decryption Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            If result = Windows.Forms.DialogResult.Yes Then
                Process.Start(txtDestinationDecrypt.Text)
            End If
            MessageBox.Show("Decryption Complete", "Decryption Complete!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            'Update the progress bar and textboxes.
            pbStatus.Value = 0
            txtFileToDecrypt.Text = "Click Browse to load file."
            txtPassDecrypt.Text = ""
            txtConPassDecrypt.Text = ""
            txtDestinationDecrypt.Text = ""
            btnChangeDecrypt.Enabled = False
            btnDecrypt.Enabled = False
        Else
            MessageBox.Show("Decryption Failed.  Please make sure the file you selected is in the correct format.", "Decryption Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If

        'Dim passwordKey As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(strPassword, saltValueBytes)
        'Dim alg4AES As AesCryptoServiceProvider = New AesCryptoServiceProvider
        'alg4AES.KeySize = 256
        'alg4AES.BlockSize = 128
        'alg4AES.Key = passwordKey.GetBytes(CInt(alg4AES.KeySize / 8))
        'alg4AES.IV = passwordKey.GetBytes(CInt(alg4AES.BlockSize / 8))
        ' ''Send the password to the CreateKey function.
        ' ''bytKey = CreateKey(txtPassDecrypt.Text)
        ' ''Send the password to the CreateIV function.
        ' ''bytIV = CreateIV(txtPassDecrypt.Text)
        ''Start the decryption.
        'EncryptOrDecryptFile(strFileToDecrypt, txtDestinationDecrypt.Text, alg4AES, _
        'CryptoAction.ActionDecrypt, "")
        ''Else
        ''MsgBox("Please re-enter your password.", MsgBoxStyle.Exclamation)
        ''txtPassDecrypt.Text = ""
        ''txtConPassDecrypt.Text = ""
        ''End If
    End Sub

#End Region




    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objOptions.strOutput = ConfigurationManager.AppSettings("OutputDirectory")
            objOptions.blnLog = CBool(ConfigurationManager.AppSettings("LogPasswords"))
            objOptions.intPort = CInt(ConfigurationManager.AppSettings("SMTPport"))
            objOptions.strEmailAddress = ConfigurationManager.AppSettings("systemFromMail")
            If Not ConfigurationManager.AppSettings("SMTPpassword") = String.Empty Then
                Dim strB64 As String = CStr(ConfigurationManager.AppSettings("SMTPpassword"))
                Dim strPassword As String = GetStringFromB64(strB64, "gr@tItud3")
                objOptions.strSMTPpassword = strPassword.Trim.Trim(vbNullChar)
            End If
            objOptions.strSMTPserver = ConfigurationManager.AppSettings("SMTPserver")
            objOptions.strSMTPuser = ConfigurationManager.AppSettings("SMTPuser")
            objOptions.blnSSL = CBool(ConfigurationManager.AppSettings("SMTPssl"))
            objOptions.strAddressList = ConfigurationManager.AppSettings("emailAddresses")
            objOptions.intMaxLogFile = CInt(ConfigurationManager.AppSettings("MaxLogFiles"))
            objOptions.strPrikeyName = ConfigurationManager.AppSettings("AsymPriKey")
            objOptions.strPubKeyName = ConfigurationManager.AppSettings("AsymPubKey")
            XML_CONFIG_FILE = System.Environment.GetEnvironmentVariable("APPDATA").ToString & "\Tenac10us\10d\zen\zen.xml"
            Xroot = System.Environment.GetEnvironmentVariable("APPDATA").ToString & "\Tenac10us\10d\"
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
                cBoxKeys2.Items.Add(strT.Replace("_pri", ""))
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
            For Each objItem As Object In cBoxKeys2.Items
                If objItem.ToString & "_pri" = objOptions.strPrikeyName Then
                    'cboxKeys.SelectedIndex = intCount2
                    cBoxKeys2.SelectedIndex = intCount2
                    Exit For
                End If
                intCount2 += 1
            Next
            GetKeys(objOptions.strPrikeyName, objOptions.strPubKeyName)
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
    Private Sub GetKeys(ByVal strKeyName As String, ByVal strPubKeyName As String)
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
            'strTemp = File.ReadAllText(strPath.Replace("_pri.xml", "_pub.xml"))
            'objOptions.strAkeyPub = strTemp

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
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
    Private Function StringToBytes( _
    ByVal str As String) _
    As Byte()

        Return System.Text.Encoding.UTF8.GetBytes(str)
    End Function
    Private Function BytesToString( _
    ByVal byt() As Byte) _
    As String

        Return System.Text.Encoding.UTF8.GetString(byt)
    End Function
    Private Sub cboxKeys_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxKeys.SelectedIndexChanged
        Try


            objOptions.strPubKeyName = cboxKeys.Items(cboxKeys.SelectedIndex).ToString & "_pub"
            GetKeys(objOptions.strPrikeyName, objOptions.strPubKeyName)
            Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath)
            config.AppSettings.Settings("AsymPubKey").Value = objOptions.strPubKeyName
            config.Save()
        Catch ex As Exception
            Throw ex
        End Try

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
    'Public Shared Sub Pump(ByVal input As Stream, ByVal output As Stream, ByVal lngLength As Long, ByRef objStatus As System.Windows.Forms.StatusBar)
    '    Dim buffer As Byte() = New Byte(1023) {}
    '    Dim count As Integer = 0
    '    Dim lngBytesProcessed As Long = 0
    '    While (InlineAssignHelper(count, input.Read(buffer, 0, 1024))) <> 0
    '        output.Write(buffer, 0, count)
    '        lngBytesProcessed = lngBytesProcessed + CLng(count)
    '        obj.Value = CInt((lngBytesProcessed / lngLength) * 100)
    '    End While
    '    output.Flush()
    'End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        Try
            Dim frmOpt As New frmtEncryptOptions
            frmOpt.ShowDialog()
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
                cBoxKeys2.Items.Add(strT.Replace("_pri", ""))
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
            For Each objItem As Object In cBoxKeys2.Items
                If objItem.ToString & "_pri" = objOptions.strPrikeyName Then
                    'cboxKeys.SelectedIndex = intCount2
                    cBoxKeys2.SelectedIndex = intCount2
                    Exit For
                End If
                intCount2 += 1
            Next
        Catch ex As Exception
            MessageBox.Show("Error Displaying options form. Message: " & vbCrLf & ex.Message, "Options Display Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub SendToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SendToolStripMenuItem.Click
        Try
            If Not ourFile.EncName = String.Empty Then
                Dim frmSendM As New frmtEncryptSendMail(ourFile.EncName)
                frmSendM.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show("Error Displaying Send Mail form. Message: " & vbCrLf & ex.Message, "Mail Display Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Try
            Dim frmAbt As New AboutBox
            frmAbt.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Error Displaying About form. Message: " & vbCrLf & ex.Message, "Options Display Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub cBoxKeys2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cBoxKeys2.SelectedIndexChanged
        Try


            objOptions.strPrikeyName = cBoxKeys2.Items(cBoxKeys2.SelectedIndex).ToString & "_pri"
            GetKeys(objOptions.strPrikeyName, objOptions.strPubKeyName)
            Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath)
            config.AppSettings.Settings("AsymPriKey").Value = objOptions.strPrikeyName
            config.Save()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CreateKeysToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CreateKeysToolStripMenuItem.Click
        Try

            Dim frmOpt As New frmGenKeys
            frmOpt.ShowDialog()
            Dim strPriKeys() As String = Directory.GetFiles(Xroot & "kys", "*_pri.xml")
            Dim strPubKeys() As String = Directory.GetFiles(Xroot & "kys", "*_pub.xml")
            lstPubKeyNames.Clear()
            lstPriKeyNames.Clear()
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
            cboxKeys.Items.Clear()
            cboxKeys.Refresh()
            For Each strT As String In lstPubKeyNames
                cboxKeys.Items.Add(strT.Replace("_pub", ""))
                'cBoxKeys2.Items.Add(strT.Replace("_pri", ""))
            Next
            cBoxKeys2.Items.Clear()
            cBoxKeys2.Refresh()
            For Each strT As String In lstPriKeyNames
                cBoxKeys2.Items.Add(strT.Replace("_pri", ""))
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
            For Each objItem As Object In cBoxKeys2.Items
                If objItem.ToString & "_pri" = objOptions.strPrikeyName Then
                    'cboxKeys.SelectedIndex = intCount2
                    cBoxKeys2.SelectedIndex = intCount2
                    Exit For
                End If
                intCount2 += 1
            Next
        Catch ex As Exception
            MessageBox.Show("Error Displaying Create Keys form. Message: " & vbCrLf & ex.Message, "Create Keys Display Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
End Class
