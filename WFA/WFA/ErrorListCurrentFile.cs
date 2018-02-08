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
    public partial class ErrorListCurrentFile : Form
    {
        private TrainingWords Translator=null;
        private string path = "";
        public ErrorListCurrentFile(TrainingWords trainingWords)
        {
            InitializeComponent();
            this.Translator = trainingWords;
            this.path = trainingWords.Path;
            ListItialize();
        }
        private void ListItialize()
        {
            foreach (var item in ErrorWord.ErrorWords)
            {
                if(item.path==path)
                {
                     listBox1.Items.Add(item.word);
                }
            }
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex!=-1)
            {
                ErrorFix er = new ErrorFix(new MainForm.Mydel2(Translator.ReplaceWord), ErrorWord.get(listBox1.SelectedItem.ToString(), path));
               if(er.ShowDialog()==DialogResult.OK)
                {
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
               if(listBox1.Items.Count==0)
                {
                    this.Close();
                }
            }
        }

        private void ErrorListCurrentFile_Load(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            { this.Close(); }
        }
    }
}
