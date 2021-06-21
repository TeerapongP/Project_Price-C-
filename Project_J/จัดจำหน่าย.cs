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
    public partial class จัดจำหน่าย : Form
    {
        public จัดจำหน่าย()
        {
            InitializeComponent();
        }
        private void random()
        {
            Random random1 = new Random();

            textBox1.Text = "P" + random1.Next(100);
            textBox2.Text = "Q" + random1.Next(100);
            textBox7.Text = "นายไกรอนันต์ รัตนา";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FirstFrom f1 = new FirstFrom();
            f1.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void จัดจำหน่าย_Load(object sender, EventArgs e)
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
                String sqlCmd = "SELECT Product_Name FROM detail_product1";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    comboBox1.Items.Add(dr["Product_Name"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            random();
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
                String sqlCmd = "SELECT * FROM detail_product1 WHERE Product_Name = '" + comboBox1.Text + "'";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                cmd.ExecuteNonQuery();
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string price = (string)dr["Price"].ToString();
                    textBox9.Text = price;
                    string product_code = (string)dr["Product_Code"].ToString();
                    textBox8.Text = product_code;

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
                String sqlCmd = "INSERT INTO distribution (Mod_Number,Customer_Code,Date_Time) VALUES (@p1, @p2, @p3 )";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                cmd.Parameters.AddWithValue("@p1", textBox1.Text);
                cmd.Parameters.AddWithValue("@p2", textBox2.Text);
                cmd.Parameters.AddWithValue("@p3", dateTimePicker1.Value.ToString());
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
                String sqlCmd = "INSERT INTO detail_customer (Customer_Name,Customer_Call,Customer_Address,Delivery_Date,Staff) VALUES (@p1, @p2, @p3, @p4, @p5 )";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                cmd.Parameters.AddWithValue("@p1", textBox3.Text);
                cmd.Parameters.AddWithValue("@p2", textBox5.Text);
                cmd.Parameters.AddWithValue("@p3", textBox6.Text);
                cmd.Parameters.AddWithValue("@p4", dateTimePicker1.Value.ToString());
                cmd.Parameters.AddWithValue("@p5", textBox7.Text);
                cmd.ExecuteNonQuery();
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
                String sqlCmd = "SELECT * FROM sales_data ";
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

        private void button5_Click(object sender, EventArgs e)
        {
            Int32 price = Convert.ToInt32(textBox9.Text);
            Int32 amount = Convert.ToInt32(textBox10.Text);
            float result = price * amount;
            float tax = ((result * 7) / 100);
            float result1 = result + tax;
            textBox12.Text = tax.ToString()+ ".00";
            textBox13.Text = result.ToString()+ ".00";
            textBox11.Text = result1.ToString() + "0.00";
        }
        private void button6_Click(object sender, EventArgs e)
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
                String sqlCmd = "INSERT INTO sales_data (Product_Name,Product_Type,Per_Price,Amount,Total_Price,tax) VALUES (@p1, @p2, @p3, @p4, @p5, @p6)";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                cmd.Parameters.AddWithValue("@p1", comboBox1.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@p2", textBox8.Text);
                cmd.Parameters.AddWithValue("@p3", textBox9.Text);
                cmd.Parameters.AddWithValue("@p4", textBox10.Text);
                cmd.Parameters.AddWithValue("@p5", textBox11.Text);
                cmd.Parameters.AddWithValue("@p6", textBox12.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label25_Click(object sender, EventArgs e)
        {

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

        private void label27_Click(object sender, EventArgs e)
        {
            ส่งคืนสินค้า f6 = new ส่งคืนสินค้า();
            f6.Show();
            this.Hide();
        }

        private void label26_Click(object sender, EventArgs e)
        {
            พิมพ์รายงาน_1 f7 = new พิมพ์รายงาน_1();
            f7.Show();
            this.Hide();
        }

        private void label25_Click_1(object sender, EventArgs e)
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

        private void บรการToolStripMenuItem_Click(object sender, EventArgs e)
        {
            บริการ f4 = new บริการ();
            f4.Show();
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            จัดจำหน่าย_Report rp1 = new จัดจำหน่าย_Report();
            rp1.Show();
            this.Hide();
            CrystalReport0 rpt = new CrystalReport0();

           
            TextObject รหัสใบเสร็จ = (TextObject)rpt.ReportDefinition.Sections["Section1"].ReportObjects["Text19"];
            รหัสใบเสร็จ.Text = textBox1.Text;

            TextObject วันที่ = (TextObject)rpt.ReportDefinition.Sections["Section1"].ReportObjects["Text20"];
            วันที่.Text = dateTimePicker1.Value.ToString();

            TextObject ผู้ขาย = (TextObject)rpt.ReportDefinition.Sections["Section1"].ReportObjects["Text21"];
            ผู้ขาย.Text = textBox7.Text;

            TextObject รหัสสินค้า = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["Text22"];
            รหัสสินค้า.Text = textBox8.Text;

            TextObject ชื่อสินค้า = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["Text23"];
            ชื่อสินค้า.Text = comboBox1.Text;

            TextObject ภาษี = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["Text25"];
            ภาษี.Text = textBox12.Text;

            TextObject ราคา = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["Text26"];
            ราคา.Text = textBox13.Text;


            TextObject จำนวน = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["Text24"];
            จำนวน.Text =textBox10.Text;

            TextObject ชื่อลูกค้า = (TextObject)rpt.ReportDefinition.Sections["Section1"].ReportObjects["Text16"];
            ชื่อลูกค้า.Text = textBox3.Text;

            TextObject ชื่อลูกค้า2 = (TextObject)rpt.ReportDefinition.Sections["Section5"].ReportObjects["Text35"];
            ชื่อลูกค้า2.Text = textBox3.Text;

            TextObject ที่อยู่ = (TextObject)rpt.ReportDefinition.Sections["Section1"].ReportObjects["Text17"];
            ที่อยู่.Text = textBox6.Text;

            TextObject เบอร์โทร = (TextObject)rpt.ReportDefinition.Sections["Section1"].ReportObjects["Text18"];
            เบอร์โทร.Text = textBox5.Text;

            TextObject ผู้ขาย2 = (TextObject)rpt.ReportDefinition.Sections["Section5"].ReportObjects["Text36"];
            ผู้ขาย2.Text = textBox7.Text;

            TextObject รวมราคา = (TextObject)rpt.ReportDefinition.Sections["Section5"].ReportObjects["Text37"];
            รวมราคา.Text = textBox11.Text;

            rp1.crystalReportViewer1.ReportSource = rpt;
        }

        private void กลบเมนหลกToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FirstFrom first = new FirstFrom();
            first.Show();
            this.Hide();
        }
    }
}
