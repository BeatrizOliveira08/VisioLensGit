using VisioLens_Blazor.Configs;

namespace VisioLens_Blazor.Models
{
    public class ClienteDAO
    {
        private readonly Conexao _conexao;

        public ClienteDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Cliente> ListarTodos()
        {
            var lista = new List<Cliente>();

            var comando = _conexao.CreateCommand("SELECT * FROM cliente;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var cliente = new Cliente();
                cliente.Id = leitor.GetInt32("id_cli");
                cliente.Nome = DAOHelper.GetString(leitor, "nome_cli");
                cliente.CPF = DAOHelper.GetString(leitor, "cpf_cli");
                cliente.Telefone = DAOHelper.GetString(leitor, "telefone_cli");
                cliente.Endereco = DAOHelper.GetString(leitor, "endereco_cli");
                cliente.Email = DAOHelper.GetString(leitor, "email_cli");

                lista.Add(cliente);
            }

            return lista;
        }

        public void Inserir(Cliente cliente)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO cliente VALUES (null, @_nome, @_cpf, @_telefone, @_endereco, @_email)");

                comando.Parameters.AddWithValue("@_nome", cliente.Nome);
                comando.Parameters.AddWithValue("@_cpf", cliente.CPF);
                comando.Parameters.AddWithValue("@_telefone", cliente.Telefone);
                comando.Parameters.AddWithValue("@_endereco", cliente.Endereco);
                comando.Parameters.AddWithValue("@_email", cliente.Email);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Cliente BuscarPorId(int Id)
        {
            var comando = _conexao.CreateCommand(
                "SELECT * FROM cliente WHERE id_cli = @Id;");
            comando.Parameters.AddWithValue("@id", Id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                var cliente = new Cliente();
                cliente.Id = leitor.GetInt32("id_cli");
                cliente.Nome = DAOHelper.GetString(leitor, "nome_cli");
                cliente.CPF = DAOHelper.GetString(leitor,"cpf_cli");
                cliente.Telefone = DAOHelper.GetString(leitor, "telefone_cli");
                cliente.Email = DAOHelper.GetString(leitor, "email_cli");


                return cliente;
            }
            else
            {
                return null;
            }
        }

        public void Atualizar(Cliente cliente)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                "UPDATE cliente SET nome_cli = @_Nome, cpf_cli= @_cpf, " +
                "telefone_cli = @_telefone, email_cli = @_email WHERE id_cli = @_id;");

                comando.Parameters.AddWithValue("@_nome", cliente.Nome);
                comando.Parameters.AddWithValue("@_cpf", cliente.CPF);
                comando.Parameters.AddWithValue("@_telefone", cliente.Telefone);
                comando.Parameters.AddWithValue("@_email", cliente.Email);
                comando.Parameters.AddWithValue("@_id", cliente.Id);

                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        public void Excluir(int Id)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                "DELETE FROM cliente WHERE id_cli = @id;");

                comando.Parameters.AddWithValue("@id", Id);

                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }
    }
}
