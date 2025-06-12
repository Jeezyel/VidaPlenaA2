using HOSPISIM.DTO;
using HOSPISIM.Entities;
using HOSPISIM.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HOSPISIM.Controllers
{
    [Route("api/profissionalSaude")]
    [ApiController]
    public class ProfissionalSaudeController : ControllerBase
    {
        private readonly VidaPlenaDbContext _context;

        public ProfissionalSaudeController(VidaPlenaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var profissionais = _context.ProfissionaisSaude
                .Include(p => p.Especialidade)
                .ToList();

            return Ok(profissionais);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var profissional = _context.ProfissionaisSaude
                .Include(p => p.Especialidade)
                .FirstOrDefault(p => p.Id == id);

            if (profissional == null)
                return NotFound();

            return Ok(profissional);
        }

        [HttpPost]
        public IActionResult Create(ProfissionalSaudeDTO dto)
        {
            var especialidade = _context.Especialidades.Find(dto.EspecialidadeId);
            if (especialidade == null)
                return BadRequest("Especialidade não encontrada.");

            var profissional = new ProfissionalSaude
            {
                Id = Guid.NewGuid(),
                NomeCompleto = dto.NomeCompleto,
                CPF = dto.CPF,
                Email = dto.Email,
                Telefone = dto.Telefone,
                RegistroConselho = dto.RegistroConselho,
                TipoRegistro = dto.TipoRegistro,
                Especialidade = especialidade,
                DataAdmissao = dto.DataAdmissao,
                CargaHorariaSemanal = dto.CargaHorariaSemanal,
                Turno = dto.Turno,
                Ativo = dto.Ativo
            };

            _context.ProfissionaisSaude.Add(profissional);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = profissional.Id }, profissional);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, ProfissionalSaudeDTO dto)
        {
            var profissionalExistente = _context.ProfissionaisSaude
                .Include(p => p.Especialidade)
                .FirstOrDefault(p => p.Id == id);

            if (profissionalExistente == null)
                return NotFound();

            var especialidade = _context.Especialidades.Find(dto.EspecialidadeId);
            if (especialidade == null)
                return BadRequest("Especialidade não encontrada.");

            profissionalExistente.NomeCompleto = dto.NomeCompleto;
            profissionalExistente.CPF = dto.CPF;
            profissionalExistente.Email = dto.Email;
            profissionalExistente.Telefone = dto.Telefone;
            profissionalExistente.RegistroConselho = dto.RegistroConselho;
            profissionalExistente.TipoRegistro = dto.TipoRegistro;
            profissionalExistente.Especialidade = especialidade;
            profissionalExistente.DataAdmissao = dto.DataAdmissao;
            profissionalExistente.CargaHorariaSemanal = dto.CargaHorariaSemanal;
            profissionalExistente.Turno = dto.Turno;
            profissionalExistente.Ativo = dto.Ativo;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var profissional = _context.ProfissionaisSaude.Find(id);
            if (profissional == null)
                return NotFound();

            _context.ProfissionaisSaude.Remove(profissional);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
