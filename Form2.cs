using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snake1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }
        public string imya1;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            imya1 = textBox1.Text;
            if (textBox1.Text.Length > 0) {
                button1.Enabled = true;
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Form2.ActiveForm.Hide();
            
        }
    }
}
