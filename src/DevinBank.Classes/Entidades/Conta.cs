using DevinBank.Library.Enums;
using DevinBank.Library.Modelos;

namespace DevinBank.Library
{
    public abstract class Conta : IConta
    {
        private static int _cont = 1000;
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public decimal RendaMensal { get; private set; }
        public int NumConta { get; private set; }
        public Agencia Agencia { get; private set; }
        public decimal Saldo { get; set; }
        public IList<Transacao> Transacoes { get; private set; }
        public IList<Transferencia> Transferencias { get; private set; }

        public Conta(string nome, string cpf, decimal rendaMensal, Agencia agencia)
        {
            Nome = nome;
            CPF = cpf;
            RendaMensal = rendaMensal;
            NumConta = Interlocked.Increment(ref _cont);
            Agencia = agencia;
            Saldo = 0.0m;
            Transacoes = new List<Transacao>();
            Transferencias = new List<Transferencia>();
        }

        public virtual void Saque(decimal montante, DateTime data)
        {
            if(montante > Saldo)
                throw new Exception("Saldo insuficiente.");
            try
            {
                SalvarTransacao(new TipoTransacao(TipoTransacaoEnum.Saque), montante, data);
                Saldo -= montante;
            }
            catch(Exception ex)
            {
                throw new Exception($"Operação cancelada. {ex.Message}");
            }
        }
        public void Deposito(decimal montante, DateTime data)
        {
            try
            {
                SalvarTransacao(new TipoTransacao(TipoTransacaoEnum.Deposito), montante, data);
                Saldo += montante;
            }
            catch (Exception ex)
            {
                throw new Exception($"Operação cancelada. {ex.Message}");
            }

        }
        public virtual void Transferencia(Conta contaBeneficiaria, decimal montante, DateTime data)
        {
            if(data.DayOfWeek == DayOfWeek.Sunday || data.DayOfWeek == DayOfWeek.Saturday)
            {
                throw new Exception("Não é possível efetuar transferências aos finais de semana.");
            }
            else if(contaBeneficiaria.NumConta == NumConta)
            {
                throw new Exception("Não é possível efetuar transferências para a mesma conta.");
            }
            else if (montante > Saldo)
            {
                throw new Exception("Saldo insuficiente.");
            }
            else
            {
                try
                {
                    SalvarTransacao(new TipoTransacao(TipoTransacaoEnum.Transferencia), montante, data);
                    SalvarTransferencia(contaBeneficiaria, montante, data);
                    Saldo -= montante;
                    contaBeneficiaria.Saldo += montante;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Operação cancelada. {ex.Message}");
                }
            }

        }
        public virtual string Extrato()
        {
            return $"\nCliente: {Nome}\nCPF: {CPF}\nConta: {NumConta}\nAgencia: {Agencia.Nome}\n\nSaldo em conta: R$ {Saldo:N2}";
        }
        public void AlterarCadastro(string nome)
        {
            try
            {
                Nome = nome;
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível salvar a alteração. {ex.Message}");
            }
        }
        public void AlterarCadastro(decimal rendaMensal)
        {
            try
            {
                RendaMensal = rendaMensal;
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível salvar a alteração. {ex.Message}");
            }   
        }
        public void AlterarCadastro(Agencia agencia)
        {
            try
            {
                Agencia = agencia;
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível salvar a alteração. {ex.Message}");
            }
        }
        public void SalvarTransferencia(IConta contaDestino, decimal valor, DateTime data)
        {
            try
            {
                Transferencias.Add(new Transferencia(this, contaDestino, valor, data));
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível salvar a transferência. {ex.Message}");
            }
        }
        public void SalvarTransacao(TipoTransacao tipo, decimal valor, DateTime data)
        {
            try
            {
                Transacoes.Add(new Transacao(tipo, valor, data));
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível salvar a transação. {ex.Message}");
            }
        }
        public string HistoricoTransferencias()
        {
            string historico = "";
            if (Transferencias.Count < 1)
            {
                throw new Exception("Nenhuma transferência registrada.");
            }
            else
            {
                foreach (var transferencia in Transferencias)
                {
                    historico += $"\nConta origem: {transferencia.ContaOrigem.NumConta}\nBeneficiario: {transferencia.ContaDestino.NumConta}\nValor: R$ {transferencia.Valor:N2}\nData: {transferencia.Data:d}\n";
                }
            }
            return historico;
        }
        public string ExtratoTransacoes()
        {
            if (Transacoes.Count < 1)
                throw new Exception("Nenhuma transação registrada.");

            string extrato = "";
            foreach (var transacoes in Transacoes)
            {
                if (transacoes is TransacaoInvestimento tri)
                {
                    extrato += $"\nTransação: {tri.TipoTransacao.Nome}\nTipo Investimento: {tri.TipoInvestimento.Nome}" +
                               $"\nValor investido: R$ {tri.Valor:N2}\nValor liquido: R$ {tri.ValorLiquido:N2}\nData do investimento: {tri.Data:d}\nResgate a partir de: {tri.DataRetirada:d}\nData fim: {tri.DataFinalInvestimento:d}\n";
                }
                else
                {
                    extrato += $"\nTransação: {transacoes.TipoTransacao.Nome}\nValor: R${transacoes.Valor:N2}\nData: {transacoes.Data:d}\n";
                }
            }
            return extrato;

        }
       
    }
}
