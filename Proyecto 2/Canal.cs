using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_2
{
    public class Canal
    {
        public string Nombre { get; set; }
        public List<Serie> Series { get; set; }

        public Canal(string nombre)
        {
            Nombre = nombre;
            Series = new List<Serie>();

            if (nombre == "HBO")
            {
                Series.Add(new Serie { Nombre = "Game of Thrones", Temporadas = 8, Episodios = 73, Duracion = 60, Ranking = 9.5m, Genero = "Fantasia", Director = "David Benioff" });
                Series.Add(new Serie { Nombre = "Chernobyl", Temporadas = 1, Episodios = 5, Duracion = 60, Ranking = 9.6m, Genero = "Drama", Director = "Johan Renck" });
            }
            else if (nombre == "Netflix")
            {
                Series.Add(new Serie { Nombre = "Stranger Things", Temporadas = 4, Episodios = 34, Duracion = 50, Ranking = 8.8m, Genero = "Ciencia Ficción", Director = "Hermanos Duffer" });
                Series.Add(new Serie { Nombre = "The Witcher", Temporadas = 2, Episodios = 16, Duracion = 60, Ranking = 8.2m, Genero = "Fantasía", Director = "Lauren Schmidt" });
            }
            else if (nombre == "Disney+")
            {
                Series.Add(new Serie { Nombre = "The Mandalorian", Temporadas = 2, Episodios = 16, Duracion = 45, Ranking = 8.7m, Genero = "Ciencia Ficción", Director = "Jon Favreau" });
                Series.Add(new Serie { Nombre = "Loki", Temporadas = 1, Episodios = 6, Duracion = 50, Ranking = 8.5m, Genero = "Superhéroes", Director = "Kate Herron" });
            }
        }

        public override string ToString()
        {
            return $"{Nombre} - {Series.Count} series";
        }
    }
}
