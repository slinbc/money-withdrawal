using MoneyWithdrawal.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWithdrawal.Console.Repositories
{
    public interface IAccountBalanceDAO
    {
        AccountBalance? GetByAccountNumber(string accountNumber);
        void AddAmount(string accountNumber, decimal amount);
    }
}
