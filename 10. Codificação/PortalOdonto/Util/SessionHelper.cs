using System;
using System.Web;

namespace PortalOdonto.Util
{
    public enum SessionKey { ADMINISTRADOR, USUARIO}

    public static class SessionHelper
    {
        public static Object Get(SessionKey chave)
        {
            String chaveString = Enum.GetName(typeof(SessionKey), chave);
            return HttpContext.Current.Session[chaveString];
        }

        public static Object Set(SessionKey chave, Object valor)
        {
            String chaveString = Enum.GetName(typeof(SessionKey), chave);
            return HttpContext.Current.Session[chaveString] = valor;
        }
    }
}