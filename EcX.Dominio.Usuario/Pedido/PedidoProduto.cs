using EcX.Dominio.Interface.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcX.Dominio.Usuario.Entidade
{
    public class PedidoProduto : EntidadeGuidIDBase
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
    }
}
