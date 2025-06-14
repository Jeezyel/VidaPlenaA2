﻿using System.Text.Json.Serialization;

namespace HOSPISIM.Entities
{

    public class Prescricao
    {
        public Guid Id { get; set; }
        public Guid AtendimentoId { get; set; }

        [JsonIgnore]
        public Atendimento Atendimento { get; set; }

        public Guid ProfissionalId { get; set; }

        [JsonIgnore]
        public ProfissionalSaude Profissional { get; set; }

        public string Medicamento { get; set; }
        public string Dosagem { get; set; }
        public string Frequencia { get; set; }
        public string ViaAdministracao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string Observacoes { get; set; }
        public string StatusPrescricao { get; set; }
        public string? ReacoesAdversas { get; set; }
    }

}
