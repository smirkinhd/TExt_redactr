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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                int lineNumber = Convert.ToInt32(numericUpDown1.Text);
                if (lineNumber > 0 && lineNumber <= main.notebox.Lines.Count())
                {
                    main.notebox.SelectionStart = main.notebox.GetFirstCharIndexFromLine(Convert.ToInt32(numericUpDown1.Text) - 1);
                    main.notebox.ScrollToCaret();
                    this.Close();
                }
            }
        }
    }
}
