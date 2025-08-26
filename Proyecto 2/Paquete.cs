using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_2
{
    public abstract class Paquete
    {
        public decimal Valor { get; set; }
        public Cliente Cliente { get; set; }
        public abstract string Tipo { get; }
        public List<Canal> Canales { get; set; } = new List<Canal>();

        public abstract void CalcularPorcentaje(decimal monto);

        public override string ToString()
        {
            string clienteInfo = Cliente != null
                ? $"{Cliente.Nombre} {Cliente.Apellido} (ID: {Cliente.IdCliente})"
                : "Sin cliente";

            return $"[Paquete {Tipo}] - Cliente: {clienteInfo}, Valor: {Valor:C}, Canales: {Canales.Count}";
        }
    }
}
