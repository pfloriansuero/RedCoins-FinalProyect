using FinalVersionRedCoins.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalVersionRedCoins.Formularios
{
    public partial class FPrincipal : Form
    {
        public FPrincipal()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FIngreso frm = new FIngreso();
            frm.ShowDialog();

            ListarMovimiento();
        }

        private void FPrincipal_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            txtAño.Text = DateTime.Now.Year.ToString();
            cboMes.SelectedIndex = (DateTime.Now.Month - 1);
            ListarMovimiento();
           
        }

        private void ResumenIngreso()
        {
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@Mes", (cboMes.SelectedIndex + 1)),
                new Parametro("@Año", txtAño.Text)
            };

            dgvRIngreso.DataSource = DBDatos.Listar("IngresoResumen_Listar", parametros);
        }

        private void ResumenGasto()
        {
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@Mes", (cboMes.SelectedIndex + 1)),
                new Parametro("@Año", txtAño.Text)
            };

            dgvRGastos.DataSource = DBDatos.Listar("GastoResumen_Listar", parametros);
        }

        private void ListarMovimiento()
        {
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@Mes", (cboMes.SelectedIndex + 1)),
                new Parametro("@Año", txtAño.Text)
            };

            dgvMovimiento.DataSource = DBDatos.Listar("Movimiento_Listar", parametros);
            DBDatos.OcultarIds(dgvMovimiento);
            dgvMovimiento.Columns["Movimiento"].Visible = false;
            dgvMovimiento.Columns["Descripcion"].Width = 130;

            pintar();

            ResumenIngreso();

            ResumenGasto();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarMovimiento();
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FGastos frm = new FGastos();
            frm.ShowDialog();
            ListarMovimiento();
        }

        public void pintar()
        {
            decimal TIngreso = 0, TGasto = 0;
            foreach (DataGridViewRow fila in dgvMovimiento.Rows)
            {
                string movimiento = fila.Cells["Movimiento"].Value.ToString();
                decimal monto = Convert.ToDecimal(fila.Cells["Monto"].Value);
                if (movimiento.Equals("I"))
                {
                    fila.DefaultCellStyle.BackColor = Color.LightGreen;
                    TIngreso += monto;
                }
                else
                {
                    fila.DefaultCellStyle.BackColor=Color.LightSalmon;
                    TGasto += monto;
                }
            }

            txtIngreso.Text = TIngreso.ToString("N2");
            txtGasto.Text = TGasto.ToString("N2");
            txtSaldo.Text = (TIngreso - TGasto).ToString("N2");
        }

        private void editarMovimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string movimiento = dgvMovimiento.CurrentRow.Cells["Movimiento"].Value.ToString();
            int idMovimiento = Convert.ToInt32(dgvMovimiento.CurrentRow.Cells["IDMovimiento"].Value);
            string descripcion = dgvMovimiento.CurrentRow.Cells["Descripcion"].Value.ToString();
            string monto = dgvMovimiento.CurrentRow.Cells["monto"].Value.ToString();
            string tipo = dgvMovimiento.CurrentRow.Cells["tipo"].Value.ToString();
            string fecha = dgvMovimiento.CurrentRow.Cells["Fecha"].Value.ToString();

            if (movimiento.Equals("I"))
            {
                FIngreso frm = new FIngreso();
                frm.txtDescripcion.Text = descripcion;
                frm.txtMonto.Text = monto;
                frm.tipo = tipo;
                frm.IDIngreso = idMovimiento;
                frm.Editar = true;
                frm.dtpFecha.Value = Convert.ToDateTime(fecha);
                frm.ShowDialog();
            }
            else
            {
                FGastos frm = new FGastos();
                frm.txtDescripcion.Text = descripcion;
                frm.txtMonto.Text = monto;
                frm.tipo = tipo;
                frm.Editar = true;
                frm.IDGasto = idMovimiento;
                frm.dtpFecha.Value = Convert.ToDateTime(fecha);
                frm.ShowDialog();
            }

            ListarMovimiento();
        }

       
    }
}
