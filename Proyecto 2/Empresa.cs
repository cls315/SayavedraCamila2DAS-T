using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_2
{
    public class Empresa
    {
        public string Nombre { get; set; }
        private List<Cliente> Clientes { get; set; } = new List<Cliente>();
        private List<Paquete> PaquetesContratados { get; set; } = new List<Paquete>();
        private ListaPaquete lista = new ListaPaquete();

        public decimal TotalRecaudado()
        {
            return PaquetesContratados.Sum(p => p.Valor);
        }

        public Paquete PaqueteMasVendido()
        {
            return PaquetesContratados.GroupBy(p => p.Tipo).OrderByDescending(g => g.Count()).Select(g => g.First()).FirstOrDefault();
        }

        public List<Serie> SeriesConRankingAlto(decimal minimo)
        {
            return PaquetesContratados.SelectMany(p => p.Canales).SelectMany(c => c.Series).Where(s => s.Ranking > minimo).Distinct().ToList();
        }

        public Cliente BuscarPorId(int id)
        {
            return Clientes.FirstOrDefault(c => c.IdCliente == id);
        }

        public List<Paquete> ObtenerInformacionPaquetes()
        {
            return PaquetesContratados;
        }

        public void AgregarCliente(Cliente cliente)
        {
            if (Clientes.Any(c => c.IdCliente == cliente.IdCliente))
                throw new Exception("Ya existe un cliente con ese ID.");

            if (Clientes.Any(c => c.Dni == cliente.Dni))
                throw new Exception("Cliente ya registrado.");

            Clientes.Add(cliente);
        }

        public void ContratarPaquete(Paquete paquete, int idCliente)
        {
            var cliente = BuscarPorId(idCliente);
            if (cliente == null)
                throw new Exception("Cliente no encontrado.");

            paquete.Cliente = cliente;
            lista.ContratarPaquete(paquete);
            PaquetesContratados.Add(paquete);
        }
    }
}
