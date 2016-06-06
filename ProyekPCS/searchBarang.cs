using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyekPCS
{
    public partial class searchBarang : Form
    {
        public searchBarang()
        {
            InitializeComponent();
        }

        private void searchBarang_Load(object sender, EventArgs e)
        {
            //menu.tis.flagSchBar = false;
            dataGridView1.Top = button1.Bottom + 10;
        }

        private void searchBarang_FormClosing(object sender, FormClosingEventArgs e)
        {
            //menu.tis.flagSchBar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string temp = textBox1.Text + "/";
            temp = temp.Replace("/", "%");
            temp = temp.Replace("?", "_");
            MessageBox.Show(temp);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox3.Text != "")
            {
                string[] temp = new string[2];
                temp = textBox3.Text.Split('-');
                MessageBox.Show(temp[0]);
                MessageBox.Show(temp[1]);
            }
            if (textBox4.Text != "")
            {
                string[] temp = new string[2];
                temp = textBox3.Text.Split('-');
                MessageBox.Show(temp[0]);
                MessageBox.Show(temp[1]);
            }
            if (textBox5.Text != "")
            {
                string[] temp = new string[2];
                temp = textBox3.Text.Split('-');
                MessageBox.Show(temp[0]);
                MessageBox.Show(temp[1]);
            }
        }
    }
}
