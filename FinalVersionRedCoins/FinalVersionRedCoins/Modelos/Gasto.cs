using FinalVersionRedCoins.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalVersionRedCoins.Modelos
{
    internal class Gasto
    {
        public int IDGasto { get; set; }
        public string Fecha { get; set; }
        public int IDTipoGasto { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public static bool Agregar(Gasto Gasto, bool Editar)
        {
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@Fecha", Gasto.Fecha),
                new Parametro("@IDTipoGasto", Gasto.IDTipoGasto),
                new Parametro("@Monto", Gasto.Monto),
                new Parametro("@Descripcion", Gasto.Descripcion),
                new Parametro("@IDGasto", Gasto.IDGasto),
                new Parametro("@Editar", Editar),

            };

            return DBDatos.Ejecutar("Gasto_Agregar", parametros);
        }
    }
}
