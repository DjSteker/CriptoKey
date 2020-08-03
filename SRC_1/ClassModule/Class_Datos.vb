
Imports System.Xml


Public Class Class_Datos

    Shared Archivo As String = "\DataBase.xml"
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

    Private Shared Function ObtenerCuerpo0() As XmlNode
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
    ''' <param name="Colunma">Nombre de la tabla</param>
    ''' <param name="Rejistros">Numero del rejistro a comprobar</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Shared Function ObtenerColumnas(ByVal Colunma As String, ByVal Rejistros As Long) As ArrayList
        Dim Columnas As New ArrayList
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        '  xmlDoc.DocumentType = Xml.XmlDataDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        '  Dim output As String = ""
        '  Dim summary As XmlNode = Nothing
        Dim CuerpoXL_1 As XmlNodeList = xmlDoc.GetElementsByTagName("body")
        Dim CuerpoXD_1 As New XmlDocument
        CuerpoXD_1.LoadXml(CuerpoXL_1.Item(0).InnerXml)

        Dim Tabla1 As XmlNodeList = CuerpoXD_1.GetElementsByTagName(Colunma)
        Dim BodyDb As XmlNode = Tabla1.Item(0)

        Dim Rejistro1 As XmlNodeList = BodyDb.ChildNodes

        For Each member1 As XmlNode In Rejistro1.Item(Rejistros)
            Columnas.Add(member1.Name)
        Next
        Return Columnas
    End Function

    Friend Shared Function ObtenerWhereId(ByVal Id As String) As ClassArchivo_Datos
        Dim Rejistro As New ClassArchivo_Datos(0, "", "", "", "", False)
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        Try
            For Each Rejistro1 As XmlNode In Nudo.ChildNodes
                Dim ID_Compara As String = Rejistro1.SelectSingleNode("C_Id").InnerText.ToString.Trim
                If Id.ToString = ID_Compara Then

                    Dim RejistroTemp As New ClassArchivo_Datos(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
                    Rejistro1.SelectSingleNode("C_Name").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Key").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Desc").InnerText(),
                    Rejistro1.SelectSingleNode("C_Tematica").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
                    Rejistro = RejistroTemp

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Rejistro
    End Function

    Friend Shared Function ObtenerWhereNombre(ByVal Nombre As String) As ClassArchivo_Datos
        Dim Rejistro As New ClassArchivo_Datos(0, "", "", "", "", False)
        Dim Encontrado As Boolean = False
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        Try
            For Each Rejistro1 As XmlNode In Nudo.ChildNodes
                Dim Compara As String = Rejistro1.SelectSingleNode("C_Name").InnerText.ToString.Trim.ToLower
                If Nombre.ToString.Trim.ToLower = Compara Then
                    Rejistro = New ClassArchivo_Datos(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
                            Rejistro1.SelectSingleNode("C_Nombre").InnerText.ToString,
                            Rejistro1.SelectSingleNode("C_Key").InnerText.ToString,
                            Rejistro1.SelectSingleNode("C_Desc").InnerText,
                            Rejistro1.SelectSingleNode("C_Tematica").InnerText.ToString,
                            Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString)
                    Encontrado = True

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return Rejistro
    End Function

    Friend Shared Function ObtenerWhereActivos(ByVal Activo As String) As List(Of ClassArchivo_Datos)
        Dim Rejistro As New List(Of ClassArchivo_Datos)
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        Try
            For Each Rejistro1 As XmlNode In Nudo.ChildNodes
                Dim Nif_Compara As String = Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString.Trim.ToLower
                If Activo.ToString.Trim.ToLower = Nif_Compara Then

                    Dim A As String = Rejistro1.SelectSingleNode("C_Id").InnerText.ToString()
                    A = Rejistro1.SelectSingleNode("C_Name").InnerText.ToString()
                    A = Rejistro1.SelectSingleNode("C_Key").InnerText.ToString()
                    A = Rejistro1.SelectSingleNode("C_Desc").InnerText.ToString()
                    A = Rejistro1.SelectSingleNode("C_Tematica").InnerText.ToString()
                    A = Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString()


                    Dim RejistroTemp As New ClassArchivo_Datos(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
                    Rejistro1.SelectSingleNode("C_Name").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Key").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Desc").InnerText(),
                    Rejistro1.SelectSingleNode("C_Tematica").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
                    Rejistro.Add(RejistroTemp)



                    'Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Rejistro
    End Function


