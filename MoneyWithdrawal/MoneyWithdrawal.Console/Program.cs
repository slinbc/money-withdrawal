using MoneyWithdrawal.Console.Repositories;
using MoneyWithdrawal.Console.Services;

namespace ENTRETIEN_TECHNIQUE.Console
{
    public class Program
    {

        static void Main()
        {
            var dao = new AccountBalanceDAO();
            var notification = new NotificationService();
            var dateTimeProvider = new DateTimeProvider();
            var accountService = new AccountService(dao, notification, dateTimeProvider);
            accountService.Withdraw("0000001", 150);

            System.Console.WriteLine("Appuyez sur une touche pour terminer l'exécution");
            System.Console.ReadKey();
        }
    }
}