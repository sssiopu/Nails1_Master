﻿using System;
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
    public partial class Add_gender : Form
    {
        DB db = new DB();
        public Add_gender()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }



        private void savebutgen1_Click(object sender, EventArgs e)
        {
            db.openConnection();

            var type = textcompgen.Text;
            SqlCommand com = new SqlCommand("select * from Gender where gender='" + textcompgen.Text + "'", db.GetSqlConnection());
            SqlDataReader fr = com.ExecuteReader();
            if (fr.Read())
            {
                fr.Close();
                MessageBox.Show("gender already exist ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                fr.Close();
                var ddd = $"insert into Gender (gender) values ('{type}')";
                var command = new SqlCommand(ddd, db.GetSqlConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            db.closeConnection();
        }
    }
}
