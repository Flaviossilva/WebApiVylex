using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiVylex.Models
{
    public class Curso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(80, ErrorMessage = "Comentário não pode exceder 80 caracteres.")]
        public string Nome { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Comentário não pode exceder 200 caracteres.")]
        public string Descricao { get; set; }
    }
}
