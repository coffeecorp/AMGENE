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


    public partial class FormItemAdjList : Form
    {
        public bool IsSelect = false;
        public string adjID;
        public string ticketID;

        DataTable dt = new DataTable("adjID,ticketID,assemblyCode");
        private void DataGridAddColumn()
        {

            dataGridView1.Columns[0].HeaderText = "Adj.ID";
            dataGridView1.Columns[1].HeaderText = "Process";
            dataGridView1.Columns[2].HeaderText = "Date";
            dataGridView1.Columns[3].HeaderText = "Ticket ID";
            dataGridView1.Columns[4].HeaderText = "Assembly Code";
            dataGridView1.Columns[5].HeaderText = "Assembly Name";
            dataGridView1.Columns[6].HeaderText = "Qty Build";
            dataGridView1.Columns[7].HeaderText = "Unit";
            dataGridView1.Columns[8].HeaderText = "Note";

            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 250;
            dataGridView1.Columns[6].Width = 80;
            dataGridView1.Columns[7].Width = 80;
            dataGridView1.Columns[8].Width = 250;



            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;
            dataGridView1.Columns[6].ReadOnly = true;
            dataGridView1.Columns[7].ReadOnly = true;
            dataGridView1.Columns[8].ReadOnly = true;


            dataGridView1.RowHeadersVisible = false;

        }
        public FormItemAdjList()
        {
            InitializeComponent();
            string sql = "SELECT * FROM stockadjustment";
            MySqlConnection con = new MySqlConnection("host=localhost;user=test;password=1234;database=amgen_db");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

            con.Open();
            cmd.ExecuteReader();
            con.Close();
            dataGridView1.DataSource = dt;

            DataGridAddColumn();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormItemAdjList_Load(object sender, EventArgs e)
        {

        }

        private void textBoxSrc_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("adjID like '%{0}%'", textBoxSrc.Text, "ticketID like '%{0}%'", textBoxSrc.Text, "assemblyCode like '%{0}%'", textBoxSrc.Text);
            dataGridView1.DataSource = dv.ToTable();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            IsSelect = true;
            Int32 rowCurrent;
            if (dataGridView1 != null && dataGridView1.Rows.Count > 0)
            {
                rowCurrent = dataGridView1.CurrentRow.Index;
                try
                {
                    adjID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    ticketID = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                }
                catch
                {

                    MessageBox.Show("Error");
                }
            }
            else
            {
                rowCurrent = 0;
                adjID = "";
                ticketID = "";
            }

            this.Close();
        }

    }
}
