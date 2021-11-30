using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UP
{
    public partial class Form2 : Form
    {
        public Form1 mainForm;
        public Form2(Form1 form)
        {
            InitializeComponent();
            mainForm = form;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "7777";
            if (textBox1.Text == s)
            {
                mainForm.Show();
                mainForm.button1.Visible = true;
                mainForm.button2.Visible = true;
                mainForm.button3.Visible = true;
                Close();
            }
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

    }
}
