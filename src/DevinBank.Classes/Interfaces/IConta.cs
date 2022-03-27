using DevinBank.Library.Enums;

namespace DevinBank.Library
{
    public interface IConta
    {
        AgenciaEnum Agencia { get; }
        string CPF { get; }
        string Nome { get; }
        int NumConta { get; }
        decimal RendaMensal { get; }
        decimal Saldo { get; }
        public IList<Transacao> Transacoes { get; }
        public IList<Transferencia> Transferencias { get; }

        void Deposito(decimal montante, DateTime data);
        void Saque(decimal montante, DateTime data);
        void Transferencia(Conta contaBeneficiaria, decimal montante, DateTime data);
        string Extrato();
        void AlterarCadastro(string nome);
        void AlterarCadastro(decimal rendaMensal);
        void AlterarCadastro(AgenciaEnum agencia);
        string ExtratoTransacoes();
        void SalvarTransferencia(IConta contaDestino, decimal valor, DateTime data);
        string HistoricoTransferencias();

      //  abstract void SimularRendimento(decimal saldo, DateTime data, int meses, int rentabilidade = 7);
    }
}