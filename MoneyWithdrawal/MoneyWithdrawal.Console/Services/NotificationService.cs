namespace MoneyWithdrawal.Console.Services
{
    public class NotificationService : INotificationService
    {
        public void DisplayNotification(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}
