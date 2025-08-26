using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_2
{
    public class ListaPaquete
    {
        private List<Paquete> paquetes;

        public ListaPaquete()
        {
            paquetes = new List<Paquete>();
        }

        public void ContratarPaquete(Paquete paquete)
        {
            if (paquete.Cliente == null)
                throw new Exception("Debe seleccionar ID de un cliente para contratar.");

            if (paquete.Tipo != "Premium" && paquete.Tipo != "Silver")
                throw new Exception("Debe elegir un paquete valido (Premium o Silver)");

            paquetes.Add(paquete);
        }
    }
}
