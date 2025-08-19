using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    public class CuentaCorriente : Cuenta
    {
        public decimal LimiteDescubierto { get; set; }
        public CuentaCorriente() : base()
        {
            LimiteDescubierto = 1000;
        }

        public override void Retirar(decimal monto)
        {
            if (monto <= 0)
                throw new Exception("El monto a retirar debe ser mayor a 0.");

            decimal saldoDisponible = Saldo + LimiteDescubierto;

            if (monto > saldoDisponible)
                throw new Exception($"No se puede retirar {monto:C}. " + $"El saldo maximo disponible es {saldoDisponible:C}.");

            Saldo -= monto;
        }

        public decimal ObtenerSaldoDisponible()
        {
            return Saldo + LimiteDescubierto;
        }

        public override string ObtenerTipoCuenta()
        {
            return "Cuenta Corriente";
        }
    }
}
