using DevinBank.Library.Enums;

namespace DevinBank.Library
{
    public class ContaCorrente : Conta, IContaCorrente
    {
        public decimal ChequeEspecial { get; private set; }
        public ContaCorrente(string nome, string cpf, decimal rendaMensal, AgenciaEnum agencia)
            : base(nome, cpf, rendaMensal, agencia)
        {
            ChequeEspecial = rendaMensal * 10 / 100;
        }

    }
}
