using System;
using System.Threading.Tasks;
using Thomas.Business.Models;

namespace Thomas.Business.Interfaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task<Fornecedor> ObterFornecedorChamado(Guid id);
    }
}
