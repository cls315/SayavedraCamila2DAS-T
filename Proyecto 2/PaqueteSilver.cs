using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_2
{
    public class PaqueteSilver : Paquete
    {
        public int PorcentajeAumento {  get; set; }

        public override string Tipo => "Silver";
        public PaqueteSilver()
        {
            PorcentajeAumento = 15;

            Canales.Add(new Canal("HBO"));
            Canales.Add(new Canal("Netflix"));
        }

        public override void CalcularPorcentaje(decimal monto)
        {
            if (monto == 0)
                throw new Exception("No se puede calcular el porcentaje.");

            Valor = monto + (monto * PorcentajeAumento) / 100;
        }
    }
}
