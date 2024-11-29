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
    public partial class Add_UP : Form
    {
        DB db = new DB();

        public Add_UP()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void savebut1up_Click(object sender, EventArgs e)
        {
            db.openConnection();

            var type = textcomp1up.Text;
            SqlCommand com = new SqlCommand("select * from Builiding_Up where centimetre ='" + textcomp1up.Text + "'", db.GetSqlConnection());
            SqlDataReader fr = com.ExecuteReader();
            if (fr.Read())
            {
                fr.Close();
                MessageBox.Show("centimetre already exist ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                fr.Close();
                var ddd = $"insert into Builiding_Up (centimetre) values ('{type}')";
                var command = new SqlCommand(ddd, db.GetSqlConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            db.closeConnection();
        }

       
    }
}
