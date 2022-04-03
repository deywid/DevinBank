using DevinBank.Library.Enums;
using DevinBank.Library.Modelos;

namespace DevinBank.Library
{
    public class Corrente : Conta, IContaCorrente
    {
        public decimal LimiteChequeEspecial { get; private set; }
        public Corrente(string nome, string cpf, decimal rendaMensal, Agencia agencia)
            : base(nome, cpf, rendaMensal, agencia)
        {
            LimiteChequeEspecial = rendaMensal * 10 / 100;
        }

        public override void Saque(decimal montante, DateTime data)
        {
            if (montante > Saldo + LimiteChequeEspecial)
                throw new Exception("Saldo insuficiente.");
            try
            {
                SalvarTransacao(new TipoTransacao(TipoTransacaoEnum.Saque), montante, data);
                Saldo -= montante;
            }
            catch (Exception ex)
            {
                throw new Exception($"Operação cancelada. {ex.Message}");
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
                try
                {
                    SalvarTransacao(new TipoTransacao(TipoTransacaoEnum.Transferencia), montante, data);
                    SalvarTransferencia(contaBeneficiaria, montante, data);
                    Saldo -= montante;
                    contaBeneficiaria.Saldo += montante;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Operação cancelada. {ex.Message}");
                }
            }

        }
        public override void AlterarCadastro(decimal rendaMensal)
        {
            try
            {
                base.AlterarCadastro(rendaMensal);
                LimiteChequeEspecial = rendaMensal * 10 / 100;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public override string Extrato()
        {
            return $"\nCliente: {Nome}\nCPF: {CPF}\nNúmero da conta: {NumConta}\nAgência: {Agencia.Nome}\n\nSaldo em conta: R$ {Saldo:N2}\nLimite do cheque especial: R$ {LimiteChequeEspecial:N2}\n";
        }
    }
}
