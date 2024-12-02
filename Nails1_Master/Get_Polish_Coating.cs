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


    public partial class Get_Polish_Coating : Form
    {
        DB db = new DB();
        int SelectedRow;

        public Get_Polish_Coating()
        {
            InitializeComponent();
        }
        private void CreateColums()
        {
            dataGridViewGPC.Columns.Add("Id_Gel_Polish_Coating", "id");
            dataGridViewGPC.Columns.Add("thickness", "thickness");
            dataGridViewGPC.Columns.Add("IsNew", String.Empty);
        }
        private void ClearFields()
        {
            textidgpc.Text = "";
            textcompgpc.Text = "";

        }
        private void ReadSingleRow(DataGridView pip, IDataRecord record)
        {
            pip.Rows.Add(record.GetInt32(0), record.GetString(1), RowState.ModifiedNew);
        }
        private void RefrestDatarid(DataGridView pip)
        {
            db.openConnection();
            pip.Rows.Clear();
            string qwertyString = $"select * from Gel_Polish_Coating";
            SqlCommand command = new SqlCommand(qwertyString, db.GetSqlConnection());

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(pip, reader);
            }
            reader.Close();
            db.closeConnection();
        }
        

        private void dataGridViewGPC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewGPC.Rows[SelectedRow];

                textidgpc.Text = row.Cells[0].Value?.ToString();
                textcompgpc.Text = row.Cells[1].Value?.ToString();

            }
        }

        private void addbutgpc_Click(object sender, EventArgs e)
        {

            Add_GPC addfrm = new Add_GPC();
            addfrm.Show();
        }

        private void updatebutgpc_Click(object sender, EventArgs e)
        {
            RefrestDatarid(dataGridViewGPC);
            ClearFields();
        }

        private void Search1(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"select * from Gel_Polish_Coating  where concat (Id_Gel_Polish_Coating, thickness) like '%" + searchtextgpc.Text + "%'";


            SqlCommand com = new SqlCommand(searchString, db.GetSqlConnection());
            db.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow(dgw, read);

            }
            read.Close();
        }

        private void searchtextgpc_TextChanged(object sender, EventArgs e)
        {
            Search1(dataGridViewGPC);
        }
        private void deleteRow()
        {
            int index = dataGridViewGPC.CurrentCell.RowIndex;
            dataGridViewGPC.Rows[index].Visible = false;

            if (dataGridViewGPC.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridViewGPC.Rows[index].Cells[2].Value = RowState.Deleted;
                return;
            }
            dataGridViewGPC.Rows[index].Cells[2].Value = RowState.Deleted;
        }
        private void Update1()
        {
            db.openConnection();
            for (int index = 0; index < dataGridViewGPC.Rows.Count; index++)
            {
                // Проверяем, что значение не null
                if (dataGridViewGPC.Rows[index].Cells[2].Value == null)
                    continue;

                var rowState = (RowState)dataGridViewGPC.Rows[index].Cells[2].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }

                if (rowState == RowState.Deleted)
                {
                    // Проверяем, что значение не null
                    if (dataGridViewGPC.Rows[index].Cells[0].Value == null)
                        continue;

                    var id = Convert.ToInt32(dataGridViewGPC.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Gel_Polish_Coating where Id_Gel_Polish_Coating = {id}";

                    var command = new SqlCommand(deleteQuery, db.GetSqlConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var id = dataGridViewGPC.Rows[index].Cells[0].Value.ToString();
                    var type1 = dataGridViewGPC.Rows[index].Cells[1].Value.ToString();

                    var changeQuery = $"update Gel_Polish_Coating set thickness = '{type1}' where Id_Gel_Polish_Coating = '{id}'";
                    var command = new SqlCommand(changeQuery, db.GetSqlConnection());
                    command.ExecuteNonQuery();
                }

            }


        }
        private void Change()
        {
            var selectedRowIndex = dataGridViewGPC.CurrentCell.RowIndex;

            var id = textidgpc.Text;
            var type = textcompgpc.Text;

            if (dataGridViewGPC.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridViewGPC.Rows[selectedRowIndex].SetValues(id, type);
                dataGridViewGPC.Rows[selectedRowIndex].Cells[2].Value = RowState.Modified;
            }
        }

        private void sortascdgpc_Click(object sender, EventArgs e)
        {
            dataGridViewGPC.Sort(dataGridViewGPC.Columns[1], ListSortDirection.Ascending);
            db.closeConnection();
        }

        private void backbutgpc_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin2 r1 = new Admin2();
            r1.Show();
        }

        private void deletebutgpc_Click(object sender, EventArgs e)
        {
            deleteRow();
            ClearFields();
        }

        private void savebutgpc_Click(object sender, EventArgs e)
        {
            Update1();
        }

        private void sortdescdgpc_Click(object sender, EventArgs e)
        {
            dataGridViewGPC.Sort(dataGridViewGPC.Columns[1], ListSortDirection.Descending);
        }

        private void clearbut_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void changebut_Click(object sender, EventArgs e)
        {
            Change();
        }

        private void Get_Polish_Coating_Load(object sender, EventArgs e)
        {
            CreateColums();
            RefrestDatarid(dataGridViewGPC);
            dataGridViewGPC.Columns[2].Visible = false;
        }
    }
}