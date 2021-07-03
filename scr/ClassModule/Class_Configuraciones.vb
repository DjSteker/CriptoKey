Imports System.Xml

Friend Class Class_Configuraciones
    Shared Archivo As String = "\DB\Configuraciones.xml"
    Event Modificacion()


#Region ""

    Private Shared Function ObtenerCuerpo() As XmlNode
        Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & Archivo
        Dim xmlDoc As New XmlDocument
        '  xmlDoc.DocumentType = Xml.XmlDataDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        '  Dim CuerpoXL_1a As XmlNodeList = 
        Return Nudo
    End Function

    ''' <summary>
    ''' Obtener las columnas del archivo y tabla
    ''' </summary>
    ''' <param name="Tabla">Nombre de la tabla</param>
    ''' <param name="Rejistro">Numero del rejistro a comprobar</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Shared Function ObtenerColumnas(ByVal Tabla As String, ByVal Rejistro As Long) As ArrayList
        Dim Columnas As New ArrayList
        Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & Archivo
        Dim xmlDoc As New XmlDocument
        '  xmlDoc.DocumentType = Xml.XmlDataDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        '  Dim output As String = ""
        '   Dim summary As XmlNode = Nothing
        Dim CuerpoXL_1 As XmlNodeList = xmlDoc.GetElementsByTagName("body")
        Dim CuerpoXD_1 As New XmlDocument
        CuerpoXD_1.LoadXml(CuerpoXL_1.Item(0).InnerXml)

        Dim Tabla1 As XmlNodeList = CuerpoXD_1.GetElementsByTagName(Tabla)
        Dim BodyDb As XmlNode = Tabla1.Item(0)

        Dim Rejistro1 As XmlNodeList = BodyDb.ChildNodes
        '  For Each member As XmlNode In BodyDb

        For Each member1 As XmlNode In Rejistro1.Item(Rejistro)
            Columnas.Add(member1.Name)
        Next
        '  Next
        Return Columnas
    End Function

#End Region

#Region "Datos"

    Friend Shared Function RutaDatos_Obtener() As String
        Dim Enviado As String = String.Empty
        Dim RutaXML As String = My.Application.Info.DirectoryPath & Archivo
        Dim xmlDoc As New XmlDocument
        Try
            xmlDoc.Load(RutaXML)
            Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
            Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("tabla_Datos").Item(0)
            Enviado = NudoTabla.SelectSingleNode("DestinoCopiaBD").InnerText.ToString
            If Enviado = String.Empty Then
                Enviado = My.Application.Info.DirectoryPath.ToString & "\DB"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Enviado
    End Function

    Friend Shared Function RutaDatos_Modificar(ByVal SelecContador As String) As Boolean
        Dim Guardado As Boolean = False
        Try
            Dim RutaXML As String = My.Application.Info.DirectoryPath & Archivo
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(RutaXML)
            Dim CuerpoXL_1 As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
            Dim NudoTabla As XmlNode = CuerpoXL_1.SelectSingleNode("tabla_Datos") '.Item(0)
            NudoTabla.SelectSingleNode("DestinoCopiaBD").InnerText = SelecContador
            xmlDoc.Save(RutaXML)
            Guardado = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            ' ObtenerTodos()
            My.Application.DoEvents()
            Module_Central.CopasSeguridad(Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo)

        Catch ex As Exception
            MsgBox("" & vbCr & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
        Return Guardado
    End Function




#End Region



End Class
