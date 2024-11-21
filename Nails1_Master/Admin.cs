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
    enum RowState
    {
        Extend,
        New,
        Modified,
        ModifiedNew,
        Deleted

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

        private void ReadSingleRow (DataGridView pip, IDataRecord record)
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
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = e.RowIndex;

            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[SelectedRow];

                textid.Text = row.Cells[0].Value.ToString();
                textcomp.Text = row.Cells[1].Value.ToString();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_design addfrm = new Add_design();
            addfrm.Show();
        }
    }
}
