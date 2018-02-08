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
using static WFA.Trainer;
using System.Configuration;
using System.Threading;
using System.Reflection;

namespace WFA
{
   
    public partial class MainForm : Form
    {

        public static string workDirrectory = "";
        bool flag = true;
        private List<string> Files = new List<string>();
        private List<string> irFiles = new List<string>();
        ContextMenu menu = new ContextMenu();
        private Object los = new object();
        public int countLoad = 0;
        public delegate void Mydel(TrainWord word);
        public delegate void Mydel1(IrregularVerb word);
        public delegate void Mydel2(ErrorWord word, string url);
        public delegate void ReloadErrorList(ErrorWord word, bool remove = false);
        public delegate void ReloadWordsList();
        public delegate void StartLoad(string Path, bool closeFile = false);
        public delegate void StopLoad(string Path, bool closeFile = false);
        public delegate void CreateFiles(string name, string fromFile = "");
        public delegate string CreateFileByName(string name);
        private string selectedPath = "";
        public static string BackListWord = @"F:\EnglishWords\BlackList.txt";
        private WorkTransetor translators = null;

        public void loadtoErrorList(ErrorWord word, bool remove)
        {
            if (remove)
            {
                for (int i = 0; i < ErrorlistView.Items.Count; i++)
                {
                    if(ErrorlistView.Items[i].Text==word.word)
                    {
                        ErrorlistView.Invoke(new Action(() => ErrorlistView.Items.RemoveAt(i)));
                        return;
                    }

                }
            }
            else
            {
                ListViewItem item = new ListViewItem(word.word);
                item.Tag = word.path;
                ErrorlistView.Invoke(new Action(() => ErrorlistView.Items.Add(item)));
            }
        }
      
        public MainForm()
        {
            InitializeComponent();
            workDirrectory=Directory.CreateDirectory("Content").ToString();
            var doubleBufferPropertyInfo = WordslistView.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            doubleBufferPropertyInfo.SetValue(WordslistView, true, null);



            selectedPath = ConfigurationManager.AppSettings["patch"];

            

            MenuItem mitem = new MenuItem("Delete");
            mitem.Click += Mitem_Click;
            MenuItem mitem2 = new MenuItem("Replace Percent");
            mitem2.Click += Mitem2_Click;
            MenuItem mitem3 = new MenuItem("Error Words");
            mitem3.Click += Mitem3_Click;
            menu.MenuItems.Add(mitem);
            menu.MenuItems.Add(mitem2);
            menu.MenuItems.Add(mitem3);

            ErrorWord.addevent(new ReloadErrorList(loadtoErrorList));
        }

        private void Mitem3_Click(object sender, EventArgs e)
        {
            ErrorListCurrentFile errorListCurrentFile = new ErrorListCurrentFile(translators.getTTranslator(FilelistBox.SelectedItem.ToString()));
            errorListCurrentFile.ShowDialog();
        }

        private void Mitem2_Click(object sender, EventArgs e)
        {
            defaultPerCentToolStripMenuItem_Click(sender, e);
        }

        public void LoadErrorList()
        {
            StreamReader stream = new StreamReader(workDirrectory+"\\"+"ErrorLoader.txt");
            while (!stream.EndOfStream)
            {
                string wordError = stream.ReadLine();
                ErrorWord word = new ErrorWord(wordError);
                ErrorWord.add(word);
            }
            stream.Close();
        }
        private void ChangedWord(TrainWord word,String path)
        {
            try
            {
                if (path == translators.getTTranslator().Path)
                {
                    Invoke((MethodInvoker)delegate
                     {
                         foreach (ListViewItem item in WordslistView.Items)
                         {
                             if (item.SubItems[1].Text == word.Word)
                             {
                                 item.BackColor = word.GetColor();
                                 return;
                             }
                         }
                     });
                }
            }
            catch
            {

            }
        }
        private void loadForm()
        {

            DirectoryInfo inf = new DirectoryInfo(workDirrectory);
            List<FileInfo> files = inf.GetFiles().ToList();
            for (int i=0;i<files.Count();i++)
            {
                if (files[i].Name.Contains("Words"))
                {
                    FilelistBox.Invoke(new Action(() => FilelistBox.Items.Add(files[i].Name)));
                    Files.Add(files[i].FullName);
                }
                else if (files[i].Name.Contains("IrregularVerbs"))
                {
                    FilelistBox.Invoke(new Action(() => FilelistBox.Items.Add(files[i].Name)));
                    irFiles.Add(files[i].FullName);
                }
               
            }
            translators = new WorkTransetor(Files.ToArray(), irFiles.ToArray(), new StartLoad(startLoadFile), new StopLoad(stopLoadFile),new TrainingWords.ChangeWord(ChangedWord));
           
        }

