using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA
{
    public partial class FindNewWords : Form
    {
        Regex regex = new Regex(@"[^a-zA-Z]");
        public List<string> patchs = new List<string>();
        public class FindWord
        {
            public FindWord()
            {

            }
            public FindWord(string word,string path)
            {
                this.Word = word;
                this.Path = path;
            }
            public string Word { get; set; }
            public string Path { get; set; }
        }
        List<string> BlackList = new List<string>();
        public delegate FindWord SearchWord(string word);
        public event SearchWord FindWORD;
        public delegate TrainingWords GetTranslator(string path);
        public event GetTranslator getTranslator;
        public event MainForm.CreateFileByName CreateFile;
        public FindNewWords()
        {
            InitializeComponent();
        
            StreamReader stream = new StreamReader(MainForm.BackListWord);
            while (!stream.EndOfStream)
            {
                BlackList.Add(stream.ReadLine());
            }
            stream.Close();
            var doubleBufferPropertyInfo = listView1.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            doubleBufferPropertyInfo.SetValue(listView1, true, null);
        }
        public bool isd(string wo)
        {
            for (int i = 0; i < BlackList.Count; i++)
            {
                if(BlackList[i]==wo)
                {
                    return true;
                }
            }
            return false;
        }
        private bool isExist(string it,List<string> list)
        {
            foreach (var item in list)
            {
                if(item==it)
                {
                    return true;
                }
            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string text = richTextBox1.Text.Replace("."," ").Replace('"',' ').Replace(',',' ').Replace("'s","");
        
            List<string> list = new List<string>();
            foreach (var item in text.Split(' '))
            {
                if (item != "")
                {

                    if (char.IsLower(item[0]))
                    {
                        if (!isd(item))
                        {
                            if (!isExist(item, list))
                            {
                                string word = item;
                                if(item.Contains("ing"))
                                {
                                    if(item[item.Count()-3]=='i')
                                    {
                                        word=word.Remove(item.Count()-3);
                                    }
                                }
                                else if(item.Contains("ed"))
                                {
                                    if(item[item.Count()-2]=='e'&&item[item.Count()-1]=='d')
                                    {
                                        word = word.Remove(word.Count()-2);
                                    }
                                }
                                
                                list.Add(word);
                            }
                        }
                    }
                }
            }
            
            Task.Run(new Action(() => addtoList(list.ToArray())));
        }
        private void addtoList(string[] mass)
        {
            int i = 1;
            foreach (var item in mass)
            {
                FindWord findWord = FindWORD(item);
                if (findWord != null)
                {
                    ListViewItem it = new ListViewItem(i.ToString());
                    it.SubItems.Add(findWord.Word);
                    it.SubItems.Add(findWord.Path);
                    addPath(findWord.Path);
                    listView1.Invoke(new Action(() => listView1.Items.Add(it)));
                }
                else
                {
                    ListViewItem it = new ListViewItem(i.ToString());
                    it.SubItems.Add(item);
                    it.SubItems.Add("NONE");
                    listView1.Invoke(new Action(() => listView1.Items.Add(it)));
                }
                i++;
            }
        }
        public void addPath(string path)
        {
            for (int i = 0; i < patchs.Count; i++)
            {
                if(patchs[i]==path)
                {
                    return;
                }
            }
            patchs.Add(path);
        }
        private void FindNewWords_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FindNewWordsCreateFile createFile = new FindNewWordsCreateFile(patchs.ToArray());
            createFile.CR += CreateFile_CR;
            createFile.ShowDialog();
        }
        TrainingWords trainingWords = null;
        private bool isExistInColection(string text, string[] coll)
        {
            for (int i = 0; i < coll.Count(); i++)
            {
                if (text ==coll[i])
                {
                    return true;
                }
            }
            return false;
        
        }
        private void CreateFile_CR(FindNewWordsCreateFile.createdFile createdFile)
        {
            CreateFile(createdFile.patchName);
            List<string> listwords = new List<string>();
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[2].Text=="")
                {
                    listwords.Add(item.SubItems[1].Text);
                }
                else if(!isExistInColection(item.SubItems[2].Text,createdFile.Files))
                {
                    listwords.Add(item.SubItems[1].Text);
                }
            }
          trainingWords = getTranslator(createdFile.patchName);
            FindNewWordsCreateWords createWords = new FindNewWordsCreateWords(listwords.ToArray());
            createWords.CreateW += CreateWords_CreateW;
            createWords.Show();
        }

        private void CreateWords_CreateW(TrainWord trainWord)
        {
            trainingWords.AddWord(trainWord);
        }
    }
}
