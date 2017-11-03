using Aula2_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aula2_2.Repository
{
    static class ProdutoRepository
    {
        public static List<Produto> listaProdutos;

        static ProdutoRepository()
        {
            listaProdutos = new List<Produto>();
        }

        public static void AdicionarAlterarProduto(Produto produto)
        {
            var item = listaProdutos.Find(x => x.ID == produto.ID);
            if (item != null)
                AlterarProduto(produto);
            else
                AdicionarProduto(produto);
        }

        public static void AdicionarProduto(Produto produto)
        {
            listaProdutos.Add(produto);
        }

        public static void ExcluirProduto(int id)
        {
            var item = listaProdutos.Find(x => x.ID == id);
            listaProdutos.Remove(item);
        }

        public static void AlterarProduto(Produto produto)
        {
            var item = listaProdutos.Find(x => x.ID == produto.ID);
            listaProdutos.Remove(item);
            listaProdutos.Add(produto);

        }

        public static Produto BuscarProduto(int id)
        {
            Produto item = new Produto();
            item = listaProdutos.Find(x => x.ID == id);
            return item;
        }

        public static List<Produto> GetProdutos()
        {
            return listaProdutos;
        }

        public static List<Produto> GetProdutosEstoqueMinimo()
        {
            var itens = listaProdutos.FindAll(x => x.Estoque < x.EstoqueMinimo);
            return itens;
        }
    }
}