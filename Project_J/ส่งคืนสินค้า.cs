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
    public partial class ส่งคืนสินค้า : Form
    {
        public ส่งคืนสินค้า()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FirstFrom f1 = new FirstFrom();
            f1.Show();
            this.Hide();
        }

        private void ส่งคืนสินค้า_Load(object sender, EventArgs e)
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
                String sqlCmd = "SELECT Product_Code FROM detail_product1";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    comboBox1.Items.Add(dr["Product_Code"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
                String sqlCmd = "SELECT * FROM detail_product1 WHERE Product_Code = '" + comboBox1.Text + "'";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                cmd.ExecuteNonQuery();
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string product_code = (string)dr["Product_Code"].ToString();
                    textBox1.Text = product_code;
                    string product_name = (string)dr["Product_Name"].ToString();
                    textBox1.Text = product_name;
                    string product_Type = (string)dr["Product_Type"].ToString();
                    textBox3.Text = product_Type;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                String sqlCmd = "INSERT INTO return_product (Product_Code,Product_Name,Product_Type,Amount,Note) VALUES (@p1, @p2, @p3, @p4, @p5)";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                cmd.Parameters.AddWithValue("@p1", comboBox1.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@p2", textBox1.Text);
                cmd.Parameters.AddWithValue("@p3", textBox3.Text);
                cmd.Parameters.AddWithValue("@p4", textBox4.Text);
                cmd.Parameters.AddWithValue("@p5", textBox2.Text);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
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
                String sqlCmd = "SELECT * FROM return_product ";
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
                MessageBox.Show("Connect Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                String sqlCmd = "DELETE FROM return_product";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("DELETE SUCCESS.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            จัดจำหน่าย f2 = new จัดจำหน่าย();
            f2.Show();
            this.Hide();
        }

        private void label30_Click(object sender, EventArgs e)
        {
            จัดซื้อ f1 = new จัดซื้อ();
            f1.Show();
            this.Hide();
        }

        private void label29_Click(object sender, EventArgs e)
        {
            บริการ f4 = new บริการ();
            f4.Show();
            this.Hide();
        }

        private void label28_Click(object sender, EventArgs e)
        {
            รับคืนสินค้า f5 = new รับคืนสินค้า();
            f5.Show();
            this.Hide();
        }

        private void label26_Click(object sender, EventArgs e)
        {
            พิมพ์รายงาน_1 f7 = new พิมพ์รายงาน_1();
            f7.Show();
            this.Hide();
        }

        private void label25_Click(object sender, EventArgs e)
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

        private void รบคนสนคาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            รับคืนสินค้า f5 = new รับคืนสินค้า();
            f5.Show();
            this.Hide();
        }

        private void รบคนToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ส่งคืนสินค้า f6 = new ส่งคืนสินค้า();
            f6.Show();
            this.Hide();
        }

        private void พมพรายงานToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            พิมพ์รายงาน_1 f7 = new พิมพ์รายงาน_1();
            f7.Show();
            this.Hide();
        }

        private void กลบเมนหลกToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FirstFrom first = new FirstFrom();
            first.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ส่งคืนสินค้า_1 ส่งคืน = new ส่งคืนสินค้า_1();
            ส่งคืน.Show();
            this.Hide();
            CrystalReport26 rpt = new CrystalReport26();

            TextObject รหัสสินค้า = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text12"];
            รหัสสินค้า.Text = comboBox1.Text;

            TextObject ชื่อสินค้า = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text13"];
            ชื่อสินค้า.Text = textBox1.Text;

            TextObject หมายเหตุ = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text14"];
            หมายเหตุ.Text = textBox2.Text;

            TextObject ประเภทสินค้า = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text15"];
            ประเภทสินค้า.Text = textBox3.Text;

            TextObject จำนวน = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text16"];
            จำนวน.Text = textBox4.Text;

            ส่งคืน.crystalReportViewer1.ReportSource = rpt;
        }
    }
}
