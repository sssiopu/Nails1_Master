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
    public partial class Regi : Form
    {
        public Regi()
        {
            InitializeComponent();
        }

        private void textlog_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void closebut_Click(object sender, EventArgs e)
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

        private void regbut_Click_1(object sender, EventArgs e)
        {
            DB db = new DB();
            db.openConnection();

            int iduser = 2;
            if (rname.Text != string.Empty && rlastname.Text != string.Empty && rlog.Text != string.Empty && rpas.Text != string.Empty && rrpas.Text != string.Empty)
            {
                if (rpas.Text == rrpas.Text)
                {
                    SqlCommand com = new SqlCommand("select * from Users where Login = '" + rlog + "'", db.GetSqlConnection());

                    SqlDataReader rreader = com.ExecuteReader();
                    if (rreader.Read())
                    {
                        rreader.Close();
                        MessageBox.Show("Login is exist, choose another(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        rreader.Close();
                        com = new SqlCommand("insert into Users values(@Login, @Password, @First_Name, @Last_Name, @Id_Role)", db.GetSqlConnection());
                        com.Parameters.AddWithValue("Login", rlog.Text);
                        com.Parameters.AddWithValue("Password", rpas.Text);
                        com.Parameters.AddWithValue("First_Name", rname.Text);
                        com.Parameters.AddWithValue("Last_Name", rlastname.Text);
                        com.Parameters.AddWithValue("Id_Role", iduser);
                        MessageBox.Show("Congratulations! Now u have an account.", "WELL DONE!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Create the same password, please!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter full parameters, please", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Hide();
            MainWin r2 = new MainWin();
            r2.Show();
        }
    }
}
