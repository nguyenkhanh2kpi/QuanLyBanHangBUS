
namespace QuanLyBanHang.Gui
{
    partial class CheckOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckOut));
            this.labelTotal = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxCusPhone = new System.Windows.Forms.TextBox();
            this.textBoxCusName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOrder = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBoxPayment = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.labeldiscount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxBronze = new System.Windows.Forms.CheckBox();
            this.checkBoxSilver = new System.Windows.Forms.CheckBox();
            this.checkBoxGold = new System.Windows.Forms.CheckBox();
            this.buttonGiftCart = new System.Windows.Forms.Button();
            this.textBoxGiftCart = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTotal
            // 
            this.labelTotal.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.Location = new System.Drawing.Point(677, 648);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(199, 36);
            this.labelTotal.TabIndex = 12;
            this.labelTotal.Text = "Total";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(239)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.textBoxCusPhone);
            this.panel1.Controls.Add(this.textBoxCusName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(71, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 168);
            this.panel1.TabIndex = 10;
            // 
            // textBoxCusPhone
            // 
            this.textBoxCusPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCusPhone.Location = new System.Drawing.Point(93, 109);
            this.textBoxCusPhone.Name = "textBoxCusPhone";
            this.textBoxCusPhone.Size = new System.Drawing.Size(303, 32);
            this.textBoxCusPhone.TabIndex = 4;
            // 
            // textBoxCusName
            // 
            this.textBoxCusName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCusName.Location = new System.Drawing.Point(93, 42);
            this.textBoxCusName.Name = "textBoxCusName";
            this.textBoxCusName.Size = new System.Drawing.Size(303, 32);
            this.textBoxCusName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "Customer Phone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Customer Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(531, 653);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 26);
            this.label1.TabIndex = 9;
            this.label1.Text = "Total";
            // 
            // buttonOrder
            // 
            this.buttonOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOrder.Location = new System.Drawing.Point(921, 648);
            this.buttonOrder.Name = "buttonOrder";
            this.buttonOrder.Size = new System.Drawing.Size(258, 36);
            this.buttonOrder.TabIndex = 8;
            this.buttonOrder.Text = "Export";
            this.buttonOrder.UseVisualStyleBackColor = true;
            this.buttonOrder.Click += new System.EventHandler(this.buttonOrder_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(536, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(709, 404);
            this.dataGridView1.TabIndex = 7;
            // 
            // comboBoxPayment
            // 
            this.comboBoxPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPayment.FormattingEnabled = true;
            this.comboBoxPayment.Items.AddRange(new object[] {
            "direct payment",
            "payment via card",
            "pay on delivery"});
            this.comboBoxPayment.Location = new System.Drawing.Point(677, 560);
            this.comboBoxPayment.Name = "comboBoxPayment";
            this.comboBoxPayment.Size = new System.Drawing.Size(199, 34);
            this.comboBoxPayment.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(921, 560);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(258, 36);
            this.button1.TabIndex = 14;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(531, 560);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 26);
            this.label4.TabIndex = 15;
            this.label4.Text = "Payment";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(71, 296);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(258, 49);
            this.button3.TabIndex = 17;
            this.button3.Text = "Weekend discount";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // labeldiscount
            // 
            this.labeldiscount.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labeldiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeldiscount.Location = new System.Drawing.Point(335, 305);
            this.labeldiscount.Name = "labeldiscount";
            this.labeldiscount.Size = new System.Drawing.Size(156, 37);
            this.labeldiscount.TabIndex = 18;
            this.labeldiscount.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(68, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 26);
            this.label7.TabIndex = 19;
            this.label7.Text = "Rank";
            // 
            // checkBoxBronze
            // 
            this.checkBoxBronze.AutoSize = true;
            this.checkBoxBronze.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxBronze.Location = new System.Drawing.Point(164, 41);
            this.checkBoxBronze.Name = "checkBoxBronze";
            this.checkBoxBronze.Size = new System.Drawing.Size(103, 30);
            this.checkBoxBronze.TabIndex = 20;
            this.checkBoxBronze.Text = "Bronze";
            this.checkBoxBronze.UseVisualStyleBackColor = true;
            // 
            // checkBoxSilver
            // 
            this.checkBoxSilver.AutoSize = true;
            this.checkBoxSilver.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSilver.Location = new System.Drawing.Point(290, 42);
            this.checkBoxSilver.Name = "checkBoxSilver";
            this.checkBoxSilver.Size = new System.Drawing.Size(89, 30);
            this.checkBoxSilver.TabIndex = 21;
            this.checkBoxSilver.Text = "Silver";
            this.checkBoxSilver.UseVisualStyleBackColor = true;
            // 
            // checkBoxGold
            // 
            this.checkBoxGold.AutoSize = true;
            this.checkBoxGold.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxGold.Location = new System.Drawing.Point(416, 42);
            this.checkBoxGold.Name = "checkBoxGold";
            this.checkBoxGold.Size = new System.Drawing.Size(80, 30);
            this.checkBoxGold.TabIndex = 22;
            this.checkBoxGold.Text = "Gold";
            this.checkBoxGold.UseVisualStyleBackColor = true;
            // 
            // buttonGiftCart
            // 
            this.buttonGiftCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGiftCart.Location = new System.Drawing.Point(73, 387);
            this.buttonGiftCart.Name = "buttonGiftCart";
            this.buttonGiftCart.Size = new System.Drawing.Size(258, 49);
            this.buttonGiftCart.TabIndex = 23;
            this.buttonGiftCart.Text = "Gift Cart";
            this.buttonGiftCart.UseVisualStyleBackColor = true;
            this.buttonGiftCart.Click += new System.EventHandler(this.buttonGiftCart_Click);
            // 
            // textBoxGiftCart
            // 
            this.textBoxGiftCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGiftCart.Location = new System.Drawing.Point(337, 395);
            this.textBoxGiftCart.Name = "textBoxGiftCart";
            this.textBoxGiftCart.Size = new System.Drawing.Size(154, 32);
            this.textBoxGiftCart.TabIndex = 25;
            this.textBoxGiftCart.Text = "0";
            // 
            // CheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(148)))), ((int)(((byte)(79)))));
            this.ClientSize = new System.Drawing.Size(1346, 728);
            this.Controls.Add(this.textBoxGiftCart);
            this.Controls.Add(this.buttonGiftCart);
            this.Controls.Add(this.checkBoxGold);
            this.Controls.Add(this.checkBoxSilver);
            this.Controls.Add(this.checkBoxBronze);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labeldiscount);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxPayment);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOrder);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CheckOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckOut";
            this.Load += new System.EventHandler(this.CheckOut_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxCusPhone;
        private System.Windows.Forms.TextBox textBoxCusName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOrder;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxPayment;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label labeldiscount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxBronze;
        private System.Windows.Forms.CheckBox checkBoxSilver;
        private System.Windows.Forms.CheckBox checkBoxGold;
        private System.Windows.Forms.Button buttonGiftCart;
        private System.Windows.Forms.TextBox textBoxGiftCart;
    }
}