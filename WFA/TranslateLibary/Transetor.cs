using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateLibary
{
   public class Translator
    {
        private List<TransleteWord> BufferWords = null;
        private List<TransleteWord> WorkWords = null;
        private List<TransleteWord> NewWords = null;
        //public event Form4.Mydel NEXT;
        //public event Trainer.TrDel StartTraires;
        public static List<string> ErrorWords = new List<string>();
        private TransleteWord CurrentWord = null;
        private Random rand = null;
        private int Iterator = 0;
        public int CountLocalWords { get; private set; }
        public int AmountCorrectAnswer { get; private set; }
        public int AmountWord { get; private set; }
        public int AmountF1 { get; private set; }
        public int CountAllAnswer { get; private set; }
        public string Path { get; private set; }

        public void SetPath(string src)
        {
            Path = src;
            LoadFromFile();
        }

        private void Initialize()
        {
            this.NewWords = new List<TransleteWord>();
            this.BufferWords = new List<TransleteWord>();
            this.WorkWords = new List<TransleteWord>();
            this.rand = new Random(DateTime.UtcNow.Second);
            this.AmountCorrectAnswer = 0;
            this.CountAllAnswer = 0;

        }
        //public void yy(Form4.Mydel del)
        //{
        //    NEXT += del;
        //}

        public Translator()
        {
            Initialize();
        }

        public Translator(String Path)
        {
            Initialize();
            this.Path = Path;
        }

        private void LoadFromFile()
        {
            BufferWords.Clear();
            CountLocalWords = 0;
            StreamReader stream = new StreamReader(Path);
            while (!stream.EndOfStream)
            {
                BufferWords.Add(TransleteWord.Parse(stream.ReadLine()));
                CountLocalWords++;
            }
            stream.Close();
        }
        
        private void setAnsver(int id,bool correct=true)
        {
            if (correct == true)
            {
                if (BufferWords[id].PerCent <= 50)
                    BufferWords[id].PerCent += 10;
                else if (BufferWords[id].PerCent + 25 <= 160)
                    BufferWords[id].PerCent += 25;
                else
                    BufferWords[id].PerCent = 160;
                AmountCorrectAnswer++;
            }
            else
            {
                NewWords.Add(CurrentWord);
                if (BufferWords[id].PerCent - 20 >= 0)
                    BufferWords[id].PerCent -= 20;
                else
                    BufferWords[id].PerCent = 0;
                AmountF1++;
                AmountCorrectAnswer--;
            }
        }

        public void loadNewTrainers(int corectedValue=0)
        {
            AmountCorrectAnswer = 0;
            CountAllAnswer = 0;
            AmountF1 = 0;
            WorkWords.Clear();
            NewWords.Clear();
            foreach (var temp in BufferWords)
            {
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
                                    WorkWords.Add(temp);
                                break;
                            case 140:
                                if (rand.Next(10, 100) < 5)
                                    WorkWords.Add(temp);
                                break;
                            case 130:
                                if (rand.Next(10, 100) < 10)
                                    WorkWords.Add(temp);
                                break;
                            case 120:
                                if (rand.Next(10, 100) < 20)
                                    WorkWords.Add(temp);
                                break;
                            case 110:
                                if (rand.Next(10, 100) < 30)
                                    WorkWords.Add(temp);
                                break;
                            default:
                                if (rand.Next(10, 100) < 40)
                                    WorkWords.Add(temp);
                                break;
                        }
                    }

                }
                else
                {
                    WorkWords.Add(temp);
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

        public List<TransleteWord> GetLocalWords()
        {
            return BufferWords;
        }
        public IEnumerable<TransleteWord> GetLocalWordsI()
        {
            foreach (var item in BufferWords)
            {
                yield return item;
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

        public TransleteWord getTrainerWord()
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

        public void ReplaceWord(TransleteWord word)
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
        }

        public void RemoveWord(TransleteWord word)
        {
            BufferWords.RemoveAt(word.Index - 1);
            CountLocalWords--;
            int i = 1;
            foreach (var item in BufferWords)
            {
                item.Index = i;
                i++;
            }
        }

        public void AddWord(TransleteWord word,bool newfile=false)
        {
            if (Path!=String.Empty)
            {
                if (containWord(word.Word) == false)
                {
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

        public void saveToFile()
        {
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
        }

        private string GetFileName()
        {
            DirectoryInfo info = new DirectoryInfo("F:\\EnglishWords");
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
            string hh = "F:\\EnglishWords\\Words-" + max + ".txt";
            File.Create(hh).Close();
            return hh;
        }
        public static void addError(string word)
        {
            foreach (var item in ErrorWords)
            {
                if(item==word)
                {
                    return;
                }
            }
            ErrorWords.Add(word);
        }
        public static void removeError(string word)
        {
            for (int i = 0; i < ErrorWords.Count-1; i++)
            {
                if(word==ErrorWords[i])
                {
                    ErrorWords.RemoveAt(i);
                    return;
                }
            }
        }
        public void replacePerCent(int value)
        {
            foreach (var item in BufferWords)
            {
                item.PerCent = value;
            }
        }
        //public void newWord()
        //{
        //    if (NewWords.Count > 0)
        //    {
        //        int n = rand.Next(0, NewWords.Count - 1);
        //        NEXT(NewWords[n]);
        //        NewWords.RemoveAt(n);
        //    }
        //}
    }
}
