using Microsoft.AspNetCore.Mvc;
using WebApiVylex.Models;
using WebApiVylex.Repository.Interface;

namespace WebApiVylex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudanteController : ControllerBase
    {
        private readonly IEstudanteRepository _estudanteRepository;

        public EstudanteController(IEstudanteRepository estudanteRepository)
        {
            _estudanteRepository = estudanteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudante>>> GetEstudantes()
        {
            var estudantes = await _estudanteRepository.GetAllAsync();
            return Ok(estudantes);
        }

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

        [HttpPost]
        public async Task<ActionResult<Estudante>> PostEstudante(Estudante estudante)
        {
            await _estudanteRepository.AddAsync(estudante);
            return CreatedAtAction("GetEstudante", new { id = estudante.Id }, estudante);
        }

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudante(int id)
        {
            await _estudanteRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
