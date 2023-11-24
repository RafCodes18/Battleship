using HiddenBattleship.PL.Entities;

namespace HiddenBattleship.PL.Tests
{
    [TestClass]
    public class utGameMove : utBase
    {
        [TestMethod]
        public void InsertTest()
        {
            int results = 0;
            tblGameMove tbGameMove = new tblGameMove();
            tbGameMove.TimeStamp = new TimeSpan(1, 12, 43);
            tbGameMove.TargetCoordinates = "B2";
            tbGameMove.PlayerId = db.tblPlayers.FirstOrDefault().Id;
            tbGameMove.GameId = db.tblGames.FirstOrDefault().Id;

            db.tblGameMoves.Add(tbGameMove);
            results = db.SaveChanges();

            Assert.IsTrue(results > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            int result;
            tblGameMove row = db.tblGameMoves.FirstOrDefault(g => g.GameMoveId == 1);
            row.TargetCoordinates = "A7";

            result = db.SaveChanges();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int result;
            tblGameMove row = db.tblGameMoves.FirstOrDefault();

            db.tblGameMoves.Remove(row);
            result = db.SaveChanges();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void LoadTest()
        {
            tblGameMove row = db.tblGameMoves.FirstOrDefault(g => g.GameMoveId == 1);
            Assert.AreEqual(1, row.GameMoveId);
        }
    }
}