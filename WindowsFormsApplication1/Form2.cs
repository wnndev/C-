using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        private string _str;
        public String PicPath
        {
            set
            {
                _str = value;
            }
            get
            {
                return _str;
            }
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (_str != "")
            {
                pictureBox1.Image = Image.FromFile(_str);
                this.Size = new Size(pictureBox1.Width + 50, pictureBox1.Height + 50);
            }
        }
    }
}
