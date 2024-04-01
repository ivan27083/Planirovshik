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

namespace Planirovshik
{
    public partial class Form1 : Form
    {
        public static string text;
        public static DateTime date; 
        public Form1()
        {
            InitializeComponent();
            import_data();
        }
        private void import_data()
        {
            if (File.Exists("1.txt"))
            {
                StreamReader reader = new StreamReader("1.txt");
                while (!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine().Split('|');
                    dataGridView.Rows.Add(line[0], line[1], line[2]);
                }
                reader.Close();
            }
            check();
        }
        private void check()
        {
            for (int i = 0; i < dataGridView.Rows.Count-1; i++)
            {
                if (Convert.ToDateTime(dataGridView.Rows[i].Cells[1].Value) < DateTime.Now) dataGridView.Rows[i].Cells[2].Value = "Просрочено";
            }
        }
        private void export_data()
        {
            if (!File.Exists("1.txt"))
                File.Create("1.txt").Close();
            StreamWriter writer = new StreamWriter("1.txt");
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView.Rows[i].Cells.Count; j++)
                {
                    if (dataGridView.Rows[i].Cells[j].Value != null)
                    {
                        string value = dataGridView.Rows[i].Cells[j].Value.ToString();
                        writer.Write(value);
                        if (j < dataGridView.Rows[i].Cells.Count - 1) writer.Write('|');
                    }
                }
                if (i < dataGridView.Rows.Count - 1) writer.Write('\n');
            }
            writer.Close();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            export_data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            dataGridView.Rows.Add(text, date, "В процессе");
            check();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
                dataGridView.Rows.Remove(row);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
                dataGridView.Rows[row.Index].Cells[2].Value = "Выполнено";
        }
    }
}
