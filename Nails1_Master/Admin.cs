using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nails1_Master
{
    enum RowState
    {
        Execute,
        New,
        Modified,
        ModifiedNew,
        Deleted,
        Existed

    }

    public partial class Admin : Form

    {


        DB db = new DB();
        int SelectedRow;

        public Admin()
        {
            InitializeComponent();
        }
        private void CreateColums()
        {
            dataGridView1.Columns.Add("Id_Design", "id");
            dataGridView1.Columns.Add("complexity", "complexity");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow(DataGridView pip, IDataRecord record)
        {
            pip.Rows.Add(record.GetInt32(0), record.GetString(1), RowState.ModifiedNew);
        }
        private void RefrestDatarid(DataGridView pip)
        {
            db.openConnection();
            pip.Rows.Clear();
            string qwertyString = $"select * from Design";
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
            RefrestDatarid(dataGridView1);
            dataGridView1.Columns[2].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[SelectedRow];

                textid.Text = row.Cells[0].Value?.ToString();
                textcomp.Text = row.Cells[1].Value?.ToString();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_design addfrm = new Add_design();
            addfrm.Show();
        }

        private void updatebut_Click(object sender, EventArgs e)
        {
            RefrestDatarid(dataGridView1);
        }

        private void Search1(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"select * from Design  where concat (Id_Design, complexity) like '%" + searchtext.Text + "%'";


            SqlCommand com = new SqlCommand(searchString, db.GetSqlConnection());
            db.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow(dgw, read);

            }
            read.Close();

        }
        private void searchtext_TextChanged(object sender, EventArgs e)
        {
            Search1(dataGridView1);
        }



        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[2].Value = RowState.Deleted;
                return;
            }
            dataGridView1.Rows[index].Cells[2].Value = RowState.Deleted;
        }



        private void Update1()
        {
            db.openConnection();
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                // Проверяем, что значение не null
                if (dataGridView1.Rows[index].Cells[2].Value == null)
                    continue;

                var rowState = (RowState)dataGridView1.Rows[index].Cells[2].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }

                if (rowState == RowState.Deleted)
                {
                    // Проверяем, что значение не null
                    if (dataGridView1.Rows[index].Cells[0].Value == null)
                        continue;

                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Design where Id_Design = {id}";

                    var command = new SqlCommand(deleteQuery, db.GetSqlConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var idd = dataGridView1.Rows[index].Cells[1].Value.ToString();

                    var changeQuery = $"update Design set complexity = '{idd}' where Id_Design = '{id}'";
                    var command = new SqlCommand(changeQuery, db.GetSqlConnection());
                    command.ExecuteNonQuery();
                }

            }
        }
        private void Change()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var id = textid.Text;
            var type = textcomp.Text;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString()!= string.Empty)
            {
                dataGridView1.Rows[selectedRowIndex].SetValues(id, type);
                dataGridView1.Rows[selectedRowIndex].Cells[2].Value = RowState.Modified;
            }
        }
             



       





      

        
       


        

       

        private void sortascd_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
            db.closeConnection();
        }

        private void backbutdes_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Admin2 r1 = new Admin2();
            r1.Show();
        }

        private void deletebut_Click_1(object sender, EventArgs e)
        {
            deleteRow();
        }

        private void savebut_Click_1(object sender, EventArgs e)
        {
            Update1();
        }

        private void sortdescd_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Descending);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Change();
        }

        
    }
}






