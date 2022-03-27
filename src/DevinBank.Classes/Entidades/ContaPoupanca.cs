using DevinBank.Library.Enums;

namespace DevinBank.Library
{
    public class ContaPoupanca : Conta
    {
        public ContaPoupanca(string nome, string cpf, decimal rendaMensal, AgenciaEnum agencia)
            : base(nome, cpf, rendaMensal, agencia)
        {
        }

        public void SimularRendimento(decimal saldo, DateTime data, int meses, int rentabilidade)
        {
            //int dias = (data.AddMonths(meses) - data).Days;
            decimal rendimentos;

            if (meses < 12)
            {
                decimal txMensal = ((decimal)Math.Pow(1 + ((double)rentabilidade/100), 1.0 / 12) - 1) * 100m;
                rendimentos = saldo * (txMensal * meses/100);

            }
            else
            {
                decimal txAno = ((decimal)Math.Pow(1 + (double)(rentabilidade / 100m), ((double)meses)/12) - 1) * 100m;
                rendimentos = saldo * txAno/100;
            }

            //decimal txDiaria = ((decimal)Math.Pow(1 + (double)(rentabilidade / 100m), (1 / (double)ano)) - 1) * 100m;
            
            saldo += rendimentos;

            Console.WriteLine($"Rendimentos: {rendimentos:N2}");
            Console.WriteLine($"Saldo ao final do período: {saldo:N2}");
        }

    }
}
