using System;
using System.Data.OleDb;
using FinPlanProject.Model.Context;
namespace FinPlanProject.Model.Repository
{
    public class UserRepository
    {
        private readonly OleDbConnection connection;

        public UserRepository(DbContext context)
        {
            connection = context.Conn;
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
        }

    }
}
