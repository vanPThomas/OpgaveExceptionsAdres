namespace DataLibrary
{
    public class Town
    {
        public Town(string townName, int townZIP)
        {
            TownName = townName;
            TownZIP = townZIP;
        }

        public string TownName { get; private set; }
        public int TownZIP { get; private set; }

    }
}
