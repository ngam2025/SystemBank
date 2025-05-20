using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BankSystem.reports;

namespace BankSystem
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            tabe1.Controls.Clear(); // تأكد أن "table" معرف مسبقاً كـ Panel أو TableLayoutPanel
            tabe1.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // مثال: عرض تقرير الحسابات عند الضغط على الزر
            frmBankBalance frmAccountsView = new frmBankBalance();
            addUserControl(frmAccountsView);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }
    }
}
