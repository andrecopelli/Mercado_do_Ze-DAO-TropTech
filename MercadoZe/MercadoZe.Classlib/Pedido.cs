using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoZe.Classlib
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public int IdProduto { get; set; }
        public int QuantidadeProduto { get; set; }
        public decimal ValorPedido { get; set; }
        public string IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public Produto Produto { get; set; }

        public Pedido()
        {
            DataHora = DateTime.Now;
        }

        public void CalculaPontosFidelidade()
        {
            if (Cliente != null)
            {
               Cliente.PontosDeFidelidade += ValorPedido * 2; 
            }
        }

        public void CalculaValorPedido()
        {
            ValorPedido = Produto.Preco * QuantidadeProduto;
        }

        public override string ToString()
        {
            return $"PEDIDO N. {Id} - DATA DO PEDIDO: {DataHora.ToShortDateString()} - PRODUTO: {Produto.Nome} {Produto.Descricao} - CLIENTE: {Cliente.Nome} - VALOR TOTAL: {ValorPedido}";
        }
    }
}