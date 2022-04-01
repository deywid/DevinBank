using DevinBank.Library.Enums;
using DevinBank.Library.Modelos;

namespace DevinBank.Library
{
    public class ContaCorrente : Conta, IContaCorrente
    {
        public decimal LimiteChequeEspecial { get; }
        public ContaCorrente(string nome, string cpf, decimal rendaMensal, Agencia agencia)
            : base(nome, cpf, rendaMensal, agencia)
        {
            LimiteChequeEspecial = rendaMensal * 10 / 100;
        }

        public override void Saque(decimal montante, DateTime data)
        {
            if (montante <= Saldo + LimiteChequeEspecial)
            {
                Saldo -= montante;
                SalvarTransacao(new TipoTransacao(TipoTransacaoEnum.Saque), montante, data);
            }
            else
            {
                throw new Exception("Saldo insuficiente.");
            }
        }
        public override void Transferencia(Conta contaBeneficiaria, decimal montante, DateTime data)
        {
            if (data.DayOfWeek == DayOfWeek.Sunday || data.DayOfWeek == DayOfWeek.Saturday)
            {
                throw new Exception("Não é possível efetuar transferências aos finais de semana.");
            }
            else if (contaBeneficiaria.NumConta == NumConta)
            {
                throw new Exception("Não é possível efetuar transferências para a mesma conta.");
            }
            else if (montante > Saldo + LimiteChequeEspecial)
            {
                throw new Exception("Saldo insuficiente.");
            }
            else
            {
                Saldo -= montante;
                contaBeneficiaria.Saldo += montante;

                SalvarTransacao(new TipoTransacao(TipoTransacaoEnum.Transferencia), montante, data);
                SalvarTransferencia(contaBeneficiaria, montante, data);
            }

        }
        public override string Extrato()
        {
            return $"\nCliente: {Nome}\nCPF: {CPF}\nConta: {NumConta}\nAgência: {Agencia.Nome}\n\nSaldo em conta: R$ {Saldo:N2}\nLimite do cheque especial: R$ {LimiteChequeEspecial:N2}";
        }

    }
}
