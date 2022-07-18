using FinalVersionRedCoins.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalVersionRedCoins.Modelos
{
    internal class Ingreso
    {
        public int IDIngreso { get; set; }
        public string Fecha { get; set; }
        public int IDTipoIngreso { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public static bool Agregar(Ingreso ingreso, bool Editar)
        {
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@Fecha", ingreso.Fecha),
                new Parametro("@IDTipoIngreso", ingreso.IDTipoIngreso),
                new Parametro("@Monto", ingreso.Monto),
                new Parametro("@Descripcion", ingreso.Descripcion),
                new Parametro("@IDIngreso", ingreso.IDIngreso),
                new Parametro("@Editar", Editar),

            };

            return DBDatos.Ejecutar("Ingreso_Agregar", parametros);
        }


    }
}
