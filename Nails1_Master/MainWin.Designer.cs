namespace Nails1_Master
{
    partial class MainWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
            this.label1 = new System.Windows.Forms.Label();
            this.LogBut = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.closebut = new System.Windows.Forms.Button();
            this.CreateBut = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.textlog = new System.Windows.Forms.TextBox();
            this.textpas = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(215)))), ((int)(((byte)(217)))));
            this.label1.Font = new System.Drawing.Font("Algerian", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(130)))), ((int)(((byte)(117)))));
            this.label1.Location = new System.Drawing.Point(348, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(720, 106);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nails Master";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            
            // 
            // LogBut
            // 
            this.LogBut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LogBut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(215)))), ((int)(((byte)(217)))));
            this.LogBut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogBut.FlatAppearance.BorderSize = 2;
            this.LogBut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(137)))), ((int)(((byte)(139)))));
            this.LogBut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(163)))), ((int)(((byte)(161)))));
            this.LogBut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogBut.Font = new System.Drawing.Font("Algerian", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogBut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(130)))), ((int)(((byte)(117)))));
            this.LogBut.Location = new System.Drawing.Point(625, 535);
            this.LogBut.Name = "LogBut";
            this.LogBut.Size = new System.Drawing.Size(128, 43);
            this.LogBut.TabIndex = 1;
            this.LogBut.Text = "Login";
            this.LogBut.UseVisualStyleBackColor = false;
            this.LogBut.Click += new System.EventHandler(this.LogBut_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(130)))), ((int)(((byte)(117)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.closebut);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1317, 189);
            this.panel1.TabIndex = 2;
            
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::Nails1_Master.Properties.Resources.Group_1;
            this.pictureBox1.Location = new System.Drawing.Point(33, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // closebut
            // 
            this.closebut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.closebut.BackColor = System.Drawing.Color.White;
            this.closebut.Font = new System.Drawing.Font("Algerian", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(130)))), ((int)(((byte)(117)))));
            this.closebut.Location = new System.Drawing.Point(1265, 3);
            this.closebut.Name = "closebut";
            this.closebut.Size = new System.Drawing.Size(40, 38);
            this.closebut.TabIndex = 1;
            this.closebut.Text = "X";
            this.closebut.UseVisualStyleBackColor = false;
            this.closebut.Click += new System.EventHandler(this.button3_Click);
            this.closebut.MouseEnter += new System.EventHandler(this.closebut_MouseEnter);
            this.closebut.MouseLeave += new System.EventHandler(this.closebut_MouseLeave);
            // 
            // CreateBut
            // 
            this.CreateBut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CreateBut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(215)))), ((int)(((byte)(217)))));
            this.CreateBut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreateBut.FlatAppearance.BorderSize = 2;
            this.CreateBut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(137)))), ((int)(((byte)(139)))));
            this.CreateBut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(163)))), ((int)(((byte)(161)))));
            this.CreateBut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateBut.Font = new System.Drawing.Font("Algerian", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateBut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(130)))), ((int)(((byte)(117)))));
            this.CreateBut.Location = new System.Drawing.Point(557, 602);
            this.CreateBut.Name = "CreateBut";
            this.CreateBut.Size = new System.Drawing.Size(288, 45);
            this.CreateBut.TabIndex = 3;
            this.CreateBut.Text = "Create account";
            this.CreateBut.UseVisualStyleBackColor = false;
            this.CreateBut.Click += new System.EventHandler(this.CreateBut_Click);
            // 
            // login
            // 
            this.login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.login.AutoSize = true;
            this.login.Font = new System.Drawing.Font("Algerian", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(130)))), ((int)(((byte)(117)))));
            this.login.Location = new System.Drawing.Point(278, 307);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(161, 54);
            this.login.TabIndex = 4;
            this.login.Text = "Login";
            
            // 
            // password
            // 
            this.password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.password.AutoSize = true;
            this.password.Font = new System.Drawing.Font("Algerian", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(130)))), ((int)(((byte)(117)))));
            this.password.Location = new System.Drawing.Point(194, 443);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(276, 54);
            this.password.TabIndex = 5;
            this.password.Text = "password";
            
            // 
            // textlog
            // 
            this.textlog.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textlog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(215)))), ((int)(((byte)(217)))));
            this.textlog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textlog.Font = new System.Drawing.Font("Algerian", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textlog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(178)))), ((int)(((byte)(191)))));
            this.textlog.Location = new System.Drawing.Point(505, 311);
            this.textlog.Name = "textlog";
            this.textlog.Size = new System.Drawing.Size(462, 47);
            this.textlog.TabIndex = 6;
            // 
            // textpas
            // 
            this.textpas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textpas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(215)))), ((int)(((byte)(217)))));
            this.textpas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textpas.Font = new System.Drawing.Font("Algerian", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textpas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(178)))), ((int)(((byte)(191)))));
            this.textpas.Location = new System.Drawing.Point(508, 447);
            this.textpas.Name = "textpas";
            this.textpas.Size = new System.Drawing.Size(464, 47);
            this.textpas.TabIndex = 7;
            this.textpas.UseSystemPasswordChar = true;
            
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(130)))), ((int)(((byte)(117)))));
            this.panel2.Location = new System.Drawing.Point(507, 356);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(463, 5);
            this.panel2.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(130)))), ((int)(((byte)(117)))));
            this.panel3.Location = new System.Drawing.Point(509, 492);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(463, 5);
            this.panel3.TabIndex = 20;
            // 
            // MainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(215)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(1317, 659);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.textpas);
            this.Controls.Add(this.textlog);
            this.Controls.Add(this.password);
            this.Controls.Add(this.login);
            this.Controls.Add(this.CreateBut);
            this.Controls.Add(this.LogBut);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWin";
            this.Text = "MainWin";
            
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWin_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainWin_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LogBut;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CreateBut;
        private System.Windows.Forms.Label login;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.TextBox textlog;
        private System.Windows.Forms.TextBox textpas;
        private System.Windows.Forms.Button closebut;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}