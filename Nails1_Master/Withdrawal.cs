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
  
    public partial class Withdrawal : Form
    {
        DB db = new DB();
        int SelectedRow;
        public Withdrawal()
        {
            InitializeComponent();

        }

        private void backbutdes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin2 r1 = new Admin2();
            r1.Show();
        }

        private void addbutwi_Click(object sender, EventArgs e)
        {
            Add_Wi addfrm = new Add_Wi();
            addfrm.Show();
        }
        private void CreateColums()

        {
            dataGridViewW.Columns.Add("Id_Withdrawal", "id");
            dataGridViewW.Columns.Add("Whos_job_is_it", "Whos_job_is_it");
            dataGridViewW.Columns.Add("IsNew", String.Empty);
        }
        private void ClearFields()
        {
            textidwi.Text = "";
            textcompwi.Text = "";

        }
        private void ReadSingleRow(DataGridView pip, IDataRecord record)
        {
            pip.Rows.Add(record.GetInt32(0), record.GetString(1), RowState.ModifiedNew);
        }
        private void RefrestDatarid(DataGridView pip)
        {
            db.openConnection();
            pip.Rows.Clear();
            string qwertyString = $"select * from Withdrawal";
            SqlCommand command = new SqlCommand(qwertyString, db.GetSqlConnection());

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(pip, reader);
            }
            reader.Close();
            db.closeConnection();
        }

        

        private void dataGridViewW_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewW.Rows[SelectedRow];

                textidwi.Text = row.Cells[0].Value?.ToString();
                textcompwi.Text = row.Cells[1].Value?.ToString();

            }
        }

        private void updatebutwi_Click(object sender, EventArgs e)
        {
            RefrestDatarid(dataGridViewW);
            ClearFields();
        }
        private void Search1(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"select * from Withdrawal where concat (Id_Withdrawal, Whos_job_is_it) like '%" + searchtextwi.Text + "%'";


            SqlCommand com = new SqlCommand(searchString, db.GetSqlConnection());
            db.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow(dgw, read);

            }
            read.Close();

        }

        private void searchtextwi_TextChanged(object sender, EventArgs e)
        {
            Search1(dataGridViewW);
        }
        private void deleteRow()
        {
            int index = dataGridViewW.CurrentCell.RowIndex;
            dataGridViewW.Rows[index].Visible = false;

            if (dataGridViewW.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridViewW.Rows[index].Cells[2].Value = RowState.Deleted;
                return;
            }
            dataGridViewW.Rows[index].Cells[2].Value = RowState.Deleted;
        }
        private void Update1()
        {
            db.openConnection();
            for (int index = 0; index < dataGridViewW.Rows.Count; index++)
            {
                // Проверяем, что значение не null
                if (dataGridViewW.Rows[index].Cells[2].Value == null)
                    continue;

                var rowState = (RowState)dataGridViewW.Rows[index].Cells[2].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }

                if (rowState == RowState.Deleted)
                {
                    // Проверяем, что значение не null
                    if (dataGridViewW.Rows[index].Cells[0].Value == null)
                        continue;

                    var id = Convert.ToInt32(dataGridViewW.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Withdrawal where Id_Withdrawal = {id}";

                    var command = new SqlCommand(deleteQuery, db.GetSqlConnection());
                    command.ExecuteNonQuery();
                }

               
                if (rowState == RowState.Modified)
                {
                    var id = dataGridViewW.Rows[index].Cells[0].Value.ToString();
                    var type1 = dataGridViewW.Rows[index].Cells[1].Value.ToString();

                    var changeQuery = $"update Withdrawal set Whos_job_is_it= '{type1}' where Id_Withdrawal = '{id}'";
                    var command = new SqlCommand(changeQuery, db.GetSqlConnection());
                    command.ExecuteNonQuery();
                }
            }
        }
        private void Change()
        {
            var selectedRowIndex = dataGridViewW.CurrentCell.RowIndex;

            var id = textidwi.Text;
            var type = textcompwi.Text;

            if (dataGridViewW.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridViewW.Rows[selectedRowIndex].SetValues(id, type);
                dataGridViewW.Rows[selectedRowIndex].Cells[2].Value = RowState.Modified;
            }
        }

        private void deletebutwi_Click(object sender, EventArgs e)
        {
            deleteRow();
            ClearFields();
        }

        private void savebutwi_Click(object sender, EventArgs e)
        {
            Update1();
        }

        private void sortdescdwi_Click(object sender, EventArgs e)
        {
            dataGridViewW.Sort(dataGridViewW.Columns[1], ListSortDirection.Descending);
        }

        private void sortascdwi_Click(object sender, EventArgs e)
        {
            dataGridViewW.Sort(dataGridViewW.Columns[1], ListSortDirection.Ascending);
            db.closeConnection();
        }

        private void Withdrawal_Load(object sender, EventArgs e)
        {
            CreateColums();
            RefrestDatarid(dataGridViewW);
            dataGridViewW.Columns[2].Visible = false;
        }

        private void clearbut_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void changebut_Click(object sender, EventArgs e)
        {
            Change();
        }
    }
}
