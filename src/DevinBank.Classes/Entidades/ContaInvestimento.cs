using DevinBank.Library.Enums;

namespace DevinBank.Library
{
    public class ContaInvestimento : Conta
    {
        public ContaInvestimento(string nome, string cpf, decimal rendaMensal, AgenciaEnum agencia) 
            : base(nome, cpf, rendaMensal, agencia)
        {
        }

        public override void ExtratoTransacoes() { }
    }
}
