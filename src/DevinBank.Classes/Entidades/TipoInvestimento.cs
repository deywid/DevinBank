
using DevinBank.Library.Enums;

namespace DevinBank.Library.Entidades
{
    public class TipoInvestimento
    {
        public TipoInvestimentoEnum IdInvestimento { get; set; }
        public string Nome { get; set; }
        public TipoInvestimento(TipoInvestimentoEnum idInvestimento, string nome)
        {
            IdInvestimento = idInvestimento;
            Nome = nome;
        }
    }
}
