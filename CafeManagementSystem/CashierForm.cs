using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementSystem
{
    public partial class CashierForm : Form
    {
        public CashierForm()
        {
            InitializeComponent();
        }

        private void LoadUserControl(UserControl userControl)
        {
            panel8.Controls.Clear();

            userControl.Dock = DockStyle.Fill;

            panel8.Controls.Add(userControl);
        }
        private void CashierForm_Load(object sender, EventArgs e)
        {
            Dashboard_Click(sender, e); 
        }

        private void Dashboard_Click(object sender, EventArgs e)
        {
            CashierDashboard dashboard = new CashierDashboard();
            LoadUserControl(dashboard);
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void Product_Click(object sender, EventArgs e)
        {
            AdminAddProduct adProduct = new AdminAddProduct();
            LoadUserControl(adProduct);
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void Bill_Click(object sender, EventArgs e)
        {
            CashierBill cashierBill = new CashierBill();
            LoadUserControl(cashierBill);
        }
    }
}
