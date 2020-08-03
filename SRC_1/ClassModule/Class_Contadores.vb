'Imports Microsoft.VisualBasic
Imports System.Xml

Friend Class Class_Contadores
    Shared Archivo As String = "\Contadores.xml"
    Event Modificacion()

    Friend Shared Function ObtenerCuenta() As Integer

        '   Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & Archivo
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        '   Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
        Dim Cuenta As Integer
        Try

            Cuenta = Nudo.ChildNodes.Count


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Cuenta
    End Function

    Private Shared Function ObtenerCuerpo() As XmlNode
        '   Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & Archivo
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
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
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
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

    Friend Shared Function ObtenerWhereContador(ByVal Id As String) As Archivo_Contadores
        Dim Enviado As New Archivo_Contadores
        '   Dim RutaXMLConfigPrintInt As String = My.Application.Info.DirectoryPath & Archivo
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("tabla1").Item(0)
        Try
            For Each Rejistro1 As XmlNode In NudoTabla.ChildNodes

                Dim ID_Compara As String = Rejistro1.SelectSingleNode("NombreContador").InnerText
                If Id = ID_Compara Then
                    Enviado.NombreContador = Rejistro1.SelectSingleNode("NombreContador").InnerText
                    Enviado.Cuenta = Rejistro1.SelectSingleNode("Cuenta").InnerText
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Enviado
    End Function

    Friend Shared Function ExisteId(ByVal Id As String) As Boolean
        Dim Existe As Boolean = False
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("tabla1").Item(0)
        Try
            For Each Rejistro1 As XmlNode In NudoTabla.ChildNodes
                Dim Comparador As String = Rejistro1.SelectSingleNode("NombreContador").InnerText
                If Comparador = Id Then
                    Existe = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Existe
    End Function

    Friend Shared Function InsertarRejistrosTodos(ByVal Archivo_contador As Archivo_Contadores)
        Dim Datos1 As New List(Of Archivo_Contadores)

        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("tabla1").Item(0)

        Try

            Dim NuevoNudo As XmlNode = xmlDoc.CreateElement("contador")
            NuevoNudo.AppendChild(xmlDoc.CreateTextNode(""))

            Dim NuevoNudoC_NombreContador As XmlNode = xmlDoc.CreateElement("NombreContador")
            NuevoNudoC_NombreContador.AppendChild(xmlDoc.CreateTextNode(Archivo_contador.NombreContador.ToString))
            NuevoNudo.AppendChild(NuevoNudoC_NombreContador)
            '------------------
            Dim NuevoNudoC_Cuenta As XmlNode = xmlDoc.CreateElement("Cuenta")
            NuevoNudoC_Cuenta.AppendChild(xmlDoc.CreateTextNode(Archivo_contador.Cuenta))
            NuevoNudo.AppendChild(NuevoNudoC_Cuenta)

            NudoTabla.AppendChild(NuevoNudo)

            xmlDoc.Save(RutaXMLConfigPrintInt)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            '  ObtenerTodos()
            My.Application.DoEvents()
            Module_Central.CopasSeguridad(Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo)

        Catch ex As Exception
            MsgBox("" & vbCr & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try

        Return Datos1
    End Function

    Friend Shared Function ModificarRejistro(ByVal SelecContador As String, ByVal Cuenta As Long) As Boolean
        Dim Guardado As Boolean = False
        Try
            Dim xmlDoc As New XmlDocument
            Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
            xmlDoc.Load(RutaXMLConfigPrintInt)

            Dim CuerpoXL_1 As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)

            Dim CuerpoXL_1a As XmlNodeList = CuerpoXL_1.SelectSingleNode("tabla1").ChildNodes

            For Each Rejistros As XmlNode In CuerpoXL_1a

                Dim Comparador As String = Rejistros.SelectSingleNode("NombreContador").InnerText

                If Comparador = SelecContador Then
                    Rejistros.SelectSingleNode("Cuenta").InnerText = Cuenta
                    Exit For
                End If

            Next
            xmlDoc.Save(RutaXMLConfigPrintInt)

            Guardado = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            'ObtenerTodos()
            My.Application.DoEvents()
            Module_Central.CopasSeguridad(Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo)

        Catch ex As Exception
            MsgBox("" & vbCr & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
        Return Guardado
    End Function

    Friend Shared Function EliminarRejistro(ByVal Tabla As String, ByVal SeleccColumna As String, ByVal SelecValor As String) As Boolean
        Dim Guardado As Boolean = False
        Try
            Dim xmlDoc As New XmlDocument
            Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
            xmlDoc.Load(RutaXMLConfigPrintInt)
            'xmlDoc.Load(My.Application.Info.DirectoryPath & Archivo)

            Dim CuerpoXL_1 As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
            Dim CuerpoXL_1a As XmlNode = CuerpoXL_1.SelectSingleNode(Tabla)

            For Each Rejistros As XmlNode In CuerpoXL_1a
                Dim Comparador As String = Rejistros.SelectSingleNode(SeleccColumna).InnerText
                If Comparador = SelecValor Then
                    CuerpoXL_1a.RemoveChild(Rejistros)
                End If
            Next

            xmlDoc.Save(RutaXMLConfigPrintInt)

            Guardado = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            'ObtenerTodos()
            My.Application.DoEvents()
            Module_Central.CopasSeguridad(Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo)

        Catch ex As Exception
            MsgBox("" & vbCr & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
        Return Guardado
    End Function

    Friend Structure Archivo_Contadores
        Dim NombreContador As String
        Dim Cuenta As String
    End Structure

End Class
