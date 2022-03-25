using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevinBank.Library
{
    public class Banco : IBanco
    {
        public DateTime DataAtual { get; private set; } = DateTime.Now;

        public IList<Conta> Contas { get; private set; } = new List<Conta>();

        public void SalvarConta(Conta conta)
        {
            Contas.Add(conta);
        }

        public IConta AcessarConta(string cpf, int numConta)
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