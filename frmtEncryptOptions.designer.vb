<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmtEncryptOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmtEncryptOptions))
        Me.fbdOptions = New System.Windows.Forms.FolderBrowserDialog
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkShowPassword = New System.Windows.Forms.CheckBox
        Me.txtSMTPport = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.chkSSL = New System.Windows.Forms.CheckBox
        Me.txtSMTPpassword = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSMTPuser = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtSMTPserver = New System.Windows.Forms.TextBox
        Me.LabelSMTP = New System.Windows.Forms.Label
        Me.txtEmailAddress = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboxKeys = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboxKeys2 = New System.Windows.Forms.ComboBox
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(123, 269)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(204, 269)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkShowPassword)
        Me.GroupBox2.Controls.Add(Me.txtSMTPport)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.chkSSL)
        Me.GroupBox2.Controls.Add(Me.txtSMTPpassword)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtSMTPuser)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtSMTPserver)
        Me.GroupBox2.Controls.Add(Me.LabelSMTP)
        Me.GroupBox2.Controls.Add(Me.txtEmailAddress)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 79)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(369, 184)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mail Settings"
        '
        'chkShowPassword
        '
        Me.chkShowPassword.AutoSize = True
        Me.chkShowPassword.Location = New System.Drawing.Point(116, 122)
        Me.chkShowPassword.Name = "chkShowPassword"
        Me.chkShowPassword.Size = New System.Drawing.Size(102, 17)
        Me.chkShowPassword.TabIndex = 11
        Me.chkShowPassword.Text = "Show Password"
        Me.chkShowPassword.UseVisualStyleBackColor = True
        '
        'txtSMTPport
        '
        Me.txtSMTPport.Location = New System.Drawing.Point(116, 145)
        Me.txtSMTPport.MaxLength = 5
        Me.txtSMTPport.Name = "txtSMTPport"
        Me.txtSMTPport.Size = New System.Drawing.Size(47, 20)
        Me.txtSMTPport.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(34, 148)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "SMTP Port:"
        '
        'chkSSL
        '
        Me.chkSSL.AutoSize = True
        Me.chkSSL.Location = New System.Drawing.Point(205, 147)
        Me.chkSSL.Name = "chkSSL"
        Me.chkSSL.Size = New System.Drawing.Size(86, 17)
        Me.chkSSL.TabIndex = 8
        Me.chkSSL.Text = "Require SSL"
        Me.chkSSL.UseVisualStyleBackColor = True
        '
        'txtSMTPpassword
        '
        Me.txtSMTPpassword.Location = New System.Drawing.Point(116, 99)
        Me.txtSMTPpassword.Name = "txtSMTPpassword"
        Me.txtSMTPpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSMTPpassword.Size = New System.Drawing.Size(224, 20)
        Me.txtSMTPpassword.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "SMTP Password:"
        '
        'txtSMTPuser
        '
        Me.txtSMTPuser.Location = New System.Drawing.Point(116, 73)
        Me.txtSMTPuser.Name = "txtSMTPuser"
        Me.txtSMTPuser.Size = New System.Drawing.Size(224, 20)
        Me.txtSMTPuser.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "SMTP UserName:"
        '
        'txtSMTPserver
        '
        Me.txtSMTPserver.Location = New System.Drawing.Point(99, 47)
        Me.txtSMTPserver.Name = "txtSMTPserver"
        Me.txtSMTPserver.Size = New System.Drawing.Size(241, 20)
        Me.txtSMTPserver.TabIndex = 3
        '
        'LabelSMTP
        '
        Me.LabelSMTP.AutoSize = True
        Me.LabelSMTP.Location = New System.Drawing.Point(17, 50)
        Me.LabelSMTP.Name = "LabelSMTP"
        Me.LabelSMTP.Size = New System.Drawing.Size(65, 13)
        Me.LabelSMTP.TabIndex = 2
        Me.LabelSMTP.Text = "SMTP Host:"
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Location = New System.Drawing.Point(99, 17)
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(241, 20)
        Me.txtEmailAddress.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Email Address:"
        '
        'cboxKeys
        '
        Me.cboxKeys.FormattingEnabled = True
        Me.cboxKeys.Location = New System.Drawing.Point(130, 22)
        Me.cboxKeys.Name = "cboxKeys"
        Me.cboxKeys.Size = New System.Drawing.Size(241, 21)
        Me.cboxKeys.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Default Encryption Key:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Default Decryption Key:"
        '
        'cboxKeys2
        '
        Me.cboxKeys2.FormattingEnabled = True
        Me.cboxKeys2.Location = New System.Drawing.Point(131, 49)
        Me.cboxKeys2.Name = "cboxKeys2"
        Me.cboxKeys2.Size = New System.Drawing.Size(241, 21)
        Me.cboxKeys2.TabIndex = 10
        '
        'frmtEncryptOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(410, 304)
        Me.Controls.Add(Me.cboxKeys2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboxKeys)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmtEncryptOptions"
        Me.Text = "Tenac10us 10d Options"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fbdOptions As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSMTPserver As System.Windows.Forms.TextBox
    Friend WithEvents LabelSMTP As System.Windows.Forms.Label
    Friend WithEvents chkSSL As System.Windows.Forms.CheckBox
    Friend WithEvents txtSMTPpassword As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSMTPuser As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSMTPport As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkShowPassword As System.Windows.Forms.CheckBox
    Friend WithEvents cboxKeys As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboxKeys2 As System.Windows.Forms.ComboBox
End Class
