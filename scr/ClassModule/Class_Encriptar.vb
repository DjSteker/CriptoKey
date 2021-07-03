'Public Class Class_Encriptar


Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Public Class Class_Encriptar


#Region "Buena"

    'Friend Shared Function encriptar128BitRijndael(ByVal textoEncriptar As String, ByVal claveEncriptacion As String) As String
    Friend Shared Function encriptar128BitRijndael(ByVal textoEncriptar As String, ByVal Contraseña As String) As String
        Dim bytValue() As Byte
        Dim bytKey() As Byte
        Dim bytEncoded() As Byte = New Byte() {}
        'Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}
        'Dim bytIV() As Byte = {112, 141, 100, 209, 33, 73, 52, 48, 146, 245, 255, 123, 213, 44, 3, 128}
        Dim bytIV() As Byte = {112, 141, 100, 209, 33, 73, 52, 48, 146, 245, 255, 123, 213, 44, 32, 128}

        Dim intLength As Integer
        Dim intRemaining As Integer
        Dim objMemoryStream As New MemoryStream()
        Dim objCryptoStream As CryptoStream
        Dim objRijndaelManaged As RijndaelManaged


        'Quitar nulos en cadena de texto a encriptar
        textoEncriptar = quitarNullCadena(textoEncriptar)

        If textoEncriptar = "" Then
            Return ""
        End If

        bytValue = Encoding.ASCII.GetBytes(textoEncriptar.ToCharArray)

        intLength = Len(Contraseña)


        'La clave de cifrado debe ser de 256 bits de longitud (32 bytes)
        'Si tiene más de 32 bytes se truncará
        'Si es menor de 32 bytes se rellenará con X
        If intLength >= 32 Then
            Contraseña = Strings.Left(Contraseña, 32)
        Else
            intLength = Len(Contraseña)
            intRemaining = 32 - intLength
            Contraseña = Contraseña & Strings.StrDup(intRemaining, Contraseña)
        End If

        bytKey = Encoding.ASCII.GetBytes(Contraseña.ToCharArray)

        objRijndaelManaged = New RijndaelManaged()

        Try
            'Crear objeto Encryptor y escribir su valor 
            'después de que se convierta en array de bytes
            objCryptoStream = New CryptoStream(objMemoryStream,
          objRijndaelManaged.CreateEncryptor(bytKey, bytIV),
          CryptoStreamMode.Write)
            objCryptoStream.Write(bytValue, 0, bytValue.Length)

            objCryptoStream.FlushFinalBlock()

            bytEncoded = objMemoryStream.ToArray
            objMemoryStream.Close()
            objCryptoStream.Close()
        Catch ex As Exception
            MsgBox("Error al encriptar cadena de texto: " &
               ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation)
        End Try

        'Devolver el valor del texto encriptado
        'convertido de array de bytes a texto en base64
        Return Convert.ToBase64String(bytEncoded)
    End Function


    ' Friend Shared Function desencriptar128BitRijndael(ByVal textoEncriptado As String, ByVal claveDesencriptacion As String) As String
    Friend Shared Function desencriptar128BitRijndael(ByVal textoEncriptado As String, ByVal Contraseña As String) As String
        Dim MensajeError As Boolean = False

        Dim bytDataToBeDecrypted() As Byte
        Dim bytTemp() As Byte
        'Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}
        'Dim bytIV() As Byte = {112, 141, 100, 209, 33, 73, 52, 48, 146, 245, 255, 123, 213, 44, 3, 128}
        Dim bytIV() As Byte = {112, 141, 100, 209, 33, 73, 52, 48, 146, 245, 255, 123, 213, 44, 32, 128}
        Dim objRijndaelManaged As New RijndaelManaged()
        Dim objMemoryStream As MemoryStream
        Dim objCryptoStream As CryptoStream
        Dim bytDecryptionKey() As Byte

        Dim intLength As Integer
        Dim intRemaining As Integer
        Dim strReturnString As String = String.Empty

        If textoEncriptado = "" Then
            GoTo 99905
        End If
        Try
            'Convertir el valor encriptado base64 a array de bytes
            bytDataToBeDecrypted = Convert.FromBase64String(textoEncriptado)

            '  bytDataToBeDecrypted = encoderAscii.GetBytes(textoEncriptado)

            'La clave de desencriptación debe ser de 256 bits de longitud (32 bytes)
            'Si tiene más de 32 bytes se truncará
            'Si es menor de 32 bytes se rellenará con A
            intLength = Len(Contraseña)

            If intLength >= 32 Then
                Contraseña = Strings.Left(Contraseña, 32)
            Else
                intLength = Len(Contraseña)
                intRemaining = 32 - intLength
                Contraseña = Contraseña & Strings.StrDup(intRemaining, Contraseña)
            End If

            bytDecryptionKey = Encoding.ASCII.GetBytes(Contraseña.ToCharArray)

            ReDim bytTemp(bytDataToBeDecrypted.Length)

            objMemoryStream = New MemoryStream(bytDataToBeDecrypted)


            'Crear objeto Dencryptor y escribir su valor 
            'después de que se convierta en array de bytes
            objCryptoStream = New CryptoStream(objMemoryStream,
           objRijndaelManaged.CreateDecryptor(bytDecryptionKey, bytIV), CryptoStreamMode.Read)

            objCryptoStream.Read(bytTemp, 0, bytTemp.Length)

            'objCryptoStream.FlushFinalBlock()
            objMemoryStream.Close()
            objCryptoStream.Close()
        Catch ex As Exception
            '   MsgBox("Error al desencriptar cadena de texto: " & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation)
            MensajeError = True
        End Try
        If MensajeError Then
