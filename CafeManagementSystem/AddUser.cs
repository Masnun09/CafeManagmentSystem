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
    public partial class AddUser : UserControl
    {
        private int? _selectedUserId = null;

        public AddUser()
        {
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            string query = "SELECT UserID, Username, Role, Status FROM Users ORDER BY UserID";

            using (SqlConnection con = new SqlConnection(DBHelper.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable table = new DataTable();
                try
                {
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Could not load users:\n" + ex.Message, "Database error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            _selectedUserId = Convert.ToInt32(row.Cells["UserID"].Value);
            textBox1.Text = row.Cells["Username"].Value.ToString();
            comboBox1.Text = row.Cells["Role"].Value.ToString();
            comboBox2.Text = row.Cells["Status"].Value.ToString();
            textBox2.Text = string.Empty; 
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(comboBox1.Text) ||
                string.IsNullOrWhiteSpace(comboBox2.Text))
            {
                MessageBox.Show("Please fill in username, role, and status.", "Missing information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void AddUser_AddBtn_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter a password for the new user.", "Missing password",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"INSERT INTO Users (Username, Password, Role, Status)
                              VALUES (@Username, @Password, @Role, @Status)";

            using (SqlConnection con = new SqlConnection(DBHelper.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Username", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", textBox2.Text); 
                cmd.Parameters.AddWithValue("@Role", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Status", comboBox2.Text);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User added successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                    AddUser_ClearBtn_Click(sender, e);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Could not add user (username may already exist):\n" + ex.Message,
                        "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddUser_UpdateBtn_Click(object sender, EventArgs e)
        {
            if (_selectedUserId == null)
            {
                MessageBox.Show("Select a user from the list first.", "No user selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs()) return;

            string query = string.IsNullOrWhiteSpace(textBox2.Text)
                ? @"UPDATE Users SET Username = @Username, Role = @Role, Status = @Status WHERE UserID = @UserID"
                : @"UPDATE Users SET Username = @Username, Password = @Password, Role = @Role, Status = @Status WHERE UserID = @UserID";

            using (SqlConnection con = new SqlConnection(DBHelper.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Username", textBox1.Text.Trim());
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                    cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                cmd.Parameters.AddWithValue("@Role", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Status", comboBox2.Text);
                cmd.Parameters.AddWithValue("@UserID", _selectedUserId.Value);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User updated successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                    AddUser_ClearBtn_Click(sender, e);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Could not update user:\n" + ex.Message, "Database error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddUser_DelBtn_Click(object sender, EventArgs e)
        {
            if (_selectedUserId == null)
            {
                MessageBox.Show("Select a user from the list first.", "No user selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedUserId == SessionManager.CurrentUserID)
            {
                MessageBox.Show("You can't delete the account you're currently logged in as.",
                    "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Delete user \"{textBox1.Text}\"? This cannot be undone.",
                "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            string query = "DELETE FROM Users WHERE UserID = @UserID";

            using (SqlConnection con = new SqlConnection(DBHelper.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@UserID", _selectedUserId.Value);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User deleted.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                    AddUser_ClearBtn_Click(sender, e);
                }
                catch (SqlException ex)
                {
                    
                    MessageBox.Show("Could not delete user (they may have existing orders on record):\n" + ex.Message,
                        "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddUser_ClearBtn_Click(object sender, EventArgs e)
        {
            _selectedUserId = null;
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }

        private void AdminAddProduct_DelBtn_Click(object sender, EventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
