using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFLK_lab_1_
{
    public partial class Form1 : Form
    {
        private Stack<string> stackState = new Stack<string>();
        private Stack<string> backstackState = new Stack<string>();
        private string oldStr;
        public Form1()
        {
            InitializeComponent();

            this.backState.Enabled = false;
            this.nextState.Enabled = false;
            this.textEnter.ScrollBars = ScrollBars.Vertical;
            oldStr = this.textEnter.Text;

        }

        private void NewList_Click(object sender, EventArgs e)
        {
            TabPage myTabPage = new TabPage("Новый файл");
            tabControl1.TabPages.Add(myTabPage);
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            var fileContent = string.Empty;
            var filePath = string.Empty;

            openFile.InitialDirectory = "c:\\";
            openFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                filePath = openFile.FileName;

                var fileStream = openFile.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
                this.textEnter.Text = fileContent;
            }
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.Filter = "txt files (*.txt)|*.txt";

            saveFile.ShowDialog();
        }

        private void BackState_Click(object sender, EventArgs e)
        {
            textEnter.TextChanged -= TextEnter_TextChanged;
            backstackState.Push(this.textEnter.Text);
            this.textEnter.Text = stackState.Pop();
            textEnter.TextChanged += TextEnter_TextChanged;
            oldStr = this.textEnter.Text;

            this.nextState.Enabled = true;

            if (stackState.Count == 0)
            {
                this.backState.Enabled = false;
            }
        }

        private void NextState_Click(object sender, EventArgs e)
        {
            textEnter.TextChanged -= TextEnter_TextChanged;
            string str = backstackState.Pop();
            stackState.Push(this.textEnter.Text);
            this.textEnter.Text = str;
            textEnter.TextChanged += TextEnter_TextChanged;

            oldStr = this.textEnter.Text;

            if (backstackState.Count == 0)
            {
                this.nextState.Enabled = false;
            }
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            string str =  this.textEnter.SelectedText;
            Clipboard.SetData(DataFormats.Text, (Object)str);
        }

        private void CutButton_Click(object sender, EventArgs e)
        {
            string str = this.textEnter.SelectedText;
            Clipboard.SetData(DataFormats.Text, (Object)str);

            this.textEnter.Text = this.textEnter.Text.Remove(this.textEnter.SelectionStart, this.textEnter.SelectionLength);
        }

        private void PushButton_Click(object sender, EventArgs e)
        {
            string str = Clipboard.GetText();
            int posCursor = this.textEnter.SelectionStart;

            this.textEnter.Text = this.textEnter.Text.Remove(this.textEnter.SelectionStart, this.textEnter.SelectionLength).Insert(posCursor, str);

        }

        private void ГрассатикаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TextEnter_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            stackState.Push(oldStr);
            oldStr = this.textEnter.Text;
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
            this.textEnter.Text = "";
        }

        private void ВЫToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textEnter.SelectionStart = 0;
            this.textEnter.SelectionLength = this.textEnter.Text.Length;
        }
    }
}
