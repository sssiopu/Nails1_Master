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

    public partial class Add_Wi : Form
    {
        DB db = new DB();
        public Add_Wi()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, EventArgs e)
        {
            db.openConnection();

            var type = textcomp1wi.Text;
            SqlCommand com = new SqlCommand("select * from Withdrawal where Whos_job_is_it='" + textcomp1wi.Text + "'", db.GetSqlConnection());
            SqlDataReader fr = com.ExecuteReader();
            if (fr.Read())
            {
                fr.Close();
                MessageBox.Show("Whos_job_is_it already exist ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                fr.Close();
                var ddd = $"insert into Withdrawal (Whos_job_is_it) values ('{type}')";
                var command = new SqlCommand(ddd, db.GetSqlConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            db.closeConnection();
        }
    }
}
