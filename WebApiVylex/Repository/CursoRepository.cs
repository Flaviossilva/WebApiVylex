using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiVylex.Data;
using WebApiVylex.DTOs;
using WebApiVylex.Models;
using WebApiVylex.Repository.Interface;

namespace WebApiVylex.Repository
{
    public class CursoRepository : ICursoRepository
    {
        private readonly ApplicationDbContext _context;

        public CursoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Curso>> GetAllAsync()
        {
            return await _context.Cursos.ToListAsync();
        }

        public async Task<IEnumerable<CursoComAvaliacoesDto>> GetAllCursoComAvaliacaoAsync()
        {
            List<CursoComAvaliacoesDto> ListaDeCursos = new List<CursoComAvaliacoesDto>();
            List<Curso> retornoCursos = _context.Cursos.ToList();

            foreach (var cursoRetorno in retornoCursos)
            {
                CursoComAvaliacoesDto Curso = new CursoComAvaliacoesDto();
                Curso.Id = cursoRetorno.Id;
                Curso.Nome = cursoRetorno.Nome;
                Curso.Descricao = cursoRetorno.Descricao;

                List<Avaliacao> avaliacoes = _context.Avaliacoes.Where(s => s.CursoId == cursoRetorno.Id).ToList();
                Curso.Avaliacoes.Clear();
                foreach (var avaliacoesRetorno in avaliacoes)
                {
                    AvaliacaoEstudante CastinDados = new AvaliacaoEstudante();
                    Estudante estudante = _context.Estudantes.Where(s => s.Id == avaliacoesRetorno.EstudanteId
                    ).First();
                    if (estudante != null)
                    {
                        CastinDados.Id = avaliacoesRetorno.Id;
                        CastinDados.EstudanteId = estudante.Id;
                        CastinDados.Nome = estudante.Nome;
                        CastinDados.Estrelas = avaliacoesRetorno.Estrelas;
                        CastinDados.Comentario = avaliacoesRetorno.Comentario;
                        CastinDados.DataHora = avaliacoesRetorno.DataHora;

                        Curso.Avaliacoes.Add(CastinDados);
                    }
                }
                ListaDeCursos.Add(Curso);
            }

            return ListaDeCursos;
        }

        public async Task<Curso> GetByIdAsync(int id)
        {
            return await _context.Cursos.FindAsync(id);
        }

        public async Task AddAsync(Curso curso)
        {
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Curso curso)
        {
            _context.Entry(curso).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso != null)
            {
                _context.Cursos.Remove(curso);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Cursos.AnyAsync(c => c.Id == id);
        }
    }

}
