using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiVylex.Models
{
    public class Avaliacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Estrelas { get; set; }
        [Required]
        public string? Comentario { get; set; }
        [Required]
        public DateTime DataHora { get; set; }
        [Required]
        public int CursoId { get; set; }
        //public Curso Curso { get; set; }
        [Required]
        public int EstudanteId { get; set; }

        public ICollection<Curso> Cursos { get; set; }

    }
}
