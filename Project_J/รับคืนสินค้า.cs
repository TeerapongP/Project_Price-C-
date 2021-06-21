using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
namespace Project_J
{
    public partial class รับคืนสินค้า : Form
    {
        public รับคืนสินค้า()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FirstFrom f1 = new FirstFrom();
            f1.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conn;
            string server = "localhost";
            string database = "triple_c_technology";
            string uid = "root";
            string password = "12345678";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                String sqlCmd = "SELECT Mod_Number FROM distribution";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    comboBox3.Items.Add(dr["Mod_Number"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection conn;
            string server = "localhost";
            string database = "triple_c_technology";
            string uid = "root";
            string password = "12345678";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                String sqlCmd = "INSERT INTO eturn_products (Product_Name,Product_Code,Customer_Code,Custoner_Name,Date_time,Receipt_number,Staff) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7)";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                cmd.Parameters.AddWithValue("@p1", textBox1.Text);
                cmd.Parameters.AddWithValue("@p2", textBox2.Text);
                cmd.Parameters.AddWithValue("@p3", textBox6.Text);
                cmd.Parameters.AddWithValue("@p4", textBox3.Text);
                cmd.Parameters.AddWithValue("@p5", dateTimePicker1.Value.ToString());
                cmd.Parameters.AddWithValue("@p6", textBox4.Text);
                cmd.Parameters.AddWithValue("@p7", textBox5.Text);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection conn;
            string server = "localhost";
            string database = "triple_c_technology";
            string uid = "root";
            string password = "12345678";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                String sqlCmd = "SELECT * FROM eturn_products ";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                cmd.ExecuteNonQuery();
                MySqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dataReader);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label30_Click(object sender, EventArgs e)
        {
            บริการ f4 = new บริการ();
            f4.Show();
            this.Hide();
        }

        private void label25_Click(object sender, EventArgs e)
        {
            จัดซื้อ f1 = new จัดซื้อ();
            f1.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            จัดจำหน่าย f2 = new จัดจำหน่าย();
            f2.Show();
            this.Hide();
        }

        private void label28_Click(object sender, EventArgs e)
        {
            ส่งคืนสินค้า f6 = new ส่งคืนสินค้า();
            f6.Show();
            this.Hide();
        }

        private void label27_Click(object sender, EventArgs e)
        {
            พิมพ์รายงาน_1 f7 = new พิมพ์รายงาน_1();
            f7.Show();
            this.Hide();
        }

        private void label26_Click(object sender, EventArgs e)
        {
            FirstFrom first = new FirstFrom();
            first.Show();
            this.Hide();
        }

        private void จดซอToolStripMenuItem_Click(object sender, EventArgs e)
        {
            จัดซื้อ f1 = new จัดซื้อ();
            f1.Show();
            this.Hide();
        }

        private void จดจำหนายToolStripMenuItem_Click(object sender, EventArgs e)
        {
            จัดจำหน่าย f2 = new จัดจำหน่าย();
            f2.Show();
            this.Hide();
        }

        private void บรการToolStripMenuItem_Click(object sender, EventArgs e)
        {
            บริการ f3 = new บริการ();
            f3.Show();
            this.Hide();
        }

        private void รบคนToolStripMenuItem_Click(object sender, EventArgs e)
        {
            รับคืนสินค้า f5 = new รับคืนสินค้า();
            f5.Show();
            this.Hide();
        }

        private void พมพรายงานToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            พิมพ์รายงาน_1 f7 = new พิมพ์รายงาน_1();
            f7.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            Report_รับคืน fm = new Report_รับคืน();
            fm.Show();
            this.Hide();
            CrystalReport25 rpt = new CrystalReport25();

            TextObject เลขที่ใบเสร็จ = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text13"];
            เลขที่ใบเสร็จ.Text = comboBox3.Text;

            TextObject รหัสสินค้า = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text14"];
            รหัสสินค้า.Text = textBox6.Text;

            TextObject ชื่อลูกค้า = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text15"];
            ชื่อลูกค้า.Text = textBox2.Text;

            TextObject วันที่ทำรายการ = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text16"];
            วันที่ทำรายการ.Text = dateTimePicker1.Value.ToString();

            TextObject เลขที่ใบเสร็จรับเงิน = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text17"];
            เลขที่ใบเสร็จรับเงิน.Text = textBox4.Text;

            TextObject ชื่อพนักงาน = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text18"];
            ชื่อพนักงาน.Text = textBox5.Text;

            fm.crystalReportViewer1.ReportSource = rpt;

        }

        private void กลบเมนหลกToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FirstFrom first = new FirstFrom();
            first.Show();
            this.Hide();
        }

        private void รับคืนสินค้า_Load(object sender, EventArgs e)
        {

        }
    }
}
