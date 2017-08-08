using System;

using EcX.Dominio.Interface;
using EcX.Dominio.Entidade;
using System.Collections.Generic;

namespace EcX.Dominio.Servico
{
    public interface IProdutoServicoDominio : ICRUDServicoBase<ProdutoEntidade, Guid>
    {
        IEnumerable<ProdutoEntidade> BuscarPorNome(string nome);
    }
}
