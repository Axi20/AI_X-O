using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIGames.Properties;
using System.Threading;
using System.Diagnostics;


namespace AIGames
{
    public partial class Game : UserControl
    {
        Stopwatch stopwatch;
        int aiWins = 0;
        int youWin = 0;
        string time = DateTime.Now.ToString("HH:mm");

        StreamWriter sw = new StreamWriter("score_ai.txt",true);
        // Local variable for the actual board
        private Board _board;

       
        // Boolean for toggling whether the current move is for human or computer
        private bool _currentMoveIsHuman = true;

       
        /// Form constructor
        public Game()
        {
            InitializeComponent();
            this.DisableAllCellButtons();
        }


    
        /*Start a game. Clear the board, display the UI and if the first move is human,
        let the user click a button, otherwise use Minimax to calculate computer move.*/
      
        /// <param name="sender"></param>
        /// <param name="e"></param>
       
        private void startButton_Click(object sender, EventArgs e)
        {
            sw.WriteLine("-------------SCORES------------");
            sw.WriteLine("The game is started " + time);
            stopwatch.Start();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            this.startButton.Enabled = false;
            this._board = new Board();
            this.DrawBoard();
            this.label3.Text = string.Empty;

            if (this._currentMoveIsHuman)
            {
               
                label1.Visible = true;
                label2.Visible = false;
                label3.Visible = false;
               
                this.label1.Text = "It's Your turn!";
            }
            else
            {
                label1.Visible = false;
                label2.Visible = true;
                label3.Visible = false;
               // this.label2.Text = "It's AI turn";
                var miniMaxTree = new MiniMaxTree(_board);
                Thread.Sleep(1000);
                var bestMove = miniMaxTree.GetBestMove();
                _board.Cells[bestMove.UpdatedCellIndex] = Board.Cell.Computer;
                this.Process();
            }
        }

      
        /* Main method for actually processing the board. Update the UI and check to see
        if someone has won, or we have a draw. If the game is not yet over, let the user
        press a button, or calculate the next computer move accordingly.*/

        private void Process()
        {
            this.DrawBoard();

            #region CheckAIWins;
            if (this._board.GetState() == Board.State.ComputerWins)
            {
                sw.WriteLine("--------The AI won the match--------");
                sw.WriteLine("--------Elapsed time: {0} --: ", label4.Text);
                sw.WriteLine("--------AI wins: {0} ---------", aiWins);
                sw.WriteLine();
                aiWins++;
                label5.Text = "AI wins - " + aiWins.ToString();
                if(MessageBox.Show("The AI wins!", "AI wins", MessageBoxButtons.OK) == DialogResult.OK)
                {
                   
                }

                this.DisableAllCellButtons();
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = true;
                this.label3.Text = "Press start to play a game";
                this.startButton.Enabled = true;
                this._currentMoveIsHuman = !this._currentMoveIsHuman;
            }
            #endregion;

            #region CheckHumanWins;
            else if (this._board.GetState() == Board.State.HumanWins)
            {
                sw.WriteLine("--------You won the match--------");
                sw.WriteLine("--------Elapsed time: {0} --: ", label4.Text);
                sw.WriteLine("--------Player wins: {0} ---------", youWin);
                sw.WriteLine();
                youWin++;
                label6.Text = "Your wins - " + youWin.ToString();
                if (MessageBox.Show("You win!", "You wins", MessageBoxButtons.OK) == DialogResult.OK)
                {
                   
                }

                this.DisableAllCellButtons();
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = true;
                this.label3.Text = "Press start to play a game";
                this.startButton.Enabled = true;
                this._currentMoveIsHuman = !this._currentMoveIsHuman;
            }
            #endregion;

            #region CheckDraw;
            else if (this._board.GetState() == Board.State.Draw)
            {
                sw.WriteLine("--------It's a draw match--------");
                sw.WriteLine("--------Elapsed time: {0} --: ", label4.Text);
                sw.WriteLine();
                if (MessageBox.Show("It's a draw!", "Draw", MessageBoxButtons.OK) == DialogResult.OK)
                {
                  
                }

                this.DisableAllCellButtons();
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = true;
                this.label3.Text = "Press start to play a game";
                this.startButton.Enabled = true;
                this._currentMoveIsHuman = !this._currentMoveIsHuman;
            }
            #endregion;

            else
            {
                // The game hasn't finished yet (noone has won and it isn't a draw), so invert
                // the current-move boolean.
                this._currentMoveIsHuman = !this._currentMoveIsHuman;
                if (this._currentMoveIsHuman)
                {
                    // If the next move is human, set the text box and do nothing (wait for
                    // user to actually press a button)
                    //label1.Visible = true;
                    label2.Visible = false;
                    label3.Visible = false;
                    //this.label1.Text = "It's Your turn!";
                }
                else
                {
                    // If the next move is computer, use Minimax to calculate the next move
                    // based on the current board

                    label1.Visible = false;
                   // label2.Visible = true;
                    label3.Visible = false;
                   // this.label2.Text = "It's AI turn";
                    var miniMaxTree = new MiniMaxTree(_board);
                    Thread.Sleep(1000);
                    var bestMove = miniMaxTree.GetBestMove();
                    _board.Cells[bestMove.UpdatedCellIndex] = Board.Cell.Computer;
                    this.Process();
                }
            }
        }


