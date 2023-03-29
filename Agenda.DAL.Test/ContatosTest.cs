using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.DAL;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class ContatosTest
    {

        Contatos _contatos;


        [SetUp]
        public void SetUp()
        {
            _contatos = new Contatos();
        }


        [Test]
        public void IncluirContatoTest()
        {
            // monta
            string id = Guid.NewGuid().ToString();
            string nome = "simao";

            //executa
            _contatos.Adicionar(id, nome);


            //verifica
            Assert.True(true);
        }


        [Test]
        public void ObterContatoTest()
        {
            // monta
            string id = Guid.NewGuid().ToString();
            string nome = "Maria";

            //executa
            _contatos.Adicionar(id, nome);
            string nomeResultado = _contatos.Obter(id);


            //verifica
            Assert.AreEqual(nome, nomeResultado);
        }



        [TearDown]
        public void TearDown()
        {
            _contatos = null;

        }



    }
}
