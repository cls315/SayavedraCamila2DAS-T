using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_2
{
    public class PaquetePremium : Paquete
    {
        public int PorcentajeAumento { get; set; }

        public override string Tipo => "Premium";

        public PaquetePremium()
        {
            PorcentajeAumento = 20;

            Canales.Add(new Canal("HBO"));
            Canales.Add(new Canal("Netflix"));
            Canales.Add(new Canal("Disney+"));
        }

        public override void CalcularPorcentaje(decimal monto)
        {
            if (monto == 0)
                throw new Exception("No se puede calcular el porcentaje.");

            Valor = monto + (monto * PorcentajeAumento) / 100;
        }
    }
}
