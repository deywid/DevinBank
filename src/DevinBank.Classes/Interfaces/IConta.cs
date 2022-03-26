﻿using DevinBank.Library.Enums;

namespace DevinBank.Library
{
    public interface IConta
    {
        AgenciaEnum Agencia { get; }
        string CPF { get; }
        string Nome { get; }
        int NumConta { get; }
        decimal RendaMensal { get; }
        decimal Saldo { get; }
        public IList<Transacao> Transacoes { get; }
        public IList<Transferencia> Transferencias { get; }

        void Deposito(decimal montante);
        void Saque(decimal montante);
        void Transferencia(Conta contaBeneficiaria, decimal montante);
        string Extrato();
        void AlterarCadastro(string nome);
        void AlterarCadastro(decimal rendaMensal);
        void AlterarCadastro(AgenciaEnum agencia);
        string ExtratoTransacoes();
        void SalvarTransferencia(IConta contaDestino, decimal valor, DateTime data);
        string HistoricoTransferencias();
    }
}