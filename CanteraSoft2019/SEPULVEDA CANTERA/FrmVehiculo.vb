Imports System.Data
Imports System.Data.OleDb

Public Class FrmVehiculo
    Dim conexion As OleDbConnection
    Dim adaptador As OleDbDataAdapter
    Dim adaptador2 As OleDbDataAdapter
    Dim construct As OleDbCommandBuilder
    Dim datos As DataSet
    Dim tabla As DataSet
    Dim bmb As BindingManagerBase

    Dim sql As String = "SELECT placa, mt3, cliente, VEHICULO.activo, idCliente, VEHICULO.id FROM CLIENTE RIGHT JOIN VEHICULO ON CLIENTE.id = VEHICULO.idCliente ORDER BY VEHICULO.id"
    Dim sql2 As String = "SELECT cliente, id FROM CLIENTE WHERE activo = true ORDER BY CLIENTE.id"

    Private Sub FrmVehiculo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter(sql, conexion)
        adaptador2 = New OleDbDataAdapter(sql2, conexion)
        construct = New OleDbCommandBuilder(adaptador)

        datos = New DataSet()

        Dim insertar As New OleDbCommand("INSERT INTO VEHICULO(placa, mt3, activo, idCliente) VALUES(@placa, @mt3, @activo, @idCliente)", conexion)
        adaptador.InsertCommand = insertar
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@placa", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@mt3", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@activo", OleDbType.Boolean))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@idCliente", OleDbType.VarChar))

        Dim actualizar As New OleDbCommand("UPDATE VEHICULO SET placa=@placa, mt3=@mt3, activo=@activo, idCliente=@idCliente WHERE id=@id", conexion)
        adaptador.UpdateCommand = actualizar
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@placa", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@mt3", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@activo", OleDbType.Boolean))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@idCliente", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@id", OleDbType.VarChar))

        Dim eliminar As New OleDbCommand("DELETE * FROM VEHICULO WHERE id=@id", conexion)
        adaptador.DeleteCommand = eliminar
        adaptador.DeleteCommand.Parameters.Add(New OleDbParameter("@id", OleDbType.VarChar))

        conexion.Open()
        adaptador.Fill(datos, "VEHICULO")
        adaptador2.Fill(datos, "CLIENTE")
        conexion.Close()

        txtPlaca.DataBindings.Add(New Binding("Text", datos.Tables("VEHICULO"), "placa"))
        txtMt3.DataBindings.Add(New Binding("Text", datos.Tables("VEHICULO"), "mt3"))
        cboCliente.DataBindings.Add(New Binding("Text", datos.Tables("VEHICULO"), "cliente"))
        chkActivo.DataBindings.Add(New Binding("Checked", datos.Tables("VEHICULO"), "activo"))

        dgvVehiculo.DataSource = datos.Tables("VEHICULO")
        dgvVehiculo.Columns("idCliente").Visible = False
        dgvVehiculo.Columns("id").Visible = False

        cboCliente.DataSource = datos.Tables("CLIENTE")
        cboCliente.DisplayMember = "cliente"
        cboCliente.ValueMember = "id"

        bmb = BindingContext(datos.Tables(0))
        Call registro()
    End Sub

    Private Sub registro()
        txtRegistro.Text = "Registro " & (bmb.Position + 1) & " de " & datos.Tables(0).Rows.Count
    End Sub

    Private Sub btnPri_Click(sender As System.Object, e As System.EventArgs) Handles btnPri.Click
        bmb.Position = 0
        Call registro()
    End Sub

    Private Sub btnAnt_Click(sender As System.Object, e As System.EventArgs) Handles btnAnt.Click
        bmb.Position -= 1
        Call registro()
    End Sub

    Private Sub btnSigg_Click(sender As System.Object, e As System.EventArgs) Handles btnSigg.Click
        bmb.Position += 1
        Call registro()
    End Sub

    Private Sub btnUlt_Click(sender As System.Object, e As System.EventArgs) Handles btnUlt.Click
        bmb.Position = datos.Tables("VEHICULO").Rows.Count
        Call registro()
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        txtPlaca.Clear()
        txtMt3.Clear()
        chkActivo.Checked = True

        btnInsertar.Enabled = True
        btnNuevo.Enabled = False

        txtPlaca.Focus()
    End Sub

    Private Sub btnInsertar_Click(sender As System.Object, e As System.EventArgs) Handles btnInsertar.Click
        If txtPlaca.Text = "" Or txtMt3.Text = "" Or IsNumeric(txtMt3.Text) = False Then
            MessageBox.Show("Llene todos los campos o verifique la capacidad sera numerica", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                adaptador.InsertCommand.Parameters("@placa").Value = txtPlaca.Text
                adaptador.InsertCommand.Parameters("@mt3").Value = txtMt3.Text
                adaptador.InsertCommand.Parameters("@activo").Value = chkActivo.CheckState
                adaptador.InsertCommand.Parameters("@idCliente").Value = cboCliente.SelectedValue

                conexion.Open()
                Dim i As Integer = adaptador.InsertCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registros añadidos", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "VEHICULO")
                adaptador2.Fill(datos, "CLIENTE")
                dgvVehiculo.Refresh()

                bmb.Position = datos.Tables("VEHICULO").Rows.Count
                chkActivo.Checked = False
                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        If txtPlaca.Text = "" Or txtMt3.Text = "" Then
            MessageBox.Show("Llene todos los campos ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                adaptador.UpdateCommand.Parameters("@placa").Value = txtPlaca.Text
                adaptador.UpdateCommand.Parameters("@mt3").Value = txtMt3.Text
                adaptador.UpdateCommand.Parameters("@activo").Value = chkActivo.CheckState
                adaptador.UpdateCommand.Parameters("@idCliente").Value = cboCliente.SelectedValue
                adaptador.UpdateCommand.Parameters("@id").Value = dgvVehiculo.CurrentRow.Cells("id").Value

                conexion.Open()
                Dim i As Integer = adaptador.UpdateCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registro actualizado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "VEHICULO")
                adaptador2.Fill(datos, "CLIENTE")
                dgvVehiculo.Refresh()

                bmb.Position = datos.Tables("VEHICULO").Rows.Count
                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If MessageBox.Show("Esta seguro de eliminar este registro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                adaptador.DeleteCommand.Parameters("@id").Value = dgvVehiculo.CurrentRow.Cells("id").Value

                conexion.Open()
                Dim i As Integer = adaptador.DeleteCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registro eliminado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "VEHICULO")
                adaptador2.Fill(datos, "CLIENTE")
                dgvVehiculo.Refresh()

                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscar.TextChanged
        Dim sql As String
        Dim tabla As DataTable

        If cboBuscar.Text = "Placa" Then
            sql = "SELECT placa, mt3, cliente FROM VEHICULO  AS V, CLIENTE AS C WHERE C.id=V.IdCliente AND placa LIKE '%" + txtBuscar.Text + "%' ORDER BY placa"
            adaptador = New OleDbDataAdapter(sql, conexion)

            tabla = New DataTable()

            conexion.Open()
            adaptador.Fill(tabla)
            conexion.Close()

            dgvVehiculoBuscar.DataSource = tabla
            'dgvVehiculoBuscar.Columns("id").Visible = False

        ElseIf cboBuscar.Text = "Cliente" Then
            sql = "SELECT placa, mt3, cliente FROM VEHICULO  AS V, CLIENTE AS C WHERE  C.id=V.IdCliente AND cliente LIKE '%" + txtBuscar.Text + "%' ORDER BY idCliente"
            adaptador = New OleDbDataAdapter(sql, conexion)

            tabla = New DataTable()

            conexion.Open()
            adaptador.Fill(tabla)
            conexion.Close()

            dgvVehiculoBuscar.DataSource = tabla
            'dgvVehiculoBuscar.Columns("id").Visible = False
        End If

        If dgvVehiculoBuscar.Rows.Count < 1 Then
            ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
            ErrorProvider1.SetError(txtBuscar, "No hay registros")
        Else
            ErrorProvider1.SetError(txtBuscar, "")
        End If
    End Sub

    Private Sub btnExportarExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportarExcel.Click
        Dim exportarExcel As New ExportarExcel()
        exportarExcel.ExportarExcel(dgvVehiculo)
    End Sub

End Class