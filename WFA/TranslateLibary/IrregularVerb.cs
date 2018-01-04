using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateLibary
{
   public class IrregularVerb
    {
        public int Index { get; set; }
        public string Translete { get;set;}
        public string Word1 { get; set; }
        public string Word2 { get; set; }
        public string Word3 { get; set; }
        public int PerCent { get; set; }


        public static IrregularVerb Parse(string src)
        {
            IrregularVerb temp = new IrregularVerb();
            string[] m = src.Split('%');
            temp.Index =Convert.ToInt32(m[0]);
            temp.Word1 = m[1];
            temp.Word2 = m[2];
            temp.Word3 = m[3];
            temp.Translete = m[4];
            temp.PerCent = Convert.ToInt32(m[5]);
            return temp;
        }
        public override string ToString()
        {
            return String.Format("{0}%{1}%{2}%{3}%{4}%{5}{6}",this.Index.ToString(),this.Word1,this.Word2,this.Word3,this.Translete,this.PerCent.ToString(), Environment.NewLine);
        }
        public static void SaveInFile(string path, IrregularVerb verbs)
        {
            File.AppendAllText(path, verbs.ToString());
        }
    }
}
