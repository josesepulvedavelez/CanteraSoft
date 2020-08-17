<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCaja
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvCaja = New System.Windows.Forms.DataGridView()
        Me.btnSigg = New System.Windows.Forms.Button()
        Me.btnUlt = New System.Windows.Forms.Button()
        Me.btnAnt = New System.Windows.Forms.Button()
        Me.btnPri = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.btnInsertar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.txtRegistro = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtIdHorometro = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(13, 93)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(318, 267)
        Me.TabControl1.TabIndex = 151
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvCaja)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(310, 241)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "$"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvCaja
        '
        Me.dgvCaja.AllowUserToAddRows = False
        Me.dgvCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCaja.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCaja.Location = New System.Drawing.Point(3, 3)
        Me.dgvCaja.Name = "dgvCaja"
        Me.dgvCaja.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCaja.Size = New System.Drawing.Size(304, 235)
        Me.dgvCaja.TabIndex = 24
        '
        'btnSigg
        '
        Me.btnSigg.Location = New System.Drawing.Point(257, 395)
        Me.btnSigg.Name = "btnSigg"
        Me.btnSigg.Size = New System.Drawing.Size(34, 23)
        Me.btnSigg.TabIndex = 148
        Me.btnSigg.Text = ">>"
        Me.btnSigg.UseVisualStyleBackColor = True
        '
        'btnUlt
        '
        Me.btnUlt.Location = New System.Drawing.Point(297, 395)
        Me.btnUlt.Name = "btnUlt"
        Me.btnUlt.Size = New System.Drawing.Size(34, 23)
        Me.btnUlt.TabIndex = 149
        Me.btnUlt.Text = ">|"
        Me.btnUlt.UseVisualStyleBackColor = True
        '
        'btnAnt
        '
        Me.btnAnt.Location = New System.Drawing.Point(54, 395)
        Me.btnAnt.Name = "btnAnt"
        Me.btnAnt.Size = New System.Drawing.Size(34, 23)
        Me.btnAnt.TabIndex = 147
        Me.btnAnt.Text = "<<"
        Me.btnAnt.UseVisualStyleBackColor = True
        '
        'btnPri
        '
        Me.btnPri.Location = New System.Drawing.Point(14, 395)
        Me.btnPri.Name = "btnPri"
        Me.btnPri.Size = New System.Drawing.Size(34, 23)
        Me.btnPri.TabIndex = 146
        Me.btnPri.Text = "|<"
        Me.btnPri.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(256, 366)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminar.TabIndex = 145
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnActualizar
        '
        Me.btnActualizar.Location = New System.Drawing.Point(175, 366)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(75, 23)
        Me.btnActualizar.TabIndex = 144
        Me.btnActualizar.Text = "&Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'btnInsertar
        '
        Me.btnInsertar.Enabled = False
        Me.btnInsertar.Location = New System.Drawing.Point(94, 366)
        Me.btnInsertar.Name = "btnInsertar"
        Me.btnInsertar.Size = New System.Drawing.Size(75, 23)
        Me.btnInsertar.TabIndex = 143
        Me.btnInsertar.Text = "&Insertar"
        Me.btnInsertar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(13, 366)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 23)
        Me.btnNuevo.TabIndex = 142
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'txtRegistro
        '
        Me.txtRegistro.Location = New System.Drawing.Point(94, 395)
        Me.txtRegistro.Multiline = True
        Me.txtRegistro.Name = "txtRegistro"
        Me.txtRegistro.Size = New System.Drawing.Size(157, 23)
        Me.txtRegistro.TabIndex = 150
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 152
        Me.Label1.Text = "Concepto"
        '
        'txtConcepto
        '
        Me.txtConcepto.Location = New System.Drawing.Point(75, 27)
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(248, 20)
        Me.txtConcepto.TabIndex = 153
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(75, 53)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(248, 20)
        Me.txtValor.TabIndex = 154
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 155
        Me.Label2.Text = "Valor"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(459, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 156
        Me.Label3.Text = "Label3"
        '
        'txtIdHorometro
        '
        Me.txtIdHorometro.Location = New System.Drawing.Point(504, 79)
        Me.txtIdHorometro.Name = "txtIdHorometro"
        Me.txtIdHorometro.Size = New System.Drawing.Size(95, 20)
        Me.txtIdHorometro.TabIndex = 157
        '
        'FrmCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 432)
        Me.Controls.Add(Me.txtIdHorometro)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtValor)
        Me.Controls.Add(Me.txtConcepto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnSigg)
        Me.Controls.Add(Me.btnUlt)
        Me.Controls.Add(Me.btnAnt)
        Me.Controls.Add(Me.btnPri)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.btnInsertar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.txtRegistro)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "$"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dgvCaja As DataGridView
    Friend WithEvents btnSigg As Button
    Friend WithEvents btnUlt As Button
    Friend WithEvents btnAnt As Button
    Friend WithEvents btnPri As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnActualizar As Button
    Friend WithEvents btnInsertar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents txtRegistro As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtConcepto As TextBox
    Friend WithEvents txtValor As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtIdHorometro As TextBox
End Class
