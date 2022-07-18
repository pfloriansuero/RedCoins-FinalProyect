using FinalVersionRedCoins.Clases;
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
    public partial class FTipoGasto : Form
    {
        public FTipoGasto()
        {
            InitializeComponent();
        }

        bool Editar;
        int IDTipoGasto;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!validacion()) return;
            {

            }
            if (!guardar()) return;

            finalizar();
        }

        private bool validacion()
        {
            if (string.IsNullOrEmpty(txtGasto.Text))
            {
                MessageBox.Show("Ingresa la Denominacion correspondiente");
                return false;
            }

            return true;
        }

        private bool guardar()
        {
            TipoGasto tipoGasto = new TipoGasto
            {
                Denominacion = txtGasto.Text,
                IDTipoGasto = IDTipoGasto
            };

            return TipoGasto.Guardar(tipoGasto, Editar);
        }

        private void finalizar()
        {
            ListarGrid();
            limpiar();
        }

        private void ListarGrid()
        {
            dgvDatos.DataSource = TipoGasto.Listar();
            DBDatos.OcultarIds(dgvDatos);
        }

        private void limpiar()
        {
            txtGasto.Text = "";
            Editar = false;
        }

        private void FTipoGasto_Load(object sender, EventArgs e)
        {
            ListarGrid();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDTipoGasto = Convert.ToInt32(dgvDatos.CurrentRow.Cells["IDTipoGasto"].Value);
            txtGasto.Text = dgvDatos.CurrentRow.Cells["Denominacion"].Value.ToString();
            Editar = true;
        }
    }
}
