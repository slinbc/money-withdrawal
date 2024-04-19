using MoneyWithdrawal.Console.Models;
using MoneyWithdrawal.Console.Repositories;

namespace MoneyWithdrawal.Console.Services
{
    public class AccountService : IAccountService
    {
        private IAccountBalanceDAO AccountBalanceDAO;
        private INotificationService NotificationService;
        private IDateTimeProvider DateTimeProvider;
        public AccountService(IAccountBalanceDAO accountBalanceDAO, INotificationService notificationService, IDateTimeProvider dateTimeProvider)
        {
            AccountBalanceDAO = accountBalanceDAO;
            NotificationService = notificationService;
            DateTimeProvider = dateTimeProvider;
        }

        public void Withdraw(string accountNumber, decimal amount)
        {
            AccountBalance? account = AccountBalanceDAO.GetByAccountNumber(accountNumber);
            if (DateTimeProvider.GetCurrentMonth() == 12) //December
            {
                NotificationService.DisplayNotification("Aucun retrait n'est autorisé en Décembre");
            } else if (account != null)
            {
                if (!account.AllowWithdrawal(amount))
                {
                    NotificationService.DisplayNotification("Le montant de la demande dépasse votre autorisation de découvert");
                }
                else
                {
                    AccountBalanceDAO.AddAmount(account.AccountNumber, -amount);
                    NotificationService.DisplayNotification($"Vous venez de retirer {amount} sur votre compte n° {accountNumber}");
                }
            }
        }
    }
}