        //Draw the board. Set the text for each cell, and disable any buttons that have already been set to a X or O

        private void DrawBoard()
        {
            SetButtonCell(topLeftButton, _board.Cells[0]);
            SetButtonCell(topCenterButton, _board.Cells[1]);
            SetButtonCell(topRightButton, _board.Cells[2]);

            SetButtonCell(middleLeftButton, _board.Cells[3]);
            SetButtonCell(middleCenterButton, _board.Cells[4]);
            SetButtonCell(middleRightButton, _board.Cells[5]);

            SetButtonCell(bottomLeftButton, _board.Cells[6]);
            SetButtonCell(bottomCenterButton, _board.Cells[7]);
            SetButtonCell(bottomRightButton, _board.Cells[8]);
        }


        //Set the text (X or O) for a button, and then disable it so user cannot click it again during this game.
        /// <param name="button">Button to set</param>
        /// <param name="cell">O, X or Empty</param>
        
        private void SetButtonCell(Button button, Board.Cell cell)
        {
            switch (cell)
            {
                case Board.Cell.Computer:
                    {
                        button.Text = Board.CellToString(cell);
                        button.Enabled = false;
                        break;
                    }
                case Board.Cell.Human:
                    {
                        button.Text = Board.CellToString(cell);
                        button.Enabled = false; break;
                    }
                case Board.Cell.Empty:
                    {
                        button.Text = Board.CellToString(cell);
                        button.Enabled = true;
                        break;
                    }
            }
        }


        //Disable all 9 buttons. Called when game is over because either someone won or we reached a draw

        private void DisableAllCellButtons()
        {
            topLeftButton.Enabled = false;
            topCenterButton.Enabled = false;
            topRightButton.Enabled = false;

            middleLeftButton.Enabled = false;
            middleCenterButton.Enabled = false;
            middleRightButton.Enabled = false;

            bottomLeftButton.Enabled = false;
            bottomCenterButton.Enabled = false;
            bottomRightButton.Enabled = false;
        }

        #region Buttons method;
        private void topLeftButton_Click(object sender, EventArgs e)
        {
            this._board.Cells[0] = Board.Cell.Human;
            this.Process();
        }

        private void topCenterButton_Click(object sender, EventArgs e)
        {
            this._board.Cells[1] = Board.Cell.Human;
            this.Process();
        }

        private void topRightButton_Click(object sender, EventArgs e)
        {
            this._board.Cells[2] = Board.Cell.Human;
            this.Process();
        }

        private void middleLeftButton_Click(object sender, EventArgs e)
        {
            this._board.Cells[3] = Board.Cell.Human;
            this.Process();
        }

        private void middleCenterButton_Click(object sender, EventArgs e)
        {
            this._board.Cells[4] = Board.Cell.Human;
            this.Process();
        }

        private void middleRightButton_Click(object sender, EventArgs e)
        {
            this._board.Cells[5] = Board.Cell.Human;
            this.Process();
        }

        private void bottomLeftButton_Click(object sender, EventArgs e)
        {
            this._board.Cells[6] = Board.Cell.Human;
            this.Process();
        }

        private void bottomCenterButton_Click(object sender, EventArgs e)
        {
            this._board.Cells[7] = Board.Cell.Human;
            this.Process();
        }

        private void bottomRightButton_Click(object sender, EventArgs e)
        {
            this._board.Cells[8] = Board.Cell.Human;
            this.Process();
        }
        #endregion;

        //Restart button
        private void restartButton_Click(object sender, EventArgs e)
        {
            sw.WriteLine("--RESTART button clicked--");
            sw.WriteLine();
            this.startButton.Enabled = false;
            this._board = new Board();
            stopwatch.Restart();
            this.DrawBoard();
            label5.Text = "AI wins";
            

            if (this._currentMoveIsHuman)
            {
               // label1.Visible = true;
                label2.Visible = false;
                label3.Visible = false;
                //this.label3.Text = "It's Your turn!";
            }
            else
            {
                label1.Visible = false;
               // label2.Visible = true;
                label3.Visible = false;
              //  this.label3.Text = "It's AI turn";
                var miniMaxTree = new MiniMaxTree(_board);
                Thread.Sleep(1000);
                var bestMove = miniMaxTree.GetBestMove();
                _board.Cells[bestMove.UpdatedCellIndex] = Board.Cell.Computer;
                this.Process();
            }
        }

        //Exit button
        private void button1_Click(object sender, EventArgs e)
        {
            sw.WriteLine("--EXIT button clicked--");
            sw.WriteLine();
            if(MessageBox.Show("Are you sure you want to exit?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Menu menu = new Menu();
                this.Controls.Add(menu);
                panel1.Hide();
                sw.WriteLine("--Exit to the menu--");
            }
            sw.AutoFlush = true;
            sw.Close();
           
        }
     
        
        //Stopwatch
        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = string.Format("{0:hh\\:mm\\:ss\\.ff}", stopwatch.Elapsed);
        }

        private void Game_Load(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            
        }
    }
}
