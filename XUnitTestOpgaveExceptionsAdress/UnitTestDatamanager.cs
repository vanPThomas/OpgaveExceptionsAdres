using DataLibrary;

namespace XUnitTestOpgaveExceptionsAdress
{
    public class UnitTestDatamanager
    {
        [Theory]

        [InlineData("gent")]
        [InlineData("GENT")]
        [InlineData("Gent")]
        [InlineData( "gENT")]
        public void Test_CheckTownCorrect(string town)
        {
            DataManager d = DataManager.GetInstance();
            int notValid = d.CheckTown(town);
            Assert.Equal(0, notValid);
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("bang")]
        [InlineData(null)]
        public void Test_CheckTownBad(string town)
        {
            DataManager d = DataManager.GetInstance();
            int notValid = d.CheckTown(town);
            Assert.Equal(1, notValid);
        }

        [Theory]
        [InlineData("Big Street")]
        [InlineData("smallstreet")]
        
        public void Test_CheckStreetCorrect(string name)
        {
            DataManager d = DataManager.GetInstance();
            int notValid = d.CheckStreet(name);
            Assert.Equal(0, notValid);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Test_CheckStreetBad(string name)
        {
            DataManager d = DataManager.GetInstance();
            int notValid = d.CheckStreet(name);
            Assert.Equal(1, notValid);
        }
    }
}