using System;
using System.Windows.Forms;
using FinPlanProject.Model.Context;
using FinPlanProject.Model.Repository;

namespace FinPlanProject
{
    public partial class Login : Form
    {
        private readonly Sign_Up signUpForm;

        public Login()
        {
            InitializeComponent();
            signUpForm = new Sign_Up();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string username = usernametxt.Text;
                string password = txtpassword.Text;
                string name = nametxt.Text;
                string confirmPassword = txtComPassword.Text;
                string email = txtemail.Text;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Username and password fields cannot be empty", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (password != confirmPassword)
                {
                    MessageBox.Show("Passwords do not match, please re-enter", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (DbContext dbContext = new DbContext())
                {
                    AuthenticationRepository authenticationRepository = new AuthenticationRepository(dbContext);

                    bool registrationResult = authenticationRepository.RegisterUser(username, password, name, confirmPassword, email);

                    if (registrationResult)
                    {
                        MessageBox.Show("Your account has been successfully created", "Registration success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        signUpForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Failed to register the user", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Add your logic for pictureBox1_Click here
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Add your logic for Login_Load here
        }
        private void button1_Click(object sender, EventArgs e)
        {
            signUpForm.Show();
            this.Hide();
        }
    }
}
