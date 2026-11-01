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
    public partial class AdminAddProduct : UserControl
    {
        

        public AdminAddProduct()
        {
            InitializeComponent();
        }

        private void AdminAddProduct_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            string query = "SELECT ProductID, ProductName, Category, Price, Stock, Availability FROM Products ORDER BY ProductID";

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
                    MessageBox.Show("Could not load products:\n" + ex.Message, "Database error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            textBox1.Text = row.Cells["ProductID"].Value.ToString();
            textBox2.Text = row.Cells["ProductName"].Value.ToString();
            comboBox1.Text = row.Cells["Category"].Value.ToString();
            textBox3.Text = row.Cells["Price"].Value.ToString();
            textBox4.Text = row.Cells["Stock"].Value.ToString();
            comboBox2.Text = row.Cells["Availability"].Value.ToString();
        }

        private bool ValidateInputs(out decimal price, out int stock)
        {
            price = 0;
            stock = 0;

            if (string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(comboBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(comboBox2.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Missing information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(textBox3.Text, out price) || price < 0)
            {
                MessageBox.Show("Please enter a valid price.", "Invalid price",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(textBox4.Text, out stock) || stock < 0)
            {
                MessageBox.Show("Please enter a valid stock quantity.", "Invalid stock",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void AdminAddProduct_AddBtn_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out decimal price, out int stock)) return;

            string query = @"INSERT INTO Products (ProductName, Category, Price, Stock, Availability)
                              VALUES (@Name, @Category, @Price, @Stock, @Availability)";

            using (SqlConnection con = new SqlConnection(DBHelper.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Name", textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@Category", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Stock", stock);
                cmd.Parameters.AddWithValue("@Availability", comboBox2.Text);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product added successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProducts();
                    AdminAddProduct_ClearBtn(sender, e);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Could not add product:\n" + ex.Message, "Database error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AdminAddProduct_UpdateBtn(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Select a product from the list first.", "No product selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs(out decimal price, out int stock)) return;

            string query = @"UPDATE Products
                              SET ProductName = @Name, Category = @Category, Price = @Price,
                                  Stock = @Stock, Availability = @Availability
                              WHERE ProductID = @ProductID";

            using (SqlConnection con = new SqlConnection(DBHelper.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Name", textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@Category", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Stock", stock);
                cmd.Parameters.AddWithValue("@Availability", comboBox2.Text);
                cmd.Parameters.AddWithValue("@ProductID", int.Parse(textBox1.Text));

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product updated successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProducts();
                    AdminAddProduct_ClearBtn(sender, e);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Could not update product:\n" + ex.Message, "Database error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AdminAddProduct_DelBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Select a product from the list first.", "No product selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Delete \"{textBox2.Text}\"? This cannot be undone.",
                "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            string query = "DELETE FROM Products WHERE ProductID = @ProductID";

            using (SqlConnection con = new SqlConnection(DBHelper.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ProductID", int.Parse(textBox1.Text));

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product deleted.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProducts();
                    AdminAddProduct_ClearBtn(sender, e);
                }
                catch (SqlException ex)
                {
                    
                    MessageBox.Show("Could not delete product (it may already be used in an order):\n" + ex.Message,
                        "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AdminAddProduct_ClearBtn(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
            textBox3.Clear();
            textBox4.Clear();
            comboBox2.SelectedIndex = -1;
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label3_Click_1(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
    }
}
