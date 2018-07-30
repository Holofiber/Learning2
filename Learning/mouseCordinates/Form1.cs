using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mouseCordinates
{
    public partial class Form1 : Form
    {
        private int x = 0;
        private int y = 0;

        public Form1()
        {

            InitializeComponent();
           
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            var position = e.Location;
            var x = e.X;
            var y = e.Y;
            Text = position.ToString();
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            var dataObject = e.Data;
            
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
             string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
             string file = files[0];
            textBox1.Text = System.IO.File.ReadAllText(file);
        }

        private void textBox1_DragOver(object sender, DragEventArgs e)
        {
            
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
    }
}
