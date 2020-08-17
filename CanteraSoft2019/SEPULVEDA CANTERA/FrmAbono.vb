Imports System.Data
Imports System.Data.OleDb

Public Class FrmAbono
    Dim conexion As OleDbConnection
    Dim adaptador As OleDbDataAdapter
    Dim construct As OleDbCommandBuilder
    Dim datos As DataSet
    Dim bmb As BindingManagerBase

    Dim sql As String = "SELECT * FROM ABONO"

    Private Sub FrmAbono_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter(Sql, conexion)
        construct = New OleDbCommandBuilder(adaptador)
        datos = New DataSet()

        Dim insertar As New OleDbCommand("INSERT INTO ABONO(fecha, valor, notas, idContrato) VALUES(@fecha, @valor, @notas, @idContrato)", conexion)
        adaptador.InsertCommand = insertar
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@fecha", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@valor", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@notas", OleDbType.VarChar))
        adaptador.InsertCommand.Parameters.Add(New OleDbParameter("@idContrato", OleDbType.VarChar))

        Dim actualizar As New OleDbCommand("UPDATE CONTRATO SET totalAbono=totalAbono + @valor WHERE id=@id", conexion)
        adaptador.UpdateCommand = actualizar
        'adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@totalAbono", OleDbType.Double))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@valor", OleDbType.VarChar))
        adaptador.UpdateCommand.Parameters.Add(New OleDbParameter("@id", OleDbType.VarChar))
    End Sub

    Private Sub btnAbonar_Click(sender As System.Object, e As System.EventArgs) Handles btnAbonar.Click
        If txtValor.Text = "" Or txtNotas.Text = "" Or IsNumeric(txtValor.Text) = False Then
            MessageBox.Show("Llene todos los campos o compruebe que el valor insertado es numerico", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                adaptador.InsertCommand.Parameters("@fecha").Value = dtpFecha.Text
                adaptador.InsertCommand.Parameters("@valor").Value = txtValor.Text
                adaptador.InsertCommand.Parameters("@notas").Value = txtNotas.Text
                adaptador.InsertCommand.Parameters("@idContrato").Value = cboContrato.Text

                adaptador.UpdateCommand.Parameters("@valor").Value = txtValor.Text
                adaptador.UpdateCommand.Parameters("@id").Value = cboContrato.Text

                conexion.Open()
                Dim i As Integer = adaptador.InsertCommand.ExecuteNonQuery()
                Dim a As Integer = adaptador.UpdateCommand.ExecuteNonQuery()
                conexion.Close()

                MessageBox.Show(i & " Registro actualizado", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

                FrmContratoVenta.datos.Clear()
                FrmContratoVenta.adaptador.Fill(FrmContratoVenta.datos, "CONTRATO")
                FrmContratoVenta.adaptador2.Fill(FrmContratoVenta.datos, "VENTA")
                FrmContratoVenta.dgvContrato.Refresh()

                FrmContratoVenta.dgvVenta.Refresh()

                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If

    End Sub
End Class