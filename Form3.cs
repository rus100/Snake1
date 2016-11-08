using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Snake1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public StreamReader sr;
        string str1;
        string[] str2;
        private void button1_Click(object sender, EventArgs e)
        {
            Form3.ActiveForm.Hide();
        }


        DataTable table = new DataTable();
       
        private void button2_Click(object sender, EventArgs e)
        {
            table.Clear();
            sr = new StreamReader("records.txt");
            table.Columns.Add("имя");
            table.Columns.Add("уровень");
            table.Columns.Add("рекорд");
            while (sr.EndOfStream == false)
            {
                str1 = sr.ReadLine();
                str2 = str1.Split(' ');
                table.Rows.Add(str2);
            }
            BindingSource bs = new BindingSource();
            bs.DataSource = table;
            dataGridView1.DataSource = bs;
            sr.Dispose();
            sr.Close();
            
            dataGridView1.Show();
        }

    }
}
