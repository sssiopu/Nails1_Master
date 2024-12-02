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
    public partial class Role : Form
    {
        DB db = new DB();
        int SelectedRow;
        public Role()
        {
            InitializeComponent();
        }

        private void backbutrl_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin2 r1 = new Admin2();
            r1.Show();
        }
        private void CreateColums()
        {
            dataGridViewRL.Columns.Add("Id_Role_Users", "id");
            dataGridViewRL.Columns.Add("name", "name");
            dataGridViewRL.Columns.Add("IsNew", String.Empty);
        }
        private void ClearFields()
        {
            textidrl.Text = "";
            textcomprl.Text = "";

        }
        private void ReadSingleRow(DataGridView pip, IDataRecord record)
        {
            pip.Rows.Add(record.GetInt32(0), record.GetString(1), RowState.ModifiedNew);
        }
        private void RefrestDatarid1(DataGridView pip)
        {
            db.openConnection();
            pip.Rows.Clear();
            string qwertyString = $"select * from Role_Users";
            SqlCommand command = new SqlCommand(qwertyString, db.GetSqlConnection());

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(pip, reader);
            }
            reader.Close();
            db.closeConnection();
        }
        private void Search1(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"select * from Role_Users where concat (Id_Role_Users, name) like '%" + searchtextrl.Text + "%'";


            SqlCommand com = new SqlCommand(searchString, db.GetSqlConnection());
            db.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow(dgw, read);

            }
            read.Close();

        }
        private void deleteRow()
        {
            int index = dataGridViewRL.CurrentCell.RowIndex;
            dataGridViewRL.Rows[index].Visible = false;

            if (dataGridViewRL.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridViewRL.Rows[index].Cells[2].Value = RowState.Deleted;
                return;
            }
            dataGridViewRL.Rows[index].Cells[2].Value = RowState.Deleted;
        }
        private void Update1()
        {
            db.openConnection();
            for (int index = 0; index < dataGridViewRL.Rows.Count; index++)
            {
                // Проверяем, что значение не null
                if (dataGridViewRL.Rows[index].Cells[2].Value == null)
                    continue;

                var rowState = (RowState)dataGridViewRL.Rows[index].Cells[2].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }

                if (rowState == RowState.Deleted)
                {
                    // Проверяем, что значение не null
                    if (dataGridViewRL.Rows[index].Cells[0].Value == null)
                        continue;

                    var id = Convert.ToInt32(dataGridViewRL.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Role_Users where Id_Role_Users = {id}";

                    var command = new SqlCommand(deleteQuery, db.GetSqlConnection());
                    command.ExecuteNonQuery();
                }
                if (rowState == RowState.Modified)
                {
                    var id = dataGridViewRL.Rows[index].Cells[0].Value.ToString();
                    var type1 = dataGridViewRL.Rows[index].Cells[1].Value.ToString();

                    var changeQuery = $"update Role_Users set name = '{type1}' where Id_Role_Users = '{id}'";
                    var command = new SqlCommand(changeQuery, db.GetSqlConnection());
                    command.ExecuteNonQuery();
                }
            }
            db.closeConnection();
        }
        private void Change()
        {
            var selectedRowIndex = dataGridViewRL.CurrentCell.RowIndex;

            var id = textidrl.Text;
            var type = textcomprl.Text;

            if (dataGridViewRL.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridViewRL.Rows[selectedRowIndex].SetValues(id, type);
                dataGridViewRL.Rows[selectedRowIndex].Cells[2].Value = RowState.Modified;
            }
        }

        private void Role_Load(object sender, EventArgs e)
        {
            CreateColums();
            RefrestDatarid1(dataGridViewRL);
            dataGridViewRL.Columns[2].Visible = false;
        }

        private void dataGridViewRL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewRL.Rows[SelectedRow];

                textidrl.Text = row.Cells[0].Value?.ToString();
                textcomprl.Text = row.Cells[1].Value?.ToString();

            }
        }

        private void updatebutrl_Click(object sender, EventArgs e)
        {
            RefrestDatarid1(dataGridViewRL);
            ClearFields();
        }

        private void searchtextrl_TextChanged(object sender, EventArgs e)
        {
            Search1(dataGridViewRL);
        }

        private void deletebutrl_Click(object sender, EventArgs e)
        {
            deleteRow();
            ClearFields();
        }

        private void savebutrl_Click(object sender, EventArgs e)
        {
            Update1();
        }

        private void sortascdrl_Click(object sender, EventArgs e)
        {
            dataGridViewRL.Sort(dataGridViewRL.Columns[1], ListSortDirection.Ascending);
        }

        private void sortdescdrl_Click(object sender, EventArgs e)
        {
            dataGridViewRL.Sort(dataGridViewRL.Columns[1], ListSortDirection.Descending);
        }

        private void cleatbutrl_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void changebutrl_Click(object sender, EventArgs e)
        {
            Change();
        }
    }
}
