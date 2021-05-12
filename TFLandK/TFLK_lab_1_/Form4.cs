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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
           string mas = "Оператор read – это оператор, который используются в программах для ввода информации в память компьютера и \"считывания\" значений в переменную.\nФормат записи: \"read(* , < определитель формата >) < список переменных >; \".\nПримеры:\nСчитывание данных без определенного формата – из потока данных считываются значения без определенного формата, то есть как пользователь ввел так данные и считаются: \"read(*, *) min; \". \nСчитывание данных с заданным форматом – из потока данных считываются значения с заданным форматом, формат задается указателем на объект, который и содержит в себе формат ввода: \" read(*, 100) max; \" \nСчитывание множества переменных – список переменных указывается после задания формата, перечисление объектов сопровождается разделительным знаком “,”: \" read(*, *) min,max,mean; \" \nДля разработанной автоматной грамматикой G[‹AB›] синтаксический анализатор (парсер) оператора read будет считать верными следующие записи: \n \"read(*, *) num;” \n\"read(*,111) RC;\" \n\"read(*,*) Num, sum, man2;\"";
            this.richTextBox1.Text = mas.Replace("\n", "\n\t").Insert(0, "\t");
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
