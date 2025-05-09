using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;
using BankSystem.counts_pages;

namespace BankSystem
{
    public partial class Counts : Form
    {
        public Counts()
        {
            InitializeComponent();

            add_counts add_Counts = new add_counts();
            addUserControl(add_Counts);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            stop_count stop_Count = new stop_count();
            addUserControl(stop_Count);
        }
        private void  addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelcontainer.Controls.Clear();
            panelcontainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            add_counts add_Counts = new add_counts();
            addUserControl(add_Counts);

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            delet_acount delet_Acount = new delet_acount();
            addUserControl(delet_Acount);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            edit_count edit_Counts = new edit_count();
            addUserControl(edit_Counts);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            show_count show_Count = new show_count();
            addUserControl(show_Count);
        }
    }
}
