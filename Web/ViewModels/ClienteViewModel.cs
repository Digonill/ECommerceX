using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.ViewModels
{
    public class ClienteViewModel
    {
        public string Nome { get; set; }
        public string Login { get; set; }

        public string Senha { get; set; }
        public bool IsAdministrador { get; set; }

        [Key]
        public Guid ID { get; set; }

        public List<PedidoEntidadeViewModels> Pedidos { get; set; }
    }
}