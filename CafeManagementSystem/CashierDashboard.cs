using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace CafeManagementSystem
{
    public partial class CashierDashboard : UserControl
    {
        
        private const decimal DAILY_GOAL = 200.00m;

        public CashierDashboard()
        {
            InitializeComponent();
        }

        private void CashierDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {SessionManager.CurrentUsername}";
            LoadStats();
        }

        private void LoadStats()
        {
            using (SqlConnection con = new SqlConnection(DBHelper.ConnectionString))
            {
                try
                {
                    con.Open();

                    
                    string todaySalesQuery = @"SELECT ISNULL(SUM(TotalAmount), 0) FROM Orders
                                                WHERE CashierID = @CashierID
                                                  AND CAST(CreatedOn AS DATE) = CAST(GETDATE() AS DATE)";
                    decimal todaySales = ExecuteScalarDecimal(con, todaySalesQuery);
                    lblSalesValue.Text = "$" + todaySales.ToString("0.00");

                    
                    decimal progressPercent = DAILY_GOAL > 0
                        ? Math.Min((todaySales / DAILY_GOAL) * 100m, 100m)
                        : 0;
                    lblGoalValue.Text = $"${todaySales:0.00} / ${DAILY_GOAL:0.00}";
                    progressGoal.Value = (int)progressPercent;

                    
                    string totalIncomeQuery = @"SELECT ISNULL(SUM(TotalAmount), 0) FROM Orders
                                                 WHERE CashierID = @CashierID";
                    decimal totalIncome = ExecuteScalarDecimal(con, totalIncomeQuery, "@CashierID");
                    lblIncomeValue.Text = "$" + totalIncome.ToString("0.00");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Could not load your dashboard statistics:\n" + ex.Message,
                        "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private decimal ExecuteScalarDecimal(SqlConnection con, string query, string paramName = "@CashierID")
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue(paramName, SessionManager.CurrentUserID);
                object result = cmd.ExecuteScalar();
                return Convert.ToDecimal(result);
            }
        }

        private void progressGoal_Click(object sender, EventArgs e)
        {

        }

        private void cardSales_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
