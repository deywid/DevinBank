
using DevinBank.Library.Enums;

namespace DevinBank.Library
{
    public class TipoInvestimento
    {
        public TipoInvestimentoEnum IdInvestimento { get; private set; }
        public string Nome { get; private set; }
        public decimal Rentabilidade { get; private set; }
        public int TempoResgate { get; private set; }
        public TipoInvestimento(TipoInvestimentoEnum idInvestimento)
        {
            IdInvestimento = idInvestimento;
            Nome = PegaNomeInvestimento(idInvestimento);
            Rentabilidade = PegaRentabilidade(idInvestimento);
            TempoResgate = PegaTempoResgate(idInvestimento);
        }

        private static string PegaNomeInvestimento(TipoInvestimentoEnum idInvestimento)
        {
            if (idInvestimento == TipoInvestimentoEnum.LCI)
            {
                return "LCI (8% a.a.)";
            }
            else if (idInvestimento == TipoInvestimentoEnum.LCA)
            {
                return "LCA (9% a.a.)";
            }
            else
            {
                return "CDB (10% a.a.)";
            }
        }
        private static decimal PegaRentabilidade(TipoInvestimentoEnum idInvestimento)
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
        private static int PegaTempoResgate(TipoInvestimentoEnum idInvestimento)
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
