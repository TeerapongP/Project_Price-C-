using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Project_J
{
    public partial class FirstFrom : Form
    {
        public FirstFrom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            จัดซื้อ f3 = new จัดซื้อ();
            f3.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            จัดจำหน่าย f2 = new จัดจำหน่าย();
            f2.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            บริการ f4 = new บริการ();
            f4.Show();
            this.Hide();
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            รับคืนสินค้า f5 = new รับคืนสินค้า();
            f5.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ส่งคืนสินค้า f6 = new ส่งคืนสินค้า();
            f6.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            พิมพ์รายงาน_1 f7 = new พิมพ์รายงาน_1();
            f7.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you wish to exit", "Exit Application", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            จัดซื้อ f1 = new จัดซื้อ();
            f1.Show();
            this.Hide();
        }
    }
}
