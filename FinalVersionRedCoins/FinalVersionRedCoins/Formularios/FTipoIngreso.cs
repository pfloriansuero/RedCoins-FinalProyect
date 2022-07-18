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

namespace FinalVersionRedCoins
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool Editar;
        int IDTipoIngreso;


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!validacion()) return;
            {

            }
            if (!guardar()) return;

            finalizar();
            
        }

        private void finalizar()
        {
            ListarGrid();
            limpiar();
        }

        private void limpiar()
        {
            txtIngreso.Text = "";
            Editar = false;
        }

        private bool guardar()
        {
            TipoIngreso tipoIngreso = new TipoIngreso
            {
                Denominacion = txtIngreso.Text,
                IDTipoIngreso = IDTipoIngreso
            };

           return TipoIngreso.Guardar(tipoIngreso, Editar);
        }

        private bool validacion()
        {
            if (string.IsNullOrEmpty(txtIngreso.Text)) 
            {
                MessageBox.Show("Ingresa la Denominacion correspondiente");
                return false;
            }

            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListarGrid();
        }

        private void ListarGrid()
        {
            dgvDatos.DataSource = TipoIngreso.Listar();
            DBDatos.OcultarIds(dgvDatos);
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDTipoIngreso = Convert.ToInt32(dgvDatos.CurrentRow.Cells["IDTipoIngreso"].Value);
            txtIngreso.Text = dgvDatos.CurrentRow.Cells["Denominacion"].Value.ToString();
            Editar = true;
        }
    }
}
