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
    public partial class GameMode : UserControl
    {
        public GameMode()
        {
            InitializeComponent();
        }

        //Singleplayer button
        private void button2_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            this.Controls.Add(game);
            panel1.Hide();
        }

        //Multiplayer button
        private void button1_Click(object sender, EventArgs e)
        {
            Player playerNames = new Player();
            this.Controls.Add(playerNames);
            panel1.Hide();

        }
    }
}
