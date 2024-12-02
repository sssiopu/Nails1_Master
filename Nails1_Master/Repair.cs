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
    public partial class Repair : Form
    {
        DB db = new DB();
        int SelectedRow;
        public Repair()
        {
            InitializeComponent();
        }

        private void backbutdes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin2 r1 = new Admin2();
            r1.Show();
        }

        private void addbutrep_Click(object sender, EventArgs e)
        {
            Add_Rep addfrm = new Add_Rep();
            addfrm.Show();
        }

        private void CreateColums()
        {
            dataGridViewREP.Columns.Add("Id_Repair", "id");
            dataGridViewREP.Columns.Add("Number_Of_Nails", "Number_Of_Nails");
            dataGridViewREP.Columns.Add("IsNew", String.Empty);
        }
        private void ClearFields()
        {
            textidrep.Text = "";
            textcomprep.Text = "";

        }
        private void ReadSingleRow(DataGridView pip, IDataRecord record)
        {
            pip.Rows.Add(record.GetInt32(0), record.GetString(1), RowState.ModifiedNew);
        }

        private void RefrestDatarid(DataGridView pip)
        {
            db.openConnection();
            pip.Rows.Clear();
            string qwertyString = $"select * from Repair";
            SqlCommand command = new SqlCommand(qwertyString, db.GetSqlConnection());

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(pip, reader);
            }
            reader.Close();
            db.closeConnection();
        }

      

        private void Repair_Load(object sender, EventArgs e)
        {
            CreateColums();
            RefrestDatarid(dataGridViewREP);
            dataGridViewREP.Columns[2].Visible = false;
        }

        private void dataGridViewREP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewREP.Rows[SelectedRow];

                textidrep.Text = row.Cells[0].Value?.ToString();
                textcomprep.Text = row.Cells[1].Value?.ToString();

            }
        }

        private void updatebutrep_Click(object sender, EventArgs e)
        {
            RefrestDatarid(dataGridViewREP);
            ClearFields();
        }

        private void searchtextrep_TextChanged(object sender, EventArgs e)
        {
            Search1(dataGridViewREP);       
        }
        private void Search1(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"select * from Repair where concat (Id_Repair, Number_Of_Nails) like '%" + searchtextrep.Text + "%'";


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
            int index = dataGridViewREP.CurrentCell.RowIndex;
            dataGridViewREP.Rows[index].Visible = false;

            if (dataGridViewREP.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridViewREP.Rows[index].Cells[2].Value = RowState.Deleted;
                return;
            }
            dataGridViewREP.Rows[index].Cells[2].Value = RowState.Deleted;
        }
        private void Update1()
        {
            db.openConnection();
            for (int index = 0; index < dataGridViewREP.Rows.Count; index++)
            {
                // Проверяем, что значение не null
                if (dataGridViewREP.Rows[index].Cells[2].Value == null)
                    continue;

                var rowState = (RowState)dataGridViewREP.Rows[index].Cells[2].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }

                if (rowState == RowState.Deleted)
                {
                    // Проверяем, что значение не null
                    if (dataGridViewREP.Rows[index].Cells[0].Value == null)
                        continue;

                    var id = Convert.ToInt32(dataGridViewREP.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Repair where Id_Repair = {id}";

                    var command = new SqlCommand(deleteQuery, db.GetSqlConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified) deleteRow();
                {
                    var id = dataGridViewREP.Rows[index].Cells[0].Value.ToString();
                    var idd = dataGridViewREP.Rows[index].Cells[1].Value.ToString();

                    var changeQuery = $"update Repair set Number_Of_Nails = '{idd}'";
                    var command = new SqlCommand(changeQuery, db.GetSqlConnection());
                    command.ExecuteNonQuery();
                }
                if (rowState == RowState.Modified)
                {
                    var id = dataGridViewREP.Rows[index].Cells[0].Value.ToString();
                    var type1 = dataGridViewREP.Rows[index].Cells[1].Value.ToString();

                    var changeQuery = $"update Repair set Number_Of_Nails = '{type1}' where Id_Repair = '{id}'";
                    var command = new SqlCommand(changeQuery, db.GetSqlConnection());
                    command.ExecuteNonQuery();
                }
            }
        }
        private void Change()
        {
            var selectedRowIndex = dataGridViewREP.CurrentCell.RowIndex;

            var id = textidrep.Text;
            var type = textcomprep.Text;

            if (dataGridViewREP.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridViewREP.Rows[selectedRowIndex].SetValues(id, type);
                dataGridViewREP.Rows[selectedRowIndex].Cells[2].Value = RowState.Modified;
            }
        }

        private void sortascdrep_Click(object sender, EventArgs e)
        {
            dataGridViewREP.Sort(dataGridViewREP.Columns[1], ListSortDirection.Ascending);
            db.closeConnection();
        }

        private void deletebutrep_Click(object sender, EventArgs e)
        {
            deleteRow();
            ClearFields();
        }

        private void savebutrep_Click(object sender, EventArgs e)
        {
            Update1();
        }



        private void sortdescdrep_Click(object sender, EventArgs e)
        {
            dataGridViewREP.Sort(dataGridViewREP.Columns[1], ListSortDirection.Descending);
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
