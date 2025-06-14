﻿namespace HOSPISIM.DTO
{
    public class ExameDTO
    {
        public string Tipo { get; set; } // sangue, imagem, etc.
        public DateTime DataSolicitacao { get; set; }
        public DateTime? DataRealizacao { get; set; }
        public string Resultado { get; set; }

        public Guid AtendimentoId { get; set; }
        public AtendimentoDTO Atendimento { get; set; }
    }
}
