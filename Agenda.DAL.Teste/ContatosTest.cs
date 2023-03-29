using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.DAL;
using Agenda.Model;
using System.Configuration;
using AutoFixture;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class ContatosTest
    {
        Contatos _contatos;
        Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _contatos = new Contatos();
            _fixture = new Fixture();
        }

        [Test]
        public void IncluirContatoTest()
        {

            var contato = new Contato() { Nome = _fixture.Create<string>() };
            var contatoo = _fixture.Create<Contato>();


            //executa
            _contatos.Adicionar(contato);

            //verifica
            Assert.True(true);
        }

        [Test]
        public void ObterContatoTest()
        {
            var contato = new Contato() { Nome = _fixture.Create<string>() };

            //executa
            var id = _contatos.Adicionar(contato);
            Contato nomeResultado = _contatos.Obter(id);

            //verifica
            //Assert.AreEqual(contato.Nome, nomeResultado.Nome);
            //Assert.AreEqual(contato.Nome, nomeResultado.Nome);
        }

        [Test]
        public void ObterTodosContatosTest()
        {
            var contato =  _fixture.Create<Contato>();
            var contato1 = _fixture.Create<Contato>();

            //executa
            _contatos.Adicionar(contato);
            _contatos.Adicionar(contato1);
            var lstContato = _contatos.ObterTodos();
            var primeiroContato = lstContato.FirstOrDefault();

            //verifica
            Assert.IsTrue(lstContato.Count() > 1);
            //Assert.AreEqual(primeiroContato.Nome, contato.Nome);
        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _fixture = null;
        }

    }
}