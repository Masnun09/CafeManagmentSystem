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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void password_box(object sender, EventArgs e)
        {

        }

        private void username_box(object sender, EventArgs e)
        {

        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            string username = username_b.Text.Trim();
            string password = password_b.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Missing information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "SELECT UserID, Role, Status FROM Users WHERE Username = @Username AND Password = @Password";

            using (SqlConnection con = new SqlConnection(DBHelper.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                try
                {
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string status = reader["Status"].ToString();
                            if (status == "Inactive")
                            {
                                MessageBox.Show("This account has been deactivated. Contact an admin.",
                                    "Account inactive", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            SessionManager.CurrentUserID = Convert.ToInt32(reader["UserID"]);
                            SessionManager.CurrentUsername = username;
                            SessionManager.CurrentRole = reader["Role"].ToString();

                            reader.Close();

                            if (SessionManager.CurrentRole == "Admin")
                            {
                                AdminForm adminForm = new AdminForm();
                                adminForm.Show();
                                this.Hide();
                            }
                            else if (SessionManager.CurrentRole == "Cashier")
                            {
                                CashierForm cashierForm = new CashierForm();
                                cashierForm.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Login failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Could not connect to the database:\n" + ex.Message,
                        "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void password_t_Click(object sender, EventArgs e)
        {

        }

        private void Login_form(object sender, EventArgs e)
        {

        }
    }
}
