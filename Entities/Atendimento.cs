namespace HOSPISIM.Entities
{
    public class Atendimento
    {
        public Guid Id { get; set; }
        public DateTime DataHora { get; set; }
        public string Tipo { get; set; } // Ex: emergência, consulta, internação
        public string Status { get; set; } // Ex: realizado, em andamento, cancelado
        public string Local { get; set; } // Ex: sala 01

        // FK e relacionamento com Paciente, ProfissionalSaude e Prontuario
        public Guid PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        public Guid ProfissionalId { get; set; }
        public ProfissionalSaude Profissional { get; set; }

        public Guid ProntuarioId { get; set; }
        public Prontuario Prontuario { get; set; }

        // Relacionamentos 1:N
        public ICollection<Prescricao> Prescricoes { get; set; }
        public ICollection<Exame> Exames { get; set; }

        // Relacionamento 0..1:1 com Internacao
        public Internacao Internacao { get; set; }
    }
}
