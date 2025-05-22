using System;

namespace MultikinoAdmin.Models
{
    public class Sala
    {
        public int SalaId { get; set; }
        public string Nazwa { get; set; }
        public int LiczbaMiejsc { get; set; }

        public override string ToString()
        {
            return Nazwa;
        }
    }
}