﻿using System.Text.Json.Serialization;

namespace HOSPISIM.Entities
{
    public class Internacao
    {
        public Guid Id { get; set; }
        public Guid PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        public Guid AtendimentoId { get; set; }

        [JsonIgnore]
        public Atendimento Atendimento { get; set; }

        public DateTime DataEntrada { get; set; }
        public DateTime? PrevisaoAlta { get; set; }
        public string MotivoInternacao { get; set; }
        public string Leito { get; set; }
        public string Quarto { get; set; }
        public string Setor { get; set; }
        public string? PlanoSaudeUtilizado { get; set; }
        public string ObservacoesClinicas { get; set; }
        public string StatusInternacao { get; set; }

        // Relacionamento 0..1:1 com AltaHospitalar
        [JsonIgnore] // Evita o ciclo
        public AltaHospitalar AltaHospitalar { get; set; }
    }
}
