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
    public partial class CashierBill : UserControl
    {

        private DataTable _cart;
        private decimal _selectedProductPrice = 0;
        private int _selectedProductId = 0;
        private string _selectedProductName = "";

        public CashierBill()
        {
            InitializeComponent();
        }

        private void CashierBill_Load(object sender, EventArgs e)
        {
            LoadMenu();
            InitializeCart();
            comboBox1.SelectedIndex = 0;
            numericUpDown1.Minimum = 1;
            numericUpDown1.Value = 1;
        }

        private void LoadMenu()
        {
            string query = @"SELECT ProductID, ProductName, Category, Price, Stock
                              FROM Products
                              WHERE Availability = 'Available' AND Stock > 0
                              ORDER BY Category, ProductName";

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
                    MessageBox.Show("Could not load the menu:\n" + ex.Message, "Database error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InitializeCart()
        {
            _cart = new DataTable();
            _cart.Columns.Add("ProductID", typeof(int));
            _cart.Columns.Add("ProductName", typeof(string));
            _cart.Columns.Add("UnitPrice", typeof(decimal));
            _cart.Columns.Add("Quantity", typeof(int));
            _cart.Columns.Add("LineTotal", typeof(decimal));
            dataGridView2.DataSource = _cart;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            _selectedProductId = Convert.ToInt32(row.Cells["ProductID"].Value);
            _selectedProductName = row.Cells["ProductName"].Value.ToString();
            _selectedProductPrice = Convert.ToDecimal(row.Cells["Price"].Value);

            textBox1.Text = _selectedProductId.ToString();
            label7.Text = _selectedProductName;
            label8.Text = _selectedProductPrice.ToString("0.00");
        }

        private void AdminAddProduct_AddBtn_Click(object sender, EventArgs e)
        {
            if (_selectedProductId == 0)
            {
                MessageBox.Show("Click a menu item first to select it.", "No item selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantity = (int)numericUpDown1.Value;
            if (quantity <= 0)
            {
                MessageBox.Show("Quantity must be at least 1.", "Invalid quantity",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRow[] existing = _cart.Select($"ProductID = {_selectedProductId}");
            if (existing.Length > 0)
            {
                DataRow row = existing[0];
                int newQty = Convert.ToInt32(row["Quantity"]) + quantity;
                row["Quantity"] = newQty;
                row["LineTotal"] = newQty * _selectedProductPrice;
            }
            else
            {
                DataRow row = _cart.NewRow();
                row["ProductID"] = _selectedProductId;
                row["ProductName"] = _selectedProductName;
                row["UnitPrice"] = _selectedProductPrice;
                row["Quantity"] = quantity;
                row["LineTotal"] = quantity * _selectedProductPrice;
                _cart.Rows.Add(row);
            }

            RecalculateTotal();
            numericUpDown1.Value = 1;
        }

        private void REMOVE_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null || dataGridView2.CurrentRow.Index < 0)
            {
                MessageBox.Show("Select a cart item to remove first.", "No item selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView rowView = dataGridView2.CurrentRow.DataBoundItem as DataRowView;
            rowView?.Row.Delete();

            RecalculateTotal();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InitializeCart();
            textBox2.Clear();
            label11.Text = "0.00";
            label12.Text = "0.00";
        }

        private void RecalculateTotal()
        {
            decimal total = 0;
            foreach (DataRow row in _cart.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                    total += Convert.ToDecimal(row["LineTotal"]);
            }
            label11.Text = total.ToString("0.00");
            RecalculateChange();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            RecalculateChange();
        }

        private void RecalculateChange()
        {
            decimal.TryParse(label11.Text, out decimal total);
            decimal.TryParse(textBox2.Text, out decimal tendered);
            decimal change = tendered - total;
            label12.Text = (change >= 0 ? change : 0).ToString("0.00");
        }

        private void PAY_Click(object sender, EventArgs e)
        {
            if (_cart.Rows.Count == 0)
            {
                MessageBox.Show("The cart is empty.", "Nothing to pay for",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal.TryParse(label11.Text, out decimal total);
            decimal.TryParse(textBox2.Text, out decimal tendered);

            if (tendered < total)
            {
                MessageBox.Show("Amount tendered is less than the total due.", "Insufficient payment",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal change = tendered - total;
            string orderType = comboBox1.Text;
            if (string.IsNullOrWhiteSpace(orderType)) orderType = "Dine-in";

            using (SqlConnection con = new SqlConnection(DBHelper.ConnectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    string orderQuery = @"INSERT INTO Orders (CashierID, OrderType, TotalAmount, AmountPaid, ChangeGiven)
                                           OUTPUT INSERTED.OrderID
                                           VALUES (@CashierID, @OrderType, @Total, @Paid, @Change)";

                    int newOrderId;
                    using (SqlCommand cmd = new SqlCommand(orderQuery, con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@CashierID", SessionManager.CurrentUserID);
                        cmd.Parameters.AddWithValue("@OrderType", orderType);
                        cmd.Parameters.AddWithValue("@Total", total);
                        cmd.Parameters.AddWithValue("@Paid", tendered);
                        cmd.Parameters.AddWithValue("@Change", change);

                        newOrderId = (int)cmd.ExecuteScalar();
                    }

                    foreach (DataRow row in _cart.Rows)
                    {
                        if (row.RowState == DataRowState.Deleted) continue;

                        int productId = Convert.ToInt32(row["ProductID"]);
                        int quantity = Convert.ToInt32(row["Quantity"]);
                        decimal unitPrice = Convert.ToDecimal(row["UnitPrice"]);

                        string itemQuery = @"INSERT INTO OrderItems (OrderID, ProductID, Quantity, UnitPrice)
                                              VALUES (@OrderID, @ProductID, @Quantity, @UnitPrice)";
                        using (SqlCommand cmd = new SqlCommand(itemQuery, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@OrderID", newOrderId);
                            cmd.Parameters.AddWithValue("@ProductID", productId);
                            cmd.Parameters.AddWithValue("@Quantity", quantity);
                            cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                            cmd.ExecuteNonQuery();
                        }

                        string stockQuery = @"UPDATE Products SET Stock = Stock - @Quantity WHERE ProductID = @ProductID";
                        using (SqlCommand cmd = new SqlCommand(stockQuery, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Quantity", quantity);
                            cmd.Parameters.AddWithValue("@ProductID", productId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();

                    MessageBox.Show(
                        $"Order #{newOrderId} completed.\nTotal: ${total:0.00}\nChange due: ${change:0.00}",
                        "Payment successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    button4_Click(sender, e);
                    LoadMenu();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Payment failed, no changes were saved:\n" + ex.Message,
                        "Transaction error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e) { }
    }
}
