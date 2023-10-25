using DataLibrary;

namespace AdressAskerUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataManager dataManager = DataManager.GetInstance();
            Menu(dataManager);
        }

        static void Menu(DataManager dataManager)
        {
            bool keepAsking = true;
            while(keepAsking)
            {
                Console.WriteLine("Maak keuze: [1] adres toevoegen, [2] adres tonen, [3] stoppen");
                bool validChoice = false;
                int input = 0;
                while (!validChoice)
                {
                    string inputAsTxt = Console.ReadLine();
                    if (Int32.TryParse(inputAsTxt, out input) && input <= 3 && input > 0){
                        Console.Clear();
                        break;
                    }
                    Console.WriteLine("Maak keuze: [1] adres toevoegen, [2] adres tonen, [3] stoppen");
                }
                if (input == 1)
                    dataManager.AddAdress();
                else if (input == 2)
                    ReadAdresses(dataManager);
                else if (input == 3)
                    keepAsking = false;
            }
        }
        static void ReadAdresses(DataManager dataManager)
        {
            Console.WriteLine("1 lijn per adres of meerdere? [1] 1 lijn, [2] meerdere");
            bool validChoice = false;
            int input = 0;
            while (!validChoice)
            {
                string inputAsTxt = Console.ReadLine();
                if (Int32.TryParse(inputAsTxt, out input) && input <= 3 && input > 0){
                    Console.Clear();
                    break;
                }
                Console.WriteLine("1 lijn per adres of meerdere? [1] 1 lijn, [2] meerdere");
            }
            if(input == 1)
                dataManager.ReadAdressesOneLine();
            else if(input == 2)
                dataManager.ReadAdressesMultipleLines();
        }
    }
}