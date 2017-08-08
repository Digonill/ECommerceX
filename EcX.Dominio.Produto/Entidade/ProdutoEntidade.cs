using EcX.Dominio.Interface.Entidade;

namespace EcX.Dominio.Produto
{
    public class ProdutoEntidade : EntidadeGuidIDBase, IEntidadeExclusaoLogica
    {
        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public string Descricao { get; set; }

        public bool RegistroExcluido { get; set; }

    }
}