        private void startLoadFile(string path, bool close)
        {
            lock (los)
            {
                countLoad++;
                this.toolStripStatusLoadLabel.Text = "Load File-" + countLoad;
            }
        }
        private int selectItemInFileListBoxByPath(string path)
        {
            ListBox.ObjectCollection coll = null;
            FilelistBox.Invoke(new Action(() => coll=FilelistBox.Items));
            for (int i = 0; i < coll.Count; i++)
            {
                if(coll[i].ToString()==path)
                {
                    return i;
                }
            }
            return 0;
        }
        private void stopLoadFile(string path, bool close)
        {
            lock (los)
            {
               
                    if(path.Contains(selectedPath))
                    {
                   
                            FilelistBox.Invoke(new Action(() => FilelistBox.SelectedIndex = selectItemInFileListBoxByPath(selectedPath)));
                    }
                countLoad--;
                this.toolStripStatusLoadLabel.Text = "Load File-" + countLoad;
            }
        }
       
        private void MainForm_Load(object sender, EventArgs e)
        {
            
            TrainingWords.LoadBadKnow();
            Task.Run(new Action(() => LoadErrorList()));
            Task.Run(new Action(() => loadForm()));
            
        }

        private void LoadWordsToList()
        {
            WordslistView.Invoke(new Action(() => WordslistView.Items.Clear()));
            foreach (var item in translators.getTTranslator().GetLocalWordsI())
            {
                ListViewItem it = new ListViewItem(item.Index.ToString());
                it.SubItems.Add(item.Word);
                it.SubItems.Add(item.Translete);
                it.SubItems.Add(item.BadTries.ToString());
                it.BackColor = item.GetColor();
                WordslistView.Invoke(new Action(() => WordslistView.Items.Add(it)));
            }
        }

        private void LoadIrWordsToList()
        {
            WordslistView.Invoke(new Action(() => WordslistView.Items.Clear()));
            foreach (var item in translators.getIRTranslator().GetLocalWordsI())
            {
                ListViewItem it = new ListViewItem(item.Index.ToString());
                it.SubItems.Add(String.Format("{0}-{1}-{2}", item.Word1, item.Word2, item.Word3));
                it.SubItems.Add(item.Translete);
                WordslistView.Invoke(new Action(() => WordslistView.Items.Add(it)));
            }
        }

