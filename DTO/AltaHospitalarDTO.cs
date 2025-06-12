

using HOSPISIM.Entities;

namespace HOSPISIM.DTO
{
    public class AltaHospitalarDTO
    {

        public Guid InternacaoId { get; set; }
        public Internacao Internacao { get; set; }

        public DateTime Data { get; set; }
        public string CondicaoPaciente { get; set; }
        public string InstrucoesPosAlta { get; set; }
    }
}
