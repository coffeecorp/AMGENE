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
    public partial class FormItemList : Form
    {
        public bool IsSelect = false;
        public string itemCode;
        public string itemName;
        public string itemLot;
        public string itemStatus;
        public double itemQty;
        public double itemOrderTemp;
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
        public double itemPerunit;
        public double itemSeedunit;

        DataTable dt = new DataTable("ItemCode,ItemName,ItemLot");
        private void DataGridAddColumn()
        {

            dataGridItemList.Columns[0].HeaderText = "Code";
            dataGridItemList.Columns[1].HeaderText = "Name";
            dataGridItemList.Columns[2].HeaderText = "Lot";
            dataGridItemList.Columns[3].HeaderText = "Status";
            dataGridItemList.Columns[4].HeaderText = "QTY.";
            dataGridItemList.Columns[5].HeaderText = "OrderTemp.";
            dataGridItemList.Columns[6].HeaderText = "Item Per Unit";
            dataGridItemList.Columns[7].HeaderText = "Seed Unit";

            dataGridItemList.Columns[8].HeaderText = "Unit";
            dataGridItemList.Columns[16].HeaderText = "Date Receive";
            dataGridItemList.Columns[17].HeaderText = "Germ";
            dataGridItemList.Columns[22].HeaderText = "Media";
            dataGridItemList.Columns[27].HeaderText = "Got";
            dataGridItemList.Columns[28].HeaderText = "OffType";
            dataGridItemList.Columns[31].HeaderText = "Result Remark";

            //ซ่อน colume
            dataGridItemList.Columns[9].HeaderText = "Note";
            dataGridItemList.Columns[10].HeaderText = "Variety";
            dataGridItemList.Columns[11].HeaderText = "Type";
            dataGridItemList.Columns[12].HeaderText = "SupName";
            dataGridItemList.Columns[13].HeaderText = "pj";
            dataGridItemList.Columns[14].HeaderText = "ticket";
            dataGridItemList.Columns[15].HeaderText = "customer"; 
            dataGridItemList.Columns[18].HeaderText = "GermAB";
            dataGridItemList.Columns[19].HeaderText = "GDate";
            dataGridItemList.Columns[20].HeaderText = "GreTest";
            dataGridItemList.Columns[21].HeaderText = "GNote";
            dataGridItemList.Columns[23].HeaderText = "MediaAB";
            dataGridItemList.Columns[24].HeaderText = "MDate";
            dataGridItemList.Columns[25].HeaderText = "Mretest";
            dataGridItemList.Columns[26].HeaderText = "MNote";
            dataGridItemList.Columns[29].HeaderText = "GotDate";
            dataGridItemList.Columns[30].HeaderText = "GotreTest";


            //dataGridItemList.Columns[0].Width = 100;
            //dataGridItemList.Columns[1].Width = 120;
            //dataGridItemList.Columns[2].Width = 150;
            //dataGridItemList.Columns[3].Width = 80;
            //dataGridItemList.Columns[4].Width = 80;
            //dataGridItemList.Columns[5].Width = 80;
            //dataGridItemList.Columns[6].Width = 150;
            //dataGridItemList.Columns[13].Width = 80;
            //dataGridItemList.Columns[14].Width = 80;
            //dataGridItemList.Columns[19].Width = 80;
            //dataGridItemList.Columns[24].Width = 80;
            //dataGridItemList.Columns[25].Width = 80;
            //dataGridItemList.Columns[28].Width = 150;


            dataGridItemList.Columns[0].ReadOnly = true;
            dataGridItemList.Columns[1].ReadOnly = true;
            dataGridItemList.Columns[2].ReadOnly = true;
            dataGridItemList.Columns[3].ReadOnly = true;
            dataGridItemList.Columns[4].ReadOnly = true;
            dataGridItemList.Columns[5].ReadOnly = true;
            dataGridItemList.Columns[6].ReadOnly = true;
            dataGridItemList.Columns[7].ReadOnly = true;
            dataGridItemList.Columns[8].ReadOnly = true;
            dataGridItemList.Columns[16].ReadOnly = true;
            dataGridItemList.Columns[17].ReadOnly = true;
            dataGridItemList.Columns[22].ReadOnly = true;
            dataGridItemList.Columns[27].ReadOnly = true;
            dataGridItemList.Columns[28].ReadOnly = true;
            dataGridItemList.Columns[31].ReadOnly = true;

            dataGridItemList.Columns[9].Visible = false;
            dataGridItemList.Columns[10].Visible = false;
            dataGridItemList.Columns[11].Visible = false;
            dataGridItemList.Columns[12].Visible = false;
            dataGridItemList.Columns[13].Visible = false;
            dataGridItemList.Columns[14].Visible = false;
            dataGridItemList.Columns[15].Visible = false;
            dataGridItemList.Columns[18].Visible = false;
            dataGridItemList.Columns[19].Visible = false;
            dataGridItemList.Columns[20].Visible = false;
            dataGridItemList.Columns[21].Visible = false;
            dataGridItemList.Columns[23].Visible = false;
            dataGridItemList.Columns[24].Visible = false;
            dataGridItemList.Columns[25].Visible = false;
            dataGridItemList.Columns[26].Visible = false; 
            dataGridItemList.Columns[29].Visible = false;
            dataGridItemList.Columns[30].Visible = false;


            dataGridItemList.RowHeadersVisible = false;

        }
        public FormItemList()
        {
            InitializeComponent();
            string sql = "SELECT `ItemCode`, `ItemName`, `ItemLot`, `ItemStatus`, `ItemAvailable`, `ItemOrderTemp`, `ItemPerunit`, `ItemSeedUnit`, `ItemUnit`, `ItemNote`, `ItemVariety`, `ItemType`, `ItemSupName`, `ItemPj`, `ItemTicket`, `ItemCustomer`, `ItemDateReceived`, `ItemGerm`, `ItemGermAB`, `ItemGDate`, `ItemGReTest`, `ItemGNote`, `ItemMedia`, `ItemMediaAB`, `ItemMDate`, `ItemMReTest`, `ItemMNote`, `ItemGot`, `ItemOffType`, `ItemGOTDate`, `ItemGOTReTest`, `ItemGOTNote` From stockitem ";
            MySqlConnection con = new MySqlConnection("host=localhost;user=test;password=1234;database=amgen_db");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

            con.Open();
            cmd.ExecuteReader();
            con.Close();
            dataGridItemList.DataSource = dt;
            DataGridAddColumn();
        }

        private void dataGridItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormItemList_Load(object sender, EventArgs e)
        {

        }

        private void textBoxSrc_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("ItemCode like '%{0}%'", textBoxSrc.Text, "ItemName like '%{0}%'", textBoxSrc.Text, "ItemLot_Description like '%{0}%'", textBoxSrc.Text);
            dataGridItemList.DataSource = dv.ToTable();
        }

        private void dataGridItemList_CellContentDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            IsSelect = true;
            Int32 rowCurrent;
            if (dataGridItemList != null && dataGridItemList.Rows.Count > 0)
            {
                rowCurrent = dataGridItemList.CurrentRow.Index;
                try
                {
                    itemCode = dataGridItemList.Rows[e.RowIndex].Cells[0].Value.ToString();
                    itemName = dataGridItemList.Rows[e.RowIndex].Cells[1].Value.ToString();
                    itemLot = dataGridItemList.Rows[e.RowIndex].Cells[2].Value.ToString();
                    itemStatus = dataGridItemList.Rows[e.RowIndex].Cells[3].ToString();
                    itemQty = Convert.ToDouble(dataGridItemList.Rows[e.RowIndex].Cells[4].Value);
                    itemOrderTemp = Convert.ToDouble(dataGridItemList.Rows[e.RowIndex].Cells[5].Value.ToString());
                    itemPerunit = Convert.ToDouble(dataGridItemList.Rows[e.RowIndex].Cells[6].Value.ToString());
                    itemSeedunit = Convert.ToDouble(dataGridItemList.Rows[e.RowIndex].Cells[7].Value.ToString());

                    itemUnit = dataGridItemList.Rows[e.RowIndex].Cells[8].Value.ToString();
                    itemNote = dataGridItemList.Rows[e.RowIndex].Cells[9].ToString();


                    //itemvariety = dataGridItemList.Rows[e.RowIndex].Cells[7].ToString();
                    //itemType = dataGridItemList.Rows[e.RowIndex].Cells[8].ToString();
                    //itemSupName = dataGridItemList.Rows[e.RowIndex].Cells[9].ToString();
                    //itemPj = dataGridItemList.Rows[e.RowIndex].Cells[10].ToString();
                    //itemTicketID = dataGridItemList.Rows[e.RowIndex].Cells[10].ToString();
                    //itemCustomer = dataGridItemList.Rows[e.RowIndex].Cells[10].ToString();
                    //itemReceived = dataGridItemList.Rows[e.RowIndex].Cells[10].ToString();
                    itemGerm = dataGridItemList.Rows[e.RowIndex].Cells[17].Value.ToString();
                    itemGermAB = dataGridItemList.Rows[e.RowIndex].Cells[18].Value.ToString();
                    itemMedia = dataGridItemList.Rows[e.RowIndex].Cells[22].Value.ToString();
                    itemMediaAB = dataGridItemList.Rows[e.RowIndex].Cells[23].Value.ToString();
                    itemGOT = dataGridItemList.Rows[e.RowIndex].Cells[27].Value.ToString();
                    itemOffType = dataGridItemList.Rows[e.RowIndex].Cells[28].Value.ToString();
                    itemGOTNote = dataGridItemList.Rows[e.RowIndex].Cells[31].Value.ToString();
                    //itemGerm = dataGridItemList.Rows[e.RowIndex].Cells[10].ToString();
                    //itemGerm = dataGridItemList.Rows[e.RowIndex].Cells[10].ToString();

                }
                catch
                {

                    MessageBox.Show("Data Invalid");
                    return;

                }
            }
            else
            {
                rowCurrent = 0;
                itemCode = "";
                itemLot = "";
                itemUnit = "";
            }

            this.Close();
        }

        private void dataGridItemList_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            itemCode = "";
            itemLot = "";
            itemUnit = "";
        }
    }
}
