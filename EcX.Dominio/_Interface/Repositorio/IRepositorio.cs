using System.Collections.Generic;

namespace EcX.Dominio.Interface
{
    public interface IRepositorio
    {

    }

    public interface IRepositorio<TEntidade, TIdentificador> : IRepositorio
        where TEntidade : class
    {
        void Inserir(TEntidade entidade);
        void Atualizar(TEntidade entidade);
        void Delete(TEntidade entidade);
        TEntidade BuscarPeloID(TIdentificador ID);
        IEnumerable<TEntidade> Listar();
    }
}
