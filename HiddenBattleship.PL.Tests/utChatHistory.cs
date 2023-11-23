using HiddenBattleship.PL.Entities;

namespace HiddenBattleship.PL.Tests
{
    [TestClass]
    public class utChatHistory : utBase
    {
        [TestMethod]
        public void InsertTest()
        {
            int results = 0;
            tblChatHistory tbChatHistory = new tblChatHistory();
            tbChatHistory.Sender = db.tblPlayers.FirstOrDefault().Id;
            tbChatHistory.Message = "message";
            tbChatHistory.Receiver = db.tblPlayers.FirstOrDefault().Id;
            tbChatHistory.GameId = db.tblGames.FirstOrDefault().Id;
            tbChatHistory.Timestamp = new TimeSpan(1, 12, 43);
            tbChatHistory.ChatHistoryId = 100;

            db.tblChatHistory.Add(tbChatHistory);
            results = db.SaveChanges();

            Assert.IsTrue(results > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            int result;
            tblChatHistory row = db.tblChatHistory.FirstOrDefault(g => g.ChatHistoryId == 1);
            row.Receiver = db.tblPlayers.FirstOrDefault().Id;

            result = db.SaveChanges();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int result;
            tblChatHistory row = db.tblChatHistory.FirstOrDefault(g => g.ChatHistoryId == 1);

            db.tblChatHistory.Remove(row);
            result = db.SaveChanges();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void LoadTest()
        {
            tblChatHistory row = db.tblChatHistory.FirstOrDefault(g => g.ChatHistoryId == 1);
            Assert.AreEqual(1, row.ChatHistoryId);
        }
    }
}