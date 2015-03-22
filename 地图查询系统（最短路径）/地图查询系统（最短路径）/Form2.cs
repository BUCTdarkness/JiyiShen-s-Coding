using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 地图查询系统_最短路径_
{
    public partial class Form2 : Form
    {
        int[,] pos =
        {
{35,387},
{62,410},
{92,410},
{124,410},
{157,410},
{190,410},
{220,410},
{252,410},
{286,410},
{321,410},
{354,410},
{387,410},
{446,410},
{485,410},
{516,410},
{548,410},
{588,410},
{645,410},
{682,410},
{722,410},
{759,410},
{789,410},
{817,410},
{285,464},
{285,366},
{285,332},
{285,295},
{188,77},
{246,77},
{277,88},
{277,114},
{277,142},
{277,179},
{277,256},
{332,296},
{388,296},
{445,296},
{445,322},
{445,343},
{445,366},
{445,450},
{445,487},
{445,529},
{424,267},
{386,328},
{386,357},
{401,443},
{522,449},
{585,449},
{633,439}
        };
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int l = Form1.tot-1;
            Image img1 = Image.FromFile("..\\..\\Resources\\StartNode.ico");
            Image img2 = Image.FromFile("..\\..\\Resources\\EndNode.ico");
            Graphics g = this.pictureBox1.CreateGraphics();
            int c1 = Form1.num[l];
            int c2 = Form1.num[l - 1];
            g.DrawImage(img1,pos[c1,0]-12,pos[c1,1]-34);
            while (l -1>= 0)
            {
                c1 = Form1.num[l];
                c2 = Form1.num[l-1];
                Pen p = new Pen(Color.Crimson, 8);
                Point p1 = new Point(pos[c1,0], pos[c1,1]);
                Point p2 = new Point(pos[c2,0], pos[c2,1]);
                g.DrawLine(p, p1, p2);
                l--;
            }
            g.DrawImage(img2, pos[c2, 0]-16, pos[c2, 1]-32);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = null;
        }


    }
}
