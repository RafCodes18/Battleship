using HiddenBattleship.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiddenBattleship.BL.Test
{
    [TestClass]
    public class utChatHistory : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            List<ChatHistory> chatHistories = new ChatHistoryManager(options).Load();
            int expected = 3;
            
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
                Receiver = System.Guid.NewGuid(),
                GameId = new GameManager(options).FirsorDefault().Id,
                Timestamp = DateTime.Now
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
    }
}
