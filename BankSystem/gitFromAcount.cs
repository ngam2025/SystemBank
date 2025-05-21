using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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

        private int ExtractID(string text)
        {
            if (text.Length != 10  || !text.StartsWith("3003"))
            {
                throw new ArgumentException(" the format of the number incouract");
            }
                string idString = text.Substring(4);
            if(!int.TryParse(idString, out int id))
            {
                throw new ArgumentException("error at the cast");
            }
            return id;
               
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
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand("DepositToAccounts", conn);
            try
            {
                string accountN = AccountNumd.Text;
                decimal amounts = decimal.Parse(amount.Text);
                int AccuID =ExtractID(accountN);
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountNumber", accountN);
                cmd.Parameters.AddWithValue("@Amount", amounts);
                cmd.Parameters.AddWithValue("@AccountID", AccuID);
                SqlParameter returnPra = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnPra.Direction=ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                if ((int)returnPra.Value == 1)
                {
                    MessageBox.Show("تمت عملية الايداع بنجاح.", "نجاع", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AccountNumd.Text = " ";
                    amount.Text = " ";
                }
                else
                {
                    MessageBox.Show("   الايوجد حساب بهذا الرقم.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand("WithdrawFromAccounts", conn);
            try
            {
                int accountID = ExtractID(accountN.Text);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountNumber", accountN.Text);
                cmd.Parameters.AddWithValue("@Amount", decimal.Parse( amount1.Text));
                cmd.Parameters.AddWithValue("@AccountID", accountID);
                SqlParameter returnPra = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnPra.Direction=ParameterDirection.ReturnValue;
                conn.Open();
                cmd.ExecuteNonQuery();
                if ((int)returnPra.Value == 2)
                {
                    MessageBox.Show("تمت عملية السحب بنجاح.", "نجاع", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    accountN.Text = " ";
                    amount1.Text = " ";
                }else if ((int)returnPra.Value ==0)
                {
                    MessageBox.Show("   الايوجد حساب بهذا الرقم.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("الرصيد غير كافٍ للسحب.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show("error" + ex.Message);
            }
            finally
            {
                conn.Close();
            }

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

            string senAccNum=sendAcount.Text;
            int idSenA = ExtractID(senAccNum);
            string rAccN=rAccountN.Text ;
            int idResA=ExtractID(rAccN);
            decimal blance=decimal.Parse(amount3.Text);
            string dec=description.Text;
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand("TransferFund", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SenderAccountNumber", senAccNum);
            cmd.Parameters.AddWithValue("@ReceiverAccountNumber", rAccN);
            cmd.Parameters.AddWithValue("@Amount", blance);
            cmd.Parameters.AddWithValue("@Description", dec);
            cmd.Parameters.AddWithValue("@AccountID", idSenA);
            cmd.Parameters.AddWithValue("@AccountIDRes", idResA);


            SqlParameter returnPra = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);

            returnPra.Direction= ParameterDirection.ReturnValue;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                if ((int)returnPra.Value == 0)
                {
                    MessageBox.Show("تمت عملية التحويل بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    amount3.Text = " ";
                    sendAcount.Text = " ";
                    rAccountN.Text = " ";
                    description.Text = " ";
                }
                else if((int)returnPra.Value == 1)
                {
                    MessageBox.Show("الرصيد غير كافٍ في حساب المرسل.", " خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else if((int)returnPra.Value == 2)
                {
                    MessageBox.Show("حساب المرسل غير موجود.", "خطأ في المرسل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("حساب المستلم غير موجود.", "خطأ في المستلم", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(" error" + ex);
            }
            finally
            {
                conn.Close();
            }

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
