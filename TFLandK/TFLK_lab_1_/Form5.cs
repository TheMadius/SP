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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string mas = "Согласно классификации Хомского, грамматика G[‹AB›] является автоматной.\nДокажем, что грамматика G[‹AB›] является автоматной. \n<AB> → read <T>; \n<T> → <O> ID{, ID } \n<O> → (*, <FMR> ) \n<FMR> → * | <ЦБЗ> \n<ID> → Б {Б | Ц} \n<ЦБЗ> → Ц {Ц} \nБ → a | b | c | ... | z | А | B | C | ... | Z \nЦ → 0 | 1 | 2 | ... | 9 \nДля доказательства преобразуем данную грамматику к новой G’[‹AB›]   которая будет являться автоматной (A → aB | a | ε), где правила будут леворекурсивными. Грамматика G’[‹AB›]:\n<AB> → r <OBR>\n<OBR> →(<FILE> \n<FILE> → * <C>\n<C> →, <FMT>  \n<FMT> → num <CBR> | * <CBR>, где num – это целое беззнаковое число\n< CBR > → ) <LIST>\n<LIST> → id <N>, где id – это идентификатор\n<N> → ,<LIST> | ; \nВ результате получаем новую грамматику G’[‹AB›], которая будет эквивалента G[‹AB›], так как L(G’[‹AB›]) = L(G[‹AB›]). Новая грамматика по классификации Хомского относится к автоматной, следовательно и  G[‹AB›] относится к автоматной.";
            this.richTextBox1.Text = mas.Replace("\n", "\n\t").Insert(0,"\t");
        }
    }
}
