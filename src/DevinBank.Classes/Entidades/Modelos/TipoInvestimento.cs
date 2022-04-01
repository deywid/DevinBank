
using DevinBank.Library.Enums;

namespace DevinBank.Library.Modelos
{
    public class TipoInvestimento
    {
        public TipoInvestimentoEnum IdInvestimento { get; }
        public string Nome { get; }
        public decimal Rentabilidade { get; }
        public int TempoResgate { get; }
        public TipoInvestimento(TipoInvestimentoEnum idInvestimento)
        {
            IdInvestimento = idInvestimento;
            Nome = PegaNome(idInvestimento);
            Rentabilidade = PegaRentabilidade(idInvestimento);
            TempoResgate = PegaTempoResgate(idInvestimento);
        }

        public static string PegaNome(TipoInvestimentoEnum idInvestimento)
        {
            if (idInvestimento == TipoInvestimentoEnum.LCI)
            {
                return $"LCI: {PegaRentabilidade(TipoInvestimentoEnum.LCI)}% a.a.";
            }
            else if (idInvestimento == TipoInvestimentoEnum.LCA)
            {
                return $"LCA: {PegaRentabilidade(TipoInvestimentoEnum.LCA)}% a.a.";
            }
            else
            {
                return $"CDB: {PegaRentabilidade(TipoInvestimentoEnum.CDB)}% a.a.";
            }
        }
        public static decimal PegaRentabilidade(TipoInvestimentoEnum idInvestimento)
        {
            if (idInvestimento == TipoInvestimentoEnum.LCI)
            {
                return 8.0m;
            }
            else if (idInvestimento == TipoInvestimentoEnum.LCA)
            {
                return 9.0m;
            }
            else
            {
                return 10.0m;
            }
        }
        public static int PegaTempoResgate(TipoInvestimentoEnum idInvestimento)
        {
            if (idInvestimento == TipoInvestimentoEnum.LCI)
            {
                return 6;
            }
            else if (idInvestimento == TipoInvestimentoEnum.LCA)
            {
                return 12;
            }
            else
            {
                return 36;
            }
        }

    }
}
