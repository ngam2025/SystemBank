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
            
        }
        private void deleteAcount()
        {

            string sql = "delete from Employees where AccountNumber=" + guna2TextBox2.Text;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                using (var cmd = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i == 0)
                        {
                            MessageBox.Show("تم حذف الحساب بنجاح.");
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("خطأ: " + ex.Message, "فشل الحذف", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            deleteAcount();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            searchAccount();
        }
        private void searchAccount()
        {
            
            label4.Text = "";
            label2.Text = "";
            label7.Text = "";

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
                            label4.Text = rd[0].ToString();
                            label2.Text = rd[1].ToString();
                            label7.Text = rd[2].ToString();
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
