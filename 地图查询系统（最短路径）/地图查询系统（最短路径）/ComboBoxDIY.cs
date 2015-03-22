//ComboBoxDIY.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication7
{
    public partial class ComboBoxDIY : UserControl
    {
        public bool buttondown = false;
        public ComboBoxDIY()
        {
            InitializeComponent();
            this.listBox1.Visible = false;
            this.vScrollBar1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //下拉按钮未曾按下
            if (this.buttondown == false)
            {
                //listbox所有数据的项数
                int count = this.listBox1.Items.Count;
                //获取listbox所能显示的项数
                int displaycount = this.listBox1.Height / this.listBox1.ItemHeight;
                //滚动条显示的最大值
                int scrollmax = 0;
                //垂直方向上显示内容数目大于所能显示的数目时
                //垂直滚动条直接可见
                if (count > displaycount)
                {
                    scrollmax = count - 1;
                    this.vScrollBar1.Visible = true;
                }
                this.vScrollBar1.LargeChange = displaycount;
                this.vScrollBar1.Maximum = scrollmax;
                this.vScrollBar1.Minimum = 0;
                this.vScrollBar1.Scroll += new ScrollEventHandler(vscroll);

                this.listBox1.Visible = true;
                //下拉按钮按下
                this.buttondown = true;
            }
            //下拉按钮已按下
            else
            {
                if (this.vScrollBar1.Visible) this.vScrollBar1.Visible = false;
                this.listBox1.Visible = false;
                //下拉按钮弹起
                this.buttondown = false;
            }
        }

        private void vscroll(object sender, ScrollEventArgs e)
        {
            //ScrollBar控制listBox滚动
            this.listBox1.TopIndex = e.NewValue;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //文本框显示选择结果
            this.textBox1.Text = this.listBox1.Items[this.listBox1.SelectedIndex].ToString();
            this.vScrollBar1.Visible = false;
            this.listBox1.Visible = false;
            //下拉按钮弹起
            this.buttondown = false;
        }
    }
}
