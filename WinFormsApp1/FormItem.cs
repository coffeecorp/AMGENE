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
    public partial class FormItem : Form
    {
        public string itemCode;
        public string itemName;
        public string itemLot;
        public string itemStatus;
        public double itemQty;
        public double itemNewQty;
        public double itemOrderTemp;
        public string itemNewUnit;
        public string itemUnit;
        
        public string itemNote;
        public string itemvariety;
        public string itemType;
        public string itemSupName;
        public string itemPj;
        public string itemTicketID;
        public string itemCustomer;
        public string itemReceived;
        public string itemGerm;
        public string itemGermAB;
        public string itemGDate;
        public string itemGreTest;
        public string itemGNote;
        public string itemMedia;
        public string itemMediaAB;
        public string itemMDate;
        public string itemMreDate;
        public string itemMNote;
        public string itemGOT;
        public string itemOffType;
        public string itemGOTDATE;
        public string itemGOTRetest;
        public string itemGOTNote;
        public FormItem()
        {
            InitializeComponent();
            

        }
        private void clearContent()
        {
            textBoxCode.Text = "";
            textBoxName.Text = "";
            textBoxLot.Text = "";
            comboBoxStatus.Text = "";
            textBoxAvailable.Text = "";
            textBoxUnit.Text = "";
            textBoxItemNote.Text = "";
            textBoxPerUnit.Text = "";

            textBoxVariety.Text = "";
            textBoxType.Text = "";
            textBoxSupName.Text = "";
            textBoxPj.Text = "";
            textBoxTicket.Text = "";
            dateTimeReceived.Value = DateTime.Now;
            textBoxCustomer.Text = "";


            textBoxGerm.Text = "";
            textBoxGermAb.Text = "";
            dateTimeGDate.Value = DateTime.Now;
            dateTimeGReTest.Value = DateTime.Now;
            textBoxGNote.Text = "";

            textBoxMedia.Text = "";
            textBoxMediaAb.Text = "";
            dateTimeMDate.Value = DateTime.Now;
            dateTimeMReTest.Value = DateTime.Now;
            textBoxMNote.Text = "";

            textBoxGot.Text = "";
            textBoxOffType.Text = "";
            dateTimeGOTDate.Value = DateTime.Now;
            dateTimeGOTReTest.Value = DateTime.Now;
            textBoxGOTNote.Text = "";

        }
        private void selectionReadOnly()
        {
            textBoxCode.ReadOnly = true;
            textBoxName.ReadOnly = true;
            textBoxLot.ReadOnly = true;
            comboBoxStatus.Enabled = false;
            textBoxAvailable.ReadOnly = true;
            textBoxUnit.Enabled = false;
            textBoxItemNote.ReadOnly = true;

            textBoxVariety.ReadOnly = true;
            textBoxType.ReadOnly = true;
            textBoxSupName.ReadOnly = true;
            textBoxPj.ReadOnly = true;
            textBoxTicket.ReadOnly = true;
            dateTimeReceived.Enabled = false;
            textBoxCustomer.ReadOnly = true;


            textBoxGerm.ReadOnly = true;
            textBoxGermAb.ReadOnly = true;
            dateTimeGDate.Enabled = false; ;
            dateTimeGReTest.Enabled = false;
            textBoxGNote.ReadOnly = true;

            textBoxMedia.ReadOnly = true;
            textBoxMediaAb.ReadOnly = true;
            dateTimeMDate.Enabled = false;
            dateTimeMReTest.Enabled = false;
            textBoxMNote.ReadOnly = true;

            textBoxGot.ReadOnly = true;
            textBoxOffType.ReadOnly = true;
            dateTimeGOTDate.Enabled = false;
            dateTimeGOTReTest.Enabled = false;
            textBoxGOTNote.ReadOnly = true;


        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            comboBoxStatus.Enabled = true;
            textBoxItemNote.ReadOnly = false;

        }
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void butDel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to DELETE ?", "Check", MessageBoxButtons.YesNo);
            {
                if (dialogResult == DialogResult.Yes)
                {
                    string sql = "DELETE From stockitem WHERE ItemLot = '" + textBoxLot.Text + "' AND ItemUnit = '" + textBoxUnit.Text + "'";
                    MySqlConnection con = new MySqlConnection("host=localhost;user=test;password=1234;database=amgen_db");
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteReader();
                    con.Close();
                    clearContent();
                    butDel.Enabled = false;
                }
            }

        }
        private void butAdj_Click(object sender, EventArgs e)
        {
            FormItemAdjList frmAdjList = new FormItemAdjList();
            frmAdjList.ShowDialog();
            if (frmAdjList.IsSelect)
            {
                try
                {
                    textBoxTicket.Text = frmAdjList.ticketID.ToString();
                    if (textBoxTicket.Text != null)
                    {
                        string sql = "SELECT * From stockadjustment WHERE ticketID = '" + textBoxTicket.Text + "'";
                        MySqlConnection con = new MySqlConnection("host=localhost;user=test;password=1234;database=amgen_db");
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        con.Open();
                        using (MySqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                textBoxCode.Text = rdr.GetString(4);
                                textBoxName.Text = rdr.GetString(5);
                                textBoxAvailable.Text = rdr.GetString(6);
                                textBoxUnit.Text = rdr.GetString(7);
                                textBoxItemNote.Text = rdr.GetString(8);
                            }
                            rdr.Close();
                        }

                        string addResult = "SELECT adjusttrx.ItemCode, adjusttrx.ticketID, stockitem.ItemGerm, stockitem.ItemGermAB, stockitem.ItemGDate, stockitem.ItemGReTest, stockitem.ItemGNote, stockitem.ItemMedia, stockitem.ItemMediaAB, stockitem.ItemMDate, stockitem.ItemMRetest, stockitem.ItemMNote, stockitem.ItemGot, stockitem.ItemOffType, stockitem.ItemGOTDate, stockitem.ItemGOTRetest, stockitem.ItemGOTNote FROM adjusttrx inner join stockitem on adjusttrx.ItemLot = stockitem.ItemLot AND adjusttrx.ItemUnit = stockitem.ItemUnit WHERE TicketID = '" + textBoxTicket.Text + "'";
                        MySqlCommand cmd2 = new MySqlCommand(addResult, con);
                        using (MySqlDataReader rdr2 = cmd2.ExecuteReader())
                    {
                        while (rdr2.Read())
                        {
                            textBoxGerm.Text = rdr2.GetString(2);
                            textBoxGermAb.Text = rdr2.GetString(3);
                            dateTimeGDate.Text = rdr2.GetString(4);
                            //dateTimeGReTest.Text = rdr2.GetString(5);
                            textBoxGNote.Text = rdr2.GetString(6);

                            textBoxMedia.Text = rdr2.GetString(7);
                            textBoxMediaAb.Text = rdr2.GetString(8);
                            dateTimeMDate.Text = rdr2.GetString(9);
                            //dateTimeMReTest.Text = rdr2.GetString(10);
                            textBoxMNote.Text = rdr2.GetString(11);

                            textBoxGot.Text = rdr2.GetString(12);
                            textBoxOffType.Text = rdr2.GetString(13);
                            dateTimeGOTDate.Text = rdr2.GetString(14);
                            //dateTimeGOTReTest.Text = rdr2.GetString(15);
                            textBoxGOTNote.Text = rdr2.GetString(16);
                        }
                        con.Close();
                    }
                        dateTimeGReTest.Value = dateTimeGDate.Value.AddDays(180);
                        dateTimeMReTest.Value = dateTimeMDate.Value.AddDays(180);
                        dateTimeGOTReTest.Value = dateTimeGOTDate.Value.AddDays(180);
                        textBoxTicket.ReadOnly = true;
                        textBoxAvailable.ReadOnly = true;
                        
                        con.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid Date");
                }
            }
        }
        private void butPrint_Click(object sender, EventArgs e)
        {


        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormItemList frmItemList = new FormItemList();
            frmItemList.ShowDialog();
            if (frmItemList.IsSelect)
            {

                try
                {
                    textBoxLot.Text = frmItemList.itemLot.ToString();
                    textBoxUnit.Text = frmItemList.itemUnit.ToString();

                    if (textBoxLot.Text != null && textBoxLot.Text != null)
                    {
                        string sql = "SELECT * From stockitem WHERE ItemLot = '" + textBoxLot.Text + "' AND ItemUnit = '" + textBoxUnit.Text + "'";
                        MySqlConnection con = new MySqlConnection("host=localhost;user=test;password=1234;database=amgen_db");
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        con.Open();
                        MySqlDataReader rdr;
                        rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            textBoxCode.Text = rdr.GetString(1);
                            textBoxName.Text = rdr.GetString(2);
                            comboBoxStatus.Text = rdr.GetString(4);
                            textBoxAvailable.Text = rdr.GetString(5);

                            textBoxPerUnit.Text = rdr.GetString(8);

                            textBoxItemNote.Text = rdr.GetString(10);
                            textBoxVariety.Text = rdr.GetString(11);
                            textBoxType.Text = rdr.GetString(12);

                            textBoxSupName.Text = rdr.GetString(13);
                            textBoxPj.Text = rdr.GetString(14);
                            textBoxTicket.Text = rdr.GetString(15);
                            textBoxCustomer.Text = rdr.GetString(16);
                            dateTimeReceived.Text = rdr.GetString(17);
                            dateTimeExpireDate.Text = rdr.GetString(18);

                            textBoxGerm.Text = rdr.GetString(19);
                            textBoxGermAb.Text = rdr.GetString(20);
                            dateTimeGDate.Text = rdr.GetString(21);
                            dateTimeGReTest.Text = rdr.GetString(22);
                            textBoxGNote.Text = rdr.GetString(23);

                            textBoxMedia.Text = rdr.GetString(24);
                            textBoxMediaAb.Text = rdr.GetString(25);
                            dateTimeMDate.Text = rdr.GetString(26);
                            dateTimeMReTest.Text = rdr.GetString(27);
                            textBoxMNote.Text = rdr.GetString(28);

                            textBoxGot.Text = rdr.GetString(29);
                            textBoxOffType.Text = rdr.GetString(30);
                            dateTimeGOTDate.Text = rdr.GetString(31);
                            dateTimeGOTReTest.Text = rdr.GetString(32);
                            textBoxGOTNote.Text = rdr.GetString(33);
                        }
                        rdr.Close();
                        con.Close();
                        butDel.Enabled = true;
                    }

                }
                catch
                {
                    MessageBox.Show("Data Invalid");
                }
            }            
        }

        private void textBoxAvailable_KeyPress(object sender, KeyPressEventArgs e)
        {

            int cInt = Convert.ToInt32(e.KeyChar);
            if ((int)e.KeyChar >= 45 && (int)e.KeyChar <= 57 || cInt == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void FormItem_Load(object sender, EventArgs e)
        {

        }

        private void butNew_Click(object sender, EventArgs e)
        {
            clearContent();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            int NumRow;
            //string sql = "SELECT * FROM inventoryitem";
            string sql = "SELECT COUNT(*) From stockitem WHERE ItemLot = '" + textBoxLot.Text + "' AND ItemUnit = '" + textBoxUnit.Text + "'";
            MySqlConnection con = new MySqlConnection("host=localhost;user=test;password=1234;database=amgen_db");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            NumRow = Convert.ToInt32(cmd.ExecuteScalar());
            if (textBoxLot.Text == "" || textBoxAvailable.Text == "" || textBoxUnit.Text == "")
            {
                MessageBox.Show("Please Fill More information");
            }
            else
            {
                if (NumRow > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to Update ?", "Check", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            double total = Convert.ToDouble(textBoxAvailable.Text) * Convert.ToDouble(textBoxPerUnit.Text);
                            sql = "UPDATE stockitem SET ItemStatus = '" + comboBoxStatus.Text + "', ItemPerunit = '"+ textBoxPerUnit.Text +"', ItemSeedUnit = '"+ total +"' WHERE ItemLot = '" + textBoxLot.Text + "' AND ItemUnit = '" + textBoxUnit.Text + "'";
                            cmd = new MySqlCommand(sql, con);
                            cmd.ExecuteNonQuery();
                            clearContent();
                            butDel.Enabled = false; 
                            con.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Error1");
                        }
                    }

                }
                else
                {
                    try
                    {
                        double seedUnit = Convert.ToDouble(textBoxAvailable.Text) * Convert.ToDouble(textBoxPerUnit.Text);
                        sql = "INSERT INTO `stockitem`(`ItemCode`, `ItemName`, `ItemLot`, `ItemStatus`, `ItemAvailable`, `ItemUnit`,`ItemPerunit`,`ItemSeedUnit`, `ItemNote`, `ItemVariety`, `ItemType`, `ItemSupName`, `ItemPj`, `ItemTicket`, `ItemCustomer`, `ItemDateReceived`, `ItemExpire` , `ItemGerm`, `ItemGermAB`, `ItemGDate`, `ItemGReTest`, `ItemGNote`, `ItemMedia`, `ItemMediaAB`, `ItemMDate`, `ItemMReTest`, `ItemMNote`, `ItemGot`, `ItemOffType`, `ItemGOTDate`, `ItemGOTReTest`, `ItemGOTNote`) " +
                        "VALUES('"+textBoxCode.Text+"', '"+textBoxName.Text+"', '"+textBoxLot.Text+"', '"+comboBoxStatus.Text+"', '"+textBoxAvailable.Text+"', '"+textBoxUnit.Text+"', '"+textBoxPerUnit.Text+ "' , '" + seedUnit + "' , '" + textBoxGNote.Text+"', '"+textBoxVariety.Text+"', '"+textBoxType.Text+ "', '" + textBoxSupName.Text + "', '" + textBoxPj.Text + "', '" + textBoxTicket.Text + "', '" + textBoxCustomer.Text + "', '" + dateTimeReceived.Text + "','"+dateTimeExpireDate.Text+"', " +
                        "'" + textBoxGerm.Text + "', '" + textBoxGermAb.Text + "', '" + dateTimeGDate.Text + "', '" + dateTimeGReTest.Text + "', '" + textBoxGNote.Text + "', '" + textBoxMedia.Text + "', '" + textBoxMediaAb.Text + "', '" + dateTimeMDate.Text + "', '" + dateTimeMReTest.Text + "', '" + textBoxMNote.Text + "', '" + textBoxGot.Text + "', '" + textBoxOffType.Text + "', '"+dateTimeGOTDate.Text+"', '"+dateTimeGOTReTest.Text+"', '"+textBoxGOTNote.Text+"')";
                        cmd = new MySqlCommand(sql, con);
                        cmd.ExecuteReader();

                        con.Close();
                        MessageBox.Show("Save Successfully");
                        clearContent();
                        butDel.Enabled = false;
                }
                    catch
                {
                    MessageBox.Show("Error2");
                }
            }
            }
        }

        private void dateTimeGDate_ValueChanged(object sender, EventArgs e)
        {
 
        }

        private void dateTimeMDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimeGOTDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            double available = Convert.ToDouble(textBoxAvailable.Text);
            FormItemUnit frmItemUnit = new FormItemUnit();
            frmItemUnit.itemUnit = textBoxUnit.Text;
            frmItemUnit.itemQty = Convert.ToDouble(textBoxAvailable.Text);
            frmItemUnit.ShowDialog();

            if (frmItemUnit.IsSelect)
            {
                itemQty = frmItemUnit.itemQty;
                itemNewUnit = frmItemUnit.itemNewUnit;
                itemNewQty = frmItemUnit.itemNewQty;

            }
            try
            {
                dateTimeReceived.Value = DateTime.Now;
                var originalCode = textBoxCode.Text.ToCharArray();
                var end = originalCode.Length / 2;

                for(int i = 0; i < end; i++)
                {
                    var temp = originalCode[i];
                    originalCode[i] = originalCode[originalCode.Length - i - 1];
                    originalCode[originalCode.Length - i - 1] = temp;
                }
                var reverseResult = new string(originalCode);
                var inputString = reverseResult.Substring(3, 6);

                var reverseOriginal = inputString.ToCharArray();
                var end2 = reverseOriginal.Length / 2;

                for(int charReverse = 0; charReverse < end2; charReverse++)
                {
                    var temp2 = reverseOriginal[charReverse];
                    reverseOriginal[charReverse] = reverseOriginal[reverseOriginal.Length - charReverse - 1];
                    reverseOriginal[reverseOriginal.Length - charReverse - 1] = temp2;
                }
                var Result = new string(reverseOriginal);

                string addNewUnit = "INSERT INTO `stockitem`(`ItemCode`, `ItemName`, `ItemLot`, `ItemStatus`, `ItemAvailable`, `ItemUnit`, `ItemNote`, `ItemVariety`, `ItemType`, `ItemSupName`, `ItemPj`, `ItemTicket`, `ItemCustomer`, `ItemDateReceived`, `ItemGerm`, `ItemGermAB`, `ItemGDate`, `ItemGReTest`, `ItemGNote`, `ItemMedia`, `ItemMediaAB`, `ItemMDate`, `ItemMReTest`, `ItemMNote`, `ItemGot`, `ItemOffType`, `ItemGOTDate`, `ItemGOTReTest`, `ItemGOTNote`) " +
                "VALUES('" + Result + itemNewUnit + "', '" + textBoxName.Text + "', '" + textBoxLot.Text + "', '" + comboBoxStatus.Text + "', '" + itemNewQty + "', '" + itemNewUnit + "', '" + textBoxItemNote.Text + "', '" + textBoxVariety.Text + "', '" + textBoxType.Text + "', '" + textBoxSupName.Text + "', '" + textBoxPj.Text + "', '" + textBoxTicket.Text + "', '" + textBoxCustomer.Text + "', '" + dateTimeReceived.Text + "', " +
                "'" + textBoxGerm.Text + "', '" + textBoxGermAb.Text + "', '" + dateTimeGDate.Text + "', '" + dateTimeGReTest.Text + "', '" + textBoxGNote.Text + "', '" + textBoxMedia.Text + "', '" + textBoxMediaAb.Text + "', '" + dateTimeMDate.Text + "', '" + dateTimeMReTest.Text + "', '" + textBoxMNote.Text + "', '" + textBoxGot.Text + "', '" + textBoxOffType.Text + "', '" + dateTimeGOTDate.Text + "', '" + dateTimeGOTReTest.Text + "', '" + textBoxGOTNote.Text + "')";
                MySqlConnection con = new MySqlConnection("host=localhost;user=test;password=1234;database=amgen_db");
                MySqlCommand cmd = new MySqlCommand(addNewUnit, con);
                con.Open();
                cmd.ExecuteNonQuery();

                double total = available - itemQty;
                string updateNewAvailable = "UPDATE stockitem SET ItemAvailable = '" + total + "' WHERE ItemLot = '" + textBoxLot.Text + "' AND ItemUnit = '" + textBoxUnit.Text + "'";
                MySqlCommand cmd2 = new MySqlCommand(updateNewAvailable, con);
                cmd2.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Save Successfully");
                clearContent();
                butDel.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Error3");
            }
}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dateTimeGReTest.Value = dateTimeGReTest.Value.AddDays(Convert.ToInt32(textBoxGNext.Text));
        }

        private void textBoxMNext_TextChanged(object sender, EventArgs e)
        {
            dateTimeMReTest.Value = dateTimeMReTest.Value.AddDays(Convert.ToInt32(textBoxMNext.Text));
        }

        private void textBoxGotNaxt_TextChanged(object sender, EventArgs e)
        {
            dateTimeGOTReTest.Value = dateTimeGOTReTest.Value.AddDays(Convert.ToInt32(textBoxGotNaxt.Text));
        }
    }
}
