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
    public partial class transaction : Form
    {
        static DataGridViewRow row;
        static SqlDataAdapter dt;
        static DataTable result = new DataTable();
        static string connectString = ConfigurationManager.ConnectionStrings[1].ConnectionString;
        
        public transaction()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void transaction_Load(object sender, EventArgs e)
        {
            displayEmployees();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0||e.RowIndex>= guna2DataGridView1.Rows.Count)
            {
                return;
            }
            row= guna2DataGridView1.Rows[e.RowIndex];
            var id = row.Cells[0].Value;
            var username= row.Cells[1].Value;
            var fullName= row.Cells[2].Value;   
            var herDate= row.Cells[3].Value;
            var salary= row.Cells[4].Value;
            var branchName= row.Cells[5].Value;
            

        }
        private void deleteEmployee(int id)
        {
            
            
            string sql = "delete from Employees" +
                "where EmployeeID=@id";
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@EmployeeID",id);
                    int i=cmd.ExecuteNonQuery();
                    if (i > 0) {
                        MessageBox.Show("تم الحذف بنجاح");
                    }
                    else
                    {
                        MessageBox.Show("فشل في الحذف");
                    }

                }

        }   }
        private void displayEmployees()
        {

            
            
            //string sql = "select *from Employees;";
            SqlConnection conn = new SqlConnection(connectString);
             dt = new SqlDataAdapter("getAllEmployeesBranch", conn);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.Fill(result);
            guna2DataGridView1.DataSource = result;
            guna2DataGridView1.AutoGenerateColumns = true;
            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            guna2DataGridView1.ScrollBars = ScrollBars.Both;

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            addNewAcount addNewAcount = new addNewAcount();
            addNewAcount.Show();
            this.Hide();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            mainInterface mainInterface = new mainInterface();
            mainInterface.Show();
            this.Hide();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
          
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                // تأكيد الحذف
                DialogResult results = MessageBox.Show("هل أنت متأكد من حذف هذا الصف؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (results == DialogResult.Yes)
                {
                    
                    DataRowView drv = (DataRowView)guna2DataGridView1.SelectedRows[0].DataBoundItem;
                    DataRow row = drv.Row;
                    int id = (int)row[0];
                    
                    deleteEmployee(id);
                    
                    row.Delete();




                    displayEmployees();
                    MessageBox.Show("تم حذف الصف بنجاح.");
                }
            }
            else
            {
                MessageBox.Show("الرجاء تحديد صف للحذف.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        


        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }
    }
}
