Imports System.Data
Imports System.Data.OleDb

Public Class FrmHorometro_Tanqueo
    Dim conexion As OleDbConnection
    Dim adaptador As OleDbDataAdapter
    Dim adaptador2 As OleDbDataAdapter
    Dim construct As OleDbCommandBuilder
    Dim datos As DataSet
    Dim tabla As DataSet
    Dim bmb As BindingManagerBase

    Dim sql As String = "SELECT marca, idMaquina, fecha, HorometroIni, HorometroFin, HorometroTotal, galones1, horaIni, galones2, horaFin, horas, HT.id FROM MAQUINA AS MA, HOROMETRO_TANQUEO AS HT WHERE MA.id=HT.idMaquina ORDER BY HT.id"
    Dim sql2 As String = "SELECT marca, id FROM MAQUINA"

    Private Sub FrmHorometro_Tanqueo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter(sql, conexion)
        adaptador2 = New OleDbDataAdapter(sql2, conexion)
        construct = New OleDbCommandBuilder(adaptador)

        datos = New DataSet()

        Dim insertar As New OleDbCommand("INSERT INTO HOROMETRO_TANQUEO(idMaquina, fecha, HorometroIni, HorometroFin, galones1, horaIni, galones2, horaFin) VALUES(@idMaquina, @fecha, @HorometroIni, @HorometroFin, @galones1, @horaIni, @galones2, @horaFin)", conexion)
        adaptador.InsertCommand = insertar
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@idMaquina", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@fecha", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@HorometroIni", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@HorometroFin", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@galones1", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@horaIni", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@galones2", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@horaFin", OleDbType.VarChar))

        Dim actualizar As New OleDbCommand("UPDATE HOROMETRO_TANQUEO SET idMaquina=@idMaquina, fecha=@fecha, HorometroIni=@HorometroIni, HorometroFin=@HorometroFin, galones1=@galones1, horaIni=@horaIni, galones2=@galones2, horaFin=@horaFin WHERE id=@id", conexion)
        adaptador.UpdateCommand = actualizar
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@idMaquina", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@fecha", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@HorometroIni", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@HorometroFin", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@galones1", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@horaIni", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@galones2", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@horaFin", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@id", OleDbType.VarChar))

        Dim eliminar As New OleDbCommand("DELETE * FROM HOROMETRO_TANQUEO WHERE id=@id", conexion)
        adaptador.DeleteCommand = eliminar
        adaptador.DeleteCommand.Parameters.Add(New OleDbParameter("@id", OleDbType.VarChar))

        conexion.Open()
        adaptador.Fill(datos, "HOROMETRO_TANQUEO")
        adaptador2.Fill(datos, "MAQUINA")
        conexion.Close()

        cboMaquina.DataBindings.Add(New Binding("Text", datos.Tables("HOROMETRO_TANQUEO"), "marca"))
        dtpFecha.DataBindings.Add(New Binding("Text", datos.Tables("HOROMETRO_TANQUEO"), "fecha"))
        txtHorometroIni.DataBindings.Add(New Binding("Text", datos.Tables("HOROMETRO_TANQUEO"), "horometroIni"))
        txtHorometroFin.DataBindings.Add(New Binding("Text", datos.Tables("HOROMETRO_TANQUEO"), "horometroFin"))
        txtHorometroTotal.DataBindings.Add(New Binding("Text", datos.Tables("HOROMETRO_TANQUEO"), "horometroTotal"))
        txtGalones1.DataBindings.Add(New Binding("Text", datos.Tables("HOROMETRO_TANQUEO"), "galones1"))
        txtHoraIni.DataBindings.Add(New Binding("Text", datos.Tables("HOROMETRO_TANQUEO"), "horaIni"))
        txtGalones2.DataBindings.Add(New Binding("Text", datos.Tables("HOROMETRO_TANQUEO"), "galones2"))
        txtHoraFin.DataBindings.Add(New Binding("Text", datos.Tables("HOROMETRO_TANQUEO"), "horaFin"))
        txtHoras.DataBindings.Add(New Binding("Text", datos.Tables("HOROMETRO_TANQUEO"), "horas"))

        dgvHorometroTanqueo.DataSource = datos.Tables("HOROMETRO_TANQUEO")
        dgvHorometroTanqueo.Columns("idMaquina").Visible = False
        dgvHorometroTanqueo.Columns("id").Visible = False

        cboMaquina.DataSource = datos.Tables("MAQUINA")
        cboMaquina.DisplayMember = "marca"
        cboMaquina.ValueMember = "id"

        bmb = BindingContext(datos.Tables("HOROMETRO_TANQUEO"))
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

    Private Sub btnSig_Click(sender As Object, e As EventArgs) Handles btnSig.Click
        bmb.Position += 1
        Call registro()
    End Sub

    Private Sub btnUlt_Click(sender As System.Object, e As System.EventArgs) Handles btnUlt.Click
        bmb.Position = datos.Tables("HOROMETRO_TANQUEO").Rows.Count
        Call registro()
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        txtHorometroIni.Text = "0"
        txtHorometroFin.Text = "0"
        txtHorometroTotal.Text = "0"

        txtGalones1.Text = "0"
        txtHoraIni.Text = "0"
        txtGalones2.Text = "0"
        txtHoraFin.Text = "0"
        txtHoras.Text = "0"

        btnInsertar.Enabled = True
        btnNuevo.Enabled = False

        cboMaquina.Focus()
    End Sub

    Private Sub btnInsertar_Click(sender As System.Object, e As System.EventArgs) Handles btnInsertar.Click
        If txtHorometroIni.Text = "" Or txtHorometroFin.Text = "" Or txtGalones1.Text = "" Or txtGalones2.Text = "" Or txtHoraIni.Text = "" Or txtHoraFin.Text = "" Then
            MessageBox.Show("Llene todos los campos ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                adaptador.InsertCommand.Parameters("@idMaquina").Value = cboMaquina.SelectedValue
                adaptador.InsertCommand.Parameters("@fecha").Value = dtpFecha.Text
                adaptador.InsertCommand.Parameters("@HorometroIni").Value = txtHorometroIni.Text
                adaptador.InsertCommand.Parameters("@HorometroFin").Value = txtHorometroFin.Text
                adaptador.InsertCommand.Parameters("@galones1").Value = txtGalones1.Text
                adaptador.InsertCommand.Parameters("@horaIni").Value = txtHoraIni.Text
                adaptador.InsertCommand.Parameters("@galones2").Value = txtGalones2.Text
                adaptador.InsertCommand.Parameters("@horaFin").Value = txtHoraFin.Text

                conexion.Open()
                Dim i As Integer = adaptador.InsertCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registros añadidos", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "HOROMETRO_TANQUEO")
                adaptador2.Fill(datos, "MAQUINA")
                dgvHorometroTanqueo.Refresh()

                bmb.Position = datos.Tables("HOROMETRO_TANQUEO").Rows.Count
                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If

    End Sub

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        If txtHorometroIni.Text = "" Or txtHorometroFin.Text = "" Or txtGalones1.Text = "" Or txtGalones2.Text = "" Or txtHoraIni.Text = "" Or txtHoraFin.Text = "" Then
            MessageBox.Show("Llene todos los campos ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                adaptador.UpdateCommand.Parameters("@idMaquina").Value = cboMaquina.SelectedValue
                adaptador.UpdateCommand.Parameters("@fecha").Value = dtpFecha.Text
                adaptador.UpdateCommand.Parameters("@HorometroIni").Value = txtHorometroIni.Text
                adaptador.UpdateCommand.Parameters("@HorometroFin").Value = txtHorometroFin.Text
                adaptador.UpdateCommand.Parameters("@galones1").Value = txtGalones1.Text
                adaptador.UpdateCommand.Parameters("@horaIni").Value = txtHoraIni.Text
                adaptador.UpdateCommand.Parameters("@galones2").Value = txtGalones2.Text
                adaptador.UpdateCommand.Parameters("@horaFin").Value = txtHoraFin.Text
                adaptador.UpdateCommand.Parameters("@id").Value = dgvHorometroTanqueo.CurrentRow.Cells("id").Value

                conexion.Open()
                Dim i As Integer = adaptador.UpdateCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registro actualizado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "HOROMETRO_TANQUEO")
                adaptador2.Fill(datos, "MAQUINA")
                dgvHorometroTanqueo.Refresh()

                bmb.Position = datos.Tables("HOROMETRO_TANQUEO").Rows.Count
                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If MessageBox.Show("Esta seguro de eliminar este registro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                adaptador.DeleteCommand.Parameters("@id").Value = dgvHorometroTanqueo.CurrentRow.Cells("id").Value

                conexion.Open()
                Dim i As Integer = adaptador.DeleteCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registro eliminado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnInsertar.Enabled = False
                btnNuevo.Enabled = True

                datos.Clear()
                adaptador.Fill(datos, "HOROMETRO_TANQUEO")
                adaptador2.Fill(datos, "MAQUINA")
                dgvHorometroTanqueo.Refresh()

                Call registro()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub txtHorometroIni_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtHorometroIni.Validating
        If txtHorometroIni.Text = "" Or IsNumeric(txtHorometroIni.Text) = False Then
            ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
            ErrorProvider1.SetError(txtHorometroIni, "Digite horometro inicial")
            txtHorometroIni.Focus()
        Else
            ErrorProvider1.SetError(txtHorometroIni, "")
            Call HorometroTotal()
        End If
    End Sub

    Private Sub txtHorometroFin_Validated(sender As Object, e As EventArgs) Handles txtHorometroFin.Validated
        If txtHorometroFin.Text = "" Or IsNumeric(txtHorometroFin.Text) = False Then
            ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
            ErrorProvider1.SetError(txtHorometroFin, "Digite el horometro final")
            txtHorometroIni.Focus()
        Else
            ErrorProvider1.SetError(txtHorometroFin, "")
            Call HorometroTotal()
        End If
    End Sub

    Private Sub HorometroTotal()
        Dim hi As Double = Convert.ToDouble(txtHorometroIni.Text)
        Dim hf As Double = Convert.ToDouble(txtHorometroFin.Text)
        Dim ht As Double

        ht = hf - hi

        txtHorometroTotal.Text = ht.ToString()
    End Sub

    Private Sub txtHoraIni_Validated(sender As Object, e As EventArgs) Handles txtHoraIni.Validated
        If txtHoraIni.Text = "" Or IsNumeric(txtHoraIni.Text) = False Then
            ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
            ErrorProvider1.SetError(txtHoraIni, "Digite la hora inicial")
            txtHoraIni.Focus()
        Else
            ErrorProvider1.SetError(txtHorometroFin, "")
            Call Horas()
        End If
    End Sub

    Private Sub txtHoraFin_Validated(sender As Object, e As EventArgs) Handles txtHoraFin.Validated
        If txtHoraFin.Text = "" Or IsNumeric(txtHoraFin.Text) = False Then
            ErrorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink
            ErrorProvider1.SetError(txtHoraFin, "Digite la hora final")
            txtHoraFin.Focus()
        Else
            ErrorProvider1.SetError(txtHoraFin, "")
            Call Horas()
        End If
    End Sub

    Private Sub Horas()
        Dim hi As Double = Convert.ToDouble(txtHoraIni.Text)
        Dim hf As Double = Convert.ToDouble(txtHoraFin.Text)
        Dim h As Double

        h = hf - hi

        txtHoras.Text = h.ToString()
    End Sub

    Private Sub btnExportarExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportarExcel.Click
        Dim exportarExcel As New ExportarExcel()
        exportarExcel.ExportarExcel(dgvHorometroTanqueo)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If dgvHorometroTanqueo.Rows.Count = 0 Then
            MessageBox.Show("No existen registros para mostrar las ventas ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            FrmMaquinaVentas.MdiParent = FrmMenu
            FrmMaquinaVentas.Show()
            FrmMaquinaVentas.txtIdHT.Text = dgvHorometroTanqueo.CurrentRow.Cells("id").Value.ToString()
        End If
    End Sub

    Private Sub btnCaja_Click(sender As Object, e As EventArgs) Handles btnCaja.Click
        If dgvHorometroTanqueo.Rows.Count = 0 Then
            MessageBox.Show("No existen registros para mostrar las ventas ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            FrmCaja.MdiParent = FrmMenu
            FrmCaja.Show()
            FrmCaja.txtIdHorometro.Text = dgvHorometroTanqueo.CurrentRow.Cells("id").Value.ToString()
        End If
    End Sub
End Class

