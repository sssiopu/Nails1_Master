﻿using System;
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
    public partial class Repair : Form
    {
        public Repair()
        {
            InitializeComponent();
        }

        private void backbutdes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin2 r1 = new Admin2();
            r1.Show();
        }

        private void addbutrep_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Rep r1 = new Add_Rep();
            r1.Show();
        }
    }
}
