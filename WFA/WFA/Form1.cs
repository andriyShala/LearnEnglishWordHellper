using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Configuration;

namespace WFA
{

    public partial class Trainer : Form
    {
        public delegate void MyDel(TrainWord word);
        public delegate void TrDel();
      
        private TrainingWords Transletors = null;

        bool chek = false;
        public Trainer()
        {
            InitializeComponent();
            Transletors = new TrainingWords();
            Transletors.StartTraires +=new TrDel(button3Click);
            DirectoryInfo inf = new DirectoryInfo("F:\\EnglishWords");
            foreach (var item in inf.GetFiles())
            {
                if (item.Name.Contains("Words"))
                {
                    toolStripComboBox1.Items.Add(item.FullName);
                }
            }
            toolStripComboBox1.SelectedIndex = 0;
            toolStripComboBox1.SelectedItem= ConfigurationManager.AppSettings["patch"];

        }
        
        Form2 f2 = null;
        private void showAllWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
                f2 = new Form2(Transletors.GetLocalWords(), new MyDel(Transletors.ReplaceWord),new MyDel(Transletors.RemoveWord));
                if (f2.Visible == false)
                {
                    f2.Show();
                }
        }
        
        private void nextWord()
        {
            try
            {
                label8.Text = Transletors.CountAllAnswer.ToString();
                Transletors.Next();
                if (chek == false)
                {
                    textBoxWork.Text = Transletors.getTrainerWord().Word;

                    string[] ans = Transletors.getTrainerWords();
                    buttonUa1.Text = ans[0];
                    buttonUa2.Text = ans[1];
                    buttonUa3.Text = ans[2];
                    buttonUa4.Text = ans[3];
                    button7_Click(null, null);
                }
                else
                {
                   textBoxAnswer.Text=textBoxTranscription.Text = textBox1.Text = string.Empty;
                    textBoxWork.Text = Transletors.getTrainerWord().Translete;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(chek==false)
            {
                Button b = sender as Button;
                if(Transletors.SetAnswer(b.Text,true))
                {
                    textBoxAnswer.BackColor = Color.LightSkyBlue;
                    textBoxAnswer.Text = String.Empty;
                    nextWord();
                }
                else
                {
                    textBoxAnswer.BackColor = Color.Red;
                }
            }
            else
            {
                if(Transletors.SetAnswer(textBoxAnswer.Text))
                {
                    textBoxAnswer.BackColor = Color.LightSkyBlue;
                    buttonUa1.Text = buttonUa2.Text = buttonUa3.Text = buttonUa4.Text = string.Empty;
                    button7_Click(null, null);
                    nextWord();
                }
                else
                {
                    textBoxAnswer.BackColor = Color.Red;
                }

            }
        }
        Random rand = new Random(DateTime.Now.Millisecond);
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedIndex != -1)
            {
                
                    Transletors.loadNewTrainers(Convert.ToInt32(numericUpDown1.Value));
                    textBox1.Text = textBoxTranscription.Text = textBoxAnswer.Text = "";
                    chek = false;
                    label10.Text = Transletors.AmountWord.ToString();
                    nextWord();
                    textBoxAnswer.BackColor = Color.LightSkyBlue;
            }
            else
                MessageBox.Show("Select file");
        }

