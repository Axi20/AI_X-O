using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIGames
{
    public class MiniMaxTree
    {
        
        // Calculates the MiniMax tree for a particular board
        /// <param name="board">Current state of board</param>
        public MiniMaxTree(Board board)
        {
            // MiniMaxTree is only ever called for the Computer player, so presume next move  will always be computer.

            // Create the list of child nodes
            this.ChildNodes = new List<MiniMaxNode>();
            for (var i = 0; i < Board.BoardSize; i++)
            {
                // For each empty cell in the current board
                if (board.Cells[i] == Board.Cell.Empty)
                {
                    // Make a copy of the current board..
                    var childBoard = board.Clone();
                    // ..fill in the cell with Computers move and calculate score recursively
                    var miniMaxNode = new MiniMaxNode(childBoard, i, Board.Cell.Computer, 0);
                    // Finally, add the node to the children
                    ChildNodes.Add(miniMaxNode);
                }
            }
        }

        // Find the best possible move
        /// <returns>The best MiniMaxNode move</returns>
        public MiniMaxNode GetBestMove()
        {
            Random random = new Random(DateTime.Now.Millisecond);

            // Find the best possible score
            int bestScore = this.ChildNodes.OrderBy(n => n.Score).Last().Score;
            // Filter all possible moves to get all moves with best possible score
            var bestMoves = this.ChildNodes.Where(n => n.Score == bestScore).ToArray();
            // Randomly return one of the best moves
            return bestMoves[random.Next(bestMoves.Count())];
        }

        
        // Child nodes of the tree. Kept private since caller should use GetBestMove()
        private List<MiniMaxNode> ChildNodes { get; }
    }
}

