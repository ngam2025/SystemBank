using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.reports
{
    public partial class frmAccountsView : UserControl
    {
        public frmAccountsView()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

            SqlDataAdapter dt;
            DataTable result = new DataTable();
            string connectString = ConfigurationManager.ConnectionStrings[1].ConnectionString;

            SqlConnection conn = new SqlConnection(connectString);
            dt = new SqlDataAdapter("getAllCostemersWithAcountsInfo", conn);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.Fill(result);
            guna2DataGridView1.DataSource = result;
            guna2DataGridView1.AutoGenerateColumns = true;
            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            guna2DataGridView1.ScrollBars = ScrollBars.Both;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            mainInterface mainInterface = new mainInterface();  
            mainInterface.Show();
            this.Hide();
        }
    }
}
