<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInformeMaquinaDiario
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
        Me.dgvHorometroTanqueo = New System.Windows.Forms.DataGridView()
        Me.dgvMaquinaVenta = New System.Windows.Forms.DataGridView()
        Me.dgvCaja = New System.Windows.Forms.DataGridView()
        CType(Me.dgvHorometroTanqueo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMaquinaVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvHorometroTanqueo
        '
        Me.dgvHorometroTanqueo.AllowUserToAddRows = False
        Me.dgvHorometroTanqueo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHorometroTanqueo.Location = New System.Drawing.Point(12, 12)
        Me.dgvHorometroTanqueo.Name = "dgvHorometroTanqueo"
        Me.dgvHorometroTanqueo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvHorometroTanqueo.Size = New System.Drawing.Size(1099, 249)
        Me.dgvHorometroTanqueo.TabIndex = 25
        '
        'dgvMaquinaVenta
        '
        Me.dgvMaquinaVenta.AllowUserToAddRows = False
        Me.dgvMaquinaVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMaquinaVenta.Location = New System.Drawing.Point(12, 267)
        Me.dgvMaquinaVenta.Name = "dgvMaquinaVenta"
        Me.dgvMaquinaVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMaquinaVenta.Size = New System.Drawing.Size(770, 249)
        Me.dgvMaquinaVenta.TabIndex = 26
        '
        'dgvCaja
        '
        Me.dgvCaja.AllowUserToAddRows = False
        Me.dgvCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCaja.Location = New System.Drawing.Point(788, 267)
        Me.dgvCaja.Name = "dgvCaja"
        Me.dgvCaja.Size = New System.Drawing.Size(323, 249)
        Me.dgvCaja.TabIndex = 27
        '
        'FrmInformeMaquinaDiario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1123, 529)
        Me.Controls.Add(Me.dgvCaja)
        Me.Controls.Add(Me.dgvMaquinaVenta)
        Me.Controls.Add(Me.dgvHorometroTanqueo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FrmInformeMaquinaDiario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INFORME DIARIO - MAQUINA"
        CType(Me.dgvHorometroTanqueo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMaquinaVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvHorometroTanqueo As DataGridView
    Friend WithEvents dgvMaquinaVenta As DataGridView
    Friend WithEvents dgvCaja As DataGridView
End Class
