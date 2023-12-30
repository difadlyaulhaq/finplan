using FinPlanProject.Model.Context;
using FinPlanProject.Model.Repository;
using System.Windows.Forms;
using System;

namespace FinPlanProject.Controller
{
    public class DataController
    {
        private readonly UserRepository userRepository;

        public DataController(DbContext context)
        {
            userRepository = new UserRepository(context);
        }
        public void SimpanData(string sumber, DateTime tanggal, decimal jumlah, string keterangan, string jenis)
        {
            try
            {
                bool simpanSuccessful = userRepository.Simpan(sumber, tanggal, jumlah, keterangan, jenis);

                if (simpanSuccessful)
                {
                    MessageBox.Show("Data berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Gagal menyimpan data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
