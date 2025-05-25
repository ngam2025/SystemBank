using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.Xml.Linq;

namespace BankSystem.reports
{
    public partial class frmBankBalance : UserControl
    {
        public frmBankBalance()
        {
            InitializeComponent();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmBankBalance_Load(object sender, EventArgs e)
        {
            string connectString = ConfigurationManager.ConnectionStrings[1].ConnectionString;

            string sql= "SELECT SUM(Balance) AS TotalBalanc FROM Accounts";
            SqlConnection conn = new SqlConnection(connectString);
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                
                conn.Open();
                object result = cmd.ExecuteScalar();
                decimal to=0m;
                 to = Convert.ToDecimal(result);
                to= Convert.ToDecimal(to); 
                label1.Text = to.ToString();    




            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            mainInterface mainInterface = new mainInterface();
            mainInterface.Show();
            this.Hide();
        }
    }

}
