using HOSPISIM.Persistence;
using Microsoft.AspNetCore.Mvc;
using HOSPISIM.DTO;
using HOSPISIM.Entities;
using Microsoft.EntityFrameworkCore;

namespace HOSPISIM.Controllers
{
    [Route("api/especialidade")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly VidaPlenaDbContext _context;

        public EspecialidadeController(VidaPlenaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var especialidades = _context.Especialidades
                .Include(e => e.Profissionais)
                .ToList();

            return Ok(especialidades);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var especialidade = _context.Especialidades
                .Include(e => e.Profissionais)
                .FirstOrDefault(e => e.Id == id);

            if (especialidade == null)
                return NotFound();

            return Ok(especialidade);
        }

        [HttpPost]
        public IActionResult Create(EspecialidadeDTO dto)
        {

            var proficionalDeSaude = _context.ProfissionaisSaude.Find(dto.ProfissionaisSaudeId);

            if (proficionalDeSaude == null)
                return BadRequest("proficional De Saude não encontrado.");

            var especialidade = new Especialidade
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome
            };

            _context.Especialidades.Add(especialidade);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = especialidade.Id }, especialidade);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, EspecialidadeDTO dto)
        {
            var especialidadeExistente = _context.Especialidades.Find(id);

            if (especialidadeExistente == null)
                return NotFound();

            especialidadeExistente.Nome = dto.Nome;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var especialidade = _context.Especialidades.Find(id);
            if (especialidade == null)
                return NotFound();

            _context.Especialidades.Remove(especialidade);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
