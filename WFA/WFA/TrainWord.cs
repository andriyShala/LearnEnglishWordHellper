using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
namespace WFA
{
    public class TrainWord
    {
       
       static WebClient client = new WebClient();
        public int Index { get; set; }
        public string Word { get; set; }
        public string Transcription { get; set; }
        public string Translete { get; set; }
        public int PerCent { get; set; }
        public string Url { get; set; }
        public string path { get; set; }
        public int BadTries { get; set;}
        public int GoodTries { get; set; }
        
        public Color GetColor()
        {
            if (PerCent >= 100)
            {
                return Color.FromArgb(0, 255, 0);
            }
            else if(PerCent>=80)
            {
                return Color.FromArgb(204, 255, 102);
            }
            else if(PerCent>=60)
            {
                return Color.FromArgb(255, 255, 0);
            }
            else if (PerCent>=50)
            {
                return Color.FromArgb(255, 153, 0);
            }
            else if(PerCent>=40)
            {
                return Color.FromArgb(255, 102, 51);
            }
            else
            {
                return Color.FromArgb(230, 57, 0);
            }
        }
        public TrainWord(string src,string path)
        {
            string[] m = src.Split('%');
            this.path = path;
            this.Index = Convert.ToInt32(m[0]);
            this.Word = m[1];
            this.Transcription = m[2];
            this.Translete = m[3];
            try
            {
                this.PerCent = Convert.ToInt32(m[4]);
            }
            catch
            {
                this.PerCent = 0;
            }
            if (m.Length > 5)
            {
                this.Url = m[5];
                if (this.Url == String.Empty)
                {
                    this.Audio();
                }
            }
            else
            {
                Audio();
            }
            if(m.Length>6)
            {
                this.BadTries = Convert.ToInt32(m[6]);
            }
            else
            {
                this.BadTries = 0;
            }
            this.GoodTries = 0;
        }

        public TrainWord(string path)
        {
            this.Word = this.Translete = this.Transcription=this.Url = String.Empty;
            this.Index = this.PerCent=this.BadTries =0;
            this.path = path;
            this.GoodTries = 0;
        }
        public TrainWord()
        {
            this.Word = this.Translete = this.Transcription = this.Url = String.Empty;
            this.Index = this.PerCent = this.BadTries = 0;
            this.path = "";
            this.GoodTries = 0;
        }

        public TrainWord(TrainWord word)
        {
            this.Word = word.Word;
            this.Translete = word.Translete;
            this.Transcription = word.Transcription;
            this.PerCent = word.PerCent;
            this.Url = word.Url;
            this.BadTries = word.BadTries;
            this.GoodTries = 0;
        }

        public override string ToString()
        {
            //return String.Format("{0}%{1}%{2}%{3}%{4}{5}", this.Index, this.Word, this.Transcription, this.Translete, this.PerCent, Environment.NewLine);
            return String.Format("{0}%{1}%{2}%{3}%{4}%{5}%{6}{7}", this.Index, this.Word, this.Transcription, this.Translete, this.PerCent, this.Url,this.BadTries, Environment.NewLine);

           
        }
        public void Audio()
        {
            string Url= string.Format("https://myefe.ru/data/sw/words/us/{0}/{1}__us_1.mp3", this.Word[0], this.Word);
            string filename = MainForm.workDirrectory +  "\\" + this.Word + ".mp3";
            if (File.Exists(filename) == false)
            {
                try
                {
                    client.DownloadFile(Url, filename);
                    ErrorWord er = new ErrorWord() { id = this.Index, word = this.Word, path = this.path };
                    ErrorWord.remove(er);
                }
                catch
                {
                    AddAudio4();
                    if(Url == "")
                    {
                        AddAudio2();
                        if(Url == "")
                        {
                            AddAudio3();
                            if (Url == "")
                            {
                                ErrorWord er = new ErrorWord() { id = this.Index, word = this.Word, path = this.path };
                                ErrorWord.add(er);
                                this.Url="";
                                return;
                            }
                        }
                    }
                }
            }
            this.Url=filename;
        }
        public void AddAudio2()
        {
            string Url = string.Format("https://myefe.ru/data/sw/words/us/{0}/{1}__us_2.mp3", this.Word[0], this.Word);
            string filename = MainForm.workDirrectory + "\\" + "sound\\" + this.Word + ".mp3";
            if (File.Exists(filename) == false)
            {
                try
                {
                    client.DownloadFile(Url, filename);
                }
                catch
                {
                    this.Url= "";
                    return;
                }
            }
            this.Url = filename;
            return;
        }
        public void AddAudio3()
        {
            string Url = string.Format("https://myefe.ru/data/sw/ext/gb/{0}_gb_pronunciation.mp3", this.Word[0], this.Word);
            string filename = MainForm.workDirrectory + "\\" + "sound\\" + this.Word + ".mp3";
            if (File.Exists(filename) == false)
            {
                try
                {
                    client.DownloadFile(Url, filename);
                }
                catch
                {
                    this.Url = "";
                    return;
                }
            }
            this.Url = filename;
            return;
        }
        public  void AddAudio4()
        {
            string Url = string.Format("https://myefe.ru/data/sw/cwords/us/{0}/{1}.mp3", this.Word[0], this.Word);
            string filename = MainForm.workDirrectory + "\\" + "sound\\" + this.Word + ".mp3";
            if (File.Exists(filename) == false)
            {
                try
                {
                    client.DownloadFile(Url, filename);
                }
                catch
                {
                    this.Url = "";
                    return;
                }
            }
            this.Url = filename;
            return;
        }
      
        public void Audio(string url)
        {
            if (File.Exists(url))
            {
                this.Url = url;
            }
            else if(url.Contains("myefe"))
            {
                string filename = MainForm.workDirrectory + "\\" + "sound\\" + this.Word + ".mp3";
                try
                {
                    client.DownloadFile(url, filename);
                    this.Url = filename;
                    ErrorWord er = new ErrorWord() { id = this.Index, word = this.Word, path = path };
                    ErrorWord.remove(er);
                }
                catch
                {

                }
            }
        }
    }
}
