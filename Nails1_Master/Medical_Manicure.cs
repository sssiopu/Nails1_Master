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
using static System.Net.Mime.MediaTypeNames;

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
            dataGridViewM.Columns.Add("Id_Medical_Manicure", "id");
            dataGridViewM.Columns.Add("problem", "problem");
            dataGridViewM.Columns.Add("IsNew", String.Empty);
        }
        private void ClearFields()
        {
            textidm.Text = "";
            textcompm.Text = "";

        }

        private void ReadSingleRow(DataGridView pip, IDataRecord record)
        {
            pip.Rows.Add(record.GetInt32(0), record.GetString(1), RowState.ModifiedNew);
        }

        private void RefrestDatarid(DataGridView pip)
        {
            db.openConnection();
            pip.Rows.Clear();
            string qwertyString = "SELECT * FROM Medical_Manicure";
            SqlCommand command = new SqlCommand(qwertyString, db.GetSqlConnection());

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ReadSingleRow(pip, reader);
                }
            }
            db.closeConnection();
        }


      


        private void Search1(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"SELECT * FROM Medical_Manicure WHERE CONCAT (Id_Medical_Manicure, problem) LIKE '%{searchtextm.Text}%'";
            SqlCommand com = new SqlCommand(searchString, db.GetSqlConnection());
            db.openConnection();

            using (SqlDataReader read = com.ExecuteReader())
            {
                while (read.Read())
                {
                    ReadSingleRow(dgw, read);
                }
            }
        }

        private void searchtextm_TextChanged(object sender, EventArgs e)
        {
            Search1(dataGridViewM);
        }

        private void deleteRow()
        {
            if (dataGridViewM.CurrentRow != null)
            {
                int index = dataGridViewM.CurrentCell.RowIndex;
                dataGridViewM.Rows[index].Visible = false;

                if (string.IsNullOrEmpty(dataGridViewM.Rows[index].Cells[0].Value?.ToString()))
                {
                    dataGridViewM.Rows[index].Cells[2].Value = RowState.Deleted;
                }
                else
                {
                    dataGridViewM.Rows[index].Cells[2].Value = RowState.Deleted;
                }
            }
        }

        private void Update1()
        {
            db.openConnection();

            for (int index = 0; index < dataGridViewM.Rows.Count; index++)
            {
                if (dataGridViewM.Rows[index].Cells[2].Value == null)
                    continue;

                var rowState = (RowState)dataGridViewM.Rows[index].Cells[2].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }

                if (rowState == RowState.Deleted)
                {
                    if (dataGridViewM.Rows[index].Cells[0].Value != null)
                    {
                        var id = Convert.ToInt32(dataGridViewM.Rows[index].Cells[0].Value);
                        var deleteQuery = $"DELETE FROM Medical_Manicure WHERE Id_Medical_Manicure = {id}";
                        var command = new SqlCommand(deleteQuery, db.GetSqlConnection());
                        command.ExecuteNonQuery();
                    }
                }
                if (rowState == RowState.Modified)
                {
                    var id = dataGridViewM.Rows[index].Cells[0].Value.ToString();
                    var type1 = dataGridViewM.Rows[index].Cells[1].Value.ToString();

                    var changeQuery = $"update Medical_Manicure set problem = '{type1}' where Id_Medical_Manicure = '{id}'";
                    var command = new SqlCommand(changeQuery, db.GetSqlConnection());
                    command.ExecuteNonQuery();
                }
            }
            db.closeConnection();
        }
        private void Change()
        {
            var selectedRowIndex = dataGridViewM.CurrentCell.RowIndex;

            var id = textidm.Text;
            var type = textcompm.Text;

            if (dataGridViewM.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridViewM.Rows[selectedRowIndex].SetValues(id, type);
                dataGridViewM.Rows[selectedRowIndex].Cells[2].Value = RowState.Modified;
            }
        }







        private void addbutm_Click(object sender, EventArgs e)
        {

            Add_M addfrm = new Add_M();
            addfrm.Show();
        }

        private void Medical_Manicure_Load_1(object sender, EventArgs e)
        {
            CreateColums();
            RefrestDatarid(dataGridViewM);
            dataGridViewM.Columns[2].Visible = false;
        }

        private void dataGridViewM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = e.RowIndex;

            if (SelectedRow >= 0)
            {
                DataGridViewRow row = dataGridViewM.Rows[SelectedRow];
                textidm.Text = row.Cells[0].Value?.ToString();
                textcompm.Text = row.Cells[1].Value?.ToString();
            }
        }

        private void updatebutm_Click(object sender, EventArgs e)
        {
            RefrestDatarid(dataGridViewM);
            ClearFields();
        }

        private void sortascdm_Click(object sender, EventArgs e)
        {
            dataGridViewM.Sort(dataGridViewM.Columns[1], ListSortDirection.Ascending);
        }

        private void deletebutm_Click(object sender, EventArgs e)
        {
            deleteRow();
            ClearFields();
        }

        private void savebutm_Click(object sender, EventArgs e)
        {
            Update1();
        }

        private void sortdescdm_Click(object sender, EventArgs e)
        {
            dataGridViewM.Sort(dataGridViewM.Columns[1], ListSortDirection.Descending);
        }

        private void clearbutm_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void changebut_Click(object sender, EventArgs e)
        {
            Change();
        }
    }
}



