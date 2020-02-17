using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Thomas.Business.Models;

namespace Thomas.Business.Interfaces
{
    public interface IChamadoRepository : IRepository<Chamado>
    {
        Task<IEnumerable<Chamado>> ObterChamadosPorFornecedor(Guid id);

        Task<IEnumerable<Chamado>> ObterChamadosFornecedores();

        Task<Chamado> ObterChamadoFornecedor(Guid id);

    }
}
