using System;
using System.Data.OleDb;
using System.Windows.Forms;
using FinPlanProject.Model.Context;
using FinPlanProject.Model.Repository;

namespace FinPlanProject
{
    public partial class Homepage : Form
    {
        private readonly DataRepository _dataRepository;

        private DateTime selectedDateTime;

        public Homepage()
        {
            InitializeComponent();
            _dataRepository = new DataRepository(new DbContext());
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new[] { "Primary", "Secondary", "Saving" });
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            InitializeListView();
            loadData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboBox1.SelectedItem?.ToString();
            MessageBox.Show("Your selection: " + selectedValue);
        }

        private void InitializeListView()
        {
            listView1.View = System.Windows.Forms.View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Columns.AddRange(new[]
            {
                new ColumnHeader { Text = "No.", Width = 30, TextAlign = HorizontalAlignment.Center },
                new ColumnHeader { Text = "Waktu", Width = 70, TextAlign = HorizontalAlignment.Center },
                new ColumnHeader { Text = "Sumber Dana", Width = 190, TextAlign = HorizontalAlignment.Left },
                new ColumnHeader { Text = "Jumlah", Width = 70, TextAlign = HorizontalAlignment.Center },
                new ColumnHeader { Text = "Keterangan", Width = 70, TextAlign = HorizontalAlignment.Center },
                new ColumnHeader { Text = "Planning", Width = 70, TextAlign = HorizontalAlignment.Center }
            });
        }

        private void loadData()
        {
            try
            {
                listView1.Items.Clear();
                var data = _dataRepository.RetrieveData();

                foreach (var row in data)
                {
                    int count = listView1.Items.Count + 1;
                    ListViewItem item = new ListViewItem(count.ToString());
                    item.SubItems.AddRange(row);
                    listView1.Items.Add(item);
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            selectedDateTime = dateTimePicker1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Modify the button1_Click event handler based on your requirements
            throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sumbertxt.Text = "";
            jumrptxt.Text = "";
            persentxt.Text = "";
            keterangantxt.Text = "";
            comboBox1.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Add your logic for button3_Click here
            throw new NotImplementedException();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Add your logic for listView1_SelectedIndexChanged here
            throw new NotImplementedException();
        }

        //private void panel1_Paint(object sender, PaintEventArgs e)
        //{
        //    // Add your logic for panel1_Paint here
            
        //}
    }
}
