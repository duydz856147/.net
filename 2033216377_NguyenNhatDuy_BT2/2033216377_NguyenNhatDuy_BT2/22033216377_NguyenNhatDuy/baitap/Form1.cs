using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;


namespace baitap
{
    public partial class Form1 : Form
    {
        public class KetNoi
        {
            public SqlConnection connect;
            public KetNoi()
            {
                connect = new SqlConnection("Data Source = A209PC32; Initial Catalog = class; Integrated Security = True");
            }
            public KetNoi(string strcn)
            {
                connect = new SqlConnection(strcn);
            }
        }
        KetNoi kn = new KetNoi();
        SqlConnection connsql;
        public Form1()
        {
            connsql = kn.connect;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
                this.errorProvider1.SetError(ctr, "Khong duoc de trong");
            else
                this.errorProvider1.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string insertString;
                insertString = "Insert into thongtin values(' " + textBox1.Text + " ', N'" + textBox2.Text + "', N'" + textBox3.Text + "', N'" + textBox4.Text + "')";
                SqlCommand cmd = new SqlCommand(insertString, connsql);
                cmd.ExecuteNonQuery();
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
                MessageBox.Show("Thanh Cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That Bai");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string deleteString;
                deleteString = "Delete thongtin where id='" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(deleteString, connsql);
                cmd.ExecuteNonQuery();
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
                MessageBox.Show("Thanh Cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That Bai");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                string updateString;
                updateString = "Update thongtin set ten='" + textBox3.Text + "', ho='" + textBox2.Text + "', ngaysinh='" + textBox4.Text +"'  where id='" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(updateString, connsql);
                cmd.ExecuteNonQuery();
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
                MessageBox.Show("Thanh Cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That Bai");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
