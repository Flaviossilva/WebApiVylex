using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiVylex.DTOs
{
    public class EstudantesDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Obrigatorio")]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
