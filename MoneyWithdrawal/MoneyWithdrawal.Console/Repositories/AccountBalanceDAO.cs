using MoneyWithdrawal.Console.Models;

namespace MoneyWithdrawal.Console.Repositories
{
    public class AccountBalanceDAO : IAccountBalanceDAO
    {
        private List<AccountBalance> AccountBalances;

        public AccountBalanceDAO()
        {
            AccountBalances = new(){
                new("0000001", 120),
                new("0000002", 50),
                new("0000003", 0)
            };
        }

        public AccountBalanceDAO(List<AccountBalance> accountBalances)
        {
            AccountBalances = accountBalances;

        }

        public AccountBalance? GetByAccountNumber(string accountNumber)
        {
            return AccountBalances.FirstOrDefault(e => e.AccountNumber.Equals(accountNumber));
        }

        public void AddAmount(string accountNumber, decimal amount)
        {
            var account = GetByAccountNumber(accountNumber);
            if (account != null)
            {
                account.AddBalance(amount);
            }
        }
    }
}
