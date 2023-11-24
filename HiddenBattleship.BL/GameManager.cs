using HiddenBattleship.BL.Models;
using HiddenBattleship.PL;
using HiddenBattleship.PL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

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
                int results = 0;

                using (HiddenBattleshipEntities hb = new HiddenBattleshipEntities(options))
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = hb.Database.BeginTransaction();

                    tblGame newRow = new tblGame();

                    newRow.Id = Guid.NewGuid();
                    newRow.Player1 = game.Player1;
                    newRow.Player2 = game.Player2;
                    newRow.WinnerId = game.WinnerId;
                    newRow.LoserId = game.LoserId;
                    newRow.StartTime = game.StartTime;
                    newRow.EndTime = game.EndTime;



                    // backfill the id on the input parameter order
                    game.Id = newRow.Id;

                    // Insert the row
                    hb.tblGames.Add(newRow);

                    // Commit the changes and get the number of rows affected
                    results += hb.SaveChanges();

                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Game> Load(Guid? playerId = null)
        {
            try
            {
                List<Game> games = new List<Game>();

                using (HiddenBattleshipEntities hb = new HiddenBattleshipEntities(options))
                {
                    var results = (from g in hb.tblGames
                                   join p in hb.tblPlayers on g.Player1 equals p.Id
                                   where g.Player1 == playerId || playerId == null
                                   select new
                                   {
                                       Id = g.Id,
                                       Player1 = g.Player1,
                                       Player2 = g.Player2,
                                       WinnerId = g.WinnerId,
                                       LoserId = g.LoserId,
                                       StartTime = g.StartTime,
                                       EndTime = g.EndTime,
                                       IsOver = g.IsOver
                                   }).ToList();
                    results.ForEach(g => games.Add(new Game
                    {
                        Id = g.Id,
                        Player1 = g.Player1,
                        Player2 = g.Player2,
                        WinnerId = g.WinnerId,
                        LoserId = g.LoserId,
                        StartTime = g.StartTime,
                        EndTime = g.EndTime,
                        IsOver = g.IsOver
                    }));
                }

                //foreach (Game game in games)
                //{
                //    game.GameMoves = new GameMovesManager(options).LoadbyGameId(game.Id);
                //}    

                return games;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Game LoadById(Guid id)
        {
            try
            {
                using (HiddenBattleshipEntities hb = new HiddenBattleshipEntities(options))
                {
                    var row = (from g in hb.tblGames
                               join p in hb.tblPlayers on g.Player1 equals p.Id
                               where g.Id == id
                               select new
                               {
                                   Id = g.Id,
                                   Player1 = g.Player1,
                                   Player2 = g.Player2,
                                   WinnerId = g.WinnerId,
                                   LoserId = g.LoserId,
                                   StartTime = g.StartTime,
                                   EndTime = g.EndTime,
                                   IsOver = g.IsOver
                               }).FirstOrDefault();

                    if (row != null)
                    {
                        Game game = new Game
                        {
                            Id = row.Id,
                            Player1 = row.Player1,
                            Player2 = row.Player2,
                            WinnerId = row.WinnerId,
                            LoserId = row.LoserId,
                            StartTime = row.StartTime,
                            EndTime = row.EndTime,
                            IsOver = row.IsOver
                        };
                        return game;
                    }
                    else
                    {
                        throw new Exception("Row not found");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Update(Game game, bool rollback = false)
        {
            try
            {
                int results = 0;

                using (HiddenBattleshipEntities hb = new HiddenBattleshipEntities(options))
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = hb.Database.BeginTransaction();

                    tblGame upDateRow = hb.tblGames.FirstOrDefault(g => g.Id == game.Id);

                    if (upDateRow != null)
                    {
                        upDateRow.Player1 = game.Player1;
                        upDateRow.Player2 = game.Player2;
                        upDateRow.WinnerId = game.WinnerId;
                        upDateRow.LoserId = game.LoserId;
                        upDateRow.StartTime = game.StartTime;
                        upDateRow.EndTime = game.EndTime;
                        upDateRow.IsOver = game.IsOver;

                        hb.tblGames.Update(upDateRow);

                        // commit the changes and get the number of rows affected
                        results = hb.SaveChanges();

                        if (rollback) transaction.Rollback();

                    }
                    else
                    {
                        throw new Exception("Row was not found.");
                    }
                }
                return results;
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
                int results = 0;

                using (HiddenBattleshipEntities hb = new HiddenBattleshipEntities(options))
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = hb.Database.BeginTransaction();

                    tblGame deleteRow = hb.tblGames.FirstOrDefault(g => g.Id == id);

                    if (deleteRow != null)
                    {
                        hb.tblGames.Remove(deleteRow);

                        var deleteGameMoves = hb.tblGameMoves.Where(g => g.Id == id);

                        hb.tblGameMoves.RemoveRange(deleteGameMoves);

                        // commit the changes and get the number of rows affected
                        results = hb.SaveChanges();

                        if (rollback) transaction.Rollback();

                    }
                    else
                    {
                        throw new Exception("Row was not found.");
                    }
                }
                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