        public static InputLanguage GetInputLanguageByName(string inputName)
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if (lang.Culture.EnglishName.ToLower().StartsWith(inputName))
                    return lang;
            }
            return null;
        }
        public void SetKeyboardLayout(InputLanguage layout)
        {
            InputLanguage.CurrentInputLanguage = layout;
        }
     
        private void textBoxAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.F1 == e.KeyCode)
            {
                if (chek == false)
                {
                    textBoxTranscription.Text = Transletors.getTrainerWord().Transcription;
                    textBox1.Text = Transletors.getTrainerWord().Translete;
                }
                else
                {
                    textBoxTranscription.Text = Transletors.getTrainerWord().Transcription;
                    textBox1.Text = Transletors.getTrainerWord().Word;
                }
                Transletors.F1();
                button7_Click(null,null);
            }
            else if (Keys.Enter == e.KeyCode)
            {
                button1_Click(null, null);
            }
        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedIndex != -1)
            {
                if (textBox4.Text != "" && textBox2.Text != "")
                {
                    if (!textBox3.Text.Contains("[]"))
                    {
                        textBox3.Text = String.Format("[ {0} ]", textBox3.Text);
                    }
                
                        string word = String.Format("{0}%{1}%{2}%{3}%50{4}", 0, textBox4.Text, textBox3.Text, textBox2.Text, Environment.NewLine);
                        TrainWord wordss = new TrainWord(new TrainWord(word,Transletors.Path));
                        if(Transletors.CountLocalWords>99)
                        {
                            DialogResult res = MessageBox.Show("create newfiel", "d", MessageBoxButtons.YesNo);
                            if(res==DialogResult.No)
                            {
                                Transletors.AddWord(wordss);
                            }
                            else
                            {
                                try
                                {
                                    Transletors.AddWord(wordss,true);
                                }
                                catch(Exception ex)
                                {
                                    toolStripComboBox1.Items.Add(ex.Message);
                                    toolStripComboBox1.SelectedItem = ex.Message;
                                }

                            }
                        }
                        else
                            {
                                Transletors.AddWord(wordss);
                            }
                    textBox4.Text = textBox3.Text = textBox2.Text = "";
                }
            }
            else
                MessageBox.Show("Select file");
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(null, null);
            }
        }
        private void startOverAgainUAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedIndex != -1)
            {
                Transletors.loadNewTrainers(Convert.ToInt32(numericUpDown1.Value));
                textBox1.Text = textBoxTranscription.Text = textBoxAnswer.Text = "";
                chek = true;
                label10.Text = Transletors.AmountWord.ToString();
                nextWord();
                textBoxAnswer.BackColor = Color.LightSkyBlue;
            }
            else
            {
                MessageBox.Show("Select file");
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            SetKeyboardLayout(GetInputLanguageByName("eng"));
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            SetKeyboardLayout(GetInputLanguageByName("ukr"));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (toolStripComboBox1.SelectedIndex != -1)
            {
                Transletors.saveToFile();
            }
            ErrorWord.close();
            
        }


        private void Form1_Load(object sender, EventArgs e)
        {
                //StreamReader stream = new StreamReader("F:\\EnglishWords\\ErrorLoader.txt");
                //while (!stream.EndOfStream)
                //{
                //    Translator.addError(stream.ReadLine());
                //}
                //stream.Close();
        }

        private void hhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f3 = new Form2(Transletors.GetLocalWords(), new MyDel(Transletors.ReplaceWord), new MyDel(Transletors.RemoveWord));
            f3.Show();
        }



        private void button3_Click(object sender, EventArgs e)
        {
           
        }
        public void button3Click()
        {
            Form4 f = new Form4(new TrDel(Transletors.newWord));
            Transletors.yy(new Form4.Mydel(f.NextWord));
            f.ShowDialog();
            Transletors.NEXT -= f.NextWord;
        }
        



        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Transletors.saveToFile();
            Transletors.SetPath(toolStripComboBox1.SelectedItem.ToString());
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string f = "F:\\EnglishWords\\Words-" + toolStripTextBox1.Text + ".txt";
            if (File.Exists(f) == false)
            {
                File.Create(f).Close();
                toolStripComboBox1.Items.Add(f);
            }
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            SetKeyboardLayout(GetInputLanguageByName("eng"));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            numericUpDown1.Value = Convert.ToInt32(b.Text);
        }

        private void replasePerCentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transletors.replacePerCent(60);
          
        }
        WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (Transletors.getTrainerWord().Url != String.Empty)
                {
                    Player.URL = Transletors.getTrainerWord().Url;
                    Player.controls.play();
                }
            }
            catch
            {
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if(textBox4.Text!=string.Empty)
            {
                textBoxUrl.Visible = true;
            }
        }

        private void subtractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach (var item in LocalWords)
            //{
            //    if(item.PerCent-10>0)
            //    {
            //        item.PerCent = item.PerCent - 10;
            //    }
            //    else
            //    {
            //        item.PerCent = 0;
            //    }
            //}
        }
        
    }
}
