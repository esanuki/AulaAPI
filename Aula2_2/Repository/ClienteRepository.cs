using Aula2_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aula2_2.Repository
{
    static class ClienteRepository
    {
        public static List<Cliente> listaCliente;

        static ClienteRepository()
        {
            listaCliente = new List<Cliente>();
        }

        public static void AdicionarAlterarCliente(Cliente cliente)
        {
            var item = listaCliente.Find(x => x.ID == cliente.ID);
            if (item != null)
                AlterarCliente(cliente);
            else
                AdicionarCliente(cliente);
        }

        public static void AdicionarCliente(Cliente cliente)
        {
            listaCliente.Add(cliente);
        }

        public static void ExcluirCliente(int id)
        {
            var item = listaCliente.Find(x => x.ID == id);
            listaCliente.Remove(item);
        }

        public static void AlterarCliente(Cliente cliente)
        {
            var item = listaCliente.Find(x => x.ID == cliente.ID);
            listaCliente.Remove(item);
            listaCliente.Add(cliente);

        }

        public static List<Cliente> BuscarClienteSexo(char sexo)
        {
            
            //item = listaCliente.Find(x => x.ID == id);
            return listaCliente.FindAll(x => x.Sexo == sexo) ;
        }

        public static List<Cliente> BuscarClienteAtivo()
        {
            return listaCliente.FindAll(x => x.Ativo == true);
        }

        public static List<Cliente> BuscarClienteDiaMes(int dia, int mes)
        {
            return listaCliente.Where(x => x.DataNascimento.Day == dia 
                                        && x.DataNascimento.Month == mes).ToList();
        }

        public static List<Cliente> AlterarAtivo(int id, bool ativo)
        {
            var item = listaCliente.Find(x => x.ID == id);

            if (item != null)
                listaCliente.Find(x => x.ID == id).Ativo = ativo;

            return GetClientes();
        }

        public static List<Cliente> GetClientes()
        {
            return listaCliente.OrderBy(x => x.Nome).ToList();
        }

    }
}