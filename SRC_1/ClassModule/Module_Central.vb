Imports System.IO
#Disable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'WA_FacturaHotel_2017' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.
Imports WA_FacturaHotel_2017
#Enable Warning BC40056 ' El espacio de nombres o el tipo especificado en el 'WA_FacturaHotel_2017' Imports no contienen ningún miembro público o no se encuentran. Asegúrese de que el espacio de nombres o el tipo se hayan definido y de que contengan al menos un miembro público. Asegúrese de que el nombre del elemento importado no use ningún alias.

Module Module_Central

    'Dim FormularioFactura As Form_Factura
    'Dim FormularioClienteLista As Form_ClientesLista
    'Dim FormularioClienteAdd As Form_ClienteEditar

    Friend Event ClienteModificados() 'As 

#Region "Clientes"

    'Friend Function TransferirEmpresa(ByVal ArchivoEmpresa As Class_Empresas.Archivo_Empresa) As Boolean
    '    Dim tranferido As Boolean = False
    '    'For Each f As Form In Application.OpenForms
    '    '    If f.Name = _form.Name Then
    '    '        Return f
    '    '    End If
    '    'Next

    '    For Each f As Form In Application.OpenForms
    '        If f.Name = Form_FacturaGrande.Name Then
    '            'Return f
    '            Form_FacturaGrande.TransferirDatosEmpresa(ArchivoEmpresa)
    '            tranferido = True
    '        End If
    '    Next

    '    'Dim existe As Form = Application.OpenForms.OfType(Of Form)().Where(Function(pre) pre.Name = "frmName").SingleOrDefault(Of Form)()
    '    'If existe IsNot Nothing Then
    '    '    MessageBox.Show("El Formulario 2 esta abierto")
    '    'End If
    '    'Dim existe As Form = Application.OpenForms.OfType(Of Form)().Where(Function(pre) pre.Name = "Form_ReparacionesAgregar")
    '    'If existe IsNot Nothing Then
    '    '    MessageBox.Show("El Formulario 2 esta abierto")
    '    'End If

    '    Return tranferido
    'End Function

    'Friend Function TransferirEmpresaMod(ByVal ArchivoReparacion As Class_Empresas.Archivo_Empresa) As Boolean
    '    Dim tranferido As Boolean = False

    '    For Each f As Form In Application.OpenForms
    '        If f.Name = Form_EmpresaEditar.Name Then
    '            Form_EmpresaEditar.TransferirDatosCliente(ArchivoReparacion)
    '            tranferido = True
    '        End If
    '    Next
    '    If tranferido = False Then
    '        Form_EmpresaEditar.Show()
    '        For Each f As Form In Application.OpenForms
    '            If f.Name = Form_EmpresaEditar.Name Then
    '                Form_EmpresaEditar.TransferirDatosCliente(ArchivoReparacion)
    '                tranferido = True
    '            End If
    '        Next
    '    End If
    '    Return tranferido
    'End Function

    'Friend Function TransferirEmpresaEliminar(ByVal ArchivoCliente As Class_Empresas.Archivo_Empresa) As Boolean
    '    Dim tranferido As Boolean = False

    '    For Each f As Form In Application.OpenForms
    '        If f.Name = Form_EmpresaEliminar.Name Then
    '            Form_EmpresaEliminar.TransferirDatosEmpresa(ArchivoCliente)
    '            tranferido = True
    '        End If
    '    Next
    '    If tranferido = False Then
    '        Form_EmpresaEliminar.Show()
    '        For Each f As Form In Application.OpenForms
    '            If f.Name = Form_EmpresaEliminar.Name Then
    '                Form_EmpresaEliminar.TransferirDatosEmpresa(ArchivoCliente)
    '                tranferido = True
    '            End If
    '        Next
    '    End If
    '    Return tranferido
    'End Function

    'Friend Function TransferirCliente(ByVal ArchivoCliente As Class_Cientes.Archivo_Clientes) As Boolean
    '    Dim tranferido As Boolean = False
    '    'For Each f As Form In Application.OpenForms
    '    '    If f.Name = _form.Name Then
    '    '        Return f
    '    '    End If
    '    'Next

    '    For Each f As Form In Application.OpenForms
    '        If f.Name = Form_FacturaGrande.Name Then
    '            'Return f
    '            Form_FacturaGrande.TransferirDatosCliente(ArchivoCliente)
    '            tranferido = True
    '        End If
    '    Next

    '    'Dim existe As Form = Application.OpenForms.OfType(Of Form)().Where(Function(pre) pre.Name = "frmName").SingleOrDefault(Of Form)()
    '    'If existe IsNot Nothing Then
    '    '    MessageBox.Show("El Formulario 2 esta abierto")
    '    'End If
    '    'Dim existe As Form = Application.OpenForms.OfType(Of Form)().Where(Function(pre) pre.Name = "Form_ReparacionesAgregar")
    '    'If existe IsNot Nothing Then
    '    '    MessageBox.Show("El Formulario 2 esta abierto")
    '    'End If

    '    Return tranferido
    'End Function

    'Friend Function TransferirFactura(ByVal archivo As Class_Factura.Archivo_Factura) As Boolean
    '    Dim tranferido As Boolean = False

    '    For Each f As Form In Application.OpenForms
    '        If f.Name = Form_FacturaGrande.Name Then
    '            If MessageBox.Show("Hay una factura abierta" & vbCrLf & " si continua los datos no guardados se perderan " & vbCrLf & " ¿Desea continuar y abrir la factura seleccionada? ", "Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
    '                Form_FacturaGrande.Close()
    '                Threading.Thread.Sleep(100)
    '                Form_FacturaGrande.Show()
    '                Threading.Thread.Sleep(100)
    '            End If
    '            Form_FacturaGrande.TransferirDatosFactura(archivo)
    '            tranferido = True
    '            Exit For
    '        End If
    '    Next
    '    If tranferido = False Then
    '        Form_FacturaGrande.Show()
    '        For Each f As Form In Application.OpenForms
    '            Threading.Thread.Sleep(700)
    '            If f.Name = Form_FacturaGrande.Name Then
    '                Form_FacturaGrande.TransferirDatosFactura(archivo)
    '                tranferido = True
    '                Exit For
    '            End If
    '        Next
    '    End If
    '    Return tranferido
    'End Function

    'Friend Function TransferirClienteMod(ByVal ArchivoReparacion As Class_Cientes.Archivo_Clientes) As Boolean
    '    Dim tranferido As Boolean = False

    '    For Each f As Form In Application.OpenForms
    '        If f.Name = Form_ClienteEditar.Name Then
    '            Form_ClienteEditar.TransferirDatosCliente(ArchivoReparacion)
    '            tranferido = True
    '        End If
    '    Next
    '    If tranferido = False Then
    '        Form_ClienteEditar.Show()
    '        For Each f As Form In Application.OpenForms
    '            If f.Name = Form_ClienteEditar.Name Then
    '                Form_ClienteEditar.TransferirDatosCliente(ArchivoReparacion)
    '                tranferido = True
    '            End If
    '        Next
    '    End If
    '    Return tranferido
    'End Function

    'Friend Function TransferirClienteEliminar(ByVal ArchivoCliente As Class_Cientes.Archivo_Clientes) As Boolean
    '    Dim tranferido As Boolean = False

    '    For Each f As Form In Application.OpenForms
    '        If f.Name = Form_ClienteEliminar.Name Then
    '            Form_ClienteEliminar.TransferirDatosCliente(ArchivoCliente)
    '            tranferido = True
    '        End If
    '    Next
    '    If tranferido = False Then
    '        Form_ClienteEliminar.Show()
    '        For Each f As Form In Application.OpenForms
    '            If f.Name = Form_ClienteEliminar.Name Then
    '                Form_ClienteEliminar.TransferirDatosCliente(ArchivoCliente)
    '                tranferido = True
    '            End If
    '        Next
    '    End If
    '    Return tranferido
    'End Function

    'Friend Function ImportarClienteNif(ByVal ArchivoCliente As Class_Cientes.Archivo_Clientes) As Boolean
    '    Dim tranferido As Boolean = False

    '    For Each f As Form In Application.OpenForms
    '        If f.Name = Form_ClienteEditar.Name Then
    '            Form_ClienteEditar.TransferirDatosClienteDNI(ArchivoCliente)
    '            tranferido = True
    '        End If
    '    Next
    '    If tranferido = False Then
    '        Form_ClienteEditar.Show()
    '        For Each f As Form In Application.OpenForms
    '            If f.Name = Form_ClienteEditar.Name Then
    '                Form_ClienteEditar.TransferirDatosClienteDNI(ArchivoCliente)
    '                tranferido = True
    '            End If
    '        Next
    '    End If
    '    Return tranferido
    'End Function

    'Friend Function ImportarEmpredaNif(ByVal ArchivoCliente As Class_Empresas.Archivo_Empresa) As Boolean
    '    Dim tranferido As Boolean = False

    '    For Each f As Form In Application.OpenForms
    '        If f.Name = Form_EmpresaEditar.Name Then
    '            Form_EmpresaEditar.TransferirDatosClienteNIF(ArchivoCliente)
    '            tranferido = True
    '        End If
    '    Next
    '    If tranferido = False Then
    '        Form_EmpresaEditar.Show()
    '        For Each f As Form In Application.OpenForms
    '            If f.Name = Form_EmpresaEditar.Name Then
    '                Form_EmpresaEditar.TransferirDatosClienteNIF(ArchivoCliente)
    '                tranferido = True
    '            End If
    '        Next
    '    End If
    '    Return tranferido
    'End Function

