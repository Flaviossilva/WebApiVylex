using WebApiVylex.Models;

namespace WebApiVylex.DTOs
{
    public class CursoComAvaliacoesDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<AvaliacaoEstudante> Avaliacoes { get; set; } = new List<AvaliacaoEstudante>();

    }
}
