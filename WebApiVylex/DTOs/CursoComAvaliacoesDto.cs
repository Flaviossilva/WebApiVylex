﻿namespace WebApiVylex.DTOs
{
    public class CursoComAvaliacoesDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<AvaliacaoDto> Avaliacoes { get; set; }
    }
}
