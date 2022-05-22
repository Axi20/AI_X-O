using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace AIGames
{
    public partial class Classic : UserControl
    {
        Stopwatch stopwatch;
        public Classic()
        {
            InitializeComponent();
            sw.WriteLine("---------SCORE----------");
            sw.WriteLine("The game is started {0}", time);
            sw.WriteLine("Player 1 name: {0}", Player.SetValueForText1);
            sw.WriteLine("Player 2 name: {0}", Player.SetValueForText2);
        }

        bool turn = true;
        int turncount = 0;
        int winnerO = 0;
        int winnerX = 0;
        string time = DateTime.Now.ToString("HH:mm");

        StreamWriter sw = new StreamWriter("score_multi.txt", true);

        
        

        //Method to restart the game anytime
        public void restart()
        {
            emptyButtons();
            stopwatch.Restart();
            turncount = 0;
            
        }

        //Method to restart buttons
        public void emptyButtons()
        {
            
            button1.Text = "";
            button1.Enabled = true;

            button2.Text = "";
            button2.Enabled = true;

            button3.Text = "";
            button3.Enabled = true;

            button4.Text = "";
            button4.Enabled = true;

            button5.Text = "";
            button5.Enabled = true;

            button6.Text = "";
            button6.Enabled = true;

            button7.Text = "";
            button7.Enabled = true;

            button8.Text = "";
            button8.Enabled = true;

            button9.Text = "";
            button9.Enabled = true;
        }

        //Method to check if someone is win 
        public void check()
        {
            //variable for the winner
            bool there_is_a_winner = false;

            //The cases when somebody is win the match
            #region Cases;
            if ((button1.Text == button2.Text) && (button2.Text == button3.Text) && button1.Text != "" || (button4.Text == button5.Text) && (button5.Text == button6.Text) && button4.Text != "" ||
                 (button7.Text == button8.Text) && (button8.Text == button9.Text) && button7.Text != "" || (button1.Text == button4.Text) && (button4.Text == button7.Text) && button1.Text != "" ||
                 (button2.Text == button5.Text) && (button5.Text == button8.Text) && button2.Text != "" || (button3.Text == button6.Text) && (button6.Text == button9.Text) && button3.Text != "" ||
                 (button1.Text == button5.Text) && (button5.Text == button9.Text) && button1.Text != "" || (button3.Text == button5.Text) && (button5.Text == button7.Text) && button3.Text != "")
                there_is_a_winner = true;
            #endregion;

            if (there_is_a_winner)
            {
                string winnerSymbol = "";

                if (turn)
                {
                    winnerSymbol = "O";
                }
                else
                {
                    winnerSymbol = "X";
                }

                    if (turncount % 2 == 0)
                    {
                        winnerO++;
                    sw.WriteLine("---{0} won the match---", label3.Text);
                    sw.WriteLine("----Elapsed time {0} -----", label7.Text);
                    label5.Text = "Wins - " + winnerO.ToString();
                        if (MessageBox.Show("The winner is " + label3.Text, "Winner") == DialogResult.OK)
                        {
                            //If user clicked OK then the game will be restart 
                            restart();
                        }
                        
                    }
                    else if (turncount % 2 == 1)
                    {
                        winnerX++;
                    sw.WriteLine("---{0} won the match---", label4.Text);
                    sw.WriteLine("----Elapsed time {0} -----", label7.Text);
                    label6.Text = "Wins - " + winnerX.ToString();
                        if (MessageBox.Show("The winner is " + label4.Text, "Winner") == DialogResult.OK)
                        {
                            //If user clicked OK then the game will be restart 
                            restart();
                        }
                    
                    }
            }
            //If the rounds are runs out and nobody wins then print it's a draw
            else if (turncount == 9)
            {
                sw.WriteLine("---It's a draw---");
                sw.WriteLine("----Elapsed time {0} -----", label7.Text);
                if (MessageBox.Show("It's a draw! Click OK to restart the game", "Confirm") == DialogResult.OK)
                {
                    //If user clicked OK then the game will be restart 
                    restart();
                }
            }
        }

        //When the user click in a button every round it will be checked if anybody wins 
        public void click()
        {
            turn = !turn;
            turncount++;
            check();
        }



        #region Button methods;

        //Menu button
        private void button12_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Controls.Add(menu);
            panel1.Hide();
            stopwatch.Stop();

        }

        //Pause button
        private void button11_Click(object sender, EventArgs e)
        {
            stopwatch.Stop();
            if (MessageBox.Show("Game is paused, click OK to play", "Pause", MessageBoxButtons.OK) == DialogResult.OK)
            {
                stopwatch.Start();
            }

        }

        //Restart button - call the restart method
        private void button10_Click(object sender, EventArgs e)
        {
            restart();
            winnerX = 0;
            winnerO = 0;
            label5.Text = "Wins - " + winnerO.ToString();
            label6.Text = "Wins - " + winnerX.ToString();
            sw.WriteLine("--RESTART button clicked--");
            sw.WriteLine();
            //.AutoFlush = true;
            sw.Close();

        }
        #endregion;

        private void Classic_Load(object sender, EventArgs e)
        {      
            label3.Text = Player.SetValueForText1;
            label4.Text = Player.SetValueForText2;
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        //Game area starts here
        #region GameArea;
        private void button1_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn == true)
                b.Text = "X";
            else b.Text = "O";
            b.Enabled = false;
            click();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn == true)
                b.Text = "X";
            else b.Text = "O";
            b.Enabled = false;
            click();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn == true)
                b.Text = "X";
            else b.Text = "O";
            b.Enabled = false;
            click();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn == true)
                b.Text = "X";
            else b.Text = "O";
            b.Enabled = false;
            click();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn == true)
                b.Text = "X";
            else b.Text = "O";
            b.Enabled = false;
            click();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn == true)
                b.Text = "X";
            else b.Text = "O";
            b.Enabled = false;
            click();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn == true)
                b.Text = "X";
            else b.Text = "O";
            b.Enabled = false;
            click();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn == true)
                b.Text = "X";
            else b.Text = "O";
            b.Enabled = false;
            click();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn == true)
                b.Text = "X";
            else b.Text = "O";
            b.Enabled = false;
            click();
        }


        #endregion;

        private void timer1_Tick(object sender, EventArgs e)
        {  
            label7.Text = "Time: " + string.Format("{0:hh\\:mm\\:ss\\.ff}", stopwatch.Elapsed);
        }

       
    }
}
