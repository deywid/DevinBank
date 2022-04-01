
namespace DevinBank.Library
{
    public interface IBanco
    {
        IList<Conta> Contas { get; }
        DateTime Data { get; }

        public void AtualizaData(DateTime data);
        void AtualizaContas();
        void SalvarConta(Conta conta);
        Conta AcessarConta(string cpf, int numConta);
        Conta AcessarConta(int numConta);
        string ListarContas();
        string ListarContasSaldoNegativo();
        decimal TotalEmInvestimentos();
    }
}