using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TranslateLibary
{
    [Serializable]
    public class TransleteWord
    {
       static WebClient client = new WebClient();
        public int Index { get; set; }
        public string Word { get; set; }
        public string Transcription { get; set; }
        public string Translete { get; set; }
        public int PerCent { get; set; }
        public int Offset { get; set; }
        public string Url { get; set; }
        public int Lenght { get { return ToByteArray().Length; } set { Lenght = 0; } }
        public static TransleteWord Parse(string src)
        {
            TransleteWord temp = new TransleteWord();
            string[] m = src.Split('%');
            temp.Index = Convert.ToInt32(m[0]);
            temp.Word = m[1];
            temp.Transcription = m[2];
            temp.Translete = m[3];
            try
            {
                temp.PerCent = Convert.ToInt32(m[4]);
            }
            catch
            {
                temp.PerCent = 0;
            }
            if (m.Length > 5)
            {
                temp.Url = m[5];
            }
            else
            {
                temp.Url = TransleteWord.AddAudio(temp);
            }
            return temp;

        }
        public TransleteWord()
        {
            this.Word = this.Translete = this.Transcription=this.Url = String.Empty;
            this.Index = this.PerCent =this.Offset=0;
            
        }
        public TransleteWord(TransleteWord word)
        {
            this.Word = word.Word;
            this.Translete = word.Translete;
            this.Transcription = word.Transcription;
            this.PerCent = word.PerCent;
            this.Url = word.Url;
        }
        public TransleteWord (byte[] bytearray)
        {
            FromByteArray(bytearray);
        }


        public override string ToString()
        {
            //return String.Format("{0}%{1}%{2}%{3}%{4}{5}", this.Index, this.Word, this.Transcription, this.Translete, this.PerCent, Environment.NewLine);
            return String.Format("{0}%{1}%{2}%{3}%{4}%{5}{6}", this.Index, this.Word, this.Transcription, this.Translete, this.PerCent, this.Url, Environment.NewLine);
           
        }
        public byte[] ToByteArray()
        {

            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, this);
                return ms.ToArray();
                
            }
        }
        public static string AddAudio(TransleteWord word)
        {
            string Url= string.Format("https://myefe.ru/data/sw/words/us/{0}/{1}__us_1.mp3", word.Word[0], word.Word);
            string filename = "F:\\EnglishWords\\sound\\" + word.Word + ".mp3";
            if (File.Exists(filename) == false)
            {
                try
                {
                    client.DownloadFile(Url, filename);
                }
                catch
                {
                    Translator.addError(word.Word);
                    return "";
                }
            }
            return filename;
        }
        public void Audio()
        {
            string Url = string.Format("https://myefe.ru/data/sw/words/us/{0}/{1}__us_1.mp3", this.Word[0], this.Word);
            string filename = "F:\\EnglishWords\\sound\\" + this.Word + ".mp3";
           
            if (File.Exists(filename) == false)
            {
                try
                {
                    client.DownloadFile(Url, filename);
                    Translator.removeError(this.Word);
                }
                catch
                {

                    Translator.addError(this.Word);
                    this.Url = filename;
                    return;
                }
            }
            this.Url = filename;
        }
        public void Audio(string url)
        {
            if (File.Exists(url))
            {
                this.Url = url;
            }
            else if(url.Contains("myefe"))
            {
                string filename = "F:\\EnglishWords\\sound\\" + this.Word + ".mp3";
                try
                {
                    client.DownloadFile(url, filename);
                    this.Url = url;
                    Translator.removeError(this.Word);
                }
                catch
                {

                }
            }
        }

        private void FromByteArray(byte[] data)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                TransleteWord temp=(TransleteWord)obj;
                this.Word = temp.Word;
                this.Translete = temp.Translete;
                this.Transcription = temp.Transcription;
                this.Index = temp.Index;
                this.PerCent = temp.PerCent;
            }
        }
    }
}
