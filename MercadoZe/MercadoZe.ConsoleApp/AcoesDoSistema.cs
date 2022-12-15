using System;
using System.Collections.Generic;
using System.Threading;
using MercadoZe.Classlib;
using MercadoZe.Classlib.DAO;

namespace MercadoZe.ConsoleApp
{
    public class AcoesDoSistema
    {
        //INSTÂNCIAS PARA A MANIPULAÇÃO DOS DADOS E OBJETOS
        static List<Produto> _listaProdutos = new List<Produto>();
        static Produto _produtoBuscado = new Produto();
        static ProdutoDAO _produtoDAO = new ProdutoDAO();
        static List<Cliente> _listaClientes = new List<Cliente>();
        static Cliente _clienteBuscado = new Cliente();
        static ClienteDAO _clienteDAO = new ClienteDAO();
        static Cliente _clienteInexistente = new Cliente();
        static List<Pedido> _listaPedidos = new List<Pedido>();
        static Pedido _pedidoBuscado = new Pedido();
        static PedidoDAO _pedidoDAO = new PedidoDAO();


        //MENUS
        public static void MenuPrincipal()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("====================== MERCADO DO ZÉ 3.1 =======================");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("======= [1] - MENU DE PRODUTOS =================================");
            Console.ForegroundColor = ConsoleColor.Magenta;
            System.Console.WriteLine("======= [2] - MENU DE CLIENTES =================================");
            Console.ForegroundColor = ConsoleColor.Black;
            System.Console.WriteLine("======= [3] - MENU DE PEDIDOS ==================================");
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("======= [0] - SAIR =============================================");
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("======================== TROPTECH MARKET =======================");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            System.Console.Write("=>");

            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    Console.Clear();
                    MenuProdutos();
                    break;

                case "2":
                    Console.Clear();
                    MenuClientes();
                    break;

                case "3":
                    Console.Clear();
                    MenuPedidos();
                    break;

                case "0":
                    Console.Clear();
                    TelaDeSaida();
                    Environment.Exit(1);
                    break;

