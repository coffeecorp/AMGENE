using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormItemUnit : Form
    {
        public bool IsSelect = false;
        public double itemQty;
        public string itemUnit;
        public string itemNewUnit;
        public double itemNewQty;

        public FormItemUnit()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormItemUnit_Load(object sender, EventArgs e)
        {
            comboBoxUnit.Text = itemUnit;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IsSelect = true;
            DialogResult dialog = MessageBox.Show("Do you want to convert unit ?", "Check", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                itemNewQty = Convert.ToDouble(textBoxNewQty.Text);
                itemNewUnit = comboBoxNewUnit.Text;
                itemQty = Convert.ToDouble(textBoxQty.Text);
            }
            else
            {
                return;
            }
            this.Close();

        }
    }
}
