<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_Lista1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBox_OcultarContraseña = New System.Windows.Forms.CheckBox()
        Me.Button_InicioContraseña = New System.Windows.Forms.Button()
        Me.TextBox_Contraseña = New System.Windows.Forms.TextBox()
        Me.Label_Contraseña = New System.Windows.Forms.Label()
        Me.CheckBox_MostrarActivos = New System.Windows.Forms.CheckBox()
        Me.Label_Tematica = New System.Windows.Forms.Label()
        Me.Button_LimpiarCampos = New System.Windows.Forms.Button()
        Me.RichTextBox_Sucesos = New System.Windows.Forms.RichTextBox()
        Me.Button_Eliminar = New System.Windows.Forms.Button()
        Me.Button_Guardar = New System.Windows.Forms.Button()
        Me.Button_Agregar = New System.Windows.Forms.Button()
        Me.CheckBox_Activo = New System.Windows.Forms.CheckBox()
        Me.TextBox_Descripcion = New System.Windows.Forms.TextBox()
        Me.Label_Descripcion = New System.Windows.Forms.Label()
        Me.TextBox_Valor = New System.Windows.Forms.TextBox()
        Me.Label_Valor = New System.Windows.Forms.Label()
        Me.TextBox_Nombre = New System.Windows.Forms.TextBox()
        Me.Label_Nombre = New System.Windows.Forms.Label()
        Me.Label_Id = New System.Windows.Forms.Label()
        Me.TextBox_Id = New System.Windows.Forms.TextBox()
        Me.DataGridView_TablaValores = New System.Windows.Forms.DataGridView()
        Me.C_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_Valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_Tematica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_Activo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label_IDSeleccionada = New System.Windows.Forms.Label()
        Me.ComboBox_Lenguaje = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Tematica = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView_TablaValores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox_OcultarContraseña)
        Me.GroupBox1.Controls.Add(Me.Button_InicioContraseña)
        Me.GroupBox1.Controls.Add(Me.TextBox_Contraseña)
        Me.GroupBox1.Controls.Add(Me.Label_Contraseña)
        Me.GroupBox1.Location = New System.Drawing.Point(31, 474)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(458, 75)
        Me.GroupBox1.TabIndex = 90
        Me.GroupBox1.TabStop = False
        '
        'CheckBox_OcultarContraseña
        '
        Me.CheckBox_OcultarContraseña.AutoSize = True
        Me.CheckBox_OcultarContraseña.Location = New System.Drawing.Point(329, 32)
        Me.CheckBox_OcultarContraseña.Name = "CheckBox_OcultarContraseña"
        Me.CheckBox_OcultarContraseña.Size = New System.Drawing.Size(116, 17)
        Me.CheckBox_OcultarContraseña.TabIndex = 1
        Me.CheckBox_OcultarContraseña.Text = "Ocultar contraseña"
        Me.CheckBox_OcultarContraseña.UseVisualStyleBackColor = True
        '
        'Button_InicioContraseña
        '
        Me.Button_InicioContraseña.Location = New System.Drawing.Point(273, 30)
        Me.Button_InicioContraseña.Name = "Button_InicioContraseña"
        Me.Button_InicioContraseña.Size = New System.Drawing.Size(49, 20)
        Me.Button_InicioContraseña.TabIndex = 3
        Me.Button_InicioContraseña.Text = "Iniciar"
        Me.Button_InicioContraseña.UseVisualStyleBackColor = True
        '
        'TextBox_Contraseña
        '
        Me.TextBox_Contraseña.Location = New System.Drawing.Point(79, 30)
        Me.TextBox_Contraseña.Name = "TextBox_Contraseña"
        Me.TextBox_Contraseña.Size = New System.Drawing.Size(187, 20)
        Me.TextBox_Contraseña.TabIndex = 2
        '
        'Label_Contraseña
        '
        Me.Label_Contraseña.AutoSize = True
        Me.Label_Contraseña.Location = New System.Drawing.Point(12, 33)
        Me.Label_Contraseña.Name = "Label_Contraseña"
        Me.Label_Contraseña.Size = New System.Drawing.Size(61, 13)
        Me.Label_Contraseña.TabIndex = 0
        Me.Label_Contraseña.Text = "Contraseña"
        '
        'CheckBox_MostrarActivos
        '
        Me.CheckBox_MostrarActivos.AutoSize = True
        Me.CheckBox_MostrarActivos.Checked = True
        Me.CheckBox_MostrarActivos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_MostrarActivos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CheckBox_MostrarActivos.Location = New System.Drawing.Point(673, 266)
        Me.CheckBox_MostrarActivos.Name = "CheckBox_MostrarActivos"
        Me.CheckBox_MostrarActivos.Size = New System.Drawing.Size(98, 17)
        Me.CheckBox_MostrarActivos.TabIndex = 15
        Me.CheckBox_MostrarActivos.Text = "Mostrar activos"
        Me.CheckBox_MostrarActivos.UseVisualStyleBackColor = True
        '
        'Label_Tematica
        '
        Me.Label_Tematica.Location = New System.Drawing.Point(40, 377)
        Me.Label_Tematica.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label_Tematica.Name = "Label_Tematica"
        Me.Label_Tematica.Size = New System.Drawing.Size(51, 13)
        Me.Label_Tematica.TabIndex = 87
        Me.Label_Tematica.Text = "Tematica"
        Me.Label_Tematica.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button_LimpiarCampos
        '
        Me.Button_LimpiarCampos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_LimpiarCampos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button_LimpiarCampos.Location = New System.Drawing.Point(777, 322)
        Me.Button_LimpiarCampos.Name = "Button_LimpiarCampos"
        Me.Button_LimpiarCampos.Size = New System.Drawing.Size(11, 23)
        Me.Button_LimpiarCampos.TabIndex = 13
        Me.Button_LimpiarCampos.Text = "Limpiar"
        Me.Button_LimpiarCampos.UseVisualStyleBackColor = True
        '
        'RichTextBox_Sucesos
        '
        Me.RichTextBox_Sucesos.Location = New System.Drawing.Point(417, 322)
        Me.RichTextBox_Sucesos.Name = "RichTextBox_Sucesos"
        Me.RichTextBox_Sucesos.Size = New System.Drawing.Size(354, 105)
        Me.RichTextBox_Sucesos.TabIndex = 85
        Me.RichTextBox_Sucesos.Text = ""
        '
        'Button_Eliminar
        '
        Me.Button_Eliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_Eliminar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button_Eliminar.Location = New System.Drawing.Point(657, 433)
        Me.Button_Eliminar.Name = "Button_Eliminar"
        Me.Button_Eliminar.Size = New System.Drawing.Size(114, 23)
        Me.Button_Eliminar.TabIndex = 12
        Me.Button_Eliminar.Text = "Eliminar"
        Me.Button_Eliminar.UseVisualStyleBackColor = True
        '
        'Button_Guardar
        '
        Me.Button_Guardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_Guardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button_Guardar.Location = New System.Drawing.Point(537, 433)
        Me.Button_Guardar.Name = "Button_Guardar"
        Me.Button_Guardar.Size = New System.Drawing.Size(114, 23)
        Me.Button_Guardar.TabIndex = 11
        Me.Button_Guardar.Text = "Guardar"
        Me.Button_Guardar.UseVisualStyleBackColor = True
        '
        'Button_Agregar
        '
        Me.Button_Agregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_Agregar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button_Agregar.Location = New System.Drawing.Point(417, 433)
        Me.Button_Agregar.Name = "Button_Agregar"
        Me.Button_Agregar.Size = New System.Drawing.Size(114, 23)
        Me.Button_Agregar.TabIndex = 10
        Me.Button_Agregar.Text = "Agregar"
        Me.Button_Agregar.UseVisualStyleBackColor = True
        '
        'CheckBox_Activo
        '
        Me.CheckBox_Activo.AutoSize = True
        Me.CheckBox_Activo.Checked = True
        Me.CheckBox_Activo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_Activo.Location = New System.Drawing.Point(281, 432)
        Me.CheckBox_Activo.Name = "CheckBox_Activo"
        Me.CheckBox_Activo.Size = New System.Drawing.Size(56, 17)
        Me.CheckBox_Activo.TabIndex = 9
        Me.CheckBox_Activo.Text = "Activo"
        Me.CheckBox_Activo.UseVisualStyleBackColor = True
        '
        'TextBox_Descripcion
        '
        Me.TextBox_Descripcion.Location = New System.Drawing.Point(102, 400)
        Me.TextBox_Descripcion.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBox_Descripcion.Multiline = True
        Me.TextBox_Descripcion.Name = "TextBox_Descripcion"
        Me.TextBox_Descripcion.Size = New System.Drawing.Size(173, 52)
        Me.TextBox_Descripcion.TabIndex = 8
        '
        'Label_Descripcion
        '
        Me.Label_Descripcion.Location = New System.Drawing.Point(28, 403)
        Me.Label_Descripcion.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label_Descripcion.Name = "Label_Descripcion"
        Me.Label_Descripcion.Size = New System.Drawing.Size(63, 13)
        Me.Label_Descripcion.TabIndex = 79
        Me.Label_Descripcion.Text = "Descripcion"
        Me.Label_Descripcion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox_Valor
        '
        Me.TextBox_Valor.Location = New System.Drawing.Point(102, 348)
        Me.TextBox_Valor.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBox_Valor.Name = "TextBox_Valor"
        Me.TextBox_Valor.Size = New System.Drawing.Size(173, 20)
        Me.TextBox_Valor.TabIndex = 6
        '
        'Label_Valor
        '
        Me.Label_Valor.Location = New System.Drawing.Point(60, 351)
        Me.Label_Valor.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label_Valor.Name = "Label_Valor"
        Me.Label_Valor.Size = New System.Drawing.Size(31, 13)
        Me.Label_Valor.TabIndex = 77
        Me.Label_Valor.Text = "Valor"
        Me.Label_Valor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox_Nombre
        '
        Me.TextBox_Nombre.Location = New System.Drawing.Point(102, 322)
        Me.TextBox_Nombre.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBox_Nombre.Name = "TextBox_Nombre"
        Me.TextBox_Nombre.Size = New System.Drawing.Size(173, 20)
        Me.TextBox_Nombre.TabIndex = 5
        '
        'Label_Nombre
        '
        Me.Label_Nombre.Location = New System.Drawing.Point(47, 325)
        Me.Label_Nombre.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label_Nombre.Name = "Label_Nombre"
        Me.Label_Nombre.Size = New System.Drawing.Size(44, 13)
        Me.Label_Nombre.TabIndex = 75
        Me.Label_Nombre.Text = "Nombre"
        Me.Label_Nombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label_Id
        '
        Me.Label_Id.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label_Id.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label_Id.Location = New System.Drawing.Point(75, 299)
        Me.Label_Id.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label_Id.Name = "Label_Id"
        Me.Label_Id.Size = New System.Drawing.Size(16, 13)
        Me.Label_Id.TabIndex = 74
        Me.Label_Id.Text = "Id"
        Me.Label_Id.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox_Id
        '
        Me.TextBox_Id.Location = New System.Drawing.Point(102, 296)
        Me.TextBox_Id.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBox_Id.Name = "TextBox_Id"
        Me.TextBox_Id.Size = New System.Drawing.Size(173, 20)
        Me.TextBox_Id.TabIndex = 4
        '
        'DataGridView_TablaValores
        '
        Me.DataGridView_TablaValores.AllowUserToOrderColumns = True
        Me.DataGridView_TablaValores.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView_TablaValores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_TablaValores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.C_Id, Me.C_Nombre, Me.C_Valor, Me.C_Tematica, Me.C_Descripcion, Me.C_Activo})
        Me.DataGridView_TablaValores.Location = New System.Drawing.Point(31, 12)
        Me.DataGridView_TablaValores.Name = "DataGridView_TablaValores"
        Me.DataGridView_TablaValores.Size = New System.Drawing.Size(740, 248)
        Me.DataGridView_TablaValores.TabIndex = 16
        '
        'C_Id
        '
        Me.C_Id.FillWeight = 65.0!
        Me.C_Id.HeaderText = "Id"
        Me.C_Id.Name = "C_Id"
        Me.C_Id.Width = 60
        '
        'C_Nombre
        '
        Me.C_Nombre.FillWeight = 200.0!
        Me.C_Nombre.HeaderText = "Nombre"
        Me.C_Nombre.Name = "C_Nombre"
        Me.C_Nombre.Width = 150
        '
        'C_Valor
        '
        Me.C_Valor.FillWeight = 200.0!
        Me.C_Valor.HeaderText = "Valor"
        Me.C_Valor.Name = "C_Valor"
        Me.C_Valor.Width = 150
        '
        'C_Tematica
        '
        Me.C_Tematica.HeaderText = "Temática"
        Me.C_Tematica.Name = "C_Tematica"
        '
        'C_Descripcion
        '
        Me.C_Descripcion.FillWeight = 400.0!
        Me.C_Descripcion.HeaderText = "Descripción"
        Me.C_Descripcion.Name = "C_Descripcion"
        Me.C_Descripcion.Width = 200
        '
        'C_Activo
        '
        Me.C_Activo.FillWeight = 75.0!
        Me.C_Activo.HeaderText = "Activo"
        Me.C_Activo.Name = "C_Activo"
        Me.C_Activo.Width = 70
        '
        'Label_IDSeleccionada
        '
        Me.Label_IDSeleccionada.AutoSize = True
        Me.Label_IDSeleccionada.Location = New System.Drawing.Point(28, 263)
        Me.Label_IDSeleccionada.Name = "Label_IDSeleccionada"
        Me.Label_IDSeleccionada.Size = New System.Drawing.Size(10, 13)
        Me.Label_IDSeleccionada.TabIndex = 91
        Me.Label_IDSeleccionada.Text = "-"
        '
        'ComboBox_Lenguaje
        '
        Me.ComboBox_Lenguaje.FormattingEnabled = True
        Me.ComboBox_Lenguaje.Items.AddRange(New Object() {"Castellano", "English"})
        Me.ComboBox_Lenguaje.Location = New System.Drawing.Point(667, 528)
        Me.ComboBox_Lenguaje.Name = "ComboBox_Lenguaje"
        Me.ComboBox_Lenguaje.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox_Lenguaje.TabIndex = 14
        '
        'ComboBox_Tematica
        '
        Me.ComboBox_Tematica.FormattingEnabled = True
        Me.ComboBox_Tematica.Location = New System.Drawing.Point(102, 373)
        Me.ComboBox_Tematica.Margin = New System.Windows.Forms.Padding(1)
        Me.ComboBox_Tematica.Name = "ComboBox_Tematica"
        Me.ComboBox_Tematica.Size = New System.Drawing.Size(173, 21)
        Me.ComboBox_Tematica.TabIndex = 7
        '
        'Form_Lista1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 561)
        Me.Controls.Add(Me.ComboBox_Tematica)
        Me.Controls.Add(Me.ComboBox_Lenguaje)
        Me.Controls.Add(Me.Label_IDSeleccionada)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CheckBox_MostrarActivos)
        Me.Controls.Add(Me.Label_Tematica)
        Me.Controls.Add(Me.Button_LimpiarCampos)
        Me.Controls.Add(Me.RichTextBox_Sucesos)
        Me.Controls.Add(Me.Button_Eliminar)
        Me.Controls.Add(Me.Button_Guardar)
        Me.Controls.Add(Me.Button_Agregar)
        Me.Controls.Add(Me.CheckBox_Activo)
        Me.Controls.Add(Me.TextBox_Descripcion)
        Me.Controls.Add(Me.Label_Descripcion)
        Me.Controls.Add(Me.TextBox_Valor)
        Me.Controls.Add(Me.Label_Valor)
        Me.Controls.Add(Me.TextBox_Nombre)
        Me.Controls.Add(Me.Label_Nombre)
        Me.Controls.Add(Me.Label_Id)
        Me.Controls.Add(Me.TextBox_Id)
        Me.Controls.Add(Me.DataGridView_TablaValores)
        Me.Name = "Form_Lista1"
        Me.Text = "Lista"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView_TablaValores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBox_Contraseña As TextBox
    Friend WithEvents Label_Contraseña As Label
    Friend WithEvents CheckBox_MostrarActivos As CheckBox
    Friend WithEvents Label_Tematica As Label
    Friend WithEvents Button_LimpiarCampos As Button
    Friend WithEvents RichTextBox_Sucesos As RichTextBox
    Friend WithEvents Button_Eliminar As Button
    Friend WithEvents Button_Guardar As Button
    Friend WithEvents Button_Agregar As Button
    Friend WithEvents CheckBox_Activo As CheckBox
    Friend WithEvents TextBox_Descripcion As TextBox
    Friend WithEvents Label_Descripcion As Label
    Friend WithEvents TextBox_Valor As TextBox
    Friend WithEvents Label_Valor As Label
    Friend WithEvents TextBox_Nombre As TextBox
    Friend WithEvents Label_Nombre As Label
    Friend WithEvents Label_Id As Label
    Friend WithEvents TextBox_Id As TextBox
    Friend WithEvents DataGridView_TablaValores As DataGridView
    Friend WithEvents Label_IDSeleccionada As Label
    Friend WithEvents C_Id As DataGridViewTextBoxColumn
    Friend WithEvents C_Nombre As DataGridViewTextBoxColumn
    Friend WithEvents C_Valor As DataGridViewTextBoxColumn
    Friend WithEvents C_Tematica As DataGridViewTextBoxColumn
    Friend WithEvents C_Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents C_Activo As DataGridViewTextBoxColumn
    Friend WithEvents ComboBox_Lenguaje As ComboBox
    Friend WithEvents ComboBox_Tematica As ComboBox
    Friend WithEvents Button_InicioContraseña As Button
    Friend WithEvents CheckBox_OcultarContraseña As CheckBox
End Class
