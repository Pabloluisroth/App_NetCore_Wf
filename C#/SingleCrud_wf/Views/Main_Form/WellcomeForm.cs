using System;
using System.Windows.Forms;

namespace SingleCrud
{
    public partial class WellcomeForm : Form
    {
        public WellcomeForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void LoadingTimer_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;
            if (panel2.Width >= 1099)
            {
                LoadingTimer.Stop();
                FormInitiate f1 = new FormInitiate();
                f1.Show();
                this.Hide();
            }
        }

        private void WellcomeForm_Load(object sender, EventArgs e)
        {

        }
    }
}