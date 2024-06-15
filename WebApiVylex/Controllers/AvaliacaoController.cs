using Microsoft.AspNetCore.Mvc;
using WebApiVylex.Models;
using WebApiVylex.Repository.Interface;

namespace WebApiVylex.Controllers
{
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

        // GET: api/Avaliacao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Avaliacao>>> GetAvaliacoes()
        {
            var avaliacoes = await _avaliacaoRepository.GetAllAsync();
            return Ok(avaliacoes);
        }

        // GET: api/Avaliacao/5
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

        // POST: api/Avaliacao
        [HttpPost]
        public async Task<ActionResult<Avaliacao>> PostAvaliacao(Avaliacao avaliacao)
        {
            await _avaliacaoRepository.AddAsync(avaliacao);
            return CreatedAtAction("GetAvaliacao", new { id = avaliacao.Id }, avaliacao);
        }

        // PUT: api/Avaliacao/5
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

        // DELETE: api/Avaliacao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvaliacao(int id)
        {
            await _avaliacaoRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}

