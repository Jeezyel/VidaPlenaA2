using System.Text.Json.Serialization;

namespace HOSPISIM.Entities
{
    public class Especialidade
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        // Relacionamento N:1 com ProfissionalSaude (1 especialidade para muitos profissionais)

        [JsonIgnore]
        public ICollection<ProfissionalSaude> Profissionais { get; set; }
    }
}
