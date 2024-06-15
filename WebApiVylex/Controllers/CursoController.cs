using Microsoft.AspNetCore.Mvc;
using WebApiVylex.DTOs;
using WebApiVylex.Models;
using WebApiVylex.Repository;
using WebApiVylex.Repository.Interface;

namespace WebApiVylex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public CursoController(ICursoRepository cursoRepository, IAvaliacaoRepository avaliacaoRepository)
        {
            _cursoRepository = cursoRepository;
            _avaliacaoRepository = avaliacaoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
        {
            var cursos = await _cursoRepository.GetAllAsync();
            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(int id)
        {
            var curso = await _cursoRepository.GetByIdAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            return Ok(curso);
        }

        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso curso)
        {
            await _cursoRepository.AddAsync(curso);
            return CreatedAtAction("GetCurso", new { id = curso.Id }, curso);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Curso curso)
        {
            if (id != curso.Id)
            {
                return BadRequest();
            }

            await _cursoRepository.UpdateAsync(curso);

            return NoContent();
        }

        [HttpGet("avaliacoeiiis")]
        public async Task<ActionResult<CursoComAvaliacoesDto>> GetCursoComAvaliacoes(Curso curso)
        {
            var cursos = await _cursoRepository.GetAllAsync();
            return Ok(cursos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            await _cursoRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
