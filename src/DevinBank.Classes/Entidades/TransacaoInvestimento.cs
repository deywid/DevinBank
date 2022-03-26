
namespace DevinBank.Library.Entidades
{
    public class TransacaoInvestimento : Transacao
    {
        public TipoInvestimento TipoInvestimento { get; set; }
        public TransacaoInvestimento(TipoTransacao tipo, decimal valor, DateTime data, TipoInvestimento tipoInvestimento)
            :base(tipo, valor, data)
        {
            TipoInvestimento = tipoInvestimento;
        }
    }
}
