using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA
{
    public partial class CreateFile : Form
    {
        event MainForm.CreateFiles Create;
        public CreateFile(MainForm.CreateFiles del)
        {
            InitializeComponent();
            Create += del;
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Enabled)
            {
                string path = comboBox1.SelectedItem.ToString()+"-" + textBox1.Text + ".txt";
                Create(path);
            }
            else
            {
                string path = comboBox1.SelectedItem.ToString()+"-" + textBox1.Text + ".txt";
                Create(path,textBox2.Text);
            }
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox2.Enabled = true;
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                textBox2.Enabled = false;
            }
        }

        private void CreateFile_Load(object sender, EventArgs e)
        {

        }
    }
}
