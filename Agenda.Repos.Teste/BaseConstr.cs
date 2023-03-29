using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Repos.Teste
{
    public class BaseConstr<T> where T : class
    {
        protected readonly Fixture _fixture;
        protected readonly Mock<T> _mock;

        protected BaseConstr()
        {
            _fixture = new Fixture();
        }

        public T Construir()
        {
            return _mock.Object;
        }

    }
}
