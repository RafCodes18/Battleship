using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiddenBattleship.PL.Entities
{
    public enum ShipType
    {
        Carrier,
        Battleship,
        Cruiser,
        Submarine,
        Destroyer
    }

    public class tblShip : IEntity
    {
        public Guid Id { get; set; }
        public int Size { get; set; }
        public ShipType ShipType { get; set; }

        public string SortField { get { return ShipType.ToString(); } }
    }
}
