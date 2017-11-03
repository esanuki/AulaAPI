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
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {
        [Route("{sexo}")]
        [HttpGet]
        public List<Cliente> GetSexo(char sexo)
        {
            return ClienteRepository.BuscarClienteSexo(sexo);
        }

        [Route("")]
        [HttpGet]
        public List<Cliente> GetAtivo()
        {
            return ClienteRepository.BuscarClienteAtivo();
        }

        [Route("{dia}/{mes}")]
        [HttpGet]
        public List<Cliente> GetDiaMes(int dia, int mes)
        {
            return ClienteRepository.BuscarClienteDiaMes(dia, mes);
        }

        [Route("{id}/{ativo}")]
        [HttpPut]
        public List<Cliente> AlterarAtivo(int id, bool ativo)
        {
            return ClienteRepository.AlterarAtivo(id,ativo);
        }

        [Route("")]
        [HttpPost]
        public List<Cliente> Post(Cliente cliente)
        {
            ClienteRepository.AdicionarAlterarCliente(cliente);
            return ClienteRepository.GetClientes();
        }
    }
}
