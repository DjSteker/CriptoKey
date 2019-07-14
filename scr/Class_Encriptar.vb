
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Public Class Class_Encriptar

Friend Shared Function encriptar128BitRijndael(ByVal textoEncriptar As String, ByVal Contraseña As String) As String
        Dim bytValue() As Byte
        Dim bytKey() As Byte
        Dim bytEncoded() As Byte = New Byte() {}
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

    Friend Shared Function desencriptar128BitRijndael(ByVal textoEncriptado As String, ByVal Contraseña As String) As String
        Dim MensajeError As Boolean = False

        Dim bytDataToBeDecrypted() As Byte
        Dim bytTemp() As Byte
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
            MensajeError = True
        End Try
        If MensajeError Then
99905:      Return textoEncriptado
        Else
            Return quitarNullCadena(Encoding.ASCII.GetString(bytTemp))
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

    End Class
