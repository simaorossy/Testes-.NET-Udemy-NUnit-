using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Agenda.DAL.Teste
{
    [TestFixture]
    internal class BaseTest
    {
        string _script;
        string _connectionString;

        public BaseTest()
        {
            _script = @"ProjetoDB_Create.sql";
            _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=AgendaTeste;User ID=sa;Password= 22111989 ;";

        }


        [OneTimeSetUp]
        public void OneTimeSetup()
        {

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

        }

    }
}
