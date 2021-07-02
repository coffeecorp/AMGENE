
namespace WinFormsApp1
{
    partial class FormItemUnit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxUnit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxQty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxNewUnit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxNewQty = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Unit :";
            // 
            // comboBoxUnit
            // 
            this.comboBoxUnit.Enabled = false;
            this.comboBoxUnit.FormattingEnabled = true;
            this.comboBoxUnit.Location = new System.Drawing.Point(60, 73);
            this.comboBoxUnit.Name = "comboBoxUnit";
            this.comboBoxUnit.Size = new System.Drawing.Size(143, 23);
            this.comboBoxUnit.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Qty :";
            // 
            // textBoxQty
            // 
            this.textBoxQty.Location = new System.Drawing.Point(60, 107);
            this.textBoxQty.Name = "textBoxQty";
            this.textBoxQty.Size = new System.Drawing.Size(143, 23);
            this.textBoxQty.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(400, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "To";
            // 
            // comboBoxNewUnit
            // 
            this.comboBoxNewUnit.FormattingEnabled = true;
            this.comboBoxNewUnit.Items.AddRange(new object[] {
            "MNR",
            "GNR",
            "SNT",
            "GRN"});
            this.comboBoxNewUnit.Location = new System.Drawing.Point(344, 73);
            this.comboBoxNewUnit.Name = "comboBoxNewUnit";
            this.comboBoxNewUnit.Size = new System.Drawing.Size(143, 23);
            this.comboBoxNewUnit.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Unit :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(303, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Qty :";
            // 
            // textBoxNewQty
            // 
            this.textBoxNewQty.Location = new System.Drawing.Point(344, 107);
            this.textBoxNewQty.Name = "textBoxNewQty";
            this.textBoxNewQty.Size = new System.Drawing.Size(143, 23);
            this.textBoxNewQty.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(202, 164);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Convert";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormItemUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(512, 211);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxNewQty);
            this.Controls.Add(this.textBoxQty);
            this.Controls.Add(this.comboBoxNewUnit);
            this.Controls.Add(this.comboBoxUnit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormItemUnit";
            this.Text = "FormItemUnit";
            this.Load += new System.EventHandler(this.FormItemUnit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxQty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxNewUnit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxNewQty;
        private System.Windows.Forms.Button button2;
    }
}