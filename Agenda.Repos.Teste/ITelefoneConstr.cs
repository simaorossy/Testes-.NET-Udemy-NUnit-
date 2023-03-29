using Agenda.Model;
using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Repos.Teste
{


    public class ITelefoneConstr : BaseConstr<ITelefone>
    {
        protected readonly Mock<ITelefone> _mTelefone ;
        //protected readonly Fixture _fixture;

        protected ITelefoneConstr(Mock<ITelefone> mTelefone)//, Fixture fixture)
        {
            _mTelefone = mTelefone;
            //_fixture = fixture;
        }

        public static ITelefoneConstr Um()
        {
            return new ITelefoneConstr(new Mock<ITelefone>());//, new Fixture());
        }

        public ITelefoneConstr Padrao()
        {
            _mTelefone.SetupGet(o => o.Id).Returns(_fixture.Create<int>());
            _mTelefone.SetupGet(o => o.Numero).Returns(_fixture.Create<string>());
            _mTelefone.SetupGet(o => o.ContatoId).Returns(_fixture.Create<int>());
            return this;
        }

        //FOI PRA HERANÇA
        //public ITelefone Contruir()
        //{
        //    return _mTelefone.Object;
        //}

        public ITelefoneConstr ComId(int id)
        {
            _mTelefone.SetupGet(o => o.Id).Returns(id);
            return this;
        }

        public ITelefoneConstr ComNumero(string numero)
        {
            _mTelefone.SetupGet(o => o.Numero).Returns(numero);
            return this;
        }

        public ITelefoneConstr ComContatoId(int contatoId)
        {
            _mTelefone.SetupGet(o => o.ContatoId).Returns(contatoId);
            return this;
        }

        //mTelefone.SetupGet(x => x.Id).Returns(telefoneId);
        //mTelefone.SetupGet(x => x.Numero).Returns("23123-13213");
        //mTelefone.SetupGet(x => x.ContatoId).Returns(contatoId);



    }
}
