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

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            DepositToAccount(AccountNum.Text,decimal.Parse(amount.Text),int .Parse(accId.Text));

        }
        public void DepositToAccount(string accountNum, decimal amount,int id)
        {
            
            using (var conn = new SqlConnection(strConn))
            using (var cmd = new SqlCommand("DepositToAccount", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountNumber", accountNum);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@AccountID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void WithdrawFromAccount(string AccountNumber, decimal amount)
        {
            using (var conn = new SqlConnection(strConn))
            using (var cmd = new SqlCommand("WithdrawFromAccount", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountNumber", AccountNumber);
                cmd.Parameters.AddWithValue("@Amount", amount);

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex) when (ex.Number == 50002)
                {
                    
                    MessageBox.Show("الرصيد غير كافٍ للسحب.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void TransferFunds(string senderAccountNumber, string receiverAccountNumber, decimal amount,string des)
        {
            using (var conn = new SqlConnection(strConn))
            using (var cmd = new SqlCommand("TransferFunds", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SenderAccountNumber", senderAccountNumber);
                cmd.Parameters.AddWithValue("@ReceiverAccountNumber", receiverAccountNumber);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@Description",des);

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex) when (ex.Number == 50003)
                {
                    MessageBox.Show("الرصيد غير كافٍ في حساب المرسل.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
    }
}
