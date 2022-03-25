namespace DevinBank.Library
{
    public interface IContaCorrente : IConta
    {
        decimal ChequeEspecial { get; }
    }
}