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
    public partial class Add_GPC : Form
    {
        DB db = new DB();
        public Add_GPC()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void save_Click(object sender, EventArgs e)
        {
            db.openConnection();

            var type = textcomp1gpc.Text;
            SqlCommand com = new SqlCommand("select * from Gel_Polish_Coating where thickness='" + textcomp1gpc.Text + "'", db.GetSqlConnection());
            SqlDataReader fr = com.ExecuteReader();
            if (fr.Read())
            {
                fr.Close();
                MessageBox.Show("thickness already exist ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                fr.Close();
                var ddd = $"insert into Gel_Polish_Coating (thickness) values ('{type}')";
                var command = new SqlCommand(ddd, db.GetSqlConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            db.closeConnection();
        }
    }
}
