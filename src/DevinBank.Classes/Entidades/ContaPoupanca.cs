using DevinBank.Library.Enums;

namespace DevinBank.Library
{
    public class ContaPoupanca : Conta
    {
        public ContaPoupanca(string nome, string cpf, decimal rendaMensal, AgenciaEnum agencia)
            : base(nome, cpf, rendaMensal, agencia)
        {
        }

        public decimal SimularRendimento(decimal saldo, int meses, int rentabilidade)
        {
            decimal txMensal = ((decimal)Math.Pow(1 + ((double)rentabilidade/100), 1.0 / 12) - 1) * 100m;
            
            return saldo * (txMensal * meses/100);

        }

    }
}
