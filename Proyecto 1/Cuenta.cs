using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    public abstract class Cuenta
    {
        public string Id { get; set; }
        public decimal Saldo { get; set; }
        public Cliente Titular { get; set; }

        public Cuenta()
        {
            Saldo = 0;
        }

        public virtual void Depositar(decimal monto)
        {
            if (monto <= 0)
                throw new Exception("El monto a depositar debe ser mayor a cero.");

            Saldo += monto;
        }

        public abstract void Retirar(decimal monto);

        public virtual decimal ConsultarSaldo()
        {
            return Saldo;
        }

        public abstract string ObtenerTipoCuenta();

        public override string ToString()
        {
            return $"[{ObtenerTipoCuenta()}] Cuenta: {Id} | Titular: {Titular.Nombre} {Titular.Apellido} | Saldo: {Saldo:C}";
        }
    }
}
