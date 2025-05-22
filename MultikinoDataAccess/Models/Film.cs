using System.ComponentModel.DataAnnotations;

namespace MultikinoDataAccess.Models
{
    public class Film
    {
        [Key]
        public int FilmId { get; set; }

        [Required]
        [StringLength(255)]
        public string Tytul { get; set; }

        [Required]
        [StringLength(100)]
        public string Gatunek { get; set; }

        [StringLength(1000)]
        public string Opis { get; set; }

        [Required]
        public int CzasTrwania { get; set; }

        public byte[] Plakat { get; set; } // VARBINARY(MAX)
    }
}