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
    enum RowStateGPC
    {
        Execute,
        New,
        Modified,
        ModifiedNew,
        Deleted,
        Existed

    }

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
        private void Get_Polish_Coating_Load(object sender, EventArgs e)
        {
            CreateColums();
            RefrestDatarid(dataGridViewGPC);
            dataGridViewGPC.Columns[2].Visible = false;
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
       

        private void updatebutgpc_Click(object sender, EventArgs e)
        {
            RefrestDatarid(dataGridViewGPC);
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin2 r1 = new Admin2();
            r1.Show();
        }

        private void addbutgpc_Click(object sender, EventArgs e)
        {
            Add_GPC addfrm = new Add_GPC();
            addfrm.Show();
        }
    }
}
