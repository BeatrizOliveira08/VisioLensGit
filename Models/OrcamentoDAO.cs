using VisioLens_Blazor.Configs;

namespace VisioLens_Blazor.Models
{
    public class OrcamentoDAO
    {
        private readonly Conexao _conexao;

        public OrcamentoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Orcamento> ListarTodos()
        {
            var lista = new List<Orcamento>();

            var comando = _conexao.CreateCommand("SELECT * FROM orcamento;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var orcamento = new Orcamento();
                orcamento.Id = leitor.GetInt32("id_orc");
                orcamento.Cliente = DAOHelper.GetString(leitor, "cliente_orc");
                orcamento.Fotografo = DAOHelper.GetString(leitor, "fotografo_orc");
                orcamento.PacoteDeFotos = DAOHelper.GetString(leitor, "pacote_fotos_orc");
                orcamento.ValorTotal = leitor.GetString("valor_total_orc");
                orcamento.Status = DAOHelper.GetString(leitor, "status_orc");
                orcamento.FormaDePagamento = DAOHelper.GetString(leitor, "forma_pagamento_orc");
                orcamento.TipoDeSessao = DAOHelper.GetString(leitor, "tipo_sessao_orc");

                lista.Add(orcamento);
            }

            return lista;
        }

        public void Inserir(Orcamento orcamento)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO orcamento VALUES (null, @_cliente, @_fotografo, @_pacoteDeFoto, @_valorTotal, @_status, @_formaDePagamento, @_tipoDeSessao)");

                comando.Parameters.AddWithValue("@_cliente", orcamento.Cliente);
                comando.Parameters.AddWithValue("@_fotografo", orcamento.Fotografo);
                comando.Parameters.AddWithValue("@_pacoteDeFoto", orcamento.PacoteDeFotos);
                comando.Parameters.AddWithValue("@_valorTotal", orcamento.ValorTotal);
                comando.Parameters.AddWithValue("@_status", orcamento.Status);
                comando.Parameters.AddWithValue("@_formaDePagamento", orcamento.FormaDePagamento);
                comando.Parameters.AddWithValue("@_tipoDeSessao", orcamento.TipoDeSessao);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Orcamento BuscarPorId(int Id)
        {
            var comando = _conexao.CreateCommand(
                "SELECT * FROM orcamento WHERE id_orc = @id;");
            comando.Parameters.AddWithValue("@id", Id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                var orcamento = new Orcamento();
                orcamento.Id = leitor.GetInt32("id_orc");
                orcamento.Cliente = DAOHelper.GetString(leitor, "cliente_orc");
                orcamento.Fotografo = DAOHelper.GetString(leitor,"fotografo_orc");
                orcamento.PacoteDeFotos = DAOHelper.GetString(leitor, "pacote_fotos_orc");
                orcamento.ValorTotal= DAOHelper.GetString(leitor,"valor_total_orc");
                orcamento.Status = DAOHelper.GetString(leitor, "status_orc");
                orcamento.FormaDePagamento = DAOHelper.GetString(leitor, "forma_pagamento_orc");
                orcamento.TipoDeSessao = DAOHelper.GetString(leitor, "tipo_sessao_orc");

                return orcamento;
            }
            else
            {
                return null;
            }
        }

        public void Atualizar(Orcamento orcamento)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                "UPDATE orcamento SET cliente_orc = @_cliente, fotografo_orc = @_fotografo, pacote_fotos_orc = @_pacote_foto, " +
                "valor_total_orc= @_valor_total, status_orc = @_status ,forma_pagamento_orc = @_forma_pagamento, tipo_sessao_orc = @_tipo_sessao  WHERE id_orc= @_id;");

                comando.Parameters.AddWithValue("@_cliente", orcamento.Cliente);
                comando.Parameters.AddWithValue("@_fotografo", orcamento.Fotografo);
                comando.Parameters.AddWithValue("@_pacote_foto", orcamento.PacoteDeFotos);
                comando.Parameters.AddWithValue("@_valor_total", orcamento.ValorTotal);
                comando.Parameters.AddWithValue("@_status", orcamento.Status);
                comando.Parameters.AddWithValue("@_forma_pagamento", orcamento.FormaDePagamento);
                comando.Parameters.AddWithValue("@_tipo_sessao", orcamento.TipoDeSessao);
                comando.Parameters.AddWithValue("@_id", orcamento.Id);

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
                "DELETE FROM orcamento WHERE id_orc = @id;");

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
