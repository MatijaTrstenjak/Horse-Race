namespace Primjenjena_projekt
{
    public partial class Form1 : Form
    {
        int x1 = 0;
        int x2 = 0;
        int balance = 1000;
        bool bet = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel2.BackgroundImage = Image.FromFile(@"konj1.png");
            panel1.BackgroundImage = Image.FromFile(@"konj1.png");

            x1 = panel1.Location.X;
            x2 = panel2.Location.X;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();  
            while ((panel1.Location.X < panel3.Width - 50) && (panel2.Location.X < panel4.Width - 50))
            {
                panel1.Location = new Point(panel1.Location.X + rnd.Next(10), panel1.Location.Y);
                panel2.Location = new Point(panel2.Location.X + rnd.Next(10), panel2.Location.Y);
                Thread.Sleep(5);
            }

            if(panel1.Location.X > panel2.Location.X)
            {
                //1.
                
                if(bet == true && radioButton1.Checked == true)
                {
                    balance += (int)numericUpDown1.Value * 2;
                }
                MessageBox.Show("Horse 1 wins!");

            }
            else
            {
                //2.
                
                if (bet == true && radioButton2.Checked == true)
                {
                    balance += (int)numericUpDown1.Value * 2;
                }
                MessageBox.Show("Horse 2 wins!");
            }
            labelBalance.Text = balance.ToString();
            buttonBet.Enabled = true;
            bet = false;

            panel1.Location = new Point(x1, panel1.Location.Y);
            panel2.Location = new Point(x2, panel2.Location.Y);
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            panel1.Location = new Point(x1, panel1.Location.Y);
            panel2.Location = new Point(x2, panel2.Location.Y);
            balance = 1000;
            bet = false;
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            numericUpDown1.Value = 10;
            labelBalance.Text = balance.ToString();
        }

        private void buttonBet_Click(object sender, EventArgs e)
        {
            if (balance >= (int)numericUpDown1.Value)
            {
                balance -= (int)numericUpDown1.Value;
                labelBalance.Text = "" + balance;
                bet = true;

                buttonBet.Enabled = false;
            }
            else
            {
                MessageBox.Show("Not enough money!");
            }
        }
    }
}