using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MercadoZe.Classlib.DAO
{
    public class ProdutoDAO
    {
        private const string _connectionString = @"Data Source=.\SQLEXPRESS;initial catalog=MERCADOZEDB;uid=sa;pwd=trop";

        public ProdutoDAO()
        {
            
        }

        //CRUD
        public void AdicionaProduto(Produto novoProduto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"INSERT PRODUTOS VALUES (@NOME, @DESCRICAO, @DATAVENCIMENTO, @PRECO, @UNIDADE, @QTDESTOQUE);";
                    ConverteObjetoParaSql(novoProduto, command);                    
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }
        
        public List<Produto> BuscaTodosProdutos()
        {
            var listaProdutos = new List<Produto>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM PRODUTOS;";
                    command.CommandText = sql;
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Produto produtoBuscado = ConverteSqlParaObjeto(reader);
                        listaProdutos.Add(produtoBuscado);
                    }
                }
            }
            return listaProdutos;
        }

        public Produto BuscaProdutoId(int idDigitado)
        {
            Produto produtoBuscado = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM PRODUTOS WHERE ID = @ID_PRODUTO;";
                    command.Parameters.AddWithValue("@ID_PRODUTO", idDigitado);
                    command.CommandText = sql;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        produtoBuscado = ConverteSqlParaObjeto(reader);    
                    }
                }                
            }
            return produtoBuscado;
        }

        public List<Produto> BuscaProdutoDescricao(string produtoDigitado)
        {
            var listaProdutos = new List<Produto>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM PRODUTOS WHERE Nome LIKE '%'+@DESCRICAO_DIGITADA+'%';";
                    command.Parameters.AddWithValue("@DESCRICAO_DIGITADA", produtoDigitado);
                    command.CommandText = sql;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Produto produtoBuscado = ConverteSqlParaObjeto(reader);
                        listaProdutos.Add(produtoBuscado);
                    }
                }                
            }
            return listaProdutos;
        }
        
        public void AtualizaProduto(Produto produtoEditado)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"UPDATE PRODUTOS SET NOME = @NOME, DESCRICAO = @DESCRICAO, DATAVENCIMENTO = @DATAVENCIMENTO, PRECO = @PRECO, UNIDADE = @UNIDADE, QUANTIDADEESTOQUE = @QTDESTOQUE WHERE ID = @ID_PRODUTO;";
                    command.Parameters.AddWithValue("@ID_PRODUTO", produtoEditado.Id);
                    ConverteObjetoParaSql(produtoEditado, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeletaProduto(Produto produtoDeletado)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"DELETE FROM PRODUTOS WHERE ID = @ID_PRODUTO;";
                    command.Parameters.AddWithValue("@ID_PRODUTO", produtoDeletado.Id);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool ProdutoEmUso(int id)
        {
            bool produtoExiste = false;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM PEDIDOS WHERE ID_PRODUTO = @ID_DIGITADO";
                    command.Parameters.AddWithValue("@ID_DIGITADO", id);
                    command.CommandText = sql;
                    SqlDataReader reader = command.ExecuteReader();
                    
                    if (reader.Read())
                    {
                        produtoExiste = true;
                    }
                    else
                    {
                        produtoExiste = false;
                    }

                    
                }
            }
            return produtoExiste;
        }

        public bool ProdutoExiste(int id)
        {
            bool produtoExiste = false;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM PRODUTOS WHERE ID = @ID_DIGITADO";
                    command.Parameters.AddWithValue("@ID_DIGITADO", id);
                    command.CommandText = sql;
                    SqlDataReader reader = command.ExecuteReader();
                    
                    if (reader.Read())
                    {
                        produtoExiste = true;
                    }
                    else
                    {
                        produtoExiste = false;
                    }

                    
                }
            }
            return produtoExiste;
        }

        public void EntradaEstoque(Produto produtoAdicionado, int qtdAdicionar)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"UPDATE PRODUTOS SET QUANTIDADEESTOQUE = QUANTIDADEESTOQUE + @QTDADICIONAR WHERE ID = @ID_PRODUTO";
                    command.Parameters.AddWithValue("@ID_PRODUTO", produtoAdicionado.Id);
                    command.Parameters.AddWithValue("@QTDADICIONAR", qtdAdicionar);
                    ConverteObjetoParaSql(produtoAdicionado, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void SaidaEstoque(Produto produtoSubtraido, int qtdSubtrair)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"UPDATE PRODUTOS SET QUANTIDADEESTOQUE = QUANTIDADEESTOQUE - @QTDSUBTRAIR WHERE ID = @ID_PRODUTO";
                    command.Parameters.AddWithValue("@ID_PRODUTO", produtoSubtraido.Id);
                    command.Parameters.AddWithValue("@QTDSUBTRAIR", qtdSubtrair);
                    ConverteObjetoParaSql(produtoSubtraido, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }


        //CONVERSORES DE DADOS E OBJETOS
        private void ConverteObjetoParaSql(Produto produto, SqlCommand command)
        {
            command.Parameters.AddWithValue("@ID", produto.Id);
            command.Parameters.AddWithValue("@NOME", produto.Nome);
            command.Parameters.AddWithValue("@DESCRICAO", produto.Descricao);
            command.Parameters.AddWithValue("@DATAVENCIMENTO", produto.DataVencimento);
            command.Parameters.AddWithValue("@PRECO", produto.Preco);
            command.Parameters.AddWithValue("@UNIDADE", produto.Unidade);
            command.Parameters.AddWithValue("@QTDESTOQUE", produto.QuantidadeEmEstoque);

        }
        
        private Produto ConverteSqlParaObjeto(SqlDataReader reader)
        {
            Produto produtoBuscado = new Produto();
            produtoBuscado.Id = int.Parse(reader["ID"].ToString());
            produtoBuscado.Nome = reader["NOME"].ToString();
            produtoBuscado.Descricao = reader["DESCRICAO"].ToString();
            produtoBuscado.DataVencimento = DateTime.Parse(reader["DATAVENCIMENTO"].ToString());
            produtoBuscado.Preco = Decimal.Parse(reader["PRECO"].ToString());
            produtoBuscado.Unidade = reader["UNIDADE"].ToString();
            produtoBuscado.QuantidadeEmEstoque = int.Parse(reader["QUANTIDADEESTOQUE"].ToString());
            return produtoBuscado;
        }
    }
}