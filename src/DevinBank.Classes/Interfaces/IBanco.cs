
namespace DevinBank.Library
{
    public interface IBanco
    {
        IList<Conta> Contas { get; }
        DateTime DataAtual { get; }

        void SalvarConta(Conta conta);
        IConta AcessarConta(string cpf, int numConta);
        Conta AcessarConta(int numConta);
    }
}