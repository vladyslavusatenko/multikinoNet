using System.ComponentModel.DataAnnotations;

namespace MultikinoDataAccess.Models
{
    public class Sala
    {
        [Key]
        public int SalaId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nazwa { get; set; }

        [Required]
        public int LiczbaMiejsc { get; set; }
    }
}