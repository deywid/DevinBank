
namespace DevinBank.Library
{
    public interface IBanco
    {
        IList<Conta> Contas { get; }
        DateTime Data { get; }

        DateTime AtualizaData(DateTime data);
        void AtualizaContas();
        void SalvarConta(Conta conta);
        Conta AcessarConta(string cpf, int numConta);
        Conta AcessarConta(int numConta);
        decimal TotalEmInvestimentos();
    }
}