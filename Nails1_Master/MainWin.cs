using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Nails1_Master
{
    public partial class MainWin : Form
    {
        public MainWin()
        {
            InitializeComponent();

            this.textlog.AutoSize = false;
            this.textlog.Size = new Size(this.textlog.Size.Width, 50);
            this.textpas.AutoSize = false;
            this.textpas.Size = new Size(this.textlog.Size.Width, 50);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closebut_MouseEnter(object sender, EventArgs e)
        {
            closebut.ForeColor = Color.Red;
        }

        private void closebut_MouseLeave(object sender, EventArgs e)
        {
            closebut.ForeColor = Color.FromArgb(191, 130, 117);
        }

        Point lastPoint;
        private void MainWin_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void MainWin_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void MainWin_Load(object sender, EventArgs e)
        {

        }

        

        private void LogBut_Click_1(object sender, EventArgs e)
        {
            string loginUser = login.Text;
            string passwordUser = password.Text;


            DB db = new DB();
            db.openConnection();

            if (textlog.Text != string.Empty && textpas.Text != string.Empty)
            {
                SqlCommand command = new SqlCommand("select * from Users where Id_Role = '1' and Login = '" + textlog.Text + "' and password = '" + textpas.Text + "'", db.GetSqlConnection());

                SqlDataReader reader = command.ExecuteReader();
                bool check = reader.Read();
                reader.Close();

                SqlCommand command2 = new SqlCommand("select * from Users where Login = '" + textlog.Text + "' and password = '" + textpas.Text + "'", db.GetSqlConnection());

                SqlDataReader reader2 = command2.ExecuteReader();
                if (check == true)
                {
                    reader2.Close();
                    this.Hide();
                    Admin ad = new Admin();
                    ad.ShowDialog();

                }
                else if (reader2.Read())
                {
                    reader2.Close();
                    this.Hide();
                    User us = new User();
                    us.ShowDialog();
                }
                else
                {
                    reader2.Close();
                    MessageBox.Show("OOOPS...Account doesnt exist", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Enter the letters!!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            db.closeConnection();
        }

        private void CreateBut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Regi r1 = new Regi();
            r1.Show();
        }

        private void password_Click(object sender, EventArgs e)
        {

        }
    }
}
