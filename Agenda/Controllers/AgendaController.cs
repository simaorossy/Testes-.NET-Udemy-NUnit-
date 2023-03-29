using Agenda.DAL;
using Agenda.DAL.dto;
using Agenda.Infra;
using Agenda.Model;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;


namespace Agenda.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AgendaController : ControllerBase
    {
        private Contatos _contatos;
        private readonly ILogger<AgendaController> _logger;

        public AgendaController(ILogger<AgendaController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public IActionResult Save(string nome)
        {
 
            _contatos = new Contatos();

            Contato contato = new Contato() { Nome= nome};


            var id = _contatos.Adicionar(contato);

            return new ObjectResult(id);
        }

        [HttpGet("{id}")]
        public IActionResult Obter(int id)
        {
            _contatos = new Contatos();
            return new ObjectResult( _contatos.Obter(id) );
        }

        [HttpGet]
        public IEnumerable<Contato> ObterTodos()
        {
            _contatos = new Contatos();

            return _contatos.ObterTodos();
        }

        [HttpPost("testando/obj")]
        public IActionResult TesteEntrada([FromBody] Pessoa obj)
        {
            bool ret = true;

            if(string.IsNullOrEmpty(obj.Nome))
                ret = false;
            


            return new ObjectResult(ret);
        }
    }
}
