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
            Player player = new Player { UserName = "Sh1PD3STR0Y3R", Password = GetHash("password"), Email = "123@gmail.com" };
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

        private static string GetHash(string Password)
        {
            using (var hasher = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(Password);
                return Convert.ToBase64String(hasher.ComputeHash(hashbytes));
            }
        }

    }
}
