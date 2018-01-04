using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA
{
   public class TrainingWords
    {
        private List<TrainWord> BufferWords = null;
        private List<TrainWord> WorkWords = null;
        private List<TrainWord> NewWords = null;
        public delegate bool Containc(TrainWord word);
        public delegate void ChangeWord(TrainWord word, String path);
        public event Form4.Mydel NEXT;
        public event ChangeWord ChangedWord;
        public event Trainer.TrDel StartTraires;
        public event MainForm.StartLoad StartLoad;
        public event MainForm.StopLoad StopLoad;
        private TrainWord CurrentWord = null;
        private bool CurrentWordF1 = false;
        private int PercentMinus = 0;
        private int PercentPlus = 0;
        private Random rand = null;
        private int Iterator = 0;
        public int CountLocalWords { get; private set; }
        public int AmountCorrectAnswer { get; private set; }
        public int AmountWord { get; private set; }
        public int AmountF1 { get; private set; }
        public int CountAllAnswer { get; private set; }
        public string Path { get; private set; }
        private int countBadTries { get; set; }
        public static List<TrainWord> BadKnow = new List<TrainWord>();

        public IEnumerable<TrainWord> GetWorkWordsI()
        {
            foreach (var item in WorkWords)
            {
                yield return item;
            }
        }
        public List<TrainWord> GetWorkWords()
        {
            return WorkWords;
        }
        public static void SaveBadKmow()
        {
            try
            {
                File.WriteAllText(MainForm.workDirrectory + "\\BadWords.txt", "");
                StreamWriter writer = new StreamWriter(MainForm.workDirrectory + "\\BadWords.txt");
                foreach (var item in BadKnow)
                {
                    writer.Write(item.ToString());
                }
                writer.Close();
            }
            catch
            {

            }
           
        }
        public static void LoadBadKnow()
        {
            try
            {
                StreamReader stream = new StreamReader(MainForm.workDirrectory + "\\BadWords.txt");
                while (!stream.EndOfStream)
                {
                    BadKnow.Add(new TrainWord(stream.ReadLine()));
                }
                stream.Close();
            }
            catch
            {

            }
          
        }

        public static void AddBadKnowWord(TrainWord word)
        {
            foreach (var item in BadKnow)
            {
                if(item.Word==word.Word)
                {
                    return;
                }
            }
            Log.Add(word.path, "Word -" + word.Word + "; added To BadKnowList");
            BadKnow.Add(word);
        }

        public static void RemoveBadKnowWord(TrainWord word)
        {
            for (int i = 0; i < BadKnow.Count; i++)
            {
                if(BadKnow[i].Word==word.Word)
                {
                    BadKnow.RemoveAt(i);
                    Log.Add(word.path, "Word -" + word.Word + "; remove From BadKnowList");
                    return;
                }
            }
        }

        public void SetPath(string src)
        {
            Path = src;
            Task.Run(new Action(()=>LoadFromFile()));
        }

        private void Initialize()
        {
            this.PercentMinus= Convert.ToInt32(ConfigurationManager.AppSettings["PercentMinus"]);
            this.PercentPlus= Convert.ToInt32(ConfigurationManager.AppSettings["PercentPlus"]);
            this.NewWords = new List<TrainWord>();
            this.BufferWords = new List<TrainWord>();
            this.WorkWords = new List<TrainWord>();
            this.rand = new Random(DateTime.UtcNow.Second);
            this.AmountCorrectAnswer = 0;
            this.CountAllAnswer = 0;
            this.countBadTries =Convert.ToInt32(ConfigurationManager.AppSettings["BadTries"]);

        }
        public void yy(Form4.Mydel del)
        {
            NEXT += del;
        }

        public TrainingWords()
        {
            Initialize();
        }

        public TrainingWords(String Path,MainForm.StartLoad del1,MainForm.StopLoad del2,ChangeWord ch)
        {
            StartLoad += del1;
            StopLoad += del2;
            ChangedWord += ch;
            Initialize();
            SetPath(Path);
            
        }

        private void LoadFromFile()
        {
            StartLoad(this.Path);
            BufferWords.Clear();
            CountLocalWords = 0;
            StreamReader stream = new StreamReader(Path);
            while (!stream.EndOfStream)
            {
                BufferWords.Add(new TrainWord(stream.ReadLine(),Path));
                CountLocalWords++;
            }
            stream.Close();
            StopLoad(this.Path);
        }
        public TrainWord Get(int index)
        {
            return BufferWords[index];
        }
        private void setAnsver(int id,bool correct=true)
        {
            TrainWord word = BufferWords[id];
            if (correct == true&&CurrentWordF1==false)
            {
                if (word.PerCent <= 50)
                    BufferWords[id].PerCent += PercentPlus/2;
                else if (word.PerCent + PercentPlus <= 160)
                    BufferWords[id].PerCent += PercentPlus;
                else
                    BufferWords[id].PerCent = 160;
                 AmountCorrectAnswer++;
                if (word.GoodTries >= 2)
                {
                    BufferWords[id].GoodTries = 0;
                    if (word.BadTries-2>=0)
                    {
                        BufferWords[id].BadTries-=2;
                        if(BufferWords[id].BadTries==0)
                        {
                            TrainingWords.RemoveBadKnowWord(BufferWords[id]);
                        }
                    }
                }
                else
                {
                    BufferWords[id].GoodTries++;
                }
                Log.Add(this.Path, "word -" + word.Word + " corect Ansver Percent-" + word.PerCent);

            }
            else if(correct==false)
            {
                if (word.PerCent - PercentMinus >= 0)
                    BufferWords[id].PerCent -= PercentMinus;
                else
                    BufferWords[id].PerCent = 0;
                CurrentWordF1 = true;
                AmountF1++;


                if (BufferWords[id].BadTries<Convert.ToInt32(ConfigurationManager.AppSettings["BadTries"]))
                {
                    BufferWords[id].BadTries++;
                    if(BufferWords[id].GoodTries>0)
                    {
                        BufferWords[id].GoodTries = 0;
                    }
                }
                else
                {
                    TrainingWords.AddBadKnowWord(BufferWords[id]);
                }
                Log.Add(this.Path, "word -" + word.Word + " bad Ansver Percent-"+word.PerCent);

            }
            ChangedWord(BufferWords[id], this.Path);
        }

        public void loadNewTrainers(int corectedValue=0)
        {
            AmountCorrectAnswer = 0;
            CountAllAnswer = 0;
            AmountF1 = 0;
            WorkWords.Clear();
            NewWords.Clear();
            this.PercentMinus = Convert.ToInt32(ConfigurationManager.AppSettings["PercentMinus"]);
            this.PercentPlus = Convert.ToInt32(ConfigurationManager.AppSettings["PercentPlus"]);
            int index = 0;
            foreach (var temp in BufferWords)
            {
                if (WorkWords.Count > 0)
                {
                     index = rand.Next(0, WorkWords.Count - 1);
                }
                    if (temp.PerCent + corectedValue >= 100)
                {
                    if (temp.PerCent + corectedValue > 150)
                    {
                    }
                    else
                    {
                        switch (temp.PerCent + corectedValue)
                        {

                            case 150:
                                if (rand.Next(10, 100) < 5)
                                    WorkWords.Insert(index, temp);
                                break;
                            case 140:
                                if (rand.Next(10, 100) < 5)
                                    WorkWords.Insert(index, temp);
                                break;
                            case 130:
                                if (rand.Next(10, 100) < 10)
                                    WorkWords.Insert(index, temp);
                                break;
                            case 120:
                                if (rand.Next(10, 100) < 20)
                                    WorkWords.Insert(index, temp);
                                break;
                            case 110:
                                if (rand.Next(10, 100) < 30)
                                    WorkWords.Insert(index, temp);
                                break;
                            default:
                                if (rand.Next(10, 100) < 40)
                                    WorkWords.Insert(index, temp);
                                break;
                        }
                    }

                }
                else
                {
                    WorkWords.Insert(index, temp);
                    if (temp.PerCent + corectedValue <= 50)
                    {
                        WorkWords.Insert(rand.Next(0, WorkWords.Count - 1), temp);
                        if (temp.PerCent + corectedValue <= 30)
                        {
                            WorkWords.Insert(rand.Next(0, WorkWords.Count - 1), temp);
                        }
                    }
                }

            }
            Iterator = WorkWords.Count() - 1;
            AmountWord = WorkWords.Count();
        }

        public List<TrainWord> GetLocalWords()
        {
            return BufferWords;
        }
        public IEnumerable<TrainWord> GetLocalWordsI()
        {
            for(int i=0;i<BufferWords.Count;i++)
            {
                yield return BufferWords[i];
            }
        }

        public void Next()
        {
            int n = rand.Next(0, Iterator);
            if (WorkWords.Count == 0)
            {
                if (NewWords.Count == 0)
                {
                    throw new Exception(String.Format("Result All={0},F1={1},Correct={2}", AmountWord, AmountF1, AmountCorrectAnswer));
                }
                else
                {
                    //StartTraires();
                    throw new Exception(String.Format("Result All={0},F1={1},Correct={2}", AmountWord, AmountF1, AmountCorrectAnswer));
                }
            }
            else
            {
                CurrentWordF1 = false;
                CurrentWord = WorkWords[n];
                WorkWords.RemoveAt(n);
                if (Iterator - 1 != -1)
                    Iterator--;
            }
           
        }
        public void F1()
        {
            setAnsver(CurrentWord.Index - 1, false);
        }

        public TrainWord getTrainerWord()
        {
            return CurrentWord;
        }
        public string[] getTrainerWords()
        {
            String[] words = new String[4];
            int countLocal = BufferWords.Count - 1;
            int ig = rand.Next(1, 5);
                    switch (ig)
                    {   

                        case 1:
                            words[0] = CurrentWord.Translete;
                             words[1] = BufferWords[rand.Next(0, countLocal)].Translete;
                           words[2] = BufferWords[rand.Next(0, countLocal)].Translete;
                          words[3] = BufferWords[rand.Next(0, countLocal)].Translete;
                            break;
                        case 2:
                    words[1] = CurrentWord.Translete;
                    words[2] = BufferWords[rand.Next(0, countLocal)].Translete;
                    words[3] = BufferWords[rand.Next(0, countLocal)].Translete;
                    words[0] = BufferWords[rand.Next(0, countLocal)].Translete;
                            break;
                        case 3:
                    words[2]= CurrentWord.Translete;
                    words[3] = BufferWords[rand.Next(0, countLocal)].Translete;
                    words[0] = BufferWords[rand.Next(0, countLocal)].Translete;
                    words[1] = BufferWords[rand.Next(0, countLocal)].Translete;
                            break;
                        case 4:
                    words[3] = CurrentWord.Translete;
                    words[0] = BufferWords[rand.Next(0, countLocal)].Translete;
                    words[1] = BufferWords[rand.Next(0, countLocal)].Translete;
                    words[2] = BufferWords[rand.Next(0, countLocal)].Translete;
                            break;
                        default:
                    words[0] = CurrentWord.Translete;
                    words[1] = BufferWords[rand.Next(0, countLocal)].Translete;
                    words[2] = BufferWords[rand.Next(0, countLocal)].Translete;
                    words[3] = BufferWords[rand.Next(0, countLocal)].Translete;
                            break;
                    }
            return words;
        }

        public void ReplaceWord(TrainWord word)
        {
            int index = word.Index - 1;
            BufferWords[index].Word = word.Word;
            BufferWords[index].Translete = word.Translete;
            BufferWords[index].Transcription = word.Transcription;
            BufferWords[index].PerCent = word.PerCent;
            if (BufferWords[index].Url != word.Url)
            {
                BufferWords[index].Audio(word.Url);
            }
            ChangedWord(BufferWords[index], this.Path);
        }
        public void ReplaceWord(ErrorWord word,string url)
        {
            BufferWords[word.id-1].Audio(url);
        }

        public void RemoveWord(TrainWord word)
        {
            for(int j=0;j<BufferWords.Count;j++)
            {
                if(BufferWords[j].Word==word.Word)
                {
                    BufferWords.RemoveAt(j);
                    break;
                }
            }
            Log.Add(this.Path, "Remove - " + word.Word);
            CountLocalWords--;
            int i = 1;
            foreach (var item in BufferWords)
            {
                item.Index = i;
                i++;
            }
        }
        public void AddWord(TrainWord word)
        {
            AddWord(word, false);
        }
        public void AddWord(TrainWord word,bool newfile=false)
        {
            if (Path!=String.Empty)
            {
                if (containWord(word.Word) == false)
                {
                    word.path = Path;
                    word.PerCent = 50;
                    word.Audio();
                    if (BufferWords.Count + 1 <= 100 || newfile == false)
                    {
                        word.Index = BufferWords.Count + 1;
                        File.AppendAllText(Path, word.ToString());
                        BufferWords.Add(word);
                        CountLocalWords++;
                    }
                    else
                    {
                        BufferWords.Clear();
                        CountLocalWords = 0;
                        this.Path = GetFileName();
                        word.Index = 1;
                        File.AppendAllText(Path, word.ToString());
                        BufferWords.Add(word);
                        throw new Exception(this.Path);
                    }
                }
            }
            else
                throw new Exception("Selected File");
        }

        public bool SetAnswer(string Answer,bool UAWord=false)
        {
            try
            {
                if (UAWord == true)
                {
                    if (Answer == CurrentWord.Translete)
                    {
                        
                        setAnsver(CurrentWord.Index - 1);
                        CountAllAnswer++;
                        return true;
                    }
                    else
                    {
                        return false;

                    }
                }
                else
                {

                    if (Answer == CurrentWord.Word)
                    {
                       
                        setAnsver(CurrentWord.Index - 1);
                        CountAllAnswer++;
                        return true;

                    }
                    else
                    {
                        return false;

                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private bool containWord(string word)
        {
            foreach (var item in BufferWords)
            {
                if (item.Word == word)
                {
                    return true;
                }
            }
            return false;

        }
        public int findErrorWords()
        {
            int i = 0;
            foreach (var item in BufferWords)
            {
                if(!File.Exists(item.Url))
                {
                    i++;
                    ErrorWord.add(new ErrorWord()
                    {
                        id = item.Index,
                        path = item.path,
                        word = item.Word
                    });
                }
            }
            return i;
        }
        public void saveToFile()
        {
            StartLoad(this.Path, true);
            try
            {
                File.WriteAllText(Path, "");
                StreamWriter writer = File.AppendText(Path);
                foreach (var item in BufferWords)
                {
                    writer.Write(item.ToString());
                }
                writer.Close();
            }
            catch
            {

            }
            StopLoad(this.Path, true);
        }

        private string GetFileName()
        {
            DirectoryInfo info = new DirectoryInfo(MainForm.workDirrectory);
            int max = 1;
            foreach (var item in info.GetFiles())
            {
                if (item.Name.Contains("Words-"))
                {
                    string name = item.Name.Remove(item.Name.Length - 4);

                    try
                    {
                        string f = name.Substring(6);
                        int temp = Convert.ToInt32(f);
                        if (temp >= max)
                            max++;
                    }
                    catch { }
                }
            }
            string hh = MainForm.workDirrectory + "\\Words -" + max + ".txt";
            File.Create(hh).Close();
            return hh;
        }
       
        public void replacePerCent(int value)
        {
            foreach (var item in BufferWords)
            {
                item.PerCent = value;
                ChangedWord(item, this.Path);
            }
        }
        public void newWord()
        {
            if (NewWords.Count > 0)
            {
                int n = rand.Next(0, NewWords.Count - 1);
                NEXT(NewWords[n]);
                NewWords.RemoveAt(n);
            }
        }
    }
}
