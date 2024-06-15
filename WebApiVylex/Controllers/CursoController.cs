using Microsoft.AspNetCore.Mvc;
using WebApiVylex.DTOs;
using WebApiVylex.Models;
using WebApiVylex.Repository;
using WebApiVylex.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiVylex.Controllers
{
    /// <summary>
    /// Controlador para operações relacionadas a cursos.
    /// </summary>
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

        /// <summary>
        /// Obtém todos os cursos.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
        {
            var cursos = await _cursoRepository.GetAllAsync();
            return Ok(cursos);
        }

        /// <summary>
        /// Obtém um curso específico pelo ID.
        /// </summary>
        /// <param name="id">ID do curso.</param>
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

        /// <summary>
        /// Cria um novo curso.
        /// </summary>
        /// <param name="curso">Dados do curso a ser criado.</param>
        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso curso)
        {
            await _cursoRepository.AddAsync(curso);
            return CreatedAtAction("GetCurso", new { id = curso.Id }, curso);
        }

        /// <summary>
        /// Atualiza um curso existente pelo ID.
        /// </summary>
        /// <param name="id">ID do curso a ser atualizado.</param>
        /// <param name="curso">Dados atualizados do curso.</param>
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

        /// <summary>
        /// Obtém todos os cursos com suas avaliações associadas.
        /// </summary>
        [HttpGet("avaliacoes")]
        public async Task<ActionResult<CursoComAvaliacoesDto>> GetCursoComAvaliacoes()
        {
            var cursos = await _cursoRepository.GetAllCursoComAvaliacaoAsync();
            return Ok(cursos);
        }

        /// <summary>
        /// Exclui um curso pelo ID.
        /// </summary>
        /// <param name="id">ID do curso a ser excluído.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            await _cursoRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
