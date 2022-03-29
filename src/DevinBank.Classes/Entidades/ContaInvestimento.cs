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
            if(meses >= tipoInvestimento.TempoResgate)
            {
                Saldo -= montante;
                ValorAplicado += montante;
                TipoTransacao tipo = new(TipoTransacaoEnum.Investimento);
                SalvarTransacao(tipo, montante, data, meses, tipoInvestimento);

            }
            else
            {
                throw new Exception("O período informado não atende aos critérios de investimento");
            }

        }

        public void SalvarTransacao(TipoTransacao tipo, decimal valor, DateTime data, int meses, TipoInvestimento tipoInvestimento)
        {
                Transacoes.Add(new TransacaoInvestimento(tipo, valor, data, meses, tipoInvestimento));
        }

        public decimal SimularRendimento(decimal saldo, int meses, TipoInvestimento tipoInvestimento)
        {
            decimal rendimentos;

            decimal txMensal = ((decimal)Math.Pow(1 + ((double)tipoInvestimento.Rentabilidade / 100), 1.0 / 12) - 1) * 100m;
            rendimentos = saldo * (txMensal * meses / 100);

            return rendimentos;
        }

        public override string ExtratoTransacoes()
        {
            string extrato = "Extrato das transações:\n";
            foreach (var transacoes in Transacoes)
            {
                if(transacoes is TransacaoInvestimento tri)
                {
                    extrato += $"\nTransação: {tri.TipoTransacao.Nome}\nTipo Investimento: {tri.TipoInvestimento.Nome}" +
                        $"\nValor investido: {tri.Valor:N2}\nValor liquido: {tri.ValorLiquido:N2}\nData do investimento: {tri.Data}\nResgate a partir de: {tri.DataRetirada}\nData fim: {tri.DataFinalInvestimento}\n";
                }
                else
                {
                    extrato += $"\nTransação: {transacoes.TipoTransacao.Nome}\nValor: {transacoes.Valor}\nData: {transacoes.Data}\n";
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
                if (dias == 0)
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
