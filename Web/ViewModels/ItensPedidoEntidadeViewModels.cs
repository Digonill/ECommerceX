using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Web.ViewModels
{

    public class ItensPedidoEntidadeViewModels
    {
        [DisplayName("ID")]
        public Guid ID { get; set; }

        [DisplayName("Nome do Produto")]
        public string NomeProduto { get; set; }

        [DisplayName("Valor Unitario")]
        public decimal ValorUnitario { get; set; }

        [DisplayName("Valor Total")]
        public decimal ValorTotal { get; set; }

        [DisplayName("Quantidade")]
        public int Quantidade { get; set; }
    }
}