#End Region


#Region "Reparaciones"
    'Friend Function TransferirReparacionMod(ByVal ArchivoReparacion As Class_Reparaciones.Archivo_Reparaciones) As Boolean
    '    Dim tranferido As Boolean = False

    '    For Each f As Form In Application.OpenForms
    '        If f.Name = Form_ReparacionesAgregar.Name Then
    '            Form_ReparacionesAgregar.TransferirDatosReparacion(ArchivoReparacion)
    '            tranferido = True
    '        End If
    '    Next
    '    If tranferido = False Then
    '        Form_ReparacionesAgregar.Show()
    '        For Each f As Form In Application.OpenForms
    '            If f.Name = Form_ReparacionesAgregar.Name Then
    '                Form_ReparacionesAgregar.TransferirDatosReparacion(ArchivoReparacion)
    '                tranferido = True
    '            End If
    '        Next
    '    End If
    '    Return tranferido
    'End Function


    'Friend Function TransferirReparacionEliminar(ByVal ArchivoReparacion As Class_Reparaciones.Archivo_Reparaciones) As Boolean
    '    Dim tranferido As Boolean = False

    '    For Each f As Form In Application.OpenForms
    '        If f.Name = Form_ReparacionEliminar.Name Then
    '            Form_ReparacionEliminar.TransferirDatosReparacion(ArchivoReparacion)
    '            tranferido = True
    '        End If
    '    Next
    '    If tranferido = False Then
    '        Form_ReparacionEliminar.Show()
    '        For Each f As Form In Application.OpenForms
    '            If f.Name = Form_ReparacionEliminar.Name Then
    '                Form_ReparacionEliminar.TransferirDatosReparacion(ArchivoReparacion)
    '                tranferido = True
    '            End If
    '        Next
    '    End If
    '    Return tranferido
    'End Function



