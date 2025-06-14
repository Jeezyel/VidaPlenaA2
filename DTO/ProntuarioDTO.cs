﻿using HOSPISIM.Entities;

namespace HOSPISIM.DTO
{
    public class ProntuarioDTO
    {
        public string NumeroProntuario { get; set; }
        public DateTime DataAbertura { get; set; }
        public string ObservacoesGerais { get; set; }

        // FK e relacionamento com Paciente
        public Guid PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        // Relacionamento 1:N com Atendimento
        public ICollection<Atendimento> Atendimentos { get; set; }
    }
}
