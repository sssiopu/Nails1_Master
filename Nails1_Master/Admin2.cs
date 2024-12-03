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
    public partial class Admin2 : Form
    {
        public Admin2()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin r1 = new Admin();
            r1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Builiding_Up r1 = new Builiding_Up();
            r1.Show();
        }

        private void getpbut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Get_Polish_Coating r1 = new Get_Polish_Coating();
            r1.Show();
        }

        private void medadbut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Medical_Manicure r1 = new Medical_Manicure();
            r1.Show();
        }

        private void genadbut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Gender r1 = new Gender();
            r1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Repair r1 = new Repair();
            r1.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Withdrawal r1 = new Withdrawal();
            r1.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Nails r1 = new Nails();
            r1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Role r1 = new Role();
            r1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users r1 = new Users();
            r1.Show();
        }
    }
}
