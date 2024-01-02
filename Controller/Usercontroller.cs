using FinPlanProject.Model.Context;
using FinPlanProject.Model.Repository;
using System;
using System.Windows.Forms;

namespace FinPlanProject.Controller
{
    public class UserController
    {
        private readonly AuthenticationRepository authentication;

        public UserController()
        {
            DbContext dbContext = new DbContext();
            authentication = new AuthenticationRepository(dbContext);
        }

        public bool LoginUser(string username, string password)
        {
            try
            {
                var loggedInUser = authentication.LoginUser(username, password);
                if (loggedInUser != null)
                {
                    // Successfully logged in
                    return true;
                }
                else
                {
                    // Login failed
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Handle any exceptions as login failure
            }
        }


        public void RegisterUser(string username, string password, string name, string confirmPassword, string email)
        {
            try
            {
                bool registrationResult = authentication.RegisterUser(username, password, name, confirmPassword, email);
                if (registrationResult)
                {
                    MessageBox.Show("Your account has been successfully created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to register the user. Please check your information and try again.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
