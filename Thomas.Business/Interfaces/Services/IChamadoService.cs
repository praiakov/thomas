using System;
using System.Threading.Tasks;
using Thomas.Business.Models;

namespace Thomas.Business.Interfaces
{
    public interface IChamadoService : IDisposable
    {
        Task Adicionar(Chamado chamado);
        Task Atualizar(Chamado produto);
        Task Remover(Guid id);
    }
}
