Imports System.IO
Imports System.Security
Imports System.Security.Cryptography

Public Class Encryption

    Public Shared IV() As Byte = {50, 199, 10, 159, 132, 55, 236, 189, 51, 243, 244, 91, 17, 136, 39, 230}
    Public Shared ReadOnly keyForEncryptingStrings As String = "*engineering_"

    Public Function StringEncrypt(ByVal plainText As String, ByVal keyText As String) As String
        Try
            Dim workText As String = plainText.Replace(vbNullChar, "")
            Dim workBytes() As Byte = System.Text.Encoding.UTF8.GetBytes(plainText)
            Dim keyBytes() As Byte = System.Text.Encoding.UTF8.GetBytes(keyText.GetHashCode)
            keyBytes = {45, 49, 52, 55, 57, 57, 56, 53, 48, 56, 56}         'Hashcode in 32-Bit-Umgebung

            Dim rijndael As New Security.Cryptography.RijndaelManaged
            Dim memoryStream As New IO.MemoryStream()
            Dim cryptoTransform As Security.Cryptography.ICryptoTransform
            cryptoTransform = rijndael.CreateEncryptor(keyBytes, Encryption.IV)
            Dim cryptoStream As New Security.Cryptography.CryptoStream(memoryStream, cryptoTransform, System.Security.Cryptography.CryptoStreamMode.Write)
            cryptoStream.Write(workBytes, 0, workBytes.Length)
            cryptoStream.FlushFinalBlock()
            Dim encrypted As String = Convert.ToBase64String(memoryStream.ToArray)
            memoryStream.Close()
            cryptoStream.Close()
            Return encrypted
        Catch
            Return ""
        End Try
    End Function
    Public Function StringDecrypt(ByVal encrypted As String, ByVal keyText As String) As String
        Try
            Dim workBytes() As Byte =
            Convert.FromBase64String(encrypted)
            Dim keyBytes() As Byte = System.Text.Encoding.UTF8.GetBytes(keyText.GetHashCode)
            keyBytes = {45, 49, 52, 55, 57, 57, 56, 53, 48, 56, 56}         'Hashcode in 32-Bit-Umgebung

            Dim tempBytes(workBytes.Length - 1) As Byte
            Dim rijndael As New Security.Cryptography.RijndaelManaged
            Dim memoryStream As New IO.MemoryStream(workBytes)
            Dim cryptoTransform As Security.Cryptography.ICryptoTransform
            cryptoTransform = rijndael.CreateDecryptor(keyBytes, Encryption.IV)
            Dim cryptoStream As New Security.Cryptography.CryptoStream(memoryStream, cryptoTransform, Security.Cryptography.CryptoStreamMode.Read)
            cryptoStream.Read(tempBytes, 0, tempBytes.Length)
            memoryStream.Close()
            cryptoStream.Close()
            Dim plainText As String = System.Text.Encoding.UTF8.GetString(tempBytes)

            Return plainText.Replace(vbNullChar, "")
        Catch
            Return ""
        End Try
    End Function

End Class
