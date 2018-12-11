using Microsoft.AspNetCore.Http;
using System;

namespace BiibleAPI.Util
{
    public class Autenticacao
    {
        public static string TOKEN = "AHBSHD7787AKJHS87987JHGSdsh82937";
        public static string FALHA_AUTENTICACAO = "Falha na autenticação ";
        private readonly IHttpContextAccessor contextAccessor;

        public Autenticacao(IHttpContextAccessor context)
        {
            contextAccessor = context;
        }

        public void Autenticar()
        {
            try
            {
                string TokenRecebido = contextAccessor.HttpContext.Request.Headers["Token"].ToString();

                if (string.Equals(TokenRecebido, TOKEN) == false)
                {
                    throw new Exception(FALHA_AUTENTICACAO);
                }

            }
            catch (Exception)
            {
                throw new Exception(FALHA_AUTENTICACAO);
            }
        }
    }
}
