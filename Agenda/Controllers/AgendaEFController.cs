using Agenda.Infra;
using Agenda.Model;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgendaEFController : ControllerBase
    {
        private readonly AgendaContext _context;

        private readonly ILogger<AgendaEFController> _logger;

        public AgendaEFController(ILogger<AgendaEFController> logger, AgendaContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost(Name = "SalveContato")]
        public bool Save(string? nome)
        {
            Contato c = new Contato() { Nome = nome };

            _context.Contatos.Add(c);
            _context.SaveChanges();

            return true;
        }

        [HttpGet(Name = "ListarContato")]
        public IEnumerable<Contato> List()
        {

            return _context.Contatos.ToList();
        }
    }
}