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
    public partial class Wordscoach : Form
    {
        private TrainingWords Transletors = null;
        WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();
        int corectedvalue = 0;
        public Wordscoach()
        {
            InitializeComponent();
        }
        public Wordscoach(TrainingWords tr,int corectValue=0)
        {
            InitializeComponent();
            this.Transletors = tr;
            this.corectedvalue = corectedvalue;
        }

        private void Wordscoach_Load(object sender, EventArgs e)
        {
            
            Transletors.loadNewTrainers(this.corectedvalue);
            TransactionTextBox.Text = AnswerTextBox.Text = PromptTextBox.Text = QuestionTextBox.Text = string.Empty;
            toolStripProgressBar1.Maximum = Transletors.AmountWord;
            toolStripProgressBar1.Value = 0;
            toolStripStatusLabelAmount.Text = Transletors.AmountWord.ToString();
            nextWord();
            AnswerTextBox.BackColor = Color.White;
        }
        private void nextWord()
        {
            try
            {
                toolStripStatusLabel1.Text = Transletors.CountAllAnswer.ToString();
                Transletors.Next();
                TransactionTextBox.Text = AnswerTextBox.Text = PromptTextBox.Text = QuestionTextBox.Text = string.Empty;
                    QuestionTextBox.Text = Transletors.getTrainerWord().Translete;
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
        private void AnswerTextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode==Keys.Enter)
            {
                if (Transletors.SetAnswer(AnswerTextBox.Text))
                {

                    try
                    {
                        toolStripProgressBar1.PerformStep();
                    }
                    catch
                    {

                    }
                        AnswerTextBox.BackColor = Color.White;
                    playsound();
                    nextWord();
                }
                else
                {
                    AnswerTextBox.BackColor = Color.Red;
                }
            }
            else if(e.KeyCode==Keys.F1)
            {
                TransactionTextBox.Text = Transletors.getTrainerWord().Transcription;
                PromptTextBox.Text = Transletors.getTrainerWord().Word;
                Transletors.F1();
                playsound();
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playsound();
        }
    }
}
