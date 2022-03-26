using System.Threading;
using DevinBank.Library.Enums;

namespace DevinBank.Library
{
    public abstract class Conta : IConta
    {
        private static int _cont;
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public decimal RendaMensal { get; private set; }
        public int NumConta { get; private set; }
        public AgenciaEnum Agencia { get; private set; }
        public decimal Saldo { get; private set; }
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

        public void Saque(decimal montante)
        {
            Saldo -= montante;

            DateTime date = DateTime.Now;
            TipoTransacao tipo = new(TipoTransacaoEnum.Saque);
            SalvarTransacao(tipo, montante, date);
        }
        public void Deposito(decimal montante)
        {
            Saldo += montante;

            DateTime date = DateTime.Now;
            TipoTransacao tipo = new(TipoTransacaoEnum.Deposito);
            SalvarTransacao(tipo, montante, date);
        }
        public void Transferencia(Conta contaBeneficiaria, decimal montante)
        {
            Saldo -= montante;
            contaBeneficiaria.Saldo += montante;

            TipoTransacao tipo = new(TipoTransacaoEnum.Transferencia);
            DateTime date = DateTime.Now;
            SalvarTransacao(tipo, montante, date);
            SalvarTransferencia(contaBeneficiaria, montante, date);
        }
        public string Extrato()
        {
            return $"\nCliente: {Nome}\nCPF: {CPF}\nConta: {NumConta}\nAgencia: {Agencia}\n\nSaldo em conta: {Saldo}";
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
        public string HistoricoTransferencias()
        {
            string historico = "Histórico de Transferencias:\n";
            foreach (var transferencia in Transferencias)
            {
                historico += $"\nConta: {transferencia.ContaOrigem.NumConta}\nBeneficiario: {transferencia.ContaDestino.NumConta}\nValor: {transferencia.Valor}\nData: {transferencia.Data}\n";
            }
            return historico;
        }
        public void SalvarTransacao(TipoTransacao tipo, decimal valor, DateTime data)
        {
            Transacoes.Add(new Transacao(tipo, valor, data));
        }


        public virtual string ExtratoTransacoes()
        {
            string extrato = "Extrato das transações:\n";
            foreach (var transacoes in Transacoes)
            {
                extrato += $"\nTransação: {transacoes.TipoTransacao.Nome}\nValor: {transacoes.Valor}\nData: {transacoes.Data}\n";
            }
            return extrato;

        }

    }




}
