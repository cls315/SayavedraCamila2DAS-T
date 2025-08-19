using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    public class Banco
    {
        private ListaCuenta lista = new ListaCuenta();
        private List<Cliente> clientes = new List<Cliente>();
        private List<Operacion> operaciones = new List<Operacion>();
        public string Nombre { get; set; }
        
        public Banco()
        {
            Nombre = "Banco Nacional";
        }

        public void AgregarCliente(Cliente cliente)
        {
            if (clientes.Any(c => c.Dni == cliente.Dni))
                throw new Exception("Ya existe un cliente con ese DNI.");
            clientes.Add(cliente);
        }

        public void ModificarCliente(string dni, string nombre, string apellido, string telefono, string email)
        {
            var cliente = clientes.FirstOrDefault(c => c.Dni == dni);
            if (cliente == null)
                throw new Exception("Cliente no encontrado");

            cliente.Nombre = nombre;
            cliente.Apellido = apellido;
            cliente.NumTelefono = telefono;
            cliente.Email = email;
        }

        public void EliminarCliente(string dni)
        {
            var cliente = clientes.FirstOrDefault(c => c.Dni == dni);
            if (cliente == null) throw new Exception("Cliente no encontrado.");
            if (lista.ObtenerTodasLasCuentas().Any(c => c.Titular.Dni == dni))
                throw new Exception("No se peude eliminar un cliente con cuentas activas.");
            clientes.Remove(cliente);
        }

        public List<Cliente> ObtenerClientes()
        {
            return clientes.ToList();
        }

        public Cliente BuscarClientePorDni(string dni)
        {
            return clientes.FirstOrDefault(c => c.Dni == dni);
        }

        public List<Cliente> BuscarClientePorNombre(string nombre)
        {
            return clientes.Where(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void CrearCuentaAhorros(string numeroCuenta, Cliente titular)
        {
            var cuenta = new CajaAhorro
            {
                Id = numeroCuenta,
                Titular = titular
            };

            lista.AgregarCuenta(cuenta);
        }

        public void CrearCuentaCorriente(string numeroCuenta, Cliente titular)
        {
            var cuenta = new CuentaCorriente
            {
                Id = numeroCuenta,
                Titular = titular
            };

            lista.AgregarCuenta(cuenta);
        }

        public void EliminarCuenta(string numeroCuenta)
        {
            lista.EliminarCuenta(numeroCuenta);
        }

        public Cuenta BuscarCuenta(string numeroCuenta)
        {
            return lista.BuscarCuenta(numeroCuenta);
        }

        public List<Cuenta> ObtenerTodasLasCuentas()
        {
            return lista.ObtenerTodasLasCuentas();
        }

        public List<Operacion> ObtenerOperaciones()
        {
            return operaciones.ToList();
        }

        public void Depositar(string numeroCuenta, decimal monto)
        {
            var cuenta = BuscarCuenta(numeroCuenta);
            if (cuenta == null) throw new Exception("Cuenta no encontrada.");

            cuenta.Depositar(monto);
            operaciones.Add(new Operacion { Fecha = DateTime.Now, Tipo = "Depósito", Cuenta = cuenta, Importe = monto });
        }

        public void Retirar(string numeroCuenta, decimal monto)
        {
            var cuenta = BuscarCuenta(numeroCuenta);
            if (cuenta == null) throw new Exception("Cuenta no encontrada.");

            cuenta.Retirar(monto);
            operaciones.Add(new Operacion { Fecha = DateTime.Now, Tipo = "Retiro", Cuenta = cuenta, Importe = monto });
        }
    }
}
