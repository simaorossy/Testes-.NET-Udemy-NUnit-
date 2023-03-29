using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Model;
using Agenda.DAL;
using Agenda.Repos;
using NUnit.Framework;
using Moq;


namespace Agenda.Repos.Teste
{
    [TestFixture]
    public class RepositorioContatosTest
    {
        Mock<IContatos> _contatos;
        Mock<ITelefones> _telefones;
        RepositorioContatos _repositorioContatos;



        [SetUp]
        public void SetUp()
        {
            _contatos = new Mock<IContatos>();
            _telefones = new Mock<ITelefones>();
            _repositorioContatos = new RepositorioContatos(_contatos.Object, _telefones.Object);
        }


        [Test]
        public void DeveSerPossivelObterContatoComListaTelefone()
        {
            int telefoneId = 5;
            int contatoId = 7;

            List<ITelefone> lstTelefone = new List<ITelefone>();

            //monta
            //CRIAR MOQ CONTATO
            //Mock<IContato> mContato = new Mock<IContato>();
            //mContato.SetupGet(x => x.Id).Returns(contatoId);
            //mContato.SetupGet(x => x.Nome).Returns("Simão");
            //mContato.SetupSet(x => x.Telefones = It.IsAny<List<ITelefone>>()).Callback<List<ITelefone>>(p=> lstTelefone = p);

            //CRIAR CONTATO ULTILIZANDO CONSTRUTOR
            Mock<IContato> mContato = IContatoConstr.Um().ComId(contatoId).ComNome("Simao").Obter();
            mContato.SetupSet(x => x.Telefones = It.IsAny<List<ITelefone>>()).Callback<List<ITelefone>>(p => lstTelefone = p);

            //moq da funcao de ObterPorId de IContatos

            //It.IsAny<int>()) = vai retornar o mContato.Object quando for qualquer int
            //_contatos.Setup(x => x.Obter(It.IsAny<int>())).Returns(mContato.Object);

            //Obter(5) = vai retornar o mContato.Object quando for 5 
            _contatos.Setup(x => x.Obter(contatoId)).Returns(mContato.Object);



            //CRIAR MOCK TELEFONE
            //Mock<ITelefone> mTelefone = new Mock<ITelefone>();
            //mTelefone.SetupGet(x => x.Id).Returns(telefoneId);
            //mTelefone.SetupGet(x => x.Numero).Returns("23123-13213");
            //mTelefone.SetupGet(x => x.ContatoId).Returns(contatoId);

            //CRIAR MOCK TELEFONE UTILIZANDO CONSTRUTOR
            //ITelefone mockTelefone = ITelefoneConstr.Um().ComId(telefoneId).ComNumero("2312-4564").ComContatoId(contatoId).Contruir();
            
            //CRIAR MOCK TELEGONE UTILIZANDO CONSTRUTOR E O FIXTURE
            ITelefone mockTelefone = ITelefoneConstr.Um().Padrao().ComId(telefoneId).ComContatoId(contatoId).Contruir();





            //moq da funcao de ObterTodosDoContato de ITelefones
            _telefones.Setup(x => x.ObterTodosDoContato(contatoId)).Returns(new List<ITelefone> { mockTelefone });


            //executa
            //chamar o metodo ObterPorId de RepositorioContatos
            IContato contatoResultado = _repositorioContatos.ObterPorId(contatoId);
            mContato.SetupGet(x => x.Telefones).Returns(lstTelefone);


            //verifica
            //verificar se o Contato retornado contem os mesmo dados do moq IContato com a lista de telefones do mow ITelefone
            Assert.AreEqual(mContato.Object.Id, contatoResultado.Id);
            Assert.AreEqual(mContato.Object.Nome, contatoResultado.Nome);
            Assert.AreEqual(1, contatoResultado.Telefones.Count());
            Assert.AreEqual(mockTelefone.Numero, contatoResultado.Telefones[0].Numero);
            Assert.AreEqual(mockTelefone.Id, contatoResultado.Telefones[0].Id);
            Assert.AreEqual(mockTelefone.ContatoId, contatoResultado.Telefones[0].ContatoId);

        }


        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _telefones = null;
            _repositorioContatos = null;
        }
    }
}
