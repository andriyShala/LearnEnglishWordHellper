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
    public partial class CreateFileByFile : Form
    {
        TrainingWords tr = null;
        List<String> buffer = new List<string>();
        public CreateFileByFile(TrainingWords tr,String path)
        {
            InitializeComponent();
            this.tr = tr;
            StreamReader stream = new StreamReader(path);
            while (!stream.EndOfStream)
            {
                buffer.Add(stream.ReadLine());
            }
            stream.Close();
            NextWords();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                textBox3.Text = textBox3.Text.Replace(" ", "");
                textBox1.Text = textBox1.Text.Replace(" ", "");
                textBox2.Text = textBox2.Text.Replace(" ", "");
                if (textBox2.Text==String.Empty)
                {
                    SafeToFile(new TrainWord(tr.Path) { Word = textBox3.Text, Translete = textBox1.Text,PerCent=50,Transcription="[]" });
                    NextWords();
                }
                else
                {
                    SafeToFile(new TrainWord(tr.Path) { Word = textBox3.Text, Translete = textBox2.Text ,PerCent=50,Transcription="[]"});
                    NextWords();
                }


            }
        }
        public void NextWords()
        {
            if(buffer.Count>0)
            {
                String[] ss = buffer[buffer.Count - 1].Split('-');
                textBox3.Text = ss[0];
                textBox1.Text = ss[1];
                textBox2.Text = "";
                buffer.RemoveAt(buffer.Count - 1);
            }
            else
            {
                this.Close();
            }
        }
        public void SafeToFile(TrainWord word)
        {
            tr.AddWord(word);
        }

        private void CreateFileByFile_Load(object sender, EventArgs e)
        {

        }
    }
}
