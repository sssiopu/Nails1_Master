using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            dataGridViewU.Columns.Add("Id_Users", "id");
            dataGridViewU.Columns.Add("Login", "name");
            dataGridViewU.Columns.Add("Password", "name");
            dataGridViewU.Columns.Add("First_Name", "name");
            dataGridViewU.Columns.Add("Last_Name", "name");
            dataGridViewU.Columns.Add("Id_Role", "name");
            dataGridViewU.Columns.Add("IsNew", String.Empty);
        }
    }
}
