using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace CafeManagementSystem
{
    public partial class AdminDashboard : UserControl
    {


        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            LoadStats();
        }

        private void LoadStats()
        {
            using (SqlConnection con = new SqlConnection(DBHelper.ConnectionString))
            {
                try
                {
                    con.Open();

                    label3.Text = ExecuteScalarQuery(con, "SELECT COUNT(*) FROM Orders").ToString();

                    object todayIncome = ExecuteScalarQuery(con,
                        "SELECT ISNULL(SUM(TotalAmount), 0) FROM Orders WHERE CAST(CreatedOn AS DATE) = CAST(GETDATE() AS DATE)");
                    label5.Text = "$" + Convert.ToDecimal(todayIncome).ToString("0.00");

                    object totalIncome = ExecuteScalarQuery(con, "SELECT ISNULL(SUM(TotalAmount), 0) FROM Orders");
                    label7.Text = "$" + Convert.ToDecimal(totalIncome).ToString("0.00");

                    label9.Text = ExecuteScalarQuery(con, "SELECT COUNT(*) FROM Users WHERE Role = 'Cashier'").ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Could not load dashboard statistics:\n" + ex.Message, "Database error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private object ExecuteScalarQuery(SqlConnection con, string query)
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                return cmd.ExecuteScalar();
            }
        }
    }
}
