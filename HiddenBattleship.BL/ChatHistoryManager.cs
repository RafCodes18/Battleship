using HiddenBattleship.BL.Models;
using HiddenBattleship.PL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiddenBattleship.BL
{
    public class ChatHistoryManager : GenericManager<tblChatHistory>
    {
        public ChatHistoryManager(DbContextOptions<HiddenBattleshipEntities> options) : base(options)
        {

        }

        public int Insert(ChatHistory chatHistory, bool rollback = false)
        {

        }

        public List<tblChatHistory> Load()
        {

        }

        public ChatHistory LoadById()
        {

        }

        public int Update()
        {

        }

        public int Delete() 
        {

        }





    }
}
