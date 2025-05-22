using System;
using System.ComponentModel.DataAnnotations;

namespace MultikinoDataAccess.Models
{
    public class HistoriaBiletow
    {
        [Key]
        public int HistoriaId { get; set; }

        public int BiletId { get; set; }

        public int SeansId { get; set; }

        public int UzytkownikId { get; set; }

        public int MiejsceNr { get; set; }

        public decimal Cena { get; set; }

        public DateTime DataZakupu { get; set; }

        public DateTime DataUsuniecia { get; set; } = DateTime.Now;
    }
}