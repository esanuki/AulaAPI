using Aula2_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aula2_2.Repository
{
    static class PedidoRepository
    {
        static List<Pedido> listaPedidos;
        static List<ItensPedido> listaItensPedidos;

        static PedidoRepository()
        {
            listaPedidos = new List<Pedido>();
            listaItensPedidos = new List<ItensPedido>();
        }

        public static int Adicionar(JsonPedido json)
        {
            try
            {
                Pedido pedido = json.Pedido;

                AdicionarAlterarPedido(json.Pedido);
                ClienteRepository.AdicionarAlterarCliente(pedido.Cliente);

                foreach (var item in json.ItensPedido)
                {
                    ItensPedido itemPedido = item;
                    itemPedido.IdPedido = json.Pedido.Id;
                    AdicionarItensPedido(itemPedido);
                }
                return 200;
            }
            catch
            {
                return 400;
            }
            
        }

        static void AdicionarAlterarPedido(Pedido pedido)
        {
            Pedido item = listaPedidos.Find(x => x.Id == pedido.Id);

            if (item != null)
            {
                listaPedidos.Remove(item);
                listaPedidos.Add(pedido);
            }
            else
            {
                listaPedidos.Add(pedido);
            }
        }

        static void AdicionarItensPedido(ItensPedido item)
        {
            ProdutoRepository.AdicionarAlterarProduto(item.Produto);
            listaItensPedidos.Add(item);
        }

        public static JsonPedido GetPedidoPorId(int Id)
        {
            JsonPedido json = new JsonPedido();

            json.Pedido = listaPedidos.Find(x => x.Id == Id);
            json.ItensPedido = listaItensPedidos.FindAll(x => x.IdPedido == Id).ToList();

            return json;
        }

        public static int Excluir(int Id)
        {
            foreach(var itens in listaItensPedidos.FindAll(x => x.IdPedido == Id))
            {
                listaItensPedidos.Remove(itens);
            }

            var pedido = listaPedidos.Find(x => x.Id == Id);
            if (pedido != null)
            {
                listaPedidos.Remove(pedido);
                return 200;
            }
            else
                return 400;
                
        }
    }
}