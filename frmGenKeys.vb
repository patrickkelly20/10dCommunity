Imports System
Imports System.IO
Imports System.Math
Imports System.Security
Imports System.Security.Cryptography

Public Class frmGenKeys
    Dim strFileName As String = ""
    Dim intSize As Integer = 8192

    Private Sub btnSaveKeyFileAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveKeyFileAs.Click
        Dim result As DialogResult
        result = sfdKeyFile.ShowDialog
        If result = Windows.Forms.DialogResult.OK Then
            strFileName = sfdKeyFile.FileName
            txtKeyFile.Text = strFileName
            lblKeyFileName.Text = "KeyFile name: " & strFileName & vbCrLf & "Directory: " & Path.GetDirectoryName(strFileName)
        End If
        
    End Sub

    Private Sub btnGenKeyFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenKeyFile.Click
        Try

            If txtKeyFile.Text.Contains(",") Then
                MessageBox.Show("KeyFile Name can not contain commas.  Please remove commas.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf txtKeyFile.Text.Contains("/") Then
                MessageBox.Show("KeyFile Name can not contain forward slashes.  Please remove forward slashes.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf txtKeyFile.Text.Contains("`") Then
                MessageBox.Show("KeyFile Name must only contain letters, numbers, underscores and dashes. Please remove all other characters from the KeyFile Name.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf txtKeyFile.Text.Contains("!") Then
                MessageBox.Show("KeyFile Name must only contain letters, numbers, underscores and dashes. Please remove all other characters from the KeyFile Name.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf txtKeyFile.Text.Contains("@") Then
                MessageBox.Show("KeyFile Name must only contain letters, numbers, underscores and dashes. Please remove all other characters from the KeyFile Name.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf txtKeyFile.Text.Contains("#") Then
                MessageBox.Show("KeyFile Name must only contain letters, numbers, underscores and dashes. Please remove all other characters from the KeyFile Name.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf txtKeyFile.Text.Contains("$") Then
                MessageBox.Show("KeyFile Name must only contain letters, numbers, underscores and dashes. Please remove all other characters from the KeyFile Name.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf txtKeyFile.Text.Contains("%") Then
                MessageBox.Show("KeyFile Name must only contain letters, numbers, underscores and dashes. Please remove all other characters from the KeyFile Name.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf txtKeyFile.Text.Contains("^") Then
                MessageBox.Show("KeyFile Name must only contain letters, numbers, underscores and dashes. Please remove all other characters from the KeyFile Name.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf txtKeyFile.Text.Contains("&") Then
                MessageBox.Show("KeyFile Name must only contain letters, numbers, underscores and dashes. Please remove all other characters from the KeyFile Name.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf txtKeyFile.Text.Contains("*") Then
                MessageBox.Show("KeyFile Name must only contain letters, numbers, underscores and dashes. Please remove all other characters from the KeyFile Name.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf txtKeyFile.Text.Contains("(") Then
                MessageBox.Show("KeyFile Name must only contain letters, numbers, underscores and dashes. Please remove all other characters from the KeyFile Name.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf txtKeyFile.Text.Contains(")") Then
                MessageBox.Show("KeyFile Name must only contain letters, numbers, underscores and dashes. Please remove all other characters from the KeyFile Name.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf txtKeyFile.Text.Contains("+") Then
                MessageBox.Show("KeyFile Name must only contain letters, numbers, underscores and dashes. Please remove all other characters from the KeyFile Name.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf txtKeyFile.Text.Contains("=") Then
                MessageBox.Show("KeyFile Name must only contain letters, numbers, underscores and dashes. Please remove all other characters from the KeyFile Name.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf txtKeyFile.Text.Contains("{") Then
                MessageBox.Show("KeyFile Name must only contain letters, numbers, underscores and dashes. Please remove all other characters from the KeyFile Name.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf txtKeyFile.Text.Contains("}") Then
                MessageBox.Show("KeyFile Name must only contain letters, numbers, underscores and dashes. Please remove all other characters from the KeyFile Name.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf txtKeyFile.Text.Contains("[") Then
                MessageBox.Show("KeyFile Name must only contain letters, numbers, underscores and dashes. Please remove all other characters from the KeyFile Name.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf txtKeyFile.Text.Contains("]") Then
                MessageBox.Show("KeyFile Name must only contain letters, numbers, underscores and dashes. Please remove all other characters from the KeyFile Name.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf txtKeyFile.Text.Contains("|") Then
                MessageBox.Show("KeyFile Name must only contain letters, numbers, underscores and dashes. Please remove all other characters from the KeyFile Name.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf txtKeyFile.Text.Contains(Chr(34)) Then
                MessageBox.Show("KeyFile Name must only contain letters, numbers, underscores and dashes. Please remove all other characters from the KeyFile Name.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf txtKeyFile.Text.Contains("'") Then
                MessageBox.Show("KeyFile Name must only contain letters, numbers, underscores and dashes. Please remove all other characters from the KeyFile Name.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf txtKeyFile.Text.Contains("?") Then
                MessageBox.Show("KeyFile Name must only contain letters, numbers, underscores and dashes. Please remove all other characters from the KeyFile Name.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf txtKeyFile.Text.Contains("<") Then
                MessageBox.Show("KeyFile Name must only contain letters, numbers, underscores and dashes. Please remove all other characters from the KeyFile Name.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf txtKeyFile.Text.Contains(">") Then
                MessageBox.Show("KeyFile Name must only contain letters, numbers, underscores and dashes. Please remove all other characters from the KeyFile Name.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            ElseIf txtKeyFile.Text.Contains("~") Then
                MessageBox.Show("KeyFile Name must only contain letters, numbers, underscores and dashes. Please remove all other characters from the KeyFile Name.", "KeyFile name error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Else
                lblStatus.Text = "Status:  Processing..."
                pgbStatus.Value = 10

                Dim intCount As Integer = 1
                Dim strFolderName As String = Xroot & "\kys"
                If Not Directory.Exists(strFolderName) Then
                    Directory.CreateDirectory(strFolderName)
                End If
                If txtKeyFile.Text = "" Then
                    strFileName = strFolderName & "\" & System.Environment.UserName.Replace("\", "_") & ".xml"
                Else
                    If txtKeyFile.Text.Contains("\") Then
                        strFileName = strFolderName & "\" & Path.GetFileNameWithoutExtension(txtKeyFile.Text) & ".xml"
                    Else
                        strFileName = strFolderName & "\" & txtKeyFile.Text & ".xml"
                    End If
                End If
                Dim strStartFileName As String = Path.GetDirectoryName(strFileName) & "\" & Path.GetFileNameWithoutExtension(strFileName)
                Dim strExt As String = ".xml"
                'While File.Exists(strFileName)
                '    strFileName = strStartFileName & intCount.ToString & strExt
                '    intCount += 1
                'End While
                Dim strFinStartName As String = Path.GetDirectoryName(strFileName) & "\" & Path.GetFileNameWithoutExtension(strFileName)
                Dim strPub As String = "_pub"
                Dim StrPri As String = "_pri"
                Dim strFilePub As String = strFinStartName & strPub & strExt
                Dim strFilePri As String = strFinStartName & StrPri & strExt
                If File.Exists(strFilePub) Then ' Or File.Exists(strFilePri) Then
                    MessageBox.Show("Error: A key with the name you requested already exists." & vbCrLf & "Please choose a new file name.", "Duplicate Key Name Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                ElseIf File.Exists(strFilePri) Then
                    MessageBox.Show("Error: A key with the name you requested already exists." & vbCrLf & "Please choose a new file name.", "Duplicate Key Name Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Else

                    Dim intKeySize As Integer = intSize
                    pgbStatus.Value = 15
                    'create the rsa provider
                    Dim myRSA As RSACryptoServiceProvider = New RSACryptoServiceProvider(intKeySize)
                    pgbStatus.Value = 20
                    Dim privateKey As RSAParameters = myRSA.ExportParameters(True)
                    pgbStatus.Value = 30
                    Dim strXML As String = myRSA.ToXmlString(True)
                    pgbStatus.Value = 40
                    File.WriteAllText(strFilePri, strXML)
                    pgbStatus.Value = 50
                    strXML = ""
                    strXML = myRSA.ToXmlString(False)
                    pgbStatus.Value = 75
                    File.WriteAllText(strFilePub, strXML)
                    pgbStatus.Value = 100
                    strXML = ""
                    lblStatus.Text = "Status: KeyFile " & Path.GetFileName(strFilePri).ToString & " is complete."
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error Generating Key File", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub frmGenKeys_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sfdKeyFile.InitialDirectory = Xroot & "\kys"
        ddlKeySize.SelectedIndex = 7
    End Sub

    Private Sub ddlKeySize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlKeySize.SelectedIndexChanged
        intSize = CInt(ddlKeySize.SelectedItem.ToString)
    End Sub
End Class