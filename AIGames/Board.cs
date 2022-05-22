using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIGames
{
    public class Board
    {

      
        //Cell enum. Each cell is either Computer, Human or currently empty
        public enum Cell { Computer, Human, Empty };

        
        // The board can be in four possible states. Either someone has won, it's a draw, or the game is incomplete
        public enum State { ComputerWins, HumanWins, Draw, Incomplete };

        public const int BoardWidth = 3;                         // Board width
        public const int BoardHeight = 3;                        // Board height
        public const int BoardSize = BoardWidth * BoardHeight;   // Board size (height * width)
    
        // Actual Cell array. Will be BoardSize in length.
        public Cell[] Cells { get; set; }
     
        // Board constructor. Initialise all cells to empty.
        public Board()
        {
            this.Cells = new Cell[BoardSize];
            for (var i = 0; i < BoardSize; i++)
            {
                this.Cells[i] = Cell.Empty;
            }
        }


        // Board constructor. Initialise cells to input parameter. Used for cloning boards.
        /// <param name="initialCells">Array of Cells</param>
        public Board(Cell[] initialCells)
        {
            if (initialCells.Length != BoardSize)
            {
                throw new Exception("Board size does not match");
            }

            this.Cells = new Cell[BoardSize];
            for (var i = 0; i < BoardSize; i++)
            {
                this.Cells[i] = initialCells[i];
            }
        }

      
       

        // Get the current state (human won, computer won, draw, or incomplete)
        /// <returns></returns>
        public State GetState()
        {
            #region CheckRows;
            // Check Rows
            if ((this.Cells[0] == this.Cells[1]) && (this.Cells[1] == this.Cells[2]))
            {
                if (this.Cells[0] == Cell.Computer)
                {
                    return State.ComputerWins;
                }
                else if (this.Cells[0] == Cell.Human)
                {
                    return State.HumanWins;
                }
            }
            if ((this.Cells[3] == this.Cells[4]) && (this.Cells[4] == this.Cells[5]))
            {
                if (this.Cells[3] == Cell.Computer)
                {
                    return State.ComputerWins;
                }
                else if (this.Cells[3] == Cell.Human)
                {
                    return State.HumanWins;
                }
            }
            if ((this.Cells[6] == this.Cells[7]) && (this.Cells[7] == this.Cells[8]))
            {
                if (this.Cells[6] == Cell.Computer)
                {
                    return State.ComputerWins;
                }
                else if (this.Cells[6] == Cell.Human)
                {
                    return State.HumanWins;
                }
            }
            #endregion;

            #region CheckColumns;
            // Check Columns
            if ((this.Cells[0] == this.Cells[3]) && (this.Cells[3] == this.Cells[6]))
            {
                if (this.Cells[0] == Cell.Computer)
                {
                    return State.ComputerWins;
                }
                else if (this.Cells[0] == Cell.Human)
                {
                    return State.HumanWins;
                }
            }
            if ((this.Cells[1] == this.Cells[4]) && (this.Cells[4] == this.Cells[7]))
            {
                if (this.Cells[1] == Cell.Computer)
                {
                    return State.ComputerWins;
                }
                else if (this.Cells[1] == Cell.Human)
                {
                    return State.HumanWins;
                }
            }
            if ((this.Cells[2] == this.Cells[5]) && (this.Cells[5] == this.Cells[8]))
            {
                if (this.Cells[2] == Cell.Computer)
                {
                    return State.ComputerWins;
                }
                else if (this.Cells[2] == Cell.Human)
                {
                    return State.HumanWins;
                }
            }
            #endregion;

            #region CheckDiagonals;
            // Check diagonals
            if ((this.Cells[0] == this.Cells[4]) && (this.Cells[4] == this.Cells[8]))
            {
                if (this.Cells[0] == Cell.Computer)
                {
                    return State.ComputerWins;
                }
                else if (this.Cells[0] == Cell.Human)
                {
                    return State.HumanWins;
                }
            }
            if ((this.Cells[2] == this.Cells[4]) && (this.Cells[4] == this.Cells[6]))
            {
                if (this.Cells[2] == Cell.Computer)
                {
                    return State.ComputerWins;
                }
                else if (this.Cells[2] == Cell.Human)
                {
                    return State.HumanWins;
                }
            }
            #endregion;

            #region CheckIncompleteOrDraw;

            if (Cells.Any(c => c == Cell.Empty))
            {
                // If there are still some empty cells, and the Computer and Human still
                // haven't won, then the game is incomplete so far.
                return State.Incomplete;
            }
            else
            {
                // If there is no winner, and but no empty spaces, then its a draw
                return State.Draw;
            }
            #endregion;
        }

        
        // Convert cell to a string (Computer is 'X', Human is '0')
        /// <param name="cell">Individual cell</param>
        /// <returns>String for Cell ('X', 'O' or ' ')</returns>
        public static string CellToString(Cell cell)
        {
            switch (cell)
            {
                case Cell.Computer: return "X";
                case Cell.Human: return "O";
                default: return " ";
            }
        }

       
        // Make a copy of the board
        /// <returns></returns>
        public Board Clone()
        {
            return new Board(this.Cells);
        }
    }
}

