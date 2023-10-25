namespace DataLibrary
{
    public class Adress
    {
        public Adress(Town town, string street, string houseNumber)
        {
            Town = town;
            Street = street;
            HouseNumber = houseNumber;
        }

        public Town Town { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }

    }
}