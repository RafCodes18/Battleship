using HiddenBattleship.BL.Models.enums;
using HiddenBattleship.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiddenBattleship.BL.GameLogic
{
    public class BoardCreator
    {
        public Board CreateBoard(int rows, int columns)
        {
            try
            {
                //build the board and set all the cells to unoccupied
                BoardCellStatus[,] boardCellStatuses = new BoardCellStatus[rows, columns];
                for (int row = 0; row < rows; row++)
                {
                    for (int column = 0; column < columns; column++)
                    {
                        boardCellStatuses[row, column] = BoardCellStatus.Unoccupied;
                    }
                }

                //return the board
                return new Board
                {
                    BoardCellStatuses = boardCellStatuses,
                    Rows = rows,
                    Columns = columns
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while creating board : {ex.Message}");
            }
        }
    }
}

