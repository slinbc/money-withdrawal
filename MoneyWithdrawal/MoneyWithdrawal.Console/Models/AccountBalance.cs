namespace MoneyWithdrawal.Console.Models
{
    public class AccountBalance
    {
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public decimal AllowedDiscovery { get; private set; }

        public AccountBalance(string accountNumber, decimal balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
            AllowedDiscovery = 0;
        }

        public AccountBalance(string accountNumber, decimal balance, decimal allowDiscovery)
        {
            AccountNumber = accountNumber;
            Balance = balance;
            AllowedDiscovery = allowDiscovery;
        }

        public void AddBalance(decimal amount)
        {
            Balance += amount;
        }

        public bool AllowWithdrawal(decimal amount) {
            return Balance + Math.Abs(AllowedDiscovery) > amount;
        }
    }
}