        private void FilelistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadWordList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ErrorlistView.SelectedItems.Count > 0)
            {
                String word = ErrorlistView.SelectedItems[0].Tag as string;
                if (word.Contains("IrregularVerbs"))
                {
                    ErrorFix er = new ErrorFix(new Mydel2(translators.getIRTranslator(word).ReplaceWord), ErrorWord.get(ErrorlistView.SelectedItems[0].SubItems[0].Text, word));
                    er.Show();
                }
                else
                {

                    ErrorFix er = new ErrorFix(new Mydel2(translators.getTTranslator(word).ReplaceWord), ErrorWord.get(ErrorlistView.SelectedItems[0].SubItems[0].Text, word));
                    er.Show();
                }

            


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (FilelistBox.SelectedItems.Count > 0)
            {
                String path = FilelistBox.SelectedItem.ToString();
                if (path.Contains("IrregularVerbs"))
                {
                    IrregularverbCoach ir = new IrregularverbCoach(translators.getIRTranslator());
                    ir.Show();
                }
                else
                {
                    Wordscoach ch = new Wordscoach(translators.getTTranslator());
                    ch.Show();
                    LoadWordsToList();
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            flag = false;
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings["patch"].Value = FilelistBox.SelectedItem.ToString();
            config.Save();
            translators.closing();
            ErrorWord.close();
            TrainingWords.SaveBadKmow();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String path = Files[FilelistBox.SelectedIndex];
            if (path.Contains("Words"))
            {
                Form2 f2 = new Form2(translators.getTTranslator().GetLocalWords(), new MyDel(translators.getTTranslator().ReplaceWord), new MyDel(translators.getTTranslator().RemoveWord));
                if (f2.Visible == false)
                {
                    f2.Show();
                }
            }
        }

        public void ReloadWordList()
        {
            if (FilelistBox.SelectedIndex != -1)
            {
                if (FilelistBox.SelectedItem.ToString().Contains("Words"))
                {
                    translators.setTTranslatorByName(FilelistBox.SelectedItem.ToString());
                    Task.Run(new Action(() => LoadWordsToList()));
                }
                else
                {
                    translators.setIRTranslatorByName(FilelistBox.SelectedItem.ToString());
                    Task.Run(new Action(() => LoadIrWordsToList()));
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (FilelistBox.SelectedItems.Count > 0)
            {
                String path = FilelistBox.SelectedItem.ToString();
                if (path.Contains("Words"))
                {
                    AddWord add = new AddWord(new Mydel(translators.getTTranslator().AddWord), new ReloadWordsList(this.ReloadWordList));
                    add.Show();
                }
                else
                {
                    AddIrWord iradd = new AddIrWord(new Mydel1(translators.getIRTranslator().AddWord), new ReloadWordsList(this.ReloadWordList));
                    iradd.Show();
                }
            }
        }

        private void createNewFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFile f = new CreateFile(new CreateFiles(CreateFille));
            f.Show();
        }

        public void CreateFille(string path, string FromFile)
        {
            string p = workDirrectory+"\\" + path;
            File.AppendAllText(p, "");
            FilelistBox.Items.Add(path);
            if (path.Contains("IrregularVerbs"))
            {

                irFiles.Add(p);
                translators.addTir(p);
            }
            else
            {
                Files.Add(p);
                translators.addT(p);
            }
            if (FromFile != String.Empty)
            {
                CreateFileByFile f = new CreateFileByFile(translators.getTTranslator(p), FromFile);
                f.ShowDialog();
            }


        }

        private void defaultPerCentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FilelistBox.SelectedItems.Count > 0)
            {
                if (FilelistBox.SelectedItem.ToString().Contains("Words"))
                {
                    translators.getTTranslator().replacePerCent(60);
                }
                else
                {
                    translators.getIRTranslator().replacePerCent(60);

                }
            }
        }

        private void errorFix1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<ErrorWord> words = ErrorWord.ErrorWords.ToList();
            foreach (var item in words)
            {
                if (item.path.Contains("IrregularVerbs"))
                {
                    translators.getIRTranslator(item.path).ReplaceWord(item, String.Format("https://myefe.ru/data/sw/ext/gb/{0}_gb_pronunciation.mp3", item.word));
                }
                else
                {
                    translators.getTTranslator(item.path).ReplaceWord(item, String.Format("https://myefe.ru/data/sw/ext/gb/{0}_gb_pronunciation.mp3", item.word));
                }
            }
        }

