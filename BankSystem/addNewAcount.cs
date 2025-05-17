using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem
{
    public partial class addNewAcount : Form
    {
        static string strConn = ConfigurationManager.ConnectionStrings[1].ConnectionString;
        static SqlConnection conn = new SqlConnection(strConn);
        public addNewAcount()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            transaction transaction = new transaction();
            transaction.Show();
            this.Hide();
        }

        private void addNewAcount_Load(object sender, EventArgs e)
        {

        }
        private void addnewEmploy()
        {
            int branchId = 1;


            SqlCommand cmd = new SqlCommand("InsertData", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", guna2TextBox1.Text);
            cmd.Parameters.AddWithValue("@password", guna2TextBox2.Text);
            cmd.Parameters.AddWithValue("@role", guna2TextBox4.Text);
            cmd.Parameters.AddWithValue("@salary",decimal.Parse( guna2TextBox3.Text));
            cmd.Parameters.AddWithValue("@branchID", branchId);

            


            try
            {
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("تمت إضافة الحساب بنجاح!");
                    clear();
                }
                else
                {
                    MessageBox.Show("لم يتم إضافة الحساب. يرجى التحقق من البيانات.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }
        private void clear()
            {
            guna2TextBox1.Text="";
            guna2TextBox2.Text = "";
            guna2TextBox4.Text = "";
            guna2TextBox3.Text = "";
            }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e) => addnewEmploy();
    }
}
