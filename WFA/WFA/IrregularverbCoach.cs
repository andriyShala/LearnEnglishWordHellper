using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using WMPLib;
using System.Media;
namespace WFA
{
    public partial class IrregularverbCoach : Form
    {
        IrTransetor translator = null;
        WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();
        public IrregularverbCoach(IrTransetor tr)
        {
            InitializeComponent();
            this.translator = tr;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool[] mas = translator.SetAnswer(textBox2.Text, textBox3.Text, textBox4.Text);
                if (mas[0]==true&&mas[1]==true&&mas[2]==true)
                {

                 textBox4.BackColor= textBox3.BackColor=textBox2.BackColor = Color.White;
                    playsound();
                    nextWord();
                }
                else
                {
                    if(!mas[0])
                    {
                        textBox2.BackColor = Color.Red;
                    }
                    else
                    {
                        textBox2.BackColor = Color.White;
                    }
                    if (!mas[1])
                    {
                        textBox3.BackColor = Color.Red;
                    }
                    else
                    {
                        textBox3.BackColor = Color.White;
                    }
                    if (!mas[2])
                    {
                        textBox4.BackColor = Color.Red;
                    }
                    else
                    {
                        textBox4.BackColor = Color.White;
                    }
                }
            }
            else if (e.KeyCode == Keys.F1)
            {
                 
                textBox5.Text = translator.getTrainerWord().Word1;
                textBox6.Text = translator.getTrainerWord().Word2;
                textBox7.Text = translator.getTrainerWord().Word3;
                translator.F1();
                playsound();
            }

        }

        private void IrregularverbCoach_Load(object sender, EventArgs e)
        {
            translator.loadNewTrainers();
           label2.Text= translator.AmountWord.ToString();
            nextWord();
        }
        private void nextWord()
        {
            try
            {
                translator.Next();
                label3.Text= translator.CountAllAnswer.ToString();
                textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text =string.Empty;
                textBox1.Text = translator.getTrainerWord().Translete;
               
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
        public void play(string urs)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = urs;
            player.Play();
        }
        private void playsound()
        {
            try
            {
                if (translator.getTrainerWord().Url1 != String.Empty)
                {
                    button1_Click(null, null);
                    Thread.Sleep(1000);
                    button2_Click(null, null);

                    Thread.Sleep(1000);
                    button3_Click(null, null);

                }
            }
            catch(Exception ex)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Player.URL = translator.getTrainerWord().Url1;
            Player.controls.play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Player.URL = translator.getTrainerWord().Url2;
            Player.controls.play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Player.URL = translator.getTrainerWord().Url3;
            Player.controls.play();
        }
    }
}
