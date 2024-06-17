using Microsoft.AspNetCore.Mvc;
using WebApiVylex.Models;
using WebApiVylex.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;

namespace WebApiVylex.Controllers
{
    /// <summary>
    /// Controlador para operações relacionadas a avaliações.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;
        private readonly ICursoRepository _cursoRepository;
        private readonly IEstudanteRepository _estudanteRepository;

        public AvaliacaoController(IAvaliacaoRepository avaliacaoRepository, ICursoRepository cursoRepository, IEstudanteRepository estudanteRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
            _cursoRepository = cursoRepository;
            _estudanteRepository = estudanteRepository;
        }

        /// <summary>
        /// Obtém todas as avaliações.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Avaliacao>>> GetAvaliacoes()
        {
            var avaliacoes = await _avaliacaoRepository.GetAllAsync();
            return Ok(avaliacoes);
        }

        /// <summary>
        /// Obtém uma avaliação específica pelo ID.
        /// </summary>
        /// <param name="id">ID da avaliação.</param>
        [HttpGet("{id}")]
        public async Task<ActionResult<Avaliacao>> GetAvaliacao(int id)
        {
            var avaliacao = await _avaliacaoRepository.GetByIdAsync(id);

            if (avaliacao == null)
            {
                return NotFound();
            }

            return Ok(avaliacao);
        }

        /// <summary>
        /// Cria uma nova avaliação.
        /// </summary>
        /// <param name="avaliacao">Dados da avaliação a ser criada.</param>
        [HttpPost]
        public async Task<ActionResult<Avaliacao>> PostAvaliacao(Avaliacao avaliacao)
        {
            await _avaliacaoRepository.AddAsync(avaliacao);
            return CreatedAtAction("GetAvaliacao", new { id = avaliacao.Id }, avaliacao);
        }

        /// <summary>
        /// Atualiza uma avaliação existente pelo ID.
        /// </summary>
        /// <param name="id">ID da avaliação a ser atualizada.</param>
        /// <param name="avaliacao">Dados atualizados da avaliação.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvaliacao(int id, Avaliacao avaliacao)
        {
            if (id != avaliacao.Id)
            {
                return BadRequest();
            }

            await _avaliacaoRepository.UpdateAsync(avaliacao);
            return NoContent();
        }

        /// <summary>
        /// Exclui uma avaliação pelo ID.
        /// </summary>
        /// <param name="id">ID da avaliação a ser excluída.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvaliacao(int id)
        {
            await _avaliacaoRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
