using MySqlConnector;
using Dapper;


namespace API_Pessoa.Repository
{
    public class PessoaRepository
    {
        public List<Pessoa> SelecionarPessoas()
        {
            string query = "SELECT * FROM Pessoa";

            string stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");

            using MySqlConnection conn = new(stringConnection);

            return conn.Query<Pessoa>(query).ToList();
        }

        public void AdiocionarPessoa(Pessoa pessoa)
        {
            string query = $"INSERT INTO Pessoa (Nome, DataNascimento, QuantidadeFilhos, Idade) VALUES ('{pessoa.Nome}', " +
                $"'{pessoa.DataNascimento.ToString("yyyy-MM-dd")}', {pessoa.QuantidadeFilhos}, {pessoa.Idade})";


            string stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");

            using MySqlConnection conn = new(stringConnection);
            
            conn.Execute(query);
        }

        public void AtualizarPessoa(int index, Pessoa pessoa)
        {
            string query = $"UPDATE Pessoa SET Nome = '{pessoa.Nome}', DataNascimento = '{pessoa.DataNascimento.ToString("yyyy-MM-dd")}', " +
                $"QuantidadeFilhos = {pessoa.QuantidadeFilhos}, Idade = {pessoa.Idade} WHERE id = {index}";

            string stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");

            using MySqlConnection conn = new(stringConnection);

            conn.Execute(query);
        }

        public void DeletarPessoa(int index)
        {
            string query = $"DELETE FROM Pessoa WHERE id = {index}";

            string stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");

            using MySqlConnection conn = new(stringConnection);

            conn.Execute(query);
        }
    }
}