#End Region

#Region "CopiasSeguridad"

    Friend Sub CopasSeguridad(ByVal Archivo As String)
        Try
            If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath.ToString & "\BaseDatos") = False Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath.ToString & "\BaseDatos")
            End If
            If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath.ToString & "\BaseDatos\Copias") = False Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath.ToString & "\BaseDatos\Copias")
            End If
            If My.Computer.FileSystem.FileExists(Archivo) = False Then
                MsgBox("No se encuentra la base de datos de origen", MsgBoxStyle.Critical)
                Exit Try
            End If
            Try
                Dim xmlDoc As New System.Xml.XmlDocument
                xmlDoc.Load(Archivo)
                Dim Nudo As System.Xml.XmlNode = xmlDoc.GetElementsByTagName("body").Item(0)
                Dim Cuenta As Integer = Nudo.ChildNodes.Count
            Catch ex As Exception
                MsgBox("el archivo de origen no es legible", MsgBoxStyle.Critical)
                Exit Try
            End Try

            Dim fileData As FileInfo = My.Computer.FileSystem.GetFileInfo(Archivo)
            My.Computer.FileSystem.CopyFile(Archivo, My.Application.Info.DirectoryPath.ToString & "\BaseDatos\Copias\" & fileData.Name)



        Catch ex As Exception

        End Try
    End Sub


#End Region


End Module
