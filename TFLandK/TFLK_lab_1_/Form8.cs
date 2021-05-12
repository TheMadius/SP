using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFLK_lab_1_
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            string mes = "Для диагностики и нейтрализации синтаксических ошибок, будем использовать метод Айронса.\nМетод Айронса\nОсновная идея – по контексту без возврата отбрасывать литеры, которые привели к тупиковой ситуации (когда продолжение анализа по грамматике невозможно), и продолжать разбор. \n	Для автоматной грамматики структурное дерево будет выглядеть как показано на рисунке.  Из дерева можно увидеть, что при возникновении ошибки у нас остается одна не достоянная часть, поэтому отбрасывание литеры будем производить до тех пор, пока следующий символ не позволит продолжить посторенние дерева.";
            this.richTextBox1.Text = mes.Replace("\n", "\n\t").Insert(0, "\t");
        }
    }
}
