namespace ENTRETIEN_TECHNIQUE.Console
{
    public class Program
    {

        static void Main()
        {
            AccountService.Withdraw("0000001", 150);

            System.Console.WriteLine("Appuyez sur une touche pour terminer l'exécution");
            System.Console.ReadKey();
        }
    }
}