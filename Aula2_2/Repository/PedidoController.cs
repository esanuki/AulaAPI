using Aula2_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Aula2_2.Repository
{
    [RoutePrefix("api/pedido")]
    public class PedidoController : ApiController
    {

        [Route("{id}")]
        [HttpGet]
        public JsonPedido Get(int Id)
        {
            return PedidoRepository.GetPedidoPorId(Id);
        }

        [Route("")]
        [HttpPost]
        public string Post(JsonPedido jsonPedido)
        {
            if (VerificaEstoque(jsonPedido))
            {
                return "Existe(m) Produto(s) com estoque negativo.";
            }
            else
            {
                int resultado = PedidoRepository.Adicionar(jsonPedido);

                if (resultado == 200)
                    return "Salvou com sucesso";
                else
                    return "Falha na gravaçao";
            }

        }

        private bool VerificaEstoque(JsonPedido jsonPedido)
        {
            bool existeProdutoEstoqueNegativo = false;
            foreach (var itens in jsonPedido.ItensPedido)
            {
                var produto = ProdutoRepository.BuscarProduto(itens.Produto.ID);
                if (produto == null)
                {
                    if (itens.Produto.Estoque - itens.Quantidade < 0)
                    {
                        existeProdutoEstoqueNegativo = true;
                        break;
                    }
                }
                else
                {
                    if ((produto.Estoque - itens.Quantidade) < 0)
                    {
                        existeProdutoEstoqueNegativo = true;
                        break;
                    }
                }
            }

            return existeProdutoEstoqueNegativo;
        }

        [Route("{Id}")]
        [HttpDelete]
        public string Delete(int Id)
        {
            int resultado = PedidoRepository.Excluir(Id);

            if (resultado == 200)
                return "Excluido com sucesso";
            else
                return "Produto inexistente";
        }
    }
}
