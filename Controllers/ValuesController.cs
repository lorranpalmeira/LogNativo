using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogNativoExemplo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace LogNativoExemplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            this._logger = logger;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var pessoa = new Pessoa();
            pessoa.Nome="Lorran";
            pessoa.Idade=27;

            var pessoaToJson = JsonConvert.SerializeObject(pessoa);

            _logger.LogInformation("Primeiro Log");

             _logger.LogInformation($"Log Pessoa {pessoaToJson}");

            return new string[] { "value1", "value2" };
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
