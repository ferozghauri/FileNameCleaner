using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileNameCleaner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label3.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                FolderBrowserDialog getDirectory = new FolderBrowserDialog();
                if (getDirectory.ShowDialog() == DialogResult.OK)
                {
                    var all_files = Directory.GetFiles(getDirectory.SelectedPath);
                    foreach (var file in all_files)
                    {
                        string new_file_name = Path.GetFileName(file).Replace(textBox1.Text, "");
                        File.Move(file, getDirectory.SelectedPath + "\\" + new_file_name);
                    }
                    label3.Show();
                }
            }
            else
            {
                MessageBox.Show("Please Enter a String to clean from Name");
            }
            
            
        }
    }
}