        private void findErrorWordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = translators.getTTranslator().findErrorWords();
            MessageBox.Show("Find Error -" + i);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (FilelistBox.SelectedItems.Count > 0)
            {
                String path = FilelistBox.SelectedItem.ToString();
                if (path.Contains("IrregularVerbs"))
                {
                }
                else
                {
                    WordsCoachUa ch = new WordsCoachUa(translators.getTTranslator());
                    ch.Show();
                }
                LoadIrWordsToList();
            }
        }

        private void FilelistBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                menu.Show(FilelistBox, e.Location, LeftRightAlignment.Right);
            }
        }

        private void Mitem_Click(object sender, EventArgs e)
        {
            if (FilelistBox.SelectedItems.Count > 0)
            {
                String str = FilelistBox.SelectedItem.ToString();
                if (MessageBox.Show("Delete "+str, "Delete File", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (str.Contains("IrregularVerbs"))
                    {
                        File.Delete(irFiles[FilelistBox.SelectedIndex - 1]);
                        str = irFiles[FilelistBox.SelectedIndex - 1];
                        irFiles.RemoveAt(FilelistBox.SelectedIndex - 1);
                        translators.RemoveT(str);
                    }
                    else
                    {
                        File.Delete(Files[FilelistBox.SelectedIndex - 1]);
                        str = Files[FilelistBox.SelectedIndex - 1];
                        Files.RemoveAt(FilelistBox.SelectedIndex - 1);
                        translators.RemoveIr(str);
                    }
                    FilelistBox.Items.RemoveAt(FilelistBox.SelectedIndex);
                    FilelistBox.SelectedIndex = 0;
                }
            }
        }

        private void trainingBadLearnWordsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void trainingFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<TrainWord> word = new List<TrainWord>();
            foreach (var item in translators.getTTranslator().GetLocalWords())
            {
                if (item.PerCent < 50)
                {
                    word.Add(item);
                }
            }
            for (int i = 0; i < word.Count; i++)
            {
                for (int j = i; j < word.Count; j++)
                {
                    if (word[i].PerCent > word[j].PerCent)
                    {
                        TrainWord temp = word[i];
                        word[i] = word[j];
                        word[j] = temp;
                    }
                }
            }
            if (word.Count > 0)
            {
                WordsWriteCoach WWC = new WordsWriteCoach(word);

                WWC.Show();
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            int s = WordslistView.Size.Width;
            WordslistView.Columns[0].Width = (s/100)*10;
            WordslistView.Columns[1].Width = (s / 100) * 40;
            WordslistView.Columns[2].Width = (s / 100) * 40;
            WordslistView.Columns[3].Width = (s / 100) * 10;
        }

        public void ContWord(String text)
        {
            TrainWord word = translators.IsExistense(text);
           if (word!=null)
            {
                toolStripTextBox2.Text = word.Translete;
                toolStripTextBox1.BackColor = Color.Green;
            }else
            {
                toolStripTextBox2.Text = "";

                toolStripTextBox1.BackColor = Color.Red;
            }
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                Task.Run(() => ContWord(toolStripTextBox1.Text));
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            Task.Run(() => ContWord(toolStripTextBox1.Text));
        }

        private void errorFix2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 0;
                foreach (var item in translators.getTTranslator().GetLocalWordsI())
                {
                    if (!File.Exists(item.Url))
                    {
                        item.Audio();
                        if(File.Exists(item.Url))
                        {
                            i++;
                        }
                    }
                }
            MessageBox.Show("Find - " + i);
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void getTrainingWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(translators.getTTranslator().GetWorkWords());
            f3.Show();
        }

        private void sadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void findAndAddNewWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindNewWords findNewWords = new FindNewWords();
            findNewWords.FindWORD += FindNewWords_FindWORD;
            findNewWords.CreateFile += FindNewWords_CreateFile;
            findNewWords.getTranslator += FindNewWords_getTranslator;
            findNewWords.Show();
        }

        private TrainingWords FindNewWords_getTranslator(string path)
        {
            TrainingWords t= translators.getTTranslator(path);
            return t;
        }

        private string FindNewWords_CreateFile(string name)
        {
            if (!File.Exists(workDirrectory + "\\" + name))
            {
                string p = workDirrectory + "\\" + "Words-" + name + ".txt";
                File.AppendAllText(p, "");
                FilelistBox.Items.Add(name);
                Files.Add(p);
                translators.addT(p);
                return p;
            }
            return name;
        }

        private FindNewWords.FindWord FindNewWords_FindWORD(string text)
        {
            TrainWord word = translators.IsExistense(text);
            if (word != null)
            {
                return new FindNewWords.FindWord(word.Word, word.path);
            }
            else
            {
                return null;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    } 
}
