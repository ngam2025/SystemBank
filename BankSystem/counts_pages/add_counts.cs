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

namespace BankSystem.counts_pages
{
    public partial class add_counts : UserControl
    {
        private byte[] fileCardImage;
        private byte[] filePhoto;
        public add_counts()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e) => addnewAccount();

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox4_SelectedIndexChanged_1(object sender, EventArgs e)
        {
           
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void add_counts_Load(object sender, EventArgs e)
        {
            guna2Panel1.Top = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                IDCardimage.Image = new Bitmap(open.FileName);

                fileCardImage = File.ReadAllBytes(open.FileName);


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {

                phot.Image = new Bitmap(open.FileName);

                filePhoto = File.ReadAllBytes(open.FileName);

            }
        }
        private void addnewAccount()
        {
            if (string.IsNullOrEmpty(FirstName.Text) || string.IsNullOrEmpty(IDcard.Text) ||
                string.IsNullOrEmpty(phoneNamber.Text) || string.IsNullOrEmpty(AccountType.Text) ||
                string.IsNullOrEmpty(Blance.Text))
            {
                MessageBox.Show("الرجاء ملء جميع الحقول المطلوبة");
                return;
            }

            string strConn = ConfigurationManager.ConnectionStrings[1].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                
                SqlCommand cmd = new SqlCommand("createCustomerWithAccount", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                
                cmd.Parameters.AddWithValue("@FullName", FirstName.Text + " " + LastName.Text);
                cmd.Parameters.AddWithValue("@IDcard", IDcard.Text);
                cmd.Parameters.AddWithValue("@Phone", phoneNamber.Text);
                cmd.Parameters.AddWithValue("@IDCardImage", fileCardImage);
                cmd.Parameters.AddWithValue("@Photo", filePhoto);
                cmd.Parameters.AddWithValue("@AccountType", AccountType.Text);
                cmd.Parameters.AddWithValue("@Balance", decimal.Parse(Blance.Text));
                cmd.Parameters.AddWithValue("@BranchID", int.Parse(BranchID.Text)); 

                try
                {
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result !=0)
                    {
                        MessageBox.Show("تمت إضافة الحساب بنجاح!");
                    }
                    else
                    {
                        MessageBox.Show("لم يتم إضافة الحساب. يرجى التحقق من البيانات.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally { conn.Close(); }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            mainInterface mainInterface = new mainInterface();
            mainInterface.Show();
            this.Hide();
        }
    }
    
}
