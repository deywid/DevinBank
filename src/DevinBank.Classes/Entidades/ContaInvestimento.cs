using DevinBank.Library.Enums;

namespace DevinBank.Library
{
    public class ContaInvestimento : Conta
    {
        public ContaInvestimento(string nome, string cpf, decimal rendaMensal, AgenciaEnum agencia) 
            : base(nome, cpf, rendaMensal, agencia)
        {
        }

        public void SimularRendimento(decimal saldo, DateTime data, int meses, int rentabilidade)
        {
            throw new NotImplementedException();
        }

        //public override string ExtratoTransacoes()
        //{
        //    return "";
        //}
    }
}
