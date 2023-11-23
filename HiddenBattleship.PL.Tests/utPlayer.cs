using HiddenBattleship.PL.Entities;
using HiddenBattleship.PL;

namespace HiddenBattleship.PL.Tests
{
    [TestClass]
    public class utPlayer : utBase
    {
        [TestMethod]
        public void InsertTest()
        {
            int results = 0;
            tblPlayer tbPlayer = new tblPlayer();
            tbPlayer.Email = "test";
            tbPlayer.UserName = "test";
            tbPlayer.Password = "test";


            db.tblPlayers.Add(tbPlayer);
            results = db.SaveChanges();

            Assert.IsTrue(results > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            int result;
            var row = db.tblPlayers.FirstOrDefault(p => p.UserName == "Sh1PD3STR0Y3R");
            row.UserName = "afafafaf";

            result = db.SaveChanges();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int result;
            tblPlayer row = db.tblPlayers.FirstOrDefault(p => p.UserName == "uTest");

            db.tblPlayers.Remove(row);
            result = db.SaveChanges();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void LoadTest()
        {
            tblPlayer row = db.tblPlayers.FirstOrDefault(p => p.Email == "789@yahoo.com");
            Assert.AreEqual("7DUut/wAuxmp4mKiKKNr9eEUeG0=", row.Password);
        }
    }
}