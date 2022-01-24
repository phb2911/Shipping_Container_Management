
Namespace Cryptography

#Region "TripleDES"

    Public Class TripleDES

        Private Sub New()
            ' can't create object reference
        End Sub

        Public Shared Function Encode(ByVal Value As String, ByVal Key As String) As String
            Dim des As New Security.Cryptography.TripleDESCryptoServiceProvider
            des.IV = New Byte(7) {}
            Dim pdb As New Security.Cryptography.PasswordDeriveBytes(Key, New Byte(-1) {})
            des.Key = pdb.CryptDeriveKey("RC2", "MD5", 128, New Byte(7) {})
            Dim ms As New IO.MemoryStream((Value.Length * 2) - 1)
            Dim encStream As New Security.Cryptography.CryptoStream(ms, des.CreateEncryptor(), Security.Cryptography.CryptoStreamMode.Write)
            Dim plainBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(Value)
            encStream.Write(plainBytes, 0, plainBytes.Length)
            encStream.FlushFinalBlock()
            Dim encryptedBytes(CInt(ms.Length - 1)) As Byte
            ms.Position = 0
            ms.Read(encryptedBytes, 0, CInt(ms.Length))
            encStream.Close()
            Return Convert.ToBase64String(encryptedBytes)
        End Function

        Public Shared Function Decode(ByVal Value As String, ByVal Key As String) As String
            Dim des As New Security.Cryptography.TripleDESCryptoServiceProvider
            des.IV = New Byte(7) {}
            Dim pdb As New Security.Cryptography.PasswordDeriveBytes(Key, New Byte(-1) {})
            des.Key = pdb.CryptDeriveKey("RC2", "MD5", 128, New Byte(7) {})
            Dim encryptedBytes As Byte() = Convert.FromBase64String(Value)
            Dim ms As New IO.MemoryStream(Value.Length)
            Dim decStream As New Security.Cryptography.CryptoStream(ms, des.CreateDecryptor(), Security.Cryptography.CryptoStreamMode.Write)
            decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
            decStream.FlushFinalBlock()
            Dim plainBytes(CInt(ms.Length - 1)) As Byte
            ms.Position = 0
            ms.Read(plainBytes, 0, CInt(ms.Length))
            decStream.Close()
            Return System.Text.Encoding.UTF8.GetString(plainBytes)
        End Function

    End Class

#End Region ' TripleDES

#Region "MD5"

    Public Class MD5

        Private Sub New()
            ' can't create object reference
        End Sub

        Public Shared Function HashString(ByVal Value As String) As String
            Dim MD5 As New System.Security.Cryptography.MD5CryptoServiceProvider()
            Dim BynaryData() As Byte = MD5.ComputeHash(System.Text.UTF8Encoding.UTF8.GetBytes(Value))

            Return System.Convert.ToBase64String(BynaryData)

        End Function

    End Class

#End Region ' MD5

End Namespace
