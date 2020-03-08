using Microsoft.AspNetCore.Mvc.Razor;

namespace Thomas.App.Extensions
{
    public static class RazorExtensions
    {
        public static string FormataStatus(this RazorPage page, int tipoStatus)
        {
            if (tipoStatus == 1) return "Aberto";

            if (tipoStatus == 2) return "Fechado";

            if (tipoStatus == 3) return "Pausado";

            return "Cancelado";
        }
    }
}
