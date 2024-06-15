using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiVylex.Models
{
    public class Estudante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]

        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo Nome deve ter entre 3 e 100 caracteres.")]
        [Display(Name = "Obrigatorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo Email deve ter entre 3 e 100 caracteres.")]
        public string Email { get; set; }
        //public ICollection<Avaliacao> Avaliacoes { get; set; }

    }
}
