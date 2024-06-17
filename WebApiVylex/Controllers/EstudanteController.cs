using Microsoft.AspNetCore.Mvc;
using WebApiVylex.Models;
using WebApiVylex.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace WebApiVylex.Controllers
{
    /// <summary>
    /// Controlador para operações relacionadas a estudantes.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EstudanteController : ControllerBase
    {
        private readonly IEstudanteRepository _estudanteRepository;

        public EstudanteController(IEstudanteRepository estudanteRepository)
        {
            _estudanteRepository = estudanteRepository;
        }

        /// <summary>
        /// Obtém todos os estudantes.
        /// </summary>
        /// <returns>Lista de estudantes.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudante>>> GetEstudantes()
        {
            var estudantes = await _estudanteRepository.GetAllAsync();
            return Ok(estudantes);
        }

        /// <summary>
        /// Obtém um estudante pelo ID.
        /// </summary>
        /// <param name="id">ID do estudante.</param>
        /// <returns>O estudante encontrado.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudante>> GetEstudante(int id)
        {
            var estudante = await _estudanteRepository.GetByIdAsync(id);

            if (estudante == null)
            {
                return NotFound();
            }

            return Ok(estudante);
        }

        /// <summary>
        /// Cria um novo estudante.
        /// </summary>
        /// <param name="estudante">Dados do estudante a serem criados.</param>
        /// <returns>O estudante criado.</returns>
        [HttpPost]
        public async Task<ActionResult<Estudante>> PostEstudante(Estudante estudante)
        {
            await _estudanteRepository.AddAsync(estudante);
            return CreatedAtAction(nameof(GetEstudante), new { id = estudante.Id }, estudante);
        }

        /// <summary>
        /// Atualiza um estudante existente.
        /// </summary>
        /// <param name="id">ID do estudante a ser atualizado.</param>
        /// <param name="estudante">Dados atualizados do estudante.</param>
        /// <returns>Um código de status indicando o resultado da operação.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudante(int id, Estudante estudante)
        {
            if (id != estudante.Id)
            {
                return BadRequest();
            }

            await _estudanteRepository.UpdateAsync(estudante);

            return NoContent();
        }

        /// <summary>
        /// Exclui um estudante pelo ID.
        /// </summary>
        /// <param name="id">ID do estudante a ser excluído.</param>
        /// <returns>Um código de status indicando o resultado da operação.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudante(int id)
        {
            await _estudanteRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
