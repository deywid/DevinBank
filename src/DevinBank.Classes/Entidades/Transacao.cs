
namespace DevinBank.Library
{
    public class Transacao
    {
        public TipoTransacao TipoTransacao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public Transacao(TipoTransacao tipo, decimal valor, DateTime date)
        {
            TipoTransacao = tipo;
            Valor = valor;
            Data = date;
        }
    }
}
