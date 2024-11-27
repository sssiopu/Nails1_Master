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
    enum RowState2
    {
        Execute,
        New,
        Modified,
        ModifiedNew,
        Deleted,
        Existed

    }
    public partial class Gender : Form
    {
        DB db = new DB();
        int SelectedRow;

        public Gender()
        {
            InitializeComponent();
        }

        private void backbutdes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin2 r1 = new Admin2();
            r1.Show();
        }
        private void CreateColums()
        {
            dataGridViewgen.Columns.Add("Id_Gender", "id");
            dataGridViewgen.Columns.Add("gender", "gender");
            dataGridViewgen.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRow(DataGridView pip, IDataRecord record)
        {
            pip.Rows.Add(record.GetInt32(0), record.GetString(1), RowState.ModifiedNew);
        }
        private void RefrestDatarid1(DataGridView pip)
        {
            db.openConnection();
            pip.Rows.Clear();
            string qwertyString = $"select * from Gender";
            SqlCommand command = new SqlCommand(qwertyString, db.GetSqlConnection());

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(pip, reader);
            }
            reader.Close();
            db.closeConnection();
        }
        private void Gender_Load(object sender, EventArgs e)
        {
            CreateColums();
            RefrestDatarid1(dataGridViewgen);
            dataGridViewgen.Columns[2].Visible = false;
        }
        private void dataGridViewgen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewgen.Rows[SelectedRow];

                textidgen.Text = row.Cells[0].Value?.ToString();
                textcompgen.Text = row.Cells[1].Value?.ToString();

            }
        }
             private void addbutgen_Click(object sender, EventArgs e)
        {
            Add_gender addfrm = new Add_gender();
            addfrm.Show();
        }
        private void updatebutgen_Click(object sender, EventArgs e)
        {
            RefrestDatarid1(dataGridViewgen);
        }
        private void Search1(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"select * from Gender where concat (Id_Gender, gender) like '%" + searchtextgen.Text + "%'";


            SqlCommand com = new SqlCommand(searchString, db.GetSqlConnection());
            db.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow(dgw, read);

            }
            read.Close();

        }
        private void searchtextgen_TextChanged(object sender, EventArgs e)
        {
            Search1(dataGridViewgen);
        }
        private void deleteRow()
        {
            int index = dataGridViewgen.CurrentCell.RowIndex;
            dataGridViewgen.Rows[index].Visible = false;

            if (dataGridViewgen.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridViewgen.Rows[index].Cells[2].Value = RowState.Deleted;
                return;
            }
            dataGridViewgen.Rows[index].Cells[2].Value = RowState.Deleted;
        }
        private void Update1()
        {
            db.openConnection();
            for (int index = 0; index < dataGridViewgen.Rows.Count; index++)
            {
                // Проверяем, что значение не null
                if (dataGridViewgen.Rows[index].Cells[2].Value == null)
                    continue;

                var rowState = (RowState)dataGridViewgen.Rows[index].Cells[2].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }

                if (rowState == RowState.Deleted)
                {
                    // Проверяем, что значение не null
                    if (dataGridViewgen.Rows[index].Cells[0].Value == null)
                        continue;

                    var id = Convert.ToInt32(dataGridViewgen.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from gender where Id_Gender = {id}";

                    var command = new SqlCommand(deleteQuery, db.GetSqlConnection());
                    command.ExecuteNonQuery();
                }
            }
            db.closeConnection();
        }

             private void deletebutgen_Click(object sender, EventArgs e)
        {
            deleteRow();
        }

        private void savebutgen_Click(object sender, EventArgs e)
        {
            Update1();
        }

        private void sortascdgen_Click(object sender, EventArgs e)
        {
            dataGridViewgen.Sort(dataGridViewgen.Columns[1], ListSortDirection.Ascending);
        }

        private void sortdescdgen_Click(object sender, EventArgs e)
        {
            dataGridViewgen.Sort(dataGridViewgen.Columns[1], ListSortDirection.Descending);
        }

    }
}


