namespace MoneyWithdrawal.Console.Services
{
    public interface IAccountService
    {
        void Withdraw(string accountNumber, decimal amount);
    }
}
