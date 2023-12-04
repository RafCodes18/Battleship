using HiddenBattleship.BL.Models.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiddenBattleship.BL.Models
{
    public class Ship
    {
        public Guid Id { get; set; }
        public string ShipName { get; set; }
        public int Size { get; set; }
        public ShipType ShipType { get; set; }
        
    }
}
