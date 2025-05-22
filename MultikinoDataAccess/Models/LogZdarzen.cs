using System;
using System.ComponentModel.DataAnnotations;

namespace MultikinoDataAccess.Models
{
    public class LogZdarzen
    {
        [Key]
        public int LogId { get; set; }

        [StringLength(50)]
        public string NazwaTabeli { get; set; }

        [StringLength(10)]
        public string Operacja { get; set; }

        [StringLength(100)]
        public string Uzytkownik { get; set; }

        public DateTime DataOperacji { get; set; } = DateTime.Now;
    }
}