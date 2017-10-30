﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WindowsFormsApplication2
{
    public partial class 충청남도 : Form
    {
        private String strConn;
        private MySqlConnection conn;

        private String Do_Name = null;


        public string D0_Name;
        public 충청남도(string Do)
        {
            D0_Name = Do;
            InitializeComponent();
            comboBox1.Items.Add("당진군");
            comboBox1.Items.Add("태안군");
            comboBox1.Items.Add("서산시");
            comboBox1.Items.Add("예산군");
            comboBox1.Items.Add("아신시");
            comboBox1.Items.Add("천안시");
            comboBox1.Items.Add("연기군");
            comboBox1.Items.Add("홍성군");
            comboBox1.Items.Add("청양군");
            comboBox1.Items.Add("보령시");
            comboBox1.Items.Add("부여군");
            comboBox1.Items.Add("서천군");
            comboBox1.Items.Add("논산시");
            comboBox1.Items.Add("금산군");
            comboBox1.Items.Add("공주시");
        }
        private void print2_data()
        {

            string query1 = "SELECT count(Distinct h_name) FROM human h JOIN criminal cr ON(h.h_id = cr.h_id) WHERE h_address LIKE '" + Do_Name + "%';";

            MySqlCommand cmd1 = new MySqlCommand(query1);
            cmd1.Connection = conn;

            conn.Open();
            MySqlDataReader reader = cmd1.ExecuteReader();

            try
            {
                reader.Read();
                label2.Text = reader.GetString(0);
                label3.Text = Do_Name + " 범죄자 수 :";
                conn.Close();
                reader.Close();
            }

            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }
        private void 충청남도_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            int selectedIndex = comboBox1.SelectedIndex;
            Object selectedItem = comboBox1.SelectedItem;

            // MessageBox.Show("Selected Item Text: " + selectedItem.ToString());

            String Si_Name = Do_Name + " " + selectedItem.ToString();

            MessageBox.Show(Si_Name);

            this.Visible = false; //현재 창 사라지게 하는 것


            monitor_list mlist = new monitor_list(Si_Name);

            mlist.ShowDialog();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false; //현재 창 사라지게 하는 것
            Form1 jungak = new Form1();

            jungak.ShowDialog();
        }
    }
}
