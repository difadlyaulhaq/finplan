using System;
using System.Data;
using System.Data.OleDb;
using FinPlanProject.Model.Context;
using FinPlanProject.Model.Entity;

namespace FinPlanProject.Model.Repository
{
    public class UserRepository
    {
        private readonly OleDbConnection connection;

        public UserRepository(DbContext context)
        {
            connection = context.Conn;
        }

        public User GetUserInfo(string username)
        {
            User user = null;

            try
            {
                using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM tbl_user WHERE username = @username", connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    connection.Open();

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
                    }
                }
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

            return user;
        }

        public bool Simpan(string sumber, DateTime tanggal, decimal jumlah, string keterangan, string jenis)
        {
            try
            {
                string insertQuery = "INSERT INTO tbl_pemasukan(sumber, [Tgl_pemasukan], [jumlah], keterangan, jenis) VALUES(@sumber, @Tgl_pemasukan, @jumlah, @keterangan, @jenis)";
                using (OleDbCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = insertQuery;
                    cmd.Parameters.AddWithValue("@sumber", sumber);
                    cmd.Parameters.AddWithValue("@Tgl_pemasukan", tanggal);
                    cmd.Parameters.AddWithValue("@jumlah", jumlah);
                    cmd.Parameters.AddWithValue("@keterangan", keterangan);
                    cmd.Parameters.AddWithValue("@jenis", jenis);
                    cmd.ExecuteNonQuery();
                }

                return true;
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
    }
}
