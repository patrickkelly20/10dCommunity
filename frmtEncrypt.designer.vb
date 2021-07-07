<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmtEncrypt
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnBrowseToFile = New System.Windows.Forms.Button
        Me.txtFileToCompress = New System.Windows.Forms.TextBox
        Me.ofdFileToCompress = New System.Windows.Forms.OpenFileDialog
        Me.lblStatus = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPassword1 = New System.Windows.Forms.TextBox
        Me.txtPassword2 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnEncrypt = New System.Windows.Forms.Button
        Me.btnDeCrypt = New System.Windows.Forms.Button
        Me.chkShowPassword = New System.Windows.Forms.CheckBox
        Me.btnReset = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.txtSalt2 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtSalt1 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.chkShowSalt = New System.Windows.Forms.CheckBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SendToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GenerateKeyFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cboxKeys = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Filename:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBrowseToFile)
        Me.GroupBox1.Controls.Add(Me.txtFileToCompress)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(515, 67)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Target File: "
        '
        'btnBrowseToFile
        '
        Me.btnBrowseToFile.Location = New System.Drawing.Point(91, 39)
        Me.btnBrowseToFile.Name = "btnBrowseToFile"
        Me.btnBrowseToFile.Size = New System.Drawing.Size(61, 23)
        Me.btnBrowseToFile.TabIndex = 2
        Me.btnBrowseToFile.Text = "Browse"
        Me.btnBrowseToFile.UseVisualStyleBackColor = True
        '
        'txtFileToCompress
        '
        Me.txtFileToCompress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFileToCompress.Location = New System.Drawing.Point(91, 13)
        Me.txtFileToCompress.Name = "txtFileToCompress"
        Me.txtFileToCompress.Size = New System.Drawing.Size(398, 20)
        Me.txtFileToCompress.TabIndex = 1
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(31, 196)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(38, 13)
        Me.lblStatus.TabIndex = 3
        Me.lblStatus.Text = "Ready"
        Me.lblStatus.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(55, 154)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Password:"
        Me.Label2.Visible = False
        '
        'txtPassword1
        '
        Me.txtPassword1.Location = New System.Drawing.Point(114, 150)
        Me.txtPassword1.Name = "txtPassword1"
        Me.txtPassword1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword1.Size = New System.Drawing.Size(108, 20)
        Me.txtPassword1.TabIndex = 6
        Me.txtPassword1.Visible = False
        '
        'txtPassword2
        '
        Me.txtPassword2.Location = New System.Drawing.Point(387, 150)
        Me.txtPassword2.Name = "txtPassword2"
        Me.txtPassword2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword2.Size = New System.Drawing.Size(108, 20)
        Me.txtPassword2.TabIndex = 8
        Me.txtPassword2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(233, 154)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(148, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Please re-enter the Password:"
        Me.Label3.Visible = False
        '
        'btnEncrypt
        '
        Me.btnEncrypt.Location = New System.Drawing.Point(179, 137)
        Me.btnEncrypt.Name = "btnEncrypt"
        Me.btnEncrypt.Size = New System.Drawing.Size(98, 46)
        Me.btnEncrypt.TabIndex = 9
        Me.btnEncrypt.Text = "&Encrypt"
        Me.btnEncrypt.UseVisualStyleBackColor = True
        '
        'btnDeCrypt
        '
        Me.btnDeCrypt.Location = New System.Drawing.Point(283, 137)
        Me.btnDeCrypt.Name = "btnDeCrypt"
        Me.btnDeCrypt.Size = New System.Drawing.Size(98, 46)
        Me.btnDeCrypt.TabIndex = 10
        Me.btnDeCrypt.Text = "&De-Crypt"
        Me.btnDeCrypt.UseVisualStyleBackColor = True
        '
        'chkShowPassword
        '
        Me.chkShowPassword.AutoSize = True
        Me.chkShowPassword.Location = New System.Drawing.Point(114, 176)
        Me.chkShowPassword.Name = "chkShowPassword"
        Me.chkShowPassword.Size = New System.Drawing.Size(126, 17)
        Me.chkShowPassword.TabIndex = 11
        Me.chkShowPassword.Text = "Show Password Text"
        Me.chkShowPassword.UseVisualStyleBackColor = True
        Me.chkShowPassword.Visible = False
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(71, 138)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(93, 35)
        Me.btnReset.TabIndex = 12
        Me.btnReset.Text = "&Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(402, 137)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(93, 35)
        Me.btnExit.TabIndex = 13
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'txtSalt2
        '
        Me.txtSalt2.Location = New System.Drawing.Point(387, 106)
        Me.txtSalt2.Name = "txtSalt2"
        Me.txtSalt2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSalt2.Size = New System.Drawing.Size(108, 20)
        Me.txtSalt2.TabIndex = 17
        Me.txtSalt2.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(261, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Please re-enter the Salt:"
        Me.Label4.Visible = False
        '
        'txtSalt1
        '
        Me.txtSalt1.Location = New System.Drawing.Point(114, 105)
        Me.txtSalt1.Name = "txtSalt1"
        Me.txtSalt1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSalt1.Size = New System.Drawing.Size(108, 20)
        Me.txtSalt1.TabIndex = 15
        Me.txtSalt1.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(83, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Salt:"
        Me.Label5.Visible = False
        '
        'chkShowSalt
        '
        Me.chkShowSalt.AutoSize = True
        Me.chkShowSalt.Location = New System.Drawing.Point(114, 131)
        Me.chkShowSalt.Name = "chkShowSalt"
        Me.chkShowSalt.Size = New System.Drawing.Size(98, 17)
        Me.chkShowSalt.TabIndex = 18
        Me.chkShowSalt.Text = "Show Salt Text"
        Me.chkShowSalt.UseVisualStyleBackColor = True
        Me.chkShowSalt.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.EditToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(539, 24)
        Me.MenuStrip1.TabIndex = 19
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.SendToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
        Me.ToolStripMenuItem1.Text = "File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.OpenToolStripMenuItem.Text = "Open..."
        '
        'SendToolStripMenuItem
        '
        Me.SendToolStripMenuItem.Name = "SendToolStripMenuItem"
        Me.SendToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.SendToolStripMenuItem.Text = "Send..."
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.GenerateKeyFileToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'GenerateKeyFileToolStripMenuItem
        '
        Me.GenerateKeyFileToolStripMenuItem.Name = "GenerateKeyFileToolStripMenuItem"
        Me.GenerateKeyFileToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.GenerateKeyFileToolStripMenuItem.Text = "Generate Key File"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem1})
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.AboutToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem1
        '
        Me.AboutToolStripMenuItem1.Name = "AboutToolStripMenuItem1"
        Me.AboutToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.AboutToolStripMenuItem1.Text = "About..."
        '
        'cboxKeys
        '
        Me.cboxKeys.FormattingEnabled = True
        Me.cboxKeys.Location = New System.Drawing.Point(103, 101)
        Me.cboxKeys.Name = "cboxKeys"
        Me.cboxKeys.Size = New System.Drawing.Size(393, 21)
        Me.cboxKeys.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(54, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Key:"
        '
        'frmtEncrypt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(539, 224)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnDeCrypt)
        Me.Controls.Add(Me.btnEncrypt)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.cboxKeys)
        Me.Controls.Add(Me.chkShowSalt)
        Me.Controls.Add(Me.txtSalt2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chkShowPassword)
        Me.Controls.Add(Me.txtPassword2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPassword1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtSalt1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmtEncrypt"
        Me.Text = "Tenac10us 10d"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBrowseToFile As System.Windows.Forms.Button
    Friend WithEvents txtFileToCompress As System.Windows.Forms.TextBox
    Friend WithEvents ofdFileToCompress As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPassword1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnEncrypt As System.Windows.Forms.Button
    Friend WithEvents btnDeCrypt As System.Windows.Forms.Button
    Friend WithEvents chkShowPassword As System.Windows.Forms.CheckBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents txtSalt2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSalt1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkShowSalt As System.Windows.Forms.CheckBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerateKeyFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboxKeys As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
