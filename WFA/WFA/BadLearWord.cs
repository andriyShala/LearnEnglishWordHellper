using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA
{
   public class BadLearWord
    {
        private static List<TrainWord> words = new List<TrainWord>();
        private String Path;
        public BadLearWord()
        {
            Path = ConfigurationManager.AppSettings["workDirectory"]+"\\badLearnWord.txt";

        }
        private void load()
        {
            StreamReader stream = new StreamReader(Path);
            while (!stream.EndOfStream)
            {
                words.Add(new TrainWord(stream.ReadLine(), Path));
            }
            stream.Close();
        }

    }
}
