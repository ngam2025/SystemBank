using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem
{
    public partial class mainInterface : Form
    {
        public mainInterface()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
           Counts counts = new Counts();
            counts.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            gitFromAcount gitFromAcount = new gitFromAcount();
            gitFromAcount.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            transaction transaction = new transaction();
            transaction.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (SessionManager.IsAdmin())
            {
                Reports rep = new Reports();
                rep.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You don`t have the authority !");
            }
        }
    }
}
