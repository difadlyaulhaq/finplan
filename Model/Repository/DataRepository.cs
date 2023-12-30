using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using FinPlanProject.Model.Context;

namespace FinPlanProject.Model.Repository
{
    public class DataRepository
    {
        private readonly DbContext _context;

        public DataRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<string[]> RetrieveData()
        {
            List<string[]> data = new List<string[]>();

            try
            {
                using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM tbl_pemasukan", _context.Conn))
                {
                    _context.Conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string[] row = new string[]
                            {
                                reader["Tgl_pemasukan"].ToString(),
                                reader["sumber"].ToString(),
                                reader["jumlah"].ToString(),
                                reader["keterangan"].ToString(),
                                reader["jenis"].ToString()
                            };
                            data.Add(row);
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
                if (_context.Conn.State == ConnectionState.Open)
                {
                    _context.Conn.Close();
                }
            }

            return data;
        }
    }
}
