namespace WebApiVylex.DTOs
{
    public class AvaliacaoEstudante
    {
        public int Id { get; set; }

        public int EstudanteId { get; set; }
        public string Nome { get; set; }

        public int Estrelas { get; set; }

        public string? Comentario { get; set; }


        public DateTime DataHora { get; set; }

    }
}
