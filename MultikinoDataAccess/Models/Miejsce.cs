using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultikinoDataAccess.Models
{
    public class Miejsce
    {
        [Key]
        public int MiejsceId { get; set; }

        public int SalaId { get; set; }

        [Required]
        public int Numer { get; set; }

        [Required]
        public bool Zajete { get; set; } = false;

        [ForeignKey("SalaId")]
        public Sala Sala { get; set; }
    }
}