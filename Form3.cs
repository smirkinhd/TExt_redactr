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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            button4.Enabled = false;
            button3.Enabled = false;
            button2.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int findCutLength = 0;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            findCutLength = 0;
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
            {
                button4.Enabled = false;
                button3.Enabled = false;
                button2.Enabled = false;
            }
            else
            {
                button4.Enabled = true;
                button3.Enabled = true;
                button2.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            findCutLength = 0;
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
            {
                button4.Enabled = false;
                button3.Enabled = false;
                button2.Enabled = false;
            }
            else
            {
                button4.Enabled = true;
                button3.Enabled = true;
                button2.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                TextWork.FindTextBox(ref main.notebox, textBox1.Text, ref findCutLength);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                TextWork.ReplaceTextBox(ref main.notebox, textBox1.Text, textBox2.Text, ref findCutLength);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                TextWork.ReplaceAllTextBox(ref main.notebox, textBox1.Text, textBox2.Text);
            }
        }
    }
}
