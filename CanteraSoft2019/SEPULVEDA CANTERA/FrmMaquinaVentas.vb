Imports System.Data
Imports System.Data.OleDb

Public Class FrmMaquinaVentas
    Dim conexion As OleDbConnection
    Dim adaptador As OleDbDataAdapter
    Dim adaptadorCliente As OleDbDataAdapter
    Dim adaptadorMaterial As OleDbDataAdapter
    Dim datos As DataSet
    Dim bmb As BindingManagerBase

    Dim sql As String = "SELECT marca, fecha, cliente, material, mt3, formaPago, valor, viajes, total, idHorometro, MAQUINA_VENTA.id FROM MAQUINA, HOROMETRO_TANQUEO, MAQUINA_VENTA WHERE MAQUINA.id = HOROMETRO_TANQUEO.idMaquina AND HOROMETRO_TANQUEO.id = MAQUINA_VENTA.idHorometro ORDER BY MAQUINA_VENTA.id"

    Private Sub FrmMaquinaVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter(sql, conexion)
        adaptadorCliente = New OleDbDataAdapter("SELECT cliente, id FROM CLIENTE", conexion)
        adaptadorMaterial = New OleDbDataAdapter("SELECT descripcion, id FROM MATERIAL", conexion)

        datos = New DataSet()

        Dim insertar As New OleDbCommand("INSERT INTO MAQUINA_VENTA(cliente, formaPago, mt3, material, valor, viajes, total, idHorometro) VALUES(@cliente, @formaPago, @mt3, @material, @valor, @viajes, @total, @idHorometro)", conexion)
        adaptador.InsertCommand = insertar
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@cliente", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@formaPago", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@mt3", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@material", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@valor", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@viajes", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@total", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@idHorometro", OleDbType.VarChar))

        Dim actualizar As New OleDbCommand("UPDATE MAQUINA_VENTA SET cliente=@cliente, formaPago=@formaPago, mt3=@mt3, material=@material, valor=@valor, viajes=@viajes, total=@total, idHorometro=@idHorometro WHERE id=@id", conexion)
        adaptador.UpdateCommand = actualizar
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@cliente", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@formaPago", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@mt3", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@material", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@valor", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@viajes", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@total", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@idHorometro", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@id", OleDbType.VarChar))

        Dim eliminar As New OleDbCommand("DELETE * FROM MAQUINA_VENTA WHERE id=@id", conexion)
        adaptador.DeleteCommand = eliminar
        adaptador.DeleteCommand.Parameters.Add(New OleDbParameter("@id", OleDbType.VarChar))

        conexion.Open()
        adaptador.Fill(datos, "MAQUINA_VENTA")
        adaptadorCliente.Fill(datos, "CLIENTE")
        adaptadorMaterial.Fill(datos, "MATERIAL")
        conexion.Close()

        dgvMaquinaVenta.DataSource = datos.Tables("MAQUINA_VENTA")
        dgvMaquinaVenta.Columns("idHorometro").Visible = False
        dgvMaquinaVenta.Columns("id").Visible = False

        cboCliente.DataBindings.Add(New Binding("Text", datos.Tables("MAQUINA_VENTA"), "cliente"))
        cboMaterial.DataBindings.Add(New Binding("Text", datos.Tables("MAQUINA_VENTA"), "material"))
        txtMt3.DataBindings.Add(New Binding("Text", datos.Tables("MAQUINA_VENTA"), "mt3"))
        cboFormaPago.DataBindings.Add(New Binding("Text", datos.Tables("MAQUINA_VENTA"), "formaPago"))
        txtValor.DataBindings.Add(New Binding("Text", datos.Tables("MAQUINA_VENTA"), "valor"))
        txtViajes.DataBindings.Add(New Binding("Text", datos.Tables("MAQUINA_VENTA"), "viajes"))
        txtTotal.DataBindings.Add(New Binding("Text", datos.Tables("MAQUINA_VENTA"), "total"))
        txtIdHT.DataBindings.Add(New Binding("Text", datos.Tables("MAQUINA_VENTA"), "idHorometro"))

        Call cargaCombox()
        bmb = BindingContext(datos.Tables("MAQUINA_VENTA"))
        Call registro()
    End Sub

    Private Sub cargaCombox()
        cboCliente.DataSource = datos.Tables("CLIENTE")
        cboCliente.DisplayMember = "cliente"
        cboCliente.ValueMember = "id"

        cboMaterial.DataSource = datos.Tables("MATERIAL")
        cboMaterial.DisplayMember = "descripcion"
        cboMaterial.ValueMember = "id"

    End Sub

    Private Sub registro()
        txtRegistro.Text = "Registro " & (bmb.Position + 1) & " de " & datos.Tables(0).Rows.Count
    End Sub

    Private Sub btnPri_Click(sender As Object, e As EventArgs) Handles btnPri.Click
        bmb.Position = 0
        Call registro()
    End Sub

    Private Sub btnAnt_Click(sender As Object, e As EventArgs) Handles btnAnt.Click
        bmb.Position -= 1
        Call registro()
    End Sub

    Private Sub btnSigg_Click(sender As Object, e As EventArgs) Handles btnSigg.Click
        bmb.Position = +1
        Call registro()
    End Sub

    Private Sub btnUlt_Click(sender As Object, e As EventArgs) Handles btnUlt.Click
        bmb.Position = datos.Tables("MAQUINA_VENTA").Rows.Count
        Call registro()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        btnInsertar.Enabled = True
        btnNuevo.Enabled = False

        txtMt3.Text = "0"
        txtValor.Text = "0"
        txtViajes.Text = "0"
        txtTotal.Text = "0"

        txtMt3.Focus()
    End Sub

    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        If txtIdHT.Text = "" Then
            MessageBox.Show("Llene todos los campos ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            adaptador.InsertCommand.Parameters("@cliente").Value = cboCliente.Text
            adaptador.InsertCommand.Parameters("@formaPago").Value = cboFormaPago.Text
            adaptador.InsertCommand.Parameters("@mt3").Value = txtMt3.Text
            adaptador.InsertCommand.Parameters("@material").Value = cboMaterial.Text
            adaptador.InsertCommand.Parameters("@valor").Value = txtValor.Text
            adaptador.InsertCommand.Parameters("@viajes").Value = txtViajes.Text
            adaptador.InsertCommand.Parameters("@total").Value = txtTotal.Text
            adaptador.InsertCommand.Parameters("@idHorometro").Value = txtIdHT.Text

            conexion.Open()
            Dim i As Integer = adaptador.InsertCommand.ExecuteNonQuery()
            conexion.Close()

            MessageBox.Show(i & " Registros añadidos", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

            btnInsertar.Enabled = False
            btnNuevo.Enabled = True

            datos.Clear()
            adaptador.Fill(datos, "MAQUINA_VENTA")
            adaptadorCliente.Fill(datos, "CLIENTE")
            adaptadorMaterial.Fill(datos, "MATERIAL")
            dgvMaquinaVenta.Refresh()

            bmb.Position = datos.Tables("MAQUINA_VENTA").Rows.Count
            Call registro()
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If cboFormaPago.Text = "" Then
            MessageBox.Show("Llene todos los campos ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            adaptador.UpdateCommand.Parameters("@cliente").Value = cboCliente.Text
            adaptador.UpdateCommand.Parameters("@formaPago").Value = cboFormaPago.Text
            adaptador.UpdateCommand.Parameters("@mt3").Value = (txtMt3.Text)
            adaptador.UpdateCommand.Parameters("@material").Value = cboMaterial.Text
            adaptador.UpdateCommand.Parameters("@valor").Value = (txtValor.Text)
            adaptador.UpdateCommand.Parameters("@viajes").Value = (txtViajes.Text)
            adaptador.UpdateCommand.Parameters("@total").Value = (txtTotal.Text)
            adaptador.UpdateCommand.Parameters("@idHorometro").Value = txtIdHT.Text
            adaptador.UpdateCommand.Parameters("@id").Value = dgvMaquinaVenta.CurrentRow.Cells("id").Value

            conexion.Open()
            Dim i As Integer = adaptador.UpdateCommand.ExecuteNonQuery()
            conexion.Close()

            MessageBox.Show(i & " Registro actualizado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

            btnInsertar.Enabled = False
            btnNuevo.Enabled = True

            datos.Clear()
            adaptador.Fill(datos, "MAQUINA_VENTA")
            adaptadorCliente.Fill(datos, "CLIENTE")
            adaptadorMaterial.Fill(datos, "MATERIAL")
            dgvMaquinaVenta.Refresh()

            bmb.Position = datos.Tables("MAQUINA_VENTA").Rows.Count
            Call registro()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If MessageBox.Show("Esta seguro de eliminar este registro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                adaptador.DeleteCommand.Parameters("@id").Value = dgvMaquinaVenta.CurrentRow.Cells("id").Value

                conexion.Open()
                Dim i As Integer = adaptador.DeleteCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registro eliminado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "MAQUINA_VENTA")
                adaptadorCliente.Fill(datos, "CLIENTE")
                adaptadorMaterial.Fill(datos, "MATERIAL")
                dgvMaquinaVenta.Refresh()

                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub txtMt3_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtMt3.Validating
        If txtMt3.Text = "" Or IsNumeric(txtMt3.Text) = False Then
            ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
            ErrorProvider1.SetError(txtMt3, "Digite Mt3")
            txtMt3.Focus()
        Else
            ErrorProvider1.SetError(txtMt3, "")
        End If
    End Sub

    Private Sub txtValor_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtValor.Validating
        If txtValor.Text = "" Or IsNumeric(txtValor.Text) = False Then
            ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
            ErrorProvider1.SetError(txtValor, "Digite el Valor")
            txtValor.Focus()
        Else
            ErrorProvider1.SetError(txtValor, "")
        End If
    End Sub

    Private Sub txtViajes_Validated(sender As Object, e As EventArgs) Handles txtViajes.Validated
        If txtViajes.Text = "" Or IsNumeric(txtViajes.Text) = False Then
            ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
            ErrorProvider1.SetError(txtViajes, "Digite horometro inicial")
            txtViajes.Focus()
        Else
            ErrorProvider1.SetError(txtViajes, "")
        End If
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim exportarExcel As New ExportarExcel()
        exportarExcel.ExportarExcel(dgvMaquinaVenta)
    End Sub

    Private Sub cboFormaPago_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboFormaPago.SelectedValueChanged

    End Sub

    Private Sub chkCalcular_CheckedChanged(sender As Object, e As EventArgs) Handles chkCalcular.CheckedChanged
        If chkCalcular.Checked = True Then
            Dim mt3 As Double = CDbl(txtMt3.Text)
            Dim valor As Double = CDbl(txtValor.Text)
            Dim viajes As Double = CDbl(txtViajes.Text)
            Dim total As Double

            If cboFormaPago.Text = "CONTADO" Then
                total = valor * viajes
                txtTotal.Text = total.ToString()
            ElseIf cboFormaPago.Text = "CREDITO" Then
                total = mt3 * valor
                txtTotal.Text = total.ToString()
            End If

        Else
            txtTotal.Text = "0"
        End If
    End Sub
End Class