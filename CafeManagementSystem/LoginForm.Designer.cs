namespace CafeManagementSystem
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.just_text = new System.Windows.Forms.Label();
            this.password_t = new System.Windows.Forms.Label();
            this.username_t = new System.Windows.Forms.Label();
            this.login_btn = new System.Windows.Forms.Button();
            this.password_b = new System.Windows.Forms.TextBox();
            this.username_b = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.only_text = new System.Windows.Forms.Label();
            this.another_text = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(243)))), ((int)(((byte)(236)))));
            this.panel1.Controls.Add(this.just_text);
            this.panel1.Controls.Add(this.password_t);
            this.panel1.Controls.Add(this.username_t);
            this.panel1.Controls.Add(this.login_btn);
            this.panel1.Controls.Add(this.password_b);
            this.panel1.Controls.Add(this.username_b);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 426);
            this.panel1.TabIndex = 0;
            // 
            // just_text
            // 
            this.just_text.AutoSize = true;
            this.just_text.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.just_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(46)))), ((int)(((byte)(43)))));
            this.just_text.Location = new System.Drawing.Point(91, 47);
            this.just_text.Name = "just_text";
            this.just_text.Size = new System.Drawing.Size(145, 46);
            this.just_text.TabIndex = 5;
            this.just_text.Text = "LOGIN";
            // 
            // password_t
            // 
            this.password_t.AutoSize = true;
            this.password_t.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_t.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.password_t.Location = new System.Drawing.Point(51, 220);
            this.password_t.Name = "password_t";
            this.password_t.Size = new System.Drawing.Size(79, 22);
            this.password_t.TabIndex = 4;
            this.password_t.Text = "Password";
            this.password_t.Click += new System.EventHandler(this.password_t_Click);
            // 
            // username_t
            // 
            this.username_t.AutoSize = true;
            this.username_t.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_t.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.username_t.Location = new System.Drawing.Point(51, 137);
            this.username_t.Name = "username_t";
            this.username_t.Size = new System.Drawing.Size(79, 22);
            this.username_t.TabIndex = 3;
            this.username_t.Text = "Username";
            // 
            // login_btn
            // 
            this.login_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(122)))), ((int)(((byte)(68)))));
            this.login_btn.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_btn.ForeColor = System.Drawing.Color.White;
            this.login_btn.Location = new System.Drawing.Point(55, 289);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(205, 40);
            this.login_btn.TabIndex = 2;
            this.login_btn.Text = "Login";
            this.login_btn.UseVisualStyleBackColor = false;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // password_b
            // 
            this.password_b.Location = new System.Drawing.Point(55, 245);
            this.password_b.Name = "password_b";
            this.password_b.PasswordChar = '*';
            this.password_b.Size = new System.Drawing.Size(208, 22);
            this.password_b.TabIndex = 1;
            this.password_b.TextChanged += new System.EventHandler(this.password_box);
            // 
            // username_b
            // 
            this.username_b.Location = new System.Drawing.Point(55, 162);
            this.username_b.Name = "username_b";
            this.username_b.Size = new System.Drawing.Size(209, 22);
            this.username_b.TabIndex = 0;
            this.username_b.TextChanged += new System.EventHandler(this.username_box);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(529, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 110);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // only_text
            // 
            this.only_text.AutoSize = true;
            this.only_text.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.only_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(243)))), ((int)(((byte)(236)))));
            this.only_text.Location = new System.Drawing.Point(521, 162);
            this.only_text.Name = "only_text";
            this.only_text.Size = new System.Drawing.Size(127, 46);
            this.only_text.TabIndex = 2;
            this.only_text.Text = "CAFE";
            // 
            // another_text
            // 
            this.another_text.AutoSize = true;
            this.another_text.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.another_text.ForeColor = System.Drawing.Color.Snow;
            this.another_text.Location = new System.Drawing.Point(405, 220);
            this.another_text.Name = "another_text";
            this.another_text.Size = new System.Drawing.Size(347, 33);
            this.another_text.TabIndex = 3;
            this.another_text.Text = "MANAGEMENT SYSTEM";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(46)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.another_text);
            this.Controls.Add(this.only_text);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Coral;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CafeManagementSystem";
            this.Load += new System.EventHandler(this.Login_form);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox password_b;
        private System.Windows.Forms.TextBox username_b;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.Label just_text;
        private System.Windows.Forms.Label password_t;
        private System.Windows.Forms.Label username_t;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label only_text;
        private System.Windows.Forms.Label another_text;
    }
}

