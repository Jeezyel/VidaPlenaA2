using HOSPISIM.Entities;
using HOSPISIM.Persistence;
using Microsoft.AspNetCore.Mvc;
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
    public IActionResult Create(Paciente paciente)
    {
        paciente.Id = Guid.NewGuid();
        _context.Pacientes.Add(paciente);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = paciente.Id }, paciente);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, Paciente paciente)
    {
        if (id != paciente.Id)
            return BadRequest("Id Invalido");

        var existente = _context.Pacientes.Find(id);
        if (existente == null)
            return NotFound("Paciente Não Encontrado");

        // Atualiza os campos manualmente
        existente.NomeCompleto = paciente.NomeCompleto;
        existente.CPF = paciente.CPF;
        existente.DataNascimento = paciente.DataNascimento;
        existente.Sexo = paciente.Sexo;
        existente.TipoSanguineo = paciente.TipoSanguineo;
        existente.Telefone = paciente.Telefone;
        existente.Email = paciente.Email;
        existente.EnderecoCompleto = paciente.EnderecoCompleto;
        existente.NumeroCartaoSUS = paciente.NumeroCartaoSUS;
        existente.EstadoCivil = paciente.EstadoCivil;
        existente.PossuiPlanoSaude = paciente.PossuiPlanoSaude;

        _context.SaveChanges();
        return NoContent();
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
