using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using RLIB;
namespace ProyekPCS
{
    public partial class LOGIN : Form
    {
        public static Connection c;
        public static LOGIN tis;
        public LOGIN()
        {
            InitializeComponent();
            tis = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                c = new Connection();
                //c.ConString = "data source = ORCL;";
                c.ConString = "data source = xe;";
                c.connCall(textBox1.Text, textBox2.Text);
                menu f = new menu();
                f.Show();
                this.Hide();
                Master m = new Master(c);
                m.test();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {
            mysqltestClass m = new mysqltestClass();
        }
    }
}
