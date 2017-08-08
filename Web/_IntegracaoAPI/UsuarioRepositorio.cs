using System;
using Web.ViewModels;
using Newtonsoft.Json;

namespace Web._IntegracaoAPI
{
    public class UsuarioRepositorio : BaseRepositorioAPI, IDisposable
    {
        const string API_USUARIO_AUTENTICAR = "api/usuario/autenticar";

        public UsuarioRepositorio()
        {

        }

        public UsuarioViewModel Autenticar(UsuarioViewModel usuario)
        {            
            return PostApi(usuario, API_USUARIO_AUTENTICAR);            
        }
        

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}