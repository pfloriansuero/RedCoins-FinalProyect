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
    public partial class FIngreso : Form
    {
        public FIngreso()
        {
            InitializeComponent();
        }
        public int IDIngreso;
        public bool Editar;
        public string tipo;

        private void FIngreso_Load(object sender, EventArgs e)
        {
            btnGuardar.Text = Editar ? "Actualizar" : "Agregar";
            ListarCombo();

            if (Editar)
            {
                cboTipoIngreso.Text = tipo;
            }
        }

        private void ListarCombo()
        {
            TipoIngreso.ListarCombo(cboTipoIngreso);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!agregar()) return;

            finalizar();
            
        }

        private void finalizar()
        {
            txtDescripcion.Text = "";
            txtMonto.Text = "";
            Editar = false;
            cboTipoIngreso.SelectedIndex = -1;
        }

        private bool agregar()
        {
            Ingreso ingreso = new Ingreso
            {
                Descripcion = txtDescripcion.Text,
                Fecha = dtpFecha.Value.ToShortDateString(),
                Monto = Convert.ToDecimal(txtMonto.Text),
                IDIngreso = IDIngreso,
                IDTipoIngreso = Convert.ToInt32(cboTipoIngreso.SelectedValue)
            };

            if (Ingreso.Agregar(ingreso, Editar))
            {
                MessageBox.Show("Acción exitosa");
                return true;
            }
            else return false;
        }

        private void btnTipoIngreso_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
        }

        private void cboTipoIngreso_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                ListarCombo();
            }
        }
    }
}
