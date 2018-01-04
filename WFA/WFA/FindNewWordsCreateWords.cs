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
    public partial class FindNewWordsCreateWords : Form
    {
        Stack<string> stackWords = new Stack<string>();
        List<string> listwords = new List<string>();
        public delegate void CreateWord(TrainWord trainWord);
        public event CreateWord CreateW;
        public FindNewWordsCreateWords(string[] words)
        {
            InitializeComponent();
            stackWords = new Stack<string>(words);
            newWord();

        }
        public void newWord()
        {
            if (stackWords.Count > 0)
            {
                string text = stackWords.Pop();
                textBox1.Text = text;
                textBox2.Text = "";
            }
            else
            {
                this.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            TrainWord word = new TrainWord();
            word.Word = textBox1.Text;
            word.Translete = textBox2.Text;
            CreateW(word);
            newWord();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newWord();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            File.AppendAllText(MainForm.BackListWord,String.Format("{0}{1}", textBox1.Text, Environment.NewLine));
            newWord();
        }

        private void FindNewWordsCreateWords_Load(object sender, EventArgs e)
        {

        }
    }
}