#Region "busquedas"

    Friend Shared Function ObtenerWhereTodos(ByVal ByVal_ValorComparador As String) As List(Of ClassArchivo_Datos)
        Dim ValorComparador As String = ByVal_ValorComparador.ToString.Trim.ToLower
        Dim Rejistro As New List(Of ClassArchivo_Datos)
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
        Try
            For Each Rejistro1 As XmlNode In Nudo.ChildNodes
                Dim coparador As New ClassArchivo_Datos(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
                    Rejistro1.SelectSingleNode("C_Name").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Key").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Desc").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Tematica").InnerText(),
                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
                ' Dim Compara As String = Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString.Trim.ToLower
                If ValorComparador = coparador.Activo Or ValorComparador = coparador.Descripcion Or
                ValorComparador = coparador.Id Or ValorComparador = coparador.Nombre Or
                ValorComparador = coparador.Valor Then



                    Dim RejistroTemp As New ClassArchivo_Datos(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
                    Rejistro1.SelectSingleNode("C_Name").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Key").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Desc").InnerText(),
                    Rejistro1.SelectSingleNode("C_Tematica").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
                    Rejistro.Add(RejistroTemp)


                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Rejistro
    End Function

    Friend Shared Function ObtenerWhereNombres(ByVal ByVal_Nombre As String) As List(Of ClassArchivo_Datos)
        Dim Rejistro As New List(Of ClassArchivo_Datos)
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
        Try
            For Each Rejistro1 As XmlNode In Nudo.ChildNodes
                Dim Nif_Compara As String = Rejistro1.SelectSingleNode("C_Name").InnerText.ToString.Trim.ToLower
                If ByVal_Nombre.ToString.Trim.ToLower = Nif_Compara Then
                    Dim RejistroTemp As New ClassArchivo_Datos(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
                    Rejistro1.SelectSingleNode("C_Name").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Key").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Desc").InnerText(),
                    Rejistro1.SelectSingleNode("C_Tematica").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
                    Rejistro.Add(RejistroTemp)

                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Rejistro
    End Function

    Friend Shared Function ObtenerWhere_Key(ByVal ByVal_1 As String) As List(Of ClassArchivo_Datos)
        Dim Rejistro As New List(Of ClassArchivo_Datos)
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        Try
            For Each Rejistro1 As XmlNode In Nudo.ChildNodes
                Dim Nif_Compara As String = Rejistro1.SelectSingleNode("C_Key").InnerText.ToString.Trim.ToLower
                If ByVal_1.ToString.Trim.ToLower = Nif_Compara Then
                    Dim RejistroTemp As New ClassArchivo_Datos(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
                    Rejistro1.SelectSingleNode("C_Name").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Key").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Desc").InnerText(),
                    Rejistro1.SelectSingleNode("C_Tematica").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
                    Rejistro.Add(RejistroTemp)

                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Rejistro
    End Function

    Friend Shared Function ObtenerWhereDesc(ByVal ByVal_1 As String) As List(Of ClassArchivo_Datos)
        Dim Rejistro As New List(Of ClassArchivo_Datos)
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        Try
            For Each Rejistro1 As XmlNode In Nudo.ChildNodes
                Dim Nif_Compara As String = Rejistro1.SelectSingleNode("C_Desc").InnerText.ToString.Trim.ToLower
                If ByVal_1.ToString.Trim.ToLower = Nif_Compara Then
                    Dim RejistroTemp As New ClassArchivo_Datos(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
                    Rejistro1.SelectSingleNode("C_Name").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Key").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Desc").InnerText(),
                    Rejistro1.SelectSingleNode("C_Tematica").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
                    Rejistro.Add(RejistroTemp)

                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Rejistro
    End Function

    Friend Shared Function ObtenerWhereTematic(ByVal ByVal_1 As String) As ClassArchivo_Datos
        Dim Rejistro As ClassArchivo_Datos
        Dim Encontrado As Double = False
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        Try
            For Each Rejistro1 As XmlNode In Nudo.ChildNodes
                Dim Compara As String = Rejistro1.SelectSingleNode("C_Tematica").InnerText.ToString.Trim.ToLower
                If ByVal_1.ToString.Trim.ToLower = Compara Then
                    Dim RejistroTemp As New ClassArchivo_Datos(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
                    Rejistro1.SelectSingleNode("C_Name").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Key").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Desc").InnerText(),
                    Rejistro1.SelectSingleNode("C_Tematica").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
                    Encontrado = True
                    Exit For

                End If

            Next
            If Encontrado = False Then
                Rejistro = New ClassArchivo_Datos(0, "", "", "", "", False)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
