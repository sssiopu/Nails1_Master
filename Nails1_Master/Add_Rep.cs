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
    public partial class Add_Rep : Form
    {
        DB db = new DB();
        public Add_Rep()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void savebutrep1_Click_1(object sender, EventArgs e)
        {
            db.openConnection();

            var type = textcomprep1.Text;
            SqlCommand com = new SqlCommand("select * from Repair where Number_Of_Nails='" + textcomprep1.Text + "'", db.GetSqlConnection());
            SqlDataReader fr = com.ExecuteReader();
            if (fr.Read())
            {
                fr.Close();
                MessageBox.Show("Number_Of_Nails already exist ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                fr.Close();
                var ddd = $"insert into Repair (Number_Of_Nails) values ('{type}')";
                var command = new SqlCommand(ddd, db.GetSqlConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            db.closeConnection();

        }
    }
}
