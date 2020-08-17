Imports System.Data
Imports System.Data.OleDb

Public Class FrmContratoBuscar
    Dim conexion As OleDbConnection
    Dim adaptador As OleDbDataAdapter
    Dim tabla As DataTable

    Dim sql As String = "SELECT descripcion, id FROM MATERIAL WHERE activo = true"

    Private Sub FrmContratoBuscar_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter(sql, conexion)
        tabla = New DataTable()

        conexion.Open()
        adaptador.Fill(tabla)
        conexion.Close()

        cboMaterial.DataSource = tabla
        cboMaterial.DisplayMember = "descripcion"
        cboMaterial.ValueMember = "id"

    End Sub

    Private Sub btnEnviar_Click(sender As System.Object, e As System.EventArgs) Handles btnEnviar.Click

        If txtCantidad.Text = "" Or txtPrecio.Text = "" Then
            MessageBox.Show("La cantidad o el precio estan vacios", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrecio.Focus()
        Else
            Dim precio, cantidad, subtotal As Double

            precio = Convert.ToDouble(txtPrecio.Text)
            cantidad = Convert.ToDouble(txtCantidad.Text)

            subtotal = cantidad * precio

            FrmContrato.dgvContrato.Rows.Add(precio, cantidad, subtotal, cboMaterial.Text, cboMaterial.SelectedValue)

            Me.Close()
        End If
    End Sub
End Class