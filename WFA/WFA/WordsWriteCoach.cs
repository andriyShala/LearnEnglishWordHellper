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
    public partial class WordsWriteCoach : Form
    {
        List<TrainWord> words = null;
        int count = 0;
        TrainWord curentWord = null;
        public WordsWriteCoach(List<TrainWord> words)
        {
            InitializeComponent();
            this.words = words;
            curentWord = words[0];
            words.RemoveAt(0);
            richTextBox1.Text += curentWord.Translete;
            label2.Text = curentWord.Word;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if(curentWord.Word==textBox1.Text)
                {
                    NextWord();
                    playsound(curentWord.Url);
                    textBox1.Text = "";
                }
            }
        }
        public void NextWord()
        {
            if (count < 8)
            {
                count++;
                richTextBox1.Text += curentWord.Word + ", ";
            }
            else
            {
                if (words.Count > 0)
                {
                    curentWord = words[0];
                    words.RemoveAt(0);
                    richTextBox1.Text += Environment.NewLine;
                    richTextBox1.Text += curentWord.Translete+"  ";
                    label2.Text = curentWord.Word;
                    
                    count = 0;
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void WordsWriteCoach_Load(object sender, EventArgs e)
        {

        }
        WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();
        private void playsound(string url)
        {
            try
            {
                if (File.Exists(url))
                {
                    Player.URL = url;
                    Player.controls.play();
                }
            }
            catch
            {
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (curentWord.Word == textBox1.Text)
            {
                NextWord();
                playsound(curentWord.Url);
                textBox1.Text = "";
            }
        }
    }
}
