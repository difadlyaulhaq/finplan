using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using FinPlanProject.Model.Context;
using FinPlanProject.Model.Entity;

namespace FinPlanProject.Model.Repository
{
    public class AuthenticationRepository
    {
        private readonly OleDbConnection connection;

        public AuthenticationRepository(DbContext context)
        {
            connection = context.Conn;
        }

        public bool RegisterUser(string username, string password, string name, string confirmPassword, string email)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    throw new ArgumentException("Username and password fields cannot be empty");
                }
                else if (password != confirmPassword)
                {
                    throw new ArgumentException("Passwords do not match, please re-enter");
                }
                else
                {
                    using (OleDbCommand cmd = connection.CreateCommand())
                    {
                        connection.Open();
                        cmd.CommandText = "INSERT INTO tbl_user (username, [password], name_user, email_user) VALUES (@username, @password, @name_user, @email_user)";
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@name_user", name);
                        cmd.Parameters.AddWithValue("@email_user", email);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (OleDbException ex)
            {
                throw new Exception("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public User LoginUser(string username, string password)
        {
            User user = null;
            try
            {
                using (OleDbCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    string loginQuery = "SELECT * FROM tbl_user WHERE username = @username AND [password] = @password";
                    cmd.CommandText = loginQuery;
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    var count = cmd.ExecuteNonQuery();

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                Username = reader["username"].ToString(),
                                Name = reader["name_user"].ToString(),
                                Email = reader["email_user"].ToString()
                                // Add other properties if necessary
                            };
                        }
                        else
                        {
                            // Username not found, return null
                            return null;
                        }
                    }
                    return user;
                }
                //return loginSuccessful;
            }
            catch (OleDbException ex)
            {
                throw new Exception("Database error: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
