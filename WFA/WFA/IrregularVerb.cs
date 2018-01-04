using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WFA
{
   public class IrregularVerb
    {
        static WebClient client = new WebClient();
        public int Index { get; set; }
        public string Translete { get;set;}
        public string Word1 { get; set; }
        public string Word2 { get; set; }
        public string Word3 { get; set; }
        public string Url1 { get; set; }
        public string Url2 { get; set; }
        public string Url3 { get; set; }
        public int PerCent { get; set; }
        public string path { get; set; }

        public void Audio(int urlid,string url)
        {
            switch (urlid)
            {
                case 1:
                    if (File.Exists(url))
                    {
                        this.Url1 = url;
                    }
                    else if (url.Contains("myefe"))
                    {
                        string filename = MainForm.workDirrectory +"\\sound\\" + this.Word1 + ".mp3";
                        try
                        {
                            client.DownloadFile(url, filename);
                            this.Url1 = filename;
                            ErrorWord er = new ErrorWord();
                            er.id = this.Index;
                            er.word = this.Word1;
                            
                            ErrorWord.remove(er);
                        }
                        catch
                        {

                        }
                    }
                    break;
                case 2:
                    if (File.Exists(url))
                    {
                        this.Url2 = url;
                    }
                    else if (url.Contains("myefe"))
                    {
                        string filename = MainForm.workDirrectory + "\\sound\\" + this.Word2 + ".mp3";
                        try
                        {
                            client.DownloadFile(url, filename);
                            this.Url2 = filename;
                            ErrorWord er = new ErrorWord();
                            er.id = this.Index;
                            er.word = this.Word2;

                            ErrorWord.remove(er);
                        }
                        catch
                        {

                        }
                    }
                    break;
                case 3:
                    if (File.Exists(url))
                    {
                        this.Url3 = url;
                    }
                    else if (url.Contains("myefe"))
                    {
                        string filename = MainForm.workDirrectory + "\\sound\\" + this.Word3 + ".mp3";
                        try
                        {
                            client.DownloadFile(url, filename);
                            this.Url3 = filename;
                            ErrorWord er = new ErrorWord();
                            er.id = this.Index;
                            er.word = this.Word3;

                            ErrorWord.remove(er);
                        }
                        catch
                        {

                        }
                    }
                    break;
                default:
                    break;
            }
        }
        public static IrregularVerb Parse(string src,string path)
        {
            IrregularVerb temp = new IrregularVerb();
            string[] m = src.Split('%');
            temp.Index =Convert.ToInt32(m[0]);
            temp.path = path;
            temp.Word1 = m[1];
            temp.Word2 = m[2];
            temp.Word3 = m[3];
            temp.Translete = m[4];
            temp.PerCent = Convert.ToInt32(m[5]);
            if(m.Length>6)
            {
                temp.Url1 = m[6];
                temp.Url2 = m[7];
                temp.Url3 = m[8];
                if(temp.Url1==string.Empty)
                {
                    temp.Url1 = temp.AddAudio(temp.Word1);
                }
                if (temp.Url2 == string.Empty)
                {
                    temp.Url2 = temp.AddAudio(temp.Word2);
                }
                if (temp.Url3 == string.Empty)
                {
                    temp.Url3 = temp.AddAudio(temp.Word3);
                }
            }
            else
            {
                temp.Url1 = temp.AddAudio(temp.Word1);
                temp.Url2 = temp.AddAudio(temp.Word2);
                temp.Url3 = temp.AddAudio(temp.Word3);

            }
            return temp;
        }
        public override string ToString()
        {
            return String.Format("{0}%{1}%{2}%{3}%{4}%{5}%{6}%{7}%{8}{9}",this.Index.ToString(),this.Word1,this.Word2,this.Word3,this.Translete,this.PerCent.ToString(),this.Url1,this.Url2,this.Url3, Environment.NewLine);
        }
        public static void SaveInFile(string path, IrregularVerb verbs)
        {
            File.AppendAllText(path, verbs.ToString());
        }
        public string AddAudio(string word)
        {
            string Url = string.Format("https://myefe.ru/data/sw/words/us/{0}/{1}__us_1.mp3", word[0], word);
            string filename = MainForm.workDirrectory + "\\sound\\" + word + ".mp3";
            if (File.Exists(filename) == false)
            {
                try
                {
                    client.DownloadFile(Url, filename);
                }
                catch
                {
                    ErrorWord.add(new ErrorWord() { id=this.Index,word=word,path=this.path});
                    return "";
                }
            }
            return filename;
        }
    }
}
