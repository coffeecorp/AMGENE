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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            customizeDesignSidebar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

             panelLogo.BackgroundImage.Width.Equals(50);



            
        }
        private void customizeDesignSidebar()
        {
            panelDash.Visible = false;
            panelProduction.Visible = false;
            panelProcessing.Visible = false;
            panelInventory.Visible = false;
        }
        private void hideSubMenu()
        {
            if  (panelDash.Visible == true)
                panelDash.Visible = false;
            if  (panelProduction.Visible == true)
                panelProduction.Visible = false;
            if  (panelProcessing.Visible == true)
                panelProcessing.Visible = false;
            if (panelInventory.Visible == true)
                panelInventory.Visible = false;
        }
        private void showMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void butDash_Click(object sender, EventArgs e)
        {
            showMenu(panelDash);
        }

        private void butReport_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void butSetting_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showMenu(panelProduction);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            showMenu(panelProcessing);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            showMenu(panelInventory);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            openChildForm(new FormItem());
           // FormItem frmitem = new FormItem();
           // frmitem.ShowDialog();
            hideSubMenu();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            openChildForm(new FormItemAdj());
            hideSubMenu();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if(activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimizeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
