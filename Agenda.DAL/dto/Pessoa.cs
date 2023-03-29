using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.DAL.dto
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public int Idade { get; set; }
        public string? Nome { get; set; } 
        public DateTime Nascimento { get; set; }
        public List<Endereco> Enderecos { get; set; } = new List<Endereco>();
        public List<Telefone> Telefones { get; set; } = new List<Telefone>();
    }
}
