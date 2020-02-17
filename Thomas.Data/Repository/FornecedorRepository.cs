using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Thomas.Business.Interfaces;
using Thomas.Business.Models;
using Thomas.Data.Context;

namespace Thomas.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MeuDbContext context) : base(context)
        {  }

        public async Task<Fornecedor> ObterFornecedorChamado(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking().Include(c => c.Chamados)
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
