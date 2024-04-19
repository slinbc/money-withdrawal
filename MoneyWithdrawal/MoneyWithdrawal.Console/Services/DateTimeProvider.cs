namespace MoneyWithdrawal.Console.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public int GetCurrentMonth()
        {
            return DateTime.Now.Month;
        }
    }
}
