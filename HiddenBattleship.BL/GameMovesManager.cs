using HiddenBattleship.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiddenBattleship.BL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

namespace HiddenBattleship.BL
{
    public class GameMovesManager : GenericManager<tblGameMove>
    {
        public GameMovesManager(DbContextOptions<HiddenBattleshipEntities> options) : base(options)
        {

        }

        private const string Message = "Row does not exist.";

        public int Insert(GameMoves gameMoves, bool rollback = false)
        {
            try
            {
                tblGameMove row = new tblGameMove
                {
                    GameId = ,
                    
                }
                gameMoves.Id = row.Id;
                return base.Insert(row, rollback);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<tblGameMove> Load() 
        {

        }

        public GameMoves LoadById(Guid id)
        {

        }

        public int Update(GameMoves gameMoves, bool rollback = false)
        {

        }

        public int Delete(Guid id, bool rollback = false) 
        {

        }

    }
}
