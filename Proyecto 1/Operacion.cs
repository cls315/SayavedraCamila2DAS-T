using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    public class Operacion
    {
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public Cuenta Cuenta { get; set; }
        public decimal Importe { get; set; }

        public override string ToString()
        {
            return $"{Fecha:G} - {Tipo} de {Importe:C} en cuenta {Cuenta.Id}";
        }
    }
}
