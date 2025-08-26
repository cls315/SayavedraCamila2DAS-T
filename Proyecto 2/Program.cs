using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Proyecto_2
{
    class Program
    {
        private static Empresa empresa;
        static void Main(string[] args)
        {
            empresa = new Empresa();
            Console.WriteLine("=== SISTEMAS PAQUETES CANALES ===");
            Console.WriteLine($"Bienvenidos a {empresa.Nombre}");
            Console.WriteLine();

            bool continuar = true;

            while (continuar)
            {
                try
                {
                    MostrarMenu();
                    int opcion = LeerOpcion();
                    continuar = ProcesarOpcion(opcion);
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error inesperado: {ex.Message}");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("=== MENU PRINCIPAL ===");
            Console.WriteLine("1. Ingresar Cliente");
            Console.WriteLine("2. Contratar Servicio");
            Console.WriteLine("3. Informacion de Paquetes");
            Console.WriteLine("4. Paquetes Contratados");
            Console.WriteLine("5. Total Recaudado");
            Console.WriteLine("6. Paquete mas Vendido");
            Console.WriteLine("7. Series con Mayor Ranking");
            Console.WriteLine("0. Salir");
            Console.WriteLine();
            Console.WriteLine("Seleccione una opcion: ");
        }

        static int LeerOpcion()
        {
            if (!int.TryParse(Console.ReadLine(), out int opcion))
                throw new Exception("Debe ingresar un numero valido.");
            return opcion;
        }

        static bool ProcesarOpcion(int opcion)
        {
            try
            {
                switch (opcion)
                {
                    case 1: IngresarCliente(); break;
                    case 2: ContratarServicio(); break;
                    case 3: InformacionPaquete(); break;
                    case 4: PaquetesContratados(); break;
                    case 5: TotalRecaudado(); break;
                    case 6: PaqueteMasVendido(); break;
                    case 7: SeriesConMayorRanking(); break;
                    case 0: Console.WriteLine("¡Gracias por usar el sistema!"); return false;
                    default: Console.WriteLine("Opcion no valida. Intente nuevamente."); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            return true;
        }

        static void IngresarCliente()
        {
            Console.WriteLine("\n=== INGRESAR CLIENTE ===");
            Console.Write("ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();

            Console.Write("DNI: ");
            int dni = Convert.ToInt32(Console.ReadLine());

            Console.Write("Fecha de Nacimiento (yyyy-MM-dd): ");
            DateTime fechaNacimiento = DateTime.Parse(Console.ReadLine());

            var cliente = new Cliente
            {
                IdCliente = id,
                Nombre = nombre,
                Apellido = apellido,
                Dni = dni,
                FechaNacimiento = fechaNacimiento
            };

            empresa.AgregarCliente(cliente);
            Console.WriteLine("Cliente agregado exitosamente.");
        }

        static void ContratarServicio()
        {
            Console.WriteLine("\n=== CONTRATAR SERVICIO ===");

            Console.Write("ID del cliente: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var cliente = empresa.BuscarPorId(id);
            if (cliente == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }

            Console.WriteLine("Seleccione paquete (1. Silver - 2. Premium): ");
            string tipo = Console.ReadLine();

            Paquete paquete;

            if (tipo == "1") 
                paquete = new PaqueteSilver();
            else if (tipo == "2") 
                paquete = new PaquetePremium();
            else
            {
                Console.WriteLine("Opcion invalida.");
                return;
            }

            decimal precioBase = 1000;
            paquete.CalcularPorcentaje(precioBase);

            empresa.ContratarPaquete(paquete, id);

            Console.WriteLine($"El cliente {cliente.Nombre} contrato el paquete {paquete.Tipo} por ${paquete.Valor}");
        }

        static void InformacionPaquete()
        {
            Console.WriteLine("\n=== INFORMACION DE LOS PAQUETES ===");
            
            var paquetes = empresa.ObtenerInformacionPaquetes();

            if (paquetes.Count == 0)
            {
                Console.WriteLine("No hay paquetes contratados.");
                return;
            }

            foreach (var p in paquetes)
            {
                Console.WriteLine(p.ToString());
                foreach (var canal in p.Canales)
                {
                    Console.WriteLine($"Canal: {canal.Nombre}");
                    foreach (var serie in canal.Series)
                    {
                        Console.WriteLine($"Serie: {serie.Nombre} (Ranking: {serie.Ranking})");
                    }
                }

                Console.WriteLine();
            }
        }

        static void PaquetesContratados()
        {
            Console.WriteLine("\n=== PAQUETES CONTRATADOS ===");
            var paquetes = empresa.ObtenerInformacionPaquetes();
            if (!paquetes.Any())
            {
                Console.WriteLine("No hay paquetes contratados.");
                return;
            }

            foreach (var p in paquetes)
                Console.WriteLine(p.ToString());
        }

        static void TotalRecaudado()
        {
            Console.WriteLine("\n=== TOTAL RECAUDADO ===");

            decimal total = empresa.TotalRecaudado();

            Console.WriteLine($"El total recaudado es: ${total}");
        }

        static void PaqueteMasVendido()
        {
            Console.WriteLine("\n=== PAQUETE MAS VENDIDO ===");

            Paquete paquete = empresa.PaqueteMasVendido();

            if (paquete != null)
                Console.WriteLine($"El paquete mas vendido es: {paquete.Tipo}");
            else
                Console.WriteLine("No hay paquetes contratados todavia.");
        }

        static void SeriesConMayorRanking()
        {
            Console.WriteLine("\n=== SERIES CON MAYOR RANKING ===");

            decimal minimo = 8.5m;
            List<Serie> serie = empresa.SeriesConRankingAlto(minimo);

            if (serie.Any())
            {
                Console.WriteLine("Series con ranking alto: ");
                foreach (var s in serie)
                {
                    Console.WriteLine($"{s.Nombre} - Ranking: {s.Ranking}");
                }
            }
            else
            {
                Console.WriteLine("No se encontraron series con ranking alto.");
            }
        }

        static void BuscarPorId()
        {
            Console.WriteLine("\nIngrese ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var cliente = empresa.BuscarPorId(id);
            if (cliente == null)
                Console.WriteLine(cliente);
            else
                Console.WriteLine("Cliente no encontrado.");
        }
    }
}
