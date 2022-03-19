namespace DevinBank
{
    public class Conta
    {
        public int Nome { get; set; }
        public int CPF { get; set; }
        public int RendaMensal { get; set; }
        public int NumConta { get; set; }
        public int Agencia { get; set; }
        public int Saldo { get; set; }

        public decimal Saque() { }
        public decimal Deposito() { }
        public decimal Extrato() { }
        public decimal Transferencia() { }
        public decimal AlterarCadastro() { }

    }

}
