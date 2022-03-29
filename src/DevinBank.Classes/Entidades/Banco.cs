
namespace DevinBank.Library
{
    public class Banco : IBanco
    {
        public IList<Conta> Contas { get; private set; } = new List<Conta>();
        public DateTime Data { get; set; } = DateTime.Now;

        public DateTime AtualizaData(DateTime data) => Data = data;
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
        public decimal TotalEmInvestimentos()
        {
            IEnumerable<Conta> query = Contas.Where(conta => conta is ContaInvestimento);
            decimal aux_soma = 0.0m;
            foreach(ContaInvestimento conta in query)
            {
                aux_soma += conta.ValorAplicado;
            }
            return aux_soma;
        }

        public void AtualizaContas()
        {
            IEnumerable<Conta> query = Contas.Where(conta => conta is ContaInvestimento);
            
            foreach (ContaInvestimento conta in query)
            {
                conta.AtualizaValorAplicado(Data);
            }
            
        }

    }
}