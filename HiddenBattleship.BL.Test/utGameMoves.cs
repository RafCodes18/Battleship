using HiddenBattleship.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiddenBattleship.BL.Test
{
    [TestClass]
    public class utGameMoves : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            List<GameMoves> gameMoves = new GameMovesManager(options).Load();
            int expected = 3;

            Assert.AreEqual(expected, gameMoves.Count);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            var id = new GameMovesManager(options).Load().FirstOrDefault().Id;
            Assert.AreEqual(new GameMovesManager(options).LoadById(id).Id, id);
        }

        [TestMethod]
        public void InsertTest()
        {
            GameMoves GameMoves = new GameMoves
            {
                MoveId = Guid.NewGuid(),
                GameId = new GameManager(options).Load().FirstOrDefault.Id,
                PlayerId = new PlayerManager(options).Load().FirstOrDefault().Id,
                TargetCoordinates = "Test",
                IsHit = true,
                TimeStamp = DateTime.Now
            };

            int result = new GameMovesManager(options).Insert(GameMoves, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            GameMoves gameMoves = new GameMovesManager(options).Load().FirstOrDefault();
            gameMoves.IsHit = false;
            Assert.IsTrue(new GameMovesManager(options).Update(gameMoves, true) > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            GameMoves gameMoves = new GameMovesManager(options).Load().FirstOrDefault();
            Assert.IsTrue(new GameMovesManager(options).Delete(gameMoves.Id, true) > 0);
        }
    }
}
