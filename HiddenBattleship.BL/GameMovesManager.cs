using HiddenBattleship.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiddenBattleship.BL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using NuGet.Packaging.Signing;
using System.ComponentModel;
using HiddenBattleship.PL.Entities;

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
                    GameId = gameMoves.GameId,
                    PlayerId = gameMoves.PlayerId,
                    TargetCoordinates = gameMoves.TargetCoordinates,
                    IsHit = gameMoves.IsHit,
                    TimeStamp = gameMoves.TimeStamp,
                    GameMoveId = gameMoves.GameMoveId
                };
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
            try
            {
                List<GameMoves> rows = new List<GameMoves>();
                base.Load()
                    .ForEach(m => rows.Add(
                        new GameMoves
                        {
                            Id = m.Id,
                            GameId = m.GameId,
                            PlayerId = m.PlayerId,
                            IsHit = m.IsHit,
                            TimeStamp = m.TimeStamp,
                            GameMoveId = m.GameMoveId
                        }));
                return rows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GameMoves LoadById(Guid id)
        {
            try
            {
                using (HiddenBattleshipEntities hb = new HiddenBattleshipEntities(options))
                {
                    tblGameMove row = hb.tblGameMoves.FirstOrDefault(gm => gm.Id == id);

                    if (row != null)
                    {
                        GameMoves gameMoves = new GameMoves
                        {
                            Id = row.Id,
                            GameId = row.GameId,
                            PlayerId = row.PlayerId,
                            IsHit = row.IsHit,
                            TimeStamp = row.TimeStamp,
                            GameMoveId = row.GameMoveId
                        };
                        return gameMoves;
                    }
                    else
                    {
                        throw new Exception("Row was not found.");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Update(GameMoves gameMoves, bool rollback = false)
        {
            try
            {
                return base.Update(new tblGameMove
                {
                    Id = gameMoves.Id,
                    GameId = gameMoves.GameId,
                    PlayerId = gameMoves.PlayerId,
                    IsHit = gameMoves.IsHit,
                    TimeStamp = gameMoves.TimeStamp,
                    GameMoveId = gameMoves.GameMoveId
                }, rollback);
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
