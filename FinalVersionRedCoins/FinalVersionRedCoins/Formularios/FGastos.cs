using FinalVersionRedCoins.Modelos;
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
    public partial class FGastos : Form
    {
        public FGastos()
        {
            InitializeComponent();
        }

        public int IDGasto;
        public bool Editar;
        public string tipo;

        private void FGastos_Load(object sender, EventArgs e)
        {
            btnGuardar.Text = Editar ? "Actualizar" : "Agregar";
            ListarCombo();

            if (Editar)
            {
                cboTipoGasto.Text = tipo;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!agregar()) return;

            finalizar();
        }

        private bool agregar()
        {
            Gasto Gasto = new Gasto
            {
                Descripcion = txtDescripcion.Text,
                Fecha = dtpFecha.Value.ToShortDateString(),
                Monto = Convert.ToDecimal(txtMonto.Text),
                IDGasto = IDGasto,
                IDTipoGasto = Convert.ToInt32(cboTipoGasto.SelectedValue)
            };

            if(Gasto.Agregar(Gasto, Editar))
            {
                MessageBox.Show("Acción exitosa");
                return true;
            }
            else return false;
        }

        private void finalizar()
        {
            txtDescripcion.Text = "";
            txtMonto.Text = "";
            Editar = false;
            cboTipoGasto.SelectedIndex = -1;
        }

        private void btnTipoGasto_Click(object sender, EventArgs e)
        {
            FTipoGasto frm = new FTipoGasto();
            frm.ShowDialog();
        }

        private void cboTipoGasto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                ListarCombo();
            }

            
        }

        private void ListarCombo()
        {
            TipoGasto.ListarCombo(cboTipoGasto);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            finalizar();
        }
    }
}
