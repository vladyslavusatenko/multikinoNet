using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultikinoDataAccess.Models
{
    public class Seans
    {
        [Key]
        public int SeansId { get; set; }

        public int FilmId { get; set; }

        public int SalaId { get; set; }

        [Required]
        [Index("IDX_Seans_DataSeansu")]
        public DateTime DataSeansu { get; set; }

        [ForeignKey("FilmId")]
        [Index("IDX_Seans_FilmId")]
        public Film Film { get; set; }

        [ForeignKey("SalaId")]
        [Index("IDX_Seans_SalaId")]
        public Sala Sala { get; set; }
    }
}