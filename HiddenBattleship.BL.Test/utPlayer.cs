using HiddenBattleship.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiddenBattleship.BL.Test
{
    [TestClass]
    public class utPlayer : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Player> players = new PlayerManager(options).Load();
            Assert.IsTrue(players.Count > 0);
        }

        [TestMethod]
        public void InsertTest()
        {
            Player player = new Player
            {
                UserName = "Test",
                Password = "Test2",
                Email = "Test3"
            };

            int result = new PlayerManager(options).Insert(player, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void LoginSuccess()
        {
            Player player = new Player { UserName = "Master", Password = "Test123", Email = "Key" };
            bool result = new PlayerManager(options).Login(player);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LoginFailure()
        {
            try
            {
                Player player = new Player { UserName = "Master", Password = "xxxxx", Email = "Key" };
                new PlayerManager(options).Login(player);
                Assert.Fail();
            }
            catch (LoginFailureException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {

                Assert.Fail();
            }
        }

    }
}
