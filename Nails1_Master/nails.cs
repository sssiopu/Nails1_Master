using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Nails1_Master
{
    public partial class Nails : Form
    {
        DB db = new DB();
        int SelectedRow;
        private int selectedRow;

        public Nails()
        {
            InitializeComponent();
        }


        private void CreateColumns()
        {
            dataGridViewN.Columns.Add("Id_Nails", "ID");
            dataGridViewN.Columns.Add("Id_Design", "Complexity");
            dataGridViewN.Columns.Add("Id_Repair", "Number of Nails");
            dataGridViewN.Columns.Add("Id_Gender", "Gender");
            dataGridViewN.Columns.Add("Id_Building_Up", "Centimetre");
            dataGridViewN.Columns.Add("Id_Gel_Polish_Coating", "Thickness");
            dataGridViewN.Columns.Add("Id_Medical_Manicure", "Problem");
            dataGridViewN.Columns.Add("Id_Withdrawal", "Who's Job Is It");
            dataGridViewN.Columns.Add("Price", "Price");
            dataGridViewN.Columns.Add("IsNew", "Is New");
        }

        private void ReadSingleRow(DataGridView pip, IDataRecord record)
        {
            pip.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetInt32(4), record.GetString(5), record.GetString(6), record.GetString(7), record.GetInt32(8), RowState.ModifiedNew);
        }

        private void RefrestDatarid(DataGridView pip)
        {
            db.openConnection();
            pip.Rows.Clear();
            string qwertyString = $"select Nails.Id_Nails, Design.complexity, Repair.Number_Of_Nails, Gender.gender, Builiding_Up.centimetre, Gel_Polish_Coating.thickness, Medical_Manicure.problem, Withdrawal.Whos_job_is_it, Nails.price from Nails join Design on Nails.Id_Design = Design.Id_Design join Repair on Nails.Id_Repair = Repair.Id_Repair join Gender on Nails.Id_Gender = Gender.Id_Gender join Builiding_Up on Nails.Id_Building_Up = Builiding_Up.Id_Builiding_Up join Gel_Polish_Coating on Nails.Id_Gel_Polish_Coating = Gel_Polish_Coating.Id_Gel_Polish_Coating join Medical_Manicure on Nails.Id_Medical_Manicure = Medical_Manicure.Id_Medical_Manicure join Withdrawal on Nails.Id_Withdrawal = Withdrawal.Id_Withdrawal";
            SqlCommand command = new SqlCommand(qwertyString, db.GetSqlConnection());

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(pip, reader);
            }
            reader.Close();
            db.closeConnection();
        }


        private void Nails_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefrestDatarid(dataGridViewN);
            dataGridViewN.Columns[9].Visible = false;
        }

        private void dataGridViewN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (selectedRow >= 0)
            {
                DataGridViewRow row = dataGridViewN.Rows[selectedRow];


                textid.Text = row.Cells[0].Value?.ToString();
                textid.Text = row.Cells[1].Value?.ToString();
                textproblem.Text = row.Cells[2].Value?.ToString();
                textnumberofnails.Text = row.Cells[3].Value?.ToString();
                textwhosjobisit.Text = row.Cells[4].Value?.ToString();
                textcantimetre.Text = row.Cells[5].Value?.ToString();
                textgender.Text = row.Cells[6].Value?.ToString();
                textthickness.Text = row.Cells[7].Value?.ToString();
            }
        }

        private void backbutn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin2 adminForm = new Admin2();
            adminForm.Show();
        }
        
        private void ClearFields()
        {
            textid.Text = "";
            textid.Text = "";
            textproblem.Text = "";
            textnumberofnails.Text = "";
            textwhosjobisit.Text = "";
            textcantimetre.Text = "";
            textgender.Text = "";
            textthickness.Text = "";

        }

        private void nailsbut_Click(object sender, EventArgs e)
        {
            Add_N addfrm = new Add_N();
            addfrm.Show();
        }

        private void updatebutn_Click(object sender, EventArgs e)
        {
            RefrestDatarid(dataGridViewN);
            ClearFields();
        }
        private void Search1(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"";


            SqlCommand com = new SqlCommand(searchString, db.GetSqlConnection());
            db.openConnection();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ReadSingleRow(dgw, read);

            }
            read.Close();

        }

        private void searchtextn_TextChanged(object sender, EventArgs e)
        {
            Search1(dataGridViewN);
        }
        private void deleteRow()
        {
            int index = dataGridViewN.CurrentCell.RowIndex;
            dataGridViewN.Rows[index].Visible = false;

            if (dataGridViewN.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridViewN.Rows[index].Cells[2].Value = RowState.Deleted;
                return;
            }
            dataGridViewN.Rows[index].Cells[2].Value = RowState.Deleted;
        }
        private void Update1()
        {
            db.openConnection();
            for (int index = 0; index < dataGridViewN.Rows.Count; index++)
            {
                // Проверяем, что значение не null
                if (dataGridViewN.Rows[index].Cells[2].Value == null)
                    continue;

                var rowState = (RowState)dataGridViewN.Rows[index].Cells[2].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }

                if (rowState == RowState.Deleted)
                {

                    if (dataGridViewN.Rows[index].Cells[0].Value == null)
                        continue;

                    var id = Convert.ToInt32(dataGridViewN.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Nails where  = {id}";

                    var command = new SqlCommand(deleteQuery, db.GetSqlConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var id = dataGridViewN.Rows[index].Cells[0].Value.ToString();
                    var type1 = dataGridViewN.Rows[index].Cells[1].Value.ToString();

                    var changeQuery = $"update Nails set  = '' where  = ''";
                    var command = new SqlCommand(changeQuery, db.GetSqlConnection());
                    command.ExecuteNonQuery();
                }

            }
        }
        private void Change()
        {
            var selectedRowIndex = dataGridViewN.CurrentCell.RowIndex;

            var id =  "";
            var type = "";

            if (dataGridViewN.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridViewN.Rows[selectedRowIndex].SetValues(id, type);
                dataGridViewN.Rows[selectedRowIndex].Cells[2].Value = RowState.Modified;
            }
        }

        private void sortascdn_Click(object sender, EventArgs e)
        {
            dataGridViewN.Sort(dataGridViewN.Columns[1], ListSortDirection.Ascending);
            db.closeConnection();
        }

        private void deletebutn_Click(object sender, EventArgs e)
        {
            deleteRow();
            ClearFields();
        }

        private void savebutn_Click(object sender, EventArgs e)
        {
            Update1();
        }

        private void sortdescdn_Click(object sender, EventArgs e)
        {
            dataGridViewN.Sort(dataGridViewN.Columns[1], ListSortDirection.Descending);
        }

        private void clearbut_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void changebutn_Click(object sender, EventArgs e)
        {
            Change();
        }
    }
}




