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

        }
        private void displayEmployees()
        {

            string connectString = ConfigurationManager.ConnectionStrings[1].ConnectionString;
            DataTable result = new DataTable();
            //string sql = "select *from Employees;";
            SqlConnection conn = new SqlConnection(connectString);
            SqlDataAdapter dt = new SqlDataAdapter("getAllEmployeesBranch", conn);
            dt.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt.Fill(result);
            guna2DataGridView1.DataSource = result;
            guna2DataGridView1.AutoGenerateColumns = true;
            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string[] headers = new[]
            {
                    "المعرف",
                    "اسم المستخدم",
                    "الاسم الكامل",
                    "تاريخ التوظيف",
                    "الراتب",
                    "اسم الفرع"

            };

            for (int i = 0; i < headers.Length && i < guna2DataGridView1.Columns.Count; i++)
            {
                guna2DataGridView1.Columns[i].HeaderText = headers[i];
            }
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
    }
}
