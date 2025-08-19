using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    public class ListaCuenta
    {
        private List<Cuenta> cuentas;

        public ListaCuenta()
        {
            cuentas = new List<Cuenta>();
        }

        public void AgregarCuenta(Cuenta cuenta)
        {
            if (cuenta == null)
                throw new Exception("La cuenta no puede ser nula");

            if (string.IsNullOrWhiteSpace(cuenta.Id))
                throw new Exception("El numero de cuenta no puede estar vacio.");

            if (cuenta.Titular == null)
                throw new Exception("La cuenta debe tener un titular.");

            if (ExisteCuenta(cuenta.Id))
                throw new Exception("Ya existe una cuenta con ese ID");

            cuentas.Add(cuenta);
        }

        public Cuenta BuscarCuenta(string numeroCuenta)
        {
            return cuentas.FirstOrDefault(c => c.Id == numeroCuenta);
        }

        public bool ExisteCuenta(string numeroCuenta)
        {
            return cuentas.Any(c => c.Id == numeroCuenta);
        }

        public List<Cuenta> ObtenerTodasLasCuentas()
        {
            return cuentas.ToList();
        }

        public void EliminarCuenta(string numeroCuenta)
        {
            var cuenta = BuscarCuenta(numeroCuenta);
            if (cuenta != null)
            {
                if (cuenta.Saldo != 0)
                    throw new Exception("Solo se pueden eliminar cuentas con saldo igual a cero.");

                cuentas.Remove(cuenta);
            }
        }
    }
}
