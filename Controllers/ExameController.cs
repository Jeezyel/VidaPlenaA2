using HOSPISIM.Entities;
using HOSPISIM.DTO;
using HOSPISIM.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HOSPISIM.Controllers
{
    [Route("api/Exame")]
    [ApiController]
    public class ExameController : ControllerBase
    {
        private readonly VidaPlenaDbContext _context;

        public ExameController(VidaPlenaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var exames = _context.Exames
                .Include(e => e.Atendimento)
                .ToList();

            return Ok(exames);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var exame = _context.Exames.Find(id);

            if (exame == null)
                return NotFound("Exame não encontrado");

            return Ok(exame);
        }

        [HttpPost]
        public IActionResult Create(ExameDTO dto)
        {
            var atendimento = _context.Atendimentos.Find(dto.AtendimentoId);
            if (atendimento == null)
                return BadRequest("Atendimento não encontrado.");

            var exame = new Exame
            {
                Id = Guid.NewGuid(),
                Tipo = dto.Tipo,
                DataSolicitacao = dto.DataSolicitacao,
                DataRealizacao = dto.DataRealizacao,
                Resultado = dto.Resultado,
                Atendimento = atendimento
            };

            _context.Exames.Add(exame);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = exame.Id }, exame);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, ExameDTO dto)
        {
            var exameExistente = _context.Exames
                                .Include(e => e.Atendimento)
                                .FirstOrDefault(e => e.Id == id);

            if (exameExistente == null)
                return NotFound();

            var atendimento = _context.Atendimentos.Find(dto.AtendimentoId);
            if (atendimento == null)
                return BadRequest("Atendimento não encontrado.");

            exameExistente.Tipo = dto.Tipo;
            exameExistente.DataSolicitacao = dto.DataSolicitacao;
            exameExistente.DataRealizacao = dto.DataRealizacao;
            exameExistente.Resultado = dto.Resultado;
            exameExistente.Atendimento = atendimento;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var exame = _context.Exames.Find(id);
            if (exame == null)
                return NotFound();

            _context.Exames.Remove(exame);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
