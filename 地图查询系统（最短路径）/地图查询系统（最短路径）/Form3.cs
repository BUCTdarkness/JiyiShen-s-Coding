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
    public partial class Form3 : Form
    {
        const int maxn = 50;
        const int INF = 10000000;
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < maxn; i++)
            {
                comboBox1.Items.Add(Form1.city[i]);
            }
            for (int i = 0; i < maxn; i++)
            {
                comboBox2.Items.Add(Form1.city[i]);
            }

        }
        private bool iflegal_1()
        {
            if (comboBox1.Text != "")
            {
                if (comboBox1.Items.Contains(comboBox1.Text))
                {
                    return true;
                }
            }
            return false;
        }
        private bool iflegal_2()
        {
            if (comboBox2.Text != "")
            {
                if (comboBox2.Items.Contains(comboBox2.Text))
                {
                    return true;
                }
            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("请输入起始点！");
                return;
            }
            if (comboBox2.Text == "")
            {
                MessageBox.Show("请输入终点！");
                return;
            }
            if (!iflegal_1())
            {
                MessageBox.Show("查无该起始点！");
                return;
            }
            if (!iflegal_2())
            {
                MessageBox.Show("查无该终点！");
                return;
            }
            int c,a,b;
            for (c = 0; c < maxn && Form1.city[c] != comboBox1.Text; c++) ;
            a = c;
            for (c = 0; c < maxn && Form1.city[c] != comboBox2.Text; c++) ;
            b = c;
            int num=Convert.ToInt32(textBox1.Text);
            Form1.distance[a, b] = num;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
