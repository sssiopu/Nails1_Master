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
    enum RowState1
    {
        Execute,
        New,
        Modified,
        ModifiedNew,
        Deleted,
        Existed

    }


    public partial class Medical_Manicure : Form
    {
        DB db = new DB();
        int SelectedRow;

        public Medical_Manicure()
        {
            InitializeComponent();
        }

        private void medbut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin2 r1 = new Admin2();
            r1.Show();
        }
        private void CreateColums()
        {
            dataGridView2.Columns.Add("Id_Medical_Manicure", "id");
            dataGridView2.Columns.Add("problem", "problem");
            dataGridView2.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRow(DataGridView pip, IDataRecord record)
        {
            pip.Rows.Add(record.GetInt32(0), record.GetString(1), RowState.ModifiedNew);
        }
        private void RefrestDatarid(DataGridView pip)
        {
            db.openConnection();
            pip.Rows.Clear();
            string qwertyString = $"select * from Medical_Manicure";
            SqlCommand command = new SqlCommand(qwertyString, db.GetSqlConnection());

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(pip, reader);
            }
            reader.Close();
            db.closeConnection();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            CreateColums();
            RefrestDatarid(dataGridView2);
            dataGridView2.Columns[2].Visible = false;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[SelectedRow];

                textidm.Text = row.Cells[0].Value?.ToString();
                textcompm.Text = row.Cells[1].Value?.ToString();

            }

        }


        private void updatebutm_Click(object sender, EventArgs e)
        {
            RefrestDatarid(dataGridView2);
        }

        private void Search1(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"select * from Medical_Manicure where concat (Id_Medical_Manicure, problem) like '%" + searchtextm.Text + "%'";


            SqlCommand com = new SqlCommand(searchString, db.GetSqlConnection());
            db.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow(dgw, read);

            }
            read.Close();

        }
        private void searchtextm_TextChanged(object sender, EventArgs e)
        {
            Search1(dataGridView2);
        }



        private void deleteRow()
        {
            int index = dataGridView2.CurrentCell.RowIndex;
            dataGridView2.Rows[index].Visible = false;

            if (dataGridView2.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView2.Rows[index].Cells[2].Value = RowState.Deleted;
                return;
            }
            dataGridView2.Rows[index].Cells[2].Value = RowState.Deleted;
        }



        private void Update1()
        {
            db.openConnection();
            for (int index = 0; index < dataGridView2.Rows.Count; index++)
            {
                // Проверяем, что значение не null
                if (dataGridView2.Rows[index].Cells[2].Value == null)
                    continue;

                var rowState = (RowState)dataGridView2.Rows[index].Cells[2].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }

                if (rowState == RowState.Deleted)
                {
                    // Проверяем, что значение не null
                    if (dataGridView2.Rows[index].Cells[0].Value == null)
                        continue;

                    var id = Convert.ToInt32(dataGridView2.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Design where Id_Design = {id}";

                    var command = new SqlCommand(deleteQuery, db.GetSqlConnection());
                    command.ExecuteNonQuery();
                }
            }
            db.closeConnection();
        }



        private void deletebutm_Click(object sender, EventArgs e)
        {
            deleteRow();
        }

        private void savebutm_Click(object sender, EventArgs e)
        {
            Update1();
        }

        private void sortascd_Click(object sender, EventArgs e)
        {
            dataGridView2.Sort(dataGridView2.Columns[1], ListSortDirection.Ascending);
        }

        private void sortdescd_Click(object sender, EventArgs e)
        {
            dataGridView2.Sort(dataGridView2.Columns[1], ListSortDirection.Descending);
        }

        private void addbutm_Click(object sender, EventArgs e)
        {
            Add_M addfrm = new Add_M();
            addfrm.Show();
        }

        
    }
}
