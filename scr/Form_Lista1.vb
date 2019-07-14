Public Class Form_Lista1

    Private Sub Form_Lista1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Label_IDSeleccionada.Text = ""
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label_Contraseña_Click(sender As Object, e As EventArgs) Handles Label_Contraseña.Click
        Try
            Class_Encriptar.Main()
            ActulizaFormularioActivos()
            Limpiar()
        Catch ex As Exception

        End Try
    End Sub

    Private Function Desencriptar(ByVal Datos As String) As String
        Return Class_Encriptar.desencriptar128BitRijndael(Datos, TextBox_Contraseña.Text.ToString.Trim)
    End Function
    Private Function Encriptar(ByVal Datos As String) As String
        Return Class_Encriptar.encriptar128BitRijndael(Datos, TextBox_Contraseña.Text.ToString.Trim)
    End Function

    Private Sub ActulizaFormularioActivos()
        Try
            DataGridView_TablaValores.Rows.Clear()

            If CheckBox_MostrarActivos.Checked = True Then
                With Class_Datos.ObtenerWhereActivos(CheckBox_Activo.Checked)
                    For Indice As Integer = 0 To (.Count - 1)
                        DataGridView_TablaValores.Rows.Add(.Item(Indice).Id, Desencriptar(.Item(Indice).Nombre.Trim), Desencriptar(.Item(Indice).Valor.Trim),
                                                      Desencriptar(.Item(Indice).Descripcion), Desencriptar(.Item(Indice).Tematica.Trim), .Item(Indice).Activo)


                    Next
                End With
            Else
                With Class_Datos.ObtenerTodos
                    For Indice As Integer = 0 To (.Count - 1)
                        DataGridView_TablaValores.Rows.Add(.Item(Indice).Id, Desencriptar(.Item(Indice).Nombre.Trim), Desencriptar(.Item(Indice).Valor.Trim),
                                                      Desencriptar(.Item(Indice).Descripcion), Desencriptar(.Item(Indice).Tematica.Trim), .Item(Indice).Activo)


                    Next
                End With
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Limpiar()
        Try

            TextBox_Id.Text = ""
            TextBox_Descripcion.Text = ""
            TextBox_Nombre.Text = ""
            TextBox_Valor.Text = ""
            TextBox_Tematica.Text = ""
            CheckBox_Activo.Checked = True
            Label_IDSeleccionada.Text = ""


            Button_Eliminar.Text = "Eliminar"

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Tabla_SociosDataGridView_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView_TablaValores.CellContentClick

    End Sub

    Private Sub Tabla_ClientesDataGridView_RowHeaderMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView_TablaValores.RowHeaderMouseClick
        Limpiar()
        Try
            Me.DataGridView_TablaValores.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Me.DataGridView_TablaValores.Rows(e.RowIndex).Selected = True
            Try
                RichTextBox_Sucesos.Text &= "Seleccionado = " & CStr(DataGridView_TablaValores("C_Id", e.RowIndex).Value).ToString & vbCrLf
            Catch ex As Exception

            End Try
            Try
                TextBox_Id.Text = CStr(DataGridView_TablaValores("C_Id", e.RowIndex).Value).ToString
                TextBox_Nombre.Text = CStr(DataGridView_TablaValores("C_Nombre", e.RowIndex).Value).ToString
                TextBox_Valor.Text = CStr(DataGridView_TablaValores("C_Valor", e.RowIndex).Value).ToString
                TextBox_Tematica.Text = CStr(DataGridView_TablaValores("C_Temperatura", e.RowIndex).Value).ToString
                TextBox_Descripcion.Text = CStr(DataGridView_TablaValores("C_Descripcion", e.RowIndex).Value).ToString
                CheckBox_Activo.Checked = CBool(DataGridView_TablaValores("C_Activo", e.RowIndex).Value)
                Label_IDSeleccionada.Text = TextBox_Id.Text
            Catch ex As Exception
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Button_Agregar_Click(sender As System.Object, e As System.EventArgs) Handles Button_Agregar.Click
        Try



            If Label_IDSeleccionada.Text <> "" Then
                Dim MsgResponse As MsgBoxResult
                MsgResponse = MsgBox(" Hay un elemento seleccionado " & vbCr & " ¿ desea agregar un nuevo elemento ? ", MsgBoxStyle.YesNo)
                If MsgResponse = MsgBoxResult.Yes Then
                    Label_IDSeleccionada.Text = ""
                Else
                    MsgBox(" Pulse el boton guardar para acutulizar los datos ")
                    Exit Sub
                End If
            End If


            If Class_Datos.Existe_Nombre(TextBox_Nombre.Text.Trim) Then
                Dim MsgResponse As MsgBoxResult
                MsgResponse = MsgBox(" El nombre ya se encuentra en la lista " & vbCr & " ¿ desea agregarlo ? ", MsgBoxStyle.YesNo)
                If MsgResponse = MsgBoxResult.Yes Then

                Else
                    Exit Sub
                End If
            End If

            Dim ContadorRejistros As Integer = Class_Contadores.ObtenerWhereContador("Datos").Cuenta + 1
            If Class_Datos.ExisteId(ContadorRejistros) Then
                RichTextBox_Sucesos.Text &= "Ya existe el material  = " & ContadorRejistros & vbCrLf
                MsgBox("El id del contador ya existe" & vbCr & "puede modificarlo para poder agregar", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim RejistroNuevo As New Class_Datos.ClassArchivo_Datos(ContadorRejistros, Encriptar(TextBox_Nombre.Text.Trim),
                                   Encriptar(TextBox_Valor.Text.Trim), Encriptar(TextBox_Tematica.Text.Trim), Encriptar(TextBox_Descripcion.Text.Trim), CheckBox_Activo.Checked)

            Class_Datos.InsertarRejistro(RejistroNuevo)
            If Class_Datos.ExisteId(ContadorRejistros) Then
                Class_Contadores.ModificarRejistro("Datos", ContadorRejistros) '.Item(0).Cuenta
                Label_IDSeleccionada.Text = ContadorRejistros
                RichTextBox_Sucesos.Text &= "Agregado nuevo = " & ContadorRejistros & vbCrLf
            Else
                RichTextBox_Sucesos.Text &= "Error al agregar = " & ContadorRejistros & vbCrLf
            End If

            ActulizaFormularioActivos()
            DataGridView_TablaValores.ClearSelection()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button_Guardar_Click(sender As System.Object, e As System.EventArgs) Handles Button_Guardar.Click
        Dim IsSocioSelec As Integer
        Try

            If (Label_IDSeleccionada.Text.ToString.Trim <> "") Then
                IsSocioSelec = CInt(Label_IDSeleccionada.Text)
                If Class_Datos.ExisteId(IsSocioSelec) = False Then
                    MsgBox("El id. seleccionado no es valido", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            Else
                MsgBox("no hay un id seleccionado")
            End If

        Catch ex As Exception
            MsgBox("El id. " & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
            Exit Sub
        End Try
        Try

            Dim SocioTemp As New Class_Datos.ClassArchivo_Datos(IsSocioSelec, Encriptar(TextBox_Nombre.Text.Trim),
                                     Encriptar(TextBox_Valor.Text.Trim), Encriptar(TextBox_Tematica.Text.Trim), Encriptar(TextBox_Descripcion.Text.Trim), CheckBox_Activo.Checked)

            Class_Datos.ModificarRejistro(IsSocioSelec, SocioTemp)


            RichTextBox_Sucesos.Text &= "Guardado = " & Label_IDSeleccionada.Text & vbCrLf
            ActulizaFormularioActivos()
            DataGridView_TablaValores.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Button_Eliminar_Click(sender As System.Object, e As System.EventArgs) Handles Button_Eliminar.Click
        Try


            If Class_Datos.ExisteId(Label_IDSeleccionada.Text) = False Then
                MsgBox(" El Id. seleccionado no ne encuentra  ", MsgBoxStyle.Information)
            End If

            If Button_Eliminar.Text = "Eliminar" Then


                Dim MsgResponse As MsgBoxResult
                MsgResponse = MsgBox(" vuelva a presionar para eliminar " & vbCr & " ¿ continuar ? ", MsgBoxStyle.YesNo)
                If MsgResponse = MsgBoxResult.Yes Then
                    Button_Eliminar.Text = "Aceptar eliminar"
                End If

            Else
                Button_Eliminar.Text = "Eliminar"
                Class_Datos.EliminarRejistro0(Label_IDSeleccionada.Text.Trim)
                RichTextBox_Sucesos.Text &= "Eliminado = " & Label_IDSeleccionada.Text & vbCrLf
                ActulizaFormularioActivos()
                DataGridView_TablaValores.ClearSelection()
            End If
            ActulizaFormularioActivos()
            DataGridView_TablaValores.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button_LimpiarCampos_Click(sender As Object, e As EventArgs) Handles Button_LimpiarCampos.Click
        Try
            Limpiar()
            Button_Eliminar.Text = "Eliminar"
            RichTextBox_Sucesos.Text = ""
            ActulizaFormularioActivos()
        Catch ex As Exception

        End Try
    End Sub

End Class
