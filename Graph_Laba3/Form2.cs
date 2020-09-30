using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph_Laba3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
       
            InitializeComponent();
        }

        private void Text_Load(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {        
            if (button1.DialogResult == DialogResult.OK && textBox1.Text != "")
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Вы ничего не ввели !\nПопробуйте снова.");
                this.Close();
            }
        }
    }
}
