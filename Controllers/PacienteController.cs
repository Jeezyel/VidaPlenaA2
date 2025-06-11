using HOSPISIM.DTO;
using HOSPISIM.Entities;
using HOSPISIM.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class PacienteController : ControllerBase
{
    private readonly VidaPlenaDbContext _context;

    public PacienteController(VidaPlenaDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var pacientes = _context.Pacientes.ToList();
        return Ok(pacientes);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var paciente = _context.Pacientes.Find(id);
        if (paciente == null)
            return NotFound();

        return Ok(paciente);
    }

    [HttpPost]
    public IActionResult Create(PacienteDTO dto)
    {
        var prontuarios = _context.Prontuarios
        .Where(p => dto.ProntuarioIds.Contains(p.Id))
        .ToList();

        var paciente = new Paciente
        {
            Id = Guid.NewGuid(),
            NomeCompleto = dto.NomeCompleto,
            CPF = dto.CPF,
            DataNascimento = dto.DataNascimento,
            Sexo = dto.Sexo,
            TipoSanguineo = dto.TipoSanguineo,
            Telefone = dto.Telefone,
            Email = dto.Email,
            EnderecoCompleto = dto.EnderecoCompleto,
            NumeroCartaoSUS = dto.NumeroCartaoSUS,
            PossuiPlanoSaude = dto.PossuiPlanoSaude,

            Prontuarios = prontuarios

        };

        _context.Pacientes.Add(paciente);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = paciente.Id }, paciente);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, PacienteDTO dto)
    {
        // Busca o paciente existente
        var pacienteExistente = _context.Pacientes
            .Include(p => p.Prontuarios) // inclui os prontuários atuais
            .FirstOrDefault(p => p.Id == id);

        if (pacienteExistente == null)
            return NotFound("Paciente não encontrado.");

        // Atualiza os dados do paciente
        pacienteExistente.NomeCompleto = dto.NomeCompleto;
        pacienteExistente.CPF = dto.CPF;
        pacienteExistente.DataNascimento = dto.DataNascimento;
        pacienteExistente.Sexo = dto.Sexo;
        pacienteExistente.TipoSanguineo = dto.TipoSanguineo;
        pacienteExistente.Telefone = dto.Telefone;
        pacienteExistente.Email = dto.Email;
        pacienteExistente.EnderecoCompleto = dto.EnderecoCompleto;
        pacienteExistente.NumeroCartaoSUS = dto.NumeroCartaoSUS;
        pacienteExistente.EstadoCivil = dto.EstadoCivil;
        pacienteExistente.PossuiPlanoSaude = dto.PossuiPlanoSaude;

        // Atualiza os prontuários associados (se algum foi passado)
        if (dto.ProntuarioIds != null)
        {
            var prontuarios = _context.Prontuarios
                .Where(p => dto.ProntuarioIds.Contains(p.Id))
                .ToList();

            pacienteExistente.Prontuarios = prontuarios;
        }

        _context.SaveChanges();

        return NoContent(); // 204 - Atualizado com sucesso, sem retorno de corpo
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var paciente = _context.Pacientes.Find(id);
        if (paciente == null)
            return NotFound();

        _context.Pacientes.Remove(paciente);
        _context.SaveChanges();
        return NoContent();
    }
}
