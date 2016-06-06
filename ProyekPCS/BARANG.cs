using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RLIB;
namespace ProyekPCS
{
    public partial class BARANG : Form
    {

        Master m;
        public BARANG()
        {
            InitializeComponent();
            m= new Master(LOGIN.c);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            menu.tis.flagBar = false;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            menu.tis.flagBar = true;
        }

        private void isiParam(Master m)
        {
            m.addParamStr(textBox1.Text);
            m.addParamStr(textBox2.Text);
            m.addParamStr(textBox3.Text);
            m.addParamStr(comboBox1.Text);
            m.addParamStr(comboBox2.Text);
            m.addParamStr(textBox4.Text);
            m.addParamNumber(textBox5.Text);
            m.addParamStr(comboBox3.Text);
            m.addParamNumber(textBox6.Text);
            m.addParamNumber(textBox7.Text);
        }

        private void resetStat()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            isiParam(m);
            try
            {
                m.insert("BARANG");
                MessageBox.Show("Insert Sukses");
                resetStat();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
               string t= m.callProcedure("AUTOGEN_KODE_BARANG",textBox2.Text);
               MessageBox.Show(t);
            }
        }

        private void isiParamKet(Master m)
        {
            m.addCondition(new condition("KODE_BARANG",textBox1.Text,Logic.none));
            m.addSet(new condition("NAMA", textBox2.Text,Logic.none));
            m.addSet(new condition("ALIAS", textBox3.Text, Logic.none));
            m.addSet(new condition("KATEGORI", comboBox1.Text, Logic.none));
            m.addSet(new condition("JENIS_MOBIL", comboBox2.Text, Logic.none));
            m.addSet(new condition("LOKASI", textBox4.Text, Logic.none));
            m.addSet(new condition("QTY", textBox5.Text, Logic.none));
            m.addSet(new condition("SATUAN", comboBox3.Text, Logic.none));
            m.addSet(new condition("HARGA_JUAL", textBox6.Text, Logic.none));
            m.addSet(new condition("HARGA_BELI", textBox7.Text, Logic.none));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isiParamKet(m);
            try
            {
                m.update("BARANG");
                MessageBox.Show("Update Sukses");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Master m = new Master(LOGIN.c);
            try
            {
                m.delBarang("barang",textBox1.Text);
                MessageBox.Show("Delete Sukses");
                resetStat();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
