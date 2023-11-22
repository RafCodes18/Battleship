using HiddenBattleship.BL.Models;
using HiddenBattleship.PL;
using HiddenBattleship.PL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace HiddenBattleship.BL
{
    public class LoginFailureException : Exception
    {
        public LoginFailureException() : base("Cannot log in with these credentials.  Your IP address has been saved.")
        {
        }

        public LoginFailureException(string message) : base(message)
        {
        }
    }
    public class PlayerManager : GenericManager<tblPlayer>
    {

        public PlayerManager(DbContextOptions<HiddenBattleshipEntities> options) : base(options)
        {

        }

        private static string GetHash(string password)
        {
            using(var hasher = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(password);
                return Convert.ToBase64String(hasher.ComputeHash(hashbytes));
            }
        }


        public int Insert(Player player, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (HiddenBattleshipEntities hb  = new HiddenBattleshipEntities(options)) 
                {
                    bool inuse = hb.tblPlayers.Any(p => p.UserName.Trim().ToUpper() == player.UserName.Trim().ToUpper());

                    if (inuse && rollback == false)
                    {
                        // throw new Exception("This UserName already exists.");
                    }
                    else
                    {
                        IDbContextTransaction transaction = null;
                        if (rollback) transaction = hb.Database.BeginTransaction();

                        tblPlayer newPlayer = new tblPlayer();

                        newPlayer.Id = Guid.NewGuid();
                        newPlayer.UserName = player.UserName.Trim();
                        newPlayer.Email = player.Email.Trim();
                        newPlayer.Password = GetHash(player.Password.Trim());

                        player.Id = newPlayer.Id; 

                        hb.tblPlayers.Add(newPlayer);

                        results = hb.SaveChanges();
                        if (rollback) transaction.Rollback();

                    }
                }
                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Login(Player player)
        {
            try
            {
                if(!string.IsNullOrEmpty(player.UserName))
                {
                    if(!string.IsNullOrEmpty(player.Password))
                    {
                        using (HiddenBattleshipEntities hb = new HiddenBattleshipEntities(options))
                        {
                            tblPlayer userrow = hb.tblPlayers.FirstOrDefault(p => p.UserName == player.UserName);

                            if(userrow != null)
                            {
                                // check password
                                if (userrow.Password == GetHash(player.Password))
                                {
                                    // Login was successful
                                    player.Id = userrow.Id;
                                    player.UserName = userrow.UserName;
                                    player.Password = userrow.Password;
                                    player.Email = userrow.Email;
                                    return true;
                                }
                                else
                                {
                                    throw new LoginFailureException("Cannot log in with these credentials.  Your IP address has been saved.");
                                }
                            }
                            else
                            {
                                throw new Exception("User could not be found.");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Password was not set.");
                    }
                }
                else
                {
                    throw new Exception("User Name was not set.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Player> Load()
        {
            try
            {
                List<Player> players = new List<Player>();

                using (HiddenBattleshipEntities hb = new HiddenBattleshipEntities(options))
                {
                    hb.tblPlayers
                        .ToList()
                        .ForEach(p => players
                        .Add(new Player
                        {
                            Id = p.Id,
                            UserName = p.UserName,
                            Password = p.Password,
                            Email = p.Email
                        }));
                }
                return players;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Player LoadById(Guid id)
        {
            try
            {
                Player player = new Player();

                using (HiddenBattleshipEntities hb = new HiddenBattleshipEntities(options))
                {
                    player = (from p in hb.tblPlayers
                              where p.Id == id
                              select new Player
                              {
                                  Id = p.Id,
                                  UserName = p.UserName,
                                  Password = p.Password,
                                  Email = p.Email
                              }).FirstOrDefault();
                }
                return player;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public int Update(Player player, bool rollback = false)
        {
            try
            {
                int results = 0;

                using (HiddenBattleshipEntities hb = new HiddenBattleshipEntities(options))
                {
                    // Check if username already exists, do not allow..
                    tblPlayer existingUser = hb.tblPlayers.Where(p => p.UserName.Trim().ToUpper() == player.UserName().ToUpper()).FirstOrDefault();

                    if (existingUser != null && existingUser.Id != player.Id && rollback == false)
                    {
                        throw new Exception("This User Name already exists");
                    }
                    else
                    {
                        IDbContextTransaction transaction = null;
                        if (rollback) transaction = hb.Database.BeginTransaction();

                        tblPlayer upDateRow = hb.tblPlayers.FirstOrDefault(r => r.Id == player.Id);

                        if(upDateRow != null)
                        {
                            upDateRow.UserName = player.UserName.Trim();
                            upDateRow.Password = GetHash(player.Password.Trim());
                            upDateRow.Email = player.Email.Trim();

                            hb.tblPlayers.Update(upDateRow);

                            // Commit the changes and get the number of rows affected
                            results = hb.SaveChanges();

                            if (rollback) transaction.Rollback();

                        }
                        else
                        {
                            throw new Exception("Row was not found");
                        }
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
                    // check if user is associated with an existing game
                    bool inuse = hb.tblGames.Any(g => g.Player1 == id);

                    if(inuse)
                    {
                        throw new Exception("This user has not finished their previous game therefore cannot be delected");
                    }
                    else
                    {
                        IDbContextTransaction transaction = null;
                        if(rollback) transaction = hb.Database.BeginTransaction();

                        tblPlayer deleteRow = hb.tblPlayers.FirstOrDefault(r => r.Id == id);

                        if(deleteRow != null)
                        {
                            hb.tblPlayers.Remove(deleteRow);

                            // commit the changed and get the number of rows affected
                            results = hb.SaveChanges();

                            if (rollback) transaction.Rollback();
                        }
                        else
                        {
                            throw new Exception("Row was not found");
                        }
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
