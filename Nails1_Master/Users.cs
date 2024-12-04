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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Nails1_Master
{
    public partial class Users : Form
    {
        DB db = new DB();
        int SelectedRow;
        public Users()
        {
            InitializeComponent();
        }

        private void backbutus_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin2 r1 = new Admin2();
            r1.Show();
        }
        private void CreateColumns()
        {
            dataGridViewUU.Columns.Add("Id_Users", "id");
            dataGridViewUU.Columns.Add("Login", "Login");
            dataGridViewUU.Columns.Add("Password", "Password");
            dataGridViewUU.Columns.Add("First_Name", "First_Name");
            dataGridViewUU.Columns.Add("Last_Name", "Last_Name");
            dataGridViewUU.Columns.Add("Id_Role", "Id_Role");
            dataGridViewUU.Columns.Add("IsNew", String.Empty);
        }
        private void ClearFields()
        {
            textiduss.Text = "";
            textcompuss.Text = "";
            textnameuss.Text = "";
            textlastuss.Text = "";
            textloginuss.Text = "";
            textpassworduss.Text = "";
        }
        private void ReadSingleRow(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgv)
        {

            db.openConnection();
            dgv.Rows.Clear();

            string QueryString = $"select Users.Id_Users, Users.Login, Users.Password, Users.First_Name, Users.Last_Name, Role_Users.name from Users join Role_Users ON Users.Id_Role = Role_Users.ID_Role_Users";
            SqlCommand cmd = new SqlCommand(QueryString, db.GetSqlConnection());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgv, reader);
            }
            reader.Close();
            db.closeConnection();
        }
        private void CreateFilter()
        {
            comboBoxUU.Items.Clear();
            HashSet<string> uniqueValues = new HashSet<string>();
            foreach (DataGridViewRow row in dataGridViewUU.Rows)
            {
                if (row.Cells[5].Value != null) // Проверка на null 
                {
                    string value = row.Cells[5].Value.ToString();
                    if (!uniqueValues.Contains(value))
                    {
                        comboBoxUU.Items.Add(value);
                        uniqueValues.Add(value);
                    }
                }
            }
        }
        private void deleteRow()
        {
            int index = dataGridViewUU.CurrentCell.RowIndex;
            dataGridViewUU.Rows[index].Visible = false;

            if (dataGridViewUU.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridViewUU.Rows[index].Cells[2].Value = RowState.Deleted;
                return;
            }
            dataGridViewUU.Rows[index].Cells[2].Value = RowState.Deleted;
        }
        
        private void cleatbutuss_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void changebutuss_Click(object sender, EventArgs e)
        {
            Change();
            ClearFields();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridViewUU);
            dataGridViewUU.Columns[6].Visible = false;
            CreateFilter();
        }

        private void dataGridViewUU_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewUU.Rows[SelectedRow];

                textiduss.Text = row.Cells[0].Value.ToString();
                textcompuss.Text = row.Cells[5].Value.ToString();
                textnameuss.Text = row.Cells[3].Value.ToString();
                textlastuss.Text = row.Cells[4].Value.ToString();
                textloginuss.Text = row.Cells[1].Value.ToString();
                textpassworduss.Text = row.Cells[2].Value.ToString();

            }
        }

        private void updatebutuss_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridViewUU);
            ClearFields();
            CreateFilter();
        }
        private void Search(DataGridView dgv)
        {
            dgv.Rows.Clear();
            string SearchString = $"select Users.Id_Users, Users.Login, Users.Password, Users.First_Name, Users.Last_Name, Role_Users.name from Users join Role_Users ON Users.Id_Role = Role_Users.ID_Role_Users where concat (Users.Id_Users, Users.Login, Users.Password, Users.First_Name, Users.Last_Name, Role_Users.name)  like '%" + searchtextuss.Text + "%'";
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

        private void searchtextuss_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridViewUU);
        }
        private void DeleteRow()
        {
            int index = dataGridViewUU.CurrentCell.RowIndex;

            dataGridViewUU.Rows[index].Visible = false;

            if (dataGridViewUU.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridViewUU.Rows[index].Cells[6].Value = RowState.Deleted;
                return;
            }
            dataGridViewUU.Rows[index].Cells[4].Value = RowState.Deleted;
        }
        private void Update1()
        {
            db.openConnection();

            for (int index = 0; index < dataGridViewUU.Rows.Count; index++)
            {
                var RowState = (RowState)dataGridViewUU.Rows[index].Cells[5].Value;
                if (RowState == RowState.Existed)
                {
                    continue;
                }
                if (RowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridViewUU.Rows[index].Cells[0].Value);
                    var DeleteQuery = $"delete from Users where Id_Users = {id}";

                    var command = new SqlCommand(DeleteQuery, db.GetSqlConnection());
                    command.ExecuteNonQuery();
                }
                if (RowState == RowState.Modified)
                {
                    var Id = dataGridViewUU.Rows[index].Cells[0].Value.ToString();
                    var Login = dataGridViewUU.Rows[index].Cells[1].Value.ToString();
                    var Password = dataGridViewUU.Rows[index].Cells[2].Value.ToString();
                    var First_Name = dataGridViewUU.Rows[index].Cells[3].Value.ToString();
                    var Last_Name = dataGridViewUU.Rows[index].Cells[4].Value.ToString();
                    var Role = dataGridViewUU.Rows[index].Cells[5].Value.ToString();

                    int IdRole = GetRoleIdFromName(Role);
                    SqlCommand cmd = new SqlCommand("select * from Users where Login='" + Login + "' and Id_Users != '" + Id + "'", db.GetSqlConnection());
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (IdRole == -1 || dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Login already exist or Role_Users '" + Role + "' not found in the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        var ChangeQuery = $"update Users set Login = '{Login}', Password = '{Password}', Id_Role_Users = '{IdRole}' where Id_Users = '{Id}'";
                        var command = new SqlCommand(ChangeQuery, db.GetSqlConnection());
                        command.ExecuteNonQuery();
                    }
                }
            }
            db.closeConnection();
        }
        private int GetRoleIdFromName(string roleName)
        {
            string query = $"SELECT Id_Role_Users FROM Role_Users WHERE name = '{roleName}'";
            SqlCommand command = new SqlCommand(query, db.GetSqlConnection());
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                if (reader.Read())
                {
                    return reader.GetInt32(0);

                }
                else
                {

                    return -1;
                }
            }
            finally
            {
                reader.Close();
            }

        }
        private void Change()
        {
            var SelectedRowIndex = dataGridViewUU.CurrentCell.RowIndex;
            var Id = textiduss.Text;
            var Login = textloginuss.Text;
            var Pswd = textpassworduss.Text;
            var name = textnameuss.Text;
            var last = textlastuss.Text;
            var Role = textcompuss.Text;
            if (textiduss.Text != string.Empty && textloginuss.Text != string.Empty && textpassworduss.Text != string.Empty && textnameuss.Text != string.Empty && textlastuss.Text != string.Empty && textcompuss.Text != string.Empty)
            {
                dataGridViewUU.Rows[SelectedRowIndex].SetValues(Id, Login, Pswd, name, last, Role);
                dataGridViewUU.Rows[SelectedRowIndex].Cells[6].Value = RowState.Modified;
            }
        }

        private void savebutuss_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void deletebutuss_Click(object sender, EventArgs e)
        {
            DeleteRow();
            ClearFields();
        }

        private void sortascduss_Click(object sender, EventArgs e)
        {
            dataGridViewUU.Sort(dataGridViewUU.Columns[1], ListSortDirection.Ascending);
        }

        private void sortdescduss_Click(object sender, EventArgs e)
        {
            dataGridViewUU.Sort(dataGridViewUU.Columns[1], ListSortDirection.Descending);
        }
        private void Filter(DataGridView dgv)
        {
            dgv.Rows.Clear();

            // Лучше использовать параметризованный запрос для предотвращения SQL-инъекций
            var searchString = @"
        SELECT Users.Id_Users, Users.Login, Users.Password, Users.First_Name, Users.Last_Name, Role_Users.Name
        FROM Users 
        JOIN Role_Users ON Users.Id_Role = Role_Users.Id_Role_Users
        WHERE Role_Users.Name = @RoleName";

            using (SqlCommand com = new SqlCommand(searchString, db.GetSqlConnection()))
            {
                // Устанавливаем параметр в запросе
                com.Parameters.AddWithValue("@RoleName", comboBoxUU.Text);

                db.openConnection();

                using (SqlDataReader read = com.ExecuteReader())
                {
                    while (read.Read())
                    {
                        ReadSingleRow(dgv, read);
                    }
                }

                db.closeConnection();
            }
        }




        private void comboBoxUU_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter(dataGridViewUU);
        }


    }




}

