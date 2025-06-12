using System.Text.Json.Serialization;

namespace HOSPISIM.Entities
{
    public class Prontuario
    {
        public Guid Id { get; set; }
        public string NumeroProntuario { get; set; }
        public DateTime DataAbertura { get; set; }
        public string ObservacoesGerais { get; set; }

        // FK e relacionamento com Paciente
        public Guid PacienteId { get; set; }

        [JsonIgnore] // Evita o ciclo
        public Paciente Paciente { get; set; }

        // Relacionamento 1:N com Atendimento
        [JsonIgnore] // Evita o ciclo
        public ICollection<Atendimento> Atendimentos { get; set; }
    }
}
