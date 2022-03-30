using DevinBank.Library.Enums;

namespace DevinBank.Library
{
    public class ContaInvestimento : Conta
    {
        public decimal ValorAplicado { get; private set; }
        public ContaInvestimento(string nome, string cpf, decimal rendaMensal, AgenciaEnum agencia) 
            : base(nome, cpf, rendaMensal, agencia)
        {
            ValorAplicado = 0.0m;
        }

        public void Investimento(decimal montante, int meses, DateTime data, TipoInvestimento tipoInvestimento)
        {
            if(montante <= Saldo)
            {
                Saldo -= montante;
                
                TipoTransacao tipo = new(TipoTransacaoEnum.Investimento);
                SalvarTransacao(tipo, montante, data, meses, tipoInvestimento);
                AtualizaValorAplicado(data);
            }
            else
            {
                throw new Exception("Saldo insuficiente.");
            }

        }
        public void SalvarTransacao(TipoTransacao tipo, decimal valor, DateTime data, int meses, TipoInvestimento tipoInvestimento)
        {
                Transacoes.Add(new TransacaoInvestimento(tipo, valor, data, meses, tipoInvestimento));
        }
        public static decimal SimularRendimento(decimal saldo, int meses, TipoInvestimento tipoInvestimento)
        {
            decimal txMensal = ((decimal)Math.Pow(1 + ((double)tipoInvestimento.Rentabilidade / 100), 1.0 / 12) - 1) * 100m;
            
            return saldo * (txMensal * meses / 100);
        }
        public override string ExtratoTransacoes()
        {
            string extrato = "Extrato das transações:\n";
            foreach (var transacoes in Transacoes)
            {
                if(transacoes is TransacaoInvestimento tri)
                {
                    extrato += $"\nTransação: {tri.TipoTransacao.Nome}\nTipo Investimento: {tri.TipoInvestimento.Nome}" +
                        $"\nValor investido: {tri.Valor:N2}\nValor liquido: {tri.ValorLiquido:N2}\nData do investimento: {tri.Data.ToString("d")}\nResgate a partir de: {tri.DataRetirada.ToString("d")}\nData fim: {tri.DataFinalInvestimento.ToString("d")}\n";
                }
                else
                {
                    extrato += $"\nTransação: {transacoes.TipoTransacao.Nome}\nValor: {transacoes.Valor:N2}\nData: {transacoes.Data.ToString("d")}\n";
                }
            }
            return extrato;
        }
        public void AtualizaValorAplicado(DateTime data)
        {
            decimal aux_soma = 0.0m;
            IEnumerable<Transacao> query = Transacoes.Where(tr => tr is TransacaoInvestimento);

            foreach(TransacaoInvestimento tr in query)
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

    }
}
