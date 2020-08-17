<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenu
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
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaterialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaquinaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VolquetaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VehiculoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CargaMasivaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContratoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerVentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DigitacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemisionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformeDiarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemisionToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DiarioToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MensualToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mt3CargadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CarteraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientesXContratoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbonosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbonosXContratoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaquinaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DiarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SanJoseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ValeraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ValeraDescargaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ControlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ControlDisposicionResumenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ControlDisposicionPorClienteDetalleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ControlDisposicionPorClienteResumenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblUsuario = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblFecha = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblHora = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ControlDisposicionPrincipalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.RegistroToolStripMenuItem, Me.ContratoToolStripMenuItem, Me.DigitacionToolStripMenuItem, Me.InformesToolStripMenuItem, Me.SanJoseToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1091, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UsuariosToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "&Archivo"
        '
        'UsuariosToolStripMenuItem
        '
        Me.UsuariosToolStripMenuItem.Name = "UsuariosToolStripMenuItem"
        Me.UsuariosToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.UsuariosToolStripMenuItem.Text = "Usuarios"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'RegistroToolStripMenuItem
        '
        Me.RegistroToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MaterialToolStripMenuItem, Me.MaquinaToolStripMenuItem, Me.ClienteToolStripMenuItem, Me.VolquetaToolStripMenuItem})
        Me.RegistroToolStripMenuItem.Name = "RegistroToolStripMenuItem"
        Me.RegistroToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.RegistroToolStripMenuItem.Text = "&Registro"
        '
        'MaterialToolStripMenuItem
        '
        Me.MaterialToolStripMenuItem.Name = "MaterialToolStripMenuItem"
        Me.MaterialToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.MaterialToolStripMenuItem.Text = "Material"
        '
        'MaquinaToolStripMenuItem
        '
        Me.MaquinaToolStripMenuItem.Name = "MaquinaToolStripMenuItem"
        Me.MaquinaToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.MaquinaToolStripMenuItem.Text = "Maquina"
        '
        'ClienteToolStripMenuItem
        '
        Me.ClienteToolStripMenuItem.Name = "ClienteToolStripMenuItem"
        Me.ClienteToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.ClienteToolStripMenuItem.Text = "Cliente"
        '
        'VolquetaToolStripMenuItem
        '
        Me.VolquetaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VehiculoToolStripMenuItem, Me.CargaMasivaToolStripMenuItem})
        Me.VolquetaToolStripMenuItem.Name = "VolquetaToolStripMenuItem"
        Me.VolquetaToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.VolquetaToolStripMenuItem.Text = "Vehiculo"
        '
        'VehiculoToolStripMenuItem
        '
        Me.VehiculoToolStripMenuItem.Name = "VehiculoToolStripMenuItem"
        Me.VehiculoToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.VehiculoToolStripMenuItem.Text = "Vehiculo"
        '
        'CargaMasivaToolStripMenuItem
        '
        Me.CargaMasivaToolStripMenuItem.Name = "CargaMasivaToolStripMenuItem"
        Me.CargaMasivaToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.CargaMasivaToolStripMenuItem.Text = "Carga Masiva"
        '
        'ContratoToolStripMenuItem
        '
        Me.ContratoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VentaToolStripMenuItem, Me.VerVentaToolStripMenuItem})
        Me.ContratoToolStripMenuItem.Name = "ContratoToolStripMenuItem"
        Me.ContratoToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ContratoToolStripMenuItem.Text = "&Contrato"
        '
        'VentaToolStripMenuItem
        '
        Me.VentaToolStripMenuItem.Name = "VentaToolStripMenuItem"
        Me.VentaToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.VentaToolStripMenuItem.Text = "Venta"
        '
        'VerVentaToolStripMenuItem
        '
        Me.VerVentaToolStripMenuItem.Name = "VerVentaToolStripMenuItem"
        Me.VerVentaToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.VerVentaToolStripMenuItem.Text = "Ver Venta"
        '
        'DigitacionToolStripMenuItem
        '
        Me.DigitacionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemisionToolStripMenuItem, Me.InformeDiarioToolStripMenuItem})
        Me.DigitacionToolStripMenuItem.Name = "DigitacionToolStripMenuItem"
        Me.DigitacionToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
        Me.DigitacionToolStripMenuItem.Text = "&Digitacion"
        '
        'RemisionToolStripMenuItem
        '
        Me.RemisionToolStripMenuItem.Name = "RemisionToolStripMenuItem"
        Me.RemisionToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.RemisionToolStripMenuItem.Text = "Remision"
        '
        'InformeDiarioToolStripMenuItem
        '
        Me.InformeDiarioToolStripMenuItem.Name = "InformeDiarioToolStripMenuItem"
        Me.InformeDiarioToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.InformeDiarioToolStripMenuItem.Text = "Horometro - Tanqueo"
        '
        'InformesToolStripMenuItem
        '
        Me.InformesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemisionToolStripMenuItem1, Me.Mt3CargadosToolStripMenuItem, Me.CarteraToolStripMenuItem, Me.MaquinaToolStripMenuItem1})
        Me.InformesToolStripMenuItem.Name = "InformesToolStripMenuItem"
        Me.InformesToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.InformesToolStripMenuItem.Text = "Informes"
        '
        'RemisionToolStripMenuItem1
        '
        Me.RemisionToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DiarioToolStripMenuItem1, Me.MensualToolStripMenuItem1})
        Me.RemisionToolStripMenuItem1.Name = "RemisionToolStripMenuItem1"
        Me.RemisionToolStripMenuItem1.Size = New System.Drawing.Size(148, 22)
        Me.RemisionToolStripMenuItem1.Text = "Remision"
        '
        'DiarioToolStripMenuItem1
        '
        Me.DiarioToolStripMenuItem1.Name = "DiarioToolStripMenuItem1"
        Me.DiarioToolStripMenuItem1.Size = New System.Drawing.Size(119, 22)
        Me.DiarioToolStripMenuItem1.Text = "Diario"
        '
        'MensualToolStripMenuItem1
        '
        Me.MensualToolStripMenuItem1.Name = "MensualToolStripMenuItem1"
        Me.MensualToolStripMenuItem1.Size = New System.Drawing.Size(119, 22)
        Me.MensualToolStripMenuItem1.Text = "Mensual"
        '
        'Mt3CargadosToolStripMenuItem
        '
        Me.Mt3CargadosToolStripMenuItem.Name = "Mt3CargadosToolStripMenuItem"
        Me.Mt3CargadosToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.Mt3CargadosToolStripMenuItem.Text = "Mt3 Cargados"
        '
        'CarteraToolStripMenuItem
        '
        Me.CarteraToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClientesXContratoToolStripMenuItem, Me.AbonosToolStripMenuItem, Me.AbonosXContratoToolStripMenuItem})
        Me.CarteraToolStripMenuItem.Name = "CarteraToolStripMenuItem"
        Me.CarteraToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.CarteraToolStripMenuItem.Text = "Cartera"
        '
        'ClientesXContratoToolStripMenuItem
        '
        Me.ClientesXContratoToolStripMenuItem.Name = "ClientesXContratoToolStripMenuItem"
        Me.ClientesXContratoToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.ClientesXContratoToolStripMenuItem.Text = "Clientes x Contrato"
        '
        'AbonosToolStripMenuItem
        '
        Me.AbonosToolStripMenuItem.Name = "AbonosToolStripMenuItem"
        Me.AbonosToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.AbonosToolStripMenuItem.Text = "Abonos"
        '
        'AbonosXContratoToolStripMenuItem
        '
        Me.AbonosXContratoToolStripMenuItem.Name = "AbonosXContratoToolStripMenuItem"
        Me.AbonosXContratoToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.AbonosXContratoToolStripMenuItem.Text = "Abonos x Contrato"
        '
        'MaquinaToolStripMenuItem1
        '
        Me.MaquinaToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DiarioToolStripMenuItem})
        Me.MaquinaToolStripMenuItem1.Name = "MaquinaToolStripMenuItem1"
        Me.MaquinaToolStripMenuItem1.Size = New System.Drawing.Size(148, 22)
        Me.MaquinaToolStripMenuItem1.Text = "Maquina"
        '
        'DiarioToolStripMenuItem
        '
        Me.DiarioToolStripMenuItem.Name = "DiarioToolStripMenuItem"
        Me.DiarioToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.DiarioToolStripMenuItem.Text = "Diario"
        '
        'SanJoseToolStripMenuItem
        '
        Me.SanJoseToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ValeraToolStripMenuItem, Me.ValeraDescargaToolStripMenuItem, Me.InformesToolStripMenuItem1})
        Me.SanJoseToolStripMenuItem.Name = "SanJoseToolStripMenuItem"
        Me.SanJoseToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.SanJoseToolStripMenuItem.Text = "San Jose"
        '
        'ValeraToolStripMenuItem
        '
        Me.ValeraToolStripMenuItem.Name = "ValeraToolStripMenuItem"
        Me.ValeraToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.ValeraToolStripMenuItem.Text = "Valera"
        '
        'ValeraDescargaToolStripMenuItem
        '
        Me.ValeraDescargaToolStripMenuItem.Name = "ValeraDescargaToolStripMenuItem"
        Me.ValeraDescargaToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.ValeraDescargaToolStripMenuItem.Text = "Valera Descarga"
        '
        'InformesToolStripMenuItem1
        '
        Me.InformesToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ControlToolStripMenuItem, Me.ControlDisposicionResumenToolStripMenuItem, Me.ControlDisposicionPorClienteDetalleToolStripMenuItem, Me.ControlDisposicionPorClienteResumenToolStripMenuItem, Me.ControlDisposicionPrincipalToolStripMenuItem})
        Me.InformesToolStripMenuItem1.Name = "InformesToolStripMenuItem1"
        Me.InformesToolStripMenuItem1.Size = New System.Drawing.Size(156, 22)
        Me.InformesToolStripMenuItem1.Text = "Informes"
        '
        'ControlToolStripMenuItem
        '
        Me.ControlToolStripMenuItem.Name = "ControlToolStripMenuItem"
        Me.ControlToolStripMenuItem.Size = New System.Drawing.Size(299, 22)
        Me.ControlToolStripMenuItem.Text = "Control Disposicion Detalle"
        '
        'ControlDisposicionResumenToolStripMenuItem
        '
        Me.ControlDisposicionResumenToolStripMenuItem.Name = "ControlDisposicionResumenToolStripMenuItem"
        Me.ControlDisposicionResumenToolStripMenuItem.Size = New System.Drawing.Size(299, 22)
        Me.ControlDisposicionResumenToolStripMenuItem.Text = "Control Disposicion - Resumen"
        '
        'ControlDisposicionPorClienteDetalleToolStripMenuItem
        '
        Me.ControlDisposicionPorClienteDetalleToolStripMenuItem.Name = "ControlDisposicionPorClienteDetalleToolStripMenuItem"
        Me.ControlDisposicionPorClienteDetalleToolStripMenuItem.Size = New System.Drawing.Size(299, 22)
        Me.ControlDisposicionPorClienteDetalleToolStripMenuItem.Text = "Control Disposicion por Cliente"
        '
        'ControlDisposicionPorClienteResumenToolStripMenuItem
        '
        Me.ControlDisposicionPorClienteResumenToolStripMenuItem.Name = "ControlDisposicionPorClienteResumenToolStripMenuItem"
        Me.ControlDisposicionPorClienteResumenToolStripMenuItem.Size = New System.Drawing.Size(299, 22)
        Me.ControlDisposicionPorClienteResumenToolStripMenuItem.Text = "Control Disposicion por Cliente - Resumen"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblUsuario, Me.lblFecha, Me.lblHora})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 663)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1091, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblUsuario
        '
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(119, 17)
        Me.lblUsuario.Text = "ToolStripStatusLabel1"
        '
        'lblFecha
        '
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(119, 17)
        Me.lblFecha.Text = "ToolStripStatusLabel2"
        '
        'lblHora
        '
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Size = New System.Drawing.Size(119, 17)
        Me.lblHora.Text = "ToolStripStatusLabel3"
        '
        'Timer1
        '
        '
        'ControlDisposicionPrincipalToolStripMenuItem
        '
        Me.ControlDisposicionPrincipalToolStripMenuItem.Name = "ControlDisposicionPrincipalToolStripMenuItem"
        Me.ControlDisposicionPrincipalToolStripMenuItem.Size = New System.Drawing.Size(299, 22)
        Me.ControlDisposicionPrincipalToolStripMenuItem.Text = "Control Disposicion - Principal"
        '
        'FrmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1091, 685)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.Name = "FrmMenu"
        Me.Text = "MENU"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsuariosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MaterialToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MaquinaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VolquetaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContratoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VentaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DigitacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemisionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerVentaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformeDiarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VehiculoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CargaMasivaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InformesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemisionToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DiarioToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents MensualToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents Mt3CargadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CarteraToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClientesXContratoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AbonosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AbonosXContratoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MaquinaToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DiarioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SanJoseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ValeraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ValeraDescargaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ControlToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ControlDisposicionResumenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ControlDisposicionPorClienteDetalleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ControlDisposicionPorClienteResumenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblUsuario As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblFecha As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblHora As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ControlDisposicionPrincipalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
