<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAbonosxContratos
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
        Me.dgvAbonos = New System.Windows.Forms.DataGridView()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.txtRegistro = New System.Windows.Forms.TextBox()
        Me.btnSigg = New System.Windows.Forms.Button()
        Me.btnUlt = New System.Windows.Forms.Button()
        Me.btnAnt = New System.Windows.Forms.Button()
        Me.btnPri = New System.Windows.Forms.Button()
        Me.cboContrato = New System.Windows.Forms.ComboBox()
        Me.cboCliente = New System.Windows.Forms.ComboBox()
        Me.Cliente = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.dgvAbonos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvAbonos
        '
        Me.dgvAbonos.AllowUserToAddRows = False
        Me.dgvAbonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAbonos.Location = New System.Drawing.Point(12, 52)
        Me.dgvAbonos.Name = "dgvAbonos"
        Me.dgvAbonos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAbonos.Size = New System.Drawing.Size(615, 375)
        Me.dgvAbonos.TabIndex = 130
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.Location = New System.Drawing.Point(552, 441)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(75, 23)
        Me.btnExportarExcel.TabIndex = 129
        Me.btnExportarExcel.Text = "Excel"
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'txtRegistro
        '
        Me.txtRegistro.Location = New System.Drawing.Point(90, 441)
        Me.txtRegistro.Multiline = True
        Me.txtRegistro.Name = "txtRegistro"
        Me.txtRegistro.Size = New System.Drawing.Size(156, 23)
        Me.txtRegistro.TabIndex = 128
        '
        'btnSigg
        '
        Me.btnSigg.Location = New System.Drawing.Point(252, 441)
        Me.btnSigg.Name = "btnSigg"
        Me.btnSigg.Size = New System.Drawing.Size(33, 23)
        Me.btnSigg.TabIndex = 127
        Me.btnSigg.Text = ">>"
        Me.btnSigg.UseVisualStyleBackColor = True
        '
        'btnUlt
        '
        Me.btnUlt.Location = New System.Drawing.Point(291, 441)
        Me.btnUlt.Name = "btnUlt"
        Me.btnUlt.Size = New System.Drawing.Size(33, 23)
        Me.btnUlt.TabIndex = 126
        Me.btnUlt.Text = ">|"
        Me.btnUlt.UseVisualStyleBackColor = True
        '
        'btnAnt
        '
        Me.btnAnt.Location = New System.Drawing.Point(51, 441)
        Me.btnAnt.Name = "btnAnt"
        Me.btnAnt.Size = New System.Drawing.Size(33, 23)
        Me.btnAnt.TabIndex = 125
        Me.btnAnt.Text = "<<"
        Me.btnAnt.UseVisualStyleBackColor = True
        '
        'btnPri
        '
        Me.btnPri.Location = New System.Drawing.Point(12, 441)
        Me.btnPri.Name = "btnPri"
        Me.btnPri.Size = New System.Drawing.Size(33, 23)
        Me.btnPri.TabIndex = 124
        Me.btnPri.Text = "|<"
        Me.btnPri.UseVisualStyleBackColor = True
        '
        'cboContrato
        '
        Me.cboContrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContrato.FormattingEnabled = True
        Me.cboContrato.Location = New System.Drawing.Point(327, 25)
        Me.cboContrato.Name = "cboContrato"
        Me.cboContrato.Size = New System.Drawing.Size(300, 21)
        Me.cboContrato.TabIndex = 131
        '
        'cboCliente
        '
        Me.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCliente.FormattingEnabled = True
        Me.cboCliente.Location = New System.Drawing.Point(12, 25)
        Me.cboCliente.Name = "cboCliente"
        Me.cboCliente.Size = New System.Drawing.Size(300, 21)
        Me.cboCliente.TabIndex = 132
        '
        'Cliente
        '
        Me.Cliente.AutoSize = True
        Me.Cliente.Location = New System.Drawing.Point(9, 9)
        Me.Cliente.Name = "Cliente"
        Me.Cliente.Size = New System.Drawing.Size(39, 13)
        Me.Cliente.TabIndex = 133
        Me.Cliente.Text = "Cliente"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(324, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 134
        Me.Label2.Text = "Contrato"
        '
        'FrmAbonosxContratos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 478)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Cliente)
        Me.Controls.Add(Me.cboCliente)
        Me.Controls.Add(Me.cboContrato)
        Me.Controls.Add(Me.dgvAbonos)
        Me.Controls.Add(Me.btnExportarExcel)
        Me.Controls.Add(Me.txtRegistro)
        Me.Controls.Add(Me.btnSigg)
        Me.Controls.Add(Me.btnUlt)
        Me.Controls.Add(Me.btnAnt)
        Me.Controls.Add(Me.btnPri)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmAbonosxContratos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgvAbonos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvAbonos As DataGridView
    Friend WithEvents btnExportarExcel As Button
    Friend WithEvents txtRegistro As TextBox
    Friend WithEvents btnSigg As Button
    Friend WithEvents btnUlt As Button
    Friend WithEvents btnAnt As Button
    Friend WithEvents btnPri As Button
    Friend WithEvents cboContrato As ComboBox
    Friend WithEvents cboCliente As ComboBox
    Friend WithEvents Cliente As Label
    Friend WithEvents Label2 As Label
End Class
