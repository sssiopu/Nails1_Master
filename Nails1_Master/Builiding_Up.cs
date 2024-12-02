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
    enum RowState3
    {
        Execute,
        New,
        Modified,
        ModifiedNew,
        Deleted,
        Existed

    }


    public partial class Builiding_Up : Form
    {
        DB db = new DB();
        int SelectedRow;

        public Builiding_Up()
        {
            InitializeComponent();
        }

        private void ClearFields()
        {
            textidup.Text = "";
            textcompup.Text = "";

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin2 r1 = new Admin2();
            r1.Show();
        }
        private void CreateColums()
        {
            dataGridViewUP.Columns.Add("Id_Builiding_Up", "id");
            dataGridViewUP.Columns.Add("centimetre", "centimetre");
            dataGridViewUP.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRow(DataGridView pip, IDataRecord record)
        {
            pip.Rows.Add(record.GetInt32(0), record.GetInt32(1), RowState.ModifiedNew);
        }
        private void RefrestDatarid(DataGridView pip)
        {
            db.openConnection();
            pip.Rows.Clear();
            string qwertyString = $"select * from Builiding_Up";
            SqlCommand command = new SqlCommand(qwertyString, db.GetSqlConnection());

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(pip, reader);
            }
            reader.Close();
            db.closeConnection();
        }

        private void Builiding_Up_Load(object sender, EventArgs e)
        {
            CreateColums();
            RefrestDatarid(dataGridViewUP);
            dataGridViewUP.Columns[2].Visible = false;
        }

        private void dataGridViewUP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewUP.Rows[SelectedRow];

                textidup.Text = row.Cells[0].Value?.ToString();
                textcompup.Text = row.Cells[1].Value?.ToString();

            }
        }

        private void addburup_Click(object sender, EventArgs e)
        {
            Add_UP addfrm = new Add_UP();
            addfrm.Show();
        }

        private void updatebutup_Click(object sender, EventArgs e)
        {
            RefrestDatarid(dataGridViewUP);
            ClearFields();
        }
        private void Search1(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"select * from Builiding_Up  where concat (Id_Builiding_Up, centimetre) like '%" + searchtextup.Text + "%'";


            SqlCommand com = new SqlCommand(searchString, db.GetSqlConnection());
            db.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow(dgw, read);

            }
            read.Close();

        }

        private void searchtextup_TextChanged(object sender, EventArgs e)
        {
            Search1(dataGridViewUP);
        }
        private void deleteRow()
        {
            int index = dataGridViewUP.CurrentCell.RowIndex;
            dataGridViewUP.Rows[index].Visible = false;

            if (dataGridViewUP.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridViewUP.Rows[index].Cells[2].Value = RowState.Deleted;
                return;
            }
            dataGridViewUP.Rows[index].Cells[2].Value = RowState.Deleted;
        }
        private void Update1()
        {
            db.openConnection();
            for (int index = 0; index < dataGridViewUP.Rows.Count; index++)
            {
                // Проверяем, что значение не null
                if (dataGridViewUP.Rows[index].Cells[2].Value == null)
                    continue;

                var rowState = (RowState)dataGridViewUP.Rows[index].Cells[2].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }

                if (rowState == RowState.Deleted)
                {
                    // Проверяем, что значение не null
                    if (dataGridViewUP.Rows[index].Cells[0].Value == null)
                        continue;

                    var id = Convert.ToInt32(dataGridViewUP.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Builiding_Up where Id_Builiding_Up = {id}";

                    var command = new SqlCommand(deleteQuery, db.GetSqlConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var id = dataGridViewUP.Rows[index].Cells[0].Value.ToString();
                    var idd = dataGridViewUP.Rows[index].Cells[1].Value.ToString();

                    var changeQuery = $"update Nail_Master set type centimetre = '{idd}'";
                    var command = new SqlCommand(changeQuery, db.GetSqlConnection());
                    command.ExecuteNonQuery();
                }
                if (rowState == RowState.Modified)
                {
                    var id = dataGridViewUP.Rows[index].Cells[0].Value.ToString();
                    var type1 = dataGridViewUP.Rows[index].Cells[1].Value.ToString();

                    var changeQuery = $"update Builiding_Up set centimetre = '{type1}' where Id_Builiding_Up = '{id}'";
                    var command = new SqlCommand(changeQuery, db.GetSqlConnection());
                    command.ExecuteNonQuery();
                }

            }
        }
        private void Change()
        {
            var selectedRowIndex = dataGridViewUP.CurrentCell.RowIndex;

            var id = textidup.Text;
            var type = textcompup.Text;

            if (dataGridViewUP.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridViewUP.Rows[selectedRowIndex].SetValues(id, type);
                dataGridViewUP.Rows[selectedRowIndex].Cells[2].Value = RowState.Modified;
            }
        }

        private void sortascdup_Click(object sender, EventArgs e)
        {
            dataGridViewUP.Sort(dataGridViewUP.Columns[1], ListSortDirection.Ascending);
            db.closeConnection();
        }

        private void deletebutup_Click(object sender, EventArgs e)
        {
            deleteRow();
            ClearFields();
        }

        private void savebutup_Click(object sender, EventArgs e)
        {
            Update1();
        }

        private void sortdescdup_Click(object sender, EventArgs e)
        {
            dataGridViewUP.Sort(dataGridViewUP.Columns[1], ListSortDirection.Descending);
        }

        private void changebut_Click(object sender, EventArgs e)
        {
            Change();
        }

        private void clearbut_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }

}


