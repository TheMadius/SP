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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            string str = "Определим грамматику оператора read READ языка FORTRAN G[‹AB›] в нотации Хомского с продукциями P:\n<AB> → read <T>; \n<T> → <O> ID{, ID } \n<O> → (*, <FMR> ) \n <FMR> → * | <ЦБЗ> \n <ID> → Б {Б | Ц} \n<ЦБЗ> → Ц {Ц} \n Б → a | b | c | ... | z | А | B | C | ... | Z \n Ц → 0 | 1 | 2 | ... | 9 \n, где \nБ - латинские буквы верхнего и нижнего регистров; \nЦ - цифры. \nСледуя введенному формальному определению грамматики, представим G[‹AB›] ее составляющими: \nZ = ‹AB›;\nVT = {a, b, c, ..., z, A, B, C, ..., Z, ( , ) , *, ; , ., 0, 1, 2, ..., 9};\nVN = {‹AB›, ‹T›, ‹O›, ‹ FMR ›, ‹ ЦБЗ ›,<ID>}.";
            this.richTextBox1.Text = str.Replace("\n","\n\t").Insert(0, "\t");
        }
    }
}
