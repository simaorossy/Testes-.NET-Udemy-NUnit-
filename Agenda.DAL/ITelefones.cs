using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Model;

namespace Agenda.DAL
{
    public interface ITelefones
    {
        List<ITelefone> ObterTodosDoContato(int Id);

    }
}
