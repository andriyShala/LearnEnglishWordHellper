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

namespace WFA
{
    public partial class FindNewWordsCreateFile : Form
    {
        public struct createdFile
        {
            public string[] Files { get; set; }
            public string patchName { get; set; }
        }
        public delegate void CreateFile(createdFile createdFile);
        public event CreateFile CR;


        public FindNewWordsCreateFile(string[] files)
        {
            InitializeComponent();
            foreach (var item in files)
            {
                checkedListBox1.Items.Add(item, true);
            }
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> files = new List<string>();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                files.Add(item.ToString());
            }
            string cob = "";
            if (comboBox1.SelectedIndex == -1)
            {
                CR(new createdFile() { patchName = textBox1.Text, Files = files.ToArray() });
            }
            else
            {
                CR(new createdFile() { patchName = comboBox1.SelectedItem.ToString(), Files = files.ToArray() });
            }
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.Count()>4)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void FindNewWordsCreateFile_Load(object sender, EventArgs e)
        {
            DirectoryInfo inf = new DirectoryInfo(MainForm.workDirrectory );
            List<FileInfo> files = inf.GetFiles().ToList();
            for (int i = 0; i < files.Count(); i++)
            {
                if (files[i].Name.Contains("Words"))
                {
                    comboBox1.Invoke(new Action(() => comboBox1.Items.Add(files[i].Name)));
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
    }
}
