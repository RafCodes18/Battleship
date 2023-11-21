using HiddenBattleship.BL.Models;
using HiddenBattleship.PL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiddenBattleship.BL
{
    public class GameManager : GenericManager<tblGame>

    {
        public GameManager(DbContextOptions<HiddenBattleshipEntities> options) : base(options) { }

        private const string Message = "Row does not exist.";

        public int Insert(Game game, bool rollback = false)
        {
            try
            {
                tblGame row = new tblGame()
                {
                    Player1 = game.Player1,
                    Player2 = game.Player2,
                    WinnerId = game.WinnerId,
                    LoserId = game.LoserId,
                    StartTime = game.StartTime,
                    EndTime = game.EndTime,
                    IsOver = game.IsOver
                };
                return base.Insert(row, rollback);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<tblGame> Load()
        {

        }

        public Game LoadById(Guid id)
        {

        }

        public int Update(Game game, bool rollback = false)
        {

        }

        public int Delete(Guid id, bool rollback = false)
        {

        }
    }
    
}
