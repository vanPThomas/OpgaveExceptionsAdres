namespace DataLibrary
{
    public class AdressException : Exception
    {
        public AdressException() :
            base("An Error Occurred")
        {

        }

        public static void ExceptionDetails(Exception e)
        {
            Console.WriteLine("-----------");
            Console.WriteLine($"Type: {e.GetType()}");
            Console.WriteLine($"Source: {e.Source}");
            Console.WriteLine($"TargetSite: {e.TargetSite.GetType()}");
            Console.WriteLine($"Message: {e.Message}");
            Console.WriteLine("-----------");
        }

    }
}
