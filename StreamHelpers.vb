
Imports System
Imports System.IO
Imports System.Security.Cryptography

Namespace CryptoSamples
    ''' <summary>
    ''' Some helpers for stream work
    ''' </summary>
    Public Class StreamHelpers
        Private Sub New()
        End Sub

        Public Shared Sub Pump(ByVal input As Stream, ByVal output As Stream, ByVal lngLength As Long, ByRef objStatus As System.Windows.Forms.ProgressBar)
            Dim buffer As Byte() = New Byte(1023) {}
            Dim count As Integer = 0
            Dim lngBytesProcessed As Long = 0
            While (InlineAssignHelper(count, input.Read(buffer, 0, 1024))) <> 0
                output.Write(buffer, 0, count)
                lngBytesProcessed = lngBytesProcessed + CLng(count)
                objStatus.Value = CInt((lngBytesProcessed / lngLength) * 100)
            End While
            output.Flush()
        End Sub
        Public Shared Function GetReadOnlyFileStream(ByVal path As String) As FileStream
            Return New FileStream(path, FileMode.Open, FileAccess.Read)
        End Function
        Public Shared Function GetReadOnlyFileStream4(ByVal path As String) As FileStream
            Dim fs As FileStream = New FileStream(path, FileMode.Open, FileAccess.Read)
            fs.Position = 3
            Return fs
        End Function

        Public Shared Function GetWriteableFileStream(ByVal path As String) As FileStream
            Return New FileStream(path, FileMode.OpenOrCreate, FileAccess.Write)
        End Function
        Public Shared Function GetAppendableFileStream(ByVal path As String) As FileStream
            Return New FileStream(path, FileMode.Append, FileAccess.Write)
        End Function

        Public Shared Function GetWriteCryptoStream(ByVal stream As Stream, ByVal transform As ICryptoTransform) As CryptoStream
            Return New CryptoStream(stream, transform, CryptoStreamMode.Write)
        End Function

        Public Shared Function GetReadCryptoStream(ByVal stream As Stream, ByVal transform As ICryptoTransform) As CryptoStream
            Return New CryptoStream(stream, transform, CryptoStreamMode.Read)
        End Function
        Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
            target = value
            Return value
        End Function
    End Class
End Namespace


