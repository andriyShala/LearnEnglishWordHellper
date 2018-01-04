using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA
{
   public class WorkTransetor
    {
        private List<TrainingWords> translators = new List<TrainingWords>();
        private List<IrTransetor> irtranlator = new List<IrTransetor>();
        private MainForm.StartLoad del1;
        private MainForm.StopLoad del2;
        private TrainingWords.ChangeWord chWord;
        private int I = 0;
        private int irI = 0;
        public WorkTransetor(string[] patchs,string[] ir,MainForm.StartLoad del1,MainForm.StopLoad del2,TrainingWords.ChangeWord chWord)
        {
            this.del1 = del1;
            this.del2 = del2;
            this.chWord = chWord;
            foreach (var item in patchs)
            {
                translators.Add(new TrainingWords(item,del1,del2,chWord));
            }
            foreach (var item in ir)
            {
                irtranlator.Add(new IrTransetor(item,del1,del2));
            }

        }
        
        public TrainingWords getTTranslator()
        {
            return translators[I];
        }
        public TrainingWords getTTranslator(string path)
        {
            for (int i = 0; i < translators.Count; i++)
            {
                if (translators[i].Path.Contains(path))
                {
                    return translators[i];
                }
            }
            return null;
        }
        public void RemoveT(String path)
        {
            for(int i=0;i<translators.Count;i++)
            {
                if(translators[i].Path==path)
                {
                    translators.RemoveAt(i);
                }
            }
        }
        public void RemoveIr(String path)
        {
            for (int i = 0; i < irtranlator.Count; i++)
            {
                if (irtranlator[i].Path == path)
                {
                    irtranlator.RemoveAt(i);
                }
            }
        }



        public void setTTranslator(string path)
        {
            for (int i = 0; i < translators.Count; i++)
            {
                if(translators[i].Path==path)
                {
                    I = i;
                    return;
                }
            }
        }
        public void setTTranslatorByName(string name)
        {
            for (int i = 0; i < translators.Count; i++)
            {
                if (translators[i].Path.Contains(name))
                {
                    I = i;
                    return;
                }
            }
        }


        public IrTransetor getIRTranslator()
        {
            return irtranlator[irI];
        }
        public IrTransetor getIRTranslator(string path)
        {
            for (int i = 0; i < irtranlator.Count; i++)
            {
                if(irtranlator[i].Path==path)
                {
                    return irtranlator[i];
                }
            }
            return null;
        }

        public void setIRTranslator(string path)
        {
            for (int i = 0; i < irtranlator.Count; i++)
            {
                if (irtranlator[i].Path == path)
                {
                    irI = i;
                    return;
                }
            }
        }
        public void setIRTranslatorByName(string name)
        {
            for (int i = 0; i < irtranlator.Count; i++)
            {
                if (irtranlator[i].Path.Contains(name))
                {
                    irI = i;
                    return;
                }
            }
        }

        public void closing()
        {
            foreach (var item in translators)
            {
                item.saveToFile();
            }
            foreach (var item in irtranlator)
            {
                item.saveToFile();
            }
        }
        public void addT(string path)
        {
            translators.Add(new TrainingWords(path,del1,del2,chWord));
        }
        public void addTir(string path)
        {
            irtranlator.Add(new IrTransetor(path,del1,del2));
        }
        public TrainWord IsExistense(String word)
        {
            for (int i = 0; i < translators.Count; i++)
            {
                for (int j = 0; j < translators[i].CountLocalWords; j++)
                {
                    if(translators[i].Get(j).Word== word)
                    {
                        return translators[i].Get(j);
                    }
                }
            }
            return null;
        }
    }
}
