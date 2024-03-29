﻿using HiddenBattleship.BL.Models;
using HiddenBattleship.PL;
using HiddenBattleship.PL.Entities;
using HiddenBattleship.Reporting;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace HiddenBattleship.BL
{
    public class ChatHistoryManager : GenericManager<tblChatHistory>
    {
        public ChatHistoryManager(DbContextOptions<HiddenBattleshipEntities> options) : base(options)
        {

        }

        public int Insert(ChatHistory chatHistory, bool rollback = false)
        {
            try
            {
                try
                {
                    tblChatHistory row = new tblChatHistory();
                    row.Sender = chatHistory.Sender;
                    row.Receiver = chatHistory.Receiver;
                    row.GameId = chatHistory.GameId;
                    row.Message = chatHistory.Message;
                    row.Timestamp = chatHistory.Timestamp;
                    row.ChatHistoryId = chatHistory.ChatHistoryId;
                    return base.Insert(row, rollback);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Export(List<ChatHistory> chatHistories, int gameId) 
        {
            try
            {
                string[,] data = new string[chatHistories.Count + 1, 5];
                int counter = 0;


                data[counter, 0] = "ChatHistoryId";
                data[counter, 1] = "Sender";
                data[counter, 2] = "Reciever";
                data[counter, 3] = "Timestamp";
                data[counter, 4] = "Message";
                
                

                counter++;
                foreach (ChatHistory ch in chatHistories)
                {
                    data[counter, 0] = ch.ChatHistoryId.ToString();
                    data[counter, 1] = ch.Sender.ToString();
                    data[counter, 2] = ch.Receiver.ToString();
                    data[counter, 3] = ch.Timestamp.ToString();
                    data[counter, 4] = ch.Message;
                    
                    counter++;
                }

                Excel.Export("ChatHistory.xlsx", data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ChatHistory> Load()
        {
            try
            {
                List<ChatHistory> rows = new List<ChatHistory>();
                base.Load()
                    .ForEach(c => rows.Add(
                        new ChatHistory
                        {
                            Id = c.Id,
                            Sender = c.Sender,
                            Receiver = c.Receiver,
                            GameId = c.GameId,
                            Message = c.Message,
                            Timestamp = c.Timestamp
                        }));
                return rows;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ChatHistory LoadById(Guid id)
        {
            try
            {
                tblChatHistory row = base.LoadById(id);

                if (row != null)
                {
                    ChatHistory chatHistory = new ChatHistory
                    {
                        Id = row.Id,
                        Sender = row.Sender,
                        Receiver = row.Receiver,
                        GameId = row.GameId,
                        Message = row.Message,
                        Timestamp = row.Timestamp
                    };
                    return chatHistory;
                }
                else
                {
                    throw new Exception("Row was not found.");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int Update(ChatHistory chatHistory, bool rollback = false)
        {
            try
            {
                try
                {
                    return base.Update(new tblChatHistory
                    {
                        Id = chatHistory.Id,
                        Sender = chatHistory.Sender,
                        Receiver = chatHistory.Receiver,
                        GameId = chatHistory.GameId,
                        Message = chatHistory.Message,
                        Timestamp = chatHistory.Timestamp
                    }, rollback);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                return base.Delete(id, rollback);
            }
            catch (Exception)
            {

                throw;
            }
        }





    }
}
