<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmtEncryptSendMail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmtEncryptSendMail))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtTo = New System.Windows.Forms.TextBox
        Me.txtCC = New System.Windows.Forms.TextBox
        Me.txtBcc = New System.Windows.Forms.TextBox
        Me.btnSendTop = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtMessage = New System.Windows.Forms.TextBox
        Me.btnSendBottom = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lbl8 = New System.Windows.Forms.Label
        Me.lblAttachment = New System.Windows.Forms.Label
        Me.txtSubject = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnAttach = New System.Windows.Forms.Button
        Me.ofdAttach = New System.Windows.Forms.OpenFileDialog
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "To:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Cc:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Bcc:"
        '
        'txtTo
        '
        Me.txtTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTo.Location = New System.Drawing.Point(61, 39)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(330, 20)
        Me.txtTo.TabIndex = 0
        '
        'txtCC
        '
        Me.txtCC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCC.Location = New System.Drawing.Point(61, 65)
        Me.txtCC.Name = "txtCC"
        Me.txtCC.Size = New System.Drawing.Size(330, 20)
        Me.txtCC.TabIndex = 1
        '
        'txtBcc
        '
        Me.txtBcc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBcc.Location = New System.Drawing.Point(61, 93)
        Me.txtBcc.Name = "txtBcc"
        Me.txtBcc.Size = New System.Drawing.Size(330, 20)
        Me.txtBcc.TabIndex = 2
        '
        'btnSendTop
        '
        Me.btnSendTop.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnSendTop.Location = New System.Drawing.Point(61, 4)
        Me.btnSendTop.Name = "btnSendTop"
        Me.btnSendTop.Size = New System.Drawing.Size(75, 23)
        Me.btnSendTop.TabIndex = 6
        Me.btnSendTop.Text = "Send"
        Me.btnSendTop.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 155)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Message:"
        '
        'txtMessage
        '
        Me.txtMessage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMessage.Location = New System.Drawing.Point(61, 152)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(330, 139)
        Me.txtMessage.TabIndex = 4
        '
        'btnSendBottom
        '
        Me.btnSendBottom.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSendBottom.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnSendBottom.Location = New System.Drawing.Point(107, 320)
        Me.btnSendBottom.Name = "btnSendBottom"
        Me.btnSendBottom.Size = New System.Drawing.Size(75, 23)
        Me.btnSendBottom.TabIndex = 5
        Me.btnSendBottom.Text = "Send"
        Me.btnSendBottom.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(207, 320)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lbl8
        '
        Me.lbl8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl8.AutoSize = True
        Me.lbl8.Location = New System.Drawing.Point(7, 294)
        Me.lbl8.Name = "lbl8"
        Me.lbl8.Size = New System.Drawing.Size(64, 13)
        Me.lbl8.TabIndex = 11
        Me.lbl8.Text = "Attachment:"
        '
        'lblAttachment
        '
        Me.lblAttachment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAttachment.AutoSize = True
        Me.lblAttachment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAttachment.Location = New System.Drawing.Point(77, 294)
        Me.lblAttachment.Name = "lblAttachment"
        Me.lblAttachment.Size = New System.Drawing.Size(45, 13)
        Me.lblAttachment.TabIndex = 12
        Me.lblAttachment.Text = "Label5"
        '
        'txtSubject
        '
        Me.txtSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubject.Location = New System.Drawing.Point(61, 126)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(330, 20)
        Me.txtSubject.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Subject:"
        '
        'btnAttach
        '
        Me.btnAttach.Location = New System.Drawing.Point(161, 4)
        Me.btnAttach.Name = "btnAttach"
        Me.btnAttach.Size = New System.Drawing.Size(75, 23)
        Me.btnAttach.TabIndex = 7
        Me.btnAttach.Text = "Attach..."
        Me.btnAttach.UseVisualStyleBackColor = True
        '
        'frmtEncryptSendMail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 355)
        Me.Controls.Add(Me.btnAttach)
        Me.Controls.Add(Me.txtSubject)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblAttachment)
        Me.Controls.Add(Me.lbl8)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSendBottom)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnSendTop)
        Me.Controls.Add(Me.txtBcc)
        Me.Controls.Add(Me.txtCC)
        Me.Controls.Add(Me.txtTo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmtEncryptSendMail"
        Me.Text = "Tenac10us 10d - Email "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents txtCC As System.Windows.Forms.TextBox
    Friend WithEvents txtBcc As System.Windows.Forms.TextBox
    Friend WithEvents btnSendTop As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents btnSendBottom As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lbl8 As System.Windows.Forms.Label
    Friend WithEvents lblAttachment As System.Windows.Forms.Label
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnAttach As System.Windows.Forms.Button
    Friend WithEvents ofdAttach As System.Windows.Forms.OpenFileDialog
End Class
