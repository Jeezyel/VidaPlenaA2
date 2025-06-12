using HOSPISIM.Persistence;
using HOSPISIM.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HOSPISIM.Entities;

namespace HOSPISIM.Controllers
{
    [Route("api/atendimento")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        private readonly VidaPlenaDbContext _context;

        public AtendimentoController(VidaPlenaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var atendimentos = _context.Atendimentos
                .Include(a => a.Paciente)
                .Include(a => a.Profissional)
                .Include(a => a.Prontuario)
                .Include(a => a.Prescricoes)
                .Include(a => a.Exames)
                .Include(a => a.Internacao)
                .ToList();

            return Ok(atendimentos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var atendimento = _context.Atendimentos
                .Include(a => a.Paciente)
                .Include(a => a.Profissional)
                .Include(a => a.Prontuario)
                .Include(a => a.Prescricoes)
                .Include(a => a.Exames)
                .Include(a => a.Internacao)
                .FirstOrDefault(a => a.Id == id);

            if (atendimento == null)
                return NotFound();

            return Ok(atendimento);
        }

        [HttpPost]
        public IActionResult Create(AtendimentoDTO dto)
        {
            var paciente = _context.Pacientes.Find(dto.PacienteId);
            var profissional = _context.ProfissionaisSaude.Find(dto.ProfissionalId);
            var prontuario = _context.Prontuarios.Find(dto.ProntuarioId);

            if (paciente == null || profissional == null || prontuario == null)
                return BadRequest("Paciente, Profissional ou Prontuário inválido.");

            var atendimento = new Atendimento
            {
                Id = Guid.NewGuid(),
                DataHora = dto.DataHora,
                Tipo = dto.Tipo,
                Status = dto.Status,
                Local = dto.Local,
                Paciente = paciente,
                Profissional = profissional,
                Prontuario = prontuario
            };

            _context.Atendimentos.Add(atendimento);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = atendimento.Id }, atendimento);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, AtendimentoDTO dto)
        {
            var atendimentoExistente = _context.Atendimentos
                .Include(a => a.Paciente)
                .Include(a => a.Profissional)
                .Include(a => a.Prontuario)
                .FirstOrDefault(a => a.Id == id);

            if (atendimentoExistente == null)
                return NotFound();

            var paciente = _context.Pacientes.Find(dto.PacienteId);
            var profissional = _context.ProfissionaisSaude.Find(dto.ProfissionalId);
            var prontuario = _context.Prontuarios.Find(dto.ProntuarioId);

            if (paciente == null || profissional == null || prontuario == null)
                return BadRequest("Paciente, Profissional ou Prontuário inválido.");

            atendimentoExistente.DataHora = dto.DataHora;
            atendimentoExistente.Tipo = dto.Tipo;
            atendimentoExistente.Status = dto.Status;
            atendimentoExistente.Local = dto.Local;
            atendimentoExistente.Paciente = paciente;
            atendimentoExistente.Profissional = profissional;
            atendimentoExistente.Prontuario = prontuario;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var atendimento = _context.Atendimentos.Find(id);
            if (atendimento == null)
                return NotFound();

            _context.Atendimentos.Remove(atendimento);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
