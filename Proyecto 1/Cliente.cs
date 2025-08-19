using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    public class Cliente
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumTelefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public int Edad
        {
            get
            {
                var hoy = DateTime.Today;
                int edad = hoy.Year - FechaNacimiento.Year;
                if (FechaNacimiento.Date > hoy.AddYears(-edad)) edad--;
                return edad;
            }
        }

        public override string ToString()
        {
            return $"{Dni} - {Nombre} {Apellido} | Tel: {NumTelefono} | Email: {Email} | Edad_ {Edad}";
        }
    }
}
