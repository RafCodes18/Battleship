using HiddenBattleship.BL.Models;
using HiddenBattleship.PL.Entities;
using HiddenBattleship.PL;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HiddenBattleship.BL
{
    public class ShipManager : GenericManager<tblShip>

    {
        public ShipManager(DbContextOptions<HiddenBattleshipEntities> options) : base(options) { }

        private const string Message = "Row does not exist.";
        public int Insert(Ship ship, bool rollback = false)
        {
            try
            {
                int results = 0;

                using (HiddenBattleshipEntities hb = new HiddenBattleshipEntities(options))
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = hb.Database.BeginTransaction();

                    tblShip newRow = new tblShip();

                    newRow.Id = Guid.NewGuid();
                    newRow.Size = ship.Size;
                    newRow.ShipType = (ShipType)ship.ShipType;


                    // backfill the id on the input parameter order
                    ship.Id = newRow.Id;

                    // Insert the row
                    hb.tblShips.Add(newRow);

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

        public List<Ship> Load(Guid? playerId = null)
        {
            try
            {
                List<Ship> rows = new List<Ship>();
                base.Load()
                    .ForEach(c => rows.Add(
                        new Ship
                        {
                            Id = c.Id,
                            Size = c.Size,
                            ShipType = (Models.enums.ShipType)c.ShipType
                        }));
                return rows;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Ship LoadById(Guid id)
        {
            try
            {
                tblShip row = base.LoadById(id);

                if (row != null)
                {
                    Ship ship = new Ship
                    {
                        Id = row.Id,
                        Size = row.Size,
                        ShipType = (Models.enums.ShipType)row.ShipType
                    };
                    return ship;
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

        public int Update(Ship ship, bool rollback = false)
        {
            try
            {
                int results = 0;

                using (HiddenBattleshipEntities hb = new HiddenBattleshipEntities(options))
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = hb.Database.BeginTransaction();

                    tblShip upDateRow = hb.tblShips.FirstOrDefault(g => g.Id == ship.Id);

                    if (upDateRow != null)
                    {
                        upDateRow.Size = ship.Size;
                        upDateRow.ShipType = (ShipType)ship.ShipType;
                        
                        hb.tblShips.Update(upDateRow);

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

                    tblShip deleteRow = hb.tblShips.FirstOrDefault(g => g.Id == id);

                    if (deleteRow != null)
                    {
                        hb.tblShips.Remove(deleteRow);

                        var deleteShipMoves = hb.tblShips.Where(g => g.Id == id);

                        hb.tblShips.RemoveRange(deleteShipMoves);

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
