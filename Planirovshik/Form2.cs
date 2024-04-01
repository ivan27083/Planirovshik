using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planirovshik
{
    public partial class Form2 : Form
    {
        public string text;
        public DateTime date;
        public Form2()
        {
            InitializeComponent();
            text = "";
            date = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                text = textBox1.Text;
                date = dateTimePicker1.Value;
            }
            Form1.text = text;
            Form1.date = date;
            this.Close();
        }
    }
}
