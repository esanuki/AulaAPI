using Aula2_2.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Aula2_2.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/palindromo")]
    public class PalindromoController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="descricao"></param>
        /// <returns></returns>
        [Route("{descricao}")]
        [HttpGet]
        public bool Get(string descricao)
        {

            return IsPalindrome(descricao);
        }

        [HttpPost]
        [Route("")]
        public List<string> Post(List<string> values)
        {
            var listRetorno = new List<string>();
            foreach (var lista in values)
            {
                if (IsPalindrome(lista))
                    listRetorno.Add(lista);

            }

            return listRetorno;

        }

        public bool IsPalindrome(string value)
        {
            return value.MetodoString();
        }
    }
}