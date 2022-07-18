using FinalVersionRedCoins.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalVersionRedCoins.Modelos
{
    internal class TipoIngreso
    {
        public int IDTipoIngreso { get; set; }
        public string Denominacion { get; set; }

        public static bool Guardar(TipoIngreso tipoIngreso, bool editar)
        {
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@Denominacion", tipoIngreso.Denominacion),
                new Parametro("@IDTipoIngreso", tipoIngreso.IDTipoIngreso),
                new Parametro("@Editar", editar)
            };

           return DBDatos.Ejecutar("TipoIngreso_Agregar", parametros);
        }

        public static DataTable Listar()
        {
            return DBDatos.Listar("TipoIngreso_Listar");
        }

        public static void ListarCombo(ComboBox comboBox)
        {
            DBDatos.ListarCombo(Listar(), "Denominacion", "IDTipoIngreso", comboBox);
        }

    }
}
