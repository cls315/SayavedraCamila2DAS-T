using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    public class CajaAhorro : Cuenta
    {
        public decimal LimiteExtraccion { get; set; }
        public CajaAhorro() : base()
        {
            LimiteExtraccion = 1000;
        }

        public override void Retirar(decimal monto)
        {
            if (monto <= 0)
                throw new Exception("El monto a retirar debe ser mayor a 0");

            if (monto > LimiteExtraccion)
                throw new Exception($"Ha excedido el limite de extraccion de dinero. Limite: {LimiteExtraccion}");

            if (monto > Saldo)
                throw new Exception("Fondos insuficientes para realizar el retiro.");

            Saldo -= monto;
        }

        public override string ObtenerTipoCuenta()
        {
            return "Caja de Ahorros";
        }
    }
}
