using System;

namespace MultikinoAdmin.Models
{
    public class Seans
    {
        public int SeansId { get; set; }
        public int FilmId { get; set; }
        public string TytulFilmu { get; set; }
        public int SalaId { get; set; }
        public string NazwaSali { get; set; }
        public DateTime DataSeansu { get; set; }

        public override string ToString()
        {
            return $"{TytulFilmu} - {DataSeansu:dd.MM.yyyy HH:mm}";
        }
    }
}