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

namespace Graph_Laba3
{
    public partial class Form1 : Form
    {
        public Form1()
        {            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            Form2 form = new Form2();
            form.Owner = this;
            form.ShowDialog();
            
            if (form.button1.DialogResult == DialogResult.OK)
            {
                if (form.textBox1.Text != " ")
                {
                    //Сохраняем куда угодно, по выбору пользователя
                    //
                    SaveFileDialog file = new SaveFileDialog();
                    file.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

                    if (file.ShowDialog() == DialogResult.OK)
                    {
                        Global.path = file.FileName;
                        using (StreamWriter writer = new StreamWriter(Global.path))
                        {
                            writer.WriteLine(form.textBox1.Text);
                            writer.Close();
                        }
                    }
                    //
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // На случай, если нужно перерисовать графику
            //
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            //

            //Путьсохраняется при записи файла
            //если файл не записывали то пользователя сам находит нужный ему
            if (Global.path == null)
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    Global.path = file.FileName;
                }
            }
            else
            {
                string text = "";
                int lineNumX = pictureBox1.Width / 4;
                int lineNumY = 200;
                using (StreamReader reader = new StreamReader(Global.path))
                {
                    text = reader.ReadLine();
                    reader.Close();
                }
                string[] TextArray = text.Trim(' ').Split();
                //Шрифты для каждого набора строк
                //
                Font first = new Font("Cambria", 36, FontStyle.Regular);
                Font second = new Font("Magneto", 24, FontStyle.Bold);
                Font third = new Font("Perpetua", 48, FontStyle.Italic);// в 1 дюйме 96 пикселей 
                //
                
                //Формирование
                //
                StringFormat firstSF = new StringFormat();
                StringFormat secondSF = new StringFormat();
                StringFormat thirdSF = new StringFormat();

                firstSF.FormatFlags = StringFormatFlags.DirectionVertical;
                firstSF.Alignment = StringAlignment.Near;
                firstSF.LineAlignment = StringAlignment.Near;
                
                secondSF.Alignment = StringAlignment.Far;
                secondSF.LineAlignment = StringAlignment.Near;

                thirdSF.Alignment = StringAlignment.Center;
                thirdSF.LineAlignment = StringAlignment.Near;
                //

                //Вывод
                //
                for (int i = 0; i < TextArray.Length; i++)
                {
                    if (i < 6)
                    {
                        g.DrawString(TextArray[i].ToString(), first, Brushes.Black, lineNumX, 10, firstSF);
                        lineNumX -= 50;
                    }
                    if (i >= 6 && i < 11)
                    {
                        g.DrawString(TextArray[i].ToString(), second, Brushes.Black, pictureBox1.Width-10, lineNumY, secondSF);
                        lineNumY += 50;
                    }
                    if (i == 11)
                    {
                        g.DrawString(TextArray[11].ToString(), third, Brushes.Black, pictureBox1.Width / 2, lineNumY - 20, thirdSF);
                    }
                }  
                //
                g.Dispose();
            }
        }
        class Global//чтобы удобно можно было получить путь нужного файла 
        {
            public static string path;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            g.Dispose();
        }
    }
}
