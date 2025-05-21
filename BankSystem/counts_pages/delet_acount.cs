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
using Guna.UI2.WinForms;

namespace BankSystem.counts_pages
{
    public partial class delet_acount : UserControl
    {
        static string strConn = ConfigurationManager.ConnectionStrings[1].ConnectionString;
        public delet_acount()
        {
            InitializeComponent();
        }

        private void delet_acount_Load(object sender, EventArgs e)
        {
            int x = (this.Width - guna2Panel1.Width) / 2;
            int y = (this.Height - guna2Panel1.Height) / 2;
            guna2Panel1.Location = new Point(x, y);
        }
        private void deleteAccount()
        {
            
            string sql = "DELETE FROM Employees WHERE AccountNumber = @AccountNumber";

            using (SqlConnection conn = new SqlConnection(strConn))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;

                
                string accountNumber = guna2TextBox2.Text;
                cmd.Parameters.AddWithValue("@AccountNumber", accountNumber);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("تم حذف الحساب بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("لم يتم العثور على الحساب.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("خطأ في قاعدة البيانات: " + ex.Message, "فشل الحذف", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            deleteAccount();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            searchAccount();
        }
        private void searchAccount()
        {

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand("serchAcount", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountNumber", guna2TextBox2.Text);

                try
                {
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read()) 
                        {
                            namefull.Text = rd[0].ToString();
                            numberPhone.Text = rd[1].ToString();
                            typeA.Text = rd[2].ToString();
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
