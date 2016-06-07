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
    public partial class menu : Form
    {
        BARANG bar;
        searchBarang schBar;
        public Boolean flagBar;
        public Boolean flagSchBar;
        public static menu tis;

        public menu()
        {
            InitializeComponent();
            IsMdiContainer = true;
            this.flagBar = true;
            this.flagSchBar = true;
            tis = this;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            menuStrip1.MdiWindowListItem = wINDOWToolStripMenuItem;

        }

        private void nEWBARANGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flagBar)
            {
                bar = new BARANG();
                bar.MdiParent = this;
                bar.Show();
            }
        }

        private void sEARCHBARANGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flagSchBar)
            {
                schBar = new searchBarang();
                schBar.MdiParent = this;
                schBar.Show();
            }
        }
    }
}
