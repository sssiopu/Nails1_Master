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
    public partial class nails : Form
    {
        DB db = new DB();
        int SelectedRow;

        public nails()
        {
            InitializeComponent();
        }

        private void CreateColums()
        {
            dataGridViewN.Columns.Add("Id_Nails", "id");
            dataGridViewN.Columns.Add("Id_Design", "complexity");
            dataGridViewN.Columns.Add("Id_Repair", "number of nails");
            dataGridViewN.Columns.Add("Id_Gender", "gender");
            dataGridViewN.Columns.Add("Id_Builiding_Up", "centimetre");
            dataGridViewN.Columns.Add("Id_Gel_Polish_Coating", "thickness");
            dataGridViewN.Columns.Add("Id_MedicaL_Manicure", "problem");
            dataGridViewN.Columns.Add("Id_Withdrawal", "Whos job is it");
            dataGridViewN.Columns.Add("Price", "price");
            dataGridViewN.Columns.Add("IsNew", String.Empty);
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


        private void nails_Load(object sender, EventArgs e)
        {
            CreateColums();
            RefrestDatarid(dataGridViewN);
            dataGridViewN.Columns[9].Visible = false;
        }

        private void backbutn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin2 r1 = new Admin2();
            r1.Show();
        }

    }
}
