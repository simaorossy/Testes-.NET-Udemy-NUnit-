using System.Data.SqlClient;
using System.Configuration;
using Agenda.Model;
using Dapper;




namespace Agenda.DAL
{
    public class Contatos
    {
        private string _connectionString;
        public Contatos()
        {
            //_connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            //Catalog = Agenda
            _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Agenda;User ID=sa;Password= 22111989 ;";

        }

        public int Adicionar(Contato contato)
        {
            var id = 0;
            using (var con = new SqlConnection(_connectionString))
            {
                //COM DAPPER
                string sql = String.Format("insert into Contatos (Nome) OUTPUT Inserted.Id values(@Nome);" );                
                 id = con.Execute(sql, new {Nome= contato.Nome });


                //SEM DAPPER
                //con.Open();
                //string sql = String.Format("insert into Contatos (Nome) OUTPUT Inserted.Id values('{0}');", contato.Nome);
                //SqlCommand cmd = new SqlCommand(sql, con);
                //var id = cmd.ExecuteNonQuery();
                //return id;
            }
            return id;
        }


        public Contato Obter(int id)
        {
            var contato = new Contato();
            using (var con = new SqlConnection(_connectionString))
            {
                //COM DAPPER
                string sql = String.Format("select Id, Nome from Contatos where id = @Id;");
                contato = con.QueryFirst<Contato>(sql , new { Id=id });



                //COM DAPPER
                //string sql = String.Format("select Id, Nome from Contatos where id = '{0}';", id);
                //contato = con.QueryFirst<Contato>(sql);


                ////SEM DAPPER
                //con.Open();

                //string sql = String.Format("select Id, Nome from Contatos where id = '{0}';", id);

                //SqlCommand cmd = new SqlCommand(sql, con);

                //var sqlDataReader = cmd.ExecuteReader();

                //sqlDataReader.Read();

                //contato = new Contato()
                //{
                //    Id = Int32.Parse(sqlDataReader["Id"].ToString()),
                //    Nome = sqlDataReader["Nome"].ToString()
                //};


            }
            return contato;
        }

        public List<Contato> ObterTodos()
        {
            var contatoList = new List<Contato>();

            using (var con = new SqlConnection(_connectionString))
            {
                //COM DAPPER
                string sql = String.Format("select Id, Nome from Contatos;");

                contatoList = con.Query<Contato>(sql).ToList();



                //SEM DAPPER
                //con.Open();

                //string sql = String.Format("select Id, Nome from Contatos;");

                //SqlCommand cmd = new SqlCommand(sql, con);

                //var sqlDataReader = cmd.ExecuteReader();

                //while (sqlDataReader.Read())
                //{
                //    var contato = new Contato()
                //    {
                //        Id = Int32.Parse(sqlDataReader["Id"].ToString()),
                //        Nome = sqlDataReader["Nome"].ToString()
                //    };

                //    contatoList.Add(contato);
                //}
            }

            return contatoList;
        }
    }
}
