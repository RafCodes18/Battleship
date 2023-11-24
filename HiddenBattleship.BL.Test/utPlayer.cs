using HiddenBattleship.BL.Models;

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
            Player player = new Player { UserName = "uTest", Password = "qUqP5cyxm6YcTAhz05Hph5gvu9M=", Email = "uTest@yahoo.com" };
            bool result = new PlayerManager(options).Login(player);
            Assert.IsTrue(result);
        }
        /*      
         *      
         *      Commented out for now.
                [TestMethod]
                public void LoginFailure()
                {
                    try
                    {
                        Player player = new Player { UserName = "ooga booga", Password = "qUqP5cyxm6YcTAhz05Hph5gvu9M=", Email = "uTest@yahoo.com" };
                        bool result = new PlayerManager(options).Login(player);
                    }
                    catch (LoginFailureException)
                    {
                        Assert.IsTrue(true);
                    }
                }*/
    }
}
