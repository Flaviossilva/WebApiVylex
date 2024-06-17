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
        public int Estrelas { get; set; }
        public string? Comentario { get; set; }
        public DateTime DataHora { get; set; }
        public int CursoId { get; set; }
        public int EstudanteId { get; set; }
    }
}
