using FinPlanProject.Model.Context;
using FinPlanProject.Model.Entity;
using FinPlanProject.Model.Repository;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinPlanProject.View
{
    public partial class Profile : Form
    {
        private UserRepository userRepository; // Deklarasi objek UserRepository

        //private String username = "difa";
        //private String nama = "Difa Dlyaulhaq";
        //private String email = "difa@gmail.com";

        public Profile(User user)
        {
            InitializeComponent();
            // Inisialisasi objek UserRepository dengan DbContext yang sesuai
            userRepository = new UserRepository(new DbContext()); // Ganti DbContext sesuai dengan yang Anda gunakan
            LoadUserInfo(user);
        }

        private void LoadUserInfo(User user)
        {
            labelUsername.Text = user.Name;
            labelNama.Text = user.Name;
            labelEmail.Text = user.Email;
            //string enteredUsername = usernametxt.Text; // Isi dengan username yang ingin Anda ambil informasinya

            //labelUsername.Text = userInfo.Username; // Menampilkan username di textBox1
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();
            homepage.Show();
            this.Hide();
        }

        private void btnhomepage_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();
            homepage.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Event handler untuk perubahan di textBox2
        }

    }
}
