using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA
{
   public class ErrorWord
    {
        public int id { get; set; }
        public string word { get; set; }
        public string path { get; set; }
        public static event MainForm.ReloadErrorList Reload;
        public override string ToString()
        {
            return String.Format("{0}%{1}%{2}", this.id, this.word, this.path);
        }
        public ErrorWord()
        {

        }
        public static ErrorWord get(string word,string path)
        {
            foreach (var item in ErrorWords)
            {
                if(item.path==path&&item.word==word)
                {
                    return item;
                }
            }
            return null;
        }
        public ErrorWord(string line)
        {
           string[] mas=line.Split('%');
            this.id = Convert.ToInt32(mas[0]);
            this.word = mas[1];
            this.path = mas[2];
        }
        public static List<ErrorWord> ErrorWords = new List<ErrorWord>();

        public static void add(ErrorWord er)
        {
            foreach (var item in ErrorWords)
            {
                if (item.word == er.word)
                {
                    return;
                }
            }
            ErrorWords.Add(er);
            Reload(er);
        }
        public static void remove(ErrorWord er)
        {
            for (int i = 0; i < ErrorWords.Count; i++)
            {
                if (er.word == ErrorWords[i].word)
                {
                    ErrorWords.RemoveAt(i);
                    Reload(er,true);
                    return;
                }
            }
        }
        public static void addevent(MainForm.ReloadErrorList del)
        {
            Reload += del;
        }
        public static void close()
        {
            File.WriteAllText(MainForm.workDirrectory+"\\ErrorLoader.txt", "");
            StreamWriter stream = new StreamWriter(MainForm.workDirrectory + "\\ErrorLoader.txt");
            foreach (var items in ErrorWords)
            {
                stream.WriteLine(items.ToString());
            }
            stream.Close();
        }
    }
}
