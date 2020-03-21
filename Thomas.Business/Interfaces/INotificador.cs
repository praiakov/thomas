using System.Collections.Generic;
using Thomas.Business.Notifications;

namespace Thomas.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();

        List<Notificacao> ObterNotificacoes();

        void Handle(Notificacao notificacao);

    }
}
