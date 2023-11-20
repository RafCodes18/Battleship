using HiddenBattleship.PL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiddenBattleship.BL
{
    public class PlayerManager : GenericManager<tblPlayer>
    {
        public PlayerManager(DbContextOptions<HiddenBattleshipEntities> options) : base(options)
        {

        }
    }
}
