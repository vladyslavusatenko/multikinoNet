using System;

namespace MultikinoAdmin.Models
{
    public class Bilet
    {
        public int BiletId { get; set; }
        public int SeansId { get; set; }
        public int UzytkownikId { get; set; }
        public int MiejsceId { get; set; }
        public decimal Cena { get; set; }
        public DateTime DataZakupu { get; set; }

        public string TytulFilmu { get; set; }
        public DateTime DataSeansu { get; set; }
        public int NumerMiejsca { get; set; }
        public string DaneKlienta { get; set; }
    }
}