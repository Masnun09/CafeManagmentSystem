using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementSystem
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            
        }

        private void LoadUserControl(UserControl userControl)
        {
            panel8.Controls.Clear();

            userControl.Dock = DockStyle.Fill;

            panel8.Controls.Add(userControl);
        }
        private void Admin_Load(object sender, EventArgs e)
        {
            Dashboard_Click_2(sender, e); 
        }

        private void Dashboard_Click(object sender, EventArgs e)
        {

        }

        private void Logout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
            
        }

        private void Product_Click(object sender, EventArgs e)
        {
            AdminAddProduct addProduct =new AdminAddProduct();

            LoadUserControl(addProduct);
        }

        private void User_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();

            LoadUserControl(addUser);
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            
       
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashboard_Click_1(object sender, EventArgs e)
        { 

        }

        private void Dashboard_Click_2(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            LoadUserControl(adminDashboard);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}
