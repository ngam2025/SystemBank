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
    public partial class edit_count : UserControl
    {
        static string strConn = ConfigurationManager.ConnectionStrings[1].ConnectionString;
        public edit_count()
        {
            InitializeComponent();
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void edit_count_Load(object sender, EventArgs e)
        {
            int x = (this.Width - guna2Panel1.Width) / 2;
            int y = (this.Height - guna2Panel1.Height) / 2;
            guna2Panel1.Location = new Point(x, y);
        }
        private void updateAccpunt()
        {
            SqlConnection conn = new SqlConnection(strConn);
            var cmd = new SqlCommand("editeAccount", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AccountNumber", guna2TextBox2.Text);
            
            cmd.Parameters.AddWithValue("@newAccountType", guna2ComboBox2.Text);
            cmd.Parameters.AddWithValue("@newPhone", guna2TextBox5.Text);



            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم تعديل بيانات الحساب بنجاح.");
                guna2TextBox2.Text = " ";
                nameFull.Text = " ";    
                numberPhone.Text = " ";

            }
            catch (SqlException ex)
            {
                MessageBox.Show("خطأ: " + ex.Message, "فشل التعديل", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            finally { conn.Close(); }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            updateAccpunt();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            searchAccount();
        }
        private void searchAccount()
        {

            
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                var cmd = new SqlCommand("serchAcount", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountNumber", guna2TextBox2.Text);

                try
                {
                    conn.Open();
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            nameFull.Text = rd[0].ToString();
                            numberPhone.Text = rd[1].ToString();
                            
                        }
                        else
                        {
                            MessageBox.Show("لا يوجد حساب بهذا الرقم", "نتيجة البحث",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("خطأ في البحث: " + ex.Message, "خطأ",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
      
    }
}
