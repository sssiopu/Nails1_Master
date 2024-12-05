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
            MainWin r1 = new MainWin();
            r1.Show();
        }
        private void UserPanel_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefrestDatarid(dataGridViewUS);
            dataGridViewUS.Columns[8].Visible = false;
            CreateFilteDesign();
            CreateFilterRepair();
            CreateFilterGender();
            CreateFilterBuiliding_Up();
            CreateFilterGel_Polish_Coating();
            CreateFilterVedical_Manicure();
            CreateFilterWithdrawal();
        }
        private void CreateColumns()
        {
            dataGridViewUS.Columns.Add("Id_Nails", "ID");
            dataGridViewUS.Columns.Add("Id_Design", "Complexity");
            dataGridViewUS.Columns.Add("Id_Repair", "Number of Nails");
            dataGridViewUS.Columns.Add("Id_Gender", "Gender");
            dataGridViewUS.Columns.Add("Id_Builiding_Up", "Centimetre");
            dataGridViewUS.Columns.Add("Id_Gel_Polish_Coating", "Thickness");
            dataGridViewUS.Columns.Add("Id_Medical_Manicure", "Problem");
            dataGridViewUS.Columns.Add("Id_Withdrawal", "Who's Job Is It");
            dataGridViewUS.Columns.Add("IsNew", String.Empty);
        }
        private void ClearFields()
        {
            comboBoxdesign.Text = "";
            comboBoxrepair.Text = "";
            comboBoxgender.Text = "";
            comboBoxbuiliding.Text = "";
            comboBoxgel.Text = "";
            comboBoxmedicine.Text = "";
            comboBoxwithdrawal.Text = "";
            searchtexus.Text = "";
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
                // Проверка на null и пустоту
                var cellValue = row.Cells[1].Value;
                if (cellValue != null && !string.IsNullOrEmpty(cellValue.ToString()))
                {
                    string value = cellValue.ToString();
                    if (!uniqueValues.Contains(value))
                    {
                        comboBoxdesign.Items.Add(value);
                        uniqueValues.Add(value);
                    }
                }
            }
        }

        private void CreateFilterRepair()
        {
            comboBoxdesign.Items.Clear();
            HashSet<string> uniqueValues = new HashSet<string>();
            foreach (DataGridViewRow row in dataGridViewUS.Rows)
            {
                // Проверка на null и пустоту
                var cellValue = row.Cells[2].Value;
                if (cellValue != null && !string.IsNullOrEmpty(cellValue.ToString()))
                {
                    string value = cellValue.ToString();
                    if (!uniqueValues.Contains(value))
                    {
                        comboBoxdesign.Items.Add(value);
                        uniqueValues.Add(value);
                    }
                }
            }
        }
        private void CreateFilterGender()
        {
            comboBoxdesign.Items.Clear();
            HashSet<string> uniqueValues = new HashSet<string>();
            foreach (DataGridViewRow row in dataGridViewUS.Rows)
            {
                // Проверка на null и пустоту
                var cellValue = row.Cells[3].Value;
                if (cellValue != null && !string.IsNullOrEmpty(cellValue.ToString()))
                {
                    string value = cellValue.ToString();
                    if (!uniqueValues.Contains(value))
                    {
                        comboBoxdesign.Items.Add(value);
                        uniqueValues.Add(value);
                    }
                }
            }
        }
        private void CreateFilterBuiliding_Up()
        {
            comboBoxdesign.Items.Clear();
            HashSet<string> uniqueValues = new HashSet<string>();
            foreach (DataGridViewRow row in dataGridViewUS.Rows)
            {
                // Проверка на null и пустоту
                var cellValue = row.Cells[4].Value;
                if (cellValue != null && !string.IsNullOrEmpty(cellValue.ToString()))
                {
                    string value = cellValue.ToString();
                    if (!uniqueValues.Contains(value))
                    {
                        comboBoxdesign.Items.Add(value);
                        uniqueValues.Add(value);
                    }
                }
            }
        }
        private void CreateFilterGel_Polish_Coating()
        {
            comboBoxdesign.Items.Clear();
            HashSet<string> uniqueValues = new HashSet<string>();
            foreach (DataGridViewRow row in dataGridViewUS.Rows)
            {
                // Проверка на null и пустоту
                var cellValue = row.Cells[5].Value;
                if (cellValue != null && !string.IsNullOrEmpty(cellValue.ToString()))
                {
                    string value = cellValue.ToString();
                    if (!uniqueValues.Contains(value))
                    {
                        comboBoxdesign.Items.Add(value);
                        uniqueValues.Add(value);
                    }
                }
            }
        }
        private void CreateFilterVedical_Manicure()
        {
            comboBoxdesign.Items.Clear();
            HashSet<string> uniqueValues = new HashSet<string>();
            foreach (DataGridViewRow row in dataGridViewUS.Rows)
            {
                // Проверка на null и пустоту
                var cellValue = row.Cells[6].Value;
                if (cellValue != null && !string.IsNullOrEmpty(cellValue.ToString()))
                {
                    string value = cellValue.ToString();
                    if (!uniqueValues.Contains(value))
                    {
                        comboBoxdesign.Items.Add(value);
                        uniqueValues.Add(value);
                    }
                }
            }
        }
        private void CreateFilterWithdrawal()
        {
            comboBoxdesign.Items.Clear();
            HashSet<string> uniqueValues = new HashSet<string>();
            foreach (DataGridViewRow row in dataGridViewUS.Rows)
            {
                // Проверка на null и пустоту
                var cellValue = row.Cells[7].Value;
                if (cellValue != null && !string.IsNullOrEmpty(cellValue.ToString()))
                {
                    string value = cellValue.ToString();
                    if (!uniqueValues.Contains(value))
                    {
                        comboBoxdesign.Items.Add(value);
                        uniqueValues.Add(value);
                    }
                }
            }
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
            string searchSql = "SELECT Nails.Id_Nails, Design.complexity, Repair.Number_Of_Nails, Gender.gender, " +
                               "Builiding_Up.centimetre, Gel_Polish_Coating.thickness, Medical_Manicure.problem, " +
                               "Withdrawal.Whos_job_is_it, Nails.price " +
                               "FROM Nails " +
                               "JOIN Design ON Nails.Id_Design = Design.Id_Design " +
                               "JOIN Repair ON Nails.Id_Repair = Repair.Id_Repair " +
                               "JOIN Gender ON Nails.Id_Gender = Gender.Id_Gender " +
                               "JOIN Builiding_Up ON Nails.Id_Building_Up = Builiding_Up.Id_Builiding_Up " +
                               "JOIN Gel_Polish_Coating ON Nails.Id_Gel_Polish_Coating = Gel_Polish_Coating.Id_Gel_Polish_Coating " +
                               "JOIN Medical_Manicure ON Nails.Id_Medical_Manicure = Medical_Manicure.Id_Medical_Manicure " +
                               "JOIN Withdrawal ON Nails.Id_Withdrawal = Withdrawal.Id_Withdrawal";

            List<string> conditions = new List<string>();

            if (!string.IsNullOrWhiteSpace(searchtexus.Text))
            {
                conditions.Add($"CONCAT(Nails.Id_Nails, Design.complexity, Repair.Number_Of_Nails, " +
                                $"Gender.gender, Builiding_Up.centimetre, Gel_Polish_Coating.thickness, " +
                                $"Medical_Manicure.problem, Withdrawal.Whos_job_is_it, Nails.price) " +
                                $"LIKE '%{searchtexus.Text}%'");
            }

            if (!string.IsNullOrEmpty(comboBoxdesign.Text))
            {
                conditions.Add($"Nails.Id_Design IN (SELECT Design.Id_Design FROM Design WHERE complexity = @complexity)");
            }

            if (!string.IsNullOrEmpty(comboBoxrepair.Text))
            {
                conditions.Add($"Nails.Id_Repair IN (SELECT Repair.Id_Repair FROM Repair WHERE Number_Of_Nails = @numberOfNails)");
            }

            if (!string.IsNullOrEmpty(comboBoxgender.Text))
            {
                conditions.Add($"Nails.Id_Gender IN (SELECT Gender.Id_Gender FROM Gender WHERE gender = @gender)");
            }

            if (!string.IsNullOrEmpty(comboBoxbuiliding.Text))
            {
                conditions.Add($"Nails.Id_Building_Up IN (SELECT Builiding_Up.Id_Builiding_Up FROM Builiding_Up WHERE centimetre = @centimetre)");
            }

            if (!string.IsNullOrEmpty(comboBoxgel.Text))
            {
                conditions.Add($"Nails.Id_Gel_Polish_Coating IN (SELECT Gel_Polish_Coating.Id_Gel_Polish_Coating FROM Gel_Polish_Coating WHERE thickness = @thickness)");
            }

            if (!string.IsNullOrEmpty(comboBoxmedicine.Text))
            {
                conditions.Add($"Nails.Id_Medical_Manicure IN (SELECT Medical_Manicure.Id_Medical_Manicure FROM Medical_Manicure WHERE problem = @problem)");
            }

            if (!string.IsNullOrEmpty(comboBoxwithdrawal.Text))
            {
                conditions.Add($"Nails.Id_Withdrawal IN (SELECT Withdrawal.Id_Withdrawal FROM Withdrawal WHERE Whos_job_is_it = @whosJobIsIt)");
            }

            if (conditions.Count > 0)
            {
                searchSql += " WHERE " + string.Join(" AND ", conditions);
            }

            SqlCommand command = new SqlCommand(searchSql, db.GetSqlConnection());
            command.Parameters.AddWithValue("@complexity", comboBoxdesign.Text);
            command.Parameters.AddWithValue("@numberOfNails", comboBoxrepair.Text);
            command.Parameters.AddWithValue("@gender", comboBoxgender.Text);
            command.Parameters.AddWithValue("@centimetre", comboBoxbuiliding.Text);
            command.Parameters.AddWithValue("@thickness", comboBoxgel.Text);
            command.Parameters.AddWithValue("@problem", comboBoxmedicine.Text);
            command.Parameters.AddWithValue("@whosJobIsIt", comboBoxwithdrawal.Text);

            db.openConnection();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgv, reader);
            }

            reader.Close();
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

