namespace CafeManagementSystem
{
    partial class CashierDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.cardSales = new System.Windows.Forms.Panel();
            this.lblSalesValue = new System.Windows.Forms.Label();
            this.lblSalesCaption = new System.Windows.Forms.Label();
            this.cardGoal = new System.Windows.Forms.Panel();
            this.progressGoal = new System.Windows.Forms.ProgressBar();
            this.lblGoalValue = new System.Windows.Forms.Label();
            this.lblGoalCaption = new System.Windows.Forms.Label();
            this.cardIncome = new System.Windows.Forms.Panel();
            this.lblIncomeValue = new System.Windows.Forms.Label();
            this.lblIncomeCaption = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.cardSales.SuspendLayout();
            this.cardGoal.SuspendLayout();
            this.cardIncome.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(216)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.cardSales);
            this.panel1.Controls.Add(this.cardGoal);
            this.panel1.Controls.Add(this.cardIncome);
            this.panel1.Location = new System.Drawing.Point(12, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 140);
            this.panel1.TabIndex = 1;
            // 
            // cardSales
            // 
            this.cardSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(46)))), ((int)(((byte)(43)))));
            this.cardSales.Controls.Add(this.lblSalesValue);
            this.cardSales.Controls.Add(this.lblSalesCaption);
            this.cardSales.Location = new System.Drawing.Point(15, 10);
            this.cardSales.Name = "cardSales";
            this.cardSales.Size = new System.Drawing.Size(330, 120);
            this.cardSales.TabIndex = 0;
            this.cardSales.Paint += new System.Windows.Forms.PaintEventHandler(this.cardSales_Paint);
            // 
            // lblSalesValue
            // 
            this.lblSalesValue.AutoSize = true;
            this.lblSalesValue.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(243)))), ((int)(((byte)(236)))));
            this.lblSalesValue.Location = new System.Drawing.Point(20, 45);
            this.lblSalesValue.Name = "lblSalesValue";
            this.lblSalesValue.Size = new System.Drawing.Size(82, 32);
            this.lblSalesValue.TabIndex = 1;
            this.lblSalesValue.Text = "$0.00";
            // 
            // lblSalesCaption
            // 
            this.lblSalesCaption.AutoSize = true;
            this.lblSalesCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(243)))), ((int)(((byte)(236)))));
            this.lblSalesCaption.Location = new System.Drawing.Point(20, 15);
            this.lblSalesCaption.Name = "lblSalesCaption";
            this.lblSalesCaption.Size = new System.Drawing.Size(105, 18);
            this.lblSalesCaption.TabIndex = 0;
            this.lblSalesCaption.Text = "Today\'s Sales";
            // 
            // cardGoal
            // 
            this.cardGoal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(46)))), ((int)(((byte)(43)))));
            this.cardGoal.Controls.Add(this.progressGoal);
            this.cardGoal.Controls.Add(this.lblGoalValue);
            this.cardGoal.Controls.Add(this.lblGoalCaption);
            this.cardGoal.Location = new System.Drawing.Point(372, 10);
            this.cardGoal.Name = "cardGoal";
            this.cardGoal.Size = new System.Drawing.Size(330, 120);
            this.cardGoal.TabIndex = 1;
            // 
            // progressGoal
            // 
            this.progressGoal.Location = new System.Drawing.Point(20, 80);
            this.progressGoal.Name = "progressGoal";
            this.progressGoal.Size = new System.Drawing.Size(290, 20);
            this.progressGoal.TabIndex = 2;
            this.progressGoal.Click += new System.EventHandler(this.progressGoal_Click);
            // 
            // lblGoalValue
            // 
            this.lblGoalValue.AutoSize = true;
            this.lblGoalValue.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoalValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(243)))), ((int)(((byte)(236)))));
            this.lblGoalValue.Location = new System.Drawing.Point(20, 42);
            this.lblGoalValue.Name = "lblGoalValue";
            this.lblGoalValue.Size = new System.Drawing.Size(150, 24);
            this.lblGoalValue.TabIndex = 1;
            this.lblGoalValue.Text = "$0.00 / $200.00";
            // 
            // lblGoalCaption
            // 
            this.lblGoalCaption.AutoSize = true;
            this.lblGoalCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoalCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(243)))), ((int)(((byte)(236)))));
            this.lblGoalCaption.Location = new System.Drawing.Point(20, 15);
            this.lblGoalCaption.Name = "lblGoalCaption";
            this.lblGoalCaption.Size = new System.Drawing.Size(99, 18);
            this.lblGoalCaption.TabIndex = 0;
            this.lblGoalCaption.Text = "Today\'s Goal";
            // 
            // cardIncome
            // 
            this.cardIncome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(46)))), ((int)(((byte)(43)))));
            this.cardIncome.Controls.Add(this.lblIncomeValue);
            this.cardIncome.Controls.Add(this.lblIncomeCaption);
            this.cardIncome.Location = new System.Drawing.Point(729, 10);
            this.cardIncome.Name = "cardIncome";
            this.cardIncome.Size = new System.Drawing.Size(330, 120);
            this.cardIncome.TabIndex = 2;
            // 
            // lblIncomeValue
            // 
            this.lblIncomeValue.AutoSize = true;
            this.lblIncomeValue.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncomeValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(243)))), ((int)(((byte)(236)))));
            this.lblIncomeValue.Location = new System.Drawing.Point(20, 45);
            this.lblIncomeValue.Name = "lblIncomeValue";
            this.lblIncomeValue.Size = new System.Drawing.Size(82, 32);
            this.lblIncomeValue.TabIndex = 1;
            this.lblIncomeValue.Text = "$0.00";
            // 
            // lblIncomeCaption
            // 
            this.lblIncomeCaption.AutoSize = true;
            this.lblIncomeCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncomeCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(243)))), ((int)(((byte)(236)))));
            this.lblIncomeCaption.Location = new System.Drawing.Point(20, 15);
            this.lblIncomeCaption.Name = "lblIncomeCaption";
            this.lblIncomeCaption.Size = new System.Drawing.Size(98, 18);
            this.lblIncomeCaption.TabIndex = 0;
            this.lblIncomeCaption.Text = "Total Income";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(46)))), ((int)(((byte)(43)))));
            this.lblWelcome.Location = new System.Drawing.Point(14, 15);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(211, 27);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome, Cashier";
            // 
            // CashierDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(216)))), ((int)(((byte)(204)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblWelcome);
            this.Name = "CashierDashboard";
            this.Size = new System.Drawing.Size(1110, 433);
            this.Load += new System.EventHandler(this.CashierDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.cardSales.ResumeLayout(false);
            this.cardSales.PerformLayout();
            this.cardGoal.ResumeLayout(false);
            this.cardGoal.PerformLayout();
            this.cardIncome.ResumeLayout(false);
            this.cardIncome.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblWelcome;

        private System.Windows.Forms.Panel cardSales;
        private System.Windows.Forms.Label lblSalesValue;
        private System.Windows.Forms.Label lblSalesCaption;

        private System.Windows.Forms.Panel cardGoal;
        private System.Windows.Forms.Label lblGoalValue;
        private System.Windows.Forms.Label lblGoalCaption;
        private System.Windows.Forms.ProgressBar progressGoal;

        private System.Windows.Forms.Panel cardIncome;
        private System.Windows.Forms.Label lblIncomeValue;
        private System.Windows.Forms.Label lblIncomeCaption;
    }
}
