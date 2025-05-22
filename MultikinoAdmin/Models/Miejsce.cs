using System;

namespace MultikinoAdmin.Models
{
    public class Miejsce
    {
        public int MiejsceId { get; set; }
        public int SalaId { get; set; }
        public int Numer { get; set; }
        public bool Zajete { get; set; }

        public override string ToString()
        {
            return $"Miejsce {Numer}";
        }
    }
}