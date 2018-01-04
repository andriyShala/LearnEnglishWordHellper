using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace WFA
{
  public  class Words
    {
        private string FilePatch = String.Empty;
        private List<TrainWord> LocalWords = new List<TrainWord>();
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
                var serializer = new DataContractJsonSerializer(LocalWords.GetType());
                using (var stream = new FileStream(this.FilePatch,FileMode.OpenOrCreate))
                {
                    serializer.WriteObject(stream, LocalWords);
                    //using (var sr = new StreamReader(stream))
                    //{
                    //    return sr.ReadToEnd();
                    //}
                }

            }
        }
    }
}
