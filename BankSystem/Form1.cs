using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace BankSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            String strConn = ConfigurationManager.ConnectionStrings[1].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COUNT(*) FROM Employees WHERE username=@username AND Password =@password";
            cmd.Connection = sqlConn;

            try
            {
                string username = guna2TextBox1.Text;
                string password = guna2TextBox2.Text;


                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("Password", password);
                sqlConn.Open();
                int rsult = (int)cmd.ExecuteScalar();
                //error rsult > 0
                if (rsult > 0)
                {

                    mainInterface mainInterface = new mainInterface();
                    string usernameLo = ConfigurationManager.AppSettings["username"];
                    mainInterface.Show();
                    this.Hide();
                }
                else
                {


                    MessageBox.Show("اسم المستخدم او كلمة المرور  غير صحيحة...!!");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
            finally
            {
                sqlConn.Close();

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
