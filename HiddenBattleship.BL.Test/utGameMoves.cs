using HiddenBattleship.BL.Models;

namespace HiddenBattleship.BL.Test
{
    [TestClass]
    public class utGameMoves : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            List<GameMoves> gameMoves = new GameMovesManager(options).Load();
            int expected = 4;

            Assert.AreEqual(expected, gameMoves.Count);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            /*var id = GameManager.LoadById(1);
            Assert.AreEqual(new GameMovesManager(options).LoadById(id).Id, id);*/
        }

        [TestMethod]
        public void InsertTest()
        {
            GameMoves GameMoves = new GameMoves
            {
                MoveId = Guid.NewGuid(),
                GameId = Guid.Parse("2c4084fc-7a70-4fc9-a411-f79aa6c5e4bf"),
                PlayerId = Guid.Parse("8be96ee1-3dfd-4621-87aa-696515e526e4"),
                TargetCoordinates = "Test",
                IsHit = true,
                TimeStamp = new TimeSpan()
            };

            int result = new GameMovesManager(options).Insert(GameMoves, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            GameMoves gameMoves = new GameMovesManager(options).Load().FirstOrDefault();
            gameMoves.IsHit = false;
            gameMoves.TargetCoordinates = "Test";
            Assert.IsTrue(new GameMovesManager(options).Update(gameMoves, true) > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            GameMoves gameMoves = new GameMovesManager(options).Load().FirstOrDefault();
            Assert.IsTrue(new GameMovesManager(options).Delete(gameMoves.MoveId, true) > 0);
        }
    }
}
