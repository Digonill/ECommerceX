using System.Collections.Generic;

namespace EcX.Dominio.Interface
{
    public interface ICRUDServicoBase<TEntidade, TIdentificador>
        where TEntidade : class, IEntidade
        where TIdentificador : struct
    {
        void Inserir(TEntidade entidade);
        void Atualizar(TEntidade entidade);
        void Remover(TEntidade entidade);
        TEntidade BuscarPeloID(TIdentificador ID);
        IEnumerable<TEntidade> Listar();
    }
}
