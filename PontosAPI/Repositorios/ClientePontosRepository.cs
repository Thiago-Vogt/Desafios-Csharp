using PontosAPI.Interfaces;
using PontosAPI.Models;
using System.Data.SqlClient;

namespace PontosAPI.Repositorios
{
    public class ClientePontosRepository : IRepository<ClientePontos, int, string>
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Padaria;Integrated Security=True";

        public ClientePontos Get(string cpf)
        {
            string selectQuery = "SELECT ClienteId, Nome, Cpf, PontosFidelidade FROM Cliente WHERE Cpf = @Cpf";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {
                command.Parameters.AddWithValue("@Cpf", cpf);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ClientePontos
                            {
                                Cpf = reader.GetString(reader.GetOrdinal("ClienteId")),
                                Pontos = reader.GetInt32(reader.GetOrdinal("PontosFidelidade"))
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
            return null;
        }

        public void AtualizarPontos(int id, int pontos)
        {
            string updateQuery = "UPDATE Cliente SET PontosFidelidade = PontosFidelidade + @Pontos WHERE ClienteId = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Pontos", pontos);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }
        }
    }
}
