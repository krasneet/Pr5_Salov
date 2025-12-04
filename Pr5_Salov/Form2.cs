using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pr5_Salov.EF;

namespace Pr5_Salov
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrWhiteSpace(textBox2.Text))
            {
                ModelEF model = new ModelEF();
                Student student = new Student();
                student.Name = textBox1.Text;
                student.Group_ = textBox2.Text;
                byte[] bImg = (byte[])new ImageConverter().ConvertTo(pictureBox1.Image, typeof(byte[]));
                student.Photo = bImg;
                model.Student.Add(student);
                try
                {
                    model.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MessageBox.Show("Сохранено");
                textBox1.Text = "";
                textBox2.Text = "";
                pictureBox1 = null;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Выберите фото сотрудника";
            ofd.Filter = "Файлы JPG, PNG|*.jpg;*.png|Все файлы(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(ofd.FileName);
        }
    }
}
