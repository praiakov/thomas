using Microsoft.AspNetCore.Mvc.Razor;
using System;

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

        public static string FormataData(this RazorPage page, string data)
        {

            var dataT = Convert.ToDateTime(data);

            return dataT.ToString("dd/MM/yyyy");
        }
    }
}
