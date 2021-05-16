using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TFLK_lab_1_
{
    public partial class Form1 : Form
    {
        private List<Stack<string>> stackState = new List<Stack<string>>();
        private List<Stack<string>> backstackState = new List<Stack<string>>();
        private List<string> oldStr = new List<string>();
        private List<string> Path = new List<string>();

        public Form1()
        {
            InitializeComponent();

            this.backState.Enabled = false;
            this.nextState.Enabled = false;
            this.textResult.Font = new Font(FontFamily.GenericMonospace, 12);
        }

        private void NewList_Click(object sender, EventArgs e)
        {
            PageNew();
            stackState.Add(new Stack<string>());
            backstackState.Add(new Stack<string>());
            oldStr.Add("");
            Path.Add(null);
            tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            var fileContent = string.Empty;

            openFile.InitialDirectory = "./";
            openFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                Path.Add(openFile.FileName);

                string[] name = openFile.FileName.Split(new char[] { '\\' });

                stackState.Add(new Stack<string>());
                backstackState.Add(new Stack<string>());

                tabControl1.SelectedIndex = PageNew(name[name.Length - 1]);

                var fileStream = openFile.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                    oldStr.Add(fileContent);
                    this.tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"].Text = fileContent;
                }
            }
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == -1)
            {
                return;
            }

            сохранитьToolStripMenuItem_Click(sender, e);
        }

        private int PageNew(string namePage = "Новый файл")
        {
            var NewText = new RichTextBox();
            NewText.Location = new System.Drawing.Point(0, 0);
            NewText.Multiline = true;
            NewText.Name = "textEnter";
            NewText.Size = new System.Drawing.Size(762, 165);
            NewText.TabIndex = 9;
            NewText.TextChanged += new System.EventHandler(this.TextEnter_TextChanged);
            NewText.Font = new Font("Arial", 14);

            TabPage myTabPage = new TabPage(namePage);
            myTabPage.Controls.Add(NewText);
            tabControl1.TabPages.Add(myTabPage);

            return tabControl1.TabPages.Count - 1;
        }

        private void BackState_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == -1)
            {
                return;
            }

            this.tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"].TextChanged -= TextEnter_TextChanged;
            backstackState[tabControl1.SelectedIndex].Push(this.tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"].Text);
            this.tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"].Text = stackState[tabControl1.SelectedIndex].Pop();
            this.tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"].TextChanged += TextEnter_TextChanged;

            oldStr[tabControl1.SelectedIndex] = this.tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"].Text;

            this.nextState.Enabled = true;

            if (stackState[tabControl1.SelectedIndex].Count == 0)
            {
                this.backState.Enabled = false;
            }
        }

        private void NextState_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == -1)
            {
                return;
            }

            this.tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"].TextChanged -= TextEnter_TextChanged;
            string str = backstackState[tabControl1.SelectedIndex].Pop();
            stackState[tabControl1.SelectedIndex].Push(this.tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"].Text);
            this.tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"].Text = str;
            this.tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"].TextChanged += TextEnter_TextChanged;

            oldStr[tabControl1.SelectedIndex] = this.tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"].Text;

            this.backState.Enabled = true;

            if (backstackState[tabControl1.SelectedIndex].Count == 0)
            {
                this.nextState.Enabled = false;
            }
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == -1)
            {
                return;
            }

            RichTextBox box = (RichTextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"];
            box.Copy();
        }

        private void CutButton_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == -1)
            {
                return;
            }

            RichTextBox box = (RichTextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"];
            box.Cut();
        }

        private void PushButton_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == -1)
            {
                return;
            }

            RichTextBox box = (RichTextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"];
            box.Paste();
        }

        private void ГрассатикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form2 = new Form6();
            form2.ShowDialog();
        }

        private void TextEnter_TextChanged(object sender, EventArgs e)
        {
            RichTextBox textBox = (RichTextBox)sender;
            stackState[tabControl1.SelectedIndex].Push(oldStr[tabControl1.SelectedIndex]);
            oldStr[tabControl1.SelectedIndex] = textBox.Text;
            int pos = textBox.SelectionStart;

            this.backState.Enabled = true;
        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void УдалитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"].Text = "";
        }

        private void ВЫToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox box = (RichTextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"];
            box.SelectAll();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.Filter = "txt files (*.txt)|*.txt";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                string sting = this.tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"].Text;
                Path[tabControl1.SelectedIndex] = saveFile.FileName;
                FileStream file = File.Create(saveFile.FileName);
                byte[] info = new UTF8Encoding(true).GetBytes(sting);

                string[] name = saveFile.FileName.Split(new char[] { '\\' });

                this.tabControl1.TabPages[tabControl1.SelectedIndex].Text = name[name.Length - 1];

                file.Write(info, 0, info.Length);
                file.Close();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Path[this.tabControl1.SelectedIndex] == null)
            {
                сохранитьКакToolStripMenuItem_Click(sender, e);
            }
            else
            {
                string sting = this.tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"].Text;
                FileStream file = File.Create(Path[tabControl1.SelectedIndex]);
                byte[] info = new UTF8Encoding(true).GetBytes(sting);
                file.Write(info, 0, info.Length);
                file.Close();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.backState.Enabled = true;
            this.nextState.Enabled = true;

            if (tabControl1.SelectedIndex == -1)
            {
                return;
            }

            if (backstackState[tabControl1.SelectedIndex].Count == 0)
            {
                this.nextState.Enabled = false;
            }

            if (stackState[tabControl1.SelectedIndex].Count == 0)
            {
                this.backState.Enabled = false;
            }

        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewList_Click(sender, e);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile_Click(sender, e);
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (stackState[tabControl1.SelectedIndex].Count == 0)
                return;

            BackState_Click(sender, e);
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CutButton_Click(sender, e);

        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy_Click(sender, e);
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PushButton_Click(sender, e);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void вызовСправкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("help.html");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = this.tabControl1.TabPages.Count; i > 0; --i)
            {
                this.tabControl1.SelectedIndex = i - 1;
                string message = "Сохранить файл - " + this.tabControl1.TabPages[i - 1].Text + "?";
                string caption = "TextNode";
                MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    сохранитьToolStripMenuItem_Click(sender, e);
                }
                this.tabControl1.TabPages.RemoveAt(i - 1);
            }
        }

        private void ПовторитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backstackState[tabControl1.SelectedIndex].Count == 0)
                return;

            NextState_Click(sender, e);
        }

        private void ПускToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == -1)
            {
                return;
            }

            this.textResult.Text = "";
            Parser recursiveDescent = new Parser();
            RichTextBox box = (RichTextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"];
            string[] lins = box.Lines;
            int i = 1;
            foreach (var item in lins)
            {
                string str = item.Replace(" ", "");
                recursiveDescent.setString(str);
                recursiveDescent.isRelate();
                this.textResult.Text += "Строка : " + i + "\n";
                string log = recursiveDescent.Log;
                if (log == "")
                {
                    this.textResult.Text += str + " - Верное выражение\n";
                }
                else
                {
                    int kol = 0;
                    foreach (var element in log.Split(new char[] { '\n' }))
                    {
                        this.textResult.Text += ((element != "") ? ((kol%4 == 0)?((kol+1)/4 + 1)+ ") ":" ") : "") + element + "\n";
                        kol++;
                    }
                }
                i++;
            }
        }

        private void регулярныеВыраженияToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void tabControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (tabControl1.SelectedIndex == -1)
            {
                return;
            }

            string message = "Сохранить файл - " + this.tabControl1.TabPages[tabControl1.SelectedIndex].Text + "?";
            string caption = "TextNode";
            MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                сохранитьToolStripMenuItem_Click(sender, e);
            }
            this.tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
        }

        private void конечныйАвтоматToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void сканерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void рекурсивныйСпускToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void тестовыйПримерToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == -1)
            {
                return;
            }
            RichTextBox box = (RichTextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"];
            box.Text = "45+a*25;";
        }

        private void грамматикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("G[LA]:\nLA → E;\nE → TA\nA → ε | +TA | -TA\nT → ОВ\nВ → ε | *ОВ | / ОВ\nО → num | id | (E)\n", "Грамматика");
        }

        private void классификацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Граматика является контекстно-свободной.", "Классификация");
        }

        private void грамматикаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           MessageBox.Show("<АВ>→T|<АВ>+ T|<АВ> –  T\nT → О | O * T | O / T\nО → (< АВ >) | < Идентификатор >| < ЦБЗ >\n< Идентификатор >→Б{ Б | Ц}\n< ЦБЗ >→ Ц{ Ц}" + "\nНетерминальные символы: \nT – терм,\nО – операнд,\n< Идентификатор > -идентификатор,\n< ЦБЗ > – целое число без знака,\nБ – буква латинского алфавита, a, b, …, z, A, B, …Z,\nЦ – цифра, 0, 1, …9.\n\nТерминальные символы: +, -, *, /, (, ).,[a-z],[A-Z],[0-9]", "Грамматика");
        }

        private void языкToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("L(G[AB]) = <B>[[<опер>(^k_j<B>]^j[[<опер><B>]^n)^k_i]^j]^m\n\n,где \n<B> = <ID>|<ЦБЗ>\n<ID> = Б{Б|Ц}\n<ЦБЗ> = Ц{Ц}\n<опер> = =|-|*|/\nm, j, i и n >= 0\nСумма(k_j) = Сумма(k_i)", "Язык");
        }

        private void классификацияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Граматика является автоматной.", "Классификация");
        }

        private void таблицаКодовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void диаграммаСостоянийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form2 = new Form3();
            form2.ShowDialog();
        }

        private void тестовыйПримерToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == -1)
            {
                return;
            }
            RichTextBox box = (RichTextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"];
            box.Text = "a + b = 1212\n121212\nfor(int i = 0)";
        }

        private void языкToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("L(G[LA]) = <B>[[<опер>(^k_j<B>]^j[[<опер><B>]^n)^k_i]^j]^m\n\n,где \n<B> = <ID>|<ЦБЗ>\n<ID> = Б{Б|Ц}\n<ЦБЗ> = Ц{Ц}\n<опер> = =|-|*|/\nm, j, i и n >= 0\nСумма(k_j) = Сумма(k_i)", "Язык");
        }

        private void пускToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void пускToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == -1)
            {
                return;
            }
            this.textResult.Text = "";
            RecursiveDescent recursiveDescent = new RecursiveDescent();
            RichTextBox box = (RichTextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"];
            string[] lins = box.Lines;
            int i = 1;
            foreach (var item in lins)
            {
                string str = item.Replace(" ", "");
                recursiveDescent.setString(str);
                recursiveDescent.isRelate();
                this.textResult.Text += "Строка : " + i + "\n";
                foreach (var element in recursiveDescent.Log.Split(new char[] { '&' }))
                {
                    string lint = element.Replace(" ", " --> ").Remove(0, 5); ;
                    this.textResult.Text += lint + "\n";
                }
                i++;
            }
        }

        private void пускToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == -1)
            {
                return;
            }
            this.textResult.Text = "";
            RichTextBox box = (RichTextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"];
            string[] lins = box.Lines;
            int i = 1;
            foreach (var item in lins)
            {
                List<InfoLExems> lint = Scaner.findLexems(item);
                this.textResult.Text += "Строка : " + i + "\n";
                foreach (InfoLExems lexems in lint)
                {
                    this.textResult.Text += lexems.name + " тип: " + lexems.lexemes + " позиция : " + lexems.posStart + "\n";
                }
                this.textResult.Text += "\n";
                i++;
            }
        }

        private void регулярныеВыраженияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == -1)
            {
                return;
            }

            RichTextBox box = (RichTextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"];
            box.Enabled = false;
            string pattern = @"(?<=\s|^)([\w-]+\.)*[\w-]+@([\w-]+\.)+(com|ru|org|de|net|uk|cn|info|nl|eu)(?=\s|$|\,|\;|\.|\?|!|:|\n)";
            int count = 0;

            this.textResult.Text = "Найденные email:\n";

            string[] text = box.Lines;

            for (int i = 0; i < text.Length; ++i)
            {
                Regex regex = new Regex(pattern);
                MatchCollection matchColl = regex.Matches(text[i]);

                foreach (Match match in matchColl)
                {
                    ++count;
                    this.textResult.Text += count + ". " + match.Value;
                    this.textResult.Text += " Строка: " + (i + 1);
                    this.textResult.Text += " Позиция в строке: " + (match.Index + 1);
                    this.textResult.Text += "\n";
                }

            }
            if (count == 0)
            {
                this.textResult.Text += "Не найдено";
            }
            box.Select(0, 0);
            box.Enabled = true;
        }

        private void конечныйАвтоматToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == -1)
            {
                return;
            }

            RichTextBox box = (RichTextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"];

            this.textResult.Text = "Найденные email:\n";

            string[] text = box.Lines;

            foreach (var item in text)
            {
                this.textResult.Text += Automat.checkString(item);
            }
        }

        private void тестовыйПримерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == -1)
            {
                return;
            }
            RichTextBox box = (RichTextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"];
            box.Text = "read(*,*) Max;\nread(*,688*) &&Max;\nread((((*,*) sdfs,12asdddd,;";
        }

        private void постановкаЗадачиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form2 = new Form4();
            form2.ShowDialog();
        }

        private void классификацияГрамматикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form2 = new Form5();
            form2.ShowDialog();
        }

        private void методАнализаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 form2 = new Form7();
            form2.ShowDialog();
        }

        private void диагностикаИНейтрализацияОшибокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 form2 = new Form8();
            form2.ShowDialog();
        }

        private void списокЛитературыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string lit = "\t1. Шорников Ю.В. Теория и практика языковых процессоров: учеб. пособие / Ю.В. Шорников. – Новосибирск: Изд-во НГТУ, 2004.\n\t2.Теория формальных языков и компиляторов [Электронный ресурс] / Электрон. дан. URL: https://dispace.edu.nstu.ru/didesk/course/show/2523, свободный. Яз.рус. (дата обращения 04.05.2021).";
            MessageBox.Show(lit);
        }

        private void исходныйКодПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("code.html");
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string lit = "Данная программа разработана в целях ознакомления с дисциплиной “ Теория формальных языков и компиляторов”. В рамках первой лабораторной было написан интерфейс и основной функционал текстового редактора.  В качестве языка был выбран – C#.\n Вторым этапом разработки таксового редактора было написание языкового процессора для оператора READ языка FORTRAN. \nРуководство пользователя можно получить из пункта меню “Справка”→”Вызвать справку”.\nПо вопросам можно писать на почту: dimon.pustovskih@mail.ru\nАвтор: Пустовских Дмитрий Александрович, НГТУ, 3 курс, АВТФ\nГруппа: АВТ-813";
            MessageBox.Show(lit.Replace("\n", "\n\t").Insert(0, "\t"));
        }
    }
}
