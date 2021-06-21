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
    public partial class จัดซื้อ : Form
    {
        public จัดซื้อ()
        {
            InitializeComponent();
        }

        private void random()
        {
                Random random1 = new Random();
            
                textBox1.Text = "P"+random1.Next(100);
                textBox5.Text = "Q" + random1.Next(100);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FirstFrom f1 = new FirstFrom();
            f1.Show();
            this.Hide();
        }
        private void Form3_Load(object sender, EventArgs e)
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
                String sqlCmd = "INSERT INTO purchase_information (Dealer_Code,Dealer_Name,Dealer_Number,Employee_Name,Date_Time) VALUES (@p1, @p2, @p3, @p4, @p5)";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                cmd.Parameters.AddWithValue("@p1", textBox1.Text);
                cmd.Parameters.AddWithValue("@p2", textBox2.Text);
                cmd.Parameters.AddWithValue("@p3", textBox3.Text);
                cmd.Parameters.AddWithValue("@p4", textBox4.Text);
                cmd.Parameters.AddWithValue("@p5", dateTimePicker1.Value.ToString());


                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            
          
        }

      

       

        private void label12_Click(object sender, EventArgs e)
        {
            บริการ f4 = new บริการ();
            f4.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            รับคืนสินค้า f5 = new รับคืนสินค้า();
            f5.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            ส่งคืนสินค้า f6 = new ส่งคืนสินค้า();
            f6.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            พิมพ์รายงาน_1 f7 = new พิมพ์รายงาน_1();
            f7.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            FirstFrom fm = new FirstFrom();
            fm.Show();
            this.Hide();
        }

        private void จดจำหนายToolStripMenuItem_Click(object sender, EventArgs e)
        {
            จัดจำหน่าย f1 = new จัดจำหน่าย();
            f1.Show();
            this.Hide();
        }

        private void บรการToolStripMenuItem_Click(object sender, EventArgs e)
        {
            บริการ f2 = new บริการ();
            f2.Show();
            this.Hide();
        }

        private void รบคนสนคาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            รับคืนสินค้า f3 = new รับคืนสินค้า();
            f3.Show();
            this.Hide();
        }

        private void รบคนToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ส่งคืนสินค้า f4 = new ส่งคืนสินค้า();
            f4.Show();
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

        private void button5_Click_1(object sender, EventArgs e)
        {
            Int32 price = Convert.ToInt32(textBox9.Text);
            Int32 amount = Convert.ToInt32(textBox10.Text);
            float result = price * amount;
            float tax = ((result * 7) / 100);
            float result1 = result + tax;
            textBox12.Text = tax.ToString() + ".00";
            textBox13.Text = result.ToString() + ".00";
            textBox11.Text = result1.ToString() + "0.00";
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            จัดซื้อ_report1 fm = new จัดซื้อ_report1();
            fm.Show();
            this.Hide();
            CrystalReport1 rpt = new CrystalReport1();
            TextObject Dealer_code = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["Text6"];
            Dealer_code.Text = textBox5.Text;
            TextObject Product_name = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["Text21"];
            Product_name.Text = comboBox1.Text;
            TextObject Amount = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["Text22"];
            Amount.Text = textBox10.Text;
            TextObject price = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["Text23"];
            price.Text = textBox9.Text;
            TextObject customer_name = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["Text24"];
            customer_name.Text = textBox4.Text;
            TextObject Dealer_name = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["Text25"];
            Dealer_name.Text = textBox2.Text;
            TextObject Date_time = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["Text26"];
            Date_time.Text = dateTimePicker1.Value.ToString();
            TextObject price_1 = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["Text27"];
            price_1.Text = textBox13.Text;
            TextObject tax = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["Text28"];
            tax.Text = textBox12.Text;
            TextObject final_price = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["Text29"];
            final_price.Text = textBox11.Text;
            fm.crystalReportViewer1.ReportSource = rpt;
        }
    }
}
