using System;
using System.Threading.Tasks;
using Thomas.Business.Interfaces;
using Thomas.Business.Models;
using Thomas.Business.Models.Validations;

namespace Thomas.Business.Services
{
    public class ChamadoService : BaseService, IChamadoService
    {
        private readonly IChamadoRepository _chamadoRepository;

        public ChamadoService(IChamadoRepository chamadoRepository,
            INotificador notificador) : base(notificador)
        {
            _chamadoRepository = chamadoRepository;
        }

        public async Task Adicionar(Chamado chamado)
        {
            if (!ExecutarValidacao(new ChamadoValidation(), chamado)) return;

            await _chamadoRepository.Adicionar(chamado);

        }

        public async Task Atualizar(Chamado chamado)
        {
            if (!ExecutarValidacao(new ChamadoValidation(), chamado)) return;

            await _chamadoRepository.Atualizar(chamado);
    
        }

        public async Task Remover(Guid id)
        {
            await _chamadoRepository.Remover(id);
        }

        public void Dispose()
        {
            _chamadoRepository?.Dispose();
        }
    }
}
