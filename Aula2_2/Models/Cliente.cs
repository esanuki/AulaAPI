using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aula2_2.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }
        public bool Ativo { get; set; }
    }
}