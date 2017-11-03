using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Aula2_2.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime? DataEmissao { get; set; }
        public decimal Total { get; set; }
        public Cliente Cliente { get; set; }
    }

    public class ItensPedido
    {
        [IgnoreDataMember]
        public int IdPedido { get; set; }

        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorItem { get; set; }
    }

    public class JsonPedido
    {
        public Pedido Pedido { get; set; }
        public List<ItensPedido> ItensPedido { get; set; }
    }
}