
namespace DevinBank.Library
{
    public class Transferencia
    {
        public IConta ContaOrigem { get; set; }
        public IConta ContaDestino { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public Transferencia(IConta contaOrigem, IConta contaDestino, decimal valor, DateTime data)
        {
            ContaOrigem = contaOrigem;
            ContaDestino = contaDestino;
            Valor = valor;
            Data = data;
        }
    }
}
