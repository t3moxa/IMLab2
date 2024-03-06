namespace IMLab2
{
    public partial class Form1 : Form
    {
        double creditRate, wupiupiRate, k = 0.1;
        DateOnly date = DateOnly.FromDateTime(DateTime.Now);
        int y = 1;
        bool started = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(CreditLabel, "Основная валюта Галактики со времен Галактической Республики.");
            toolTip2.SetToolTip(WupiupiLabel, "Хаттская разменная монета, ходившая на территориях Внешнего Кольца Галактики до имперского периода.");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            creditRate = ChangeRate(creditRate);
            wupiupiRate = ChangeRate(wupiupiRate);
            //date = date.AddDays(1);
            y++;
            chart1.Series[0].Points.AddXY(y, creditRate);
            chart1.Series[1].Points.AddXY(y, wupiupiRate);
        }
        private double ChangeRate(double rate)
        {
            Random rand = new Random();
            return rate * (1 + k * (rand.NextDouble() - 0.5));
        }
        private void Init()
        {
            creditRate = Convert.ToDouble(CreditBox.Text);
            wupiupiRate = Convert.ToDouble(WupiupiBox.Text);
            chart1.Series[0].Points.AddXY(y, creditRate);
            chart1.Series[1].Points.AddXY(y, wupiupiRate);
            started = true;
        }
        private void StartStopButton_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
            }
            else
            {
                if (!started)
                    Init();
                timer1.Start();
            }
        }


    }
}
