namespace HiddenBattleship.PL.Tests
{
    [TestClass]
    public class utGame : utBase
    {
        [TestMethod]
        public void InsertTest()
        {
            int results = 0;
            tblGame tbGame = new tblGame();
            tbGame.EndTime = new TimeSpan(1, 12, 23);
            tbGame.StartTime = new TimeSpan(1, 12, 43);
            tbGame.Player1 = Guid.NewGuid();
            tbGame.Player2 = Guid.NewGuid();
            tbGame.WinnerId = Guid.NewGuid();
            tbGame.IsOver = 0;
            tbGame.LoserId = Guid.NewGuid();

            db.tblGames.Add(tbGame);
            results = db.SaveChanges();

            Assert.IsTrue(results > 0);
        }
    }
}