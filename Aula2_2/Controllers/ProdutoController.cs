using Aula2_2.Models;
using Aula2_2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Aula2_2.Controllers
{
    [RoutePrefix("api/produto")]
    public class ProdutoController : ApiController
    {
        public IList<Produto> ListaProduto;

        [Route("")]
        [HttpGet]
        public List<Produto> BuscaProdutosEstoqueMinimo()
        {
            return ProdutoRepository.GetProdutosEstoqueMinimo();
        }

        [Route("")]
        [HttpPost]
        public List<Produto> Post(Produto produto)
        {
            ProdutoRepository.AdicionarProduto(produto);
            return ProdutoRepository.GetProdutos();
        }


        [Route("{id}")]
        [HttpDelete]
        public List<Produto> Delete(int id)
        {
            ProdutoRepository.ExcluirProduto(id);
            return ProdutoRepository.GetProdutos();
        }

        [Route("")]
        [HttpPut]
        public List<Produto> Put(Produto produto)
        {
            ProdutoRepository.AdicionarAlterarProduto(produto);
            return ProdutoRepository.GetProdutos();
        }

    }
}
