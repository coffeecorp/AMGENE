using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormItemAdj : Form
    {
        private Button btnSelector = new Button();
        private int pCase;
        private void SelectorClick(object sender, EventArgs e)
        {
            switch (pCase)
            {
                case 1:
                    if (true)
                    {

                        FormItemList frmItemList = new FormItemList();
                        frmItemList.ShowDialog();
                        if (frmItemList.IsSelect)
                        {
                            for (int row = 0; row < dataGridView1.Rows.Count; row++)
                            {

                                if (dataGridView1.Rows[row].Cells[2].Value != null &&
                                dataGridView1.Rows[row].Cells[2].Value.Equals(frmItemList.itemLot.ToString()) && dataGridView1.Rows[row].Cells[8].Value.Equals(frmItemList.itemUnit.ToString()))
                                {
                                    MessageBox.Show("Please check Lot Duplicate");
                                    return;
                                }
                            }
                            dataGridView1.Rows.Add(frmItemList.itemCode, frmItemList.itemLot, frmItemList.itemName, 0, frmItemList.itemUnit, frmItemList.itemGerm.ToString(), frmItemList.itemGermAB.ToString(), frmItemList.itemMedia, frmItemList.itemMediaAB, frmItemList.itemGOT, frmItemList.itemOffType, frmItemList.itemGOTNote, frmItemList.itemQty);
                            btnSelector.Hide();
                            //    return;
                            //    int sum = 0;
                            //    string germResult;
                            //    int avgGerm = 1;
                            //    int avgData = 0;
                            //    int total = 0;
                            //    string resultReverse;
                            //    for (avgData = 0; avgData < dataGridView1.Rows.Count; avgData++)
                            //    {
                            //        if (dataGridView1.Rows[avgData].Cells[5].Value != null && dataGridView1.Rows[avgData].Cells[5].Value != "")
                            //        {
                            //            germResult = dataGridView1.Rows[avgData].Cells[5].Value.ToString();
                            //            //reverse right to left
                            //            var inputArray = germResult.ToCharArray();
                            //            var end = inputArray.Length / 2;

                            //            for (int i = 0; i < end; i++)
                            //            {
                            //                var temp = inputArray[i];
                            //                inputArray[i] = inputArray[inputArray.Length - i - 1];
                            //                inputArray[inputArray.Length - i - 1] = temp;
                            //            }

                            //            var result = new string(inputArray);
                            //            resultReverse = result.Substring(1, 2);
                            //            //reverse left to right
                            //            var reverse = resultReverse.ToCharArray();
                            //            var end2 = reverse.Length / 2;

                            //            for (int i = 0; i < end2; i++)
                            //            {
                            //                var temp2 = reverse[i];
                            //                reverse[i] = reverse[reverse.Length - i - 1];
                            //                reverse[reverse.Length - i - 1] = temp2;
                            //            }
                            //            var result2 = new string(reverse);
                            //            sum += Convert.ToInt32(result2);
                            //        }

                            //        avgGerm = avgData;


                            //    }
                            //    total = (sum / avgGerm);
                            //    MessageBox.Show(total.ToString());
                        }

                    }
                    break;
            }

        }
        private void CreatButton(ref Button myButton)
        {
            myButton.FlatStyle = FlatStyle.Flat;
            myButton.FlatAppearance.BorderSize = 0;
            myButton.Size = new Size(18, 18);
            myButton.ImageAlign = ContentAlignment.MiddleCenter;
            myButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            myButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            myButton.BackColor = Color.Transparent;
            myButton.Image = Image.FromFile(FileSystem.CurDir() + "\\resource\\icons8-search-24.png");
            //myButton.Image = Image.FromFile("@resources/icons8-search-24.png");

            myButton.Hide();
            myButton.Click += new EventHandler(this.SelectorClick);
            //--------------------------------------------
        }
        private void DataGridAddColumn()
        {
            CreatButton(ref btnSelector);
            dataGridView1.Controls.Add(btnSelector);
            DataGridViewButtonCell btn = new DataGridViewButtonCell();
            dataGridView1.ColumnCount = 13;
            dataGridView1.Columns[0].HeaderText = "Item Code";
            dataGridView1.Columns[1].HeaderText = "Item Lot";
            dataGridView1.Columns[1].Name = "ItemLot";
            dataGridView1.Columns[2].HeaderText = "Item Name";
            dataGridView1.Columns[3].HeaderText = "Item Order";
            dataGridView1.Columns[4].HeaderText = "Item Unit";
            dataGridView1.Columns[5].HeaderText = "Germ";
            dataGridView1.Columns[6].HeaderText = "GermAB";
            dataGridView1.Columns[7].HeaderText = "Media";
            dataGridView1.Columns[8].HeaderText = "MediaAB";
            dataGridView1.Columns[9].HeaderText = "GOT";
            dataGridView1.Columns[10].HeaderText = "Off Type";
            dataGridView1.Columns[11].HeaderText = "Result Note";

            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 180;
            dataGridView1.Columns[2].Width = 180;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 80;
            dataGridView1.Columns[5].Width = 80;
            dataGridView1.Columns[6].Width = 80;
            dataGridView1.Columns[7].Width = 80;
            dataGridView1.Columns[8].Width = 80;
            dataGridView1.Columns[9].Width = 80;
            dataGridView1.Columns[10].Width = 80;
            dataGridView1.Columns[11].Width = 150;

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;
            dataGridView1.Columns[6].ReadOnly = true;
            dataGridView1.Columns[7].ReadOnly = true;
            dataGridView1.Columns[8].ReadOnly = true;
            dataGridView1.Columns[9].ReadOnly = true;
            dataGridView1.Columns[10].ReadOnly = true;
            dataGridView1.Columns[11].ReadOnly = true;

            dataGridView1.Columns[12].Visible = false;
            dataGridView1.RowHeadersVisible = false;
        }
        private void dataClear()
        {
            dataGridView1.Rows.Clear();
            textBoxTicketID.Text = "";
            textBoxAdjNote.Text = "";
            textBoxAssemblyCode.Text = "";
            textBoxAssemblyName.Text = "";
            comboBoxAdjFor.Text = "";
            textBoxQtyBuild.Text = "";
            comboBoxUnit.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }
        public FormItemAdj()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormItemAdj_Load(object sender, EventArgs e)
        {
            DataGridAddColumn();

            string sql = "SELECT ItemCode From stockitem";
            MySqlConnection con = new MySqlConnection("host=localhost;user=test;password=1234;database=amgen_db");
            MySqlCommand cmd = new MySqlCommand(sql,con);
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for(int i = 0; i<dt.Rows.Count; i++)
            {
                textBoxAssemblyCode.Items.Add(dt.Rows[i]["ItemCode"].ToString());
            }
            textBoxAssemblyCode.AutoCompleteSource = AutoCompleteSource.ListItems;
            textBoxAssemblyCode.AutoCompleteMode = AutoCompleteMode.Suggest;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((dataGridView1 != null) && (dataGridView1.RowCount > 0))
            {
                try
                {
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(rowIndex);
                }
                catch
                {
                    MessageBox.Show("ไม่พบข้อมูลในตารางที่เลือก");
                }
            }
        }

        private void buttonSrc_Click(object sender, EventArgs e)
        {
            FormItemAdjList frmItemList = new FormItemAdjList();
            frmItemList.ShowDialog();
            if (frmItemList.ticketID != "")
            {
                dataClear();
            }
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter();
            if (frmItemList.IsSelect)
            {

                try
                {
                    textBoxTicketID.Text = frmItemList.ticketID.ToString();
                    if (textBoxTicketID.Text != null)
                    {
                        string sql = "SELECT * From stockadjustment WHERE ticketID = '" + textBoxTicketID.Text + "'";
                        MySqlConnection con = new MySqlConnection("host=localhost;user=test;password=1234;database=amgen_db");
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        con.Open();
                        MySqlDataReader rdr;
                        rdr = cmd.ExecuteReader();
                        bool temp = false;

                        while (rdr.Read())
                        {
                            comboBoxAdjFor.Text = rdr.GetString(1);
                            dateTimePicker1.Text = rdr.GetString(2);
                            textBoxTicketID.Text = rdr.GetString(3);
                            textBoxAssemblyCode.Text = rdr.GetString(4);
                            textBoxAssemblyName.Text = rdr.GetString(5);
                            textBoxQtyBuild.Text = rdr.GetString(6);
                            comboBoxUnit.Text = rdr.GetString(7);
                            textBoxAdjNote.Text = rdr.GetString(8);
                        }
                        con.Close();

                        string trxAdd = "SELECT adjusttrx.ItemCode, adjusttrx.ItemLot, adjusttrx.ItemName, adjusttrx.ItemOrder, adjusttrx.ItemUnit, stockitem.ItemGerm, stockitem.ItemGermAB, stockitem.ItemMedia, stockitem.ItemMediaAB, stockitem.ItemGot, stockitem.ItemOffType, stockitem.ItemGOTNote, stockitem.ItemAvailable FROM adjusttrx inner join stockitem on adjusttrx.ItemLot = stockitem.ItemLot AND adjusttrx.ItemUnit = stockitem.ItemUnit WHERE ticketID = '" + textBoxTicketID.Text + "'";
                        MySqlCommand cmd2 = new MySqlCommand(trxAdd, con);
                        da = new MySqlDataAdapter(cmd2);
                        da.Fill(dt);
                        con.Open();
                        cmd2.ExecuteReader();
                        foreach (DataRow row in dt.Rows)
                        {
                            dataGridView1.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], row[11], row[12]);
                        }

                        con.Close();
                        return;
                    }

                }
                catch
                {
                    MessageBox.Show("error");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < dataGridView1.RowCount -1; i++)
            {
                if (Convert.ToDouble(dataGridView1.Rows[i].Cells[12].Value) < Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value))
                {
                    string totalcheck;
                    string checkAvailable = "SELECT ItemAvailable FROM stockitem WHERE ItemLot = '" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "' AND ItemUnit = '" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "'";
                    MySqlConnection connection = new MySqlConnection("host=localhost;user=test;password=1234;database=amgen_db");
                    MySqlCommand cmdcheck = new MySqlCommand(checkAvailable, connection);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmdcheck);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    

                    Double totalAvailable = Convert.ToDouble(totalcheck) + Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                    if (totalAvailable < Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value))
                    {
                        MessageBox.Show("Item Not Available");
                        return;
                    }

                }
                continue;
            }
            MySqlConnection con = new MySqlConnection("host=localhost;user=test;password=1234;database=amgen_db");
            if (dataGridView1.RowCount > 0 && textBoxQtyBuild.Text != null )
            {
                int numrow = 0;
                string sql = "SELECT COUNT(*) FROM adjusttrx WHERE ticketID = '" + textBoxTicketID.Text + "'";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                numrow = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                if (numrow > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to Update ?", "Check", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                            {
                                    //update transection
                                    sql = "UPDATE adjusttrx SET ItemOrder = (ItemOrder - ItemOrder) + '" + Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) + "' WHERE ticketID = '" + textBoxTicketID.Text + "'";
                                    string updateAvailable = "UPDATE adjusttrx INNER JOIN stockitem on adjusttrx.ItemLot = stockitem.ItemLot AND adjusttrx.ItemUnit = stockitem.ItemUnit SET stockitem.ItemAvailable = (stockitem.ItemAvailable + adjusttrx.ItemOrder) WHERE adjusttrx.ticketID = '" + textBoxTicketID.Text + "' AND stockitem.ItemLot = '" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "' AND stockitem.ItemUnit = '" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "'";
                                    MySqlCommand upAvailable = new MySqlCommand(updateAvailable, con);
                                    con.Open();
                                    upAvailable.ExecuteNonQuery();// + return Available

                                    string delIteminvlist = "UPDATE stockitem SET ItemAvailable = ItemAvailable - '" + Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) + "' WHERE ItemLot = '" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "' AND ItemUnit = '" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "'";
                                    MySqlCommand cmd2 = new MySqlCommand(delIteminvlist, con);
                                    cmd2.ExecuteNonQuery(); // - stockitem available

                                    string updateSeedPerunit = "UPDATE stockitem SET ItemSeedUnit = ItemAvailable * ItemPerunit WHERE ItemLot = '" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "' AND ItemUnit = '" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "'";
                                    MySqlCommand upSeed = new MySqlCommand(updateSeedPerunit, con);
                                    upSeed.ExecuteNonQuery(); // Update Seed per Unit
                                    con.Close();
                            }
                            //Delete transection
                            string deleteAdjusttrx = "DELETE FROM adjusttrx WHERE ticketID = '" + textBoxTicketID.Text + "'";
                            MySqlCommand delTrx = new MySqlCommand(deleteAdjusttrx, con);
                            con.Open();
                            delTrx.ExecuteNonQuery(); // Delete old transection
                            
                            //Delete Old AdjustmentBuild
                            string deleteAdj = "DELETE FROM stockadjustment WHERE ticketID = '" + textBoxTicketID.Text + "'";
                            MySqlCommand delAdj = new MySqlCommand(deleteAdj, con);
                            delAdj.ExecuteNonQuery(); // Delete old workticket

                            //Insert New ajustmentBuild
                             string InsertAdj = "INSERT INTO `stockadjustment` ( `adjselect`, `adjDate`, `ticketID`, `assemblyCode`, `assemblyName`, `adjQtyBuild`, `adjUnit` , `adjNote`) " +
                            "VALUES ('" + comboBoxAdjFor.Text + "','" + dateTimePicker1.Text + "','" + textBoxTicketID.Text + "','" + textBoxAssemblyCode.Text + "','" + textBoxAssemblyName.Text + "','" + textBoxQtyBuild.Text + "','" + comboBoxUnit.Text + "','" + textBoxAdjNote.Text + "')";
                            MySqlCommand cmdInsert = new MySqlCommand(InsertAdj, con);
                            cmdInsert.ExecuteNonQuery();
                            con.Close();

                            //Insert Transction
                            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                            {

                                string adjTrx = "INSERT INTO `adjusttrx`(`ItemCode`, `ItemLot`, `ItemName`, `ItemOrder`, `ItemUnit`, `ticketID`, `TrxFor`) " +
                                "VALUES ('" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString()) + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "', '" + textBoxTicketID.Text + "','" + comboBoxAdjFor.Text + "')";
                                MySqlCommand cmd3 = new MySqlCommand(adjTrx, con);
                                con.Open();
                                cmd3.ExecuteNonQuery(); // add new transection

                            }
                            con.Close();
                            dataClear();
                            return;

                        }
                            catch
                        {
                            MessageBox.Show("Error");
                        }
                }
                }// Update transection
                else
                {
                    try
                    {
                        for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                        {
                            if (Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) > 0)
                            {
                                string delIteminvlist = "UPDATE stockitem SET ItemAvailable = ItemAvailable - '" + Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) + "' WHERE ItemLot = '" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "' AND ItemUnit = '" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "'";
                                MySqlCommand cmd2 = new MySqlCommand(delIteminvlist, con);
                                con.Open();
                                cmd2.ExecuteNonQuery();

                                string adjTrx = "INSERT INTO `adjusttrx`(`ItemCode`, `ItemLot`, `ItemName`, `ItemOrder`, `ItemUnit`, `ticketID`, `TrxFor`) " +
                                    "VALUES ('" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString()) + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "', '" + textBoxTicketID.Text + "','" + comboBoxAdjFor.Text + "')";
                                MySqlCommand cmd3 = new MySqlCommand(adjTrx, con);
                                cmd3.ExecuteNonQuery();
                                con.Close();
                            }

                            else
                            {
                                MessageBox.Show("Please fill Oder Row" + " " + i.ToString());
                                return;
                            }

                        }
                        string InsertAdj = "INSERT INTO `stockadjustment` ( `adjselect`, `adjDate`, `ticketID`, `assemblyCode`, `assemblyName`, `adjQtyBuild`, `adjUnit` , `adjNote`) " +
                        "VALUES ('" + comboBoxAdjFor.Text + "','" + dateTimePicker1.Text + "','" + textBoxTicketID.Text + "','" + textBoxAssemblyCode.Text + "','" + textBoxAssemblyName.Text + "','" + textBoxQtyBuild.Text + "','" + comboBoxUnit.Text + "','" + textBoxAdjNote.Text + "')";
                        MySqlCommand cmdInsert = new MySqlCommand(InsertAdj, con);
                        con.Open();
                        cmdInsert.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Done");
                        dataClear();
                    }
                    catch
                    {
                        MessageBox.Show("Please fill information");
                        return;
                    }
                } // Add new transection and adjustment
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataClear();
        }

        private void textBoxAssemblyCode_TextChanged(object sender, EventArgs e)
        {
            string autoName = "SELECT DISTINCT ItemName FROM stockitem WHERE ItemCode = '"+textBoxAssemblyCode.Text+"'";
            MySqlConnection con = new MySqlConnection("host=localhost;user=test;password=1234;database=amgen_db");
            MySqlCommand cmd = new MySqlCommand(autoName, con);
            con.Open();
            MySqlDataReader dr1;
            dr1 = cmd.ExecuteReader();
            if (dr1.Read())
            {
                textBoxAssemblyName.Text = dr1.GetValue(0).ToString();
            }
            con.Close();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "ItemLot")
            {
                pCase = 1;
                Rectangle Loc = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                int Wid = dataGridView1.CurrentCell.Size.Width;
                btnSelector.Location = new Point(Loc.X - 25 + Wid, Loc.Y + 3);
                btnSelector.Show();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if(btnSelector.Focused != true)
            {
                btnSelector.Hide();
            }

        }
    }
}
