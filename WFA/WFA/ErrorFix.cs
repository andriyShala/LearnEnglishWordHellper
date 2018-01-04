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
    public partial class ErrorFix : Form
    {
        event MainForm.Mydel2 replace;
        ErrorWord word;
        public ErrorFix(MainForm.Mydel2 del,ErrorWord word)
        {
            InitializeComponent();
            replace += del;
            textBox1.Text = word.id.ToString();
            textBox2.Text = word.word;
            textBox3.Text = word.path;
            this.word = word;
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            replace(word, textBoxUrl.Text);
            this.Close();
        }

        private void ErrorFix_Load(object sender, EventArgs e)
        {

        }
    }
}
