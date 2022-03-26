using DevinBank.Library.Enums;

namespace DevinBank.Library
{
    public class ContaPoupanca : Conta
    {
        public ContaPoupanca(string nome, string cpf, decimal rendaMensal, AgenciaEnum agencia) 
            : base(nome, cpf, rendaMensal, agencia)
        {
        }

        public void SimulaRendimento(DateTime meses, decimal rentabilidade = 7) { }
        
    }
}
