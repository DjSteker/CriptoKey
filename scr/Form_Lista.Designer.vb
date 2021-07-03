<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Lista
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button_Cancelar = New System.Windows.Forms.Button()
        Me.Button_Guardar = New System.Windows.Forms.Button()
        Me.Label_Id = New System.Windows.Forms.Label()
        Me.TextBox_Id = New System.Windows.Forms.TextBox()
        Me.TextBox_Contraseñas = New System.Windows.Forms.TextBox()
        Me.Label_Contraseñas = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label_Descripcion = New System.Windows.Forms.Label()
        Me.C_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_Contraseña = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.C_Tematica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.C_ID, Me.C_Nombre, Me.C_Contraseña, Me.C_Descripcion, Me.C_Tematica})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 37)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(768, 297)
        Me.DataGridView1.TabIndex = 0
        '
        'Button_Cancelar
        '
        Me.Button_Cancelar.Location = New System.Drawing.Point(105, 497)
        Me.Button_Cancelar.Name = "Button_Cancelar"
        Me.Button_Cancelar.Size = New System.Drawing.Size(87, 27)
        Me.Button_Cancelar.TabIndex = 3
        Me.Button_Cancelar.Text = "Cancelar"
        Me.Button_Cancelar.UseVisualStyleBackColor = True
        '
        'Button_Guardar
        '
        Me.Button_Guardar.Location = New System.Drawing.Point(10, 497)
        Me.Button_Guardar.Name = "Button_Guardar"
        Me.Button_Guardar.Size = New System.Drawing.Size(87, 27)
        Me.Button_Guardar.TabIndex = 2
        Me.Button_Guardar.Text = "Guardar"
        Me.Button_Guardar.UseVisualStyleBackColor = True
        '
        'Label_Id
        '
        Me.Label_Id.AutoSize = True
        Me.Label_Id.Location = New System.Drawing.Point(211, 504)
        Me.Label_Id.Name = "Label_Id"
        Me.Label_Id.Size = New System.Drawing.Size(16, 13)
        Me.Label_Id.TabIndex = 4
        Me.Label_Id.Text = "Id"
        '
        'TextBox_Id
        '
        Me.TextBox_Id.Location = New System.Drawing.Point(233, 501)
        Me.TextBox_Id.Name = "TextBox_Id"
        Me.TextBox_Id.Size = New System.Drawing.Size(100, 20)
        Me.TextBox_Id.TabIndex = 5
        '
        'TextBox_Contraseñas
        '
        Me.TextBox_Contraseñas.Location = New System.Drawing.Point(426, 501)
        Me.TextBox_Contraseñas.Name = "TextBox_Contraseñas"
        Me.TextBox_Contraseñas.Size = New System.Drawing.Size(130, 20)
        Me.TextBox_Contraseñas.TabIndex = 7
        '
        'Label_Contraseñas
        '
        Me.Label_Contraseñas.AutoSize = True
        Me.Label_Contraseñas.Location = New System.Drawing.Point(354, 504)
        Me.Label_Contraseñas.Name = "Label_Contraseñas"
        Me.Label_Contraseñas.Size = New System.Drawing.Size(66, 13)
        Me.Label_Contraseñas.TabIndex = 6
        Me.Label_Contraseñas.Text = "Contraseñas"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(629, 501)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(130, 20)
        Me.TextBox3.TabIndex = 9
        '
        'Label_Descripcion
        '
        Me.Label_Descripcion.AutoSize = True
        Me.Label_Descripcion.Location = New System.Drawing.Point(560, 504)
        Me.Label_Descripcion.Name = "Label_Descripcion"
        Me.Label_Descripcion.Size = New System.Drawing.Size(63, 13)
        Me.Label_Descripcion.TabIndex = 8
        Me.Label_Descripcion.Text = "Descripcion"
        '
        'C_ID
        '
        Me.C_ID.FillWeight = 70.0!
        Me.C_ID.HeaderText = "ID"
        Me.C_ID.Name = "C_ID"
        Me.C_ID.Width = 50
        '
        'C_Nombre
        '
        Me.C_Nombre.FillWeight = 200.0!
        Me.C_Nombre.HeaderText = "Nombre"
        Me.C_Nombre.Name = "C_Nombre"
        Me.C_Nombre.Width = 200
        '
        'C_Contraseña
        '
        Me.C_Contraseña.FillWeight = 300.0!
        Me.C_Contraseña.HeaderText = "Contraseña"
        Me.C_Contraseña.Name = "C_Contraseña"
        Me.C_Contraseña.Width = 300
        '
        'C_Descripcion
        '
        Me.C_Descripcion.FillWeight = 300.0!
        Me.C_Descripcion.HeaderText = "Descripcion"
        Me.C_Descripcion.Name = "C_Descripcion"
        Me.C_Descripcion.Width = 200
        '
        'C_Tematica
        '
        Me.C_Tematica.HeaderText = "Tematica"
        Me.C_Tematica.Name = "C_Tematica"
        '
        'Form_Lista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 536)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label_Descripcion)
        Me.Controls.Add(Me.TextBox_Contraseñas)
        Me.Controls.Add(Me.Label_Contraseñas)
        Me.Controls.Add(Me.TextBox_Id)
        Me.Controls.Add(Me.Label_Id)
        Me.Controls.Add(Me.Button_Cancelar)
        Me.Controls.Add(Me.Button_Guardar)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Form_Lista"
        Me.Text = "Kripto key beta"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button_Cancelar As Button
    Friend WithEvents Button_Guardar As Button
    Friend WithEvents Label_Id As Label
    Friend WithEvents TextBox_Id As TextBox
    Friend WithEvents TextBox_Contraseñas As TextBox
    Friend WithEvents Label_Contraseñas As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label_Descripcion As Label
    Friend WithEvents C_ID As DataGridViewTextBoxColumn
    Friend WithEvents C_Nombre As DataGridViewTextBoxColumn
    Friend WithEvents C_Contraseña As DataGridViewTextBoxColumn
    Friend WithEvents C_Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents C_Tematica As DataGridViewTextBoxColumn
End Class
