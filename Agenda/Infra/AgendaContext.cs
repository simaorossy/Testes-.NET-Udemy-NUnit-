using Agenda.Model;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infra;
public class AgendaContext : DbContext
{

    public AgendaContext (DbContextOptions options) : base(options)
    {

    }

    public DbSet<Contato> Contatos { get; set; }
}
