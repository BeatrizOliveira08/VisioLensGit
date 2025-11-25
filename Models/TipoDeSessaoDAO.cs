using VisioLens_Blazor.Configs;
using System.Data;


namespace VisioLens_Blazor.Models
{
    public class TipoDeSessaoDAO
    {
        private readonly Conexao _conexao;

        public TipoDeSessaoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<TipoDeSessao> ListarTodos()
        {
            var lista = new List<TipoDeSessao>();

            var comando = _conexao.CreateCommand("SELECT * FROM tipo_de_sessao;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var tipoDeSessao = new TipoDeSessao();
                tipoDeSessao.Id = leitor.GetInt32("id_tip_ses");
                tipoDeSessao.Duracao = DAOHelper.GetString(leitor, "duracao_tip_ses");
                tipoDeSessao.PrecoPadrao = DAOHelper.GetString(leitor, "preco_padrao_tip_ses");
                tipoDeSessao.Quantidade = DAOHelper.GetString(leitor, "quantidade_fotos_tip_ses");
                tipoDeSessao.Entrega = leitor.GetDateTime("entrega_tip_ses");
                tipoDeSessao.Observaçao = DAOHelper.GetString(leitor, "observacoes_tip_ses");
                tipoDeSessao.Categoria = DAOHelper.GetString(leitor, "categoria_tip_ses");

                lista.Add(tipoDeSessao);
            }

            return lista;
        }

        public void Inserir(TipoDeSessao tipoDeSessao)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO tipo_de_sessao VALUES (null, @_duracao, @_precoPadrao, @_quantidade, @_entrega, @_observacao, @_categoria)");

                comando.Parameters.AddWithValue("@_duracao", tipoDeSessao.Duracao);
                comando.Parameters.AddWithValue("@_precoPadrao", tipoDeSessao.PrecoPadrao);
                comando.Parameters.AddWithValue("@_quantidade", tipoDeSessao.Quantidade);
                comando.Parameters.AddWithValue("@_entrega", tipoDeSessao.Entrega);
                comando.Parameters.AddWithValue("@_observacao", tipoDeSessao.Observaçao);
                comando.Parameters.AddWithValue("_categoria", tipoDeSessao.Categoria);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
