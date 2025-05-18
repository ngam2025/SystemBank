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

namespace BankSystem
{
    public partial class gitFromAcount : Form
    {
        static string strConn = ConfigurationManager.ConnectionStrings[1].ConnectionString;
        public gitFromAcount()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            mainInterface mainInterface = new mainInterface();
            mainInterface.Show();
            this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

            DepositToAccount(AccountNum.Text,decimal.Parse(amount.Text),int .Parse(accId.Text));

        }
        public void DepositToAccount(string accountNum, decimal amount, int id)
        {
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand("DepositToAccount", conn);
            try
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountNumber", accountNum);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@AccountID", id);

                
                int i=cmd.ExecuteNonQuery();
                if (i > 0) {
                    MessageBox.Show("تم الايداع");
                }
                else
                {
                    MessageBox.Show("فشل الايداع");
                }
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        
        public void WithdrawFromAccount(string AccountNumber, decimal amount)
        {
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand("WithdrawFromAccount", conn);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountNumber", AccountNumber);
                cmd.Parameters.AddWithValue("@Amount", amount);
                
                conn.Open();
                int i=cmd.ExecuteNonQuery();
                }
                catch (SqlException ex) when (ex.Number == 50002)
                {
                    
                    MessageBox.Show("الرصيد غير كافٍ للسحب.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            
        }
        public void TransferFunds(string senderAccountNumber, string receiverAccountNumber, decimal amount,string des)
        {
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand("TransferFunds", conn);
            
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SenderAccountNumber", senderAccountNumber);
                cmd.Parameters.AddWithValue("@ReceiverAccountNumber", receiverAccountNumber);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@Description",des);
                try
                {
                conn.Open();
                int i=cmd.ExecuteNonQuery();
                

                }
                catch (SqlException ex) when (ex.Number == 50003)
                {
                    MessageBox.Show("الرصيد غير كافٍ في حساب المرسل.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void gitFromAcount_Load(object sender, EventArgs e)
        {
            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            WithdrawFromAccount(accountN.Text, decimal.Parse(amount1.Text));
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            mainInterface mainInterface = new mainInterface();
            mainInterface.Show();
            this.Hide();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {

            mainInterface mainInterface = new mainInterface();
            mainInterface.Show();
            this.Hide();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {

            mainInterface mainInterface = new mainInterface();
            mainInterface.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            TransferFunds(sendAcount.Text,rAccountN.Text,decimal.Parse(amount3.Text), description.Text);
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            mainInterface mainInterface = new mainInterface();
            mainInterface.Show();
            this.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            mainInterface mainInterface = new mainInterface();
            mainInterface.Show();
            this.Hide();
        }
    }
}
