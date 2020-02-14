using System.Collections.Generic;

namespace Thomas.Business.Models
{
    public class Fornecedor : Entity
    {
        public string Nome { get; set; }

        public string Contato { get; set; }

        public bool Ativo { get; set; }

        public IEnumerable<Chamado> Chamados { get; set; }
    }
}
