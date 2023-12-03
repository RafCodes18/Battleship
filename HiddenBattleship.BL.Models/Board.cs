using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiddenBattleship.BL.Models.enums;

namespace HiddenBattleship.BL.Models
{
    public class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public BoardCellStatus[,] BoardCellStatuses { get; set; }
        public int ShipTilesCount { get; set; }
        public int HitCount { get; set; }

    }
}
