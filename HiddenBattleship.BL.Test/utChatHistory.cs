using HiddenBattleship.BL.Models;
using iText.Forms.Xfdf;

namespace HiddenBattleship.BL.Test
{
    [TestClass]
    public class utChatHistory : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            List<ChatHistory> chatHistories = new ChatHistoryManager(options).Load();
            int expected = 4;

            Assert.AreEqual(expected, chatHistories.Count);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            ChatHistory chatHistory = new ChatHistoryManager(options).Load().FirstOrDefault();
            Assert.AreEqual(new ChatHistoryManager(options).LoadById(chatHistory.Id).Id, chatHistory.Id);
        }

        [TestMethod]
        public void InsertTest()
        {
            ChatHistory chatHistory = new ChatHistory
            {
                Sender = System.Guid.NewGuid(),
                Receiver = Guid.Parse("0e7af0f1-d3b4-4d3f-aab7-5399cba2868a"),
                GameId = Guid.Parse("9e227195-3ea1-4d23-a5fc-df835b7c46a8"),
                Timestamp = new TimeSpan(),
                Message = "yooo",
                ChatHistoryId = 1,
            };

            int result = new ChatHistoryManager(options).Insert(chatHistory, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            ChatHistory chatHistory = new ChatHistoryManager(options).Load().FirstOrDefault();
            chatHistory.Message = "Test";

            Assert.IsTrue(new ChatHistoryManager(options).Update(chatHistory, true) > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            ChatHistory chatHistory = new ChatHistoryManager(options).Load().FirstOrDefault();

            Assert.IsTrue(new ChatHistoryManager(options).Delete(chatHistory.Id, true) > 0);
        }

        [TestMethod]
        public void ExportTest()
        {
            List<ChatHistory> chatHistories = new ChatHistoryManager(options).Load();
            int expected = 4;
            ChatHistoryManager.Export(chatHistories,1);


            Assert.AreEqual(expected, chatHistories.Count);
        }
    }
}
