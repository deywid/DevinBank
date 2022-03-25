using System.Threading;
using DevinBank.Library.Enums;

namespace DevinBank.Library
{
    public abstract class Conta : IConta
    {
        private static int _cont;
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public decimal RendaMensal { get; private set; }
        public int NumConta { get; private set; }
        public AgenciaEnum Agencia { get; private set; }
        public decimal Saldo { get; private set; }

        public Conta(string nome, string cpf, decimal rendaMensal, AgenciaEnum agencia)
        {
            Nome = nome;
            CPF = cpf;
            RendaMensal = rendaMensal;
            NumConta = Interlocked.Increment(ref _cont);
            Agencia = agencia;
            Saldo = 0.0m;
        }

        public void Saque(decimal montante)
        {
            Saldo -= montante;
        }
        public void Deposito(decimal montante)
        {
            Saldo += montante;
        }
        public string Extrato()
        {
            return $"\nCliente: {CPF}\nConta: {NumConta}\nAgencia: {Agencia}\n\nSaldo em conta: {Saldo}";
        }
        public void Transferencia(Conta contaBeneficiaria, decimal montante)
        {
            Saldo -= montante;

            contaBeneficiaria.Saldo += montante;
        }
        public void AlterarCadastro(string nome)
        {
            Nome = nome;
        }

        public void AlterarCadastro(decimal rendaMensal)
        {
            RendaMensal = rendaMensal;
        }

        public void AlterarCadastro(AgenciaEnum agencia)
        {
            Agencia = agencia;
        }
        public abstract void ExtratoTransacoes();

    }



}
