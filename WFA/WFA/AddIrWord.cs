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
    public partial class AddIrWord : Form
    {
        event MainForm.Mydel1 Add;
        event MainForm.ReloadWordsList ReloadList;
        public AddIrWord(MainForm.Mydel1 del,MainForm.ReloadWordsList del1)
        {
            InitializeComponent();
            Add += del;
            ReloadList += del1;
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                IrregularVerb verb = new IrregularVerb() { PerCent = 50, Word1 = textBox1.Text, Word2 = textBox2.Text, Word3 = textBox3.Text, Translete = textBox4.Text };
                Add(verb);
                ReloadList();
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = String.Empty;
            }
        }

        private void AddIrWord_Load(object sender, EventArgs e)
        {

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
        private void textBox4_Enter(object sender, EventArgs e)
        {
            SetKeyboardLayout(GetInputLanguageByName("ukr"));
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            SetKeyboardLayout(GetInputLanguageByName("eng"));
        }
        
    }
}
