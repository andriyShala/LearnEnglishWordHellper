using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA
{
    public static class Log
    {
        public static String logFile = MainForm.workDirrectory + "\\log.txt";
        public static void Add(string path,string mess)
        {
            File.AppendAllText(logFile, string.Format("{0}-Path-{1}-Message={2}{3}", DateTime.Now,path, mess, Environment.NewLine));
        }
    }
}
