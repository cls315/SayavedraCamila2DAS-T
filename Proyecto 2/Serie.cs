using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_2
{
    public class Serie
    {
        public string Nombre { get; set; }
        public int Temporadas { get; set; }
        public int Episodios { get; set; }
        public int Duracion { get; set; }
        public decimal Ranking { get; set; }
        public string Genero { get; set; }
        public string Director { get; set; }

        public override string ToString()
        {
            return $"{Nombre} ({Genero}) - {Temporadas} teporadas, Ranking: {Ranking}";
        }
    }
}
