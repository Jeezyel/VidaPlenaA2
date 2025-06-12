using HOSPISIM.DTO;
using HOSPISIM.Entities;
using HOSPISIM.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HOSPISIM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescricaoController : ControllerBase
    {
        private readonly VidaPlenaDbContext _context;

        public PrescricaoController(VidaPlenaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var prescricoes = _context.Prescricoes
                .Include(p => p.Atendimento)
                .Include(p => p.Profissional)
                .ToList();

            return Ok(prescricoes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var prescricao = _context.Prescricoes
                .Include(p => p.Atendimento)
                .Include(p => p.Profissional)
                .FirstOrDefault(p => p.Id == id);

            if (prescricao == null)
                return NotFound();

            return Ok(prescricao);
        }

        [HttpPost]
        public IActionResult Create(PrescricaoDTO dto)
        {
            var atendimento = _context.Atendimentos.Find(dto.AtendimentoId);
            var profissional = _context.ProfissionaisSaude.Find(dto.ProfissionalId);

            if (atendimento == null || profissional == null)
                return BadRequest("Atendimento ou Profissional inválido.");

            var prescricao = new Prescricao
            {
                Id = Guid.NewGuid(),
                Atendimento = atendimento,
                Profissional = profissional,
                Medicamento = dto.Medicamento,
                Dosagem = dto.Dosagem,
                Frequencia = dto.Frequencia,
                ViaAdministracao = dto.ViaAdministracao,
                DataInicio = dto.DataInicio,
                DataFim = dto.DataFim,
                Observacoes = dto.Observacoes,
                StatusPrescricao = dto.StatusPrescricao,
                ReacoesAdversas = dto.ReacoesAdversas
            };

            _context.Prescricoes.Add(prescricao);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = prescricao.Id }, prescricao);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, PrescricaoDTO dto)
        {
            var prescricaoExistente = _context.Prescricoes
                .Include(p => p.Atendimento)
                .Include(p => p.Profissional)
                .FirstOrDefault(p => p.Id == id);

            if (prescricaoExistente == null)
                return NotFound();

            var atendimento = _context.Atendimentos.Find(dto.AtendimentoId);
            var profissional = _context.ProfissionaisSaude.Find(dto.ProfissionalId);

            if (atendimento == null || profissional == null)
                return BadRequest("Atendimento ou Profissional inválido.");

            prescricaoExistente.Atendimento = atendimento;
            prescricaoExistente.Profissional = profissional;
            prescricaoExistente.Medicamento = dto.Medicamento;
            prescricaoExistente.Dosagem = dto.Dosagem;
            prescricaoExistente.Frequencia = dto.Frequencia;
            prescricaoExistente.ViaAdministracao = dto.ViaAdministracao;
            prescricaoExistente.DataInicio = dto.DataInicio;
            prescricaoExistente.DataFim = dto.DataFim;
            prescricaoExistente.Observacoes = dto.Observacoes;
            prescricaoExistente.StatusPrescricao = dto.StatusPrescricao;
            prescricaoExistente.ReacoesAdversas = dto.ReacoesAdversas;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var prescricao = _context.Prescricoes.Find(id);
            if (prescricao == null)
                return NotFound();

            _context.Prescricoes.Remove(prescricao);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
