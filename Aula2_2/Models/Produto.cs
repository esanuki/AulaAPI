using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aula2_2.Models
{
    public class Produto
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int Estoque { get; set; }
        public int EstoqueMinimo { get; set; }
    }
}