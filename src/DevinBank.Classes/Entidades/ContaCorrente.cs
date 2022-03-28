using DevinBank.Library.Enums;

namespace DevinBank.Library
{
    public class ContaCorrente : Conta, IContaCorrente
    {
        public decimal LimiteChequeEspecial { get; }
        public ContaCorrente(string nome, string cpf, decimal rendaMensal, AgenciaEnum agencia)
            : base(nome, cpf, rendaMensal, agencia)
        {
            LimiteChequeEspecial = rendaMensal * 10 / 100;
        }

        public override void Saque(decimal montante, DateTime data)
        {
            if(montante > Saldo + LimiteChequeEspecial)
            {
                throw new Exception("Saldo insuficiente");
            }
            else if(montante <= 0)
            {
                throw new Exception("O valor informado é inválido");
            }
            else
            {
                Saldo -= montante;
                
                TipoTransacao tipo = new(TipoTransacaoEnum.Saque);
                SalvarTransacao(tipo, montante, data);
            }

        }
        public override void Transferencia(Conta contaBeneficiaria, decimal montante, DateTime data)
        {
            if (montante > Saldo + LimiteChequeEspecial)
            {
                throw new Exception("Saldo insuficiente");
            }
            else if (montante <= 0)
            {
                throw new Exception("O valor informado é inválido");
            }
            else
            {
            Saldo -= montante;
            contaBeneficiaria.Saldo += montante;
            }

            TipoTransacao tipo = new(TipoTransacaoEnum.Transferencia);
            SalvarTransacao(tipo, montante, data);
            SalvarTransferencia(contaBeneficiaria, montante, data);
        }
        public override string Extrato()
        {
            return $"\nCliente: {Nome}\nCPF: {CPF}\nConta: {NumConta}\nAgencia: {Agencia}\n\nSaldo em conta: {Saldo}\n\nLimite do cheque especial: {LimiteChequeEspecial}";
        }

    }
}
