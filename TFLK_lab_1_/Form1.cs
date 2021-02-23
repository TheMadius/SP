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
        private List<Stack<string>> stackState = new List<Stack<string>>();
        private List<Stack<string>> backstackState = new List<Stack<string>>();
        private List<string> oldStr = new List<string>();
        private List<string> Path = new List<string>();

        public Form1()
        {
            InitializeComponent();

            this.backState.Enabled = false;
            this.nextState.Enabled = false;
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

            openFile.InitialDirectory = "c:\\";
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
            сохранитьToolStripMenuItem_Click(sender, e);
        }

        private int PageNew(string namePage = "Новый файл")
        {
            var NewText = new TextBox();
            NewText.Location = new System.Drawing.Point(0, 0);
            NewText.Multiline = true;
            NewText.Name = "textEnter";
            NewText.Size = new System.Drawing.Size(762, 165);
            NewText.TabIndex = 9;
            NewText.TextChanged += new System.EventHandler(this.TextEnter_TextChanged);
            NewText.ScrollBars = ScrollBars.Vertical;

            TabPage myTabPage = new TabPage(namePage);
            myTabPage.Controls.Add(NewText);
            tabControl1.TabPages.Add(myTabPage);

            return tabControl1.TabPages.Count - 1;
        }

        private void BackState_Click(object sender, EventArgs e)
        {
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
            TextBox box = (TextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"];
            string str = box.SelectedText;
            Clipboard.SetData(DataFormats.Text, (Object)str);
        }

        private void CutButton_Click(object sender, EventArgs e)
        {
            TextBox box = (TextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"];
            int start = box.SelectionStart;
            string str = box.SelectedText;
            Clipboard.SetData(DataFormats.Text, (Object)str);

            box.Text = box.Text.Remove(box.SelectionStart, box.SelectionLength);
            box.SelectionStart = start;
            box.SelectionLength = 0;
        }

        private void PushButton_Click(object sender, EventArgs e)
        {
            TextBox box = (TextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"];
            string str = Clipboard.GetText();
            int posCursor = box.SelectionStart;
            int start = box.SelectionStart + str.Length;

            box.Text = box.Text.Remove(box.SelectionStart, box.SelectionLength).Insert(posCursor, str);

            box.SelectionStart = start;
            box.SelectionLength = 0;
        }

        private void ГрассатикаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TextEnter_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            stackState[tabControl1.SelectedIndex].Push(oldStr[tabControl1.SelectedIndex]);
            oldStr[tabControl1.SelectedIndex] = textBox.Text;

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
            TextBox box = (TextBox)tabControl1.TabPages[tabControl1.SelectedIndex].Controls["textEnter"];
            box.SelectionStart = 0;
            box.SelectionLength = box.Text.Length;
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
            NewList_Click(sender, e);
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
    }
}
