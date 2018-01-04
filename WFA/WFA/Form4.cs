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
    public partial class Form4 : Form
    {
        public delegate void Mydel(TrainWord word);
        event Trainer.TrDel TrDel;
        public Form4(Trainer.TrDel de)
        {
            InitializeComponent();
            TrDel += de;

        }
        public void NextWord(TrainWord word)
        {
            textBoxAnswer.Text=textBoxQvestion.Text = "";
            currentword = word;
            textBoxQvestion.Text = word.Translete;
            Index = 0;
            Weight = 12;
            Height = 96;
            List<char> hh = new List<char>();
            hh.AddRange(currentword.Word);
            while(hh.Count>0)
            {
               int n=rand.Next(0, hh.Count);
                char r = hh[n];
                hh.RemoveAt(n);
                gg(r);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if(b.Text[0]==currentword.Word[Index])
            {
                Index++;
                textBoxAnswer.Text += b.Text;
                this.Controls.Remove(b);
                if(textBoxAnswer.Text==currentword.Word)
                {
                    TrDel();
                }
            }
        }
        int Index = 0;
        TrainWord currentword = new TrainWord("");
        Random rand = new Random(DateTime.Now.Second);
        int Weight = 0;
        int Height = 96;
        public void gg(char r)
        {
                Button b1 = new Button();
                b1.Location = new System.Drawing.Point(Weight, Height);
                b1.Name = "button1"+r+""+rand.Next(0,5555);
                b1.Size = new System.Drawing.Size(24, 24);
                b1.TabIndex = 0;
                b1.Text = r.ToString();
                b1.UseVisualStyleBackColor = true;
                b1.Click += new System.EventHandler(this.button1_Click);
                this.Controls.Add(b1);
                Weight += 20;
            if(Weight>340)
            {
                Weight = 12;
                Height += 10;
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            TrDel();
        }
    }
}
