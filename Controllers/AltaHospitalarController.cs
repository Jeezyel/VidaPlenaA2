using Microsoft.AspNetCore.Mvc;
using HOSPISIM.Entities;
using HOSPISIM.DTO;
using HOSPISIM.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HOSPISIM.Controllers
{
    [Route("api/altaHospitalar")]
    [ApiController]
    public class AltaHospitalarController : ControllerBase
    {
        private readonly VidaPlenaDbContext _context;

        public AltaHospitalarController(VidaPlenaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var altas = _context.AltasHospitalares
                .Include(a => a.Internacao)
                .ToList();

            return Ok(altas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var alta = _context.AltasHospitalares.Find(id);

            if (alta == null)
                return NotFound();

            return Ok(alta);
        }

        [HttpPost]
        public IActionResult Create(AltaHospitalarDTO dto)
        {
            var internacao = _context.Internacoes.Find(dto.InternacaoId);
            if (internacao == null)
                return BadRequest("Internação não encontrada.");

            var alta = new AltaHospitalar
            {
                Id = Guid.NewGuid(),
                Internacao = internacao,
                Data = dto.Data,
                CondicaoPaciente = dto.CondicaoPaciente,
                InstrucoesPosAlta = dto.InstrucoesPosAlta
            };

            _context.AltasHospitalares.Add(alta);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = alta.Id }, alta);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, AltaHospitalarDTO dto)
        {
            var altaExistente = _context.AltasHospitalares
                                .Include(a => a.Internacao)
                                .FirstOrDefault(a => a.Id == id);

            if (altaExistente == null)
                return NotFound("Alta Hospitalar não encontrada");

            var internacao = _context.Internacoes.Find(dto.InternacaoId);
            if (internacao == null)
                return BadRequest("Internação não encontrada.");

            altaExistente.Internacao = internacao;
            altaExistente.Data = dto.Data;
            altaExistente.CondicaoPaciente = dto.CondicaoPaciente;
            altaExistente.InstrucoesPosAlta = dto.InstrucoesPosAlta;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var alta = _context.AltasHospitalares.Find(id);
            if (alta == null)
                return NotFound("Alta Hospitalar não encontrada");

            _context.AltasHospitalares.Remove(alta);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
