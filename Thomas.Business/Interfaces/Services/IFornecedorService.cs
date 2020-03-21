using System;
using System.Threading.Tasks;
using Thomas.Business.Models;

namespace Thomas.Business.Interfaces.Services
{
    public interface IFornecedorService : IDisposable
    {
        Task Adicionar(Fornecedor fornecedor);
        Task Atualizar(Fornecedor fornecedor);
        Task Remover(Guid id);
    }
}
