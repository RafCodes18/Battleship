using HiddenBattleship.BL.Models;
using HiddenBattleship.PL;
using HiddenBattleship.PL.Entities;
using Microsoft.EntityFrameworkCore;

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
                gameMoves.MoveId = row.Id;
                return base.Insert(row, rollback);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<GameMoves> Load()
        {
            try
            {
                List<GameMoves> rows = new List<GameMoves>();
                base.Load()
                    .ForEach(m => rows.Add(
                        new GameMoves
                        {
                            MoveId = m.Id,
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
                            MoveId = row.Id,
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
                    Id = gameMoves.MoveId,
                    GameId = gameMoves.GameId,
                    PlayerId = gameMoves.PlayerId,
                    IsHit = gameMoves.IsHit,
                    TimeStamp = gameMoves.TimeStamp,
                    GameMoveId = gameMoves.GameMoveId,
                    TargetCoordinates = gameMoves.TargetCoordinates,
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

        //Method to generate a computer move, takes in list of coordinates, returns random coordinates not already taken

        public string GetRandomComputerMove(List<string> takenCoordinates)
        {
            Random random = new Random();
            int row = random.Next(1, 11);
            int col = random.Next(1, 11);

            string newCoordinate = $"{(char)('A' + row - 1)}{col}";

            //if random generated numbers are taken already, select new ones
            while (takenCoordinates.Contains(newCoordinate))
            {
                row = random.Next(1, 11);
                col = random.Next(1, 11);
                newCoordinate = $"{(char)('A' + row - 1)}{col}";
            }

            return newCoordinate;
        }

    }
}
