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
    enum RowState2
    {
        Execute,
        New,
        Modified,
        ModifiedNew,
        Deleted,
        Existed

    }
    public partial class Gender : Form
    {
        DB db = new DB();
        int SelectedRow;

        public Gender()
        {
            InitializeComponent();
        }

        private void backbutdes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin2 r1 = new Admin2();
            r1.Show();
        }
        private void CreateColums()
        {
            dataGridViewgen.Columns.Add("Id_Gender", "id");
            dataGridViewgen.Columns.Add("gender", "gender");
            dataGridViewgen.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRow1(DataGridView pip, IDataRecord record)
        {
            pip.Rows.Add(record.GetInt32(0), record.GetString(1), RowState.ModifiedNew);
        }
        private void RefrestDatarid1(DataGridView pip)
        {
            db.openConnection();
            pip.Rows.Clear();
            string qwertyString = $"select * from Gender";
            SqlCommand command = new SqlCommand(qwertyString, db.GetSqlConnection());

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow1(pip, reader);
            }
            reader.Close();
            db.closeConnection();
        }
       
    }
}
