using System;
using System.Windows.Forms;
using FinPlanProject.View;

namespace FinPlanProject.View
{
    public partial class appmenu : Form
    {
        public appmenu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnhomepage_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();
            homepage.Show();
        }

        private void btnprofile_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
        }
    }
}
