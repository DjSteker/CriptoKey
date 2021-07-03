Public Class Form_Lista

    Private Sub Form_Lista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Label_Id.Visible = False
            TextBox_Id.Visible = False
            GroupBox_Datos.Text = "Añadir"
            Me.Text = "Editar empresa"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_Guardar_Click(sender As Object, e As EventArgs) Handles Button_Guardar.Click
        Dim RejistroCliente As New Class_Empresas.Archivo_Empresa()
        Try
            Me.Validate()


            RejistroCliente.Nombre = TextBox_Nombre.Text.ToString.Trim
            RejistroCliente.CIF = TextBox_Nif.Text.ToString.Trim
            RejistroCliente.Email = TextBox_Email.Text.ToString.Trim
            RejistroCliente.Telefonos = TextBox_Telefono.Text.ToString.Trim
            RejistroCliente.Calle = TextBox_Calle.Text.ToString.Trim
            RejistroCliente.Poblacion = TextBox_Poblacion.Text.ToString.Trim
            RejistroCliente.CPostal = TextBox_CodigoPostal.Text.ToString.Trim
            RejistroCliente.Provincia = TextBox_Provincia.Text.ToString.Trim
            RejistroCliente.Pais = TextBox_Pais.Text.ToString.Trim





            If TextBox_Id.Visible = False Then
                Dim IdCuenta As Long = (Class_Contadores.ObtenerWhereContador("ContadorEmpresas").Cuenta) + 1
                If Class_Empresas.ExisteId(IdCuenta) Then
                    MsgBox("Error, existe el identificador. " & IdCuenta & vbCr & " Para corregirlo cambie el contador de las empresas o vuelva a intentarlo")
                    Exit Sub
                End If
                RejistroCliente.Id = IdCuenta
                Class_Empresas.InsertarRejistro(RejistroCliente)
                Class_Contadores.ModificarRejistro("ContadorEmpresas", IdCuenta)
                Button_Cancelar.Text = "Cerrar"


            Else
                RejistroCliente.Id = TextBox_Id.Text.ToString.Trim
                Class_Empresas.ModificarRejistro(TextBox_Id.Text.ToString.Trim, RejistroCliente)
                Button_Cancelar.Text = "Cerrar"
                TextBox_Id.Enabled = False
            End If

            If Class_Empresas.ExisteId(RejistroCliente.Id) Then
                TextBox_Id.Text = RejistroCliente.Id.ToString
                TextBox_Id.Visible = True
                GroupBox_Datos.Text = "Modificar"
                TextBox_Id.Enabled = False
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            If TranferirAFactura = True Then
                TransferirEmpresa(RejistroCliente)
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_Cancelar_Click(sender As Object, e As EventArgs) Handles Button_Cancelar.Click

    End Sub

End Class
