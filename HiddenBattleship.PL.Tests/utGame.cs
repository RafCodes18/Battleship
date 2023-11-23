using HiddenBattleship.PL.Entities;

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
            tbGame.Player1 = db.tblPlayers.FirstOrDefault().Id;
            tbGame.Player2 = db.tblPlayers.FirstOrDefault().Id;
            tbGame.WinnerId = db.tblPlayers.FirstOrDefault().Id;
            tbGame.IsOver = 0;
            tbGame.LoserId = db.tblPlayers.FirstOrDefault().Id;
            tbGame.GameId = 900;

            db.tblGames.Add(tbGame);
            results = db.SaveChanges();

            Assert.IsTrue(results > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            int result;
            tblGame row = db.tblGames.FirstOrDefault(g => g.GameId == 1);
            row.Player1 = db.tblPlayers.FirstOrDefault().Id;

            result = db.SaveChanges();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int result;
            tblGame row = db.tblGames.FirstOrDefault(g => g.GameId == 1);

            db.tblGames.Remove(row);
            result = db.SaveChanges();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void LoadTest()
        {
            tblGame row = db.tblGames.FirstOrDefault(g => g.GameId == 1);
            Assert.AreEqual(1, row.GameId);
        }
    }
}