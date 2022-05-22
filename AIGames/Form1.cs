namespace AIGames
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
           
        }

        //Start button
        private void button1_Click(object sender, EventArgs e)
        {
            GameMode gameMode = new GameMode();
            this.Controls.Add(gameMode);
            panel1.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}