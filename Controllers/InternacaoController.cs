
using HOSPISIM.DTO;
using HOSPISIM.Entities;
using HOSPISIM.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HOSPISIM.Controllers
{
    [Route("api/internacao")]
    [ApiController]
    public class InternacaoController : ControllerBase
    {
        private readonly VidaPlenaDbContext _context;

        public InternacaoController(VidaPlenaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var internacoes = _context.Internacoes
                .Include(i => i.Paciente)
                .Include(i => i.Atendimento)
                .Include(i => i.AltaHospitalar)
                .ToList();

            return Ok(internacoes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var internacao = _context.Internacoes
                .Include(i => i.Paciente)
                .Include(i => i.Atendimento)
                .Include(i => i.AltaHospitalar)
                .FirstOrDefault(i => i.Id == id);

            if (internacao == null)
                return NotFound();

            return Ok(internacao);
        }

        [HttpPost]
        public IActionResult Create(InternacaoDTO dto)
        {
            var paciente = _context.Pacientes.Find(dto.PacienteId);
            var atendimento = _context.Atendimentos.Find(dto.AtendimentoId);

            if (paciente == null || atendimento == null)
                return BadRequest("Paciente ou Atendimento inválido.");

            var internacao = new Internacao
            {
                Id = Guid.NewGuid(),
                Paciente = paciente,
                Atendimento = atendimento,
                DataEntrada = dto.DataEntrada,
                PrevisaoAlta = dto.PrevisaoAlta,
                MotivoInternacao = dto.MotivoInternacao,
                Leito = dto.Leito,
                Quarto = dto.Quarto,
                Setor = dto.Setor,
                PlanoSaudeUtilizado = dto.PlanoSaudeUtilizado,
                ObservacoesClinicas = dto.ObservacoesClinicas,
                StatusInternacao = dto.StatusInternacao
            };

            _context.Internacoes.Add(internacao);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = internacao.Id }, internacao);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, InternacaoDTO dto)
        {
            var internacaoExistente = _context.Internacoes
                .Include(i => i.Paciente)
                .Include(i => i.Atendimento)
                .FirstOrDefault(i => i.Id == id);

            if (internacaoExistente == null)
                return NotFound();

            var paciente = _context.Pacientes.Find(dto.PacienteId);
            var atendimento = _context.Atendimentos.Find(dto.AtendimentoId);

            if (paciente == null || atendimento == null)
                return BadRequest("Paciente ou Atendimento inválido.");

            internacaoExistente.Paciente = paciente;
            internacaoExistente.Atendimento = atendimento;
            internacaoExistente.DataEntrada = dto.DataEntrada;
            internacaoExistente.PrevisaoAlta = dto.PrevisaoAlta;
            internacaoExistente.MotivoInternacao = dto.MotivoInternacao;
            internacaoExistente.Leito = dto.Leito;
            internacaoExistente.Quarto = dto.Quarto;
            internacaoExistente.Setor = dto.Setor;
            internacaoExistente.PlanoSaudeUtilizado = dto.PlanoSaudeUtilizado;
            internacaoExistente.ObservacoesClinicas = dto.ObservacoesClinicas;
            internacaoExistente.StatusInternacao = dto.StatusInternacao;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var internacao = _context.Internacoes.Find(id);
            if (internacao == null)
                return NotFound();

            _context.Internacoes.Remove(internacao);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
