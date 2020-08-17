Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb

Public Class FrmRemision
    Dim conexion As OleDbConnection
    Dim adaptador As OleDbDataAdapter
    Dim adaptadorCliente As OleDbDataAdapter
    Dim adaptadorContrato As OleDbDataAdapter
    Dim adaptadorMaquina As OleDbDataAdapter
    Dim adaptadorMaterial As OleDbDataAdapter
    Dim adaptadorEmpleado As OleDbDataAdapter
    Dim construct As OleDbCommandBuilder
    Dim datos As DataSet
    Dim tblCOntrato As DataTable
    Dim tblMaterial As DataTable
    Dim bmb As BindingManagerBase

    Dim sql As String = "SELECT numero, RE.fecha, cliente, contrato, marca, RE.serie, descripcion AS material, formaPago, nombres AS operador, conductor, RE.placa, horaDespacho, mt3Dig, mt3Cap, morro, RE.activo, RE.id FROM CLIENTE AS CL, REMISION AS RE, CONTRATO AS CR, MAQUINA AS MA, MATERIAL AS MT, EMPLEADO AS EM WHERE CL.id=RE.idCliente AND CR.id=RE.idContrato AND MA.id=RE.idMaquina AND MT.id=RE.idMaterial AND EM.id=RE.idEMpleado ORDER BY RE.id;"

    Private Sub FrmRemision_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter(sql, conexion)
        adaptadorCliente = New OleDbDataAdapter("SELECT cliente, id FROM CLIENTE WHERE activo = true", conexion)
        adaptadorContrato = New OleDbDataAdapter("SELECT contrato, id FROM CONTRATO WHERE activo = true", conexion)
        adaptadorMaquina = New OleDbDataAdapter("SELECT marca, serie, id FROM MAQUINA WHERE activo = true", conexion)
        adaptadorMaterial = New OleDbDataAdapter("SELECT descripcion, id FROM MATERIAL WHERE activo = true", conexion)
        adaptadorEmpleado = New OleDbDataAdapter("SELECT nombres, id FROM EMPLEADO WHERE cargo = 'OPERADOR' ", conexion)

        datos = New DataSet()

        Dim insertar As New OleDbCommand("INSERT INTO REMISION(numero, fecha, idCliente, idContrato, idMaquina, serie, idMaterial, formaPago, idEmpleado, conductor, placa, horaDespacho, mt3Dig, mt3Cap, morro, activo) VALUES(@numero, @fecha, @idCliente, @idContrato, @idMaquina, @serie, @idMaterial, @formaPago, @idEmpleado, @conductor, @placa, @horaDespacho, @mt3Dig, @mt3Cap, @morro, @activo)", conexion)
        adaptador.InsertCommand = insertar
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@numero", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@fecha", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@idCliente", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@idContrato", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@idMaquina", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@serie", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@idMaterial", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@formaPago", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@idEmpleado", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@conductor", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@placa", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@horaDespacho", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@mt3Dig", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@mt3Cap", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@morro", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@activo", OleDbType.Boolean))

        Dim actualizar As New OleDbCommand("UPDATE REMISION SET numero=@numero, fecha=@fecha, idCLiente=@idCliente, idContrato=@idContrato, idMaquina=@idMaquina, serie=@serie, idMaterial=@idMaterial, formaPago=@formaPago, idEmpleado=@idEmpleado, conductor=@conductor, placa=@placa, horaDespacho=@horaDespacho, mt3Dig=@mt3Dig, mt3Cap=@mt3Cap, morro=@morro, activo=@activo WHERE REMISION.id=@id", conexion)
        adaptador.UpdateCommand = actualizar
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@numero", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@fecha", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@idCliente", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@idContrato", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@idMaquina", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@serie", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@idMaterial", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@formaPago", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@idEmpleado", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@conductor", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@placa", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@horaDespacho", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@mt3Dig", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@mt3Cap", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@morro", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@activo", OleDbType.Boolean))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@id", OleDbType.VarChar))

        Dim eliminar As New OleDbCommand("DELETE * FROM REMISION WHERE id=@id", conexion)
        adaptador.DeleteCommand = eliminar
        adaptador.DeleteCommand.Parameters.Add(New OleDbParameter("@id", OleDbType.VarChar))

        conexion.Open()
        adaptador.Fill(datos, "REMISION")
        adaptadorCliente.Fill(datos, "CLIENTE")
        adaptadorContrato.Fill(datos, "CONTRATO")
        adaptadorMaquina.Fill(datos, "MAQUINA")
        adaptadorMaterial.Fill(datos, "MATERIAL")
        adaptadorEmpleado.Fill(datos, "EMPLEADO")
        conexion.Close()

        dgvRemision.DataSource = datos.Tables("REMISION")
        dgvRemision.Columns("id").Visible = False

        txtNumero.DataBindings.Add(New Binding("Text", datos.Tables("REMISION"), "numero"))
        dtpFecha.DataBindings.Add(New Binding("Text", datos.Tables("REMISION"), "Fecha"))
        cboCliente.DataBindings.Add(New Binding("Text", datos.Tables("REMISION"), "cliente"))
        cboContrato.DataBindings.Add(New Binding("Text", datos.Tables("REMISION"), "contrato"))
        cboMaquina.DataBindings.Add(New Binding("Text", datos.Tables("REMISION"), "marca"))
        txtSerie.DataBindings.Add(New Binding("Text", datos.Tables("REMISION"), "serie"))
        cboMaterial.DataBindings.Add(New Binding("Text", datos.Tables("REMISION"), "material"))
        cboFormaPago.DataBindings.Add(New Binding("Text", datos.Tables("REMISION"), "formaPago"))
        cboEmpleado.DataBindings.Add(New Binding("Text", datos.Tables("REMISION"), "operador"))
        txtConductor.DataBindings.Add(New Binding("Text", datos.Tables("REMISION"), "conductor"))
        txtPlaca.DataBindings.Add(New Binding("Text", datos.Tables("REMISION"), "placa"))
        txtHoraDespacho.DataBindings.Add(New Binding("Text", datos.Tables("REMISION"), "horaDespacho"))
        txtMt3Dig.DataBindings.Add(New Binding("Text", datos.Tables("REMISION"), "mt3Dig"))
        txtMt3Cap.DataBindings.Add(New Binding("Text", datos.Tables("REMISION"), "mt3Cap"))
        txtMorro.DataBindings.Add(New Binding("Text", datos.Tables("REMISION"), "morro"))
        chkActivo.DataBindings.Add("Checked", datos.Tables("REMISION"), "activo")

        Call cargaCombox()

        Dim sqlPLaca As String = "SELECT placa FROM VEHICULO"
        Busqueda.busqueda(txtPlaca, sqlPLaca)

        bmb = BindingContext(datos.Tables("REMISION"))
        Call registro()
    End Sub

    Private Sub cargaCombox()
        cboCliente.DataSource = datos.Tables("CLIENTE")
        cboCliente.DisplayMember = "cliente"
        cboCliente.ValueMember = "id"

        cboContrato.DataSource = datos.Tables("CONTRATO")
        cboContrato.DisplayMember = "contrato"
        cboContrato.ValueMember = "id"

        cboMaquina.DataSource = datos.Tables("MAQUINA")
        cboMaquina.DisplayMember = "marca"
        cboMaquina.ValueMember = "id"

        cboMaterial.DataSource = datos.Tables("MATERIAL")
        cboMaterial.DisplayMember = "descripcion"
        cboMaterial.ValueMember = "id"

        cboEmpleado.DataSource = datos.Tables("EMPLEADO")
        cboEmpleado.DisplayMember = "nombres"
        cboEmpleado.ValueMember = "id"
    End Sub

    Private Sub cboMaquina_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboMaquina.SelectedIndexChanged
        Try
            txtSerie.Text = datos.Tables("MAQUINA").Rows(cboMaquina.SelectedIndex)(1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub registro()
        txtRegistro.Text = "Registro " & (bmb.Position + 1) & " de " & datos.Tables(0).Rows.Count
    End Sub

    Private Sub btnPri_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPri.Click
        bmb.Position = 0
        Call registro()
    End Sub

    Private Sub btnAnt_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAnt.Click
        bmb.Position -= 1
        Call registro()
    End Sub

    Private Sub btnSig_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSig.Click
        bmb.Position += 1
        Call registro()
    End Sub

    Private Sub btnUlt_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUlt.Click
        bmb.Position = datos.Tables("REMISION").Rows.Count
        Call registro()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNuevo.Click
        txtNumero.Clear()
        txtPlaca.Clear()
        cboFormaPago.Text = "CREDITO"
        txtConductor.Clear()
        txtHoraDespacho.Text = DateAndTime.TimeString.ToString()
        chkActivo.checked = True

        btnNuevo.Enabled = False
        btnInsertar.Enabled = True

        txtNumero.Focus()
    End Sub

    Private Sub btnInsertar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnInsertar.Click
        If cboCliente.Text = "" Or cboContrato.Text = "" Or cboMaterial.Text = "" Or txtNumero.Text = "" Or txtPlaca.Text = "" Or txtHoraDespacho.Text = "" Or txtMt3Dig.Text = "" Or txtMt3Dig.Text = "0" Then
            MessageBox.Show("Llene todos los campos ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                adaptador.InsertCommand.Parameters("@numero").Value = txtNumero.Text.ToString()
                adaptador.InsertCommand.Parameters("@fecha").Value = dtpFecha.Text
                adaptador.InsertCommand.Parameters("@idCliente").Value = cboCliente.SelectedValue
                adaptador.InsertCommand.Parameters("@idContrato").Value = cboContrato.SelectedValue
                adaptador.InsertCommand.Parameters("@idMaquina").Value = cboMaquina.SelectedValue
                adaptador.InsertCommand.Parameters("@serie").Value = txtSerie.Text
                adaptador.InsertCommand.Parameters("@idMaterial").Value = cboMaterial.SelectedValue
                adaptador.InsertCommand.Parameters("@formaPago").Value = cboFormaPago.Text
                adaptador.InsertCommand.Parameters("@idEmpleado").Value = cboEmpleado.SelectedValue
                adaptador.InsertCommand.Parameters("@conductor").Value = txtConductor.Text
                adaptador.InsertCommand.Parameters("@placa").Value = txtPlaca.Text
                adaptador.InsertCommand.Parameters("@horaDespacho").Value = txtHoraDespacho.Text
                adaptador.InsertCommand.Parameters("@mt3Dig").Value = txtMt3Dig.Text
                adaptador.InsertCommand.Parameters("@mt3Cap").Value = txtMt3Cap.Text
                adaptador.InsertCommand.Parameters("@morro").Value = txtMorro.Text
                adaptador.InsertCommand.Parameters("@activo").Value = chkActivo.CheckState

                conexion.Open()
                Dim i As Integer = adaptador.InsertCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Datos insertados", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "REMISION")
                adaptadorCliente.Fill(datos, "CLIENTE")
                adaptadorContrato.Fill(datos, "CONTRATO")
                adaptadorEmpleado.Fill(datos, "EMPLEADO")
                adaptadorMaquina.Fill(datos, "MAQUINA")
                adaptadorMaterial.Fill(datos, "MATERIAL")
                dgvRemision.Refresh()

                bmb.Position = datos.Tables("REMISION").Rows.Count

                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If

    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        If txtNumero.Text = "" Then 'Or txtPlaca.Text = "" Or txtHoraDespacho.Text = "" Then
            MessageBox.Show("Llene todos los campos ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                adaptador.UpdateCommand.Parameters("@numero").Value = txtNumero.Text.ToString()
                adaptador.UpdateCommand.Parameters("@fecha").Value = dtpFecha.Text
                adaptador.UpdateCommand.Parameters("@idCliente").Value = cboCliente.SelectedValue
                adaptador.UpdateCommand.Parameters("@idContrato").Value = cboContrato.SelectedValue
                adaptador.UpdateCommand.Parameters("@idMaquina").Value = cboMaquina.SelectedValue
                adaptador.UpdateCommand.Parameters("@serie").Value = txtSerie.Text
                adaptador.UpdateCommand.Parameters("@idMaterial").Value = cboMaterial.SelectedValue
                adaptador.UpdateCommand.Parameters("@formaPago").Value = cboFormaPago.Text
                adaptador.UpdateCommand.Parameters("@idEmpleado").Value = cboEmpleado.SelectedValue
                adaptador.UpdateCommand.Parameters("@conductor").Value = txtConductor.Text
                adaptador.UpdateCommand.Parameters("@placa").Value = txtPlaca.Text
                adaptador.UpdateCommand.Parameters("@horaDespacho").Value = txtHoraDespacho.Text
                adaptador.UpdateCommand.Parameters("@mt3Dig").Value = txtMt3Dig.Text
                adaptador.UpdateCommand.Parameters("@mt3Cap").Value = txtMt3Cap.Text
                adaptador.UpdateCommand.Parameters("@morro").Value = txtMorro.Text
                adaptador.UpdateCommand.Parameters("@activo").Value = chkActivo.CheckState
                adaptador.UpdateCommand.Parameters("@id").Value = dgvRemision.CurrentRow.Cells("id").Value

                conexion.Open()
                Dim i As Integer = adaptador.UpdateCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Datos actualizados", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "REMISION")
                adaptadorCliente.Fill(datos, "CLIENTE")
                adaptadorContrato.Fill(datos, "CONTRATO")
                adaptadorEmpleado.Fill(datos, "EMPLEADO")
                adaptadorMaquina.Fill(datos, "MAQUINA")
                adaptadorMaterial.Fill(datos, "MATERIAL")
                dgvRemision.Refresh()

                bmb.Position = datos.Tables("REMISION").Rows.Count

                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

#Region "VALIDACION DE DATOS"
    Private Sub txtPlaca_TextChanged(sender As Object, e As EventArgs) Handles txtPlaca.TextChanged
        Try
            Using conexion As New OleDbConnection(ConexionDatos.conectar())
                Dim sql As String = "SELECT MT3, id FROM VEHICULO WHERE placa LIKE '%" + txtPlaca.Text + "%' "
                Dim adaptador As New OleDbDataAdapter(sql, conexion)

                Dim datos As New DataSet()

                conexion.Open()
                adaptador.Fill(datos)
                conexion.Close()

                txtMt3Cap.Text = datos.Tables(0).Rows(0)("mt3").ToString()
                txtIdVehiculo.Text = datos.Tables(0).Rows(0)("id").ToString()
            End Using
        Catch ex As Exception
            txtMt3Cap.Text = "0"
        End Try
    End Sub

    'MORRO RESTA DE DIG - CAP
    Private Sub mt3()
        Dim mt3Cap As Double = Convert.ToDouble(txtMt3Cap.Text)
        Dim mt3Dig As Double = Convert.ToDouble(txtMt3Dig.Text)
        Dim morro As Double

        morro = mt3Dig - mt3Cap
        txtMorro.Text = morro.ToString()
    End Sub

    Private Sub txtMt3Cap_TextChanged(sender As Object, e As EventArgs) Handles txtMt3Cap.TextChanged
        txtMt3Dig.Text = txtMt3Cap.Text
    End Sub

    REM validacion de No Remision
    Private Sub txtNumero_Validated(sender As Object, e As EventArgs) Handles txtNumero.Validated
        If txtNumero.Text = "" Then
            ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
            ErrorProvider1.SetError(txtNumero, "Digite la placa")
            txtNumero.Focus()
        Else
            ErrorProvider1.SetError(txtNumero, "")
            Call mt3()
        End If
    End Sub

    REM valacion de la placa
    Private Sub txtPlaca_Validated(sender As Object, e As EventArgs) Handles txtPlaca.Validated
        If txtPlaca.Text = "" Then
            ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
            ErrorProvider1.SetError(txtPlaca, "Digite la placa")
            txtPlaca.Focus()
        Else
            ErrorProvider1.SetError(txtPlaca, "")
            Call mt3()
        End If
    End Sub

    REM validacion de metros 3 digitados
    Private Sub txtMt3Dig_Validated(sender As Object, e As EventArgs) Handles txtMt3Dig.Validated
        If txtMt3Dig.Text = "" Or txtMt3Dig.Text = "0" Or IsNumeric(txtMt3Dig.Text) = False Then
            ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
            ErrorProvider1.SetError(txtMt3Dig, "Digite un valor numerico")
            txtMt3Dig.Focus()
        Else
            Call mt3()
            ErrorProvider1.SetError(txtMt3Dig, "")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If MessageBox.Show("Esta seguro de eliminar este registro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                adaptador.DeleteCommand.Parameters("@id").Value = dgvRemision.CurrentRow.Cells("id").Value

                conexion.Open()
                Dim i As Integer = adaptador.DeleteCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registro eliminado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "REMISION")
                adaptadorCliente.Fill(datos, "CLIENTE")
                adaptadorContrato.Fill(datos, "CONTRATO")
                adaptadorEmpleado.Fill(datos, "EMPLEADO")
                adaptadorMaquina.Fill(datos, "MAQUINA")
                adaptadorMaterial.Fill(datos, "MATERIAL")
                dgvRemision.Refresh()

                bmb.Position = 1
                bmb.Position = 0

                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub cboCliente_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCliente.SelectionChangeCommitted
        Dim sql2 As String = "SELECT id, contrato FROM contrato WHERE activo = true AND idCliente = " + cboCliente.SelectedValue.ToString()
        Dim comando As New OleDbCommand(sql2, conexion)
        tblCOntrato = New DataTable()

        Dim adaptadorCont = New OleDbDataAdapter(comando)
        adaptadorCont.Fill(tblCOntrato)

        cboContrato.DataSource = tblCOntrato
        cboContrato.DisplayMember = "contrato"
        cboContrato.ValueMember = "id"

        'Me.Text = cboContrato.SelectedIndex
    End Sub

    Private Sub cboContrato_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboContrato.SelectionChangeCommitted
        Dim sql2 As String = "SELECT MA.id, descripcion FROM MATERIAL AS MA, VENTA AS VE WHERE MA.id = VE.idMaterial AND VE.idContrato = " + cboContrato.SelectedValue.ToString()
        Dim comando As New OleDbCommand(sql2, conexion)
        tblMaterial = New DataTable()

        Dim adaptadorCont = New OleDbDataAdapter(comando)
        adaptadorCont.Fill(tblMaterial)

        cboMaterial.DataSource = tblMaterial
        cboMaterial.DisplayMember = "descripcion"
        cboMaterial.ValueMember = "id"
    End Sub
#End Region

    Private Sub btnExportarExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportarExcel.Click
        Dim exportarExcel As New ExportarExcel()
        exportarExcel.ExportarExcel(dgvRemision)
    End Sub

    Private Sub btnExcelFiltro_Click(sender As System.Object, e As System.EventArgs) Handles btnExcelFiltro.Click
        FrmRemisionFiltro.Show()
    End Sub

End Class