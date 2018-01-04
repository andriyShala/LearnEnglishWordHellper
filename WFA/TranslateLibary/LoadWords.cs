using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TranslateLibary
{
  public  class Words
    {
        private string FilePatch = String.Empty;
        private List<TransleteWord> LocalWords = new List<TransleteWord>();
        public Words(String patch)
        {
            this.FilePatch = patch;
            LoadFromFile();
        }
        private void LoadFromFile()
        {
            byte[] buffer=new byte[50];
            FileStream stream = new FileStream(this.FilePatch, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            stream.Read(buffer, 0, 25);
            string something = Encoding.ASCII.GetString(buffer);
            stream.Close();


        }
        public void SafeToFile()
        {
            if (LocalWords.Count > 0)
            {

            }
        }
        private int GetOffset()
        {
            if(LocalWords.Count==0)
            {
                return 25;
            }
            else
            {
                int offset = LocalWords[LocalWords.Count - 1].Offset;
                offset += LocalWords[LocalWords.Count - 1].Lenght;
                return offset;
            }
        }
        public void Add(TransleteWord word)
        {
            word.Offset = GetOffset();
            this.LocalWords.Add(word);
        }
        public void Add(String word)
        {
            this.LocalWords.Add(TransleteWord.Parse(word));
        }


    }
}
