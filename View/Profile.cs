using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinPlanProject.View
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
            textBox1.Text = "hasusashuashd";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();
            homepage.Show();
        }

        private void btnhomepage_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();
            homepage.Show();
        }
    }
}