99905:      Return textoEncriptado
        Else
#Disable Warning BC42104 ' La variable 'bytTemp' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            Return quitarNullCadena(Encoding.ASCII.GetString(bytTemp))
#Enable Warning BC42104 ' La variable 'bytTemp' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
        End If
        'Devolver la cadena de texto desencriptada
        'convertida de array de bytes a cadena de texto ASCII

    End Function

    'Quita nulos de una cadena de texto
    Friend Shared Function quitarNullCadena(ByVal texto As String) As String
        Dim posicionNull As Integer
        Dim textoSinNull As String

        posicionNull = 1
        textoSinNull = texto

        Do While posicionNull > 0
            posicionNull = InStr(posicionNull, texto, vbNullChar)

            If posicionNull > 0 Then
                textoSinNull =
                Left$(textoSinNull, posicionNull - 1) &
                Right$(textoSinNull,
                Len(textoSinNull) - posicionNull)
            End If

            If posicionNull > textoSinNull.Length Then
                Exit Do
            End If
        Loop

        Return textoSinNull
    End Function



#End Region


#Region "microsoft"
    Public Shared Sub Main()
        Try

            Dim original As String = "Here is some data to encrypt!"

            ' Create a new instance of the Rijndael
            ' class.  This generates a new key and initialization 
            ' vector (IV).
            Using myRijndael = Rijndael.Create()

                ' Encrypt the string to an array of bytes.
                Dim encrypted As Byte() = EncryptStringToBytes(original, myRijndael.Key, myRijndael.IV)

                ' Decrypt the bytes to a string.
                Dim roundtrip As String = DecryptStringFromBytes(encrypted, myRijndael.Key, myRijndael.IV)

                'Display the original data and the decrypted data.
                Console.WriteLine("Original:   {0}", original)
                Console.WriteLine("Round Trip: {0}", roundtrip)
            End Using
        Catch e As Exception
            Console.WriteLine("Error: {0}", e.Message)
        End Try

    End Sub 'Main

    Shared Function EncryptStringToBytes(ByVal plainText As String, ByVal Key() As Byte, ByVal IV() As Byte) As Byte()
        ' Check arguments.
        If plainText Is Nothing OrElse plainText.Length <= 0 Then
            Throw New ArgumentNullException("plainText")
        End If
        If Key Is Nothing OrElse Key.Length <= 0 Then
            Throw New ArgumentNullException("Key")
        End If
        If IV Is Nothing OrElse IV.Length <= 0 Then
            Throw New ArgumentNullException("IV")
        End If
        Dim encrypted() As Byte
        ' Create an Rijndael object
        ' with the specified key and IV.
        Using rijAlg = Rijndael.Create()

            rijAlg.Key = Key
            rijAlg.IV = IV

            ' Create an encryptor to perform the stream transform.
            Dim encryptor As ICryptoTransform = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV)
            ' Create the streams used for encryption.
            Using msEncrypt As New MemoryStream()
                Using csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)
                    Using swEncrypt As New StreamWriter(csEncrypt)

                        'Write all data to the stream.
                        swEncrypt.Write(plainText)
                    End Using
                    encrypted = msEncrypt.ToArray()
                End Using
            End Using
        End Using

        ' Return the encrypted bytes from the memory stream.
        Return encrypted

    End Function 'EncryptStringToBytes

    Shared Function DecryptStringFromBytes(ByVal cipherText() As Byte, ByVal Key() As Byte, ByVal IV() As Byte) As String
        ' Check arguments.
        If cipherText Is Nothing OrElse cipherText.Length <= 0 Then
            Throw New ArgumentNullException("cipherText")
        End If
        If Key Is Nothing OrElse Key.Length <= 0 Then
            Throw New ArgumentNullException("Key")
        End If
        If IV Is Nothing OrElse IV.Length <= 0 Then
            Throw New ArgumentNullException("IV")
        End If
        ' Declare the string used to hold
        ' the decrypted text.
        Dim plaintext As String = Nothing

        ' Create an Rijndael object
        ' with the specified key and IV.
        Using rijAlg = Rijndael.Create()
            rijAlg.Key = Key
            rijAlg.IV = IV

            ' Create a decryptor to perform the stream transform.
            Dim decryptor As ICryptoTransform = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV)

            ' Create the streams used for decryption.
            Using msDecrypt As New MemoryStream(cipherText)

                Using csDecrypt As New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)

                    Using srDecrypt As New StreamReader(csDecrypt)


                        ' Read the decrypted bytes from the decrypting stream
                        ' and place them in a string.
                        plaintext = srDecrypt.ReadToEnd()
                    End Using
                End Using
            End Using
        End Using

        Return plaintext

    End Function 'DecryptStringFromBytes 

#End Region

End Class

