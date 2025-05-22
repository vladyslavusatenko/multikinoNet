using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultikinoDataAccess.Models
{
    public class Bilet
    {
        [Key]
        public int BiletId { get; set; }

        public int SeansId { get; set; }

        public int UzytkownikId { get; set; }

        public int? MiejsceId { get; set; }

        [Required]
        public decimal Cena { get; set; }

        [Required]
        public DateTime DataZakupu { get; set; }

        [ForeignKey("SeansId")]
        public Seans Seans { get; set; }

        [ForeignKey("UzytkownikId")]
        public Uzytkownik Uzytkownik { get; set; }

        [ForeignKey("MiejsceId")]
        public Miejsce Miejsce { get; set; }
    }
}