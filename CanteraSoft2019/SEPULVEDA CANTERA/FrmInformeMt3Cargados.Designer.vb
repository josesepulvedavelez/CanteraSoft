<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInformeMt3Cargados
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
        Me.dgvInformemt3Cargados = New System.Windows.Forms.DataGridView()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.txtRegistro = New System.Windows.Forms.TextBox()
        Me.btnSigg = New System.Windows.Forms.Button()
        Me.btnUlt = New System.Windows.Forms.Button()
        Me.btnAnt = New System.Windows.Forms.Button()
        Me.btnPri = New System.Windows.Forms.Button()
        CType(Me.dgvInformemt3Cargados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvInformemt3Cargados
        '
        Me.dgvInformemt3Cargados.AllowUserToAddRows = False
        Me.dgvInformemt3Cargados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInformemt3Cargados.Location = New System.Drawing.Point(12, 12)
        Me.dgvInformemt3Cargados.Name = "dgvInformemt3Cargados"
        Me.dgvInformemt3Cargados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvInformemt3Cargados.Size = New System.Drawing.Size(822, 407)
        Me.dgvInformemt3Cargados.TabIndex = 0
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.Location = New System.Drawing.Point(759, 427)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(75, 23)
        Me.btnExportarExcel.TabIndex = 122
        Me.btnExportarExcel.Text = "Excel"
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'txtRegistro
        '
        Me.txtRegistro.Location = New System.Drawing.Point(93, 427)
        Me.txtRegistro.Multiline = True
        Me.txtRegistro.Name = "txtRegistro"
        Me.txtRegistro.Size = New System.Drawing.Size(157, 23)
        Me.txtRegistro.TabIndex = 121
        '
        'btnSigg
        '
        Me.btnSigg.Location = New System.Drawing.Point(256, 427)
        Me.btnSigg.Name = "btnSigg"
        Me.btnSigg.Size = New System.Drawing.Size(34, 23)
        Me.btnSigg.TabIndex = 120
        Me.btnSigg.Text = ">>"
        Me.btnSigg.UseVisualStyleBackColor = True
        '
        'btnUlt
        '
        Me.btnUlt.Location = New System.Drawing.Point(296, 427)
        Me.btnUlt.Name = "btnUlt"
        Me.btnUlt.Size = New System.Drawing.Size(34, 23)
        Me.btnUlt.TabIndex = 119
        Me.btnUlt.Text = ">|"
        Me.btnUlt.UseVisualStyleBackColor = True
        '
        'btnAnt
        '
        Me.btnAnt.Location = New System.Drawing.Point(53, 427)
        Me.btnAnt.Name = "btnAnt"
        Me.btnAnt.Size = New System.Drawing.Size(34, 23)
        Me.btnAnt.TabIndex = 118
        Me.btnAnt.Text = "<<"
        Me.btnAnt.UseVisualStyleBackColor = True
        '
        'btnPri
        '
        Me.btnPri.Location = New System.Drawing.Point(13, 427)
        Me.btnPri.Name = "btnPri"
        Me.btnPri.Size = New System.Drawing.Size(34, 23)
        Me.btnPri.TabIndex = 117
        Me.btnPri.Text = "|<"
        Me.btnPri.UseVisualStyleBackColor = True
        '
        'FrmInformeMt3Cargados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(846, 462)
        Me.Controls.Add(Me.btnExportarExcel)
        Me.Controls.Add(Me.txtRegistro)
        Me.Controls.Add(Me.btnSigg)
        Me.Controls.Add(Me.btnUlt)
        Me.Controls.Add(Me.btnAnt)
        Me.Controls.Add(Me.btnPri)
        Me.Controls.Add(Me.dgvInformemt3Cargados)
        Me.Name = "FrmInformeMt3Cargados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INFORME METROS CARGADOS CLIENTE Y CONTRATO"
        CType(Me.dgvInformemt3Cargados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvInformemt3Cargados As DataGridView
    Friend WithEvents btnExportarExcel As Button
    Friend WithEvents txtRegistro As TextBox
    Friend WithEvents btnSigg As Button
    Friend WithEvents btnUlt As Button
    Friend WithEvents btnAnt As Button
    Friend WithEvents btnPri As Button
End Class
