using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA
{
    public partial class Form3 : Form
    {
        List<TrainWord> words = new List<TrainWord>();
        public Form3(List<TrainWord> words) 
        {
            InitializeComponent();
            this.words = words;
            foreach (var item in words)
            {
                ListViewItem ite = new ListViewItem(item.Word);
                ite.SubItems.Add(countExistance(item.Word).ToString());
                listView1.Items.Add(ite);
            }

        }
        private int countExistance(String word)
        {
            int count = 0;
            foreach (var item in words)
            {
                if(item.Word==word)
                {
                    count++;
                }
            }
            return count;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
