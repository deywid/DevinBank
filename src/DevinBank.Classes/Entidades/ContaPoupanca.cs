using DevinBank.Library.Enums;

namespace DevinBank.Library
{
    public class ContaPoupanca : Conta
    {
        public ContaPoupanca(string nome, string cpf, decimal rendaMensal, AgenciaEnum agencia)
            : base(nome, cpf, rendaMensal, agencia)
        {
        }

        public void SimularRendimento(decimal saldo, int meses, int rentabilidade)
        {
            decimal rendimentos;
            
            decimal txMensal = ((decimal)Math.Pow(1 + ((double)rentabilidade/100), 1.0 / 12) - 1) * 100m;
            rendimentos = saldo * (txMensal * meses/100);

            //int dias = (data.AddMonths(meses) - data).Days;
            //decimal txDiaria = ((decimal)Math.Pow(1 + (double)(rentabilidade / 100m), (1 / (double)ano)) - 1) * 100m;
            
            saldo += rendimentos;

            Console.WriteLine($"Rendimentos: {rendimentos:N2}");
            Console.WriteLine($"Saldo ao final do período: {saldo:N2}");
        }

    }
}
