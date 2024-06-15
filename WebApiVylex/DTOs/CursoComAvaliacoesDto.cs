using WebApiVylex.Models;

namespace WebApiVylex.DTOs
{
    public class CursoComAvaliacoesDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Avaliacao> Avaliacoes { get; set; }
    }
}
