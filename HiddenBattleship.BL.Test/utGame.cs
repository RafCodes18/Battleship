using HiddenBattleship.BL.Models;

namespace HiddenBattleship.BL.Test
{
    [TestClass]
    public class utGame : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Game> games = new GameManager(options).Load();
            int expected = 4;
            Assert.AreEqual(expected, games.Count);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            /*var id = new GameManager(options)
                .Load()
                .Where(g => g.GameMoves.Count > 0)
                .LastorDefault().Id;
            Game game = new GameManager(options).LoadById(id);
            Assert.AreEqual(game.Id, id);
            Assert.IsTrue(game.GameMoves.Count > 0);*/
        }

        [TestMethod]
        public void InsertTest()
        {
            Game game = new Game
            {
                Player1 = new PlayerManager(options).Load().FirstOrDefault().Id,
                Player2 = Guid.NewGuid(),
                WinnerId = Guid.NewGuid(),
                LoserId = Guid.NewGuid(),
                StartTime = new TimeSpan(),
                EndTime = new TimeSpan(),
                IsOver = true
            };

            var result = new GameManager(options).Insert(game, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Game game = new GameManager(options).Load().FirstOrDefault();
            game.IsOver = false;
            Assert.IsTrue(new GameManager(options).Update(game, true) > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Game game = new GameManager(options).Load().FirstOrDefault();
            Assert.IsTrue(new GameManager(options).Delete(game.Id, true) > 0);
        }

    }
}
