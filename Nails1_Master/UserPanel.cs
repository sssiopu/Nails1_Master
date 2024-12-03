using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Nails1_Master
{
    public partial class UserPanel : Form
    {
        DB db = new DB();
        int SelectedRow;
        public UserPanel()
        {
            InitializeComponent();
        }

        private void LogBut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin2 r1 = new Admin2();
            r1.Show();
        }
        private void CreateColumns()
        {
            dataGridViewUS.Columns.Add("Id_Nails", "ID");
            dataGridViewUS.Columns.Add("Id_Design", "Complexity");
            dataGridViewUS.Columns.Add("Id_Repair", "Number of Nails");
            dataGridViewUS.Columns.Add("Id_Gender", "Gender");
            dataGridViewUS.Columns.Add("Id_Building_Up", "Centimetre");
            dataGridViewUS.Columns.Add("Id_Gel_Polish_Coating", "Thickness");
            dataGridViewUS.Columns.Add("Id_Medical_Manicure", "Problem");
            dataGridViewUS.Columns.Add("Id_Withdrawal", "Who's Job Is It");
            dataGridViewUS.Columns.Add("IsNew", "Is New");
        }
        private void ClearFields()
        {
            comboBoxdesign.Text = "";
            comboBoxrepair.Text = "";
            comboBoxgender.Text = "";
            comboBoxbuiliding.Text = "";
            comboBoxgel.Text = "";
            comboBoxmedicine.Text = "";
            comboBoxwithdrawal  .Text = "";
            

        }
        private void ReadSingleRow(DataGridView pip, IDataRecord record)
        {
            pip.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetInt32(4), record.GetString(5), record.GetString(6), record.GetString(7), record.GetInt32(8), RowState.Modified);
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
        private void CreateFilteDesign()
        {
            comboBoxdesign.Items.Clear();
            HashSet<string> uniqueValues = new HashSet<string>();
            foreach (DataGridViewRow row in dataGridViewUS.Rows)
            {
                string value = row.Cells[1].Value.ToString();
                if (!uniqueValues.Contains(value))
                {
                    comboBoxdesign.Items.Add(value);
                    uniqueValues.Add(value);
                }
            }
        }
        private void CreateFilterRepair()
        {
            comboBoxrepair.Items.Clear();
            HashSet<string> uniqueValues = new HashSet<string>();
            foreach (DataGridViewRow row in dataGridViewUS.Rows)
            {
                string value = row.Cells[2].Value.ToString();
                if (!uniqueValues.Contains(value))
                {
                    comboBoxrepair.Items.Add(value);
                    uniqueValues.Add(value);
                }
            }
        }
        private void CreateFilterGender()
        {
            comboBoxgender.Items.Clear();
            HashSet<string> uniqueValues = new HashSet<string>();
            foreach (DataGridViewRow row in dataGridViewUS.Rows)
            {
                string value = row.Cells[3].Value.ToString();
                if (!uniqueValues.Contains(value))
                {
                    comboBoxgender.Items.Add(value);
                    uniqueValues.Add(value);
                }
            }
        }
        private void CreateFilterBuiliding_Up()
        {
            comboBoxbuiliding.Items.Clear();
            HashSet<string> uniqueValues = new HashSet<string>();
            foreach (DataGridViewRow row in dataGridViewUS.Rows)
            {
                string value = row.Cells[4].Value.ToString();
                if (!uniqueValues.Contains(value))
                {
                    comboBoxbuiliding.Items.Add(value);
                    uniqueValues.Add(value);
                }
            }
        }
        private void CreateFilterGel_Polish_Coating()
        {
            comboBoxgel.Items.Clear();
            HashSet<string> uniqueValues = new HashSet<string>();
            foreach (DataGridViewRow row in dataGridViewUS.Rows)
            {
                string value = row.Cells[5].Value.ToString();
                if (!uniqueValues.Contains(value))
                {
                    comboBoxgel.Items.Add(value);
                    uniqueValues.Add(value);
                }
            }
        }
        private void CreateFilterVedical_Manicure()
        {
            comboBoxmedicine.Items.Clear();
            HashSet<string> uniqueValues = new HashSet<string>();
            foreach (DataGridViewRow row in dataGridViewUS.Rows)
            {
                string value = row.Cells[6].Value.ToString();
                if (!uniqueValues.Contains(value))
                {
                    comboBoxmedicine.Items.Add(value);
                    uniqueValues.Add(value);
                }
            }
        }
        private void CreateFilterWithdrawal()
        {
            comboBoxwithdrawal.Items.Clear();
            HashSet<string> uniqueValues = new HashSet<string>();
            foreach (DataGridViewRow row in dataGridViewUS.Rows)
            {
                string value = row.Cells[7].Value.ToString();
                if (!uniqueValues.Contains(value))
                {
                    comboBoxwithdrawal.Items.Add(value);
                    uniqueValues.Add(value);
                }
            }
        }

        private void UserPanel_Load(object sender, EventArgs e)
        {
        }


        private void Catalog_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefrestDatarid(dataGridViewUS);
            dataGridViewUS.Columns[9].Visible = false;
            CreateFilteDesign();
            CreateFilterRepair();
            CreateFilterGender();
            CreateFilterBuiliding_Up();
            CreateFilterGel_Polish_Coating();
            CreateFilterVedical_Manicure();
            CreateFilterWithdrawal();
        }

        private void clearbutus_Click(object sender, EventArgs e)
        {
            RefrestDatarid(dataGridViewUS);
            ClearFields();
            CreateFilteDesign();
            CreateFilterRepair();
            CreateFilterGender();
            CreateFilterBuiliding_Up();
            CreateFilterGel_Polish_Coating();
            CreateFilterVedical_Manicure();
            CreateFilterWithdrawal();
        }

        private void searchtexus_TextChanged(object sender, EventArgs e)
        {
            SearchAndFilter(dataGridViewUS);
        }
        private void SearchAndFilter(DataGridView dgv)
        {
            dgv.Rows.Clear();
            string SearchString = $"select Nails.Id_Nails, Design.complexity, Repair.Number_Of_Nails, Gender.gender, Builiding_Up.centimetre, Gel_Polish_Coating.thickness, Medical_Manicure.problem, Withdrawal.Whos_job_is_it, Nails.price from Nails join Design on Nails.Id_Design = Design.Id_Design join Repair on Nails.Id_Repair = Repair.Id_Repair join Gender on Nails.Id_Gender = Gender.Id_Gender join Builiding_Up on Nails.Id_Building_Up = Builiding_Up.Id_Builiding_Up join Gel_Polish_Coating on Nails.Id_Gel_Polish_Coating = Gel_Polish_Coating.Id_Gel_Polish_Coating join Medical_Manicure on Nails.Id_Medical_Manicure = Medical_Manicure.Id_Medical_Manicure join Withdrawal on Nails.Id_Withdrawal = Withdrawal.Id_Withdrawal";

            bool AddedCondition = false;
            if (!string.IsNullOrEmpty(searchtexus.Text))
            {
                SearchString += $"where concat (Nails.Id_Nails, Design.complexity, Repair.Number_Of_Nails, Gender.gender, Builiding_Up.centimetre, Gel_Polish_Coating.thickness, Medical_Manicure.problem, Withdrawal.Whos_job_is_it, Nails.price from Nails) like '%{searchtexus.Text}%'";
                AddedCondition = true;
            }

            if (!string.IsNullOrEmpty(comboBoxdesign.Text))
            {
                SearchString += (AddedCondition ? " AND " : "where ") + $"=Nails.Id_Design = (select Design.Id_design from Design where complexity = '{comboBoxdesign.Text}')";
                AddedCondition = true;
            }

            if (!string.IsNullOrEmpty(comboBoxrepair.Text))
            {
                SearchString += (AddedCondition ? " AND " : "where ") + $"Nails.Repair = (select Repair_Id_Repair from Repair where Number_Of_Nails = '{comboBoxrepair.Text}')";
                AddedCondition = true;
            }
            if (!string.IsNullOrEmpty(comboBoxgender.Text))
            {
                SearchString += (AddedCondition ? " AND " : "where ") + $"Nails.Id_Gender = (select Gender.Id_Gender from Gender where gender = '{comboBoxgender.Text}')";
                AddedCondition = true;
            }
            if (!string.IsNullOrEmpty(comboBoxbuiliding.Text))
            {
                SearchString += (AddedCondition ? " AND " : "where ") + $"Nails.Id_Builiding_Up = (select Builiding_Up.Id_Builiding_Up from Builiding_Up where centimetre = '{comboBoxbuiliding}')";
                AddedCondition = true;
            }
            if (!string.IsNullOrEmpty(comboBoxgel.Text))
            {
                SearchString += (AddedCondition ? " AND " : "where ") + $"Nails.Id_Gel_Polish_Coating = (select Id_Gel_Polish_Coating.Gel_Polish_Coating from Gel_Polish_Coating where thickness = '{comboBoxgel.Text}')";
                AddedCondition = true;
            }
            if (!string.IsNullOrEmpty(comboBoxmedicine.Text))
            {
                SearchString += (AddedCondition ? " AND " : "where ") + $"Nails.Id_Medical_Manicure in (select Id_Medical_Manicure.Medical_Manicure from Medical_Manicure where problem = '{comboBoxmedicine.Text}')";
                AddedCondition = true;
            }
            if (!string.IsNullOrEmpty(comboBoxwithdrawal.Text))
            {
                SearchString += (AddedCondition ? " AND " : "where ") + $"Nails.Id_Withdrawal in (select Id_Withdrawal.Withdrawal from Withdrawal where Whos_job_is_it = '{comboBoxwithdrawal.Text}')";
                AddedCondition = true;
            }


            SqlCommand com = new SqlCommand(SearchString, db.GetSqlConnection());
            db.openConnection();
            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow(dgv, read);
            }
            read.Close();
            db.closeConnection();
        }

        private void comboBoxdesign_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchAndFilter(dataGridViewUS);
        }

        private void comboBoxrepair_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchAndFilter(dataGridViewUS);
        }

        private void comboBoxmedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchAndFilter(dataGridViewUS);
        }

        private void comboBoxgender_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchAndFilter(dataGridViewUS);
        }

        private void comboBoxgel_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchAndFilter(dataGridViewUS);
        }

        private void comboBoxbuiliding_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchAndFilter(dataGridViewUS);
        }

        private void comboBoxwithdrawal_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchAndFilter(dataGridViewUS);
        }
    }
}

