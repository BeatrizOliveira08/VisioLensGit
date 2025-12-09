using VisioLens_Blazor.Configs;

namespace VisioLens_Blazor.Models
{
    public class PagamentoDAO
    {
        private readonly Conexao _conexao;

        public PagamentoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Pagamento> ListarTodos()
        {
            var lista = new List<Pagamento>();

            var comando = _conexao.CreateCommand("SELECT * FROM pagamento");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var pagamento = new Pagamento();
                pagamento.Id = leitor.GetInt32("id_pag");
                pagamento.Cliente = DAOHelper.GetString(leitor, "cliente_pag");
                pagamento.Fotografo = DAOHelper.GetString(leitor, "fotografo_pag");
                pagamento.PacoteContratado = DAOHelper.GetString(leitor, "pacote_contratado_pag");
                pagamento.ValorPago = leitor.GetDecimal("valor_pago_pag");
                pagamento.ValorTotal = leitor.GetDecimal("valor_total_pag");
                pagamento.ValorRestante = leitor.GetDecimal("valor_restante_pag");
                pagamento.FormaPagamento = DAOHelper.GetString(leitor, "forma_pag");
                pagamento.StatusPagamento = DAOHelper.GetString(leitor, "status_pag");


                lista.Add(pagamento);
            }

            return lista;
        }

        public void Inserir(Pagamento pagamento)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO pagamento VALUES (null, @_cliente, @_fotografo, @_pacote, @_valorPago, @_valorTotal, @_valorRestante, @_formaPagamento, @_statusPagamento)");

                comando.Parameters.AddWithValue("@_cliente", pagamento.Cliente);
                comando.Parameters.AddWithValue("@_fotografo", pagamento.Fotografo);
                comando.Parameters.AddWithValue("@_pacote", pagamento.PacoteContratado);
                comando.Parameters.AddWithValue("@_valorPago", pagamento.ValorPago);
                comando.Parameters.AddWithValue("@_valorTotal", pagamento.ValorTotal);
                comando.Parameters.AddWithValue("@_valorRestante", pagamento.ValorRestante);
                comando.Parameters.AddWithValue("@_formaPagamento", pagamento.FormaPagamento);
                comando.Parameters.AddWithValue("@_statusPagamento", pagamento.StatusPagamento);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }


        }

        public void Atualizar(Pagamento pagamento)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                "UPDATE pagamento SET cliente_pag = @_cliente, fotografo_pag = @_fotografo, pacote_contratado_pag = @_pacote_contratado, " +
                "valor_pago_pag = @_valor_pago, valor_total_pag = @_valor_total, valor_restante_pag = @_valor_restante, forma_pag = @_forma_pagamento, status_pag = @_status  WHERE id_pag= @_id;");

                comando.Parameters.AddWithValue("@_cliente", pagamento.Cliente);
                comando.Parameters.AddWithValue("@_fotografo", pagamento.Fotografo);
                comando.Parameters.AddWithValue("@_pacote_contratado", pagamento.PacoteContratado);
                comando.Parameters.AddWithValue("@_valor_pago", pagamento.ValorPago);
                comando.Parameters.AddWithValue("@_valor_total", pagamento.ValorTotal);
                comando.Parameters.AddWithValue("@_valor_restante", pagamento.ValorRestante);
                comando.Parameters.AddWithValue("@_forma_pagamento", pagamento.FormaPagamento);
                comando.Parameters.AddWithValue("@_status", pagamento.StatusPagamento);
                comando.Parameters.AddWithValue("@_id", pagamento.Id);

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
                "DELETE FROM pagamento WHERE id_pag = @id;");

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
