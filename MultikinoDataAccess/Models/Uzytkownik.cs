using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultikinoDataAccess.Models
{
    public class Uzytkownik
    {
        [Key]
        public int UzytkownikId { get; set; }

        [Required]
        [StringLength(50)]
        public string Imie { get; set; }

        [Required]
        [StringLength(50)]
        public string Nazwisko { get; set; }

        [Required]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Haslo { get; set; }

        [Required]
        [StringLength(50)]
        [Index("IDX_Uzytkownik_Rola")]
        public string Rola { get; set; }
    }
}