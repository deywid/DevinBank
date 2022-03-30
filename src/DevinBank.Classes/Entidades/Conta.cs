using DevinBank.Library.Enums;

namespace DevinBank.Library
{
    public abstract class Conta : IConta
    {
        private static int _cont = 1000;
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public decimal RendaMensal { get; private set; }
        public int NumConta { get; private set; }
        public AgenciaEnum Agencia { get; private set; }
        public decimal Saldo { get; set; }
        public IList<Transacao> Transacoes { get; private set; }
        public IList<Transferencia> Transferencias { get; private set; }

        public Conta(string nome, string cpf, decimal rendaMensal, AgenciaEnum agencia)
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
            if(montante <= Saldo)
            {
                Saldo -= montante;

                TipoTransacao tipo = new(TipoTransacaoEnum.Saque);
                SalvarTransacao(tipo, montante, data);
            }
            else
            {
                throw new Exception("Saldo insuficiente.");
            }
        }
        public void Deposito(decimal montante, DateTime data)
        {
            Saldo += montante;

            TipoTransacao tipo = new(TipoTransacaoEnum.Deposito);
            SalvarTransacao(tipo, montante, data);
        }
        public virtual void Transferencia(Conta contaBeneficiaria, decimal montante, DateTime data)
        {
            if(montante > Saldo)
            {
                throw new Exception("Saldo insuficiente.");
            }
            else if(contaBeneficiaria.NumConta == NumConta)
            {
                throw new Exception("Não é possível efetuar transferências para a mesma conta.");
            }
            else if(data.DayOfWeek == DayOfWeek.Sunday || data.DayOfWeek == DayOfWeek.Saturday)
            {
                throw new Exception("Não é possível efetuar transferências aos finais de semana.");
            }
            else
            {
                Saldo -= montante;
                contaBeneficiaria.Saldo += montante;

                TipoTransacao tipo = new(TipoTransacaoEnum.Transferencia);
                SalvarTransacao(tipo, montante, data);
                SalvarTransferencia(contaBeneficiaria, montante, data);
            }

        }
        public virtual string Extrato()
        {
            return $"\nCliente: {Nome}\nCPF: {CPF}\nConta: {NumConta}\nAgencia: {Agencia}\n\nSaldo em conta: R${Saldo:N2}";
        }
        public void AlterarCadastro(string nome)
        {
            Nome = nome;
        }
        public void AlterarCadastro(decimal rendaMensal)
        {
            RendaMensal = rendaMensal;
        }
        public void AlterarCadastro(AgenciaEnum agencia)
        {
            Agencia = agencia;
        }
        public void SalvarTransferencia(IConta contaDestino, decimal valor, DateTime data)
        {
            Transferencias.Add(new Transferencia(this, contaDestino, valor, data));
        }
        public void SalvarTransacao(TipoTransacao tipo, decimal valor, DateTime data)
        {
            Transacoes.Add(new Transacao(tipo, valor, data));
        }
        public string HistoricoTransferencias()
        {
            string historico = "Histórico de Transferencias:\n";
            foreach (var transferencia in Transferencias)
            {
                historico += $"\nConta origem: {transferencia.ContaOrigem.NumConta}\nBeneficiario: {transferencia.ContaDestino.NumConta}\nValor: {transferencia.Valor:N2}\nData: {transferencia.Data.ToString("d")}\n";
            }
            return historico;
        }
        public virtual string ExtratoTransacoes()
        {
            string extrato = "Extrato das transações:\n";
            foreach (var transacoes in Transacoes)
            {
                extrato += $"\nTransação: {transacoes.TipoTransacao.Nome}\nValor: {transacoes.Valor:N2}\nData: {transacoes.Data.ToString("d")}\n";
            }
            return extrato;

        }
       
    }

}
