
namespace DevinBank.Library
{
    public interface IBanco
    {
        IList<Conta> Contas { get; }

        public DateTime DataAtual();
        void SalvarConta(Conta conta);
        Conta AcessarConta(string cpf, int numConta);
        Conta AcessarConta(int numConta);
    }
}