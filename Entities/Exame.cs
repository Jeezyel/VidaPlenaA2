using System.Text.Json.Serialization;

namespace HOSPISIM.Entities
{
    public class Exame
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; } // sangue, imagem, etc.
        public DateTime DataSolicitacao { get; set; }
        public DateTime? DataRealizacao { get; set; }
        public string Resultado { get; set; }

        public Guid AtendimentoId { get; set; }

        [JsonIgnore]
        public Atendimento Atendimento { get; set; }
    }
}
