using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Proyecto_1
{
    class Program
    {
        private static Banco banco;

        static void Main(string[] args)
        {
            banco = new Banco();
            Console.WriteLine("=== SISTEMA BANCARIO ===");
            Console.WriteLine($"Bienvenido a {banco.Nombre}");
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
                catch (Exception ex)
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
            Console.WriteLine("1. Crear Cliente");
            Console.WriteLine("2. Modificar Cliente");
            Console.WriteLine("3. Eliminar Cliente");
            Console.WriteLine("4. Buscar Cliente por DNI");
            Console.WriteLine("5. Buscar Cliente por Nombre");
            Console.WriteLine("6. Crear Cuenta de Ahorro");
            Console.WriteLine("7. Crear Cuenta Corriente");
            Console.WriteLine("8. Eliminar Cuenta");
            Console.WriteLine("9. Realizar Deposito");
            Console.WriteLine("10. Realizar Retiro");
            Console.WriteLine("11. Consultar Saldo");
            Console.WriteLine("12. Listar Todas las Cuentas");
            Console.WriteLine("13. Listar Todos los Clientes");
            Console.WriteLine("14. Listar Operaciones");
            Console.WriteLine("0. Salir");
            Console.WriteLine();
            Console.Write("Seleccione una opcion: ");
        }

        static int LeerOpcion()
        {
            if (!int.TryParse(Console.ReadLine(), out int opcion))
                throw new Exception("Debe ingresar un número válido.");
            return opcion;
        }

        static bool ProcesarOpcion(int opcion)
        {
            try
            {
                switch (opcion)
                {
                    case 1: AgregarCliente(); break;
                    case 2: ModificarCliente(); break;
                    case 3: EliminarCliente(); break;
                    case 4: BuscarClientePorDni(); break;
                    case 5: BuscarClientePorNombre(); break;
                    case 6: CrearCuentaAhorros(); break;
                    case 7: CrearCuentaCorriente(); break;
                    case 8: EliminarCuenta(); break;
                    case 9: Depositar(); break;
                    case 10: Retirar(); break;
                    case 11: ConsultarSaldo(); break;
                    case 12: ObtenerTodasLasCuentas(); break;
                    case 13: ListarClientes(); break;
                    case 14: ListarOperaciones(); break;
                    case 0:
                        Console.WriteLine("¡Gracias por usar el sistema bancario!");
                        return false;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
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

        // === MÉTODOS DEL MENÚ ===

        static void AgregarCliente()
        {
            Console.WriteLine("\n=== AGREGAR CLIENTE ===");
            Console.Write("DNI: ");
            string dni = Console.ReadLine();

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();

            Console.Write("Numero de Telefono: ");
            string numTelefono = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Fecha de nacimiento (yyyy-MM-dd): ");
            DateTime fechaNacimiento = DateTime.Parse(Console.ReadLine());

            var cliente = new Cliente
            {
                Dni = dni,
                Nombre = nombre,
                Apellido = apellido,
                NumTelefono = numTelefono,
                Email = email,
                FechaNacimiento = fechaNacimiento
            };

            banco.AgregarCliente(cliente);
            Console.WriteLine("Cliente agregado exitosamente.");
        }

        static void ModificarCliente()
        {
            Console.WriteLine("\n=== MODIFICAR CLIENTE ===");
            Console.Write("Ingrese DNI: ");
            string dni = Console.ReadLine();

            Console.Write("Nuevo Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Nuevo Apellido: ");
            string apellido = Console.ReadLine();

            Console.Write("Nuevo Telefono: ");
            string telefono = Console.ReadLine();

            Console.Write("Nuevo Email: ");
            string email = Console.ReadLine();

            banco.ModificarCliente(dni, nombre, apellido, telefono, email);
            Console.WriteLine("Cliente modificado exitosamente.");
        }

        static void EliminarCliente()
        {
            Console.WriteLine("\n=== ELIMINAR CLIENTE ===");
            Console.Write("Ingrese DNI: ");
            string dni = Console.ReadLine();

            banco.EliminarCliente(dni);
            Console.WriteLine("Cliente eliminado exitosamente.");
        }

        static void BuscarClientePorDni()
        {
            Console.Write("\nIngrese DNI: ");
            string dni = Console.ReadLine();

            var cliente = banco.BuscarClientePorDni(dni);
            if (cliente != null)
                Console.WriteLine(cliente);
            else
                Console.WriteLine("Cliente no encontrado.");
        }

        static void BuscarClientePorNombre()
        {
            Console.Write("\nIngrese Nombre: ");
            string nombre = Console.ReadLine();

            var clientes = banco.BuscarClientePorNombre(nombre);
            foreach (var c in clientes)
                Console.WriteLine(c);

            if (clientes.Count == 0)
                Console.WriteLine("No se encontraron clientes.");
        }

        static void CrearCuentaAhorros()
        {
            Console.Write("\nIngrese DNI del titular: ");
            string dni = Console.ReadLine();
            var cliente = banco.BuscarClientePorDni(dni);
            if (cliente == null) throw new Exception("Cliente no encontrado.");

            Console.Write("Ingrese ID de la cuenta: ");
            string id = Console.ReadLine();

            banco.CrearCuentaAhorros(id, cliente);
            Console.WriteLine("Cuenta de ahorro creada exitosamente.");
        }

        static void CrearCuentaCorriente()
        {
            Console.Write("\nIngrese DNI del titular: ");
            string dni = Console.ReadLine();
            var cliente = banco.BuscarClientePorDni(dni);
            if (cliente == null) throw new Exception("Cliente no encontrado.");

            Console.Write("Ingrese ID de la cuenta: ");
            string id = Console.ReadLine();

            banco.CrearCuentaCorriente(id, cliente);
            Console.WriteLine("Cuenta corriente creada exitosamente.");
        }

        static void EliminarCuenta()
        {
            Console.Write("\nIngrese ID de la cuenta: ");
            string id = Console.ReadLine();

            banco.EliminarCuenta(id);
            Console.WriteLine("Cuenta eliminada exitosamente.");
        }

        static void Depositar()
        {
            Console.Write("\nIngrese ID de la cuenta: ");
            string id = Console.ReadLine();

            Console.Write("Ingrese monto a depositar: ");
            decimal monto = decimal.Parse(Console.ReadLine());

            banco.Depositar(id, monto);
            Console.WriteLine("Depósito realizado exitosamente.");
        }

        static void Retirar()
        {
            Console.Write("\nIngrese ID de la cuenta: ");
            string id = Console.ReadLine();

            Console.Write("Ingrese monto a retirar: ");
            decimal monto = decimal.Parse(Console.ReadLine());

            banco.Retirar(id, monto);
            Console.WriteLine("Retiro realizado exitosamente.");
        }

        static void ConsultarSaldo()
        {
            Console.Write("\nIngrese ID de la cuenta: ");
            string id = Console.ReadLine();

            var cuenta = banco.BuscarCuenta(id);
            if (cuenta != null)
                Console.WriteLine($"Saldo actual: {cuenta.ConsultarSaldo():C}");
            else
                Console.WriteLine("Cuenta no encontrada.");
        }

        static void ObtenerTodasLasCuentas()
        {
            Console.WriteLine("\n=== TODAS LAS CUENTAS ===");
            var cuentas = banco.ObtenerTodasLasCuentas();
            foreach (var c in cuentas)
                Console.WriteLine(c);

            if (cuentas.Count == 0)
                Console.WriteLine("No hay cuentas registradas.");
        }

        static void ListarClientes()
        {
            Console.WriteLine("\n=== LISTA DE CLIENTES ===");
            var clientes = banco.ObtenerClientes();
            foreach (var c in clientes)
                Console.WriteLine(c);

            if (clientes.Count == 0)
                Console.WriteLine("No hay clientes registrados.");
        }

        static void ListarOperaciones()
        {
            Console.WriteLine("\n=== HISTORIAL DE OPERACIONES ===");
            var operaciones = banco.ObtenerOperaciones();
            foreach (var op in operaciones)
                Console.WriteLine(op);

            if (operaciones.Count == 0)
                Console.WriteLine("No se registraron operaciones aún.");
        }
    }
}
