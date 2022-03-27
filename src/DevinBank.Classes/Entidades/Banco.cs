
namespace DevinBank.Library
{
    public class Banco : IBanco
    {
        public IList<Conta> Contas { get; private set; } = new List<Conta>();

        public DateTime DataAtual() => DateTime.Now;
        public void SalvarConta(Conta conta)
        {
            Contas.Add(conta);
        }
        public Conta AcessarConta(string cpf, int numConta)
        {
            return Contas.FirstOrDefault(conta => conta.CPF == cpf && conta.NumConta == numConta)
                    ?? throw new Exception($"Cliente {cpf} ou conta {numConta} não encontrados");
        }
        public Conta AcessarConta(int numConta)
        {
            return Contas.FirstOrDefault(conta => conta.NumConta == numConta)
                    ?? throw new Exception($"Conta {numConta} não encontrada");
        }
    }
}