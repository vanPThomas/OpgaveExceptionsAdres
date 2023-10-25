namespace DataLibrary
{
    public class TownException : Exception
    {
        public string message { get; } = "fine";
        public TownException(string message) : base(message) { this.message = message; }
        

    }
}
