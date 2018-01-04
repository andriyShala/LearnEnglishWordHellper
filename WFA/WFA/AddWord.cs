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
    public partial class AddWord : Form
    {
        event MainForm.Mydel Add;
        event MainForm.ReloadWordsList Reload;
        public AddWord(MainForm.Mydel del,MainForm.ReloadWordsList del1)
        {
            InitializeComponent();
            Add += del;
            Reload += del1;
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text != string.Empty && textBox3.Text != string.Empty)
                {
                    TrainWord word = new TrainWord("") { Word = textBox1.Text, Transcription = textBox2.Text, Translete = textBox3.Text,PerCent=50};
                    Add(word);
                    Reload();
                    textBox1.Text = textBox2.Text = textBox3.Text = String.Empty;
                }
            }
        }

        private void AddWord_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            SetKeyboardLayout(GetInputLanguageByName("eng"));
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            SetKeyboardLayout(GetInputLanguageByName("ukr"));
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
    }
}
