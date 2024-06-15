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
        [Range(1, 5, ErrorMessage = "Estrelas deve ser entre 1 e 5.")]
        public int Estrelas { get; set; }

        [StringLength(500, ErrorMessage = "Comentário não pode exceder 500 caracteres.")]
        public string? Comentario { get; set; }
        [Required]
        public DateTime DataHora { get; set; }
        public int CursoId { get; set; }
        public int EstudanteId { get; set; }
    }
}
