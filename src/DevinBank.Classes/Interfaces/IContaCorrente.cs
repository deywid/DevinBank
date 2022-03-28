namespace DevinBank.Library
{
    public interface IContaCorrente : IConta
    {
        decimal LimiteChequeEspecial { get; }
    }
}