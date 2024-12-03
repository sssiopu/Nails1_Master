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
        private void CreateColums()
            {
        //    dataGridViewUU.Columns.Add("Id_Users", "id");
        //    dataGridViewUU.Columns.Add("Login", "Login");
        //    dataGridViewUU.Columns.Add("Password", "Password");
        //    dataGridViewUU.Columns.Add("First_Name", "First_Name");
        //    dataGridViewUU.Columns.Add("Last_Name", "Last_Name");
        //    dataGridViewUU.Columns.Add("Id_Role", "Id_Role");
        //    dataGridViewUU.Columns.Add("IsNew", String.Empty);
        }
        private void ClearFields()
        {
            //textidsuss.Text = "";
            //textcompuss.Text = "";
            //textnameuss.Text = "";
            //textlastuss.Text = "";
            //textloginuss.Text = "";
            //textpassworduss.Text = "";
        }
        private void ReadSingleRow(DataGridView dgv, IDataRecord record)
        {
            //dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetInt32(5), RowState.ModifiedNew);
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
        private void Search1(DataGridView dgw)
        {
            //dgw.Rows.Clear();
            //string searchString = $"select * from Users where concat (Id_Users, Login, Password, First_Name, Last_Name, Id_Role) like '%" + searchtextuss.Text + "%'";


            //SqlCommand com = new SqlCommand(searchString, db.GetSqlConnection());
            //db.openConnection();
            //SqlDataReader read = com.ExecuteReader();
            //while (read.Read())
            //{
            //    ReadSingleRow(dgw, read);

            //}
            //read.Close();

        }
        private void deleteRow()
        {
            //int index = dataGridViewUU.CurrentCell.RowIndex;
            //dataGridViewUU.Rows[index].Visible = false;

            //if (dataGridViewUU.Rows[index].Cells[0].Value.ToString() == string.Empty)
            //{
            //    dataGridViewUU.Rows[index].Cells[2].Value = RowState.Deleted;
            //    return;
            //}
            //dataGridViewUU.Rows[index].Cells[2].Value = RowState.Deleted;
        }
        private void Update1()
        {
            //db.openConnection();
            //var rowState = (RowState)dataGridViewUU.Rows[index].Cells[2].Value;

            //if (rowState == RowState.Existed)
            //{
            //    continue;
            //}

            //if (rowState == RowState.Deleted)
            //{
            //    // Проверяем, что значение не null
            //    if (dataGridViewgen.Rows[index].Cells[0].Value == null)
            //        continue;

            //    var id = Convert.ToInt32(dataGridViewgen.Rows[index].Cells[0].Value);
            //    var deleteQuery = $"delete from gender where Id_Gender = {id}";

            //    var command = new SqlCommand(deleteQuery, db.GetSqlConnection());
            //    command.ExecuteNonQuery();
            //}
            //if (rowState == RowState.Modified)
            //{
            //    var id = dataGridViewgen.Rows[index].Cells[0].Value.ToString();
            //    var type1 = dataGridViewgen.Rows[index].Cells[1].Value.ToString();

            //    var changeQuery = $"update Users set  = '{type1}' where Id_Users = '{id}'";
            //    var command = new SqlCommand(changeQuery, db.GetSqlConnection());
            //    command.ExecuteNonQuery();
            //}
        }
       
      }




}

