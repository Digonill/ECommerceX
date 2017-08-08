using EcX.Dominio.Interface;
using System.Collections.Generic;

namespace EcX.Dominio
{
    public abstract class BaseServicoDominio<TIReposirorio, TEntidade, TIdentificador> : ICRUDServicoBase<TEntidade, TIdentificador>
        where TIReposirorio : IRepositorio<TEntidade, TIdentificador>
        where TEntidade : class, IEntidade<TIdentificador>
        where TIdentificador : struct
    {
        protected readonly TIReposirorio _repositorio;

        public BaseServicoDominio(TIReposirorio respositorio)
        {
            _repositorio = respositorio;
        }


        public void Atualizar(TEntidade entidade)
        {
            _repositorio.Atualizar(entidade);
        }

        public TEntidade BuscarPeloID(TIdentificador ID)
        {
            return _repositorio.BuscarPeloID(ID);
        }

        public void Remover(TEntidade entidade)
        {
            _repositorio.Delete(entidade);
        }

        public void Inserir(TEntidade entidade)
        {
            _repositorio.Inserir(entidade);
        }

        public IEnumerable<TEntidade> Listar()
        {
            return _repositorio.Listar();
        }
    }
}
