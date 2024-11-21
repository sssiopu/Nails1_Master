using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nails1_Master
{
    public partial class Add_design : Form

    {
        DB db = new DB();

        public Add_design()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

       

        private void save_Click_1(object sender, EventArgs e)
        {
            db.openConnection();

            var type = textcomp1.Text;
            SqlCommand com = new SqlCommand("select * from Design where complexity='" + textcomp1.Text + "'", db.GetSqlConnection());
            SqlDataReader fr = com.ExecuteReader();
            if (fr.Read())
            {
                fr.Close();
                MessageBox.Show("complexity already exist ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                fr.Close();
                var ddd = $"insert into Design (complexity) values ('{type}')";
                var command = new SqlCommand(ddd, db.GetSqlConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            db.closeConnection();

        }
    }
}
