using HOSPISIM.DTO;
using HOSPISIM.Entities;
using HOSPISIM.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HOSPISIM.Controllers
{

    [Route("api/prontuario")]
    [ApiController]
    public class ProntuarioController : ControllerBase
    {
        private readonly VidaPlenaDbContext _context;

        public ProntuarioController(VidaPlenaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var prontuarios = _context.Prontuarios
                .Include(p => p.Paciente)
                .Include(p => p.Atendimentos)
                .ToList();

            return Ok(prontuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var prontuario = _context.Prontuarios
                .Include(p => p.Paciente)
                .Include(p => p.Atendimentos)
                .FirstOrDefault(p => p.Id == id);

            if (prontuario == null)
                return NotFound();

            return Ok(prontuario);
        }

        [HttpPost]
        public IActionResult Create(ProntuarioDTO dto)
        {
            var paciente = _context.Pacientes.Find(dto.PacienteId);
            if (paciente == null)
                return BadRequest("Paciente não encontrado.");

            var prontuario = new Prontuario
            {
                Id = Guid.NewGuid(),
                NumeroProntuario = dto.NumeroProntuario,
                DataAbertura = dto.DataAbertura,
                ObservacoesGerais = dto.ObservacoesGerais,
                Paciente = paciente
            };

            _context.Prontuarios.Add(prontuario);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = prontuario.Id }, prontuario);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, ProntuarioDTO dto)
        {
            var prontuarioExistente = _context.Prontuarios
                .Include(p => p.Paciente)
                .FirstOrDefault(p => p.Id == id);

            if (prontuarioExistente == null)
                return NotFound();

            var paciente = _context.Pacientes.Find(dto.PacienteId);
            if (paciente == null)
                return BadRequest("Paciente não encontrado.");

            prontuarioExistente.NumeroProntuario = dto.NumeroProntuario;
            prontuarioExistente.DataAbertura = dto.DataAbertura;
            prontuarioExistente.ObservacoesGerais = dto.ObservacoesGerais;
            prontuarioExistente.Paciente = paciente;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var prontuario = _context.Prontuarios.Find(id);
            if (prontuario == null)
                return NotFound();

            _context.Prontuarios.Remove(prontuario);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
