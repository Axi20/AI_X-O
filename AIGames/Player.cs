using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIGames
{
    public partial class Player : UserControl
    {
        string player1name = "";
        string player2name = "";

        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";
        public Player()
        {
            InitializeComponent();
        }

        //Next button
        private void button1_Click(object sender, EventArgs e)
        {
            DifficultyLevel level = new DifficultyLevel();
            this.Controls.Add(level);
            panel1.Hide();

            SetValueForText1 = textBox1.Text;
            SetValueForText2 = textBox2.Text;
        }

        private void Player_Load(object sender, EventArgs e)
        {
            player1name = textBox1.Text;
            player2name = textBox2.Text;
        }
    }
}
