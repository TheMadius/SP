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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            string mes = "Грамматика G[‹AB›] - автоматной. \nПравила (1) – (8) для G[‹AB›] реализованы на графе (см. рисунок). \nГде, \nНепрерывные стрелки на графе характеризуют синтаксически верный разбор; \n Пунктирные символизируют состояние ошибки (ERROR); \nERROR – является обработчиком ошибочных символов. \nOUT – завершение разбора строки.  \nСостояние 9 является заключительным, при его достижении разбор завершается.";
            this.richTextBox1.Text = mes.Replace("\n", "\n\t").Insert(0, "\t");
        }
    }
}
