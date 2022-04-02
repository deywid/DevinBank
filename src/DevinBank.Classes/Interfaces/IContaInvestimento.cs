using DevinBank.Library.Modelos;

namespace DevinBank.Library
{
    public interface IContaInvestimento : IConta
    {
        decimal ValorAplicado { get; }

        void AtualizaValorAplicado(DateTime data);
        void Investimento(decimal montante, int meses, DateTime data, TipoInvestimento tipoInvestimento);
        void SalvarTransacao(TipoTransacao tipo, decimal valor, DateTime data, int meses, TipoInvestimento tipoInvestimento);
    }

}