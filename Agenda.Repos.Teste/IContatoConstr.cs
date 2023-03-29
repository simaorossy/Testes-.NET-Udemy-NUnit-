﻿using Agenda.Model;
using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Repos.Teste
{
    public  class IContatoConstr :BaseConstr<IContato>
    {
        private readonly Mock<IContato> _mockIContato;



        protected IContatoConstr(Mock<IContato> mockIContato)//, Fixture fixture )
        {
            _mockIContato = mockIContato;
        }

        public static IContatoConstr Um()
        {
            return new IContatoConstr(new Mock<IContato>());//, new Fixture());
        }

        //FOI PRA HERANÇA
        //public IContato Construir()
        //{
        //    return _mockIContato.Object;
        //}

        public Mock<IContato> Obter()
        {
            return _mockIContato;
        }


        public IContatoConstr ComNome(string nome)
        {
            _mockIContato.SetupGet(o=>o.Nome).Returns(nome);
            return this;
        }
        public IContatoConstr ComId(int id)
        {
            _mockIContato.SetupGet(o => o.Id).Returns(id);
            return this;
        }

    }
}
