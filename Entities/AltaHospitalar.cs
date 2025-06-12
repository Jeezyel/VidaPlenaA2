using System.Text.Json.Serialization;

namespace HOSPISIM.Entities
{
    public class AltaHospitalar
    {
        public Guid Id { get; set; }
        public Guid InternacaoId { get; set; }

        [JsonIgnore]
        public Internacao Internacao { get; set; }

        public DateTime Data { get; set; }
        public string CondicaoPaciente { get; set; }
        public string InstrucoesPosAlta { get; set; }
    }
}
