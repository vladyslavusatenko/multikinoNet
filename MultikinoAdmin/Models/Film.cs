using System;

namespace MultikinoAdmin.Models
{
    public class Film
    {
        public int FilmId { get; set; }
        public string Tytul { get; set; }
        public string Gatunek { get; set; }
        public string Opis { get; set; }
        public int CzasTrwania { get; set; }
        public byte[] Plakat { get; set; }

        public override string ToString()
        {
            return Tytul;
        }
    }
}