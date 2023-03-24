using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ENTRETIEN_TECHNIQUE.Console
{
    public class AccountService
    {
       

        public static void Withdraw(string accountNumber, decimal amount)
        {

            AccountBalanceDAO dao = new();
            AccountBalance? account = dao.GetById(accountNumber);

            if (account != null)
            {
                if (amount > account.Balance)
                {
                    System.Console.WriteLine("Le montant de la demande dépasse le solde du compte");
                }
                else
                {
                    AccountBalance newBalance = new(account.AccountNumber,
                                account.Balance - amount);

                    dao.Save(newBalance);

                    System.Console.WriteLine($"Vous venez de retirer {amount} sur votre compte n° {accountNumber}");
                }
            }
        }
    }
}
