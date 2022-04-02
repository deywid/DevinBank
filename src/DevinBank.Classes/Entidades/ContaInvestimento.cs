using DevinBank.Library.Enums;
using DevinBank.Library.Modelos;

namespace DevinBank.Library
{
    public class ContaInvestimento : Conta, IContaInvestimento
    {
        public decimal ValorAplicado { get; private set; }
        public ContaInvestimento(string nome, string cpf, decimal rendaMensal, Agencia agencia)
            : base(nome, cpf, rendaMensal, agencia)
        {
            ValorAplicado = 0.0m;
        }

        public void Investimento(decimal montante, int meses, DateTime data, TipoInvestimento tipoInvestimento)
        {
            if (meses < tipoInvestimento.TempoResgate)
                throw new Exception("A operação não atende ao requisito de tempo mínimo para este tipo de investimento.\n");

            if (montante > Saldo)
                throw new Exception("Saldo insuficiente.");
            try
            {
                SalvarTransacao(new TipoTransacao(TipoTransacaoEnum.Investimento), montante, data, meses, tipoInvestimento);
                AtualizaValorAplicado(data);
                Saldo -= montante;
            }
            catch (Exception ex)
            {
                throw new Exception($"Operação cancelada. {ex.Message}");
            }
        }
        public void SalvarTransacao(TipoTransacao tipo, decimal valor, DateTime data, int meses, TipoInvestimento tipoInvestimento)
        {
            try
            {
                Transacoes.Add(new TransacaoInvestimento(tipo, valor, data, meses, tipoInvestimento));
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível salvar a transação. {ex.Message}");
            }
        }
        public static decimal SimularRendimento(decimal saldo, int meses, TipoInvestimento tipoInvestimento)
        {
            if (meses < tipoInvestimento.TempoResgate)
                Console.WriteLine("Esta simulação não observa o tempo mínimo de resgate!");

            decimal txMensal = ((decimal)Math.Pow(1 + ((double)tipoInvestimento.Rentabilidade / 100), 1.0 / 12) - 1) * 100m;

            return saldo * (txMensal * meses / 100);
        }
        public void AtualizaValorAplicado(DateTime data)
        {
            decimal aux_soma = 0.0m;
            IEnumerable<Transacao> query = Transacoes.Where(tr => tr is TransacaoInvestimento);

            foreach (TransacaoInvestimento tr in query)
            {
                int dias = (data - tr.Data).Days;
                if (dias <= 0)
                {
                    tr.ValorLiquido = tr.Valor;
                    aux_soma += tr.Valor;
                }
                else
                {
                    decimal txDiaria = ((decimal)Math.Pow(1 + (double)(tr.TipoInvestimento.Rentabilidade / 100), (1.0 / 365)) - 1) * 100m;

                    tr.ValorLiquido = tr.Valor * (txDiaria * dias / 100) + tr.Valor;
                    aux_soma += tr.ValorLiquido;
                }
            }
            ValorAplicado = aux_soma;

        }
        public override string Extrato()
        {
            return $"\nCliente: {Nome}\nCPF: {CPF}\nNúmero da conta: {NumConta}\nAgência: {Agencia.Nome}\n\nSaldo em conta: R$ {Saldo:N2}\nTotal aplicado: R$ {ValorAplicado:N2}";
        }
    }
}
