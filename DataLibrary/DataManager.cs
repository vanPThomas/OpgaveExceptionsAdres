namespace DataLibrary
{
    public class DataManager
    {
        private DataManager()
        {
            fillTowns();
        }
        Dictionary<string, int> TownNametoZIP = new Dictionary<string, int> { { "gent", 9000 }, { "aalst", 9300 }, { "lokeren", 9160 } };
        List<Adress> adresses = new List<Adress>();
        List<Town> towns = new List<Town>();

        private static DataManager instance;
        public static DataManager GetInstance()
        {
            if (instance != null)
                return instance;
            else
            {
                instance = new DataManager();
                return instance;
            }
        }

        public void AddAdress()
        {
            int inValidInput = 0;
            Console.Write("Gemeente: ");
            string town = Console.ReadLine();
            Console.Write("Straat: ");
            string street = Console.ReadLine();
            Console.Write("Housenumber: ");
            string houseNumber = Console.ReadLine();
            int inValidTown = CheckTown(town);
            int inValidStreet = CheckStreet(street);
            int inValidNumber = CheckHouseNumber(houseNumber);
            inValidInput += inValidTown;
            inValidInput += inValidStreet;
            inValidInput += inValidNumber;
            if (inValidInput == 1)
            {
                if(inValidTown == 1)
                {
                    Console.Write("Gemeente: ");
                    town = Console.ReadLine();
                    inValidTown = CheckTown(town);
                }
                else if(inValidStreet == 1)
                {
                    Console.Write("Straat: ");
                    street = Console.ReadLine();
                    inValidStreet = CheckStreet(street);
                }
                else if(inValidNumber == 1)
                {
                    Console.Write("Housenumber: ");
                    houseNumber = Console.ReadLine();
                    inValidNumber = CheckHouseNumber(houseNumber);
                }
                inValidInput = 0;
                inValidInput += inValidTown;
                inValidInput += inValidStreet;
                inValidInput += inValidNumber;
                if(inValidInput > 0)
                    AddAdress();
                else
                    foreach(Town listedTown in towns)
                        if (listedTown.TownName == town.ToLower())
                        {
                            Adress adress = new Adress(listedTown, street, houseNumber);
                            if(!CheckDuplicateAdress(adress))
                                adresses.Add(adress);
                        }
            }
            else if(inValidInput >= 2)
                AddAdress();
            else
                foreach(Town listedTown in towns)
                    if (listedTown.TownName == town.ToLower())
                    {
                        Adress adress = new Adress(listedTown, street, houseNumber);
                        if(!CheckDuplicateAdress(adress))
                            adresses.Add(adress);
                    }
        }

        public int CheckTown(string town)
        {
            int notValid = 1;
            try
            {
                if (!TownNametoZIP.ContainsKey(town.ToLower()))
                    throw new TownException("Town name Invalid");
                else
                    notValid = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Town Exception!");
                AdressException.ExceptionDetails(ex);
            }
            return notValid;
        }
        public int CheckStreet(string street)
        {
            int notValid = 1;
            try
            {
                if (street == "" || street == null || street == " ")
                    throw new StreetException("Street is null!");
                else
                    notValid = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Street Exception!");
                AdressException.ExceptionDetails(ex);
            }
            return notValid;
            
        }
        private int CheckHouseNumber(string number)
        {
            int notValid = 1;
            try
            {
                if (!Char.IsDigit(number[0]))
                    throw new HouseNumberException("Housenumber does not start with number!");
                else
                    notValid = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Housenumber Exception!");
                AdressException.ExceptionDetails(ex);
            }
            return notValid;
        }
        private bool CheckDuplicateAdress(Adress newAdress)
        {
            bool isDuplicateAdress = false;
            foreach(Adress adress in adresses)
            {
                if(adress.Town == newAdress.Town && adress.HouseNumber == newAdress.HouseNumber && adress.Street == newAdress.Street)
                    isDuplicateAdress = true;
            }
            return isDuplicateAdress;
        }

        public void ReadAdressesOneLine()
        {
            foreach(Adress adress in adresses)
                Console.WriteLine($"{adress.Street} {adress.HouseNumber}, {adress.Town.TownName} - {adress.Town.TownZIP}");
            Console.WriteLine();
        }
        public void ReadAdressesMultipleLines()
        {
            foreach (Adress adress in adresses)
            {
                Console.WriteLine($"{adress.Street} {adress.HouseNumber}");
                Console.WriteLine($"{adress.Town.TownZIP} {adress.Town.TownName}");
                Console.WriteLine();
            }
        }

        public void fillTowns()
        {
            Town gent = new Town("gent", 9000);
            Town aalst = new Town("aalst", 9300);
            Town lokeren = new Town("lokeren", 9160);

            towns.Add(gent);
            towns.Add(aalst);
            towns.Add(lokeren);
        }
    }
}
