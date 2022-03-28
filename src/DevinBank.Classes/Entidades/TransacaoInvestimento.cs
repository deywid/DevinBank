
namespace DevinBank.Library
{
    public class TransacaoInvestimento : Transacao
    {
        public TipoInvestimento TipoInvestimento { get; private set; }
        public DateTime DataRetirada { get; private set; }
        public DateTime DataFinalInvestimento { get; set; }
        public TransacaoInvestimento(TipoTransacao tipo, decimal valor, DateTime data, int meses, TipoInvestimento tipoInvestimento)
            :base(tipo, valor, data)
        {
            TipoInvestimento = tipoInvestimento;
            DataRetirada = Data.AddMonths(TipoInvestimento.TempoResgate);
            DataFinalInvestimento = Data.AddMonths(meses);
        }

    }
}
