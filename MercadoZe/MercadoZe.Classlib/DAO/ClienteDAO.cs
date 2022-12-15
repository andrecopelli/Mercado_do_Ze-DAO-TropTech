using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MercadoZe.Classlib.DAO
{
    public class ClienteDAO
    {
        private const string _connectionString = @"Data Source=.\SQLEXPRESS;initial catalog=MERCADOZEDB;uid=sa;pwd=trop";

        public ClienteDAO()
        {
            
        }

        //MÉTODOS
        

        //CRUD
        public void AdicionaCliente(Cliente novoCliente)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"INSERT CLIENTES VALUES (@CPF, @NOME, @DATA_NASCIMENTO, @PONTOS_FIDELIDADE, @RUA, @NUMERO, @BAIRRO, @CEP, @COMPLEMENTO);";
                    ConverteObjetoParaSql(novoCliente, command);                    
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AtualizaCliente(Cliente clienteEditado)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"UPDATE CLIENTES SET CPF = @CPF, NOME = @NOME, DATA_NASCIMENTO = @DATA_NASCIMENTO, PONTOS_FIDELIDADE = @PONTOS_FIDELIDADE,
                                 RUA = @RUA, NUMERO = @NUMERO, BAIRRO = @BAIRRO, CEP = @CEP, COMPLEMENTO = @COMPLEMENTO WHERE CPF = @CPF_CLIENTE;";
                    command.Parameters.AddWithValue("@CPF_CLIENTE", clienteEditado.Cpf);
                    ConverteObjetoParaSql(clienteEditado, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeletaCliente(Cliente clienteDeletado)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"DELETE FROM CLIENTES WHERE CPF = @CPF_CLIENTE;";
                    command.Parameters.AddWithValue("@CPF_CLIENTE", clienteDeletado.Cpf);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Cliente> BuscaTodosClientes()
        {
            var listaClientes = new List<Cliente>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM CLIENTES";
                    command.CommandText = sql;
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Cliente cliente = ConverteSqlParaObjeto(reader);
                        listaClientes.Add(cliente);                        
                    }
                }
            }
            return listaClientes;
        }

        public List<Cliente> BuscaClienteNome(string nomeDigitado)
        {
            var listaClientes = new List<Cliente>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM CLIENTES WHERE NOME LIKE '%'+@NOME_DIGITADO+'%';";
                    command.Parameters.AddWithValue("@NOME_DIGITADO", nomeDigitado);
                    command.CommandText = sql;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Cliente clienteBuscado = ConverteSqlParaObjeto(reader);
                        listaClientes.Add(clienteBuscado);
                    }
                }                
            }
            return listaClientes;
        }

        public Cliente BuscaClienteCpf(string cpfDigitado)
        {
            var clienteBuscado = new Cliente();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM CLIENTES WHERE CPF = @CPF_DIGITADO";
                    command.Parameters.AddWithValue("@CPF_DIGITADO", cpfDigitado);
                    command.CommandText = sql;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        clienteBuscado = ConverteSqlParaObjeto(reader);                    
                    }
                }                
            }
            return clienteBuscado;
        }

        public bool ClienteEmUso(string cpf)
        {
            bool clienteExiste = false;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM PEDIDOS WHERE ID_CLIENTE = @CPF_DIGITADO";
                    command.Parameters.AddWithValue("@CPF_DIGITADO", cpf);
                    command.CommandText = sql;
                    SqlDataReader reader = command.ExecuteReader();
                    
                    if (reader.Read())
                    {
                        clienteExiste = true;
                    }
                    else
                    {
                        clienteExiste = false;
                    }
                }
            }
            return clienteExiste;
        }

        public bool ClienteExiste(string cpf)
        {
            bool clienteExiste = false;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM CLIENTES WHERE CPF = @CPF_DIGITADO";
                    command.Parameters.AddWithValue("@CPF_DIGITADO", cpf);
                    command.CommandText = sql;
                    SqlDataReader reader = command.ExecuteReader();
                    
                    if (reader.Read())
                    {
                        clienteExiste = true;
                    }
                    else
                    {
                        clienteExiste = false;
                    }
                }
            }
            return clienteExiste;
        }



        //CONVERSORES DE DADOS E OBJETOS
        private void ConverteObjetoParaSql(Cliente cliente, SqlCommand command)
        {
            command.Parameters.AddWithValue("@CPF", cliente.Cpf);
            command.Parameters.AddWithValue("@NOME", cliente.Nome);
            command.Parameters.AddWithValue("@DATA_NASCIMENTO", cliente.DataNascimento);
            command.Parameters.AddWithValue("@PONTOS_FIDELIDADE", cliente.PontosDeFidelidade);
            command.Parameters.AddWithValue("@RUA", cliente.Endereco.Rua);
            command.Parameters.AddWithValue("@NUMERO", cliente.Endereco.Numero);
            command.Parameters.AddWithValue("@BAIRRO", cliente.Endereco.Bairro);
            command.Parameters.AddWithValue("@CEP", cliente.Endereco.Cep);
            command.Parameters.AddWithValue("@COMPLEMENTO", cliente.Endereco.Complemento);
        }
        
        private Cliente ConverteSqlParaObjeto(SqlDataReader reader)
        {
            Cliente clienteBuscado = new Cliente();
            clienteBuscado.Cpf = reader["CPF"].ToString();
            clienteBuscado.Nome = reader["NOME"].ToString();
            clienteBuscado.DataNascimento = Convert.ToDateTime(reader["DATA_NASCIMENTO"].ToString());
            clienteBuscado.PontosDeFidelidade = Convert.ToDecimal(reader["PONTOS_FIDELIDADE"].ToString());
            clienteBuscado.Endereco = new Endereco()
            {
                Rua = reader["RUA"].ToString(),
                Numero = Convert.ToInt32(reader["NUMERO"].ToString()),
                Bairro = reader["BAIRRO"].ToString(),
                Cep = reader["CEP"].ToString(),
                Complemento = reader["COMPLEMENTO"].ToString(),
            };
            return clienteBuscado;
        }

    }
}