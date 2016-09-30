using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.picBox1.PictureBox_Custom.Image = Image.FromFile(@"G:\123.bmp");
           this.picBox1. InitalData();
        }



        private void button1_Click(object sender, EventArgs e)
        {
           

            Bitmap bmp = this.picBox1.GetBMP();
            if (bmp != null)
            {
                bmp.Save(@"G:\456.bmp");
                MessageBox.Show("存储成功");
            }
            else
                MessageBox.Show("存储失败");
        }
    }
}
