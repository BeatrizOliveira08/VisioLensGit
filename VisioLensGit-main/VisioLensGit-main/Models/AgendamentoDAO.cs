using System.Data;
using VisioLens_Blazor.Components.Pages.Agendamento;
using VisioLens_Blazor.Components.Pages.ListaAgendamento;
using VisioLens_Blazor.Configs;
namespace VisioLens_Blazor.Models
{
    public class AgendamentoDAO
    {
        private readonly Conexao _conexao;

        public AgendamentoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Agendamento> ListarTodos()
        {
            var lista = new List<Agendamento>();

            var comando = _conexao.CreateCommand("SELECT * FROM agendamento;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var agendamento = new Agendamento 
                {
                    Id = leitor.GetInt32("id_agen"),
                    Cliente = DAOHelper.GetString(leitor, "cliente_agen"),
                    Data = leitor.GetDateTime("data_agen"),
                    TipoDeSessao = DAOHelper.GetString(leitor, "tipo_sessao_agen"),
                    Duracao = DAOHelper.GetString(leitor, "duracao_agen"),
                    Fotografo = DAOHelper.GetString(leitor, "fotografo_agen"),
                    Observacao = DAOHelper.GetString(leitor, "observacao_agen")
                };

                lista.Add(agendamento);
            }

            return lista;
        }

        public void Inserir(Agendamento agendamento)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO agendamento VALUES (null, @_cliente, @_data, @_tipoSessao, @_duracao, @_fotografo, @_observacao)");

                comando.Parameters.AddWithValue("@_cliente", agendamento.Cliente);
                comando.Parameters.AddWithValue("@_data", agendamento.Data);
                comando.Parameters.AddWithValue("@_tipoSessao", agendamento.TipoDeSessao);
                comando.Parameters.AddWithValue("@_duracao", agendamento.Duracao);
                comando.Parameters.AddWithValue("@_fotografo", agendamento.Fotografo);
                comando.Parameters.AddWithValue("@_observacao", agendamento.Observacao);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Agendamento? BuscarPorId(int Id)
        {
            var comando = _conexao.CreateCommand(
                "SELECT * FROM agendamento WHERE id_agen = @id;");
            comando.Parameters.AddWithValue("@id", Id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                var agendamento = new Agendamento();
                agendamento.Id = leitor.GetInt32("id_agen");
                agendamento.Cliente = DAOHelper.GetString(leitor, "cliente_agen");
                agendamento.Data = leitor.GetDateTime("data_agen");
                agendamento.TipoDeSessao = DAOHelper.GetString(leitor, "tipo_sessao_agen");
                agendamento.Duracao = DAOHelper.GetString(leitor, "duracao_agen");
                agendamento.Fotografo = DAOHelper.GetString(leitor, "fotografo_agen");
                agendamento.Observacao = DAOHelper.GetString(leitor, "observacao_agen");

                return agendamento;
            }
            else
            {
                return null;
            }
        }

        public void Atualizar(Agendamento agendamento)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                "UPDATE agendamento SET cliente_agen = @_cliente, data_agen = @_data, " +
                "tipo_sessao_agen = @_tipoSessao, duracao_agen = @_duracao, fotografo_agen = @_fotografo, " +
                "observacao_agen = @_observacao WHERE id_agen = @_id;");

                comando.Parameters.AddWithValue("@_cliente", agendamento.Cliente);
                comando.Parameters.AddWithValue("@_data", agendamento.Data);
                comando.Parameters.AddWithValue("@_tipoSessao", agendamento.TipoDeSessao);
                comando.Parameters.AddWithValue("@_duracao", agendamento.Duracao);
                comando.Parameters.AddWithValue("@_fotografo", agendamento.Fotografo);
                comando.Parameters.AddWithValue("@_observacao", agendamento.Observacao);
                comando.Parameters.AddWithValue("@_id", agendamento.Id);

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
                "DELETE FROM agendamento WHERE id_agen = @id;");

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
