using System;

namespace MercadoZe.Classlib
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Preco { get; set; }
        public string Unidade { get; set; }
        public int QuantidadeEmEstoque { get; set; }

        public Produto()
        {
            
        }

        public override string ToString()
        {
            return $"PRODUTO N. {Id} - NOME: {Nome} - DESCRIÇÃO: {Descricao} - VENCIMENTO: {DataVencimento.ToShortDateString()} - PREÇO: {Preco} - ESTOQUE: {QuantidadeEmEstoque}";
        }
    }
}