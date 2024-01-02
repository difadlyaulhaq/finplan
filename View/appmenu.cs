using System;
using System.Windows.Forms;
using FinPlanProject.Model.Entity;
using FinPlanProject.View;

namespace FinPlanProject.View
{
    public partial class appmenu : Form
    {
        User CurrentUser = null;
        public appmenu(User user)
        {
            this.CurrentUser = user;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnhomepage_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();
            homepage.Show();
            this.Hide();
        }

        private void btnprofile_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile(CurrentUser);
            profile.Show();
            this.Hide();
        }
    }
}
