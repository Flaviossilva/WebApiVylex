namespace WebApiVylex.DTOs
{
    public class AvaliacaoDto
    {
        public int Id { get; set; }
        public int EstudanteId { get; set; }
        public string NomeEstudante { get; set; }
        public int Estrelas { get; set; }
        public string Comentario { get; set; }
        public DateTime DataHora { get; set; }
    }
}