#Disable Warning BC42104 ' La variable 'Rejistro' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
        Return Rejistro
#Enable Warning BC42104 ' La variable 'Rejistro' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
    End Function

    Friend Shared Function ObtenerWhereActivo(ByVal ByVal_1 As String) As List(Of ClassArchivo_Datos)
        Dim Rejistro As New List(Of ClassArchivo_Datos)
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)

        Try
            For Each Rejistro1 As XmlNode In Nudo.ChildNodes
                Dim Nif_Compara As String = Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString.Trim.ToLower
                If ByVal_1.ToString.Trim.ToLower = Nif_Compara Then
                    Dim RejistroTemp As New ClassArchivo_Datos(Rejistro1.SelectSingleNode("C_Id").InnerText.ToString,
                    Rejistro1.SelectSingleNode("C_Name").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Key").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Desc").InnerText(),
                    Rejistro1.SelectSingleNode("C_Tematica").InnerText.ToString(),
                    Rejistro1.SelectSingleNode("C_Activo").InnerText.ToString())
                    Rejistro.Add(RejistroTemp)

                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Rejistro
    End Function


#End Region



    'Friend Shared Function ObtenerWhereBusqueda(ByVal DatosBusqueda As ClassArchivo_Dielectricos) As List(Of ClassArchivo_Dielectricos)
    '    Dim RejistroLista As New List(Of ClassArchivo_Dielectricos)
    '    Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
    '    Dim xmlDoc As New XmlDocument
    '    xmlDoc.Load(RutaXMLConfigPrintInt)
    '    Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
    '    '  Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("C_Cliente").Item(0)
    '    Try

    '        Dim Lista As New ArrayList









    '        'Dim ColumnasXml As New ArrayList
    '        'Dim ColumnasStructure As New ArrayList
    '        'If DatosBusqueda.Id <> String.Empty Then : ColumnasXml.Add("C_Id") : ColumnasStructure.Add(DatosBusqueda.Id.ToString.ToLower) : End If
    '        'If DatosBusqueda.Nombre <> String.Empty Then : ColumnasXml.Add("C_Nombre") : ColumnasStructure.Add(DatosBusqueda.Nombre.ToString.ToLower) : End If
    '        'If DatosBusqueda.Apellidos <> String.Empty Then : ColumnasXml.Add("C_Apellidos") : ColumnasStructure.Add(DatosBusqueda.Apellidos.ToString.ToLower) : End If
    '        'If DatosBusqueda.Nif <> String.Empty Then : ColumnasXml.Add("C_Nif") : ColumnasStructure.Add(DatosBusqueda.Nif.ToString.ToLower) : End If
    '        'If DatosBusqueda.Poblacion <> String.Empty Then : ColumnasXml.Add("C_CPostal") : ColumnasStructure.Add(DatosBusqueda.CPostal.ToString.ToLower) : End If
    '        'If DatosBusqueda.Poblacion <> String.Empty Then : ColumnasXml.Add("C_Poblacion") : ColumnasStructure.Add(DatosBusqueda.Poblacion.ToString.ToLower) : End If
    '        'If DatosBusqueda.Poblacion <> String.Empty Then : ColumnasXml.Add("C_Calle") : ColumnasStructure.Add(DatosBusqueda.Calle.ToString.ToLower) : End If
    '        'If DatosBusqueda.Telefonos <> String.Empty Then : ColumnasXml.Add("C_Telefonos") : ColumnasStructure.Add(DatosBusqueda.Telefonos.ToString.ToLower) : End If





    '        'For Each RejistroNudo As XmlNode In Nudo.ChildNodes
    '        '    Dim Encontrados As Int16 = 0
    '        '    For Indice As Int64 = 0 To ColumnasXml.Count - 1
    '        '        Dim dato_Compara As String = RejistroNudo.SelectSingleNode(ColumnasXml.Item(Indice)).InnerText.ToString.Trim.ToLower
    '        '        If ColumnasStructure.Item(Indice).ToString = dato_Compara Then
    '        '            Encontrados += 1

    '        '        ElseIf ColumnasStructure.Item(Indice).ToString.Length < dato_Compara.Length
    '        '            For indiceCaracteres As Integer = 0 To dato_Compara.Length - ColumnasStructure.Item(Indice).ToString.Length
    '        '                Dim CadenaFragmento As String = Mid(dato_Compara.ToString, indiceCaracteres + 1, ColumnasStructure.Item(Indice).ToString.Length) ' dato_Compara.ToString.Skip(indiceCaracteres).Take(dato_Compara.Length).ToString()

    '        '                If ColumnasStructure.Item(Indice).ToString = Mid(dato_Compara.ToString, indiceCaracteres + 1, ColumnasStructure.Item(Indice).ToString.Length) Then
    '        '                    Encontrados += 1
    '        '                    Exit For
    '        '                End If
    '        '            Next

    '        '        End If

    '        '    Next

    '        '    If Encontrados = ColumnasXml.Count Then
    '        '        Dim Rejistro As New Archivo_Clientes
    '        '        Rejistro.Id = RejistroNudo.SelectSingleNode("C_Id").InnerText.ToString.Trim
    '        '        Rejistro.Nombre = RejistroNudo.SelectSingleNode("C_Nombre").InnerText.ToString
    '        '        Rejistro.Apellidos = RejistroNudo.SelectSingleNode("C_Apellidos").InnerText.ToString
    '        '        Rejistro.Nif = RejistroNudo.SelectSingleNode("C_Nif").InnerText.ToString
    '        '        ' Rejistro.Direccion = Rejistro1.SelectSingleNode("C_Direccion").InnerText
    '        '        Rejistro.CPostal = RejistroNudo.SelectSingleNode("C_CPostal").InnerText.ToString
    '        '        Rejistro.Poblacion = RejistroNudo.SelectSingleNode("C_Poblacion").InnerText.ToString
    '        '        Rejistro.Calle = RejistroNudo.SelectSingleNode("C_Calle").InnerText.ToString
    '        '        Rejistro.DireccionValida = RejistroNudo.SelectSingleNode("C_DireccionValida").InnerText.ToString
    '        '        Rejistro.Email = RejistroNudo.SelectSingleNode("C_Email").InnerText.ToString
    '        '        Rejistro.Telefonos = RejistroNudo.SelectSingleNode("C_Telefonos").InnerText.ToString
    '        '        Rejistro.Provincia = RejistroNudo.SelectSingleNode("C_Provincia").InnerText.ToString
    '        '        Rejistro.Pais = RejistroNudo.SelectSingleNode("C_Pais").InnerText.ToString
    '        '        RejistroLista.Add(Rejistro)
    '        '    End If

    '        'Next



    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    Return RejistroLista
    'End Function


    Friend Shared Function GetAll_Errores() As Boolean
        Dim Lista As Boolean = False
        Dim Rejistro As New ClassArchivo_Datos(0, "", "", "", "", False)
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        Try
            For Each Rejistro_Nudo As XmlNode In Nudo.ChildNodes
                Rejistro.Id = Rejistro_Nudo.SelectSingleNode("C_Id").InnerText
                Rejistro.Nombre = Rejistro_Nudo.SelectSingleNode("C_Nombre").InnerText
                Rejistro.Valor = Rejistro_Nudo.SelectSingleNode("C_Key").InnerText
                Rejistro.Descripcion = Rejistro_Nudo.SelectSingleNode("C_Desc").InnerText
                Rejistro.Tematica = Rejistro_Nudo.SelectSingleNode("C_Tematica").InnerText
                Rejistro.Activo = Rejistro_Nudo.SelectSingleNode("C_Activo").InnerText
            Next
        Catch ex As Exception
            Lista = True
            MsgBox(ex.Message)

        End Try
        Return Lista
    End Function



    Friend Shared Function ObtenerTodos() As List(Of ClassArchivo_Datos)
        Dim Lista As New List(Of ClassArchivo_Datos)
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        Try
            For Each Rejistro_Nudo As XmlNode In Nudo.ChildNodes
                Dim Rejistro As New ClassArchivo_Datos(Rejistro_Nudo.SelectSingleNode("C_Id").InnerText,
                    Rejistro_Nudo.SelectSingleNode("C_Name").InnerText,
                    Rejistro_Nudo.SelectSingleNode("C_Key").InnerText,
                    Rejistro_Nudo.SelectSingleNode("C_Desc").InnerText,
                    Rejistro_Nudo.SelectSingleNode("C_Tematica").InnerText,
                    Rejistro_Nudo.SelectSingleNode("C_Activo").InnerText)

                Lista.Add(Rejistro)

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Lista
    End Function
    Friend Shared Function ExisteId(ByVal Id As String) As Boolean
        Dim Existe As Boolean = False
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        Try
            For Each Rejistro1 As XmlNode In Nudo.ChildNodes
                Dim Comparador As String = Rejistro1.SelectSingleNode("C_Id").InnerText
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
    Friend Shared Function Existe_Nombre(ByVal Valor As String) As Boolean
        Dim Existe As Boolean = False
        Dim ValorSelectivo As String = Valor.ToString.Trim.ToUpper
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        Try
            For Each Rejistro1 As XmlNode In Nudo.ChildNodes
                Dim Comparador As String = Rejistro1.SelectSingleNode("C_Name").InnerText
                If Comparador.ToString.Trim.ToUpper = ValorSelectivo Then
                    Existe = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Existe
    End Function
    Friend Shared Function Existe_Valor(ByVal Valor As String) As Boolean
        Dim Existe As Boolean = False
        Dim ValorSelectivo As String = Valor.ToString.Trim.ToUpper
        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim Nudo As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
        Try
            For Each Rejistro1 As XmlNode In Nudo.ChildNodes
                Dim Comparador As String = Rejistro1.SelectSingleNode("C_Key").InnerText
                If Comparador.ToString.Trim.ToUpper = ValorSelectivo Then
                    Existe = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Existe
    End Function


    Friend Shared Function InsertarRejistro(ByVal Archivo_Envio As ClassArchivo_Datos)
        Dim Datos1 As New List(Of ClassArchivo_Datos)

        Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(RutaXMLConfigPrintInt)
        Dim NudoTabla As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)

        Try
            Dim NuevoNudo As XmlNode = xmlDoc.CreateElement("R_Data")
            NuevoNudo.AppendChild(xmlDoc.CreateTextNode(""))

            Dim NuevoNudoC_Id As XmlNode = xmlDoc.CreateElement("C_Id")
            NuevoNudoC_Id.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Id.ToString))
            NuevoNudo.AppendChild(NuevoNudoC_Id)
            '------------------
            Dim NuevoNudoC_Nombre As XmlNode = xmlDoc.CreateElement("C_Name")
            NuevoNudoC_Nombre.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Nombre))
            NuevoNudo.AppendChild(NuevoNudoC_Nombre)
            '------------------
            Dim NuevoNudoC_Fechanacimiento As XmlNode = xmlDoc.CreateElement("C_Key")
            NuevoNudoC_Fechanacimiento.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Valor))
            NuevoNudo.AppendChild(NuevoNudoC_Fechanacimiento)
            '------------------
            Dim NuevoNudoC_Direccion As XmlNode = xmlDoc.CreateElement("C_Desc")
            NuevoNudoC_Direccion.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Descripcion))
            NuevoNudo.AppendChild(NuevoNudoC_Direccion)
            '------------------
            Dim NuevoNudoC_Telefono As XmlNode = xmlDoc.CreateElement("C_Tematica")
            NuevoNudoC_Telefono.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Tematica))
            NuevoNudo.AppendChild(NuevoNudoC_Telefono)
            '------------------
            Dim NuevoNudoC_Activo As XmlNode = xmlDoc.CreateElement("C_Activo")
            NuevoNudoC_Activo.AppendChild(xmlDoc.CreateTextNode(Archivo_Envio.Activo))
            NuevoNudo.AppendChild(NuevoNudoC_Activo)
            '------------------

            NudoTabla.AppendChild(NuevoNudo)

            xmlDoc.Save(RutaXMLConfigPrintInt)
            '   Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            ObtenerTodos()
            My.Application.DoEvents()
            Module_Central.CopasSeguridad(Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo)

        Catch ex As Exception
            MsgBox("" & vbCr & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try

        Return Datos1
    End Function

    Friend Shared Function ModificarRejistro(ByVal Valor_Id As String, ByVal Columnas As ClassArchivo_Datos) As Boolean
        Dim Guardado As Boolean = False
        Try
            Dim xmlDoc As New XmlDocument
            Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
            xmlDoc.Load(RutaXMLConfigPrintInt)
            Dim CuerpoXL_1 As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
            For Each Rejistros As XmlNode In CuerpoXL_1
                Dim Comparador As String = Rejistros.SelectSingleNode("C_Id").InnerText
                If Comparador = Valor_Id Then
                    Rejistros.SelectSingleNode("C_Id").InnerText = Columnas.Id
                    Rejistros.SelectSingleNode("C_Name").InnerText = Columnas.Nombre
                    Rejistros.SelectSingleNode("C_Key").InnerText = Columnas.Valor
                    Rejistros.SelectSingleNode("C_Desc").InnerText = Columnas.Descripcion
                    Rejistros.SelectSingleNode("C_Tematica").InnerText = Columnas.Tematica
                    Rejistros.SelectSingleNode("C_Activo").InnerText = Columnas.Activo
                    xmlDoc.Save(RutaXMLConfigPrintInt)
                    Guardado = True
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            ObtenerTodos()
            My.Application.DoEvents()
            Module_Central.CopasSeguridad(Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo)

        Catch ex As Exception
            MsgBox("" & vbCr & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
        Return Guardado
    End Function

    Friend Shared Function Update_Desc(ByVal Valor_Id As String, ByVal C_Descripcion As String) As Boolean
        Dim Guardado As Boolean = False
        Try
            Dim xmlDoc As New XmlDocument
            Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
            xmlDoc.Load(RutaXMLConfigPrintInt)
            Dim CuerpoXL_1 As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
            For Each Rejistros As XmlNode In CuerpoXL_1
                Dim Comparador As String = Rejistros.SelectSingleNode("C_Id").InnerText
                If Comparador = Valor_Id Then
                    Rejistros.SelectSingleNode("C_Desc").InnerText = C_Descripcion
                    xmlDoc.Save(RutaXMLConfigPrintInt)
                    Guardado = True
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            ObtenerTodos()
            My.Application.DoEvents()
            Module_Central.CopasSeguridad(Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo)
        Catch ex As Exception
            MsgBox("" & vbCr & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
        Return Guardado
    End Function


    Friend Shared Function EliminarRejistro0(ByVal ByVal_Id As String) As Boolean
        Dim Guardado As Boolean = False
        Try
            Dim xmlDoc As New XmlDocument
            Dim RutaXMLConfigPrintInt As String = Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo
            xmlDoc.Load(RutaXMLConfigPrintInt)

            Dim CuerpoXL_1 As XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
            Dim Cuerpo_Cliente As XmlNode = CuerpoXL_1.SelectSingleNode("R_Data")

            For Each Rejistros As XmlNode In CuerpoXL_1
                Dim Comparador As String = Rejistros.SelectSingleNode("C_Id").InnerText
                If Comparador = ByVal_Id Then
                    CuerpoXL_1.RemoveChild(Rejistros)
                    xmlDoc.Save(RutaXMLConfigPrintInt)
                    Guardado = True
                End If
            Next


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            ObtenerTodos()
            My.Application.DoEvents()
            Module_Central.CopasSeguridad(Class_Configuraciones.RutaDatos_Obtener().ToString & Archivo)

        Catch ex As Exception
            MsgBox("" & vbCr & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
        Return Guardado
    End Function



    Friend Class ClassArchivo_Datos

        '<?xml version="1.0" encoding="iso-8859-15" ?>
        '<body>
        '    <R_Data>
        '    <C_Id></C_Id>
        '    <C_Name></C_Name>
        '    <C_Key></C_Key>
        '    <C_Desc></C_Desc>
        '    <C_Tematica></C_Tematica>
        '    <C_Activo></C_Activo>
        '  </R_Data>
        '</body>
        Friend Sub New(ByVal C_Id As Integer, ByVal C_Nombre As String, ByVal C_Valor As String,
               ByVal C_Desc As String, ByVal C_Tematica As String, ByVal C_Activo As Boolean)
            Try
                Me.Id = C_Id
            Catch ex As Exception
                Me.Id = "-- --"
            End Try
            Try
                Me.Nombre = C_Nombre
            Catch ex As Exception
                Me.Nombre = "-- --"
            End Try
            Try
                Me.Valor = C_Valor
            Catch ex As Exception
                Me.Valor = "-- --"
            End Try
            Try
                Me.Descripcion = C_Desc
            Catch ex As Exception
                Me.Descripcion = "-- --"
            End Try
            Try
                Me.Tematica = C_Tematica
            Catch ex As Exception
                Me.Tematica = "-- --"
            End Try
            Try
                Me.Activo = C_Activo
            Catch ex As Exception
                Me.Activo = "-- --"
            End Try
        End Sub

        Private m_Id As Integer
        Private m_Nombre As String
        Private m_Valor As String
        Private m_Descripcion As String
        Private m_Tematica As String
        Private m_Activo As Boolean

        Friend Property Id() As Integer
            Get
                Return m_Id
            End Get
            Set(value As Integer)
                m_Id = value
            End Set
        End Property
        Friend Property Nombre() As String
            Get
                Return m_Nombre
            End Get
            Set(value As String)
                m_Nombre = value
            End Set
        End Property
        Friend Property Valor() As String
            Get
                Return m_Valor
            End Get
            Set(value As String)
                m_Valor = value
            End Set
        End Property
        Friend Property Descripcion() As String
            Get
                Return m_Descripcion
            End Get
            Set(value As String)
                m_Descripcion = value
            End Set
        End Property
        Friend Property Tematica() As String
            Get
                Return m_Tematica
            End Get
            Set(value As String)
                m_Tematica = value
            End Set
        End Property
        Friend Property Activo() As Boolean
            Get
                Return m_Activo
            End Get
            Set(value As Boolean)
                m_Activo = value
            End Set
        End Property

    End Class




End Class



