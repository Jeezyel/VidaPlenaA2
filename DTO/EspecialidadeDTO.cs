
using HOSPISIM.Entities;

namespace HOSPISIM.DTO

{
    public class EspecialidadeDTO
    {
        public string Nome { get; set; }

        // Relacionamento N:1 com ProfissionalSaude (1 especialidade para muitos profissionais)

        public Guid ProfissionaisSaudeId { get; set; }

    }
}
