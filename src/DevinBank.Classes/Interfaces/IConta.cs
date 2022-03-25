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

        void Deposito(decimal montante);
        void Saque(decimal montante);
        void Transferencia(Conta contaBeneficiaria, decimal montante);
        string Extrato();
        void AlterarCadastro(string nome);
        void AlterarCadastro(decimal rendaMensal);
        void AlterarCadastro(AgenciaEnum agencia);
        void ExtratoTransacoes() { }
    }
}