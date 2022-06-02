namespace QuanLyBanHang.Gui
{
    partial class GiftCard
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelCustomerOrder = new System.Windows.Forms.Label();
            this.buttonGiftCard1 = new System.Windows.Forms.Button();
            this.buttonGiftCard2 = new System.Windows.Forms.Button();
            this.buttonGiftcard3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(70, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(585, 368);
            this.dataGridView1.TabIndex = 0;
            // 
            // labelCustomerOrder
            // 
            this.labelCustomerOrder.AutoSize = true;
            this.labelCustomerOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelCustomerOrder.Location = new System.Drawing.Point(243, 37);
            this.labelCustomerOrder.Name = "labelCustomerOrder";
            this.labelCustomerOrder.Size = new System.Drawing.Size(261, 29);
            this.labelCustomerOrder.TabIndex = 1;
            this.labelCustomerOrder.Text = "Customer\'s total order";
            this.labelCustomerOrder.Click += new System.EventHandler(this.labelCustomerOrder_Click);
            // 
            // buttonGiftCard1
            // 
            this.buttonGiftCard1.Location = new System.Drawing.Point(703, 85);
            this.buttonGiftCard1.Name = "buttonGiftCard1";
            this.buttonGiftCard1.Size = new System.Drawing.Size(99, 33);
            this.buttonGiftCard1.TabIndex = 2;
            this.buttonGiftCard1.Text = "Gift Card 1";
            this.buttonGiftCard1.UseVisualStyleBackColor = true;
            this.buttonGiftCard1.Click += new System.EventHandler(this.buttonGiftCard1_Click);
            // 
            // buttonGiftCard2
            // 
            this.buttonGiftCard2.Location = new System.Drawing.Point(703, 146);
            this.buttonGiftCard2.Name = "buttonGiftCard2";
            this.buttonGiftCard2.Size = new System.Drawing.Size(99, 33);
            this.buttonGiftCard2.TabIndex = 3;
            this.buttonGiftCard2.Text = "Gift Card 2";
            this.buttonGiftCard2.UseVisualStyleBackColor = true;
            this.buttonGiftCard2.Click += new System.EventHandler(this.buttonGiftCard2_Click);
            // 
            // buttonGiftcard3
            // 
            this.buttonGiftcard3.Location = new System.Drawing.Point(703, 211);
            this.buttonGiftcard3.Name = "buttonGiftcard3";
            this.buttonGiftcard3.Size = new System.Drawing.Size(99, 34);
            this.buttonGiftcard3.TabIndex = 4;
            this.buttonGiftcard3.Text = "Gift Card 3";
            this.buttonGiftcard3.UseVisualStyleBackColor = true;
            this.buttonGiftcard3.Click += new System.EventHandler(this.buttonGiftcard3_Click);
            // 
            // GiftCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(189)))), ((int)(((byte)(117)))));
            this.ClientSize = new System.Drawing.Size(881, 495);
            this.Controls.Add(this.buttonGiftcard3);
            this.Controls.Add(this.buttonGiftCard2);
            this.Controls.Add(this.buttonGiftCard1);
            this.Controls.Add(this.labelCustomerOrder);
            this.Controls.Add(this.dataGridView1);
            this.Name = "GiftCard";
            this.Text = "GiftCard";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelCustomerOrder;
        private System.Windows.Forms.Button buttonGiftCard1;
        private System.Windows.Forms.Button buttonGiftCard2;
        private System.Windows.Forms.Button buttonGiftcard3;
    }
}