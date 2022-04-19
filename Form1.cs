using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bl2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            переносПоСловамToolStripMenuItem.Checked = true;
            richTextBox1.WordWrap = true;
            строкаСостоянияToolStripMenuItem.Checked = true;
            отменитьToolStripMenuItem.Enabled = false;
            вставитьToolStripMenuItem.Enabled = false;
            копироватьToolStripMenuItem.Enabled = false;
            удалитьToolStripMenuItem.Enabled = false;
            найтиToolStripMenuItem.Enabled = false;
            найтиДалееToolStripMenuItem.Enabled = false;
            найтиРанееToolStripMenuItem.Enabled = false;
            вырезатьToolStripMenuItem.Enabled = false;

            richTextBox1.Dock = DockStyle.Fill;
            openFileDialog1.FileName = "Text2.txt";
            openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            richTextBox1.ZoomFactor = 1;

            statusStrip1.Visible = true;
            statusStrip1.Items[1].Text = DateTime.Now.ToLongDateString() + "     |     ";
            statusStrip1.Items[0].Text = " символов     |     ";
            statusStrip1.Items[2].Text = "Масштаб 100%";

            richTextBox1.Font = new Font("Thimes New Roman", 14.0F);

        }

        private void переносПоСловамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            переносПоСловамToolStripMenuItem.Checked = !переносПоСловамToolStripMenuItem.Checked;
            richTextBox1.WordWrap = !richTextBox1.WordWrap;
        }

        private void строкаСостоянияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Visible = !statusStrip1.Visible;
            строкаСостоянияToolStripMenuItem.Checked = !строкаСостоянияToolStripMenuItem.Checked;
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.Font = fontDialog1.Font;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Запись()
        {
            try
            {
                var Писатель = new System.IO.StreamWriter(saveFileDialog1.FileName, false,
                System.Text.Encoding.GetEncoding(1251));
                Писатель.Write(richTextBox1.Text);
                Писатель.Close();
                richTextBox1.Modified = false;
            }
            catch (System.Exception Ситуация)
            { 
                MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
        }

        public void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (richTextBox1.Modified == false) return;
            DialogResult MBox = MessageBox.Show("Текст был изменен.\nСохранить изменения?",
            "Простой редактор", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            if (MBox == DialogResult.No) return;
            if (MBox == DialogResult.Cancel) e.Cancel = true;
            if (MBox == DialogResult.Yes)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Запись();
                    return;
                }
                else e.Cancel = true;
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            try
            { 
                var Читатель = new System.IO.StreamReader(openFileDialog1.FileName,
                System.Text.Encoding.GetEncoding(1251));
                richTextBox1.Text = Читатель.ReadToEnd();
                Читатель.Close();
            }
            catch (System.IO.FileNotFoundException Ситуация)
            {
                MessageBox.Show(Ситуация + "\nНет такого файла", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (System.Exception Ситуация)
            {
                MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = openFileDialog1.FileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) Запись();
        }

        private void увеличитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.ZoomFactor += 1;
            }
            catch (System.Exception Ситуация)
            {
                MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
            int mas = Convert.ToInt32(richTextBox1.ZoomFactor);
            statusStrip1.Items[2].Text = "Масштаб " + (mas * 100) + "%";
        }

        private void новоеОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f2 = new Form1();
            f2.Show();
        }

        private void уменьшитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.ZoomFactor -= 1;
            }
            catch (System.Exception Ситуация)
            {
                MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
            int mas = Convert.ToInt32(richTextBox1.ZoomFactor);
            statusStrip1.Items[2].Text = "Масштаб " + (mas * 100) + "%";
        }

        private void восстановитьМасштабПоУмолчаниюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ZoomFactor = 1;
            int mas = Convert.ToInt32(richTextBox1.ZoomFactor);
            statusStrip1.Items[2].Text = "Масштаб " + (mas * 100) + "%";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int mas = Convert.ToInt32(richTextBox1.ZoomFactor);
            int pos = richTextBox1.SelectionStart; // get starting point
            int line = richTextBox1.GetLineFromCharIndex(pos); // get line number
            int column = richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexFromLine(line); // get column number
            statusStrip1.Items[0].Text = "Стр. " + (line + 1) + ", Столб." + (column + 1) + "     |     ";
            statusStrip1.Items[2].Text = "Масштаб " + (mas * 100) +"%";

            if (richTextBox1.TextLength != 0)
            {
                отменитьToolStripMenuItem.Enabled = true;
                вставитьToolStripMenuItem.Enabled = true;
                копироватьToolStripMenuItem.Enabled = true;
                удалитьToolStripMenuItem.Enabled = true;
                найтиToolStripMenuItem.Enabled = true;
                найтиДалееToolStripMenuItem.Enabled = true;
                найтиРанееToolStripMenuItem.Enabled = true;
                вырезатьToolStripMenuItem.Enabled = true;
            }
            else
            {
                отменитьToolStripMenuItem.Enabled = false;
                вставитьToolStripMenuItem.Enabled = false;
                копироватьToolStripMenuItem.Enabled = false;
                удалитьToolStripMenuItem.Enabled = false;
                найтиToolStripMenuItem.Enabled = false;
                найтиДалееToolStripMenuItem.Enabled = false;
                найтиРанееToolStripMenuItem.Enabled = false;
                вырезатьToolStripMenuItem.Enabled = false;
            }
        }

        public void CpyText()
        {
            Clipboard.SetText(richTextBox1.SelectedText);
        }

        public void CutText()
        {
            Clipboard.SetText(richTextBox1.Text.Substring(richTextBox1.SelectionStart, richTextBox1.SelectionLength));
            richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.SelectionStart, richTextBox1.SelectionLength);
        }

        public void pasteText()
        {
            richTextBox1.Text = richTextBox1.Text.Substring(0, richTextBox1.SelectionStart) + Clipboard.GetText() + richTextBox1.Text.Substring(richTextBox1.SelectionStart, richTextBox1.Text.Length - richTextBox1.SelectionStart);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }
        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CpyText();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CutText();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pasteText();
        }

        public void Unsave()
        {
            DialogResult result = MessageBox.Show("Сохранить изменения в файле?", "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) Запись();
            }
            if (result == DialogResult.No)
            {
                richTextBox1.Text = "";
            }
        }


        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength != 0) Unsave();
            else
            {
                richTextBox1.Text = "";
            }
        }

        private void найтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 fm = new Form3();
            fm.ShowDialog();
        }
    }
}
