Imports System.Data
Imports System.Data.OleDb

Public Class FrmInformeMaquinaDiario
    Dim conexion As OleDbConnection
    Friend adaptador, adaptador2, adaptador3 As OleDbDataAdapter
    Dim comando As OleDbCommand
    Friend datos As DataSet
    Friend datos2 As DataSet
    Dim bmb As BindingManagerBase

    Private Sub FrmInformeMaquinaDiario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion = New OleDbConnection(ConexionDatos.conectar())
        adaptador = New OleDbDataAdapter("SELECT marca, idMaquina, fecha, HorometroIni, HorometroFin, HorometroTotal, galones1, horaIni, galones2, horaFin, horas, HT.id FROM MAQUINA AS MA, HOROMETRO_TANQUEO AS HT WHERE MA.id=HT.idMaquina ORDER BY HT.id", conexion)
        adaptador2 = New OleDbDataAdapter("SELECT marca, fecha, cliente, material, mt3, formaPago, valor, viajes, total, idHorometro, MAQUINA_VENTA.id FROM MAQUINA, HOROMETRO_TANQUEO, MAQUINA_VENTA WHERE MAQUINA.id = HOROMETRO_TANQUEO.idMaquina AND HOROMETRO_TANQUEO.id = MAQUINA_VENTA.idHorometro ORDER BY MAQUINA_VENTA.id", conexion)
        adaptador3 = New OleDbDataAdapter("SELECT concepto, valor, idHorometro, id FROM CAJA", conexion)
        datos = New DataSet()

        conexion.Open()
        adaptador.Fill(datos, "HOROMETRO_TANQUEO")
        adaptador2.Fill(datos, "MAQUINA_VENTA")
        adaptador3.Fill(datos, "CAJA")
        conexion.Close()

        datos.Relations.Add("PK", datos.Tables("HOROMETRO_TANQUEO").Columns("id"), datos.Tables("MAQUINA_VENTA").Columns("idHorometro"))
        datos.Relations.Add("PK2", datos.Tables("HOROMETRO_TANQUEO").Columns("id"), datos.Tables("CAJA").Columns("idHorometro"))

        dgvHorometroTanqueo.DataSource = datos
        dgvHorometroTanqueo.DataMember = "HOROMETRO_TANQUEO"
        dgvHorometroTanqueo.Columns("idMaquina").Visible = False
        dgvHorometroTanqueo.Columns("id").Visible = False

        dgvMaquinaVenta.DataSource = datos
        dgvMaquinaVenta.DataMember = "HOROMETRO_TANQUEO.PK"
        dgvMaquinaVenta.Columns("marca").Visible = False
        dgvMaquinaVenta.Columns("fecha").Visible = False
        dgvMaquinaVenta.Columns("idHorometro").Visible = False
        dgvMaquinaVenta.Columns("id").Visible = False

        dgvCaja.DataSource = datos
        dgvCaja.DataMember = "HOROMETRO_TANQUEO.PK2"
        dgvCaja.Columns("idHorometro").Visible = False
        dgvCaja.Columns("id").Visible = False

        bmb = BindingContext(datos.Tables("HOROMETRO_TANQUEO"))
    End Sub
End Class