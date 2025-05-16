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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace BankSystem.counts_pages
{
    public partial class show_count : UserControl
    {
        public show_count()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void displayEmployees()
        {

            string connectString = ConfigurationManager.ConnectionStrings[1].ConnectionString;


            SqlConnection conn = new SqlConnection(connectString);
            using (SqlCommand cmd = new SqlCommand("getCustomerWithAccountInfo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountNumber",guna2TextBox2.Text);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        name.Text = reader[1].ToString();
                        Phone.Text=reader[2].ToString();
                        IDCardimage.Text = reader[4].ToString();
                        AccountNamber.Text=reader[5].ToString();
                        AccountType.Text=reader[6].ToString();
                        Blance.Text=reader[7].ToString();
                        opendedDate.Text=reader[8].ToString();

                    }
                    else
                    {
                        MessageBox.Show("not found the acount");
                    }

                }
            }
        }

        private void show_count_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            displayEmployees();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
