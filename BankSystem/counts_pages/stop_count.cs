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

namespace BankSystem.counts_pages
{
    public partial class stop_count : UserControl
    {
        public stop_count()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
             string strConn = ConfigurationManager.ConnectionStrings[1].ConnectionString;
            SqlConnection conn=new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand("stopsarchAccount",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AccountNumber", accNumber.Text);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader()) {
                if (reader.Read()) { 
                    fullName.Text = reader.GetString(0);
                    phonNumber.Text = reader.GetString(1);
                    typeAcou.Text = reader.GetString(2);
                    blance.Text= reader.GetDecimal(3).ToString();
                    statusAc.Text = reader.GetString(4);

                    MessageBox.Show("Stoping the account is successfully", "successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("not fund the account.", "warimg", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
            }

            
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            mainInterface mainInterface = new mainInterface();
            mainInterface.Show();
            this.Hide();
        }

        private void stop_count_Load(object sender, EventArgs e)
        {
            int x=(this.Width- guna2Panel1.Width)/2;
            int y=(this.Height- guna2Panel1.Height)/2;
            guna2Panel1.Location = new Point(x, y);
        }
    }
}