                default:
                    Console.Clear();
                    System.Console.WriteLine("OPÇÃO INVÁLIDA, APERTE QUALQUER TECLA PARA VOLTAR.");
                    Console.ReadKey();
                    Console.Clear();
                    MenuPrincipal();
                    break;
            }
        }

        public static void MenuProdutos()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("======================= MENU DE PRODUTOS =======================");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            System.Console.WriteLine("======= [1] - ADICIONAR PRODUTOS ===============================");
            System.Console.WriteLine("======= [2] - EDITAR PRODUTO ===================================");
            System.Console.WriteLine("======= [3] - DELETAR PRODUTO ==================================");
            System.Console.WriteLine("======= [4] - LISTAR PRODUTOS ==================================");
            System.Console.WriteLine("======= [5] - BUSCAR PRODUTO POR NOME ==========================");
            System.Console.WriteLine("======= [6] - BUSCAR PRODUTO POR ID ============================");
            System.Console.WriteLine("======= [7] - ENTRADA DE PRODUTOS NO ESTOQUE ===================");
            System.Console.WriteLine("======= [8] - SAÍDAS DE PRODUTOS NO ESTOQUE ====================");
            System.Console.WriteLine("======= [9] - MENU PRINCIPAL ===================================");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            System.Console.WriteLine("======= [0] - SAIR =============================================");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("======================== TROPTECH MARKET =======================");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            System.Console.Write("=>");

            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    Console.Clear();
                    AdicionaProduto();
                    break;

                case "2":
                    Console.Clear();
                    AtualizaProduto();
                    break;

                case "3":
                    Console.Clear();
                    DeletaProdutos();
                    break;

                case "4":
                    Console.Clear();
                    ListaProdutos();
                    break;

                case "5":
                    Console.Clear();
                    BuscaDescricao();
                    break;

                case "6":
                    Console.Clear();
                    BuscaIdentificador();
                    break;

                case "7":
                    Console.Clear();
                    EntradaEstoque();
                    break;

                case "8":
                    Console.Clear();
                    SaidaEstoque();
                    break;

                case "9":
                    Console.Clear();
                    MenuPrincipal();
                    break;

                case "0":
                    Console.Clear();
                    TelaDeSaida();
                    Environment.Exit(1);
                    break;

                default:
                    Console.Clear();
                    System.Console.WriteLine("OPÇÃO INVÁLIDA, APERTE QUALQUER TECLA PARA VOLTAR.");
                    Console.ReadKey();
                    Console.Clear();
                    MenuProdutos();
                    break;
            }
        }

        public static void MenuClientes()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("======================= MENU DE CLIENTES =======================");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.WriteLine("======= [1] - ADICIONAR CLIENTE ================================");
            System.Console.WriteLine("======= [2] - ATUALIZAR CLIENTE ================================");
            System.Console.WriteLine("======= [3] - DELETAR CLIENTE ==================================");
            System.Console.WriteLine("======= [4] - LISTAR CLIENTES ==================================");
            System.Console.WriteLine("======= [5] - BUSCAR CLIENTE POR NOME ==========================");
            System.Console.WriteLine("======= [6] - BUSCAR CLIENTE POR CPF ===========================");
            System.Console.WriteLine("======= [7] - MENU PRINCIPAL ===================================");
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("======= [0] - SAIR =============================================");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("======================== TROPTECH MARKET =======================");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            System.Console.Write("=>");

            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    Console.Clear();
                    AdicionaCliente();
                    break;

                case "2":
                    Console.Clear();
                    AtualizaCliente();
                    break;

                case "3":
                    Console.Clear();
                    DeletaCliente();
                    break;

                case "4":
                    Console.Clear();
                    ListaClientes();
                    break;

                case "5":
                    Console.Clear();
                    BuscaClienteNome();
                    break;

                case "6":
                    Console.Clear();
                    BuscaClienteCpf();
                    break;

                case "7":
                    Console.Clear();
                    MenuPrincipal();
                    break;

                case "0":
                    Console.Clear();
                    TelaDeSaida();
                    Environment.Exit(1);
                    break;

                default:
                    Console.Clear();
                    System.Console.WriteLine("OPÇÃO INVÁLIDA, APERTE QUALQUER TECLA PARA VOLTAR.");
                    Console.ReadKey();
                    MenuClientes();
                    break;
            }


        }

        public static void MenuPedidos()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("======================= MENU DE PEDIDOS ========================");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.WriteLine("======= [1] - REGISTRAR PEDIDO =================================");
            System.Console.WriteLine("======= [2] - LISTAR PEDIDOS ===================================");
            System.Console.WriteLine("======= [3] - MENU PRINCIPAL ===================================");
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("======= [0] - SAIR =============================================");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("======================= TROPTECH MARKET ========================");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            System.Console.Write("=>");

            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    Console.Clear();
                    AdicionaPedido();
                    break;

                case "2":
                    Console.Clear();
                    ListaPedidos();
                    break;

                case "3":
                    Console.Clear();
                    MenuPrincipal();
                    break;

                case "0":
                    Console.Clear();
                    TelaDeSaida();
                    Environment.Exit(1);
                    break;

                default:
                    Console.Clear();
                    System.Console.WriteLine("OPÇÃO INVÁLIDA, APERTE QUALQUER TECLA PARA VOLTAR.");
                    Console.ReadKey();
                    MenuPedidos();
                    break;
            }
        }

        public static void TelaDeSaida()
        {
            Console.Clear();
            System.Console.WriteLine("                                                                                ");
            System.Console.WriteLine("                             ################                                   ");
            Thread.Sleep(500);
            System.Console.WriteLine("                          ######################                                ");
            Thread.Sleep(500);
            System.Console.WriteLine("                       #####                  #####                             ");
            Thread.Sleep(500);
            System.Console.WriteLine("                      ##                          ##                            ");
            Thread.Sleep(500);
            System.Console.WriteLine("                     ##                            ##                           ");
            Thread.Sleep(500);
            System.Console.WriteLine("                     ##    #######      #######    ##                           ");
            Thread.Sleep(500);
            System.Console.WriteLine("                    ##   #########      #########   ##                          ");
            Thread.Sleep(500);
            System.Console.WriteLine("                    ##   #########      #########   ##                          ");
            Thread.Sleep(500);
            System.Console.WriteLine("                    ##    ######          ######    ##                          ");
            Thread.Sleep(500);
            System.Console.WriteLine("                    ##                              ##                          ");
            Thread.Sleep(500);
            System.Console.WriteLine("                     ##             ##             ##                           ");
            Thread.Sleep(500);
            System.Console.WriteLine("                     ##            ####            ##                           ");
            Thread.Sleep(500);
            System.Console.WriteLine("                      ###          ####          ###                            ");
            Thread.Sleep(500);
            System.Console.WriteLine("                        ##                      ##                              ");
            Thread.Sleep(500);
            System.Console.WriteLine("                         ##                    ##                               ");
            Thread.Sleep(500);
            System.Console.WriteLine("                         ##    ##        ##    ##                               ");
            Thread.Sleep(500);
            System.Console.WriteLine("                         ##    ##        ##    ##                               ");
            Thread.Sleep(500);
            System.Console.WriteLine("                          ######################                                ");
            Thread.Sleep(500);
            System.Console.WriteLine("                          ######################                                ");
            System.Console.WriteLine("                                                                                ");
            System.Console.WriteLine("                                                                                ");
            System.Console.WriteLine("                                                                                ");
            System.Console.WriteLine("                                                                                ");
            Thread.Sleep(500);
            System.Console.WriteLine("                     OBRIGADO POR USAR NOSSO SOFTWARE!!!                        ");
            System.Console.WriteLine("                                                                                ");
            Thread.Sleep(500);
            System.Console.WriteLine("                     DESENVOLVIDO POR ANDRÉ LUIZ COPELLI                        ");
            Thread.Sleep(500);
            System.Console.WriteLine("                                  TROPTECH                                      ");
            System.Console.WriteLine("                                                                                ");
            System.Console.WriteLine("                                                                                ");
            Thread.Sleep(500);
            System.Console.WriteLine("                      APERTE QUALQUER TECLA PARA SAIR!                          ");
            Console.ReadKey();
        }

        //CRUD PRODUTOS
        private static void DeletaProdutos()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("============ DIGITE O ID DO PRODUTO A SER DELETADO =============");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            System.Console.Write("=>");
            _produtoBuscado.Id = Convert.ToInt32(Console.ReadLine());

            if (_produtoDAO.ProdutoExiste(_produtoBuscado.Id))
            {
                if (_produtoDAO.ProdutoEmUso(_produtoBuscado.Id))
                {
                    System.Console.WriteLine($"O PRODUTO {_produtoBuscado.Nome} {_produtoBuscado.Descricao} JÁ FOI UTILIZADO EM UM PEDIDO E NÃO PODE SER DELETADO.");
                    System.Console.WriteLine("APERTE QUALQUER TECLA PARA VOLTAR.");
                    Console.ReadKey();
                    Console.Clear();
                    MenuProdutos();
                }
                else
                {
                    _produtoDAO.DeletaProduto(_produtoBuscado);
                    Console.Clear();
                    System.Console.WriteLine($"O PRODUTO {_produtoBuscado.Nome} {_produtoBuscado.Descricao} FOI EXCLUÍDO COM SUCESSO, APERTE QUALQUER TECLA PARA VOLTAR.");
                    Console.ReadKey();
                    Console.Clear();
                    MenuProdutos();
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                System.Console.WriteLine("================================================================");
                System.Console.WriteLine($"================== O PRODUTO NÃO EXISTE =======================");
                System.Console.WriteLine("================================================================");
                Console.BackgroundColor = ConsoleColor.Yellow;
            }

            Console.ReadKey();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Yellow;
            MenuProdutos();
        }

        public static void AdicionaProduto()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Produto novoProduto = new Produto();
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("=================== CADASTRO DE PRODUTOS =======================");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("======= DIGITE O  NOME DO PRODUTO ==============================");
            novoProduto.Nome = Console.ReadLine();
            System.Console.WriteLine("======= DIGITE A DESCRIÇÃO DO PRODUTO ==========================");
            novoProduto.Descricao = Console.ReadLine();
            System.Console.WriteLine("======= DIGITE A DATA DE VENCIMENTO (EX: 01-01-2023) ===========");
            novoProduto.DataVencimento = Convert.ToDateTime(Console.ReadLine());
            System.Console.WriteLine("======= DIGITE O PREÇO DO PRODUTO (EX: 3,99) ===================");
            novoProduto.Preco = Convert.ToDecimal(Console.ReadLine());
            System.Console.WriteLine("======= DIGITE A UNIDADE DO PRODUTO ============================");
            novoProduto.Unidade = Console.ReadLine();
            System.Console.WriteLine("======= QUANTIDADE DO PRODUTO EM ESTOQUE =======================");
            novoProduto.QuantidadeEmEstoque = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("================================================================");

            _produtoDAO.AdicionaProduto(novoProduto);
            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("=========== DESEJA CADASTAR OUTRO PRODUTO? [S/N] ===============");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            System.Console.Write("=>");
            string opcao = Console.ReadLine().ToUpper();
            switch (opcao)
            {
                case "S":
                    Console.Clear();
                    AdicionaProduto();
                    break;

                case "N":
                    Console.Clear();
                    MenuProdutos();
                    break;

                default:
                    Console.Clear();
                    System.Console.WriteLine("OPÇÃO INVÁLIDA, APERTE QUALQUER TECLA PARA VOLTAR.");
                    Console.ReadKey();
                    MenuProdutos();
                    break;
            }

        }

        public static void ListaProdutos()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("=============== TODOS OS PRODUTOS CADASTRADOS ==================");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;

            _listaProdutos = _produtoDAO.BuscaTodosProdutos();

            foreach (var item in _listaProdutos)
            {
                System.Console.WriteLine(item);
            }

            Console.ReadKey();
            Console.Clear();
            MenuProdutos();
        }

        public static void AtualizaProduto()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("============ DIGITE O ID DO PRODUTO A SER EDITADO ==============");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            System.Console.Write("=>");
            _produtoBuscado.Id = int.Parse(Console.ReadLine());
            if (_produtoDAO.ProdutoExiste(_produtoBuscado.Id))
            {
                System.Console.WriteLine("======= DIGITE O  NOME DO PRODUTO ===================");
                _produtoBuscado.Nome = Console.ReadLine();
                System.Console.WriteLine("======= DIGITE A DESCRIÇÃO DO PRODUTO =================");
                _produtoBuscado.Descricao = Console.ReadLine();
                System.Console.WriteLine("======= DIGITE A DATA DE VENCIMENTO (EX: 01-01-2023) ========");
                _produtoBuscado.DataVencimento = Convert.ToDateTime(Console.ReadLine());
                System.Console.WriteLine("======= DIGITE O PREÇO DO PRODUTO (EX: 3,99) ============");
                _produtoBuscado.Preco = Convert.ToDecimal(Console.ReadLine());
                System.Console.WriteLine("======= DIGITE A UNIDADE DO PRODUTO ==================");
                _produtoBuscado.Unidade = Console.ReadLine();
                System.Console.WriteLine("======= QUANTIDADE DO PRODUTO EM ESTOQUE ===============");
                _produtoBuscado.QuantidadeEmEstoque = Convert.ToInt32(Console.ReadLine());
                _produtoDAO.AtualizaProduto(_produtoBuscado);
                Console.BackgroundColor = ConsoleColor.Gray;
                System.Console.WriteLine("================================================================");
                System.Console.WriteLine($"======================= {_produtoBuscado.Nome} ALTERADO =======================");
                System.Console.WriteLine("================================================================");
                Console.BackgroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                System.Console.WriteLine("================================================================");
                System.Console.WriteLine($"================== O PRODUTO NÃO EXISTE =======================");
                System.Console.WriteLine("================================================================");
                Console.BackgroundColor = ConsoleColor.Yellow;
            }
            Console.ReadKey();
            Console.Clear();
            MenuProdutos();
        }

        public static void BuscaIdentificador()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("==================== DIGITE O ID DO PRODUTO ====================");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            System.Console.Write("=>");
            int typedID = int.Parse(Console.ReadLine());

            if (_produtoDAO.ProdutoExiste(typedID))
            {
                _produtoBuscado = _produtoDAO.BuscaProdutoId(typedID);
                Console.BackgroundColor = ConsoleColor.Gray;
                System.Console.WriteLine("================================================================");
                System.Console.WriteLine("====================== PRODUTO PESQUISADO ======================");
                System.Console.WriteLine("================================================================");
                Console.BackgroundColor = ConsoleColor.Yellow;
                System.Console.Write("=>");
                System.Console.WriteLine(_produtoBuscado);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                System.Console.WriteLine("================================================================");
                System.Console.WriteLine($"================== O PRODUTO NÃO EXISTE =======================");
                System.Console.WriteLine("================================================================");
                Console.BackgroundColor = ConsoleColor.Yellow;
            }

            Console.ReadKey();
            Console.Clear();
            MenuProdutos();
        }

        public static void BuscaDescricao()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("============== DIGITE A DESCRIÇÃO DO PRODUTO ===================");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            System.Console.Write("=>");
            string typedDescricao = Console.ReadLine();

            _listaProdutos = _produtoDAO.BuscaProdutoDescricao(typedDescricao);

            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("====================== PRODUTO PESQUISADO ======================");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;

            foreach (var item in _listaProdutos)
            {
                System.Console.WriteLine(item);
            }

            Console.ReadKey();
            Console.Clear();
            MenuProdutos();
        }

        public static void SaidaEstoque()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("======== DIGITE O ID DO PRODUTO PARA SAÍDA DO ESTOQUE ==========");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            System.Console.Write("=>");
            int typedID = int.Parse(Console.ReadLine());

            if (_produtoDAO.ProdutoExiste(typedID))
            {
                _produtoBuscado = _produtoDAO.BuscaProdutoId(typedID);
                Console.BackgroundColor = ConsoleColor.Gray;
                System.Console.WriteLine($"DIGITE A QUANTIDADE QUE DEVE SER DEBITADO DE {_produtoBuscado.Nome} - {_produtoBuscado.Descricao}.");
                System.Console.WriteLine("==================================================================================");
                System.Console.Write("=>");
                int quantidade = Convert.ToInt32(Console.ReadLine());

                _produtoDAO.SaidaEstoque(_produtoBuscado, quantidade);

                Console.BackgroundColor = ConsoleColor.Gray;
                System.Console.WriteLine("================================================================");
                System.Console.WriteLine($"====      ESTOQUE DE {_produtoBuscado.Nome} - {_produtoBuscado.Descricao} ALTERADO      ====");
                System.Console.WriteLine("================================================================");
                Console.BackgroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                System.Console.WriteLine("================================================================");
                System.Console.WriteLine($"================== O PRODUTO NÃO EXISTE =======================");
                System.Console.WriteLine("================================================================");
                Console.BackgroundColor = ConsoleColor.Yellow;
            }

            Console.ReadKey();
            Console.Clear();
            MenuProdutos();
        }

        public static void EntradaEstoque()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("======= DIGITE O ID DO PRODUTO PARA ADICIONAR AO ESTOQUE =======");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.Write("=>");
            int typedID = int.Parse(Console.ReadLine());

            if (_produtoDAO.ProdutoExiste(typedID))
            {
                _produtoBuscado = _produtoDAO.BuscaProdutoId(typedID);
                Console.BackgroundColor = ConsoleColor.Gray;
                System.Console.WriteLine($"DIGITE A QUANTIDADE QUE DEVE SER ADICIONADA DE {_produtoBuscado.Nome} - {_produtoBuscado.Descricao}.");
                System.Console.WriteLine("==================================================================================");
                System.Console.Write("=>");
                int quantidade = Convert.ToInt32(Console.ReadLine());

                _produtoDAO.EntradaEstoque(_produtoBuscado, quantidade);

                Console.BackgroundColor = ConsoleColor.Gray;
                System.Console.WriteLine("================================================================");
                System.Console.WriteLine($"====      ESTOQUE DE {_produtoBuscado.Nome} - {_produtoBuscado.Descricao} ALTERADO      ====");
                System.Console.WriteLine("================================================================");
                Console.BackgroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                System.Console.WriteLine("================================================================");
                System.Console.WriteLine($"================== O PRODUTO NÃO EXISTE =======================");
                System.Console.WriteLine("================================================================");
                Console.BackgroundColor = ConsoleColor.Yellow;
            }
            Console.ReadKey();
            Console.Clear();
            MenuProdutos();
        }
        
        
        //CRUD CLIENTES
        public static void AdicionaCliente()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Cliente novoCliente = new Cliente();
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("=================== CADASTRO DE CLIENTES =======================");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("======= DIGITE O CPF DO CLIENTE ================================");
            novoCliente.Cpf = Console.ReadLine();
            System.Console.WriteLine("======= DIGITE O NOME DO CLIENTE ===============================");
            novoCliente.Nome = Console.ReadLine();
            System.Console.WriteLine("======= DIGITE A DATA DE NASCIMENTO DO CLIENTE =================");
            novoCliente.DataNascimento = Convert.ToDateTime(Console.ReadLine());
            System.Console.WriteLine("======= DIGITE A RUA DO CLIENTE ================================");
            novoCliente.Endereco.Rua = Console.ReadLine();
            System.Console.WriteLine("======= DIGITE O NUMERO DO IMÓVEL ==============================");
            novoCliente.Endereco.Numero = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("======= DIGITE O BAIRRO DO CLIENTE =============================");
            novoCliente.Endereco.Bairro = Console.ReadLine();
            System.Console.WriteLine("======= DIGITE O CEP DO CLIENTE ================================");
            novoCliente.Endereco.Cep = Console.ReadLine();
            System.Console.WriteLine("==================== DIGITE O COMPLEMENTO ======================");
            novoCliente.Endereco.Complemento = Console.ReadLine();
            System.Console.WriteLine("================================================================");

            _clienteDAO.AdicionaCliente(novoCliente);

            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("============ DESEJA CADASTAR OUTRO CLIENTE? [S/N] ==============");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            System.Console.Write("=>");
            string opcao = Console.ReadLine().ToUpper();
            switch (opcao)
            {
                case "S":
                    Console.Clear();
                    AdicionaCliente();
                    break;

                case "N":
                    Console.Clear();
                    MenuClientes();
                    break;

                default:
                    Console.Clear();
                    System.Console.WriteLine("OPÇÃO INVÁLIDA, APERTE QUALQUER TECLA PARA VOLTAR.");
                    Console.ReadKey();
                    MenuClientes();
                    break;
            }

        }

        public static void ListaClientes()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("=============== TODOS OS CLIENTES CADASTRADOS ==================");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;

            _listaClientes = _clienteDAO.BuscaTodosClientes();

            foreach (var item in _listaClientes)
            {
                System.Console.WriteLine(item);
            }

            Console.ReadKey();
            Console.Clear();
            MenuClientes();
        }

        public static void AtualizaCliente()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("=========== DIGITE O CPF DO CLIENTE A SER ATUALIZADO ===========");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            _clienteBuscado.Cpf = Console.ReadLine();
            if (_clienteDAO.ClienteExiste(_clienteBuscado.Cpf))
            {
                System.Console.WriteLine("======= DIGITE O NOME DO CLIENTE ===============================");
                _clienteBuscado.Nome = Console.ReadLine();
                System.Console.WriteLine("======= DIGITE A DATA DE NASCIMENTO DO CLIENTE =================");
                _clienteBuscado.DataNascimento = Convert.ToDateTime(Console.ReadLine());
                System.Console.WriteLine("======= DIGITE A RUA DO CLIENTE ================================");
                _clienteBuscado.Endereco.Rua = Console.ReadLine();
                System.Console.WriteLine("======= DIGITE O NUMERO DO IMÓVEL ==============================");
                _clienteBuscado.Endereco.Numero = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("======= DIGITE O BAIRRO DO CLIENTE =============================");
                _clienteBuscado.Endereco.Bairro = Console.ReadLine();
                System.Console.WriteLine("======= DIGITE O CEP DO CLIENTE ================================");
                _clienteBuscado.Endereco.Cep = Console.ReadLine();
                System.Console.WriteLine("======= DIGITE O COMPLEMENTO ===================================");
                _clienteBuscado.Endereco.Complemento = Console.ReadLine();
                System.Console.WriteLine("================================================================");
                _clienteDAO.AtualizaCliente(_clienteBuscado);
                Console.BackgroundColor = ConsoleColor.Gray;
                System.Console.WriteLine("================================================================");
                System.Console.WriteLine($"======================= {_produtoBuscado.Nome} ALTERADO =======================");
                System.Console.WriteLine("================================================================");
                Console.BackgroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                System.Console.WriteLine("================================================================");
                System.Console.WriteLine($"================== O CLIENTE NÃO EXISTE =======================");
                System.Console.WriteLine("================================================================");
                Console.BackgroundColor = ConsoleColor.Yellow;
            }

            Console.ReadKey();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Yellow;
            MenuClientes();
        }

        public static void DeletaCliente()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("============ DIGITE O CPF DO CLIENTE A SER DELETADO ============");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            System.Console.Write("=>");
            _clienteBuscado.Cpf = Console.ReadLine();

            if (_clienteDAO.ClienteExiste(_clienteBuscado.Cpf))
            {
                if (_clienteDAO.ClienteEmUso(_clienteBuscado.Cpf))
                {
                    System.Console.WriteLine($"O CLIENTE {_clienteBuscado.Nome} JÁ EFETUOU UM PEDIDO E NÃO PODE SER DELETADO.");
                    System.Console.WriteLine("APERTE QUALQUER TECLA PARA VOLTAR.");
                    Console.ReadKey();
                    Console.Clear();
                    MenuClientes();
                }
                else
                {
                    _clienteDAO.DeletaCliente(_clienteBuscado);
                    Console.Clear();
                    System.Console.WriteLine($"O CLIENTE {_clienteBuscado.Nome} FOI EXCLUÍDO COM SUCESSO, APERTE QUALQUER TECLA PARA VOLTAR.");
                    Console.ReadKey();
                    Console.Clear();
                    MenuClientes();
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                System.Console.WriteLine("================================================================");
                System.Console.WriteLine($"================== O CLIENTE NÃO EXISTE =======================");
                System.Console.WriteLine("================================================================");
                Console.BackgroundColor = ConsoleColor.Yellow;
            }

            Console.ReadKey();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Yellow;
            MenuClientes();
        }

        public static void BuscaClienteNome()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("================== DIGITE O NOME DO CLIENTE ====================");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            System.Console.Write("=>");
            string nomeDigitado = Console.ReadLine();

            _listaClientes = _clienteDAO.BuscaClienteNome(nomeDigitado);

            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("=================== CLIENTE(S) PESQUISADO(S) ===================");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            foreach (var item in _listaClientes)
            {
                System.Console.WriteLine(item);
            }

            Console.ReadKey();
            Console.Clear();
            MenuClientes();
        }

        public static void BuscaClienteCpf()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("================== DIGITE O CPF DO CLIENTE =====================");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            System.Console.Write("=>");
            string cpfDigitado = Console.ReadLine();

            if (_clienteDAO.ClienteExiste(cpfDigitado))
            {
                _clienteBuscado = _clienteDAO.BuscaClienteCpf(cpfDigitado);

                Console.BackgroundColor = ConsoleColor.Gray;
                System.Console.WriteLine("================================================================");
                System.Console.WriteLine("====================== CLIENTE PESQUISADO ======================");
                System.Console.WriteLine("================================================================");
                System.Console.Write("=>");
                Console.BackgroundColor = ConsoleColor.Gray;
                System.Console.WriteLine(_clienteBuscado);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                System.Console.WriteLine("================================================================");
                System.Console.WriteLine($"================== O CLIENTE NÃO EXISTE =======================");
                System.Console.WriteLine("================================================================");
                Console.BackgroundColor = ConsoleColor.Yellow;
            }
            Console.ReadKey();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Yellow;
            MenuClientes();
        }

        //CRUD PEDIDOS
        public static void AdicionaPedido()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Pedido novoPedido = new Pedido();
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("==================== CADASTRO DE PEDIDOS =======================");
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("======= [1] - PEDIDO COM CPF ===================================");
            System.Console.WriteLine("======= [2] - PEDIDO SEM CPF ===================================");
            System.Console.WriteLine("================================================================");
            System.Console.Write("=>");
            Console.BackgroundColor = ConsoleColor.Gray;
            int opcaoPedido = int.Parse(System.Console.ReadLine());

            if (opcaoPedido == 1)
            {
                System.Console.WriteLine("======= CPF DO CLIENTE =========================================");
                novoPedido.IdCliente = Console.ReadLine();
                System.Console.WriteLine("======= DIGITE O ID DO PRODUTO =================================");
                novoPedido.IdProduto = Convert.ToInt32(Console.ReadLine());

                if (_produtoDAO.ProdutoExiste(novoPedido.IdProduto) && _clienteDAO.ClienteExiste(novoPedido.IdCliente))
                {
                    System.Console.WriteLine("======= DIGITE A QUANTIDADE DO PRODUTO =========================");
                    novoPedido.QuantidadeProduto = Convert.ToInt32(Console.ReadLine());
                    System.Console.WriteLine("================================================================");
                    
                    var clientePedido = _clienteDAO.BuscaClienteCpf(novoPedido.IdCliente);
                    novoPedido.Cliente = clientePedido;
                    var produtoPedido = _produtoDAO.BuscaProdutoId(novoPedido.IdProduto);
                    novoPedido.Produto = produtoPedido;
                    novoPedido.CalculaValorPedido();
                    novoPedido.CalculaPontosFidelidade();
                    _pedidoDAO.AdicionaPedido(novoPedido);
                    _produtoDAO.SaidaEstoque(produtoPedido, novoPedido.QuantidadeProduto);

                    if (!String.IsNullOrEmpty(novoPedido.IdCliente))
                    {
                        _clienteDAO.AtualizaCliente(novoPedido.Cliente);
                    }
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    System.Console.WriteLine("================================================================");
                    System.Console.WriteLine($"============= O PRODUTO/CLIENTE NÃO EXISTE ====================");
                    System.Console.WriteLine("================================================================");
                    Console.BackgroundColor = ConsoleColor.Yellow;
                }

            }
            else
            {
                if (opcaoPedido == 2)
                {
                    System.Console.WriteLine("======= DIGITE O ID DO PRODUTO =================================");
                    novoPedido.IdProduto = Convert.ToInt32(Console.ReadLine());
                    novoPedido.IdCliente = null;
                    if (_produtoDAO.ProdutoExiste(novoPedido.IdProduto))
                    {
                        System.Console.WriteLine("======= DIGITE A QUANTIDADE DO PRODUTO =========================");
                        novoPedido.QuantidadeProduto = Convert.ToInt32(Console.ReadLine());
                        System.Console.WriteLine("================================================================");
                        var produtoPedido = _produtoDAO.BuscaProdutoId(novoPedido.IdProduto);
                        novoPedido.Produto = produtoPedido;
                        novoPedido.CalculaValorPedido();
                        novoPedido.CalculaPontosFidelidade();
                        _pedidoDAO.AdicionaPedido(novoPedido);
                        _produtoDAO.SaidaEstoque(produtoPedido, novoPedido.QuantidadeProduto);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        System.Console.WriteLine("================================================================");
                        System.Console.WriteLine($"================== O PRODUTO NÃO EXISTE =======================");
                        System.Console.WriteLine("================================================================");
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }
                }
                else
                {
                    Console.Clear();
                    System.Console.WriteLine("OPÇÃO INVÁLIDA, APERTE QUALQUER TECLA PARA VOLTAR.");
                    Console.ReadKey();
                    Console.Clear();
                    MenuPedidos();
                }
            }

            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("============= DESEJA CADASTAR OUTRO PEDIDO? [S/N] ==============");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;
            System.Console.Write("=>");
            string opcao = Console.ReadLine().ToUpper();
            switch (opcao)
            {
                case "S":
                    Console.Clear();
                    AdicionaPedido();
                    break;

                case "N":
                    Console.Clear();
                    MenuPedidos();
                    break;

                default:
                    Console.Clear();
                    System.Console.WriteLine("OPÇÃO INVÁLIDA, APERTE QUALQUER TECLA PARA VOLTAR.");
                    Console.ReadKey();
                    Console.Clear();
                    MenuPedidos();
                    break;
            }
        }

        public static void ListaPedidos()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            System.Console.WriteLine("================================================================");
            System.Console.WriteLine("=============== TODOS OS PEDIDOS CADASTRADOS ==================");
            System.Console.WriteLine("================================================================");
            Console.BackgroundColor = ConsoleColor.Yellow;

            _listaPedidos = _pedidoDAO.BuscarTodosPedidos();

            foreach (var item in _listaPedidos)
            {
                System.Console.WriteLine(item);
            }

            Console.ReadKey();
            Console.Clear();
            MenuPedidos();
        }
    }
}