using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MercadoZe.Classlib;
using MercadoZe.Classlib.DAO;
using System.Data.SqlClient;

namespace MercadoZe.Classlib.DAO
{
    public class PedidoDAO
    {
        private const string _connectionString = @"Data Source=.\SQLEXPRESS;initial catalog=MERCADOZEDB;uid=sa;pwd=trop";

        public PedidoDAO()
        {
            
        }

        public void AdicionaPedido(Pedido novoPedido)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"INSERT PEDIDOS (DATAHORA, ID_PRODUTO, QTD_PRODUTO, VALOR_PEDIDO, ID_CLIENTE) VALUES (@DATA_HORA, @ID_PRODUTO, @QTD_PRODUTO, @VALOR_PEDIDO, @ID_CLIENTE)";

                    comando.Parameters.AddWithValue("@DATA_HORA", novoPedido.DataHora);
                    comando.Parameters.AddWithValue("@ID_PRODUTO", novoPedido.IdProduto);
                    comando.Parameters.AddWithValue("@QTD_PRODUTO", novoPedido.QuantidadeProduto);
                    comando.Parameters.AddWithValue("@VALOR_PEDIDO", novoPedido.ValorPedido);
                    comando.Parameters.AddWithValue("@ID_CLIENTE", novoPedido.Cliente == null ? DBNull.Value : novoPedido.Cliente.Cpf);
                    
                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }

            }
        }

        public void AdicionaPontos(Cliente clientePontuado, Decimal totalDePontos)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"UPDATE CLIENTES SET PONTOS_FIDELIDADE = @PONTOS_FIDELIDADE WHERE CPF = @ID_CLIENTE)";

                    comando.Parameters.AddWithValue("@PONTOS_FIDELIDADE", totalDePontos);
                    comando.Parameters.AddWithValue("@ID_CLIENTE", clientePontuado.Cpf);
                    
                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Pedido> BuscarTodosPedidos()
        {
            var listaPedidos = new List<Pedido>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT PD.ID, PD.DATAHORA, PD.ID_PRODUTO, PD.QTD_PRODUTO, PD.VALOR_PEDIDO, PD.ID_CLIENTE, C.NOME AS 'CLIENTE' , PR.NOME AS 'PRODUTO' FROM PEDIDOS PD
                                   INNER JOIN PRODUTOS PR ON PR.ID = PD.ID_PRODUTO
                                   LEFT JOIN CLIENTES C ON C.CPF = PD.ID_CLIENTE";

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while(leitor.Read())
                    {
                        Pedido pedidoBuscado = new Pedido();
                        pedidoBuscado.Id = int.Parse(leitor["ID"].ToString());
                        pedidoBuscado.DataHora = Convert.ToDateTime(leitor["DATAHORA"].ToString());
                        pedidoBuscado.QuantidadeProduto = int.Parse(leitor["QTD_PRODUTO"].ToString());
                        pedidoBuscado.ValorPedido = Convert.ToDecimal(leitor["VALOR_PEDIDO"].ToString());
                        pedidoBuscado.Cliente = new Cliente();
                        pedidoBuscado.Produto = new Produto();
                        pedidoBuscado.Cliente.Nome = leitor["CLIENTE"].ToString();
                        pedidoBuscado.Produto.Nome = leitor["PRODUTO"].ToString();
                        listaPedidos.Add(pedidoBuscado);
                    }
                }
            }

            return listaPedidos;

        }
    }
}