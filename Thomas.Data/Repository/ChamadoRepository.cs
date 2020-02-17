using System;
using System.Collections.Generic;
using Thomas.Business.Models;
using Thomas.Business.Interfaces;
using System.Threading.Tasks;
using Thomas.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Thomas.Data.Repository
{
    public class ChamadoRepository : Repository<Chamado>, IChamadoRepository
    {
        public ChamadoRepository(MeuDbContext context) : base(context)
        {  }

        public async Task<Chamado> ObterChamadoFornecedor(Guid id)
        {
            return await Db.Chamados.AsNoTracking().Include(f => f.Fornecedor)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Chamado>> ObterChamadosFornecedores()
        {
            return await Db.Chamados.AsNoTracking().Include(f => f.Fornecedor)
                .OrderBy(c => c.Titulo).ToListAsync();
        }

        public async Task<IEnumerable<Chamado>> ObterChamadosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(c => c.FornecedorId == fornecedorId);
        }
    }
}
