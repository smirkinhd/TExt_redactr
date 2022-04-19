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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            label1.Text = "ЗАО Клуб Весёлых Питонистов.";
            label2.Text = "Пишем и на С#, и режем QR-Коды на питоне!";
            this.Text = "О программе";
        }
    }
}
