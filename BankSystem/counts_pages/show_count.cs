using System;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

using System.Windows.Forms;


namespace BankSystem.counts_pages
{
    public partial class show_count : UserControl
    {
        public show_count()
        {
            InitializeComponent();
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
                        byte[] img = (byte[])reader[3];
                        using (MemoryStream sm = new MemoryStream(img))
                        {
                            Photo.Image = Image.FromStream(sm);
                        }
                        IDCard.Text = reader[4].ToString();
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
            int x = (this.Width - guna2Panel1.Width) / 2;
            int y = (this.Height - guna2Panel1.Height) / 2;
            guna2Panel1.Location = new Point(x, y);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            displayEmployees();
        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            mainInterface mainInterface = new mainInterface();
            mainInterface.Show();
            this.Hide();
        }
    }
}
