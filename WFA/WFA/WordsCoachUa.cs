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
    public partial class WordsCoachUa : Form
    {
        private TrainingWords Transletors = null;
        WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();
        int corectedvalue = 0;
        public WordsCoachUa(TrainingWords tr, int corectValue = 0)
        {
            InitializeComponent();
            this.Transletors = tr;
            this.corectedvalue = corectedvalue;
        }

        private void WordsCoachUa_Load(object sender, EventArgs e)
        {
            Transletors.loadNewTrainers(this.corectedvalue);
            button1.Text = button2.Text = button3.Text = button4.Text =textBox1.Text= string.Empty;
            label2.Text = Transletors.AmountWord.ToString();
            nextWord();
        }
        private void nextWord()
        {
            try
            {
                label1.Text = Transletors.CountAllAnswer.ToString();
                Transletors.Next();
                playsound();
                textBox1.Text = Transletors.getTrainerWord().Word;
                string[] m = Transletors.getTrainerWords();
                button1.Text = m[0];
                button2.Text = m[1];
                button3.Text = m[2];
                button4.Text = m[3];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
        private void playsound()
        {
            TrainWord w = Transletors.getTrainerWord();
            try
            {
                if (File.Exists(w.Url))
                {
                    Player.URL = w.Url;
                    Player.controls.play();
                }
                else
                {
                    ErrorWord.add(new ErrorWord() { id = w.Index, path = w.path, word = w.Word });
                }
            }
            catch
            {
                if (!File.Exists(w.Url))
                {
                    ErrorWord.add(new ErrorWord() { id = w.Index, path = w.path, word = w.Word });
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (Transletors.SetAnswer(b.Text, true))
            {
                playsound();
                nextWord();
                button1.BackColor = button2.BackColor= button3.BackColor= button4.BackColor= Color.White;
            }
            else
            {
                b.BackColor = Color.Red;
            }
        }
    }
}
