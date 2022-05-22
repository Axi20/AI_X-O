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
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
        }

        //Start button
        private void button1_Click(object sender, EventArgs e)
        {
            GameMode mode = new GameMode();
            this.Controls.Add(mode);
            panel1.Hide();
        }

        //Exit button
        private void button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure to want to exit?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //Score button
        private void button2_Click(object sender, EventArgs e)
        {
            Score score = new Score();
            this.Controls.Add(score);
            panel1.Hide();
        }
    }
}
