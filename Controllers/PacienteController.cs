using HOSPISIM.DTO;
using HOSPISIM.Entities;
using HOSPISIM.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

[Route("api/paciente")]
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
        if (dto == null)
            return BadRequest("Dados do paciente são obrigatórios.");

        var prontuario = _context.Prontuarios.Find(dto.ProntuarioIds);

        if (prontuario == null)
            return BadRequest("Prontuário não encontrado.");

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
            EstadoCivil = dto.EstadoCivil,
            PossuiPlanoSaude = dto.PossuiPlanoSaude,
            Prontuarios = new List<Prontuario> { prontuario }
        };

        try
        {
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            // Logar o erro se necessário
            return StatusCode(500, "Erro ao salvar paciente: " + ex.Message);
        }

        // Retorne um DTO ou ViewModel se possível
        return CreatedAtAction(nameof(GetById), new { id = paciente.Id }, new
        {
            paciente.Id,
            paciente.NomeCompleto,
            paciente.CPF,
            paciente.DataNascimento
        });
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, PacienteDTO dto)
    {
        if (dto == null)
            return BadRequest("Dados do paciente são obrigatórios.");

        var pacienteExistente = _context.Pacientes
            .Include(p => p.Prontuarios)
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

        // Atualiza o prontuário associado (se algum foi passado)
        if (dto.ProntuarioIds != Guid.Empty)
        {
            var prontuario = _context.Prontuarios.Find(dto.ProntuarioIds);
            if (prontuario == null)
                return BadRequest("Prontuário não encontrado.");

            // Adiciona apenas se não estiver presente
            if (!pacienteExistente.Prontuarios.Any(p => p == prontuario))
            {
                pacienteExistente.Prontuarios.Add(prontuario);
            }
        }

        try
        {
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            // Logar o erro se necessário
            return StatusCode(500, "Erro ao atualizar paciente: " + ex.Message);
        }

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
