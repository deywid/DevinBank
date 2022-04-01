﻿
namespace DevinBank.Library
{
    public class Banco : IBanco
    {
        public IList<Conta> Contas { get; private set; } = new List<Conta>();
        public DateTime Data { get; private set; } = DateTime.Now;

        public void AtualizaData(DateTime data)
        {
            if(data < DateTime.Now)
            {
                throw new Exception($"A data não pode ser anterior a {DateTime.Now:d}");
            }
            else
            {
                Data = data;
            }
        }
        public void SalvarConta(Conta conta)
        {
            try
            {
                Contas.Add(conta);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível salvar conta no sistema. {ex.Message}");
            }
        }
        public Conta AcessarConta(string cpf, int numConta)
        {
            return Contas.FirstOrDefault(conta => conta.CPF == cpf && conta.NumConta == numConta)
                    ?? throw new Exception($"Cliente {cpf} ou conta {numConta} não existem.");
        }
        public Conta AcessarConta(int numConta)
        {
            return Contas.FirstOrDefault(conta => conta.NumConta == numConta)
                    ?? throw new Exception($"Conta {numConta} não existe.");
        }
        public void AtualizaContas()
        {
            IEnumerable<Conta> query = Contas.Where(conta => conta is ContaInvestimento);
            
            foreach (ContaInvestimento conta in query)
            {
                conta.AtualizaValorAplicado(Data);
            }
            
        }
        public string ListarContas()
        {
            if (Contas.Count < 1)
                throw new Exception("Nenhuma conta cadastrada.");

            string lista = "";
            foreach (var conta in Contas)
            {
                
                lista += $"¨¨¨ ¨¨¨¨ ¨¨ ¨¨ ¨¨¨¨ ¨¨¨ ¨¨¨ ¨¨¨¨ ¨¨ ¨¨ ¨¨¨¨ ¨¨¨\n{conta.Extrato()}\n";
            }
            return lista;
        }
        public string ListarContasSaldoNegativo()
        {
            if (Contas.Count < 1)
                throw new Exception("Nenhuma conta cadastrada.");

            IEnumerable<Conta> query = Contas.Where(conta => conta.Saldo < 0);
            if (!query.Any())
                throw new Exception("Nenhuma conta com saldo negativo foi encontrada.");

            string lista = "";
            foreach (var conta in query)
            {
                lista += $"\n¨¨¨ ¨¨¨¨ ¨¨ ¨¨ ¨¨¨¨ ¨¨¨\n{conta.Extrato()}\n";
            }
            return lista;

        }
        public decimal TotalEmInvestimentos()
        {
            IEnumerable<Conta> query;
            if (Contas.OfType<ContaInvestimento>().Any())
            { 
                query = Contas.Where(conta => conta is ContaInvestimento);
            }
            else
            {
                throw new Exception("Nenhuma conta de investimentos cadastrada.");
            }

            decimal aux_soma = 0.0m;
            foreach(ContaInvestimento conta in query)
            {
                aux_soma += conta.ValorAplicado;
            }

            if(aux_soma <=0)
                throw new Exception("Nenhum investimento foi registrado até o momento");

            return aux_soma;
        }

    }
}