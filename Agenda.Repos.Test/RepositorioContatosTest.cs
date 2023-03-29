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


namespace Agenda.Repos.Test
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
            //monta
            //criar moq de IContato
            Mock<IContato> mContato = new Mock<IContato>();
            mContato.SetupGet(x => x.Id).Returns(5);
            mContato.SetupGet(x => x.Nome).Returns("Simão");
            //moq da funcao de ObterPorId de IContatos
            _contatos.Setup(x => x.Obter(It.IsAny<int>())).Returns(mContato.Object);
            //criar moq de ITelefones
            Mock<ITelefone> mElefone = new Mock<ITelefone>();
            mElefone.SetupGet(x => x.Id).Returns(6);
            mElefone.SetupGet(x => x.Numero).Returns("23123-13213");
            mElefone.SetupGet(x => x.ContatoId).Returns(7);
            //moq da funcao de ObterTodosDoContato de ITelefones
            _telefones.Setup(x => x.ObterTodosDoContato(It.IsAny<int>())).Returns(new List<ITelefone> { mElefone.Object });
            //executa
            //chamar o metodo ObterPorId de RepositorioContatos
            IContato contatoResultado = _repositorioContatos.ObterPorId(8);
            //verifica
            //verificar se o Contato retornado contem os mesmo dados do moq IContato com a lista de telefones do mow ITelefone
            Assert.AreEqual(mContato.Object.Id, contatoResultado.Id);
            Assert.AreEqual(mContato.Object.Nome, contatoResultado.Nome);

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
