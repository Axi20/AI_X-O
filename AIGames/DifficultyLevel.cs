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
    public partial class DifficultyLevel : UserControl
    {
        public DifficultyLevel()
        {
            InitializeComponent();
        }

        //Classic button
        private void button1_Click(object sender, EventArgs e)
        {
            Classic classic = new Classic();
            this.Controls.Add(classic);
            panel1.Hide();
        }
    }
}
