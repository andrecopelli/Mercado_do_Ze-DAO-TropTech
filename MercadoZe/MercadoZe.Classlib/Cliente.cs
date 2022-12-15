using System;

namespace MercadoZe.Classlib
{
    public class Cliente
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public DateTime DataNascimento { get; set; }
        public Decimal PontosDeFidelidade { get; set; }
        
        public Cliente()
        {
            Endereco = new Endereco();
        }

        public override string ToString()
        {
            return $"CPF {Cpf} - NOME: {Nome} - ENDEREÇO: {Endereco.Rua}, {Endereco.Numero} - {Endereco.Bairro} - PONTOS DE FIDELIDADE: {PontosDeFidelidade}";
        }
    }
}