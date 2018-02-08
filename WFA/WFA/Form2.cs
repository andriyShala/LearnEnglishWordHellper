using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WFA
{
    public partial class Form2 : Form
    {
        private int SelectedItemIndex = 0;
        event Trainer.MyDel AddEvent;
        event Trainer.MyDel RemoveEvent;
        private WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();
        private List<TrainWord> words =null;
        private bool percentColumClick = false;
        public  delegate bool SortDelegate(ListViewItem it1, ListViewItem it2,bool reverse=false);
        public Form2()
        {
            InitializeComponent();
        }
      
        private bool cont(string word)
        {
            foreach (var item in ErrorWord.ErrorWords)
            {
                if(word==item.word)
                {
                    return true;
                }
            }
            return false;
        }
        public void check()
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if(cont(item.SubItems[1].Text))
                {
                    item.BackColor = Color.Red;
                }
            }
        }
        public void sortItem()
        {
            TrainWord temp = new TrainWord("");
            for (int i = 0; i < words.Count() - 1; i++)
            {
                for (int j = i + 1; j < words.Count(); j++)
                {
                    if (words[i].Index > words[j].Index)
                    {
                        temp = words[i];
                        words[i] = words[j];
                        words[j] = temp;
                    }
                }
            }

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

        private void textBox2_Enter(object sender, EventArgs e)
        {
            SetKeyboardLayout(GetInputLanguageByName("ukr"));
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
        public Form2(List<TrainWord> words, Trainer.MyDel del,Trainer.MyDel delete)
        {
            AddEvent += del;
            RemoveEvent += delete;
            this.words = words;
            InitializeComponent();
          load();
        }
        public void load()
        {
            listView1.Items.Clear();
            foreach (var t in this.words)
            {
                addtolist(t);
            }
            check();
        }
        public bool contain(string s)
        {
           
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.Text == s)
                    {
                        return true;
                    }
                }
           
            return false;
        }
        private bool containInWords(string s,int ss)
        {
            for (int i = ss; i < words.Count() - 1; i++)
            {
                if (words[i].Translete.Contains(s))
                {
                    return true;
                }
            }
            return false;
        }
        public void removeFromList(TrainWord t)
        {
            for (int i = 0; i < listView1.Items.Count-1; i++)
            {
                if((int)listView1.Items[i].Tag==t.Index)
                {
                    listView1.Invoke(new Action(()=>listView1.Items.RemoveAt(i)));
                    break;
                }
            }
        }
        public void addtolist(TrainWord t,bool check=false)
        {
            ListViewItem item = new ListViewItem(t.Index.ToString());
            item.SubItems.Add(t.Word);
            item.SubItems.Add(t.Transcription);
            item.SubItems.Add(t.Translete);
            item.SubItems.Add(t.PerCent.ToString());
            item.SubItems.Add(t.Url);
            item.Tag = t.Index;
            

            if (contain(t.Index.ToString()) == false)
            {
                if (check == false)
                {
                    try
                    {
                        listView1.Invoke(new Action(() => listView1.Items.Add(item)));
                    }
                    catch
                    {
                        listView1.Items.Add(item);
                    }
                }
                else
                {
                    
                    listView1.Invoke(new Action(() => listView1.Items.Insert(t.Index - 1, item)));
                }
            }
        }
        public void addtolist(string s)
        {
            TrainWord t =new TrainWord(s,"");
            ListViewItem item = new ListViewItem(t.Index.ToString());
            item.SubItems.Add(t.Word);
            item.SubItems.Add(t.Transcription);
            item.SubItems.Add(t.Translete);
            item.Tag = t.Index;
            listView1.Items.Add(item);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                textBoxWord.Text = item.SubItems[1].Text;
                textBoxTranscription.Text = item.SubItems[2].Text;
                textBoxTranslate.Text = item.SubItems[3].Text;
                textBoxColumn.Text = item.SubItems[4].Text;
                textBox3.Text = item.SubItems[5].Text;
                SelectedItemIndex = Convert.ToInt32(item.Tag);
                playsound(textBox3.Text);

            }
        }
        private void playsound(string Url)
        {
            try
            {
                if (File.Exists(Url))
                {
                    Player.URL = Url;
                    Player.controls.play();
                }
               
            }
            catch
            {
               
            }
        }
        int id = -1;
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    if(item.SubItems[1].Text==textBox1.Text)
                    {
                        if(id!=-1)
                            listView1.Items[id].ForeColor = Color.Black;
                        id = item.Index;
                        listView1.Items[id].ForeColor = Color.Red;
                        return;
                    }
                }


            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.SubItems[3].Text == textBox2.Text)
                    {
                        if (id != -1)
                            listView1.Items[id].ForeColor = Color.Black;
                        id = item.Index;
                        listView1.Items[id].ForeColor = Color.Red;
                        return;
                    }
                }
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string textsearch = textBox2.Text;

           
            
                for (int i = 0; i < words.Count() - 1; i++)
                {
                    if (words[i].Translete.Contains(textsearch))
                    {
                        addtolist(words[i]);
                    }
                    else
                    {
                        removeFromList(words[i]);
                    }
                }
            if (textsearch == string.Empty)
            {
                TrainWord temp = new TrainWord("");
                for (int i = 0; i < words.Count() - 1; i++)
                {
                    for (int j = i + 1; j < words.Count(); j++)
                    {
                        if (words[i].Index > words[j].Index)
                        {
                            temp = words[i];
                            words[i] = words[j];
                            words[j] = temp;
                        }
                    }
                }
            }
        }
        private void textBoxWord_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                TrainWord word = new TrainWord("");
                word.Index = SelectedItemIndex;
                word.PerCent = Convert.ToInt32(textBoxColumn.Text);
                word.Transcription = textBoxTranscription.Text;
                word.Translete = textBoxTranslate.Text;
                word.Word = textBoxWord.Text;
                word.Url = textBox3.Text;
                replaceWord(word);
                AddEvent(word);
                textBoxTranscription.Text = textBoxTranslate.Text = textBoxWord.Text = textBox3.Text=string.Empty;
            }
        }
        public void replaceWord(TrainWord word)
        {
            string wor = "";
            foreach (ListViewItem item in listView1.Items)
            {
                if(item.SubItems[0].Text==word.Index.ToString())
                {
                    wor = item.SubItems[1].Text;
                    item.SubItems[1].Text = word.Word;
                    item.SubItems[2].Text = word.Transcription;
                    item.SubItems[3].Text = word.Translete;
                    item.SubItems[4].Text = word.PerCent.ToString();
                    item.SubItems[5].Text = word.Url;
                    ErrorWord er = new ErrorWord();
                    er.id = word.Index;
                    er.path = word.path;
                    er.word = word.Word;
                    if(item.BackColor==Color.Red)
                    {
                        ErrorWord.remove(er);
                        item.BackColor = Color.LightSteelBlue;
                        return;
                    }
                }
            }
        }
        private void textBoxTranscription_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string textsearch = textBox1.Text;



            for (int i = 0; i < words.Count() - 1; i++)
            {
                if (words[i].Word.Contains(textsearch))
                {
                    addtolist(words[i]);
                }
                else
                {
                    removeFromList(words[i]);
                }
            }
            if (textsearch == string.Empty)
            {
                TrainWord temp = new TrainWord("");
                for (int i = 0; i < words.Count() - 1; i++)
                {
                    for (int j = i + 1; j < words.Count(); j++)
                    {
                        if (words[i].Index > words[j].Index)
                        {
                            temp = words[i];
                            words[i] = words[j];
                            words[j] = temp;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem item = listView1.SelectedItems[0];
            TrainWord word = new TrainWord("");
            word.Index = Convert.ToInt32(item.Tag);
            word.PerCent = Convert.ToInt32(textBoxColumn.Text);
            word.Transcription = textBoxTranscription.Text;
            word.Translete = textBoxTranslate.Text;
            word.Word = textBoxWord.Text;
            word.Url = textBox3.Text;
            RemoveEvent(word);
            removeFromList(word);
            if (word.Index - 1 >= 0)
            {
                listView1.Items[word.Index - 1].Selected=true;
            }
            else
            {
                if(listView1.Items.Count>=1)
                {
                    listView1.Items[0].Selected = true;
                }
            }
            for (int i = 0; i < words.Count; i++)
            {
                words[i].Index = i + 1;
            }
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Delete)
            {
                button1_Click(null, null);
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            String col = listView1.Columns[e.Column].Text;
            if (col=="Percent")
            {
                if(percentColumClick==false)
                {
                    percentColumClick = true;
                    BubleSort(sortByPercent);
                }
                else
                {
                    percentColumClick = false;
                    BubleSort(sortByPercent, true);
                }
            }
           else if(col== "I")
            {
                if (percentColumClick == false)
                {
                    percentColumClick = true;
                    BubleSort(sortByIndex);
                }
                else
                {
                    percentColumClick = false;
                    BubleSort(sortByIndex, true);
                }
            }
        }
        private bool sortByIndex(ListViewItem it1, ListViewItem it2, bool reverse = false)
        {
            if (reverse == false)
            {
                if (Convert.ToInt32(it1.SubItems[0].Text) < Convert.ToInt32(it2.SubItems[0].Text))
                {
                    return true;
                }
            }
            else
            {
                if (Convert.ToInt32(it1.SubItems[0].Text) > Convert.ToInt32(it2.SubItems[0].Text))
                {
                    return true;
                }
            }
            return false;
        }
        private bool sortByPercent(ListViewItem it1, ListViewItem it2, bool reverse = false)
        {
           if(reverse==false)
            {
                if(Convert.ToInt32(it1.SubItems[4].Text) < Convert.ToInt32(it2.SubItems[4].Text))
                {
                    return true;
                }
            }
           else
            {
                if (Convert.ToInt32(it1.SubItems[4].Text) > Convert.ToInt32(it2.SubItems[4].Text))
                { 
                    return true;
                }
            }
            return false;
        }
        public void BubleSort(SortDelegate func,bool reverse=false)
        {
            ListView.ListViewItemCollection col=null;
            listView1.Invoke(new Action(() => col = listView1.Items));
            ListViewItem temp;
            ListViewItem temp2;
           
                for (int i = 0; i < col.Count; i++)
                {
                    for (int j = i + 1; j < col.Count; j++)
                    {
                            if(func(col[i], col[j],reverse))
                            {
                                temp = listView1.Items[i];
                                temp2 = listView1.Items[j];
                        listView1.Invoke(new Action(() => listView1.Items.RemoveAt(i)));
                        listView1.Invoke(new Action(() => listView1.Items.RemoveAt(j - 1)));



                        listView1.Invoke(new Action(() => listView1.Items.Insert(i, temp2)));
                        listView1.Invoke(new Action(() => listView1.Items.Insert(j, temp)));
                    }
                        
                    }
                }
        }
    }
}
