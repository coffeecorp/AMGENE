using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class DataTest : Form
    {
        public DataTest()
        {
            InitializeComponent();
        }
        public string myString = "1234";

        private void DataTest_Load(object sender, EventArgs e)
        {
            //string addResult = "SELECT adjusttrx.ItemCode, adjusttrx.ticketID, stockitem.ItemGerm, stockitem.ItemGermAB, stockitem.ItemGDate, stockitem.ItemGReTest, stockitem.ItemGNote, stockitem.ItemMedia, stockitem.ItemMediaAB, stockitem.ItemMDate, stockitem.ItemMRetest, stockitem.ItemMNote, stockitem.ItemGot, stockitem.ItemOffType, stockitem.ItemGOTDate, stockitem.ItemGOTRetest, stockitem.ItemGOTNote FROM adjusttrx inner join stockitem on adjusttrx.ItemLot = stockitem.ItemLot AND adjusttrx.ItemUnit = stockitem.ItemUnit";
            string addResult = "SELECT adjusttrx.ItemOrder, stockitem.ItemAvailable FROM adjusttrx INNER JOIN stockitem on adjusttrx.ItemLot = stockitem.ItemLot AND adjusttrx.ItemUnit = stockitem.ItemUnit";
            MySqlConnection con = new MySqlConnection("host=localhost;user=test;password=1234;database=amgen_db");
            MySqlCommand cmd2 = new MySqlCommand(addResult, con);
            con.Open();
            //cmd2.ExecuteReader();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            var inputArray = myString.ToCharArray();
            var end = inputArray.Length / 2;

            for (int i = 0; i < end; i++)
            {
                var temp = inputArray[i];
                inputArray[i] = inputArray[inputArray.Length - i - 1];
                inputArray[inputArray.Length - i - 1] = temp;
            }

            var result = new string(inputArray);
            MessageBox.Show(result);

        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            dateTimePicker2.Value =  dateTimePicker2.Value.AddDays(30);
        }
    }
}
