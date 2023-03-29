using Agenda.DAL;
using Agenda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Repos
{
    public class RepositorioContatos
    {
        private readonly IContatos _contatos;
        private readonly ITelefones _telefones;

        public RepositorioContatos(IContatos contatos, ITelefones telefones)
        {
            _contatos = contatos;
            _telefones = telefones;
        }

        public IContato ObterPorId(int Id)
        {
            IContato contato = _contatos.Obter(Id);
            List<ITelefone> listTelefone = _telefones.ObterTodosDoContato(Id);
            contato.Telefones = listTelefone;     



            return contato;
        }
    }
}
