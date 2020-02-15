using System;

namespace Thomas.Business.Models
{
    public class Chamado : Entity
    {
        public Guid FornecedorId { get; set; }
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime DataAbertura { get; set; }

        public DateTime DataFechamento { get; set; }

        public DateTime DataRegistro { get; set; }

        public TipoStatus TipoStatus { get; set; }

        public Fornecedor Fornecedor { get; set; }
    }
}
