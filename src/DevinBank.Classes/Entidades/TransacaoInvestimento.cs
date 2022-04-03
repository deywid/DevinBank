
using DevinBank.Library.Modelos;

namespace DevinBank.Library
{
    public class TransacaoInvestimento : Transacao
    {
        public TipoInvestimento TipoInvestimento { get; }
        public decimal ValorLiquido { get; protected internal set; }
        public DateTime DataRetirada { get; }
        public DateTime DataFinalInvestimento { get; }
        public TransacaoInvestimento(TipoTransacao tipo, decimal valor, DateTime data, int meses, TipoInvestimento tipoInvestimento)
            :base(tipo, valor, data)
        {
            TipoInvestimento = tipoInvestimento;
            DataRetirada = Data.AddMonths(TipoInvestimento.TempoResgate);
            DataFinalInvestimento = Data.AddMonths(meses);
        }

    }
}
