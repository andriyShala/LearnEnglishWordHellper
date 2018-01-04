using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA
{
  public class IrTransetor
    {
        private List<IrregularVerb> BufferWords = null;
        private List<IrregularVerb> WorkWords = null;
        private IrregularVerb CurrentWord = null;
        private Random rand = null;
        private int Iterator = 0;
        public event MainForm.StartLoad StartLoad;
        public event MainForm.StopLoad StopLoad;
        public int CountLocalWords { get; private set; }
        public int AmountCorrectAnswer { get; private set; }
        public int AmountWord { get; private set; }
        public int AmountF1 { get; private set; }
        public int CountAllAnswer { get; private set; }
        public string Path { get; private set; }

        public void SetPath(string src)
        {
            Path = src;
            Task.Run(new Action(() => LoadFromFile()));
        }
        private void Initialize()
        {
            this.BufferWords = new List<IrregularVerb>();
            this.WorkWords = new List<IrregularVerb>();
            this.rand = new Random(DateTime.UtcNow.Second);
            this.AmountCorrectAnswer = 0;
            this.CountAllAnswer = 0;

        }
        public IrTransetor()
        {
            Initialize();
        }

        public IrTransetor(String Path, MainForm.StartLoad del1, MainForm.StopLoad del2)
        {
            StartLoad += del1;
            StopLoad += del2;
            Initialize();
            SetPath(Path);
        }
        private void setAnsver(int id, bool correct = true)
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
                if (BufferWords[id].PerCent - 20 >= 0)
                    BufferWords[id].PerCent -= 20;
                else
                    BufferWords[id].PerCent = 0;
                AmountF1++;
                AmountCorrectAnswer--;
            }
        }
        private void LoadFromFile()
        {
            StartLoad(this.Path);
            BufferWords.Clear();
            CountLocalWords = 0;
            StreamReader stream = new StreamReader(Path);
            while (!stream.EndOfStream)
            {
                BufferWords.Add(IrregularVerb.Parse(stream.ReadLine(),this.Path));
                CountLocalWords++;
            }
            stream.Close();
            StopLoad(this.Path);
        }
        public void loadNewTrainers(int corectedValue = 0)
        {
            AmountCorrectAnswer = 0;
            CountAllAnswer = 0;
            AmountF1 = 0;
            WorkWords.Clear();
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
        public List<IrregularVerb> GetLocalWords()
        {
            return BufferWords;
        }
        public IEnumerable<IrregularVerb> GetLocalWordsI()
        {
            for (int i = 0; i < BufferWords.Count; i++)
            {
                yield return BufferWords[i];
            }
        }
        public void replacePerCent(int value)
        {
            foreach (var item in BufferWords)
            {
                item.PerCent = value;
            }
        }
        public void Next()
        {
            int n = rand.Next(0, Iterator);
            if (WorkWords.Count == 0)
            {
                    throw new Exception(String.Format("Result All={0},F1={1},Correct={2}", AmountWord, AmountF1, AmountCorrectAnswer));
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
        private bool containWord(IrregularVerb ir)
        {
            foreach (var item in BufferWords)
            {
                if (item.Word1 == ir.Word1&&item.Word2==ir.Word2&&item.Word3==ir.Word3)
                {
                    return true;
                }
            }
            return false;

        }
        public IrregularVerb getTrainerWord()
        {
            return CurrentWord;
        }
        public void AddWord(IrregularVerb word)
        {
            if (!containWord(word))
            {
                word.path = Path;
                word.Index = BufferWords.Count + 1;
                word.Url1 = word.AddAudio(word.Word1);
                word.Url2 = word.AddAudio(word.Word2);
                word.Url3 = word.AddAudio(word.Word3);
                File.AppendAllText(Path, word.ToString());
                BufferWords.Add(word);
                CountLocalWords++;
            }
        }
        public bool[] SetAnswer(string Answer1,string Answer2,string Answer3, bool UAWord = false)
        {
            bool[] mas = new bool[3];
            
            try
            {
                if(Answer1==CurrentWord.Word1)
                {
                    mas[0] = true;
                }
                else
                {
                    mas[0] = false;
                }
                if (Answer2 == CurrentWord.Word2)
                {
                    mas[1] = true;
                }
                else
                {
                    mas[1] = false;
                }
                if (Answer3 == CurrentWord.Word3)
                {
                    mas[2] = true;
                }
                else
                {
                    mas[2] = false;
                }

                if (mas[0]==true&&mas[1]==true&&mas[2]==true)
                    {

                        setAnsver(CurrentWord.Index - 1);
                        CountAllAnswer++;
                    }
                return mas;

            }
            catch
            {
                return mas;
            }
        }
        public void ReplaceWord(IrregularVerb word)
        {
            int index = word.Index;
            BufferWords[index].Word1 = word.Word1;
            BufferWords[index].Word2 = word.Word2;
            BufferWords[index].Word3 = word.Word3;

            BufferWords[index].Translete = word.Translete;
            BufferWords[index].PerCent = word.PerCent;
            if (BufferWords[index].Url1 != word.Url1)
            {
                BufferWords[index].Audio(1,word.Url1);
            }
            if (BufferWords[index].Url2 != word.Url2)
            {
                BufferWords[index].Audio(2,word.Url2);
            }
            if (BufferWords[index].Url3 != word.Url3)
            {
                BufferWords[index].Audio(3,word.Url3);
            }
        }
        public void ReplaceWord(ErrorWord word, string url)
        {
            try
            {
                if (word.word == BufferWords[word.id - 1].Word1)
                {
                    BufferWords[word.id - 1].Audio(1, url);
                }
                if (word.word == BufferWords[word.id - 1].Word2)
                {
                    BufferWords[word.id - 1].Audio(2, url);
                }
                if (word.word == BufferWords[word.id - 1].Word3)
                {
                    BufferWords[word.id - 1].Audio(3, url);
                }
            }
            catch { }
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
    }
}
